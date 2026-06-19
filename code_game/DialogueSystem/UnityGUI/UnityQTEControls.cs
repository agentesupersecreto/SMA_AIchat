using System;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002D8 RID: 728
	[Serializable]
	public class UnityQTEControls : AbstractUIQTEControls
	{
		// Token: 0x06001DCB RID: 7627 RVA: 0x0003ACBC File Offset: 0x00038EBC
		public UnityQTEControls(GUIControl[] qteIndicators)
		{
			this.qteIndicators = qteIndicators;
		}

		// Token: 0x17000A9B RID: 2715
		// (get) Token: 0x06001DCC RID: 7628 RVA: 0x0003ACCC File Offset: 0x00038ECC
		public override bool AreVisible
		{
			get
			{
				return this.numVisibleQTEIndicators > 0;
			}
		}

		// Token: 0x06001DCD RID: 7629 RVA: 0x0003ACD8 File Offset: 0x00038ED8
		public override void SetActive(bool value)
		{
			if (!value)
			{
				this.numVisibleQTEIndicators = 0;
				foreach (GUIControl guicontrol in this.qteIndicators)
				{
					guicontrol.gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x06001DCE RID: 7630 RVA: 0x0003AD20 File Offset: 0x00038F20
		public override void ShowIndicator(int index)
		{
			if (this.IsValidQTEIndex(index) && !this.IsQTEIndicatorVisible(index))
			{
				this.qteIndicators[index].gameObject.SetActive(true);
				this.numVisibleQTEIndicators++;
			}
		}

		// Token: 0x06001DCF RID: 7631 RVA: 0x0003AD68 File Offset: 0x00038F68
		public override void HideIndicator(int index)
		{
			if (this.IsValidQTEIndex(index) && this.IsQTEIndicatorVisible(index))
			{
				this.qteIndicators[index].gameObject.SetActive(false);
				this.numVisibleQTEIndicators--;
			}
		}

		// Token: 0x06001DD0 RID: 7632 RVA: 0x0003ADB0 File Offset: 0x00038FB0
		private bool IsQTEIndicatorVisible(int index)
		{
			return this.IsValidQTEIndex(index) && this.qteIndicators[index].gameObject.activeSelf;
		}

		// Token: 0x06001DD1 RID: 7633 RVA: 0x0003ADE4 File Offset: 0x00038FE4
		private bool IsValidQTEIndex(int index)
		{
			return 0 <= index && index < this.qteIndicators.Length;
		}

		// Token: 0x0400114F RID: 4431
		public GUIControl[] qteIndicators;

		// Token: 0x04001150 RID: 4432
		private int numVisibleQTEIndicators;
	}
}
