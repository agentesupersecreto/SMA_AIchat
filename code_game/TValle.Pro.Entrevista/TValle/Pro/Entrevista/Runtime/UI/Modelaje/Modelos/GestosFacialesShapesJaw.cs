using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x02000034 RID: 52
	[Modelo]
	[Panel(height = 160)]
	[Serializable]
	public class GestosFacialesShapesJaw
	{
		// Token: 0x0400012A RID: 298
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 20f)]
		[Label("Open", "US")]
		public float x;

		// Token: 0x0400012B RID: 299
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Rotate", "US")]
		public float Expresion_Jaw_Rotate_D__RL_58__;

		// Token: 0x0400012C RID: 300
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Move", "US")]
		public float Expresion_Jaw_Move_D__RL_61__Exprecion;
	}
}
