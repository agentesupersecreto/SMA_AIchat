using System;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers
{
	// Token: 0x0200000D RID: 13
	[Flags]
	public enum TipoDePose
	{
		// Token: 0x04000028 RID: 40
		None = 0,
		// Token: 0x04000029 RID: 41
		dePieRigida = 1,
		// Token: 0x0400002A RID: 42
		[Obsolete("ver si se esta usando", true)]
		dePieSuave = 2,
		// Token: 0x0400002B RID: 43
		[Obsolete("ver si se esta usando", true)]
		dePieSuaveManosRigidas = 4,
		// Token: 0x0400002C RID: 44
		[Obsolete("ver si se esta usando", true)]
		sentadaRigida = 8,
		// Token: 0x0400002D RID: 45
		[Obsolete("ver si se esta usando", true)]
		sentadaSuave = 16,
		// Token: 0x0400002E RID: 46
		[Obsolete("ver si se esta usando", true)]
		sentadaSuaveManosRigidas = 32,
		// Token: 0x0400002F RID: 47
		doggy_ApoyoManosRodillas = 64,
		// Token: 0x04000030 RID: 48
		misioneroMesaPiernasArriba_ApoyoEnCodosManos = 128,
		// Token: 0x04000031 RID: 49
		misioneroMesaPiernasArriba_ApoyoManos = 256,
		// Token: 0x04000032 RID: 50
		sentadaMesaPiernasAbiertas_ApoyoManosPelvis = 512,
		// Token: 0x04000033 RID: 51
		sentadaMesaPiernasAbiertasInver_ApoyoManosPelvis = 1024,
		// Token: 0x04000034 RID: 52
		doggyTable_ApoyoManos_SemiApoyoPiernas = 2048,
		// Token: 0x04000035 RID: 53
		doggyLayTable_ApoyoManos_SemiApoyoPiernas = 4096,
		// Token: 0x04000036 RID: 54
		sideTableFront_ApoyoManosRodilla = 8192,
		// Token: 0x04000037 RID: 55
		sideTableBack_ApoyoManosRodilla = 16384,
		// Token: 0x04000038 RID: 56
		dePieWallFrontPiernasAbiertas_ApoyoManosPies = 32768,
		// Token: 0x04000039 RID: 57
		dePieWallFront_ApoyoManosPies = 65536,
		// Token: 0x0400003A RID: 58
		dePieWallBack_ApoyoManosPies = 131072,
		// Token: 0x0400003B RID: 59
		dePieWallBackDoblada_ApoyoManosPies = 262144,
		// Token: 0x0400003C RID: 60
		dePieForwardBend_ApoyoManosPies = 524288,
		// Token: 0x0400003D RID: 61
		layGround_ApoyoManosCodosPiesRodillas = 1048576,
		// Token: 0x0400003E RID: 62
		kneelOral_ApoyoRodillasPies = 2097152,
		// Token: 0x0400003F RID: 63
		sitGroundOral_ApoyoRodillasHips = 4194304,
		// Token: 0x04000040 RID: 64
		Anim_Sentada_ApoyoPelvis = 8388608,
		// Token: 0x04000041 RID: 65
		Anim_Sentada_ApoyoPelvisManos = 16777216,
		// Token: 0x04000042 RID: 66
		Anim_Acostada_ApoyoPelvisHombros = 33554432,
		// Token: 0x04000043 RID: 67
		Anim_AcostadaBocaAbajo_ApoyoPelvisCodosManos = 67108864,
		// Token: 0x04000044 RID: 68
		Anim_Doggy_ApoyoRodillasCodos = 134217728,
		// Token: 0x04000045 RID: 69
		Anim_Gine = 268435456,
		// Token: 0x04000046 RID: 70
		custom = -2147483648
	}
}
