using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x02000039 RID: 57
	[Modelo]
	[Panel(height = 190)]
	[Serializable]
	public class MakeoverColorOpacity : MakeoverColor
	{
		// Token: 0x04000146 RID: 326
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0, orderOverriden = 3)]
		[Range(0f, 100f)]
		[Label("Opacity", "US")]
		[SecondaryModel(index = 3)]
		public int opacity;
	}
}
