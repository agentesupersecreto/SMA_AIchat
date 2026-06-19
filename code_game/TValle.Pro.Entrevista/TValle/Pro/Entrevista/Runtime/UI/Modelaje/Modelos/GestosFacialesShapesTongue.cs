using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x02000036 RID: 54
	[Modelo]
	[Panel(height = 280)]
	[Serializable]
	public class GestosFacialesShapesTongue
	{
		// Token: 0x04000135 RID: 309
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Curl U", "US")]
		public float ExpresionTongue_Curl_U__RL_14__;

		// Token: 0x04000136 RID: 310
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 120f)]
		[Label("Curl D", "US")]
		public float ExpresionTongue_Curl_D__RL_15__;

		// Token: 0x04000137 RID: 311
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 200f)]
		[Label("Up", "US")]
		public float ExpresionTongue_up__RL_9__;

		// Token: 0x04000138 RID: 312
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(-100f, 100f)]
		[Label("Narrow", "US")]
		public float ExpresionTongue_Narrow__RL_12__;

		// Token: 0x04000139 RID: 313
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 200f)]
		[Label("Out", "US")]
		public float ExpresionTongue_Out__RL_11__;

		// Token: 0x0400013A RID: 314
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 200f)]
		[Label("Raise", "US")]
		public float ExpresionTongue_Raise__RL_10__;

		// Token: 0x0400013B RID: 315
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 120f)]
		[Label("Lower", "US")]
		public float ExpresionTongue_Lower__RL_13__;
	}
}
