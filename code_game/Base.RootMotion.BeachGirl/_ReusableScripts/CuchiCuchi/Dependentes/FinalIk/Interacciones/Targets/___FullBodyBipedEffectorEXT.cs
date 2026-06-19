using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Targets
{
	// Token: 0x020000BA RID: 186
	public static class ___FullBodyBipedEffectorEXT
	{
		// Token: 0x060006E5 RID: 1765 RVA: 0x00021564 File Offset: 0x0001F764
		public static void GetBendGoal(this CustomBipedEffector effector, out FullBodyBipedEffector shoulderOrMuscle, out FullBodyBipedEffector handOrFeet)
		{
			if (effector <= CustomBipedEffector.codoDerecho)
			{
				if (effector == CustomBipedEffector.codoIzquierdo)
				{
					shoulderOrMuscle = FullBodyBipedEffector.LeftShoulder;
					handOrFeet = FullBodyBipedEffector.LeftHand;
					return;
				}
				if (effector == CustomBipedEffector.codoDerecho)
				{
					shoulderOrMuscle = FullBodyBipedEffector.RightShoulder;
					handOrFeet = FullBodyBipedEffector.RightHand;
					return;
				}
			}
			else
			{
				if (effector == CustomBipedEffector.rodillaIzquierdo)
				{
					shoulderOrMuscle = FullBodyBipedEffector.LeftThigh;
					handOrFeet = FullBodyBipedEffector.LeftFoot;
					return;
				}
				if (effector == CustomBipedEffector.rodillaDerecho)
				{
					shoulderOrMuscle = FullBodyBipedEffector.RightThigh;
					handOrFeet = FullBodyBipedEffector.RightFoot;
					return;
				}
			}
			throw new ArgumentOutOfRangeException(effector.ToString());
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x000215C4 File Offset: 0x0001F7C4
		public static Side GetSide(this CustomBipedEffector effector)
		{
			if (effector > CustomBipedEffector.hombroIzquierdo)
			{
				if (effector != CustomBipedEffector.hombroDerecho)
				{
					if (effector == CustomBipedEffector.toeIzquierdo)
					{
						return Side.L;
					}
					if (effector != CustomBipedEffector.toeDerecho)
					{
						goto IL_0031;
					}
				}
				return Side.R;
			}
			if (effector - CustomBipedEffector.head <= 1 || effector == CustomBipedEffector.cuello2)
			{
				return Side.none;
			}
			if (effector != CustomBipedEffector.hombroIzquierdo)
			{
				goto IL_0031;
			}
			return Side.L;
			IL_0031:
			throw new ArgumentOutOfRangeException(effector.ToString());
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x00021614 File Offset: 0x0001F814
		public static HumanBodyBones ParceAHumanBone(this CustomBipedEffector effector)
		{
			if (effector <= CustomBipedEffector.hombroIzquierdo)
			{
				switch (effector)
				{
				case CustomBipedEffector.head:
					return HumanBodyBones.Head;
				case CustomBipedEffector.cuello1:
					return HumanBodyBones.Neck;
				case CustomBipedEffector.head | CustomBipedEffector.cuello1:
					break;
				case CustomBipedEffector.cuello2:
					return HumanBodyBones.Neck;
				default:
					if (effector == CustomBipedEffector.hombroIzquierdo)
					{
						return HumanBodyBones.LeftShoulder;
					}
					break;
				}
			}
			else
			{
				if (effector == CustomBipedEffector.hombroDerecho)
				{
					return HumanBodyBones.RightShoulder;
				}
				if (effector == CustomBipedEffector.toeIzquierdo)
				{
					return HumanBodyBones.LeftToes;
				}
				if (effector == CustomBipedEffector.toeDerecho)
				{
					return HumanBodyBones.RightToes;
				}
			}
			throw new ArgumentOutOfRangeException(effector.ToString());
		}
	}
}
