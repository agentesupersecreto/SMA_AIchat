using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x02000031 RID: 49
	[Modelo]
	[Panel(height = 220)]
	[Serializable]
	public class GestosFacialesShapesEyes
	{
		// Token: 0x0400011E RID: 286
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Enlarge", "US")]
		public float Expresion_Eyelids_Enlarge__RL_42__;

		// Token: 0x0400011F RID: 287
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Squint", "US")]
		public float Expresion_Eyes_Squint__RL_47__;

		// Token: 0x04000120 RID: 288
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Blink", "US")]
		public float Expresion_Eyes_Blink__RL_48__;

		// Token: 0x04000121 RID: 289
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Blink L", "US")]
		public float Expresion_Eye_Blink_L__RL_49__;

		// Token: 0x04000122 RID: 290
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Blink R", "US")]
		public float Expresion_Eye_Blink_R__RL_50__;
	}
}
