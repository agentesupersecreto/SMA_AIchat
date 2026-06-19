using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Testing.PhyscisAnus
{
	// Token: 0x02000014 RID: 20
	[ExecuteInEditMode]
	public class AddMeshesToBones : MonoBehaviour
	{
		// Token: 0x0600007D RID: 125 RVA: 0x00003D14 File Offset: 0x00001F14
		private void Update()
		{
			if (Application.isPlaying)
			{
				return;
			}
			if (this.m_AddDrawers)
			{
				this.m_AddDrawers = false;
				this.AddDrawers(true);
			}
			if (this.m_RemoveDrawers)
			{
				this.m_RemoveDrawers = false;
				this.RemoveDrawers();
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003D49 File Offset: 0x00001F49
		public void RemoveDrawers()
		{
			if (this.root == null)
			{
				return;
			}
			AddMeshesToBones.RemoveToChildren<MeshBone>(this.root);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003D65 File Offset: 0x00001F65
		public void AddDrawers(bool ignoreSelf = false)
		{
			if (this.root == null)
			{
				return;
			}
			AddMeshesToBones.AddToChildren<MeshBone>(this.root, ignoreSelf);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003D84 File Offset: 0x00001F84
		private static void AddToChildren<T>(Transform trans, bool ignoreSelf = false) where T : Component
		{
			if (!ignoreSelf && (trans.name.Contains("DEF") || trans.name.Contains("Stretch")))
			{
				trans.GetComponentNotNull<T>();
			}
			foreach (object obj in trans)
			{
				AddMeshesToBones.AddToChildren<T>((Transform)obj, false);
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003E04 File Offset: 0x00002004
		private static void RemoveToChildren<T>(Transform trans) where T : Component
		{
			T component = trans.GetComponent<T>();
			if (component != null)
			{
				Object.DestroyImmediate(component);
			}
			foreach (object obj in trans)
			{
				AddMeshesToBones.RemoveToChildren<T>((Transform)obj);
			}
		}

		// Token: 0x04000068 RID: 104
		public Transform root;

		// Token: 0x04000069 RID: 105
		public bool m_AddDrawers;

		// Token: 0x0400006A RID: 106
		public bool m_RemoveDrawers;
	}
}
