using System;
using System.Collections.Generic;
using TValleCustomClases;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000127 RID: 295
	[Serializable]
	public sealed class TypeKeyUnityValueDictionary : SerializableDictionary<SerializableType, Object>
	{
		// Token: 0x0600083E RID: 2110 RVA: 0x0001BB44 File Offset: 0x00019D44
		public TypeKeyUnityValueDictionary()
			: base(new TypeKeyUnityValueDictionaryComparador())
		{
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x0001BB51 File Offset: 0x00019D51
		public TypeKeyUnityValueDictionary(IEqualityComparer<SerializableType> comparer)
			: base(comparer)
		{
		}
	}
}
