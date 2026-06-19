using System;

namespace Assets
{
	// Token: 0x0200000C RID: 12
	public static class FemalePenetracionTipoEXT
	{
		// Token: 0x0600003D RID: 61 RVA: 0x000020C6 File Offset: 0x000002C6
		public static ParteDelCuerpoHumano ParseAParteDelCuerpoHumano(this FemalePenetracionTipo tipo)
		{
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				return ParteDelCuerpoHumano.ano;
			case FemalePenetracionTipo.vag:
				return ParteDelCuerpoHumano.vag;
			case FemalePenetracionTipo.facial:
				return ParteDelCuerpoHumano.bocaInterno;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}
	}
}
