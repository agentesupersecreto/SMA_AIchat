using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002FC RID: 764
	[Flags]
	public enum TipoDeCalculadorDeEstimulo
	{
		// Token: 0x04000D7F RID: 3455
		None = 0,
		// Token: 0x04000D80 RID: 3456
		frame = 1,
		// Token: 0x04000D81 RID: 3457
		sesionEspecifica = 2,
		// Token: 0x04000D82 RID: 3458
		sesionEspecificaDe = 4,
		// Token: 0x04000D83 RID: 3459
		sesionGeneral = 8,
		// Token: 0x04000D84 RID: 3460
		sesionGeneralDe = 16,
		// Token: 0x04000D85 RID: 3461
		[Obsolete]
		sesionGeneralDeTipoDeCualquierEmocion = 32
	}
}
