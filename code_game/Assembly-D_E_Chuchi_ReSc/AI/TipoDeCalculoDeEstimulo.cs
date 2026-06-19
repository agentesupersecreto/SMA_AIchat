using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002FD RID: 765
	[Flags]
	public enum TipoDeCalculoDeEstimulo
	{
		// Token: 0x04000D87 RID: 3463
		None = 0,
		// Token: 0x04000D88 RID: 3464
		frame = 1,
		// Token: 0x04000D89 RID: 3465
		sesionComienza = 2,
		// Token: 0x04000D8A RID: 3466
		sesionEnCurso = 4,
		// Token: 0x04000D8B RID: 3467
		sesionTermina = 8
	}
}
