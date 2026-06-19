using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000E4 RID: 228
	public interface IInteractionOrden : IOrdenDeController
	{
		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000855 RID: 2133
		// (set) Token: 0x06000856 RID: 2134
		bool flagToStop { get; set; }

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000857 RID: 2135
		float timerWeigth { get; }

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000858 RID: 2136
		// (set) Token: 0x06000859 RID: 2137
		bool fijaPorAnimacion { get; set; }

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x0600085A RID: 2138
		// (set) Token: 0x0600085B RID: 2139
		bool puedeTrasladarse { get; set; }

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x0600085C RID: 2140
		// (set) Token: 0x0600085D RID: 2141
		bool puedeApoyarse { get; set; }

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x0600085E RID: 2142
		// (set) Token: 0x0600085F RID: 2143
		bool puedeApoyarseExt { get; set; }
	}
}
