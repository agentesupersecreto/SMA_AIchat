using System;

namespace Assets.TValle.BeachGirl.Runtime
{
	// Token: 0x0200004A RID: 74
	public static class TiposDeGestosDeBocaEXT
	{
		// Token: 0x0600014B RID: 331 RVA: 0x00002E2C File Offset: 0x0000102C
		public static bool EsDeseoOral(this TiposDeGestosDeBoca tipo)
		{
			switch (tipo)
			{
			case TiposDeGestosDeBoca.None:
			case TiposDeGestosDeBoca.sorprender:
			case TiposDeGestosDeBoca.aplanarApretando:
			case TiposDeGestosDeBoca.pico:
			case TiposDeGestosDeBoca.sorpresaConLengua:
			case TiposDeGestosDeBoca.sorpresaConLenguaExtrema:
			case TiposDeGestosDeBoca.suck:
			case TiposDeGestosDeBoca.morderLabio:
			case TiposDeGestosDeBoca.abrirLabios:
			case TiposDeGestosDeBoca.exclamar_A:
			case TiposDeGestosDeBoca.exclamar_O:
			case TiposDeGestosDeBoca.exclamar_A_Extrema:
			case TiposDeGestosDeBoca.exclamar_O_Extrema:
			case TiposDeGestosDeBoca.examinarBoca:
				return false;
			case TiposDeGestosDeBoca.deseoOralSmall:
			case TiposDeGestosDeBoca.deseoOralNormal:
			case TiposDeGestosDeBoca.deseoOralBig:
			case TiposDeGestosDeBoca.deseoOralMoster:
				return true;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00002EA0 File Offset: 0x000010A0
		public static bool AbreLaBoca(this TiposDeGestosDeBoca tipo)
		{
			switch (tipo)
			{
			case TiposDeGestosDeBoca.None:
			case TiposDeGestosDeBoca.aplanarApretando:
			case TiposDeGestosDeBoca.pico:
			case TiposDeGestosDeBoca.suck:
			case TiposDeGestosDeBoca.morderLabio:
				return false;
			case TiposDeGestosDeBoca.sorprender:
			case TiposDeGestosDeBoca.sorpresaConLengua:
			case TiposDeGestosDeBoca.sorpresaConLenguaExtrema:
			case TiposDeGestosDeBoca.deseoOralSmall:
			case TiposDeGestosDeBoca.deseoOralNormal:
			case TiposDeGestosDeBoca.deseoOralBig:
			case TiposDeGestosDeBoca.deseoOralMoster:
			case TiposDeGestosDeBoca.abrirLabios:
			case TiposDeGestosDeBoca.exclamar_A:
			case TiposDeGestosDeBoca.exclamar_O:
			case TiposDeGestosDeBoca.exclamar_A_Extrema:
			case TiposDeGestosDeBoca.exclamar_O_Extrema:
			case TiposDeGestosDeBoca.examinarBoca:
				return true;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00002F14 File Offset: 0x00001114
		public static bool AprietaLaBoca(this TiposDeGestosDeBoca tipo)
		{
			switch (tipo)
			{
			case TiposDeGestosDeBoca.None:
			case TiposDeGestosDeBoca.sorprender:
			case TiposDeGestosDeBoca.sorpresaConLengua:
			case TiposDeGestosDeBoca.sorpresaConLenguaExtrema:
			case TiposDeGestosDeBoca.deseoOralSmall:
			case TiposDeGestosDeBoca.deseoOralNormal:
			case TiposDeGestosDeBoca.deseoOralBig:
			case TiposDeGestosDeBoca.deseoOralMoster:
			case TiposDeGestosDeBoca.morderLabio:
			case TiposDeGestosDeBoca.abrirLabios:
			case TiposDeGestosDeBoca.exclamar_A:
			case TiposDeGestosDeBoca.exclamar_O:
			case TiposDeGestosDeBoca.exclamar_A_Extrema:
			case TiposDeGestosDeBoca.exclamar_O_Extrema:
			case TiposDeGestosDeBoca.examinarBoca:
				return false;
			case TiposDeGestosDeBoca.aplanarApretando:
			case TiposDeGestosDeBoca.pico:
			case TiposDeGestosDeBoca.suck:
				return true;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}
	}
}
