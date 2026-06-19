using System;
using System.Collections.Generic;
using TValleCustomClases;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200012A RID: 298
	[Serializable]
	public sealed class ColliderKeyVector3ValueDictionary : SerializableDictionary<Collider, Vector3>
	{
		// Token: 0x06000845 RID: 2117 RVA: 0x0001BB93 File Offset: 0x00019D93
		public ColliderKeyVector3ValueDictionary()
		{
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x0001BB9B File Offset: 0x00019D9B
		public ColliderKeyVector3ValueDictionary(IEqualityComparer<Collider> comparer)
			: base(comparer)
		{
		}
	}
}
