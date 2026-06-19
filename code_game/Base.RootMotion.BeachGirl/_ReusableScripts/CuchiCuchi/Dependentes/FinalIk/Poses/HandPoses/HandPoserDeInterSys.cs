using System;
using System.Collections.Generic;
using RootMotion;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Poses.HandPoses
{
	// Token: 0x0200008D RID: 141
	public sealed class HandPoserDeInterSys : PoserDeInterSys
	{
		// Token: 0x06000587 RID: 1415 RVA: 0x0001BC64 File Offset: 0x00019E64
		public override void AutoMapping()
		{
			if (this.poseRoot == null)
			{
				this.poseChildren = new Transform[0];
			}
			else
			{
				this.poseChildren = this.poseRoot.GetComponentsInChildren<Transform>();
			}
			this._poseRoot = this.poseRoot;
			if (this.poseChildren.Length <= this.children.Length)
			{
				return;
			}
			if (base.transform.name != this.poseRoot.name)
			{
				return;
			}
			List<Transform> list = new List<Transform>(this.children.Length);
			HandPoserDeInterSys.Load(base.transform, this.poseRoot, list);
			this.poseChildren = list.ToArray();
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x0001BD08 File Offset: 0x00019F08
		private static void Load(Transform source, Transform target, List<Transform> result)
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
					HandPoserDeInterSys.Load(child, transform, result);
				}
			}
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x0001BD6C File Offset: 0x00019F6C
		protected override void InitiatePoser()
		{
			this.children = base.GetComponentsInChildren<Transform>();
			this.StoreDefaultState();
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x0001BD80 File Offset: 0x00019F80
		protected override void FixPoserTransforms()
		{
			for (int i = 0; i < this.children.Length; i++)
			{
				this.children[i].localPosition = this.defaultLocalPositions[i];
				this.children[i].localRotation = this.defaultLocalRotations[i];
			}
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x0001BDD4 File Offset: 0x00019FD4
		protected override void UpdatePoser()
		{
			if (this.weight <= 0f)
			{
				return;
			}
			if (this.localPositionWeight <= 0f && this.localRotationWeight <= 0f)
			{
				return;
			}
			if (this._poseRoot != this.poseRoot)
			{
				this.AutoMapping();
			}
			if (this.poseRoot == null)
			{
				return;
			}
			if (this.children.Length != this.poseChildren.Length)
			{
				Warning.Log("Number of children does not match with the pose", base.transform, false);
				return;
			}
			float num = this.localRotationWeight * this.weight;
			float num2 = this.localPositionWeight * this.weight;
			for (int i = 0; i < this.children.Length; i++)
			{
				if (this.children[i] != base.transform)
				{
					this.children[i].localRotation = Quaternion.Lerp(this.children[i].localRotation, this.poseChildren[i].localRotation, num);
					this.children[i].localPosition = Vector3.Lerp(this.children[i].localPosition, this.poseChildren[i].localPosition, num2);
				}
			}
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x0001BEF4 File Offset: 0x0001A0F4
		private void StoreDefaultState()
		{
			this.defaultLocalPositions = new Vector3[this.children.Length];
			this.defaultLocalRotations = new Quaternion[this.children.Length];
			for (int i = 0; i < this.children.Length; i++)
			{
				this.defaultLocalPositions[i] = this.children[i].localPosition;
				this.defaultLocalRotations[i] = this.children[i].localRotation;
			}
		}

		// Token: 0x040003CE RID: 974
		private Transform _poseRoot;

		// Token: 0x040003CF RID: 975
		private Transform[] children;

		// Token: 0x040003D0 RID: 976
		private Transform[] poseChildren;

		// Token: 0x040003D1 RID: 977
		private Vector3[] defaultLocalPositions;

		// Token: 0x040003D2 RID: 978
		private Quaternion[] defaultLocalRotations;
	}
}
