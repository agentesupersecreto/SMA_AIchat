using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos
{
	// Token: 0x0200004C RID: 76
	[Modelo]
	[Label("Selected Model", alignment = TextAlignmentOptions.MidlineRight)]
	[Panel(tipo = TipoDePanel.nestedContainerConTitulo, controlChildHeight = false, controlChildWidth = true, childForceExpandHeight = false, childForceExpandWidth = true, width = 350)]
	[Serializable]
	public class ModelInfoModelo
	{
		// Token: 0x04000185 RID: 389
		[Ignore]
		public string id;

		// Token: 0x04000186 RID: 390
		[Modelo]
		public ModelImageModelo portrait = new ModelImageModelo();

		// Token: 0x04000187 RID: 391
		[LabelCortoLabelLargoPar]
		public LabelParData modelName = new LabelParData();

		// Token: 0x04000188 RID: 392
		[LabelCortoLabelLargoPar]
		public LabelParData salary = new LabelParData();

		// Token: 0x04000189 RID: 393
		[LabelCortoLabelLargoPar]
		public LabelParData commission = new LabelParData();

		// Token: 0x0400018A RID: 394
		[LabelCortoLabelLargoPar]
		public LabelParData fatigue = new LabelParData();

		// Token: 0x0400018B RID: 395
		[LabelCortoLabelLargoPar]
		public LabelParData JobInterests = new LabelParData();
	}
}
