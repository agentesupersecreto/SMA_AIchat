using System;

namespace Assets
{
	// Token: 0x02000158 RID: 344
	public static class TipoDeSemenEXT
	{
		// Token: 0x060009F1 RID: 2545 RVA: 0x00020544 File Offset: 0x0001E744
		public static SemenParticulaQuePuedeEstimular GetEstimulanteSemenParticle(this TipoDeSemen tipo)
		{
			switch (tipo)
			{
			case TipoDeSemen.semen:
				return SemenParticulaQuePuedeEstimular.semen;
			case TipoDeSemen.water:
				return SemenParticulaQuePuedeEstimular.water;
			case TipoDeSemen.lubricante:
				return SemenParticulaQuePuedeEstimular.lubricante;
			case TipoDeSemen.orine:
				return SemenParticulaQuePuedeEstimular.orine;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x00020593 File Offset: 0x0001E793
		public static float CapacidadDeHoleModSegunTipoDeSemen(this TipoDeSemen tipo, ParteDelCuerpoHumano parte)
		{
			if (!parte.EsHole())
			{
				throw new InvalidOperationException();
			}
			return tipo.CapacidadDeHoleModSegunTipoDeSemen((ParteDelCuerpoHumanoHole)parte);
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x000205AC File Offset: 0x0001E7AC
		public static float CapacidadDeHoleModSegunTipoDeSemen(this TipoDeSemen tipo, ParteDelCuerpoHumanoHole hole)
		{
			if (hole == ParteDelCuerpoHumanoHole.bocaInterno)
			{
				return 1f;
			}
			if (hole != ParteDelCuerpoHumanoHole.ano)
			{
				if (hole != ParteDelCuerpoHumanoHole.vag)
				{
					throw new ArgumentOutOfRangeException(hole.ToString());
				}
				return 1f;
			}
			else
			{
				switch (tipo)
				{
				case TipoDeSemen.semen:
					return 1f;
				case TipoDeSemen.water:
					return 20f;
				case TipoDeSemen.lubricante:
					return 1f;
				case TipoDeSemen.orine:
					return 20f;
				default:
					throw new ArgumentOutOfRangeException(tipo.ToString());
				}
			}
		}
	}
}
