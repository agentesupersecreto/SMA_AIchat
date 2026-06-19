using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Controladores;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x0200003C RID: 60
	[Modelo]
	[Panel(height = 130)]
	[Serializable]
	public class MakeUpMakeover
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060001DE RID: 478 RVA: 0x0000BED2 File Offset: 0x0000A0D2
		public static int styleTypesAmount
		{
			get
			{
				return ControlladorDeFemaleMakeUp.cantidadDeTexturasStatic;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060001DF RID: 479 RVA: 0x0000BED9 File Offset: 0x0000A0D9
		[ModeloExtraData(para = "style")]
		private object styleTypesRange
		{
			get
			{
				return new ValueTuple<float, float>(0f, (float)(MakeUpMakeover.styleTypesAmount - 1));
			}
		}

		// Token: 0x0400014B RID: 331
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Label("Style", "US")]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Textureador_HeadDecals", index = 0)]
		public int style;

		// Token: 0x0400014C RID: 332
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Opacity", "US")]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Textureador_HeadDecalsAlpha", index = 0)]
		public float opacity;
	}
}
