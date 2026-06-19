using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200016E RID: 366
	public static class TValleEditorTools
	{
		// Token: 0x06000AE2 RID: 2786 RVA: 0x00025062 File Offset: 0x00023262
		public static void Destroy(Object obj)
		{
			if (obj == null)
			{
				return;
			}
			Object.Destroy(obj);
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x00025074 File Offset: 0x00023274
		public static List<TMapa> CargarTodosLosMapasDeTipo<TMapa>() where TMapa : ScriptableObject
		{
			if (Application.isPlaying)
			{
				throw new InvalidOperationException();
			}
			if (!Application.isEditor)
			{
				throw new InvalidOperationException();
			}
			return new List<TMapa>();
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x00025095 File Offset: 0x00023295
		public static void SaveUndo(Object obj)
		{
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x00025097 File Offset: 0x00023297
		public static void SaveUndo(Object[] objs, string name)
		{
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x00025099 File Offset: 0x00023299
		public static void PrefabSetDirtyV2(Object obj)
		{
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x0002509B File Offset: 0x0002329B
		public static void SetDirty(ScriptableObject obj)
		{
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x0002509D File Offset: 0x0002329D
		public static void SetDirty(Object obj)
		{
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x0002509F File Offset: 0x0002329F
		[Obsolete("", true)]
		public static void PrefabSetDirty(Object obj)
		{
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x000250A4 File Offset: 0x000232A4
		public static bool IsPersistent(Object obj)
		{
			if (obj == null)
			{
				return false;
			}
			Component component = obj as Component;
			if (component != null)
			{
				return !component.gameObject.scene.IsValid();
			}
			GameObject gameObject = obj as GameObject;
			return gameObject != null && !gameObject.scene.IsValid();
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x00025106 File Offset: 0x00023306
		public static string Ruta(Object obj)
		{
			return null;
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0002510C File Offset: 0x0002330C
		private static string RutaEnScena(Transform target)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Insert(0, target.name);
			Transform transform = target;
			while (transform.parent != null)
			{
				transform = transform.parent;
				stringBuilder.Insert(0, '.');
				stringBuilder.Insert(0, transform.name);
			}
			return stringBuilder.ToString();
		}
	}
}
