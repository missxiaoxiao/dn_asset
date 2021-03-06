/*
 * <auto-generated>
 *	 The code is generated by tools
 *	 Edit manually this code will lead to incorrect behavior
 * </auto-generated>
 */

#ifndef __DefaultEquip__
#define __DefaultEquip__

#include "NativeReader.h"
#include "Log.h"
#include <vector>
#include <unordered_map>


struct DefaultEquipRow
{
	
	uint profid;
	char profname[MaxStringSize];
	char face[MaxStringSize];
	char hair[MaxStringSize];
	char helmet[MaxStringSize];
	char body[MaxStringSize];
	char leg[MaxStringSize];
	char glove[MaxStringSize];
	char boots[MaxStringSize];
	char weapon[MaxStringSize];
	char secondweapon[MaxStringSize];
	char wing[MaxStringSize];
	char tail[MaxStringSize];
	char decal[MaxStringSize];
	char weaponpoint[MaxStringSize];
	char wingpoint[MaxStringSize];
	char tailpoint[MaxStringSize];
	char fishingpoint[MaxStringSize];
	char sideweaponpoint[MaxStringSize];
};

class DefaultEquip:public NativeReader
{
public:
	DefaultEquip(void);
	void ReadTable();
	void GetRow(int val,DefaultEquipRow* row);
	void GetByUID(uint id, DefaultEquipRow* row);
	int GetLength();

protected:
	std::string name;
	std::vector<DefaultEquipRow*> m_data;
	std::unordered_map<uint, DefaultEquipRow*> m_map;
};


extern "C"
{
	ENGINE_INTERFACE_EXPORT int iGetDefaultEquipLength();
	ENGINE_INTERFACE_EXPORT void iGetDefaultEquipRow(int idx,DefaultEquipRow* row);
	ENGINE_INTERFACE_EXPORT void iGetDefaultEquipRowByID(uint id, DefaultEquipRow* row);
};

#endif