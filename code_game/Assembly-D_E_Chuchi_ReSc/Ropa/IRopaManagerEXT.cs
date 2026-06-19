using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000D6 RID: 214
	public static class IRopaManagerEXT
	{
		// Token: 0x06000540 RID: 1344 RVA: 0x00018520 File Offset: 0x00016720
		public static void CorregirPartesExpuestasSiEstanVestidas(this IRopaManager manager, IList<ParteDelCuerpoHumano> expuestas)
		{
			try
			{
				int cubriendoFlags = (int)manager.cubriendoFlags;
				for (int i = 0; i < expuestas.Count; i++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano = expuestas[i];
					bool flag = parteDelCuerpoHumano.EsAnalInteraction();
					bool flag2 = parteDelCuerpoHumano.EsVaginalInteraction();
					bool flag3 = parteDelCuerpoHumano == ParteDelCuerpoHumano.pezones;
					RopaCubre ropaCubre;
					if ((flag || flag2 || flag3) && parteDelCuerpoHumano.TryParce(out ropaCubre) && cubriendoFlags.HasFlag((int)ropaCubre))
					{
						if (flag)
						{
							parteDelCuerpoHumano = ParteDelCuerpoHumano.nalgas;
						}
						if (flag2)
						{
							parteDelCuerpoHumano = ParteDelCuerpoHumano.vientreBajo;
						}
						if (flag3)
						{
							parteDelCuerpoHumano = ParteDelCuerpoHumano.senos;
						}
					}
					if (IRopaManagerEXT.m_TempSet.Add((int)parteDelCuerpoHumano))
					{
						IRopaManagerEXT.m_Temp.Add(parteDelCuerpoHumano);
					}
				}
				expuestas.Clear();
				for (int j = 0; j < IRopaManagerEXT.m_Temp.Count; j++)
				{
					expuestas.Add(IRopaManagerEXT.m_Temp[j]);
				}
			}
			finally
			{
				IRopaManagerEXT.m_Temp.Clear();
				IRopaManagerEXT.m_TempSet.Clear();
			}
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x00018604 File Offset: 0x00016804
		public static void TransferirCorregiendoPartesExpuestasSiEstanVestidas(this IRopaManager manager, IReadOnlyList<ParteDelCuerpoHumano> expuestasSource, List<ParteDelCuerpoHumano> expuestasResultado, HashSet<int> expuestasResultadoSet)
		{
			int cubriendoFlags = (int)manager.cubriendoFlags;
			for (int i = 0; i < expuestasSource.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = expuestasSource[i];
				bool flag = parteDelCuerpoHumano.EsAnalInteraction();
				bool flag2 = parteDelCuerpoHumano.EsVaginalInteraction();
				bool flag3 = parteDelCuerpoHumano == ParteDelCuerpoHumano.pezones;
				RopaCubre ropaCubre;
				if ((flag || flag2 || flag3) && parteDelCuerpoHumano.TryParce(out ropaCubre) && cubriendoFlags.HasFlag((int)ropaCubre))
				{
					if (flag)
					{
						parteDelCuerpoHumano = ParteDelCuerpoHumano.nalgas;
					}
					if (flag2)
					{
						parteDelCuerpoHumano = ParteDelCuerpoHumano.vientreBajo;
					}
					if (flag3)
					{
						parteDelCuerpoHumano = ParteDelCuerpoHumano.senos;
					}
				}
				if (expuestasResultadoSet.Add((int)parteDelCuerpoHumano))
				{
					expuestasResultado.Add(parteDelCuerpoHumano);
				}
			}
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00018688 File Offset: 0x00016888
		public static bool Cubriendo(this IRopaManager manager, RopaCubre parte)
		{
			return manager != null && ((int)manager.cubriendoFlags).HasFlag((int)parte);
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x000186A8 File Offset: 0x000168A8
		public static bool Cubriendo(this IRopaManager manager, ParteDelCuerpoHumano parte)
		{
			if (manager == null)
			{
				return false;
			}
			int cubriendoFlags = (int)manager.cubriendoFlags;
			int num = (int)parte.Parce();
			return cubriendoFlags.HasFlag(num);
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x000186CD File Offset: 0x000168CD
		public static bool TryParce(this ParteDelCuerpoHumano parte, out RopaCubre cubre)
		{
			cubre = IRopaManagerEXT.parce(parte);
			return cubre != RopaCubre.None;
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x000186DE File Offset: 0x000168DE
		public static RopaCubre Parce(this ParteDelCuerpoHumano parte)
		{
			RopaCubre ropaCubre = IRopaManagerEXT.parce(parte);
			if (ropaCubre == RopaCubre.None)
			{
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
			return ropaCubre;
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x000186FC File Offset: 0x000168FC
		private static RopaCubre parce(ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
				return RopaCubre.torzo;
			case ParteDelCuerpoHumano.espalda:
				return RopaCubre.espalda;
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.caderas:
				return RopaCubre.belly;
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.orejas:
				return RopaCubre.cabeza;
			case ParteDelCuerpoHumano.cuello:
				return RopaCubre.cuello;
			case ParteDelCuerpoHumano.mandibula:
				return RopaCubre.labios;
			case ParteDelCuerpoHumano.labios:
				return RopaCubre.labios;
			case ParteDelCuerpoHumano.bocaInterno:
				return RopaCubre.bocaHole;
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.frente:
				return RopaCubre.rostro;
			case ParteDelCuerpoHumano.ojos:
				return RopaCubre.ojos;
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
				return RopaCubre.ojos;
			case ParteDelCuerpoHumano.hombros:
				return RopaCubre.hombros;
			case ParteDelCuerpoHumano.axilas:
				return RopaCubre.hombros;
			case ParteDelCuerpoHumano.brazos:
				return RopaCubre.brazos;
			case ParteDelCuerpoHumano.anteBrazos:
				return RopaCubre.anteBrazos;
			case ParteDelCuerpoHumano.manos:
				return RopaCubre.manos;
			case ParteDelCuerpoHumano.senos:
				return RopaCubre.pectorales;
			case ParteDelCuerpoHumano.pezones:
				return RopaCubre.pezones;
			case ParteDelCuerpoHumano.coxis:
				return RopaCubre.nalgas;
			case ParteDelCuerpoHumano.vientre:
				return RopaCubre.belly;
			case ParteDelCuerpoHumano.nalgas:
				return RopaCubre.nalgas;
			case ParteDelCuerpoHumano.vientreBajo:
				return RopaCubre.vientreBajo;
			case ParteDelCuerpoHumano.labiosVaginales:
				return RopaCubre.labiosVaginales;
			case ParteDelCuerpoHumano.clitoris:
				return RopaCubre.labiosVaginales;
			case ParteDelCuerpoHumano.perineo:
				return RopaCubre.ano;
			case ParteDelCuerpoHumano.ano:
				return RopaCubre.ano;
			case ParteDelCuerpoHumano.vag:
				return RopaCubre.vaginaHole;
			case ParteDelCuerpoHumano.piernas:
				return RopaCubre.piernas;
			case ParteDelCuerpoHumano.rodillas:
				return RopaCubre.canillas;
			case ParteDelCuerpoHumano.canillas:
				return RopaCubre.canillas;
			case ParteDelCuerpoHumano.pies:
				return RopaCubre.pies;
			case ParteDelCuerpoHumano.lengua:
				return RopaCubre.bocaHole;
			case ParteDelCuerpoHumano.pene:
				return RopaCubre.pene;
			case ParteDelCuerpoHumano.testiculos:
				return RopaCubre.testiculos;
			}
			throw new ArgumentOutOfRangeException(parte.ToString());
		}

		// Token: 0x04000361 RID: 865
		private static List<ParteDelCuerpoHumano> m_Temp = new List<ParteDelCuerpoHumano>();

		// Token: 0x04000362 RID: 866
		private static HashSet<int> m_TempSet = new HashSet<int>();
	}
}
