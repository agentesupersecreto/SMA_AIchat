using System;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem.ChatMapper;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000017 RID: 23
	[Serializable]
	public class Asset
	{
		// Token: 0x0600013D RID: 317 RVA: 0x00005E64 File Offset: 0x00004064
		public Asset()
		{
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00005E6C File Offset: 0x0000406C
		public Asset(Asset sourceAsset)
		{
			this.id = sourceAsset.id;
			this.fields = Field.CopyFields(sourceAsset.fields);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00005E94 File Offset: 0x00004094
		public Asset(int chatMapperID, List<Field> chatMapperFields)
		{
			this.Assign(chatMapperID, chatMapperFields);
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000140 RID: 320 RVA: 0x00005EA4 File Offset: 0x000040A4
		// (set) Token: 0x06000141 RID: 321 RVA: 0x00005EB8 File Offset: 0x000040B8
		public string Name
		{
			get
			{
				return Field.LookupValue(this.fields, "Name");
			}
			set
			{
				Field.SetValue(this.fields, "Name", value);
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00005ECC File Offset: 0x000040CC
		public string LocalizedName
		{
			get
			{
				return Field.LookupLocalizedValue(this.fields, "Name");
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00005EE0 File Offset: 0x000040E0
		public void Assign(int chatMapperID, List<Field> chatMapperFields)
		{
			this.id = chatMapperID;
			this.fields = Field.CreateListFromChatMapperFields(chatMapperFields);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00005EF8 File Offset: 0x000040F8
		public bool FieldExists(string title)
		{
			return Field.FieldExists(this.fields, title);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00005F08 File Offset: 0x00004108
		public string LookupValue(string title)
		{
			return Field.LookupValue(this.fields, title);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00005F18 File Offset: 0x00004118
		public string LookupLocalizedValue(string title)
		{
			return Field.LookupLocalizedValue(this.fields, title);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00005F28 File Offset: 0x00004128
		public int LookupInt(string title)
		{
			return Field.LookupInt(this.fields, title);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00005F38 File Offset: 0x00004138
		public float LookupFloat(string title)
		{
			return Field.LookupFloat(this.fields, title);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00005F48 File Offset: 0x00004148
		public bool LookupBool(string title)
		{
			return Field.LookupBool(this.fields, title);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00005F58 File Offset: 0x00004158
		public bool IsFieldAssigned(string title)
		{
			return Field.IsFieldAssigned(this.fields, title);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00005F68 File Offset: 0x00004168
		public Field AssignedField(string title)
		{
			return Field.AssignedField(this.fields, title);
		}

		// Token: 0x04000070 RID: 112
		public int id;

		// Token: 0x04000071 RID: 113
		public List<Field> fields;
	}
}
