using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync
{
	// Token: 0x0200026B RID: 619
	[Serializable]
	public struct Silaba : IEnumerable<Casilla>, IEnumerable
	{
		// Token: 0x06000DC5 RID: 3525 RVA: 0x00040668 File Offset: 0x0003E868
		public Silaba(Casilla casilla)
		{
			this.duracionMod = (float)Mathf.Clamp(casilla.largo, 1, 10);
			this.primera = casilla;
			this.segunda = default(Casilla);
			TipoDeCasilla tipoDeCasilla = this.primera.tipo;
			if (tipoDeCasilla != TipoDeCasilla.simple)
			{
				if (tipoDeCasilla != TipoDeCasilla.consonanteCompuesta)
				{
					throw new ArgumentOutOfRangeException(this.primera.tipo.ToString());
				}
				this.tipo = TipoDeSilaba.consonanteCompuesta;
				return;
			}
			else
			{
				switch (this.primera.primer.tipo)
				{
				case TipoDeCharacter.espacio:
					this.tipo = TipoDeSilaba.espacio;
					return;
				case TipoDeCharacter.coma:
				case TipoDeCharacter.punto:
				case TipoDeCharacter.dosPuntos:
				case TipoDeCharacter.puntoYComa:
				case TipoDeCharacter.simbolo:
					this.tipo = TipoDeSilaba.simbolo;
					return;
				case TipoDeCharacter.consonante:
					this.tipo = TipoDeSilaba.unaConsonante;
					return;
				case TipoDeCharacter.vocal:
					this.tipo = TipoDeSilaba.unaVocal;
					return;
				default:
					throw new ArgumentOutOfRangeException(this.primera.primer.tipo.ToString());
				}
			}
		}

		// Token: 0x06000DC6 RID: 3526 RVA: 0x00040754 File Offset: 0x0003E954
		public Silaba(Casilla a, Casilla b)
		{
			this.duracionMod = 1f;
			this.primera = a;
			this.segunda = b;
			bool flag = a.tipo == TipoDeCasilla.simple;
			bool flag2 = b.tipo == TipoDeCasilla.simple;
			if (!flag)
			{
				foreach (CasillaDeCharacters casillaDeCharacters in a)
				{
					if (casillaDeCharacters.tipo != TipoDeCharacter.consonante)
					{
						throw new NotSupportedException("vocal o simbolo compuesta aun no es soportado: " + casillaDeCharacters.@char.ToString());
					}
				}
			}
			if (!flag2)
			{
				foreach (CasillaDeCharacters casillaDeCharacters2 in b)
				{
					if (casillaDeCharacters2.tipo != TipoDeCharacter.consonante)
					{
						throw new NotSupportedException("vocal o simbolo compuesta aun no es soportado: " + casillaDeCharacters2.@char.ToString());
					}
				}
			}
			bool flag3 = flag && a.primer.tipo == TipoDeCharacter.vocal;
			bool flag4 = flag && a.primer.tipo == TipoDeCharacter.consonante;
			bool flag5 = !flag && a.primer.tipo == TipoDeCharacter.consonante;
			bool flag6 = flag2 && b.primer.tipo == TipoDeCharacter.vocal;
			bool flag7 = flag2 && b.primer.tipo == TipoDeCharacter.consonante;
			bool flag8;
			if (flag7)
			{
				char? upper = b.primer.upper;
				int? num = ((upper != null) ? new int?((int)upper.GetValueOrDefault()) : null);
				int num2 = 89;
				flag8 = (num.GetValueOrDefault() == num2) & (num != null);
			}
			else
			{
				flag8 = false;
			}
			bool flag9 = flag8;
			bool flag10 = !flag2 && b.primer.tipo == TipoDeCharacter.consonante;
			flag6 = flag6 || flag9;
			flag7 = !flag9 && flag7;
			if (flag3 && flag6)
			{
				throw new NotSupportedException();
			}
			if (flag4)
			{
				if (flag7)
				{
					throw new NotSupportedException(a.primer.@char.ToString() + " y " + b.primer.@char.ToString() + " debieron haber sido consonante compuesta.");
				}
				if (flag10)
				{
					throw new NotSupportedException(a.primer.@char.ToString() + " y " + string.Join(string.Empty, b.Select((CasillaDeCharacters i) => i.@char.ToString())) + " debieron haber sido consonante compuesta.");
				}
			}
			if (flag7)
			{
				if (flag4)
				{
					throw new NotSupportedException(a.primer.@char.ToString() + " y " + b.primer.@char.ToString() + " debieron haber sido consonante compuesta.");
				}
				if (flag5)
				{
					throw new NotSupportedException(string.Join(string.Empty, a.Select((CasillaDeCharacters i) => i.@char.ToString())) + " y " + b.primer.@char.ToString() + " debieron haber sido consonante compuesta.");
				}
			}
			if (flag5 && flag10)
			{
				throw new NotSupportedException(string.Join(string.Empty, a.Select((CasillaDeCharacters i) => i.@char.ToString())) + " y " + string.Join(string.Empty, b.Select((CasillaDeCharacters i) => i.@char.ToString())) + " son doble consonante compuesta y no es soportado.");
			}
			if (flag3)
			{
				this.duracionMod = Mathf.Clamp((float)a.largo * 0.6f + (float)b.largo * 0.4f, 1f, 10f);
				if (flag7)
				{
					this.tipo = TipoDeSilaba.unaVocalConUnaConsonante;
					return;
				}
				if (flag10)
				{
					this.tipo = TipoDeSilaba.unaVocalConConsonanteCompuesta;
					return;
				}
				throw new ArgumentOutOfRangeException();
			}
			else
			{
				if (!flag6)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.duracionMod = Mathf.Clamp((float)a.largo * 0.4f + (float)b.largo * 0.6f, 1f, 10f);
				if (flag4)
				{
					this.tipo = TipoDeSilaba.unaConsonanteConUnaVocal;
					return;
				}
				if (flag5)
				{
					this.tipo = TipoDeSilaba.consonanteCompuestaConUnaVocal;
					return;
				}
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x06000DC7 RID: 3527 RVA: 0x00040BB0 File Offset: 0x0003EDB0
		public IEnumerator<Casilla> GetEnumerator()
		{
			TipoDeSilaba tipoDeSilaba = this.tipo;
			if (tipoDeSilaba > TipoDeSilaba.consonanteCompuesta)
			{
				if (tipoDeSilaba - TipoDeSilaba.unaConsonanteConUnaVocal > 3)
				{
					throw new ArgumentOutOfRangeException(this.tipo.ToString());
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

		// Token: 0x06000DC8 RID: 3528 RVA: 0x00005A42 File Offset: 0x00003C42
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000BD1 RID: 3025
		public TipoDeSilaba tipo;

		// Token: 0x04000BD2 RID: 3026
		public float duracionMod;

		// Token: 0x04000BD3 RID: 3027
		public Casilla primera;

		// Token: 0x04000BD4 RID: 3028
		public Casilla segunda;
	}
}
