using System;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002DB RID: 731
	[Serializable]
	public class UnityUIRoot : AbstractUIRoot
	{
		// Token: 0x06001DE5 RID: 7653 RVA: 0x0003B498 File Offset: 0x00039698
		public UnityUIRoot(GUIRoot guiRoot)
		{
			this.guiRoot = guiRoot;
		}

		// Token: 0x06001DE6 RID: 7654 RVA: 0x0003B4A8 File Offset: 0x000396A8
		public override void Show()
		{
			if (this.guiRoot != null)
			{
				this.guiRoot.gameObject.SetActive(true);
				this.guiRoot.ManualRefresh();
			}
		}

		// Token: 0x06001DE7 RID: 7655 RVA: 0x0003B4D8 File Offset: 0x000396D8
		public override void Hide()
		{
			if (this.guiRoot != null)
			{
				this.guiRoot.gameObject.SetActive(false);
			}
		}

		// Token: 0x0400115F RID: 4447
		private GUIRoot guiRoot;
	}
}
