using System;
using System.Collections.Generic;
using TValleCustomClases;

namespace Assets
{
	// Token: 0x02000123 RID: 291
	[Serializable]
	public sealed class StringKeyBoolValueDictionary : SerializableDictionary<string, bool>
	{
		// Token: 0x06000836 RID: 2102 RVA: 0x0001BB00 File Offset: 0x00019D00
		public StringKeyBoolValueDictionary()
		{
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x0001BB08 File Offset: 0x00019D08
		public StringKeyBoolValueDictionary(IEqualityComparer<string> comparer)
			: base(comparer)
		{
		}
	}
}
