using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x0200003A RID: 58
	public interface IPeneConPartes : IPene, IPertenecibleDeCharacter, IComponentStartable, IPeneSimple
	{
		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000125 RID: 293
		[Obsolete("Las partes tienen anchos diferentes", true)]
		float worldPartLength { get; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000126 RID: 294
		float worldTipPartLength { get; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000127 RID: 295
		float worldTipPartWidth { get; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000128 RID: 296
		IEnumerable<PenisPart> enumerator { get; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000129 RID: 297
		IReadOnlyList<PenisPart> partesEnOrden { get; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600012A RID: 298
		PenisPart puntaParte { get; }

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x0600012B RID: 299
		// (remove) Token: 0x0600012C RID: 300
		event IPenePenetratingHandler entered;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x0600012D RID: 301
		// (remove) Token: 0x0600012E RID: 302
		event IPenePenetratingHandler stayed;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x0600012F RID: 303
		// (remove) Token: 0x06000130 RID: 304
		event IPenePenetratingHandler exited;
	}
}
