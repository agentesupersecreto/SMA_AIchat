using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.UI.EditingModels.Modelos
{
	// Token: 0x02000089 RID: 137
	[Modelo]
	[FontProConfigUI(alignment = TextAlignmentOptions.Midline)]
	[Panel(tipo = TipoDePanel.nestedContainerConTitulo, width = 450)]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[Serializable]
	public class DesignerEditApparenceAlteratorsModel
	{
		// Token: 0x0600029D RID: 669 RVA: 0x0000FA09 File Offset: 0x0000DC09
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x0400011B RID: 283
		[Ignore]
		[NonSerialized]
		public string title = "Alterators";

		// Token: 0x0400011C RID: 284
		[Ignore]
		public HolderDeAlteradores currentHolder;

		// Token: 0x0400011D RID: 285
		[Ignore]
		public List<Alterador> currentAlteradores;

		// Token: 0x0400011E RID: 286
		[Modelo]
		public List<DesignerEditApparenceAlteratorModel> alteratorSlidersModels;
	}
}
