using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x020004F9 RID: 1273
	public interface IPhyscisIntervalosDeProfundidadAbove
	{
		// Token: 0x170007FB RID: 2043
		// (get) Token: 0x06001E29 RID: 7721
		RangeValueV2 vagUnLimited { get; }

		// Token: 0x170007FC RID: 2044
		// (get) Token: 0x06001E2A RID: 7722
		RangeValueV2 anusUnLimited { get; }

		// Token: 0x170007FD RID: 2045
		// (get) Token: 0x06001E2B RID: 7723
		RangeValueV2 facialUnLimited { get; }

		// Token: 0x170007FE RID: 2046
		// (get) Token: 0x06001E2C RID: 7724
		RangeValueV2 vag { get; }

		// Token: 0x170007FF RID: 2047
		// (get) Token: 0x06001E2D RID: 7725
		RangeValueV2 anus { get; }

		// Token: 0x17000800 RID: 2048
		// (get) Token: 0x06001E2E RID: 7726
		RangeValueV2 facial { get; }

		// Token: 0x17000801 RID: 2049
		// (get) Token: 0x06001E2F RID: 7727
		float vagWeight { get; }

		// Token: 0x17000802 RID: 2050
		// (get) Token: 0x06001E30 RID: 7728
		float anusWeight { get; }

		// Token: 0x17000803 RID: 2051
		// (get) Token: 0x06001E31 RID: 7729
		float facialWeight { get; }
	}
}
