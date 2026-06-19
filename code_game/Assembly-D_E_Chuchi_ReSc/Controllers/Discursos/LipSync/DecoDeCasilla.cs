using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync
{
	// Token: 0x02000277 RID: 631
	public class DecoDeCasilla : IDecoDeCasilla
	{
		// Token: 0x06000DF7 RID: 3575 RVA: 0x00041880 File Offset: 0x0003FA80
		public void Decodificar(ref Silaba owner, ref Casilla casilla, int casillaIndex, out TipoDeCasillaPronunciable tipo, out Phoneme phoneme)
		{
			tipo = TipoDeCasillaPronunciable.None;
			phoneme = Phoneme.None;
			TipoDeCasilla tipo2 = casilla.tipo;
			if (tipo2 != TipoDeCasilla.simple)
			{
				if (tipo2 != TipoDeCasilla.consonanteCompuesta)
				{
					throw new ArgumentOutOfRangeException(casilla.tipo.ToString());
				}
				phoneme = this.ObtenerPhonemeDeConsonante(casilla.primer.upper.Value, casilla.segundo.upper.Value);
				if (phoneme == Phoneme.None)
				{
					phoneme = this.ObtenerPhonemeDeConsonante(casilla.primer.upper.Value);
				}
				if (phoneme == Phoneme.None)
				{
					tipo = TipoDeCasillaPronunciable.None;
					return;
				}
				tipo = TipoDeCasillaPronunciable.Phoneme;
				return;
			}
			else
			{
				switch (casilla.primer.tipo)
				{
				case TipoDeCharacter.espacio:
				case TipoDeCharacter.punto:
				case TipoDeCharacter.dosPuntos:
				case TipoDeCharacter.simbolo:
					phoneme = Phoneme.None;
					tipo = TipoDeCasillaPronunciable.extencion;
					return;
				case TipoDeCharacter.coma:
				case TipoDeCharacter.puntoYComa:
					phoneme = Phoneme.None;
					tipo = TipoDeCasillaPronunciable.None;
					return;
				case TipoDeCharacter.consonante:
					phoneme = this.ObtenerPhonemeDeConsonante(casilla.primer.upper.Value);
					if (phoneme == Phoneme.None)
					{
						tipo = TipoDeCasillaPronunciable.None;
						return;
					}
					tipo = TipoDeCasillaPronunciable.Phoneme;
					return;
				case TipoDeCharacter.vocal:
					phoneme = this.ObtenerPhonemeDeVocal(casilla.primer.upper.Value);
					if (phoneme == Phoneme.None)
					{
						tipo = TipoDeCasillaPronunciable.None;
						return;
					}
					tipo = TipoDeCasillaPronunciable.Phoneme;
					return;
				default:
					throw new ArgumentOutOfRangeException(casilla.primer.tipo.ToString());
				}
			}
		}

		// Token: 0x06000DF8 RID: 3576 RVA: 0x000419CC File Offset: 0x0003FBCC
		public bool CasillaPrimariaEsMuda(ref Casilla casilla)
		{
			TipoDeCasilla tipo = casilla.tipo;
			if (tipo != TipoDeCasilla.simple)
			{
				if (tipo != TipoDeCasilla.consonanteCompuesta)
				{
				}
			}
			else
			{
				if (Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id == Localizacion.ES)
				{
					char? upper = casilla.primer.upper;
					int? num = ((upper != null) ? new int?((int)upper.GetValueOrDefault()) : null);
					int num2 = 72;
					if ((num.GetValueOrDefault() == num2) & (num != null))
					{
						return true;
					}
				}
				if (casilla.primer.@char == '\'')
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000DF9 RID: 3577 RVA: 0x00041A54 File Offset: 0x0003FC54
		public bool CasillaSegundariaEsMuda(ref Casilla segunda, ref Casilla primera)
		{
			TipoDeCasilla tipo = segunda.tipo;
			if (tipo != TipoDeCasilla.simple)
			{
				if (tipo != TipoDeCasilla.consonanteCompuesta)
				{
					throw new ArgumentOutOfRangeException(segunda.tipo.ToString());
				}
				return false;
			}
			else
			{
				char? c = segunda.primer.upper;
				int? num = ((c != null) ? new int?((int)c.GetValueOrDefault()) : null);
				int num2 = 72;
				if ((num.GetValueOrDefault() == num2) & (num != null))
				{
					return true;
				}
				TipoDeCasilla tipo2 = primera.tipo;
				if (tipo2 != TipoDeCasilla.simple)
				{
					if (tipo2 != TipoDeCasilla.consonanteCompuesta)
					{
						throw new ArgumentOutOfRangeException(primera.tipo.ToString());
					}
				}
				else
				{
					c = segunda.primer.upper;
					num = ((c != null) ? new int?((int)c.GetValueOrDefault()) : null);
					num2 = 75;
					if (((num.GetValueOrDefault() == num2) & (num != null)) && primera.primer.@char == 'C')
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x06000DFA RID: 3578 RVA: 0x00041B58 File Offset: 0x0003FD58
		private Phoneme ObtenerPhonemeDeVocal(char vocal)
		{
			switch (Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id)
			{
			case Localizacion.US:
				return this.ObtenerPhonemeDeVocalUS(vocal);
			case Localizacion.ES:
				return this.ObtenerPhonemeDeVocalES(vocal);
			}
			throw new ArgumentOutOfRangeException(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id.ToString());
		}

		// Token: 0x06000DFB RID: 3579 RVA: 0x00041BB8 File Offset: 0x0003FDB8
		private Phoneme ObtenerPhonemeDeConsonante(char primeraConsonante, char segundaConsonante)
		{
			switch (Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id)
			{
			case Localizacion.US:
				return this.ObtenerPhonemeDeConsonanteUS(primeraConsonante, segundaConsonante);
			case Localizacion.ES:
				return this.ObtenerPhonemeDeConsonanteES(primeraConsonante, segundaConsonante);
			}
			throw new ArgumentOutOfRangeException(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id.ToString());
		}

		// Token: 0x06000DFC RID: 3580 RVA: 0x00041C1C File Offset: 0x0003FE1C
		private Phoneme ObtenerPhonemeDeConsonante(char primeraConsonante)
		{
			switch (Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id)
			{
			case Localizacion.US:
				return this.ObtenerPhonemeDeConsonanteUS(primeraConsonante);
			case Localizacion.ES:
				return this.ObtenerPhonemeDeConsonanteES(primeraConsonante);
			}
			throw new ArgumentOutOfRangeException(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id.ToString());
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x00041C7C File Offset: 0x0003FE7C
		private Phoneme ObtenerPhonemeDeVocalUS(char vocal)
		{
			if (!char.IsLetter(vocal))
			{
				throw new NotSupportedException();
			}
			if (vocal == 'I' || vocal == 'Y')
			{
				return Phoneme.A1;
			}
			if (vocal == 'A')
			{
				return Phoneme.B1;
			}
			if (vocal == 'E')
			{
				return Phoneme.C1;
			}
			if (vocal == 'O')
			{
				return Phoneme.D1;
			}
			if (vocal == 'U')
			{
				return Phoneme.A3;
			}
			throw new NotSupportedException();
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x00041CBA File Offset: 0x0003FEBA
		private Phoneme ObtenerPhonemeDeVocalES(char vocal)
		{
			if (!char.IsLetter(vocal))
			{
				throw new NotSupportedException();
			}
			if (vocal == 'A')
			{
				return Phoneme.A1;
			}
			if (vocal == 'E')
			{
				return Phoneme.B1;
			}
			if (vocal == 'I' || vocal == 'Y')
			{
				return Phoneme.C1;
			}
			if (vocal == 'O')
			{
				return Phoneme.D1;
			}
			if (vocal == 'U')
			{
				return Phoneme.A3;
			}
			throw new NotSupportedException();
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x00041CF8 File Offset: 0x0003FEF8
		private Phoneme ObtenerPhonemeDeConsonanteUS(char primeraConsonante)
		{
			if (!char.IsLetter(primeraConsonante))
			{
				throw new NotSupportedException();
			}
			if (primeraConsonante == 'F' || primeraConsonante == 'V')
			{
				return Phoneme.B2;
			}
			if (primeraConsonante == 'L' || primeraConsonante == 'D')
			{
				return Phoneme.C2;
			}
			if (primeraConsonante == 'M' || primeraConsonante == 'B' || primeraConsonante == 'P')
			{
				return Phoneme.D2;
			}
			if (primeraConsonante == 'W' || primeraConsonante == 'Q')
			{
				return Phoneme.A3;
			}
			if (primeraConsonante == 'H')
			{
				return Phoneme.B3;
			}
			return Phoneme.A2;
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x00041D51 File Offset: 0x0003FF51
		private Phoneme ObtenerPhonemeDeConsonanteES(char primeraConsonante)
		{
			if (primeraConsonante == 'F' || primeraConsonante == 'V')
			{
				return Phoneme.B2;
			}
			if (primeraConsonante == 'L' || primeraConsonante == 'D')
			{
				return Phoneme.C2;
			}
			if (primeraConsonante == 'M' || primeraConsonante == 'B' || primeraConsonante == 'P')
			{
				return Phoneme.D2;
			}
			if (primeraConsonante == 'W')
			{
				return Phoneme.A3;
			}
			if (primeraConsonante == 'H')
			{
				return Phoneme.B3;
			}
			return Phoneme.A2;
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x00041D8C File Offset: 0x0003FF8C
		private Phoneme ObtenerPhonemeDeConsonanteUS(char primeraConsonante, char segundaConsonante)
		{
			if (primeraConsonante == 'P' && segundaConsonante == 'H')
			{
				return Phoneme.B2;
			}
			if (primeraConsonante == 'T' && segundaConsonante == 'H')
			{
				return Phoneme.C2;
			}
			if (primeraConsonante == 'S' && segundaConsonante == 'H')
			{
				return Phoneme.A2;
			}
			if (primeraConsonante == 'C' && segundaConsonante == 'H')
			{
				return Phoneme.A2;
			}
			return Phoneme.None;
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x00041DBF File Offset: 0x0003FFBF
		private Phoneme ObtenerPhonemeDeConsonanteES(char primeraConsonante, char segundaConsonante)
		{
			return this.ObtenerPhonemeDeConsonanteUS(primeraConsonante, segundaConsonante);
		}
	}
}
