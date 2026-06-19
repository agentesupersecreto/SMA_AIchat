using System;
using System.Collections.Generic;
using TValleCustomClases;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200011E RID: 286
	[Serializable]
	public sealed class StringKeyUnityValueDictionary : SerializableDictionary<string, Object>
	{
		// Token: 0x06000827 RID: 2087 RVA: 0x0001BA26 File Offset: 0x00019C26
		public StringKeyUnityValueDictionary()
		{
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x0001BA2E File Offset: 0x00019C2E
		public StringKeyUnityValueDictionary(IEqualityComparer<string> comparer)
			: base(comparer)
		{
		}
	}
}
