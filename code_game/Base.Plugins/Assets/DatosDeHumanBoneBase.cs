using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000C3 RID: 195
	public abstract class DatosDeHumanBoneBase : DatosDeBoneBase
	{
		// Token: 0x060005D2 RID: 1490 RVA: 0x00016EE8 File Offset: 0x000150E8
		public void Init(Animator anim, HumanBodyBones boneEnum)
		{
			this.humanBodyBone = boneEnum;
			Transform boneTransform = anim.GetBoneTransform(boneEnum);
			this.OnInit(anim, boneEnum, boneTransform);
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x00016F0D File Offset: 0x0001510D
		protected virtual void OnInit(Animator anim, HumanBodyBones boneEnum, Transform bone)
		{
			this.OnInit(anim, bone);
		}

		// Token: 0x04000182 RID: 386
		public HumanBodyBones humanBodyBone;
	}
}
