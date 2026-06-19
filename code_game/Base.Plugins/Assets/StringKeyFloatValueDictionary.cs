using System;
using System.Collections.Generic;
using TValleCustomClases;

namespace Assets
{
	// Token: 0x02000121 RID: 289
	[Serializable]
	public sealed class StringKeyFloatValueDictionary : SerializableDictionary<string, float>
	{
		// Token: 0x06000831 RID: 2097 RVA: 0x0001BAD5 File Offset: 0x00019CD5
		public StringKeyFloatValueDictionary()
		{
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x0001BADD File Offset: 0x00019CDD
		public StringKeyFloatValueDictionary(IEqualityComparer<string> comparer)
			: base(comparer)
		{
		}
	}
}
