using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars
{
	// Token: 0x02000134 RID: 308
	[Serializable]
	public class BlendShapeTransfer
	{
		// Token: 0x06000D5A RID: 3418 RVA: 0x0002E608 File Offset: 0x0002C808
		public BlendShapeTransfer(Dictionary<string, int> sorceNameToIndex, SkinnedMeshRenderer target, float minValue, float maxValue)
		{
			if (target == null)
			{
				throw new InvalidOperationException();
			}
			this.m_minValue = minValue;
			this.m_maxValue = maxValue;
			this.m_target = target;
			this.m_sorceNameToSoruceIndex = new Dictionary<string, int>();
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			BlendShapeTransfer.GetNamesDic(dictionary, target);
			this.m_taretIndexToSourceIndex = new Dictionary<int, int>();
			this.m_targetIndexes = new List<int>();
			this.m_sourceIndexToTaretIndex = new Dictionary<int, int>();
			foreach (KeyValuePair<string, int> keyValuePair in dictionary)
			{
				if (sorceNameToIndex.ContainsKey(keyValuePair.Key))
				{
					this.m_taretIndexToSourceIndex.Add(keyValuePair.Value, sorceNameToIndex[keyValuePair.Key]);
					this.m_targetIndexes.Add(keyValuePair.Value);
					this.m_sorceNameToSoruceIndex.Add(keyValuePair.Key, sorceNameToIndex[keyValuePair.Key]);
					this.m_sourceIndexToTaretIndex.Add(sorceNameToIndex[keyValuePair.Key], keyValuePair.Value);
				}
			}
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06000D5B RID: 3419 RVA: 0x0002E738 File Offset: 0x0002C938
		public SkinnedMeshRenderer target
		{
			get
			{
				return this.m_target;
			}
		}

		// Token: 0x06000D5C RID: 3420 RVA: 0x0002E740 File Offset: 0x0002C940
		public void TransferShapes(Func<int, float> ValueDeIndex)
		{
			if (ValueDeIndex == null || this.m_target == null)
			{
				return;
			}
			Dictionary<int, int> taretIndexToSourceIndex = this.m_taretIndexToSourceIndex;
			for (int i = 0; i < this.m_targetIndexes.Count; i++)
			{
				int num = this.m_targetIndexes[i];
				int num2 = taretIndexToSourceIndex[num];
				float num3 = ValueDeIndex(num2);
				num3 = Mathf.Clamp(num3, this.m_minValue, this.m_maxValue);
				this.m_target.SetBlendShapeWeight(num, num3);
			}
		}

		// Token: 0x06000D5D RID: 3421 RVA: 0x0002E7C0 File Offset: 0x0002C9C0
		public float CurrentValue(int indexOfSource)
		{
			float blendShapeWeight;
			try
			{
				int num = this.m_sourceIndexToTaretIndex[indexOfSource];
				blendShapeWeight = this.m_target.GetBlendShapeWeight(num);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return blendShapeWeight;
		}

		// Token: 0x06000D5E RID: 3422 RVA: 0x0002E7FC File Offset: 0x0002C9FC
		public bool ContieneShape(string nameOfSource)
		{
			return this.m_sorceNameToSoruceIndex.ContainsKey(nameOfSource);
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x0002E80C File Offset: 0x0002CA0C
		public float CurrentValue(string nameOfSource)
		{
			float num2;
			try
			{
				int num;
				if (this.m_sorceNameToSoruceIndex.TryGetValue(nameOfSource, out num))
				{
					num2 = this.CurrentValue(num);
				}
				else
				{
					num2 = 0f;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return num2;
		}

		// Token: 0x06000D60 RID: 3424 RVA: 0x0002E850 File Offset: 0x0002CA50
		public static void GetNamesDic(Dictionary<string, int> result, SkinnedMeshRenderer render)
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

		// Token: 0x04000779 RID: 1913
		[ReadOnlyUI]
		[SerializeField]
		private SkinnedMeshRenderer m_target;

		// Token: 0x0400077A RID: 1914
		[ReadOnlyUI]
		[SerializeField]
		private float m_minValue;

		// Token: 0x0400077B RID: 1915
		[ReadOnlyUI]
		[SerializeField]
		private float m_maxValue;

		// Token: 0x0400077C RID: 1916
		[NonSerialized]
		private Dictionary<string, int> m_sorceNameToSoruceIndex;

		// Token: 0x0400077D RID: 1917
		[NonSerialized]
		private Dictionary<int, int> m_sourceIndexToTaretIndex;

		// Token: 0x0400077E RID: 1918
		[NonSerialized]
		private Dictionary<int, int> m_taretIndexToSourceIndex;

		// Token: 0x0400077F RID: 1919
		[NonSerialized]
		private List<int> m_targetIndexes;
	}
}
