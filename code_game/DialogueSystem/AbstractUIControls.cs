using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000264 RID: 612
	[Serializable]
	public abstract class AbstractUIControls
	{
		// Token: 0x06001A7E RID: 6782
		public abstract void SetActive(bool value);

		// Token: 0x06001A7F RID: 6783 RVA: 0x0002D578 File Offset: 0x0002B778
		public void Show()
		{
			this.SetActive(true);
		}

		// Token: 0x06001A80 RID: 6784 RVA: 0x0002D584 File Offset: 0x0002B784
		public void Hide()
		{
			this.SetActive(false);
		}
	}
}
