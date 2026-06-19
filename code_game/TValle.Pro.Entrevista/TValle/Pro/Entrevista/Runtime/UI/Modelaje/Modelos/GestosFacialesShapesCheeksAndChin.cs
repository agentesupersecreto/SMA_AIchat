using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x02000033 RID: 51
	[Modelo]
	[Panel(height = 160)]
	[Serializable]
	public class GestosFacialesShapesCheeksAndChin
	{
		// Token: 0x04000127 RID: 295
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Cheek Raise L", "US")]
		public float Expresion_Cheek_Raise_L__RL_24__;

		// Token: 0x04000128 RID: 296
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Cheek Raise R", "US")]
		public float Expresion_Cheek_Raise_R__RL_25__;

		// Token: 0x04000129 RID: 297
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Chin Raise", "US")]
		public float Expresion_Chin_Raise__RL_38__;
	}
}
