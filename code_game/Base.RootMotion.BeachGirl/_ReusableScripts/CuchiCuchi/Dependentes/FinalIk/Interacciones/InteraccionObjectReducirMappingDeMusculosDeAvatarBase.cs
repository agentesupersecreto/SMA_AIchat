using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x020000A7 RID: 167
	public abstract class InteraccionObjectReducirMappingDeMusculosDeAvatarBase : InteraccionObjectReducirMappingDeMusculos
	{
		// Token: 0x06000672 RID: 1650 RVA: 0x0001F94C File Offset: 0x0001DB4C
		protected sealed override IReadOnlyList<Transform> ObtenerBonesToUnMap()
		{
			List<Transform> list = new List<Transform>();
			ICharacter componentInParent = base.GetComponentInParent<ICharacter>();
			if (componentInParent == null)
			{
				return list;
			}
			Animator bodyAnimator = componentInParent.bodyAnimator;
			if (bodyAnimator == null)
			{
				return list;
			}
			for (int i = 0; i < this.m_avatarBones.Count; i++)
			{
				Transform boneTransform = bodyAnimator.GetBoneTransform(this.m_avatarBones[i]);
				if (!(boneTransform == null))
				{
					list.Add(boneTransform);
				}
			}
			return list;
		}

		// Token: 0x04000470 RID: 1136
		[Header("Human Body Bones")]
		[SerializeField]
		private List<HumanBodyBones> m_avatarBones = new List<HumanBodyBones>();
	}
}
