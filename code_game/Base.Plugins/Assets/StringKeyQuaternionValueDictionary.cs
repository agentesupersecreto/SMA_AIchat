using System;
using System.Collections.Generic;
using TValleCustomClases;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000125 RID: 293
	[Serializable]
	public sealed class StringKeyQuaternionValueDictionary : SerializableDictionary<string, Quaternion>
	{
		// Token: 0x0600083A RID: 2106 RVA: 0x0001BB22 File Offset: 0x00019D22
		public StringKeyQuaternionValueDictionary()
		{
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x0001BB2A File Offset: 0x00019D2A
		public StringKeyQuaternionValueDictionary(IEqualityComparer<string> comparer)
			: base(comparer)
		{
		}
	}
}
