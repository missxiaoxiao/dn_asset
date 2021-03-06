//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.8825
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace XTable {
    
    
    public class XNpcList : CSVReader {
        
        public class RowData :BaseRow {
			public int NPCID;
			public string NPCName;
			public uint PresentID;
			public string NPCIcon;
			public string NPCPortrait;
			public int NPCScene;
			public float[] NPCPosition;
			public float[] NPCRotation;
			public int RequiredTaskID;
			public string Content;
			public string FunctionList;
			public int Gazing;
			public bool OnlyHead;
			public string Voice;
			public string ShowUp;
			public int DisappearTask;
			public int NPCType;
		}


		private RowData[] Table;

		public override int length { get { return Table.Length; } }

		public RowData this[int index] { get { return Table[index]; } }

		public override string bytePath { get { return "Table/XNpcList"; } }
        
        // 二分法查找
        public virtual RowData GetByUID(int id) {
			return BinarySearch(Table, 0, Table.Length - 1, id) as RowData;
        }
        
        public override void OnClear(int lineCount) {
			if (lineCount > 0) Table = new RowData[lineCount];
			else Table = null;
        }
        
        public override void ReadLine(System.IO.BinaryReader reader) {
			RowData row = new RowData();
			Read<int>(reader, ref row.NPCID, intParse); columnno = 0;
			Read<string>(reader, ref row.NPCName, stringParse); columnno = 1;
			Read<uint>(reader, ref row.PresentID, uintParse); columnno = 2;
			Read<string>(reader, ref row.NPCIcon, stringParse); columnno = 3;
			Read<string>(reader, ref row.NPCPortrait, stringParse); columnno = 4;
			Read<int>(reader, ref row.NPCScene, intParse); columnno = 5;
			ReadArray<float>(reader, ref row.NPCPosition, floatParse); columnno = 6;
			ReadArray<float>(reader, ref row.NPCRotation, floatParse); columnno = 7;
			Read<int>(reader, ref row.RequiredTaskID, intParse); columnno = 8;
			Read<string>(reader, ref row.Content, stringParse); columnno = 9;
			Read<string>(reader, ref row.FunctionList, stringParse); columnno = 10;
			Read<int>(reader, ref row.Gazing, intParse); columnno = 11;
			Read<bool>(reader, ref row.OnlyHead, boolParse); columnno = 12;
			Read<string>(reader, ref row.Voice, stringParse); columnno = 13;
			Read<string>(reader, ref row.ShowUp, stringParse); columnno = 14;
			Read<int>(reader, ref row.DisappearTask, intParse); columnno = 15;
			Read<int>(reader, ref row.NPCType, intParse); columnno = 16;
			row.sortID = (int)row.NPCID;
			Table[lineno] = row;
			columnno = -1;
        }
    }
}
