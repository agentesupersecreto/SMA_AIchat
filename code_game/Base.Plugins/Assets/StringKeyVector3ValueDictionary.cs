using System;
using System.Collections.Generic;
using TValleCustomClases;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000124 RID: 292
	[Serializable]
	public sealed class StringKeyVector3ValueDictionary : SerializableDictionary<string, Vector3>
	{
		// Token: 0x06000838 RID: 2104 RVA: 0x0001BB11 File Offset: 0x00019D11
		public StringKeyVector3ValueDictionary()
		{
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x0001BB19 File Offset: 0x00019D19
		public StringKeyVector3ValueDictionary(IEqualityComparer<string> comparer)
			: base(comparer)
		{
		}
	}
}
