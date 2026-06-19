using System;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x0200002E RID: 46
	public interface IPeneCresiente : IPene, IPertenecibleDeCharacter, IComponentStartable, IPeneSimple
	{
		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060000DC RID: 220
		// (set) Token: 0x060000DD RID: 221
		float largo { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060000DE RID: 222
		// (set) Token: 0x060000DF RID: 223
		float ancho { get; set; }
	}
}
