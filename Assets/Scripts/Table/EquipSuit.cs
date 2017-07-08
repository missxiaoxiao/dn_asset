//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace XTable {
    using UnityEngine;
    using System.IO;
    
    
    public class EquipSuit : CVSReader {
        
        public class RowData{
			public int SuitID;
			public string SuitName;
			public int Level;
			public int ProfID;
			public int SuitQuality;
			public bool IsCreateShow;
			public int[] EquipID;
			public string Effect1;
			public string Effect2;
			public string Effect3;
			public string Effect4;
			public string Effect5;
			public string Effect6;
			public string Effect7;
			public string Effect8;
			public string Effect9;
			public string Effect10;
		}


		public EquipSuit() { if (Table == null) Create(); }

		public RowData[] Table = null;

		public override string bytePath { get { return "Table/EquipSuit"; } }
        
        public override void OnClear(int lineCount) {
			if (lineCount > 0) Table = new RowData[lineCount];
			else Table = null;
        }
        
        public override void ReadLine(System.IO.BinaryReader reader) {
			RowData row = new RowData();
			Read<int>(reader, ref row.SuitID, intParse); columnno = 0;
			Read<string>(reader, ref row.SuitName, stringParse); columnno = 1;
			Read<int>(reader, ref row.Level, intParse); columnno = 2;
			Read<int>(reader, ref row.ProfID, intParse); columnno = 3;
			Read<int>(reader, ref row.SuitQuality, intParse); columnno = 4;
			Read<bool>(reader, ref row.IsCreateShow, boolParse); columnno = 5;
			ReadArray<int>(reader, ref row.EquipID, intParse); columnno = 6;
			Read<string>(reader, ref row.Effect1, stringParse); columnno = 7;
			Read<string>(reader, ref row.Effect2, stringParse); columnno = 8;
			Read<string>(reader, ref row.Effect3, stringParse); columnno = 9;
			Read<string>(reader, ref row.Effect4, stringParse); columnno = 10;
			Read<string>(reader, ref row.Effect5, stringParse); columnno = 11;
			Read<string>(reader, ref row.Effect6, stringParse); columnno = 12;
			Read<string>(reader, ref row.Effect7, stringParse); columnno = 13;
			Read<string>(reader, ref row.Effect8, stringParse); columnno = 14;
			Read<string>(reader, ref row.Effect9, stringParse); columnno = 15;
			Read<string>(reader, ref row.Effect10, stringParse); columnno = 16;
			Table[lineno] = row;
			columnno = -1;
        }
    }
}
