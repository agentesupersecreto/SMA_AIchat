using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x0200003B RID: 59
	[Modelo]
	[Panel(height = 290)]
	[Serializable]
	public class EyebrowsMakeover
	{
		// Token: 0x04000149 RID: 329
		[Modelo]
		[Label("Color", "US", alignment = TextAlignmentOptions.MidlineLeft, fontSizeMod = 0.7f)]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Coloreador_Cejas")]
		public MakeoverColorOpacity color = new MakeoverColorOpacity();

		// Token: 0x0400014A RID: 330
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Texture", "US")]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Coloreador_NormalCejas", index = 0)]
		public int texture;
	}
}
