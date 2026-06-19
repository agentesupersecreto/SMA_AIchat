using System;
using RootMotion.FinalIK;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk
{
	// Token: 0x02000020 RID: 32
	public class WorldEffectorOffset : TValleEffectorOffsetInteremedio
	{
		// Token: 0x06000110 RID: 272 RVA: 0x000072F8 File Offset: 0x000054F8
		protected sealed override void ModifyOffset(FullBodyBipedIK ik)
		{
			if (this.usaBodyOffset)
			{
				base.SetOffset(ik.solver.bodyEffector, FullBodyBipedEffector.Body, this.m_bodyOffset);
			}
			if (this.usaLeftShoulderOffset)
			{
				base.SetOffset(ik.solver.leftShoulderEffector, FullBodyBipedEffector.LeftShoulder, this.m_leftShoulderOffset);
			}
			if (this.usaRightShoulderOffset)
			{
				base.SetOffset(ik.solver.rightShoulderEffector, FullBodyBipedEffector.RightShoulder, this.m_rightShoulderOffset);
			}
			if (this.usaLeftThighOffset)
			{
				base.SetOffset(ik.solver.leftThighEffector, FullBodyBipedEffector.LeftThigh, this.m_leftThighOffset);
			}
			if (this.usaRightThighOffset)
			{
				base.SetOffset(ik.solver.rightThighEffector, FullBodyBipedEffector.RightThigh, this.m_rightThighOffset);
			}
			if (this.usaLeftHandOffset)
			{
				base.SetOffset(ik.solver.leftHandEffector, FullBodyBipedEffector.LeftHand, this.m_leftHandOffset);
			}
			if (this.usaRightHandOffset)
			{
				base.SetOffset(ik.solver.rightHandEffector, FullBodyBipedEffector.RightHand, this.m_rightHandOffset);
			}
			if (this.usaLeftFootOffset)
			{
				base.SetOffset(ik.solver.leftFootEffector, FullBodyBipedEffector.LeftFoot, this.m_leftFootOffset);
			}
			if (this.usaRightFootOffset)
			{
				base.SetOffset(ik.solver.rightFootEffector, FullBodyBipedEffector.RightFoot, this.m_rightFootOffset);
			}
		}
	}
}
