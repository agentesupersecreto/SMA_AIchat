using System;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos
{
	// Token: 0x02000010 RID: 16
	[Flags]
	public enum TipoDeEstimuloFlags
	{
		// Token: 0x04000030 RID: 48
		None = 0,
		// Token: 0x04000031 RID: 49
		tactil = 1,
		// Token: 0x04000032 RID: 50
		auditiva = 2,
		// Token: 0x04000033 RID: 51
		visual = 4,
		// Token: 0x04000034 RID: 52
		olfativa = 8,
		// Token: 0x04000035 RID: 53
		gustativa = 16,
		// Token: 0x04000036 RID: 54
		energetica = 32,
		// Token: 0x04000037 RID: 55
		agarrante = 64,
		// Token: 0x04000038 RID: 56
		coital = 128,
		// Token: 0x04000039 RID: 57
		desvestidura = 256,
		// Token: 0x0400003A RID: 58
		empujante = 512,
		// Token: 0x0400003B RID: 59
		peticionDesvestidura = 1024,
		// Token: 0x0400003C RID: 60
		ejecucionDePose = 2048,
		// Token: 0x0400003D RID: 61
		peticionEjecucionDePose = 4096,
		// Token: 0x0400003E RID: 62
		manipulacionDeBone = 8192,
		// Token: 0x0400003F RID: 63
		peticionMovimientoDeBone = 16384
	}
}
