using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync
{
	// Token: 0x02000276 RID: 630
	public class DecoDeCharacters : IDecoDeCharacters
	{
		// Token: 0x06000DF3 RID: 3571 RVA: 0x000417B0 File Offset: 0x0003F9B0
		public TipoDeCharacter Decodificar(char @char)
		{
			switch (Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id)
			{
			case Localizacion.US:
				return this.US(@char);
			case Localizacion.ES:
				return this.ES(@char);
			}
			throw new ArgumentOutOfRangeException(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id.ToString());
		}

		// Token: 0x06000DF4 RID: 3572 RVA: 0x00041810 File Offset: 0x0003FA10
		private TipoDeCharacter ES(char @char)
		{
			if (char.IsWhiteSpace(@char))
			{
				return TipoDeCharacter.espacio;
			}
			if (@char == ',')
			{
				return TipoDeCharacter.coma;
			}
			if (@char == '.')
			{
				return TipoDeCharacter.punto;
			}
			if (@char == ';')
			{
				return TipoDeCharacter.puntoYComa;
			}
			if (@char == ':')
			{
				return TipoDeCharacter.dosPuntos;
			}
			if (char.IsLetter(@char))
			{
				char c = char.ToUpperInvariant(@char);
				if (c <= 'E')
				{
					if (c != 'A' && c != 'E')
					{
						return TipoDeCharacter.consonante;
					}
				}
				else if (c != 'I' && c != 'O' && c != 'U')
				{
					return TipoDeCharacter.consonante;
				}
				return TipoDeCharacter.vocal;
			}
			return TipoDeCharacter.simbolo;
		}

		// Token: 0x06000DF5 RID: 3573 RVA: 0x00041877 File Offset: 0x0003FA77
		private TipoDeCharacter US(char @char)
		{
			return this.ES(@char);
		}
	}
}
