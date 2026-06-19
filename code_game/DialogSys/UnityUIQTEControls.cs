using System;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200001D RID: 29
	[Serializable]
	public class UnityUIQTEControls : AbstractUIQTEControls
	{
		// Token: 0x06000090 RID: 144 RVA: 0x00003ED2 File Offset: 0x000020D2
		public UnityUIQTEControls(Graphic[] qteIndicators)
		{
			this.qteIndicators = qteIndicators;
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00003EE1 File Offset: 0x000020E1
		public override bool AreVisible
		{
			get
			{
				return this.numVisibleQTEIndicators > 0;
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003EEC File Offset: 0x000020EC
		public override void SetActive(bool value)
		{
			if (!value)
			{
				this.numVisibleQTEIndicators = 0;
				Graphic[] array = this.qteIndicators;
				for (int i = 0; i < array.Length; i++)
				{
					Tools.SetGameObjectActive(array[i], false);
				}
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003F21 File Offset: 0x00002121
		public override void ShowIndicator(int index)
		{
			if (this.IsValidQTEIndex(index) && !this.IsQTEIndicatorVisible(index))
			{
				Tools.SetGameObjectActive(this.qteIndicators[index], true);
				this.numVisibleQTEIndicators++;
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003F51 File Offset: 0x00002151
		public override void HideIndicator(int index)
		{
			if (this.IsValidQTEIndex(index) && this.IsQTEIndicatorVisible(index))
			{
				Tools.SetGameObjectActive(this.qteIndicators[index], false);
				this.numVisibleQTEIndicators--;
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003F81 File Offset: 0x00002181
		private bool IsQTEIndicatorVisible(int index)
		{
			return this.IsValidQTEIndex(index) && this.qteIndicators[index].gameObject.activeSelf;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003FA0 File Offset: 0x000021A0
		private bool IsValidQTEIndex(int index)
		{
			return 0 <= index && index < this.qteIndicators.Length;
		}

		// Token: 0x0400005D RID: 93
		public Graphic[] qteIndicators;

		// Token: 0x0400005E RID: 94
		private int numVisibleQTEIndicators;
	}
}
