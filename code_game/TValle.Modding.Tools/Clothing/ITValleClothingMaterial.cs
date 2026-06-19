using System;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Clothing
{
	// Token: 0x0200003D RID: 61
	public interface ITValleClothingMaterial
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000153 RID: 339
		string ID { get; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000154 RID: 340
		int slotIndex { get; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000155 RID: 341
		Color color { get; }
	}
}
