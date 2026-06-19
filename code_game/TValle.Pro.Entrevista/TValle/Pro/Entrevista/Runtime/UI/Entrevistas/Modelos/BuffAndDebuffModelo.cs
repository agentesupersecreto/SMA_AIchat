using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos
{
	// Token: 0x02000048 RID: 72
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[FontProConfigUI(alignment = TextAlignmentOptions.TopLeft, fontStyle = FontStyles.Normal)]
	[Panel(width = 550, height = 750, childForceExpandHeight = false, childForceExpandWidth = true, controlChildWidth = true, unlockFlexibleIfWidthWasSet = true, unlockParentFlexibleIfWidthWasSet = true)]
	[Cerrable(accion = CerrableAttribute.Accion.destruir)]
	[Serializable]
	public class BuffAndDebuffModelo
	{
		// Token: 0x0600024A RID: 586 RVA: 0x0000EFA8 File Offset: 0x0000D1A8
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x04000177 RID: 375
		[Ignore]
		public string title = "NONE";

		// Token: 0x04000178 RID: 376
		[AsyncDrawed]
		[TittleLabel]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
		public List<LabelData2> items = new List<LabelData2>();
	}
}
