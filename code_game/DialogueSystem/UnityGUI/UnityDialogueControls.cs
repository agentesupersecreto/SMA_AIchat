using System;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002D6 RID: 726
	[Serializable]
	public class UnityDialogueControls : AbstractDialogueUIControls
	{
		// Token: 0x17000A98 RID: 2712
		// (get) Token: 0x06001DC4 RID: 7620 RVA: 0x0003ABE0 File Offset: 0x00038DE0
		public override AbstractUISubtitleControls NPCSubtitle
		{
			get
			{
				return this.npcSubtitle;
			}
		}

		// Token: 0x17000A99 RID: 2713
		// (get) Token: 0x06001DC5 RID: 7621 RVA: 0x0003ABE8 File Offset: 0x00038DE8
		public override AbstractUISubtitleControls PCSubtitle
		{
			get
			{
				return this.pcSubtitle;
			}
		}

		// Token: 0x17000A9A RID: 2714
		// (get) Token: 0x06001DC6 RID: 7622 RVA: 0x0003ABF0 File Offset: 0x00038DF0
		public override AbstractUIResponseMenuControls ResponseMenu
		{
			get
			{
				return this.responseMenu;
			}
		}

		// Token: 0x06001DC7 RID: 7623 RVA: 0x0003ABF8 File Offset: 0x00038DF8
		public override void ShowPanel()
		{
			UnityDialogueUIControls.SetControlActive(this.panel, true);
		}

		// Token: 0x06001DC8 RID: 7624 RVA: 0x0003AC08 File Offset: 0x00038E08
		public override void SetActive(bool value)
		{
			base.SetActive(value);
			UnityDialogueUIControls.SetControlActive(this.panel, value);
		}

		// Token: 0x0400114B RID: 4427
		public GUIControl panel;

		// Token: 0x0400114C RID: 4428
		public UnitySubtitleControls npcSubtitle;

		// Token: 0x0400114D RID: 4429
		public UnitySubtitleControls pcSubtitle;

		// Token: 0x0400114E RID: 4430
		public UnityResponseMenuControls responseMenu;
	}
}
