using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x02000054 RID: 84
	public static class TransformExt
	{
		// Token: 0x06000408 RID: 1032 RVA: 0x00018CDC File Offset: 0x00016EDC
		public static Transform FindTransform(this Transform rThis, HumanBodyBones rBone)
		{
			Animator component = rThis.gameObject.GetComponent<Animator>();
			if (component != null)
			{
				return component.GetBoneTransform(rBone);
			}
			return null;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00018D07 File Offset: 0x00016F07
		public static Transform FindTransform(this Transform rThis, string rName)
		{
			return TransformExt.FindChildTransform(rThis, rName);
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x00018D10 File Offset: 0x00016F10
		public static Transform FindChildTransform(Transform rParent, string rName)
		{
			string text = rParent.name;
			if (text == rName)
			{
				return rParent;
			}
			int num = text.IndexOf(':');
			if (num >= 0)
			{
				text = text.Substring(num + 1);
				if (text == rName)
				{
					return rParent;
				}
			}
			for (int i = 0; i < rParent.transform.childCount; i++)
			{
				Transform transform = TransformExt.FindChildTransform(rParent.transform.GetChild(i), rName);
				if (transform != null)
				{
					return transform;
				}
			}
			return null;
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x00018D88 File Offset: 0x00016F88
		public static void FindTransformChain(Transform rParent, string rName, ref List<Transform> rList)
		{
			Transform transform = rParent.FindTransform(rName);
			rList.Clear();
			while (transform != null)
			{
				rList.Add(transform);
				if (transform.childCount > 0)
				{
					transform = transform.GetChild(0);
				}
				else
				{
					transform = null;
				}
			}
		}
	}
}
