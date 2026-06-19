using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques.Modificadores
{
	// Token: 0x020002B4 RID: 692
	public static class DiccDeModDeSonidoPatDeParteEstimulada
	{
		// Token: 0x06000F8F RID: 3983 RVA: 0x00047380 File Offset: 0x00045580
		static DiccDeModDeSonidoPatDeParteEstimulada()
		{
			IReadOnlyList<int> enumValoresInt = typeof(ParteDelCuerpoHumano).GetEnumValoresInt();
			DiccDeModDeSonidoPatDeParteEstimulada.m_modsDeVolumen = new Dictionary<int, float>(enumValoresInt.Count);
			DiccDeModDeSonidoPatDeParteEstimulada.m_modsDePitch = new Dictionary<int, float>(enumValoresInt.Count);
			foreach (int num in enumValoresInt)
			{
				DiccDeModDeSonidoPatDeParteEstimulada.m_modsDeVolumen.Add(num, DiccDeModDeSonidoPatDeParteEstimulada.ModVolDeParte((ParteDelCuerpoHumano)num));
				DiccDeModDeSonidoPatDeParteEstimulada.m_modsDePitch.Add(num, DiccDeModDeSonidoPatDeParteEstimulada.ModPitchDeParte((ParteDelCuerpoHumano)num));
			}
		}

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000F90 RID: 3984 RVA: 0x00047414 File Offset: 0x00045614
		public static IReadOnlyDictionary<int, float> modsDeVolumen
		{
			get
			{
				return DiccDeModDeSonidoPatDeParteEstimulada.m_modsDeVolumen;
			}
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000F91 RID: 3985 RVA: 0x0004741B File Offset: 0x0004561B
		public static IReadOnlyDictionary<int, float> modsDePitch
		{
			get
			{
				return DiccDeModDeSonidoPatDeParteEstimulada.m_modsDePitch;
			}
		}

		// Token: 0x06000F92 RID: 3986 RVA: 0x00047424 File Offset: 0x00045624
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

		// Token: 0x06000F93 RID: 3987 RVA: 0x00047504 File Offset: 0x00045704
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
				return 0.75f;
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.pies:
				return 1.25f;
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.orejas:
				return 1.15f;
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.testiculos:
				return 0.666f;
			default:
				return 1f;
			}
		}

		// Token: 0x04000CDB RID: 3291
		private static Dictionary<int, float> m_modsDeVolumen;

		// Token: 0x04000CDC RID: 3292
		private static Dictionary<int, float> m_modsDePitch;
	}
}
