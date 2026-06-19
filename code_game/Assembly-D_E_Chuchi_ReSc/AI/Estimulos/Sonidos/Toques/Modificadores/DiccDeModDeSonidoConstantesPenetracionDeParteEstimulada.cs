using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.Sonidos.Toques.Modificadores
{
	// Token: 0x020003F8 RID: 1016
	public static class DiccDeModDeSonidoConstantesPenetracionDeParteEstimulada
	{
		// Token: 0x06001633 RID: 5683 RVA: 0x0005CAB8 File Offset: 0x0005ACB8
		static DiccDeModDeSonidoConstantesPenetracionDeParteEstimulada()
		{
			int[] array = new int[] { 9, 32, 31 };
			DiccDeModDeSonidoConstantesPenetracionDeParteEstimulada.m_modsDeVolumen = new Dictionary<int, float>(array.Length);
			DiccDeModDeSonidoConstantesPenetracionDeParteEstimulada.m_modsDePitch = new Dictionary<int, float>(array.Length);
			foreach (int num in array)
			{
				DiccDeModDeSonidoConstantesPenetracionDeParteEstimulada.m_modsDeVolumen.Add(num, DiccDeModDeSonidoConstantesPenetracionDeParteEstimulada.ModVolDeParte((ParteDelCuerpoHumano)num));
				DiccDeModDeSonidoConstantesPenetracionDeParteEstimulada.m_modsDePitch.Add(num, DiccDeModDeSonidoConstantesPenetracionDeParteEstimulada.ModPitchDeParte((ParteDelCuerpoHumano)num));
			}
		}

		// Token: 0x17000574 RID: 1396
		// (get) Token: 0x06001634 RID: 5684 RVA: 0x0005CB25 File Offset: 0x0005AD25
		public static IReadOnlyDictionary<int, float> modsDeVolumen
		{
			get
			{
				return DiccDeModDeSonidoConstantesPenetracionDeParteEstimulada.m_modsDeVolumen;
			}
		}

		// Token: 0x17000575 RID: 1397
		// (get) Token: 0x06001635 RID: 5685 RVA: 0x0005CB2C File Offset: 0x0005AD2C
		public static IReadOnlyDictionary<int, float> modsDePitch
		{
			get
			{
				return DiccDeModDeSonidoConstantesPenetracionDeParteEstimulada.m_modsDePitch;
			}
		}

		// Token: 0x06001636 RID: 5686 RVA: 0x0005CB33 File Offset: 0x0005AD33
		private static float ModVolDeParte(ParteDelCuerpoHumano parte)
		{
			if (parte == ParteDelCuerpoHumano.bocaInterno)
			{
				return 1.1f;
			}
			if (parte == ParteDelCuerpoHumano.ano)
			{
				return 0.8f;
			}
			if (parte != ParteDelCuerpoHumano.vag)
			{
				return 1f;
			}
			return 1f;
		}

		// Token: 0x06001637 RID: 5687 RVA: 0x0005CB5D File Offset: 0x0005AD5D
		private static float ModPitchDeParte(ParteDelCuerpoHumano parte)
		{
			if (parte == ParteDelCuerpoHumano.bocaInterno)
			{
				return 1.2f;
			}
			if (parte == ParteDelCuerpoHumano.ano)
			{
				return 0.8f;
			}
			if (parte != ParteDelCuerpoHumano.vag)
			{
				return 1f;
			}
			return 1f;
		}

		// Token: 0x040011A6 RID: 4518
		private static Dictionary<int, float> m_modsDeVolumen;

		// Token: 0x040011A7 RID: 4519
		private static Dictionary<int, float> m_modsDePitch;
	}
}
