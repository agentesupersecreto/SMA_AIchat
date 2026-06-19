using System;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x02000030 RID: 48
	public interface IPeneParte
	{
		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060000E2 RID: 226
		float worldDistanceToHole { get; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060000E3 RID: 227
		float worldTipPenetrationDistance { get; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060000E4 RID: 228
		float worldBasePenetrationDistance { get; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060000E5 RID: 229
		float worldDeepDistance { get; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060000E6 RID: 230
		float deepMod { get; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060000E7 RID: 231
		float maxRadius { get; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060000E8 RID: 232
		float maxWorldRadius { get; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060000E9 RID: 233
		float maxWorldHeight { get; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060000EA RID: 234
		float maxWorldThickness { get; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060000EB RID: 235
		IPeneParteCollider mainCollider { get; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060000EC RID: 236
		IPeneParteCollider complementoCollider { get; }
	}
}
