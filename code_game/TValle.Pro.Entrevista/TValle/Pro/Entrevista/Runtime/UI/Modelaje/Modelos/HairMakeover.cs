using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Hair;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x0200003D RID: 61
	[Modelo]
	[Panel(height = 470)]
	[Serializable]
	public class HairMakeover
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x0000BEFA File Offset: 0x0000A0FA
		public static int styleTypesAmount
		{
			get
			{
				return ControlladorDeCabelloGpu.cantidadDeStylosDeCabelloStatic;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x0000BF01 File Offset: 0x0000A101
		[ModeloExtraData(para = "style")]
		private object styleTypesRange
		{
			get
			{
				return new ValueTuple<float, float>(0f, (float)(HairMakeover.styleTypesAmount - 1));
			}
		}

		// Token: 0x0400014D RID: 333
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Label("Style", "US")]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Reemplazador_StyloDeCabello", index = 0)]
		public int style;

		// Token: 0x0400014E RID: 334
		[Modelo]
		[Label("Color", "US", alignment = TextAlignmentOptions.MidlineLeft, fontSizeMod = 0.7f)]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Coloreador_StyloDeCabello")]
		public MakeoverColor hairColor = new MakeoverColor();

		// Token: 0x0400014F RID: 335
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Gloss", "US")]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Coloreador_BrilloDeCabello", index = 0)]
		public int gloss;

		// Token: 0x04000150 RID: 336
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Length", "US")]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Encojedor_CerdasDeCabello", index = 0)]
		public int length;

		// Token: 0x04000151 RID: 337
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Volume", "US")]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Scaler_CerdasDeCabello", index = 0)]
		public int volume;

		// Token: 0x04000152 RID: 338
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Curls Scale", "US")]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Scaler_RisosDeCabello", index = 0)]
		public int curlsScale;

		// Token: 0x04000153 RID: 339
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Curls Freq", "US")]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Incrementador_FrequenciaRisosDeCabello", index = 0)]
		public int curlsFrequency;

		// Token: 0x04000154 RID: 340
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Curls Angle", "US")]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Scaler_AxisDeRisosDeCabello", index = 0)]
		public int curlsAngle;

		// Token: 0x04000155 RID: 341
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		[Label("Loss", "US")]
		[SecondaryModel(type = typeof(DiccionarioDeNombresDeAlteradoresFemeninos), member = "Interpolador_CabelloTip", index = 0)]
		public int loss;
	}
}
