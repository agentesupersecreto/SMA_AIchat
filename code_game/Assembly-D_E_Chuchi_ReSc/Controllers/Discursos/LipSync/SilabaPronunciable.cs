using System;
using System.Collections;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Runtime;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync
{
	// Token: 0x02000267 RID: 615
	[Serializable]
	public struct SilabaPronunciable : IEnumerable<CasillaPronunciable>, IEnumerable
	{
		// Token: 0x06000DB9 RID: 3513 RVA: 0x00040234 File Offset: 0x0003E434
		public SilabaPronunciable(Silaba silaba, IDecoDeCasilla deco)
		{
			if (deco == null)
			{
				throw new ArgumentNullException("deco", "deco null reference.");
			}
			float num = 0f;
			if (deco.CasillaPrimariaEsMuda(ref silaba.primera))
			{
				num = (float)silaba.primera.largo;
				this.primera = default(CasillaPronunciable);
			}
			else
			{
				TipoDeCasillaPronunciable tipoDeCasillaPronunciable;
				Phoneme phoneme;
				deco.Decodificar(ref silaba, ref silaba.primera, 0, out tipoDeCasillaPronunciable, out phoneme);
				this.primera = new CasillaPronunciable(silaba.primera, tipoDeCasillaPronunciable, phoneme);
				this.primera.durationMod = this.primera.durationMod * silaba.duracionMod;
			}
			switch (silaba.tipo)
			{
			case TipoDeSilaba.simbolo:
			case TipoDeSilaba.espacio:
			case TipoDeSilaba.unaVocal:
			case TipoDeSilaba.unaConsonante:
			case TipoDeSilaba.consonanteCompuesta:
				this.segunda = default(CasillaPronunciable);
				break;
			case TipoDeSilaba.unaConsonanteConUnaVocal:
			case TipoDeSilaba.consonanteCompuestaConUnaVocal:
			{
				TipoDeCasillaPronunciable tipoDeCasillaPronunciable2;
				Phoneme phoneme2;
				deco.Decodificar(ref silaba, ref silaba.segunda, 1, out tipoDeCasillaPronunciable2, out phoneme2);
				this.segunda = new CasillaPronunciable(silaba.segunda, tipoDeCasillaPronunciable2, phoneme2);
				this.primera.durationMod = this.primera.durationMod * 0.5f;
				this.segunda.durationMod = silaba.duracionMod + num;
				break;
			}
			case TipoDeSilaba.unaVocalConUnaConsonante:
			case TipoDeSilaba.unaVocalConConsonanteCompuesta:
				if (deco.CasillaSegundariaEsMuda(ref silaba.segunda, ref silaba.primera))
				{
					this.segunda = default(CasillaPronunciable);
					this.primera.durationMod = this.primera.durationMod + (float)silaba.segunda.largo * 0.5f;
				}
				else
				{
					TipoDeCasillaPronunciable tipoDeCasillaPronunciable3;
					Phoneme phoneme3;
					deco.Decodificar(ref silaba, ref silaba.segunda, 1, out tipoDeCasillaPronunciable3, out phoneme3);
					this.segunda = new CasillaPronunciable(silaba.segunda, tipoDeCasillaPronunciable3, phoneme3);
					this.segunda.durationMod = 0.5f * silaba.duracionMod * (num * 0.5f);
				}
				break;
			default:
				throw new ArgumentOutOfRangeException(silaba.tipo.ToString());
			}
			this.silaba = silaba;
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000DBA RID: 3514 RVA: 0x0004040C File Offset: 0x0003E60C
		public float duration
		{
			get
			{
				TipoDeSilaba tipo = this.silaba.tipo;
				if (tipo <= TipoDeSilaba.consonanteCompuesta)
				{
					return this.primera.duration;
				}
				if (tipo - TipoDeSilaba.unaConsonanteConUnaVocal > 3)
				{
					throw new ArgumentOutOfRangeException(this.silaba.tipo.ToString());
				}
				return this.primera.duration + this.segunda.duration;
			}
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x00040470 File Offset: 0x0003E670
		public IEnumerator<CasillaPronunciable> GetEnumerator()
		{
			TipoDeSilaba tipo = this.silaba.tipo;
			if (tipo > TipoDeSilaba.consonanteCompuesta)
			{
				if (tipo - TipoDeSilaba.unaConsonanteConUnaVocal > 3)
				{
					throw new ArgumentOutOfRangeException(this.silaba.tipo.ToString());
				}
				yield return this.primera;
				yield return this.segunda;
			}
			else
			{
				yield return this.primera;
			}
			yield break;
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x00040484 File Offset: 0x0003E684
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x04000BC3 RID: 3011
		public Silaba silaba;

		// Token: 0x04000BC4 RID: 3012
		public CasillaPronunciable primera;

		// Token: 0x04000BC5 RID: 3013
		public CasillaPronunciable segunda;
	}
}
