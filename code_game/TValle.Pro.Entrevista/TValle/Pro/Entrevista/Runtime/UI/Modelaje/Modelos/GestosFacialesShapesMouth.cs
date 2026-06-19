using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x0200002F RID: 47
	[Modelo]
	[Panel(height = 280)]
	[Serializable]
	public class GestosFacialesShapesMouth
	{
		// Token: 0x04000106 RID: 262
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Closed", "US")]
		public float Expresion_Open__RL_1__;

		// Token: 0x04000107 RID: 263
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Explosive", "US")]
		public float Expresion_Explosive__RL_2__;

		// Token: 0x04000108 RID: 264
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Tight O", "US")]
		public float Expresion_Tight_O__RL_4__;

		// Token: 0x04000109 RID: 265
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Tight", "US")]
		public float Expresion_Tight__RL_5__;

		// Token: 0x0400010A RID: 266
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Wide", "US")]
		public float Expresion_Wide__RL_6__;

		// Token: 0x0400010B RID: 267
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Affricate", "US")]
		public float Expresion_Affricate__RL_7__;

		// Token: 0x0400010C RID: 268
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Open", "US")]
		public float Expresion_Mouth_Open__RL_44__;
	}
}
