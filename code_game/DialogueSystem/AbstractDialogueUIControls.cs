using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000262 RID: 610
	[Serializable]
	public abstract class AbstractDialogueUIControls : AbstractUIControls
	{
		// Token: 0x17000A58 RID: 2648
		// (get) Token: 0x06001A73 RID: 6771
		public abstract AbstractUISubtitleControls NPCSubtitle { get; }

		// Token: 0x17000A59 RID: 2649
		// (get) Token: 0x06001A74 RID: 6772
		public abstract AbstractUISubtitleControls PCSubtitle { get; }

		// Token: 0x17000A5A RID: 2650
		// (get) Token: 0x06001A75 RID: 6773
		public abstract AbstractUIResponseMenuControls ResponseMenu { get; }

		// Token: 0x06001A76 RID: 6774
		public abstract void ShowPanel();

		// Token: 0x06001A77 RID: 6775 RVA: 0x0002D4F0 File Offset: 0x0002B6F0
		public override void SetActive(bool value)
		{
			this.NPCSubtitle.SetActive(value);
			this.PCSubtitle.SetActive(value);
			this.ResponseMenu.SetActive(value);
		}
	}
}
