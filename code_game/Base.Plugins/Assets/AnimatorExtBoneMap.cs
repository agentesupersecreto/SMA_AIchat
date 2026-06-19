using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000163 RID: 355
	public static class AnimatorExtBoneMap
	{
		// Token: 0x06000A71 RID: 2673 RVA: 0x000233C6 File Offset: 0x000215C6
		public static Transform GetBoneTransform(this Animator anim, string name)
		{
			if (anim == null)
			{
				throw new ArgumentNullException("anim", "anim null reference.");
			}
			if (name == null)
			{
				return null;
			}
			return anim.GetBoneTransform(HumanBodyBones.Hips).FindDeepChild(name, true);
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x000233F4 File Offset: 0x000215F4
		public static Transform GetBoneTransform(this Animator anim, string name, string name2)
		{
			if (anim == null)
			{
				throw new ArgumentNullException("anim", "anim null reference.");
			}
			if (name == null)
			{
				return null;
			}
			return anim.GetBoneTransform(HumanBodyBones.Hips).FindDeepChild(name, name2, true);
		}
	}
}
