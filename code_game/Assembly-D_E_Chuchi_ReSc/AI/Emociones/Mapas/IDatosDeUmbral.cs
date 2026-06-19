using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas
{
	// Token: 0x02000434 RID: 1076
	public interface IDatosDeUmbral
	{
		// Token: 0x17000633 RID: 1587
		// (get) Token: 0x06001806 RID: 6150
		// (set) Token: 0x06001807 RID: 6151
		RangeValueV2 intervaloDeGeneracion { get; set; }

		// Token: 0x17000634 RID: 1588
		// (get) Token: 0x06001808 RID: 6152
		// (set) Token: 0x06001809 RID: 6153
		ValorModificable estimulacionQueGenera { get; set; }

		// Token: 0x17000635 RID: 1589
		// (get) Token: 0x0600180A RID: 6154
		// (set) Token: 0x0600180B RID: 6155
		SpotBonuses spotBonuses { get; set; }

		// Token: 0x17000636 RID: 1590
		// (get) Token: 0x0600180C RID: 6156
		// (set) Token: 0x0600180D RID: 6157
		float promedioMod { get; set; }

		// Token: 0x17000637 RID: 1591
		// (get) Token: 0x0600180E RID: 6158
		// (set) Token: 0x0600180F RID: 6159
		float modPorEncima { get; set; }

		// Token: 0x17000638 RID: 1592
		// (get) Token: 0x06001810 RID: 6160
		// (set) Token: 0x06001811 RID: 6161
		float modPorDebajo { get; set; }
	}
}
