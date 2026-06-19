using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x0200007E RID: 126
	public class LocalDefaultEffectorOffset : TValleEffectorOffsetInteremedio
	{
		// Token: 0x060004F0 RID: 1264 RVA: 0x00017FC9 File Offset: 0x000161C9
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.defLocalRotation = base.transform.localRotation;
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x00017FE4 File Offset: 0x000161E4
		protected sealed override void ModifyOffset(FullBodyBipedIK ik)
		{
			Quaternion quaternion = base.transform.parent.rotation * this.defLocalRotation;
			if (this.usaBodyOffset)
			{
				base.SetOffset(ik.solver.bodyEffector, FullBodyBipedEffector.Body, quaternion * this.m_bodyOffset);
			}
			if (this.usaLeftShoulderOffset)
			{
				base.SetOffset(ik.solver.leftShoulderEffector, FullBodyBipedEffector.LeftShoulder, quaternion * this.m_leftShoulderOffset);
			}
			if (this.usaRightShoulderOffset)
			{
				base.SetOffset(ik.solver.rightShoulderEffector, FullBodyBipedEffector.RightShoulder, quaternion * this.m_rightShoulderOffset);
			}
			if (this.usaLeftThighOffset)
			{
				base.SetOffset(ik.solver.leftThighEffector, FullBodyBipedEffector.LeftThigh, quaternion * this.m_leftThighOffset);
			}
			if (this.usaRightThighOffset)
			{
				base.SetOffset(ik.solver.rightThighEffector, FullBodyBipedEffector.RightThigh, quaternion * this.m_rightThighOffset);
			}
			if (this.usaLeftHandOffset)
			{
				base.SetOffset(ik.solver.leftHandEffector, FullBodyBipedEffector.LeftHand, quaternion * this.m_leftHandOffset);
			}
			if (this.usaRightHandOffset)
			{
				base.SetOffset(ik.solver.rightHandEffector, FullBodyBipedEffector.RightHand, quaternion * this.m_rightHandOffset);
			}
			if (this.usaLeftFootOffset)
			{
				base.SetOffset(ik.solver.leftFootEffector, FullBodyBipedEffector.LeftFoot, quaternion * this.m_leftFootOffset);
			}
			if (this.usaRightFootOffset)
			{
				base.SetOffset(ik.solver.rightFootEffector, FullBodyBipedEffector.RightFoot, quaternion * this.m_rightFootOffset);
			}
		}

		// Token: 0x04000342 RID: 834
		private Quaternion defLocalRotation;
	}
}
