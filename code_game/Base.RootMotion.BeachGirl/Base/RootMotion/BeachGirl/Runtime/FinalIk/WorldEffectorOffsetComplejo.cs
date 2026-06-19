using System;
using RootMotion.FinalIK;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk
{
	// Token: 0x02000021 RID: 33
	public class WorldEffectorOffsetComplejo : TValleEffectorForcedOffset
	{
		// Token: 0x06000112 RID: 274 RVA: 0x00007430 File Offset: 0x00005630
		protected sealed override void ModifyOffset(FullBodyBipedIK ik)
		{
			TValleEffectorForcer tvalleEffectorForcer = base.ObtenerForcer(ik);
			if (this.usaBodyOffset)
			{
				base.SetOffset(tvalleEffectorForcer, ref tvalleEffectorForcer.bodyOffset, ref tvalleEffectorForcer.bodyOffsetWeight, ik.solver.bodyEffector, FullBodyBipedEffector.Body, this.m_bodyOffset, this.bodyOverridenWeight);
			}
			if (this.usaLeftShoulderOffset)
			{
				base.SetOffset(tvalleEffectorForcer, ref tvalleEffectorForcer.leftShoulderOffset, ref tvalleEffectorForcer.leftShoulderOffsetWeight, ik.solver.leftShoulderEffector, FullBodyBipedEffector.LeftShoulder, this.m_leftShoulderOffset, this.leftShoulderOverridenWeight);
			}
			if (this.usaRightShoulderOffset)
			{
				base.SetOffset(tvalleEffectorForcer, ref tvalleEffectorForcer.rightShoulderOffset, ref tvalleEffectorForcer.rightShoulderOffsetWeight, ik.solver.rightShoulderEffector, FullBodyBipedEffector.RightShoulder, this.m_rightShoulderOffset, this.rightShoulderOverridenWeight);
			}
			if (this.usaLeftThighOffset)
			{
				base.SetOffset(tvalleEffectorForcer, ref tvalleEffectorForcer.leftThighOffset, ref tvalleEffectorForcer.leftThighOffsetWeight, ik.solver.leftThighEffector, FullBodyBipedEffector.LeftThigh, this.m_leftThighOffset, this.leftThighOverridenWeight);
			}
			if (this.usaRightThighOffset)
			{
				base.SetOffset(tvalleEffectorForcer, ref tvalleEffectorForcer.rightThighOffset, ref tvalleEffectorForcer.rightThighOffsetWeight, ik.solver.rightThighEffector, FullBodyBipedEffector.RightThigh, this.m_rightThighOffset, this.rightThighOverridenWeight);
			}
			if (this.usaLeftHandOffset)
			{
				base.SetOffset(tvalleEffectorForcer, ref tvalleEffectorForcer.leftHandOffset, ref tvalleEffectorForcer.leftHandOffsetWeight, ik.solver.leftHandEffector, FullBodyBipedEffector.LeftHand, this.m_leftHandOffset, this.leftHandOverridenWeight);
			}
			if (this.usaRightHandOffset)
			{
				base.SetOffset(tvalleEffectorForcer, ref tvalleEffectorForcer.rightHandOffset, ref tvalleEffectorForcer.rightHandOffsetWeight, ik.solver.rightHandEffector, FullBodyBipedEffector.RightHand, this.m_rightHandOffset, this.rightHandOverridenWeight);
			}
			if (this.usaLeftFootOffset)
			{
				base.SetOffset(tvalleEffectorForcer, ref tvalleEffectorForcer.leftFootOffset, ref tvalleEffectorForcer.leftFootOffsetWeight, ik.solver.leftFootEffector, FullBodyBipedEffector.LeftFoot, this.m_leftFootOffset, this.leftFootOverridenWeight);
			}
			if (this.usaRightFootOffset)
			{
				base.SetOffset(tvalleEffectorForcer, ref tvalleEffectorForcer.rightFootOffset, ref tvalleEffectorForcer.rightFootOffsetWeight, ik.solver.rightFootEffector, FullBodyBipedEffector.RightFoot, this.m_rightFootOffset, this.rightFootOverridenWeight);
			}
		}
	}
}
