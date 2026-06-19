using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Testing.PhyscisAnus
{
	// Token: 0x02000017 RID: 23
	[ExecuteInEditMode]
	public class MeshBone : MonoBehaviour
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00004054 File Offset: 0x00002254
		private static GameObject prefab
		{
			get
			{
				if (MeshBone.m_prefab != null)
				{
					return MeshBone.m_prefab;
				}
				MeshBone.m_prefab = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				MeshBone.m_prefab.name = "IGNORE_ME";
				MeshBone.m_prefab.SetActive(false);
				Collider component = MeshBone.m_prefab.GetComponent<Collider>();
				if (component != null)
				{
					Object.DestroyImmediate(component);
				}
				return MeshBone.m_prefab;
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000040B8 File Offset: 0x000022B8
		private void Awake()
		{
			if (Application.isPlaying || this.m_trans != null)
			{
				return;
			}
			this.m_trans = Object.Instantiate<GameObject>(MeshBone.prefab).transform;
			this.m_trans.parent = base.transform;
			this.m_trans.localRotation = Quaternion.identity;
			this.m_trans.localPosition = Vector3.zero;
			this.m_trans.localScale = Vector3.one * 0.0004f;
			this.m_trans.gameObject.SetActive(true);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000414C File Offset: 0x0000234C
		private void OnDestroy()
		{
			if (Application.isPlaying)
			{
				return;
			}
			Object.DestroyImmediate(this.m_trans.gameObject);
		}

		// Token: 0x04000071 RID: 113
		private static GameObject m_prefab;

		// Token: 0x04000072 RID: 114
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_trans;
	}
}
