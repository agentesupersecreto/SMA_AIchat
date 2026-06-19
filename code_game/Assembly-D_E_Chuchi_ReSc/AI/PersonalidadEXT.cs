using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000361 RID: 865
	public static class PersonalidadEXT
	{
		// Token: 0x060012EE RID: 4846 RVA: 0x00052080 File Offset: 0x00050280
		public static Personalidad.TipoDeRespuestaDeDialogoDeHeroina Parse(this Personalidad.Tipo tipo)
		{
			if (tipo <= Personalidad.Tipo.pervertido)
			{
				switch (tipo)
				{
				case Personalidad.Tipo.None:
					return Personalidad.TipoDeRespuestaDeDialogoDeHeroina.None;
				case Personalidad.Tipo.neutral:
				case Personalidad.Tipo.neutral | Personalidad.Tipo.timido:
					goto IL_003F;
				case Personalidad.Tipo.timido:
					return Personalidad.TipoDeRespuestaDeDialogoDeHeroina.timida;
				case Personalidad.Tipo.extrovertido:
					break;
				default:
					if (tipo != Personalidad.Tipo.pervertido)
					{
						goto IL_003F;
					}
					return Personalidad.TipoDeRespuestaDeDialogoDeHeroina.pervertida;
				}
			}
			else if (tipo != Personalidad.Tipo.respetuoso)
			{
				if (tipo != Personalidad.Tipo.grosero)
				{
					goto IL_003F;
				}
				return Personalidad.TipoDeRespuestaDeDialogoDeHeroina.grosera;
			}
			return Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable;
			IL_003F:
			throw new ArgumentOutOfRangeException(tipo.ToString());
		}
	}
}
