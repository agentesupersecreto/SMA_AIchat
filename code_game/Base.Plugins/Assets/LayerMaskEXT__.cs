using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000167 RID: 359
	public static class LayerMaskEXT__
	{
		// Token: 0x06000A94 RID: 2708 RVA: 0x00023B6C File Offset: 0x00021D6C
		public static bool Contains(this LayerMask mask, int layer)
		{
			return mask.value == (mask.value | (1 << layer));
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x00023B85 File Offset: 0x00021D85
		public static bool Contains(this LayerMask mask, LayerMask other)
		{
			return mask.value == (mask.value | (1 << other.value));
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x00023BA4 File Offset: 0x00021DA4
		public static bool ContainsLayer(this int mask, int layer)
		{
			return mask == (mask | (1 << layer));
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x00023BB4 File Offset: 0x00021DB4
		public static LayerMask GetPhysicsLayerMask(this int currentLayer)
		{
			int num = 0;
			for (int i = 0; i < 32; i++)
			{
				if (!Physics.GetIgnoreLayerCollision(currentLayer, i))
				{
					num |= 1 << i;
				}
			}
			return num;
		}
	}
}
