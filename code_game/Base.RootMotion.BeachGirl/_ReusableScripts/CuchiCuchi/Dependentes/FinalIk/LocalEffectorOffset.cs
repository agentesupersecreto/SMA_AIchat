using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x0200007F RID: 127
	public class LocalEffectorOffset : TValleEffectorOffsetInteremedio
	{
		// Token: 0x060004F3 RID: 1267 RVA: 0x0001816C File Offset: 0x0001636C
		protected sealed override void ModifyOffset(FullBodyBipedIK ik)
		{
			Quaternion rotation = base.transform.rotation;
			if (this.usaBodyOffset)
			{
				base.SetOffset(ik.solver.bodyEffector, FullBodyBipedEffector.Body, rotation * this.m_bodyOffset);
			}
			if (this.usaLeftShoulderOffset)
			{
				base.SetOffset(ik.solver.leftShoulderEffector, FullBodyBipedEffector.LeftShoulder, rotation * this.m_leftShoulderOffset);
			}
			if (this.usaRightShoulderOffset)
			{
				base.SetOffset(ik.solver.rightShoulderEffector, FullBodyBipedEffector.RightShoulder, rotation * this.m_rightShoulderOffset);
			}
			if (this.usaLeftThighOffset)
			{
				base.SetOffset(ik.solver.leftThighEffector, FullBodyBipedEffector.LeftThigh, rotation * this.m_leftThighOffset);
			}
			if (this.usaRightThighOffset)
			{
				base.SetOffset(ik.solver.rightThighEffector, FullBodyBipedEffector.RightThigh, rotation * this.m_rightThighOffset);
			}
			if (this.usaLeftHandOffset)
			{
				base.SetOffset(ik.solver.leftHandEffector, FullBodyBipedEffector.LeftHand, rotation * this.m_leftHandOffset);
			}
			if (this.usaRightHandOffset)
			{
				base.SetOffset(ik.solver.rightHandEffector, FullBodyBipedEffector.RightHand, rotation * this.m_rightHandOffset);
			}
			if (this.usaLeftFootOffset)
			{
				base.SetOffset(ik.solver.leftFootEffector, FullBodyBipedEffector.LeftFoot, rotation * this.m_leftFootOffset);
			}
			if (this.usaRightFootOffset)
			{
				base.SetOffset(ik.solver.rightFootEffector, FullBodyBipedEffector.RightFoot, rotation * this.m_rightFootOffset);
			}
		}
	}
}
