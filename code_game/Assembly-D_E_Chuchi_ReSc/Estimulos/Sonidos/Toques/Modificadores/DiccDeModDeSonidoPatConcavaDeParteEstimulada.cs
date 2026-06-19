using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques.Modificadores
{
	// Token: 0x020002B3 RID: 691
	public static class DiccDeModDeSonidoPatConcavaDeParteEstimulada
	{
		// Token: 0x06000F8A RID: 3978 RVA: 0x0004711C File Offset: 0x0004531C
		static DiccDeModDeSonidoPatConcavaDeParteEstimulada()
		{
			IReadOnlyList<int> enumValoresInt = typeof(ParteDelCuerpoHumano).GetEnumValoresInt();
			DiccDeModDeSonidoPatConcavaDeParteEstimulada.m_modsDeVolumen = new Dictionary<int, float>(enumValoresInt.Count);
			DiccDeModDeSonidoPatConcavaDeParteEstimulada.m_modsDePitch = new Dictionary<int, float>(enumValoresInt.Count);
			foreach (int num in enumValoresInt)
			{
				DiccDeModDeSonidoPatConcavaDeParteEstimulada.m_modsDeVolumen.Add(num, DiccDeModDeSonidoPatConcavaDeParteEstimulada.ModVolDeParte((ParteDelCuerpoHumano)num));
				DiccDeModDeSonidoPatConcavaDeParteEstimulada.m_modsDePitch.Add(num, DiccDeModDeSonidoPatConcavaDeParteEstimulada.ModPitchDeParte((ParteDelCuerpoHumano)num));
			}
		}

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06000F8B RID: 3979 RVA: 0x000471B0 File Offset: 0x000453B0
		public static IReadOnlyDictionary<int, float> modsDeVolumen
		{
			get
			{
				return DiccDeModDeSonidoPatConcavaDeParteEstimulada.m_modsDeVolumen;
			}
		}

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000F8C RID: 3980 RVA: 0x000471B7 File Offset: 0x000453B7
		public static IReadOnlyDictionary<int, float> modsDePitch
		{
			get
			{
				return DiccDeModDeSonidoPatConcavaDeParteEstimulada.m_modsDePitch;
			}
		}

		// Token: 0x06000F8D RID: 3981 RVA: 0x000471C0 File Offset: 0x000453C0
		private static float ModVolDeParte(ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.pene:
				return 1f;
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.piernas:
			case ParteDelCuerpoHumano.lengua:
				return 1.05f;
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.pies:
				return 0.9f;
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.orejas:
				return 0.95f;
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.testiculos:
				return 1.1f;
			default:
				return 1f;
			}
		}

		// Token: 0x06000F8E RID: 3982 RVA: 0x000472A0 File Offset: 0x000454A0
		private static float ModPitchDeParte(ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.pene:
				return 1f;
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.piernas:
			case ParteDelCuerpoHumano.lengua:
				return 0.9f;
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.pies:
				return 1.2f;
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.orejas:
				return 1.1f;
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.testiculos:
				return 0.8f;
			default:
				return 1f;
			}
		}

		// Token: 0x04000CD9 RID: 3289
		private static Dictionary<int, float> m_modsDeVolumen;

		// Token: 0x04000CDA RID: 3290
		private static Dictionary<int, float> m_modsDePitch;
	}
}
