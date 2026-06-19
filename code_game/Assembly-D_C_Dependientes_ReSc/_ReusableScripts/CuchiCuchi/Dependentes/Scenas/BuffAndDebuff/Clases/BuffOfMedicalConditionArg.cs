using System;
using System.Reflection;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.MapasDeAlteradores.Runtime;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000A8 RID: 168
	public class BuffOfMedicalConditionArg : DisplayableArgumentoDeEfecto<BuffOfMedicalConditionArg>
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000384 RID: 900 RVA: 0x00014284 File Offset: 0x00012484
		public override DisplayableBuffCategory displayableBuffType
		{
			get
			{
				return DisplayableBuffCategory.other;
			}
		}

		// Token: 0x06000385 RID: 901 RVA: 0x00014287 File Offset: 0x00012487
		public bool EstaEnferma()
		{
			return this.lastSicknessLvl > 0f;
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00014298 File Offset: 0x00012498
		public bool IsFlaggedTratamientoComenzo()
		{
			DateTime now = Singleton<TiempoDeJuego>.instance.now;
			return now >= this.fechaDeTratamientoStart && now <= this.fechaDeTratamientoEnd;
		}

		// Token: 0x06000387 RID: 903 RVA: 0x000142D6 File Offset: 0x000124D6
		public void ReforzarTratamiento(float TratamientoEfectividad)
		{
			this.tratamientoEfectividad += TratamientoEfectividad;
			this.tratamientoEfectividad = Mathf.Clamp01(this.tratamientoEfectividad);
		}

		// Token: 0x06000388 RID: 904 RVA: 0x000142F8 File Offset: 0x000124F8
		public void FlagTratamientoComenzo(float TratamientoEfectividad = 1f, float TratamientoRate = 1f)
		{
			this.tratamientoRate = TratamientoRate;
			this.tratamientoEfectividad = TratamientoEfectividad;
			DateTime now = Singleton<TiempoDeJuego>.instance.now;
			this.fechaDeTratamientoStart = now;
			DateTime dateTime = now;
			dateTime = dateTime.AddDays((double)(1f * TratamientoRate * 7f));
			this.fechaDeTratamientoEnd = (this.fechaDeContagio = dateTime);
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00014358 File Offset: 0x00012558
		protected override string GenerateNonLocalizedText(DisplayableBuff buff)
		{
			MemberInfo memberInfo;
			if (DiccionarioDeStrings<DiccionarioDeNombresDeAlteradoresFemeninos>.memberDeNombre.TryGetValue(this.alteratorName, out memberInfo))
			{
				return TextoLocalizadoAttribute.Localizado(memberInfo, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura) + " " + this.lastSicknessLvl.ToString("P0");
			}
			return "Known " + this.lastSicknessLvl.ToString("P0");
		}

		// Token: 0x04000337 RID: 823
		public const float yearsToMaxSickness = 0.5f;

		// Token: 0x04000338 RID: 824
		public const float weeksToMinSickness = 1f;

		// Token: 0x04000339 RID: 825
		public string alteratorName;

		// Token: 0x0400033A RID: 826
		public UDateTime fechaDeContagio;

		// Token: 0x0400033B RID: 827
		public float contagioRate = 1f;

		// Token: 0x0400033C RID: 828
		public UDateTime fechaDeTratamientoStart = DateTime.MinValue;

		// Token: 0x0400033D RID: 829
		public UDateTime fechaDeTratamientoEnd = DateTime.MinValue;

		// Token: 0x0400033E RID: 830
		public float tratamientoRate = 1f;

		// Token: 0x0400033F RID: 831
		public float tratamientoEfectividad = 1f;

		// Token: 0x04000340 RID: 832
		public float maxPainGain = 3f;

		// Token: 0x04000341 RID: 833
		public float maxPainIncreaseV2 = 0.5f;

		// Token: 0x04000342 RID: 834
		public float maxPainExpandV2 = 1.1f;

		// Token: 0x04000343 RID: 835
		public GenericDataOfInteractionMultArg[] painData = Array.Empty<GenericDataOfInteractionMultArg>();

		// Token: 0x04000344 RID: 836
		public bool esModelo;

		// Token: 0x04000345 RID: 837
		public bool esSecretaria;

		// Token: 0x04000346 RID: 838
		public bool esAsistente;

		// Token: 0x04000347 RID: 839
		public bool esMedicalJob;

		// Token: 0x04000348 RID: 840
		public float lastSicknessLvl;
	}
}
