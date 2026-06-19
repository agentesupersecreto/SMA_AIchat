using System;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.HandPoses
{
	// Token: 0x0200008A RID: 138
	public sealed class HandPoserByName : HandPoser
	{
		// Token: 0x06000575 RID: 1397 RVA: 0x0001B96C File Offset: 0x00019B6C
		public override void AutoMapping()
		{
			base.AutoMapping();
			if (this.poseChildren.Length <= this.children.Length)
			{
				return;
			}
			if (base.transform.name != this.poseRoot.name)
			{
				return;
			}
			List<Transform> list = new List<Transform>(this.children.Length);
			this.Load(base.transform, this.poseRoot, list);
			this.poseChildren = list.ToArray();
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0001B9E0 File Offset: 0x00019BE0
		private void Load(Transform source, Transform target, List<Transform> result)
		{
			if (source.name != target.name)
			{
				throw new InvalidOperationException();
			}
			result.Add(target);
			for (int i = 0; i < source.childCount; i++)
			{
				Transform child = source.GetChild(i);
				Transform transform = target.Find(child.name);
				if (!(transform == null))
				{
					this.Load(child, transform, result);
				}
			}
		}
	}
}
