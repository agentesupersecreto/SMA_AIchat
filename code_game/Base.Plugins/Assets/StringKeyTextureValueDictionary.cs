using System;
using System.Collections.Generic;
using TValleCustomClases;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000126 RID: 294
	[Serializable]
	public sealed class StringKeyTextureValueDictionary : SerializableDictionary<string, Texture>
	{
		// Token: 0x0600083C RID: 2108 RVA: 0x0001BB33 File Offset: 0x00019D33
		public StringKeyTextureValueDictionary()
		{
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x0001BB3B File Offset: 0x00019D3B
		public StringKeyTextureValueDictionary(IEqualityComparer<string> comparer)
			: base(comparer)
		{
		}
	}
}
