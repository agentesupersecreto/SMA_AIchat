using System;
using Assets;
using RootMotion.Dynamics;
using UnityEngine;

// Token: 0x02000002 RID: 2
public static class PuppetExt
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static Muscle GetMuscle(this PuppetMaster puppet, Transform bone)
	{
		if (puppet == null)
		{
			return null;
		}
		foreach (Muscle muscle in puppet.muscles)
		{
			if (muscle.target == bone)
			{
				return muscle;
			}
		}
		return null;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002094 File Offset: 0x00000294
	public static Muscle GetMuscle(this PuppetMaster puppet, string bone)
	{
		foreach (Muscle muscle in puppet.muscles)
		{
			if (muscle.target.name == bone)
			{
				return muscle;
			}
		}
		return null;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000020D0 File Offset: 0x000002D0
	public static Muscle GetMuscle(this PuppetMaster puppet, Animator anim, HumanBodyBones bone)
	{
		Transform boneTransform = anim.GetBoneTransform(bone);
		if (boneTransform == null)
		{
			return null;
		}
		return puppet.GetMuscle(boneTransform);
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000020F8 File Offset: 0x000002F8
	public static Muscle GetMuscle(this PuppetMaster puppet, HumanBodyBones bone)
	{
		Animator targetAnimator = puppet.targetAnimator;
		Transform transform = ((targetAnimator != null) ? targetAnimator.GetBoneTransform(bone) : null);
		if (transform == null)
		{
			return null;
		}
		return puppet.GetMuscle(transform);
	}

	// Token: 0x06000005 RID: 5 RVA: 0x0000212C File Offset: 0x0000032C
	public static Muscle GetMuscle(this PuppetMaster puppet, Side side, Muscle.GroupCompleto muscle)
	{
		for (int i = 0; i < puppet.muscles.Length; i++)
		{
			Muscle muscle2 = puppet.muscles[i];
			if (muscle2.grupo == muscle)
			{
				switch (side)
				{
				case Side.none:
					if (muscle2.side == Muscle.MuscleSide.None)
					{
						return muscle2;
					}
					break;
				case Side.L:
					if (muscle2.side == Muscle.MuscleSide.L)
					{
						return muscle2;
					}
					break;
				case Side.R:
					if (muscle2.side == Muscle.MuscleSide.R)
					{
						return muscle2;
					}
					break;
				}
			}
		}
		return null;
	}
}
