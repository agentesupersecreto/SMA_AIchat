using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars
{
	// Token: 0x02000133 RID: 307
	public abstract class BlendShapeCopier : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06000D54 RID: 3412
		protected abstract SkinnedMeshRenderer skinnedMeshRendererSource { get; }

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06000D55 RID: 3413
		protected abstract List<SkinnedMeshRenderer> skinnedMeshRendererSourceTargets { get; }

		// Token: 0x06000D56 RID: 3414 RVA: 0x0002E390 File Offset: 0x0002C590
		public void UpdateData()
		{
			this.m_sourcesToDestinationIndex = new List<List<int>>();
			this.m_sourcesToDestinationDic = new List<Dictionary<int, int>>();
			this.m_source = null;
			this.m_targets = null;
			List<SkinnedMeshRenderer> skinnedMeshRendererSourceTargets = this.skinnedMeshRendererSourceTargets;
			if (this.skinnedMeshRendererSource == null || skinnedMeshRendererSourceTargets == null || skinnedMeshRendererSourceTargets.Count == 0)
			{
				throw new InvalidOperationException();
			}
			this.m_source = this.skinnedMeshRendererSource;
			this.m_targets = skinnedMeshRendererSourceTargets;
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			BlendShapeCopier.GetNamesDic(dictionary, this.m_source);
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in this.m_targets)
			{
				if (skinnedMeshRenderer == null)
				{
					throw new ArgumentNullException("target", "target null reference.");
				}
				Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
				BlendShapeCopier.GetNamesDic(dictionary2, skinnedMeshRenderer);
				Dictionary<int, int> dictionary3 = new Dictionary<int, int>();
				List<int> list = new List<int>();
				foreach (KeyValuePair<string, int> keyValuePair in dictionary2)
				{
					if (dictionary.ContainsKey(keyValuePair.Key))
					{
						dictionary3.Add(keyValuePair.Value, dictionary[keyValuePair.Key]);
						list.Add(keyValuePair.Value);
					}
				}
				this.m_sourcesToDestinationIndex.Add(list);
				this.m_sourcesToDestinationDic.Add(dictionary3);
			}
		}

		// Token: 0x06000D57 RID: 3415 RVA: 0x0002E510 File Offset: 0x0002C710
		public void CopyShapes()
		{
			if (this.m_source == null || this.m_targets == null || this.m_targets.Count == 0)
			{
				return;
			}
			for (int i = 0; i < this.m_targets.Count; i++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = this.m_targets[i];
				Dictionary<int, int> dictionary = this.m_sourcesToDestinationDic[i];
				List<int> list = this.m_sourcesToDestinationIndex[i];
				for (int j = 0; j < list.Count; j++)
				{
					int num = list[j];
					int num2 = dictionary[num];
					float blendShapeWeight = this.m_source.GetBlendShapeWeight(num2);
					skinnedMeshRenderer.SetBlendShapeWeight(num, blendShapeWeight);
				}
			}
		}

		// Token: 0x06000D58 RID: 3416 RVA: 0x0002E5C0 File Offset: 0x0002C7C0
		private static void GetNamesDic(Dictionary<string, int> result, SkinnedMeshRenderer render)
		{
			result.Clear();
			Mesh sharedMesh = render.sharedMesh;
			int blendShapeCount = sharedMesh.blendShapeCount;
			for (int i = 0; i < blendShapeCount; i++)
			{
				string blendShapeName = sharedMesh.GetBlendShapeName(i);
				result.Add(blendShapeName, i);
			}
		}

		// Token: 0x04000775 RID: 1909
		[NonSerialized]
		private SkinnedMeshRenderer m_source;

		// Token: 0x04000776 RID: 1910
		[NonSerialized]
		private List<SkinnedMeshRenderer> m_targets;

		// Token: 0x04000777 RID: 1911
		[NonSerialized]
		private List<Dictionary<int, int>> m_sourcesToDestinationDic;

		// Token: 0x04000778 RID: 1912
		[NonSerialized]
		private List<List<int>> m_sourcesToDestinationIndex;
	}
}
