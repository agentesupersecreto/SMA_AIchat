using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos
{
	// Token: 0x02000053 RID: 83
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[FontProConfigUI(alignment = TextAlignmentOptions.Center, fontStyle = FontStyles.Italic)]
	[Panel]
	[HeightDinamico(dinamicoMethodTarget = "GetHeight")]
	[Serializable]
	public class SessionEndBuffGainCategoria
	{
		// Token: 0x06000281 RID: 641 RVA: 0x0000F784 File Offset: 0x0000D984
		public int GetHeight()
		{
			return 50 + this.items.Count * 50 + 20;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000F79A File Offset: 0x0000D99A
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x040001A7 RID: 423
		[Ignore]
		public string title = "NONE";

		// Token: 0x040001A8 RID: 424
		[TittleLabel]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
		[AsyncDrawed]
		public List<LabelData2> items = new List<LabelData2>();
	}
}
