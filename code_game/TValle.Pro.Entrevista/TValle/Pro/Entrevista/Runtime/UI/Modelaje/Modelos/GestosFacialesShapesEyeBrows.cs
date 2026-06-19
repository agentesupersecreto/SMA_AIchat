using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x02000035 RID: 53
	[Modelo]
	[Panel(height = 310)]
	[Serializable]
	public class GestosFacialesShapesEyeBrows
	{
		// Token: 0x0400012D RID: 301
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Raise Inner L", "US")]
		public float Expresion_Brow_Raise_Inner_L__RL_16__;

		// Token: 0x0400012E RID: 302
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Raise Inner R", "US")]
		public float Expresion_Brow_Raise_Inner_R__RL_17__;

		// Token: 0x0400012F RID: 303
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Raise Outer L", "US")]
		public float Expresion_Brow_Raise_Outer_L__RL_18__;

		// Token: 0x04000130 RID: 304
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Raise Outer R", "US")]
		public float Expresion_Brow_Raise_Outer_R__RL_19__;

		// Token: 0x04000131 RID: 305
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Drop L", "US")]
		public float Expresion_Brow_Drop_L__RL_20__;

		// Token: 0x04000132 RID: 306
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Drop R", "US")]
		public float Expresion_Brow_Drop_R__RL_21__;

		// Token: 0x04000133 RID: 307
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Raise L", "US")]
		public float Expresion_Brow_Raise_L__RL_22__;

		// Token: 0x04000134 RID: 308
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Raise R", "US")]
		public float Expresion_Brow_Raise_R__RL_23__;
	}
}
