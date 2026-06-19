using System;
using PixelCrushers.DialogueSystem.ChatMapper;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000023 RID: 35
	[Serializable]
	public class Item : Asset
	{
		// Token: 0x060001E3 RID: 483 RVA: 0x00008C14 File Offset: 0x00006E14
		public Item()
		{
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00008C1C File Offset: 0x00006E1C
		public Item(Item sourceItem)
			: base(sourceItem)
		{
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00008C28 File Offset: 0x00006E28
		public Item(Item chatMapperItem)
		{
			this.Assign(chatMapperItem);
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x00008C38 File Offset: 0x00006E38
		// (set) Token: 0x060001E7 RID: 487 RVA: 0x00008C48 File Offset: 0x00006E48
		public bool IsItem
		{
			get
			{
				return base.LookupBool("Is Item");
			}
			set
			{
				Field.SetValue(this.fields, "Is Item", value);
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x00008C5C File Offset: 0x00006E5C
		// (set) Token: 0x060001E9 RID: 489 RVA: 0x00008C6C File Offset: 0x00006E6C
		public string Group
		{
			get
			{
				return base.LookupValue("Group");
			}
			set
			{
				Field.SetValue(this.fields, "Group", value);
			}
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00008C80 File Offset: 0x00006E80
		public void Assign(Item chatMapperItem)
		{
			if (chatMapperItem != null)
			{
				base.Assign(chatMapperItem.ID, chatMapperItem.Fields);
			}
		}
	}
}
