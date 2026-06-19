using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200000B RID: 11
	public class AssetBundleManager
	{
		// Token: 0x0600004E RID: 78 RVA: 0x000031CC File Offset: 0x000013CC
		public void RegisterAssetBundle(AssetBundle bundle)
		{
			if (bundle == null)
			{
				return;
			}
			this.bundles.Add(bundle);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000031E8 File Offset: 0x000013E8
		public void UnregisterAssetBundle(AssetBundle bundle)
		{
			if (bundle == null)
			{
				return;
			}
			this.bundles.Remove(bundle);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003204 File Offset: 0x00001404
		public Object Load(string name)
		{
			foreach (AssetBundle assetBundle in this.bundles)
			{
				if (assetBundle.Contains(name))
				{
					return this.LoadFromBundle(assetBundle, name);
				}
			}
			return Resources.Load(name);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003288 File Offset: 0x00001488
		public Object Load(string name, Type type)
		{
			foreach (AssetBundle assetBundle in this.bundles)
			{
				if (assetBundle.Contains(name))
				{
					return this.LoadFromBundle(assetBundle, name, type);
				}
			}
			return Resources.Load(name, type);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000330C File Offset: 0x0000150C
		private Object LoadFromBundle(AssetBundle bundle, string name)
		{
			return bundle.LoadAsset(name);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003318 File Offset: 0x00001518
		private Object LoadFromBundle(AssetBundle bundle, string name, Type type)
		{
			return bundle.LoadAsset(name, type);
		}

		// Token: 0x04000026 RID: 38
		private HashSet<AssetBundle> bundles = new HashSet<AssetBundle>();
	}
}
