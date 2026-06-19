using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Testing.PhyscisAnus
{
	// Token: 0x02000013 RID: 19
	[ExecuteInEditMode]
	public class AddDrawersToBones : MonoBehaviour
	{
		// Token: 0x06000076 RID: 118 RVA: 0x00003B39 File Offset: 0x00001D39
		private void Awake()
		{
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003BCC File Offset: 0x00001DCC
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

		// Token: 0x06000078 RID: 120 RVA: 0x00003C01 File Offset: 0x00001E01
		public void RemoveDrawers()
		{
			if (this.root == null)
			{
				return;
			}
			AddDrawersToBones.RemoveToChildren<GizmoBone>(this.root);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003C1D File Offset: 0x00001E1D
		public void AddDrawers(bool ignoreSelf = false)
		{
			if (this.root == null)
			{
				return;
			}
			AddDrawersToBones.AddToChildren<GizmoBone>(this.root, ignoreSelf);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003C3C File Offset: 0x00001E3C
		private static void AddToChildren<T>(Transform trans, bool ignoreSelf = false) where T : Component
		{
			if (!ignoreSelf)
			{
				trans.GetComponentNotNull<T>();
			}
			foreach (object obj in trans)
			{
				AddDrawersToBones.AddToChildren<T>((Transform)obj, false);
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003C98 File Offset: 0x00001E98
		private static void RemoveToChildren<T>(Transform trans) where T : Component
		{
			T component = trans.GetComponent<T>();
			if (component != null)
			{
				Object.DestroyImmediate(component);
			}
			foreach (object obj in trans)
			{
				AddDrawersToBones.RemoveToChildren<T>((Transform)obj);
			}
		}

		// Token: 0x04000065 RID: 101
		public Transform root;

		// Token: 0x04000066 RID: 102
		public bool m_AddDrawers;

		// Token: 0x04000067 RID: 103
		public bool m_RemoveDrawers;
	}
}
