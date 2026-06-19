using System;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync
{
	// Token: 0x02000271 RID: 625
	[Serializable]
	public struct CasillaDeCharacters
	{
		// Token: 0x06000DE1 RID: 3553 RVA: 0x00040EE8 File Offset: 0x0003F0E8
		public CasillaDeCharacters(TipoDeCharacter tipo, char @char)
		{
			this.@char = @char;
			this.tipo = tipo;
			if (tipo - TipoDeCharacter.consonante <= 1)
			{
				this.upper = new char?(char.ToUpperInvariant(@char));
				this.lower = new char?(char.ToLowerInvariant(@char));
			}
			else
			{
				this.upper = null;
				this.lower = null;
			}
			this.largo = 1;
		}

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06000DE2 RID: 3554 RVA: 0x00040F4C File Offset: 0x0003F14C
		public bool esLetra
		{
			get
			{
				return this.upper != null;
			}
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x00040F59 File Offset: 0x0003F159
		public override string ToString()
		{
			return this.@char.ToString();
		}

		// Token: 0x04000BED RID: 3053
		[ReadOnlyUI]
		public TipoDeCharacter tipo;

		// Token: 0x04000BEE RID: 3054
		[ReadOnlyUI]
		public char @char;

		// Token: 0x04000BEF RID: 3055
		[ReadOnlyUI]
		public int largo;

		// Token: 0x04000BF0 RID: 3056
		[NonSerialized]
		public char? upper;

		// Token: 0x04000BF1 RID: 3057
		[NonSerialized]
		public char? lower;
	}
}
