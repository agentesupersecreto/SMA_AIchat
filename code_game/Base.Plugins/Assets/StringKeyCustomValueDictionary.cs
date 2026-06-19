using System;
using System.Collections.Generic;
using TValleCustomClases;

namespace Assets
{
	// Token: 0x02000120 RID: 288
	[Serializable]
	public sealed class StringKeyCustomValueDictionary : SerializableDictionary<string, object>
	{
		// Token: 0x0600082F RID: 2095 RVA: 0x0001BAC4 File Offset: 0x00019CC4
		public StringKeyCustomValueDictionary()
		{
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x0001BACC File Offset: 0x00019CCC
		public StringKeyCustomValueDictionary(IEqualityComparer<string> comparer)
			: base(comparer)
		{
		}
	}
}
