#ifndef  __XEntityMgr__
#define  __XEntityMgr__

#include <vector>
#include <unordered_map>
#include <unordered_set>
#include "Common.h"
#include "Singleton.h"
#include "GameObjectMgr.h"
#include "XNpcList.h"
#include "XAttributes.h"


class XEntity;
class XRole;
class XPlayer;
class Vector3;
class XAttributes;
class GameObject;
class Transform;

enum EntityType
{
	//表现
	Entity = 1 << 0,
	Role = 1 << 1,
	Player = 1 << 2,
	Monster = 1 << 3,
	Boss = 1 << 4,
	Npc = 1 << 5,

	//同盟
	Ship_Start = 6,
	Enemy = 1 << 6, //敌对 
	Ally = 1 << 7,  //友好
	AllyAll = 1 << 8, //双方友好 如礼物
	EnemyAll = 1 << 9, //双方敌对 如风火轮
	EProtected = 1 << 10,//敌对但不可受击 如隐形怪
	AProtected = 1 << 11,//友军不可受击 如安全区域
	Ship_End = 11
};

class XEntityMgr:public Singleton<XEntityMgr>
{
public:
	~XEntityMgr();
	void Update(float delta);
	void AttachToHost();
	void DetachFromHost();
	XEntity* GetEntity(uint id);
	XPlayer* CreatePlayer();
	XEntity* CreateNPC(XNpcListRow& row,Vector3 pos,Vector3 rot);
	void UnloadAll();
	void PrepareEntity(XAttributes* attr,XEntity* ent);
	void UnloadEntity(uint id);

	template<typename T>
	XEntity* CreateEntity(uint staticid, Vector3 pos, Vector3 rot);

	void InitAttr(int, XAttributes*);
	std::vector<XEntity*> GetAllEnemy(XEntity* e);
	std::vector<XEntity*> GetAllAlly(XEntity* e);
	std::vector<XEntity*> GetAllNPC();

public:
	XPlayer* Player;


private:
	bool Add(EntityType type, XEntity* e);
	XAttributes* InitAttrByPresent(uint presentID);

	std::vector<XEntity*> _empty;
	std::unordered_set<XEntity*> _hash_entities;
	std::unordered_map<uint, XEntity*> _dic_entities;
	std::unordered_map<int, std::vector<XEntity*>> _map_entities;
};

template<typename T>
XEntity* XEntityMgr::CreateEntity(uint staticid, Vector3 pos, Vector3 rot)
{
	XAttributes* attr = new XAttributes();
	InitAttr(staticid, attr);
	attr->setAppearPosition(pos);
	attr->setAppearQuaternion(rot);
	XEntity* ent = new T();
	PrepareEntity(attr, ent);
	Add(Entity, ent);
	return ent;
}

#endif