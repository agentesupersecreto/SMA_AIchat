using System;
using System.Collections.Generic;
using TValleCustomClases;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200012B RID: 299
	[Serializable]
	public sealed class ColliderKeyColliderValueDictionary : SerializableDictionary<Collider, Collider>
	{
		// Token: 0x06000847 RID: 2119 RVA: 0x0001BBA4 File Offset: 0x00019DA4
		public ColliderKeyColliderValueDictionary()
		{
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x0001BBAC File Offset: 0x00019DAC
		public ColliderKeyColliderValueDictionary(IEqualityComparer<Collider> comparer)
			: base(comparer)
		{
		}
	}
}
