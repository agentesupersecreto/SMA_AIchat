using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000BF RID: 191
	[Serializable]
	public sealed class DatosDeNeck : DatosDeHumanBoneBase
	{
		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060005CA RID: 1482 RVA: 0x00016DF3 File Offset: 0x00014FF3
		public Quaternion initialCurrentWorldRotationDesdeChest
		{
			get
			{
				return this.chest.rotation * this.initialLocalRotationDesdeChest * this.offSetToForward;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060005CB RID: 1483 RVA: 0x00016E16 File Offset: 0x00015016
		public Vector3 initialCurrentWorldPositionDesdeChest
		{
			get
			{
				return this.chest.TransformPoint(this.initialLocalPositionDesdeChest);
			}
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00016E2C File Offset: 0x0001502C
		protected override void OnInit(Animator anim, HumanBodyBones boneEnum, Transform bone)
		{
			base.OnInit(anim, boneEnum, bone);
			if (boneEnum != HumanBodyBones.Neck)
			{
				throw new InvalidOperationException();
			}
			this.chest = anim.GetBoneTransform(HumanBodyBones.Chest);
			this.initialLocalPositionDesdeChest = this.chest.InverseTransformPoint(bone.position);
			this.initialLocalRotationDesdeChest = Quaternion.Inverse(this.chest.rotation) * bone.rotation;
		}

		// Token: 0x0400017F RID: 383
		public Transform chest;

		// Token: 0x04000180 RID: 384
		public Vector3 initialLocalPositionDesdeChest;

		// Token: 0x04000181 RID: 385
		public Quaternion initialLocalRotationDesdeChest;
	}
}
