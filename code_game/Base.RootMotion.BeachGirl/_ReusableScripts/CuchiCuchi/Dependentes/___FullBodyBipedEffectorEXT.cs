using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes
{
	// Token: 0x0200004D RID: 77
	public static class ___FullBodyBipedEffectorEXT
	{
		// Token: 0x06000349 RID: 841 RVA: 0x000108B4 File Offset: 0x0000EAB4
		public static ParteDelCuerpoHumano ParceAParteHumama(this FullBodyBipedEffector effector)
		{
			switch (effector)
			{
			case FullBodyBipedEffector.Body:
				return ParteDelCuerpoHumano.cintura;
			case FullBodyBipedEffector.LeftShoulder:
				return ParteDelCuerpoHumano.brazos;
			case FullBodyBipedEffector.RightShoulder:
				return ParteDelCuerpoHumano.brazos;
			case FullBodyBipedEffector.LeftThigh:
				return ParteDelCuerpoHumano.piernas;
			case FullBodyBipedEffector.RightThigh:
				return ParteDelCuerpoHumano.piernas;
			case FullBodyBipedEffector.LeftHand:
				return ParteDelCuerpoHumano.manos;
			case FullBodyBipedEffector.RightHand:
				return ParteDelCuerpoHumano.manos;
			case FullBodyBipedEffector.LeftFoot:
				return ParteDelCuerpoHumano.pies;
			case FullBodyBipedEffector.RightFoot:
				return ParteDelCuerpoHumano.pies;
			default:
				throw new ArgumentOutOfRangeException(effector.ToString());
			}
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0001091C File Offset: 0x0000EB1C
		public static HumanBodyBones ParceAHumanBone(this FullBodyBipedEffector effector)
		{
			switch (effector)
			{
			case FullBodyBipedEffector.Body:
				return HumanBodyBones.Spine;
			case FullBodyBipedEffector.LeftShoulder:
				return HumanBodyBones.LeftUpperArm;
			case FullBodyBipedEffector.RightShoulder:
				return HumanBodyBones.RightUpperArm;
			case FullBodyBipedEffector.LeftThigh:
				return HumanBodyBones.LeftUpperLeg;
			case FullBodyBipedEffector.RightThigh:
				return HumanBodyBones.RightUpperLeg;
			case FullBodyBipedEffector.LeftHand:
				return HumanBodyBones.LeftHand;
			case FullBodyBipedEffector.RightHand:
				return HumanBodyBones.RightHand;
			case FullBodyBipedEffector.LeftFoot:
				return HumanBodyBones.LeftFoot;
			case FullBodyBipedEffector.RightFoot:
				return HumanBodyBones.RightFoot;
			default:
				throw new ArgumentOutOfRangeException(effector.ToString());
			}
		}
	}
}
