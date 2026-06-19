using System;
using Assets.TValle.BeachGirl.Runtime;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync
{
	// Token: 0x02000269 RID: 617
	[Serializable]
	public struct CasillaPronunciable
	{
		// Token: 0x06000DC3 RID: 3523 RVA: 0x0004058A File Offset: 0x0003E78A
		public CasillaPronunciable(Casilla casilla, TipoDeCasillaPronunciable tipo, Phoneme phenome)
		{
			this.casilla = casilla;
			this.tipo = tipo;
			this.phenome = phenome;
			this.durationMod = 1f;
		}

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000DC4 RID: 3524 RVA: 0x000405AC File Offset: 0x0003E7AC
		public float duration
		{
			get
			{
				float num = 1f;
				if (this.casilla.tipo == TipoDeCasilla.simple)
				{
					switch (this.casilla.primer.tipo)
					{
					case TipoDeCharacter.espacio:
						num = 1.333f;
						break;
					case TipoDeCharacter.coma:
					case TipoDeCharacter.puntoYComa:
						num = 1.3f;
						break;
					case TipoDeCharacter.punto:
						num = 0.333f;
						break;
					case TipoDeCharacter.dosPuntos:
						num = 1.5f;
						break;
					case TipoDeCharacter.consonante:
					case TipoDeCharacter.vocal:
						break;
					case TipoDeCharacter.simbolo:
						num = 0.666f;
						break;
					default:
						throw new ArgumentOutOfRangeException(this.casilla.primer.tipo.ToString());
					}
				}
				return (float)this.casilla.largo * this.durationMod * num;
			}
		}

		// Token: 0x04000BC9 RID: 3017
		public float durationMod;

		// Token: 0x04000BCA RID: 3018
		public Casilla casilla;

		// Token: 0x04000BCB RID: 3019
		public TipoDeCasillaPronunciable tipo;

		// Token: 0x04000BCC RID: 3020
		public Phoneme phenome;
	}
}
