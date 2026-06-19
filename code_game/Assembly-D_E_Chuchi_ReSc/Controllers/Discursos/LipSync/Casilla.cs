using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync
{
	// Token: 0x0200026F RID: 623
	[Serializable]
	public struct Casilla : IEnumerable<CasillaDeCharacters>, IEnumerable
	{
		// Token: 0x06000DD5 RID: 3541 RVA: 0x00040CD4 File Offset: 0x0003EED4
		public Casilla(CasillaDeCharacters primer)
		{
			this.primer = primer;
			this.tipo = TipoDeCasilla.simple;
			this.segundo = default(CasillaDeCharacters);
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x00040CF0 File Offset: 0x0003EEF0
		public Casilla(CasillaDeCharacters primer, CasillaDeCharacters segundo)
		{
			this.primer = primer;
			this.tipo = TipoDeCasilla.consonanteCompuesta;
			this.segundo = segundo;
		}

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000DD7 RID: 3543 RVA: 0x00040D08 File Offset: 0x0003EF08
		public int largo
		{
			get
			{
				TipoDeCasilla tipoDeCasilla = this.tipo;
				if (tipoDeCasilla == TipoDeCasilla.simple)
				{
					return this.primer.largo;
				}
				if (tipoDeCasilla != TipoDeCasilla.consonanteCompuesta)
				{
					throw new ArgumentOutOfRangeException(this.tipo.ToString());
				}
				return Mathf.FloorToInt((float)(this.primer.largo + this.segundo.largo) / 2f);
			}
		}

		// Token: 0x06000DD8 RID: 3544 RVA: 0x00040D6B File Offset: 0x0003EF6B
		public IEnumerator<CasillaDeCharacters> GetEnumerator()
		{
			TipoDeCasilla tipoDeCasilla = this.tipo;
			if (tipoDeCasilla != TipoDeCasilla.simple)
			{
				if (tipoDeCasilla != TipoDeCasilla.consonanteCompuesta)
				{
					throw new ArgumentOutOfRangeException(this.tipo.ToString());
				}
				yield return this.primer;
				yield return this.segundo;
			}
			else
			{
				yield return this.primer;
			}
			yield break;
		}

		// Token: 0x06000DD9 RID: 3545 RVA: 0x00040D7F File Offset: 0x0003EF7F
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000DDA RID: 3546 RVA: 0x00040D88 File Offset: 0x0003EF88
		public override string ToString()
		{
			TipoDeCasilla tipoDeCasilla = this.tipo;
			if (tipoDeCasilla == TipoDeCasilla.simple)
			{
				return this.primer.ToString();
			}
			if (tipoDeCasilla != TipoDeCasilla.consonanteCompuesta)
			{
				throw new ArgumentOutOfRangeException(this.tipo.ToString());
			}
			return this.primer.ToString() + this.segundo.ToString();
		}

		// Token: 0x04000BE7 RID: 3047
		public CasillaDeCharacters primer;

		// Token: 0x04000BE8 RID: 3048
		public CasillaDeCharacters segundo;

		// Token: 0x04000BE9 RID: 3049
		public TipoDeCasilla tipo;
	}
}
