using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000BE RID: 190
	[Serializable]
	public sealed class DatosDeLengua : DatosDeNoHumanBoneBase
	{
		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060005C4 RID: 1476 RVA: 0x00016CEB File Offset: 0x00014EEB
		public Quaternion initialCurrentWorldRotationDesdeJaw
		{
			get
			{
				return this.jaw.rotation * this.initialLocalRotationDesdeJaw * this.offSetToForward;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060005C5 RID: 1477 RVA: 0x00016D0E File Offset: 0x00014F0E
		public Vector3 initialCurrentWorldPositionDesdeJaw
		{
			get
			{
				return this.jaw.TransformPoint(this.initialLocalPositionDesdeJaw);
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060005C6 RID: 1478 RVA: 0x00016D24 File Offset: 0x00014F24
		// (set) Token: 0x060005C7 RID: 1479 RVA: 0x00016D54 File Offset: 0x00014F54
		public Vector3 currentRotationAnglesDesdeJaw
		{
			get
			{
				return (Quaternion.Inverse(this.initialCurrentWorldRotationDesdeJaw) * base.currentWorldRotation).eulerAngles.PolarizarAngulos();
			}
			set
			{
				this.transform.rotation = this.jaw.rotation * this.initialLocalRotationDesdeJaw * Quaternion.Euler(this.offSetToForward * value);
			}
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00016D90 File Offset: 0x00014F90
		protected override void OnInit(Animator anim, Transform bone)
		{
			base.OnInit(anim, bone);
			this.jaw = anim.GetBoneTransform(HumanBodyBones.Jaw);
			this.initialLocalPositionDesdeJaw = this.jaw.InverseTransformPoint(bone.position);
			this.initialLocalRotationDesdeJaw = Quaternion.Inverse(this.jaw.rotation) * bone.rotation;
		}

		// Token: 0x0400017C RID: 380
		public Transform jaw;

		// Token: 0x0400017D RID: 381
		public Vector3 initialLocalPositionDesdeJaw;

		// Token: 0x0400017E RID: 382
		public Quaternion initialLocalRotationDesdeJaw;
	}
}
