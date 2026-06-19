using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x02000038 RID: 56
	[Modelo]
	[Panel(height = 160)]
	[Serializable]
	public class MakeoverColor
	{
		// Token: 0x04000143 RID: 323
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0, orderOverriden = 0)]
		[Range(0f, 360f)]
		[Label("Hue", "US")]
		[SecondaryModel(index = 0)]
		public int hue;

		// Token: 0x04000144 RID: 324
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0, orderOverriden = 1)]
		[Range(0f, 100f)]
		[Label("Saturation", "US")]
		[SecondaryModel(index = 1)]
		public int saturation;

		// Token: 0x04000145 RID: 325
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0, orderOverriden = 2)]
		[Range(0f, 100f)]
		[Label("Value ", "US")]
		[SecondaryModel(index = 2)]
		public int value;
	}
}
