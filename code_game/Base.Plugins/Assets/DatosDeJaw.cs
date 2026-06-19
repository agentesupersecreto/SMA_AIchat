using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000BD RID: 189
	[Serializable]
	public sealed class DatosDeJaw : DatosDeHumanBoneBase
	{
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060005BE RID: 1470 RVA: 0x00016BDA File Offset: 0x00014DDA
		public Quaternion initialCurrentWorldRotationDesdeHead
		{
			get
			{
				return this.head.rotation * this.initialLocalRotationDesdeHead * this.offSetToForward;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060005BF RID: 1471 RVA: 0x00016BFD File Offset: 0x00014DFD
		public Vector3 initialCurrentWorldPositionDesdeHead
		{
			get
			{
				return this.head.TransformPoint(this.initialLocalPositionDesdeHead);
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060005C0 RID: 1472 RVA: 0x00016C10 File Offset: 0x00014E10
		// (set) Token: 0x060005C1 RID: 1473 RVA: 0x00016C40 File Offset: 0x00014E40
		public Vector3 currentRotationAnglesDesdeHead
		{
			get
			{
				return (Quaternion.Inverse(this.initialCurrentWorldRotationDesdeHead) * base.currentWorldRotation).eulerAngles.PolarizarAngulos();
			}
			set
			{
				this.transform.rotation = this.head.rotation * this.initialLocalRotationDesdeHead * Quaternion.Euler(this.offSetToForward * value);
			}
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x00016C7C File Offset: 0x00014E7C
		protected override void OnInit(Animator anim, HumanBodyBones boneEnum, Transform bone)
		{
			base.OnInit(anim, boneEnum, bone);
			if (boneEnum != HumanBodyBones.Jaw)
			{
				throw new InvalidOperationException();
			}
			this.head = anim.GetBoneTransform(HumanBodyBones.Head);
			this.initialLocalPositionDesdeHead = this.head.InverseTransformPoint(bone.position);
			this.initialLocalRotationDesdeHead = Quaternion.Inverse(this.head.rotation) * bone.rotation;
		}

		// Token: 0x04000179 RID: 377
		public Transform head;

		// Token: 0x0400017A RID: 378
		public Vector3 initialLocalPositionDesdeHead;

		// Token: 0x0400017B RID: 379
		public Quaternion initialLocalRotationDesdeHead;
	}
}
