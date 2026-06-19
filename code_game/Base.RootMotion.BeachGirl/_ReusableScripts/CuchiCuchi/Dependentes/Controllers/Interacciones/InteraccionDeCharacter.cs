using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000E7 RID: 231
	[Serializable]
	public abstract class InteraccionDeCharacter
	{
		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x0600086A RID: 2154
		// (set) Token: 0x0600086B RID: 2155
		public abstract int id { get; set; }

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x0600086C RID: 2156
		// (set) Token: 0x0600086D RID: 2157
		public abstract int layer { get; set; }

		// Token: 0x0400057E RID: 1406
		public Interaccion instancia;

		// Token: 0x0400057F RID: 1407
		public bool setInitial;
	}
}
