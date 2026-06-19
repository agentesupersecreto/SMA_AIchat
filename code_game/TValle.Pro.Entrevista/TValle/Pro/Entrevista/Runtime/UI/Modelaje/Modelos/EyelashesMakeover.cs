using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Controladores;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x0200003E RID: 62
	[Modelo]
	[Panel(height = 130)]
	[Serializable]
	public class EyelashesMakeover
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x0000BF2D File Offset: 0x0000A12D
		public static int styleTypesAmount
		{
			get
			{
				return ControlladorDeFemaleEyeLashesApariencia.cantidadDeTexturasStatic;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x0000BF34 File Offset: 0x0000A134
		[ModeloExtraData(para = "style")]
		private object styleTypesRange
		{
			get
			{
				return new ValueTuple<float, float>(0f, (float)(EyelashesMakeover.styleTypesAmount - 1));
			}
		}

		// Token: 0x04000156 RID: 342
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Label("Style", "US")]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Textureador_EyeLashes", index = 0)]
		public int style;

		// Token: 0x04000157 RID: 343
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Opacity", "US")]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Coloreador_EyeLashes", index = 3)]
		public float opacity;
	}
}
