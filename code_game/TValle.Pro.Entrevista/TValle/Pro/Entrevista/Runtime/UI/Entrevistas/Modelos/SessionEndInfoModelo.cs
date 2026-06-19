using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos
{
	// Token: 0x02000050 RID: 80
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[Panel(width = 1150, height = 700)]
	[Serializable]
	public class SessionEndInfoModelo
	{
		// Token: 0x06000279 RID: 633 RVA: 0x0000F658 File Offset: 0x0000D858
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x0600027A RID: 634 RVA: 0x0000F660 File Offset: 0x0000D860
		// (remove) Token: 0x0600027B RID: 635 RVA: 0x0000F698 File Offset: 0x0000D898
		public event Action onNextClick;

		// Token: 0x0600027C RID: 636 RVA: 0x0000F6CD File Offset: 0x0000D8CD
		[Label("Leave", "US")]
		[BotonDePanel]
		public void Next()
		{
			Action action = this.onNextClick;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x0400019B RID: 411
		[Ignore]
		public string title = "";

		// Token: 0x0400019D RID: 413
		[TittleLabel]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
		[LayoutDynamicUI(height = 30)]
		public LabelData2 income = new LabelData2();

		// Token: 0x0400019E RID: 414
		[TittleLabel]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
		[LayoutDynamicUI(height = 30)]
		public LabelData2 activityExpGain = new LabelData2();

		// Token: 0x0400019F RID: 415
		[TittleLabel]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
		[LayoutDynamicUI(height = 30)]
		public LabelData2 activityExpTotal = new LabelData2();

		// Token: 0x040001A0 RID: 416
		[TittleLabel]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
		[LayoutDynamicUI(height = 30)]
		public LabelData2 fatigueGain = new LabelData2();

		// Token: 0x040001A1 RID: 417
		[TittleLabel]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
		[LayoutDynamicUI(height = 30)]
		public LabelData2 fatigueTotal = new LabelData2();

		// Token: 0x040001A2 RID: 418
		[Modelo]
		public SessionEndBuffGainPair buff = new SessionEndBuffGainPair();
	}
}
