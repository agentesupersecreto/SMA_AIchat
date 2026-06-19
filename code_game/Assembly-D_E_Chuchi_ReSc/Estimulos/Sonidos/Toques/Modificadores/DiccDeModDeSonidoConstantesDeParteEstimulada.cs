using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques.Modificadores
{
	// Token: 0x020002B2 RID: 690
	public static class DiccDeModDeSonidoConstantesDeParteEstimulada
	{
		// Token: 0x06000F85 RID: 3973 RVA: 0x00046EB8 File Offset: 0x000450B8
		static DiccDeModDeSonidoConstantesDeParteEstimulada()
		{
			IReadOnlyList<int> enumValoresInt = typeof(ParteDelCuerpoHumano).GetEnumValoresInt();
			DiccDeModDeSonidoConstantesDeParteEstimulada.m_modsDeVolumen = new Dictionary<int, float>(enumValoresInt.Count);
			DiccDeModDeSonidoConstantesDeParteEstimulada.m_modsDePitch = new Dictionary<int, float>(enumValoresInt.Count);
			foreach (int num in enumValoresInt)
			{
				DiccDeModDeSonidoConstantesDeParteEstimulada.m_modsDeVolumen.Add(num, DiccDeModDeSonidoConstantesDeParteEstimulada.ModVolDeParte((ParteDelCuerpoHumano)num));
				DiccDeModDeSonidoConstantesDeParteEstimulada.m_modsDePitch.Add(num, DiccDeModDeSonidoConstantesDeParteEstimulada.ModPitchDeParte((ParteDelCuerpoHumano)num));
			}
		}

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06000F86 RID: 3974 RVA: 0x00046F4C File Offset: 0x0004514C
		public static IReadOnlyDictionary<int, float> modsDeVolumen
		{
			get
			{
				return DiccDeModDeSonidoConstantesDeParteEstimulada.m_modsDeVolumen;
			}
		}

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06000F87 RID: 3975 RVA: 0x00046F53 File Offset: 0x00045153
		public static IReadOnlyDictionary<int, float> modsDePitch
		{
			get
			{
				return DiccDeModDeSonidoConstantesDeParteEstimulada.m_modsDePitch;
			}
		}

		// Token: 0x06000F88 RID: 3976 RVA: 0x00046F5C File Offset: 0x0004515C
		private static float ModVolDeParte(ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.pies:
			case ParteDelCuerpoHumano.testiculos:
				return 1.25f;
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.canillas:
				return 1.175f;
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.piernas:
				return 1f;
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.lengua:
			case ParteDelCuerpoHumano.pene:
				return 0.5f;
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.orejas:
				return 0.75f;
			default:
				return 1f;
			}
		}

		// Token: 0x06000F89 RID: 3977 RVA: 0x0004703C File Offset: 0x0004523C
		private static float ModPitchDeParte(ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.pies:
			case ParteDelCuerpoHumano.testiculos:
				return 1.2f;
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.canillas:
				return 1.1f;
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.piernas:
				return 1f;
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.lengua:
			case ParteDelCuerpoHumano.pene:
				return 0.66f;
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.orejas:
				return 0.733f;
			default:
				return 1f;
			}
		}

		// Token: 0x04000CD7 RID: 3287
		private static Dictionary<int, float> m_modsDeVolumen;

		// Token: 0x04000CD8 RID: 3288
		private static Dictionary<int, float> m_modsDePitch;
	}
}
