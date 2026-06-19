using System;

namespace PixelCrushers.DialogueSystem.Articy
{
	// Token: 0x02000047 RID: 71
	[Serializable]
	public class ConversionSetting
	{
		// Token: 0x06000296 RID: 662 RVA: 0x0000D660 File Offset: 0x0000B860
		public ConversionSetting()
		{
			this.Assign(null);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000D670 File Offset: 0x0000B870
		public ConversionSetting(string id)
		{
			this.Assign(id);
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000298 RID: 664 RVA: 0x0000D680 File Offset: 0x0000B880
		// (set) Token: 0x06000299 RID: 665 RVA: 0x0000D688 File Offset: 0x0000B888
		public string Id { get; set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600029A RID: 666 RVA: 0x0000D694 File Offset: 0x0000B894
		// (set) Token: 0x0600029B RID: 667 RVA: 0x0000D69C File Offset: 0x0000B89C
		public bool Include { get; set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600029C RID: 668 RVA: 0x0000D6A8 File Offset: 0x0000B8A8
		// (set) Token: 0x0600029D RID: 669 RVA: 0x0000D6B0 File Offset: 0x0000B8B0
		public EntityCategory Category { get; set; }

		// Token: 0x0600029E RID: 670 RVA: 0x0000D6BC File Offset: 0x0000B8BC
		private void Assign(string id)
		{
			this.Id = id;
			this.Include = !string.IsNullOrEmpty(id);
			this.Category = EntityCategory.NPC;
		}
	}
}
