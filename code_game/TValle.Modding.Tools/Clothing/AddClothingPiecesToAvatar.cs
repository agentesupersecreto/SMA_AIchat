using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Clothing
{
	// Token: 0x0200003A RID: 58
	public class AddClothingPiecesToAvatar : MonoBehaviour
	{
		// Token: 0x0600014B RID: 331 RVA: 0x00003694 File Offset: 0x00001894
		private void OnEnable()
		{
			if (this.m_avatar == null || this.m_clothingAssets == null || this.m_clothingAssets.Length == 0)
			{
				return;
			}
			Dictionary<string, Transform> dictionary = this.m_avatar.GetComponentsInChildren<SkinnedMeshRenderer>().SelectMany((SkinnedMeshRenderer s) => s.bones).Distinct<Transform>()
				.ToDictionary((Transform b) => b.name);
			this.m_clothingInstances = (from a in this.m_clothingAssets
				where a != null
				select Object.Instantiate<SkinnedMeshRenderer>(a, this.m_avatar.transform.position, this.m_avatar.transform.rotation, this.m_avatar.transform)).ToArray<SkinnedMeshRenderer>();
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in this.m_clothingInstances)
			{
				if (!(skinnedMeshRenderer == null))
				{
					Transform[] bones = skinnedMeshRenderer.bones;
					for (int j = 0; j < bones.Length; j++)
					{
						Transform transform = bones[j];
						Transform transform2;
						if (!(transform == null) && dictionary.TryGetValue(transform.name, out transform2))
						{
							bones[j] = transform2;
						}
					}
					skinnedMeshRenderer.bones = bones;
				}
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x000037D0 File Offset: 0x000019D0
		private void OnDisable()
		{
			if (this.m_clothingInstances == null || this.m_clothingInstances.Length == 0)
			{
				return;
			}
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in this.m_clothingInstances)
			{
				if (skinnedMeshRenderer != null)
				{
					Object.Destroy(skinnedMeshRenderer);
				}
			}
			this.m_clothingInstances = null;
		}

		// Token: 0x0400007F RID: 127
		[SerializeField]
		private Animator m_avatar;

		// Token: 0x04000080 RID: 128
		[SerializeField]
		private SkinnedMeshRenderer[] m_clothingAssets;

		// Token: 0x04000081 RID: 129
		private SkinnedMeshRenderer[] m_clothingInstances;
	}
}
