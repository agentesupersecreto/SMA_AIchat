using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x0200003A RID: 58
	[Modelo]
	[Panel(height = 290)]
	[Serializable]
	public class LipstickMakeover
	{
		// Token: 0x04000147 RID: 327
		[Modelo]
		[Label("Color", "US", alignment = TextAlignmentOptions.MidlineLeft, fontSizeMod = 0.7f)]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Coloreador_Labios")]
		public MakeoverColorOpacity color = new MakeoverColorOpacity();

		// Token: 0x04000148 RID: 328
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Coloreador_BrilloSecondaryLabios", index = 0)]
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Gloss", "US")]
		public int gloss;
	}
}
