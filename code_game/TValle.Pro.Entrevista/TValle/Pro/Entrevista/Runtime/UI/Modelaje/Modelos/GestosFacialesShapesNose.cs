using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x02000032 RID: 50
	[Modelo]
	[Panel(height = 190)]
	[Serializable]
	public class GestosFacialesShapesNose
	{
		// Token: 0x04000123 RID: 291
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Nose Scrunch", "US")]
		public float Expresion_Nose_Scrunch__RL_27__;

		// Token: 0x04000124 RID: 292
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Flank Raise L", "US")]
		public float Expresion_Nose_Flank_Raise_L__RL_28__;

		// Token: 0x04000125 RID: 293
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Flank Raise R", "US")]
		public float Expresion_Nose_Flank_Raise_R__RL_29__;

		// Token: 0x04000126 RID: 294
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Flank Raise", "US")]
		public float Expresion_Nose_Flank_Raise__RL_30__;
	}
}
