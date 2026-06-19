using System;
using System.IO;

namespace com.ootii.Utilities
{
	// Token: 0x0200000E RID: 14
	public class JSONData : JSONNode
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00006FEB File Offset: 0x000051EB
		// (set) Token: 0x060000EF RID: 239 RVA: 0x00006FF3 File Offset: 0x000051F3
		public override string Value
		{
			get
			{
				return this.m_Data;
			}
			set
			{
				this.m_Data = value;
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00006FFC File Offset: 0x000051FC
		public JSONData(string aData)
		{
			this.m_Data = aData;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000700B File Offset: 0x0000520B
		public JSONData(float aData)
		{
			this.AsFloat = aData;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000701A File Offset: 0x0000521A
		public JSONData(double aData)
		{
			this.AsDouble = aData;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00007029 File Offset: 0x00005229
		public JSONData(bool aData)
		{
			this.AsBool = aData;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00007038 File Offset: 0x00005238
		public JSONData(int aData)
		{
			this.AsInt = aData;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00007047 File Offset: 0x00005247
		public override string ToString()
		{
			return "\"" + JSONNode.Escape(this.m_Data) + "\"";
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00007063 File Offset: 0x00005263
		public override string ToString(string aPrefix)
		{
			return "\"" + JSONNode.Escape(this.m_Data) + "\"";
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00007080 File Offset: 0x00005280
		public override void Serialize(BinaryWriter aWriter)
		{
			JSONData jsondata = new JSONData("");
			jsondata.AsInt = this.AsInt;
			if (jsondata.m_Data == this.m_Data)
			{
				aWriter.Write(4);
				aWriter.Write(this.AsInt);
				return;
			}
			jsondata.AsFloat = this.AsFloat;
			if (jsondata.m_Data == this.m_Data)
			{
				aWriter.Write(7);
				aWriter.Write(this.AsFloat);
				return;
			}
			jsondata.AsDouble = this.AsDouble;
			if (jsondata.m_Data == this.m_Data)
			{
				aWriter.Write(5);
				aWriter.Write(this.AsDouble);
				return;
			}
			jsondata.AsBool = this.AsBool;
			if (jsondata.m_Data == this.m_Data)
			{
				aWriter.Write(6);
				aWriter.Write(this.AsBool);
				return;
			}
			aWriter.Write(3);
			aWriter.Write(this.m_Data);
		}

		// Token: 0x040000B7 RID: 183
		private string m_Data;
	}
}
