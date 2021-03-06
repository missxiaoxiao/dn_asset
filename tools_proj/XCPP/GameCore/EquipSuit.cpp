/*
 * <auto-generated>
 *	 The code is generated by tools
 *	 Edit manually this code will lead to incorrect behavior
 * </auto-generated>
 */

#include "EquipSuit.h"

EquipSuit::EquipSuit(void)
{
	name = UNITY_STREAM_PATH + "Table/EquipSuit.bytes";
	ReadTable();
}

void EquipSuit::ReadTable()
{
	Open(name.c_str());
	long long filesize =0;
	int lineCnt = 0;
	Read(&filesize);
	Read(&lineCnt);
	m_data.clear();
	for(int i=0;i<lineCnt;i++)
	{
		EquipSuitRow *row = new EquipSuitRow();
		
		Read(&(row->suitid));
		ReadString(row->suitname);
		Read(&(row->level));
		Read(&(row->profid));
		Read(&(row->suitquality));
		Read(&(row->iscreateshow));
		ReadArray<int>(row->equipid);
		ReadString(row->effect1);
		ReadSeq(row->effect2);
		ReadSeq(row->effect3);
		ReadSeq(row->effect4);
		ReadSeq(row->effect5);
		ReadSeq(row->effect6);
		ReadSeq(row->effect7);
		ReadSeq(row->effect8);
		ReadSeq(row->effect9);
		ReadSeq(row->effect10);
		m_data.push_back(row);
		m_map.insert(std::make_pair(row->suitid, row));
	}
	this->Close();
}

void EquipSuit::GetRow(int idx,EquipSuitRow* row)
{
	size_t len = m_data.size();
	if(idx<(int)len)
	{
		*row = *m_data[idx];
	}
	else
	{
		LOG("eror, EquipSuit index out of range, size: "+tostring(len)+" idx: "+tostring(idx));
	}
}

void EquipSuit::GetByUID(uint idx, EquipSuitRow* row)
{
 *row = *m_map[idx];
}

int EquipSuit::GetLength()
{
	return (int)m_data.size();
}


extern "C"
{
	EquipSuit *equipsuit;

	int iGetEquipSuitLength()
	{
		if(equipsuit==NULL)
		{
			equipsuit = new EquipSuit();
		}
		return equipsuit->GetLength();
	}

	void iGetEquipSuitRow(int id,EquipSuitRow* row)
	{
		if(equipsuit==NULL)
		{
			equipsuit = new EquipSuit();
		}
		equipsuit->GetRow(id,row);
	}

	void iGetEquipSuitRowByID(uint id, EquipSuitRow* row)
	{
		if (equipsuit == NULL)
		{
		   equipsuit = new EquipSuit();
		}
		equipsuit->GetByUID(id, row);
	}
}