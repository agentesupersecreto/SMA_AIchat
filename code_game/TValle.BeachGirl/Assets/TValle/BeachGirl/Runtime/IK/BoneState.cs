using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.IK
{
	// Token: 0x020000A2 RID: 162
	[Serializable]
	public class BoneState
	{
		// Token: 0x060004F7 RID: 1271 RVA: 0x0000FF78 File Offset: 0x0000E178
		public void Init(Transform bone, BoneState initial, Animator anim)
		{
			this.bone = bone;
			this.initial = initial;
			this.up = bone.InverseTransformDirection(anim.transform.up);
			this.forward = bone.InverseTransformDirection(anim.transform.forward);
			this.right = bone.InverseTransformDirection(anim.transform.right);
			this.position = bone.position;
			this.rotation = bone.rotation;
			this.localRotation = bone.localRotation;
			this.localPosition = bone.localPosition;
			this.offSetToForward = Quaternion.Inverse(anim.transform.rotation) * bone.rotation;
			this.forwardPoint = this.position + this.forward;
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00010040 File Offset: 0x0000E240
		public void Save()
		{
			if (this.initial == null)
			{
				return;
			}
			this.up = this.bone.TransformDirection(this.initial.up);
			this.forward = this.bone.TransformDirection(this.initial.forward);
			this.right = this.bone.TransformDirection(this.initial.right);
			this.position = this.bone.position;
			this.rotation = this.bone.rotation;
			this.localRotation = this.bone.localRotation;
			this.localPosition = this.bone.localPosition;
			this.forwardPoint = this.position + this.forward;
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00010108 File Offset: 0x0000E308
		[Obsolete]
		public void Save(Transform bone, BoneState initialAxis)
		{
			this.up = bone.TransformDirection(initialAxis.up);
			this.forward = bone.TransformDirection(initialAxis.forward);
			this.right = bone.TransformDirection(initialAxis.right);
			this.position = bone.position;
			this.rotation = bone.rotation;
			this.localRotation = bone.localRotation;
			this.localPosition = bone.localPosition;
		}

		// Token: 0x040002EE RID: 750
		[NonSerialized]
		public Transform bone;

		// Token: 0x040002EF RID: 751
		[NonSerialized]
		public BoneState initial;

		// Token: 0x040002F0 RID: 752
		public Vector3 up;

		// Token: 0x040002F1 RID: 753
		public Vector3 forward;

		// Token: 0x040002F2 RID: 754
		public Vector3 forwardPoint;

		// Token: 0x040002F3 RID: 755
		public Vector3 right;

		// Token: 0x040002F4 RID: 756
		public Vector3 position;

		// Token: 0x040002F5 RID: 757
		public Quaternion rotation;

		// Token: 0x040002F6 RID: 758
		public Quaternion localRotation;

		// Token: 0x040002F7 RID: 759
		public Vector3 localPosition;

		// Token: 0x040002F8 RID: 760
		public Quaternion offSetToForward;
	}
}
