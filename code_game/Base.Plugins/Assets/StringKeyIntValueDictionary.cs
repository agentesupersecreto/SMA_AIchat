using System;
using System.Collections.Generic;
using TValleCustomClases;

namespace Assets
{
	// Token: 0x02000122 RID: 290
	[Serializable]
	public sealed class StringKeyIntValueDictionary : SerializableDictionary<string, int>
	{
		// Token: 0x06000833 RID: 2099 RVA: 0x0001BAE6 File Offset: 0x00019CE6
		public StringKeyIntValueDictionary()
		{
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x0001BAEE File Offset: 0x00019CEE
		public StringKeyIntValueDictionary(IEqualityComparer<string> comparer)
			: base(comparer)
		{
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x0001BAF7 File Offset: 0x00019CF7
		public StringKeyIntValueDictionary(IDictionary<string, int> dictionary)
			: base(dictionary)
		{
		}
	}
}
