﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XTable;

public class XAnimComponent : XComponent
{
    private Animator m_Animator;
    private AnimatorOverrideController m_overrideController = null;
    private string m_stateName = "";
    private int m_playLayer = 0;
    private bool m_crossFade = false;
    //表示一个常数持有负无穷大
    private float m_normalizedTime = float.NegativeInfinity;
    private string m_triggerName = "";
    private float m_speed = 1;
    private float m_value = 0;
    private bool m_enable = true;


    public override void OnInitial(XEntity _entity)
    {
        base.OnInitial(_entity);
        m_Animator = _entity.EntityObject.GetComponent<Animator>();
        if (m_Animator.runtimeAnimatorController is AnimatorOverrideController)
        {
            m_overrideController = m_Animator.runtimeAnimatorController as AnimatorOverrideController;
        }
        else
        {
            m_overrideController = new AnimatorOverrideController();
            m_overrideController.runtimeAnimatorController = m_Animator.runtimeAnimatorController;
            m_Animator.runtimeAnimatorController = m_overrideController;
        }
        m_Animator.Rebind();
     
    }

    public override void OnUninit()
    {
        Reset();
        base.OnUninit();
    }


    bool init = false;
    public void OverrideAnims(XEntityPresentation.RowData row)
    {
        if (!init)
        {
            init = true;
            OverrideAnim("A", row.AnimLocation + row.A);
            OverrideAnim("AA", row.AnimLocation + row.AA);
            OverrideAnim("AAA", row.AnimLocation + row.AAA);
            OverrideAnim("AAAA", row.AnimLocation + row.AAAA);
            OverrideAnim("AAAAA", row.AnimLocation + row.AAAAA);
            OverrideAnim("Walk", row.AnimLocation + row.Walk);
            OverrideAnim("Idle", row.AnimLocation + row.Idle);
            OverrideAnim("Death", row.AnimLocation + row.Death);
            OverrideAnim("Run", row.AnimLocation + row.Run);
            OverrideAnim("RunLeft", row.AnimLocation + row.RunLeft);
            OverrideAnim("RunRight", row.AnimLocation + row.RunRight);
            OverrideAnim("Freezed", row.AnimLocation + row.Freeze);
            OverrideAnim("HitLanding", row.AnimLocation + row.Hit_l);
        }
    }

    public void SyncSpeed(float speed)
    {
        if (m_Animator != null)
        {
            m_speed = speed;
            m_Animator.speed = m_speed;
        }
    }

    public void CrossFade(string stateName, float transitionDuration, int layer, float normalizedTime)
    {
        m_stateName = stateName;
        m_value = transitionDuration;
        m_playLayer = layer;
        m_normalizedTime = normalizedTime;
        m_crossFade = true;
        if (IsAnimStateValid())
        {
            RealPlay();
        }
    }

    public void SetTrigger(string name)
    {
        m_triggerName = name;
        if (m_Animator != null && m_Animator != null)
        {
            m_Animator.SetTrigger(m_triggerName);
        }
    }

    public void SyncEnable(bool enable)
    {
        if (m_Animator != null )
        {
            m_enable = enable;
            m_Animator.enabled = m_enable;
        }
    }

    public void Play(string stateName, int layer, float normalizedTime)
    {
        m_stateName = stateName;
        m_playLayer = layer;
        m_normalizedTime = normalizedTime;
        m_crossFade = false;
        if (IsAnimStateValid())
        {
            RealPlay();
        }
    }

    public void Play(string stateName, int layer)
    {
        m_stateName = stateName;
        m_playLayer = layer;
        m_normalizedTime = float.NegativeInfinity;
        m_crossFade = false;
        if (IsAnimStateValid())
        {
            RealPlay();
        }
    }


    public void RealPlay()
    {
        if (m_Animator != null)
        {
            if (m_crossFade)
            {
                m_Animator.CrossFade(m_stateName, m_value, m_playLayer, m_normalizedTime);
            }
            else
            {
                m_Animator.Play(m_stateName, m_playLayer, m_normalizedTime);
            }
        }
    }

    public bool IsAnimStateValid()
    {
        if (m_Animator==null) return false;
        if (string.IsNullOrEmpty(m_stateName))
            return false;
        return true;
    }


    public void OverrideAnim(string key, string clippath)
    {
        if (string.IsNullOrEmpty(clippath) || m_Animator == null || m_overrideController == null)
            return;

        if(m_overrideController[key] ==null)
        {
            m_overrideController[key] = XResourceMgr.Load<AnimationClip>("Animation/"+clippath);
        }
    }

    public void Reset()
    {
        if (m_Animator != null)
        {
            m_Animator.cullingMode = AnimatorCullingMode.BasedOnRenderers;
            m_Animator.enabled = false;
            m_Animator = null;
        }
        if (m_overrideController != null)
        {
            AnimationClipPair[] clips = m_overrideController.clips;
            for (int i = 0; i < clips.Length; ++i)
            {
                AnimationClipPair clip = clips[i];
                if (clip.overrideClip != null)
                {
                    m_overrideController[clip.originalClip.name] = null;
                }
            }
            m_overrideController = null;
        }
        m_stateName = "";
        m_value = -1;
        m_playLayer = -1;
        m_normalizedTime = float.NegativeInfinity;
        m_triggerName = "";
    }

}
