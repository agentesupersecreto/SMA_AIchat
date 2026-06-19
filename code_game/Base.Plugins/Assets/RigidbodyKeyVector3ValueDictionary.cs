using System;
using System.Collections.Generic;
using TValleCustomClases;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000129 RID: 297
	[Serializable]
	public sealed class RigidbodyKeyVector3ValueDictionary : SerializableDictionary<Rigidbody, Vector3>
	{
		// Token: 0x06000843 RID: 2115 RVA: 0x0001BB82 File Offset: 0x00019D82
		public RigidbodyKeyVector3ValueDictionary()
		{
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x0001BB8A File Offset: 0x00019D8A
		public RigidbodyKeyVector3ValueDictionary(IEqualityComparer<Rigidbody> comparer)
			: base(comparer)
		{
		}
	}
}
