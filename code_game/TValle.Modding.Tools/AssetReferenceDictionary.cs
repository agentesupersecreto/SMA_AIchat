using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;

namespace Assets.TValle.Tools.Runtime
{
	// Token: 0x0200000B RID: 11
	[Serializable]
	public sealed class AssetReferenceDictionary : SerializableDictionary<string, AssetReference>
	{
		// Token: 0x06000023 RID: 35 RVA: 0x000026BC File Offset: 0x000008BC
		public AssetReferenceDictionary()
		{
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000026C4 File Offset: 0x000008C4
		public AssetReferenceDictionary(IEqualityComparer<string> comparer)
			: base(comparer)
		{
		}
	}
}
