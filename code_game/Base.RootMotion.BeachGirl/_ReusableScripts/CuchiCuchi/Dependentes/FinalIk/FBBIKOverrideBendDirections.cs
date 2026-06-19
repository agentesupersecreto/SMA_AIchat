using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000071 RID: 113
	public class FBBIKOverrideBendDirections : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x0600044D RID: 1101 RVA: 0x00014728 File Offset: 0x00012928
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ik = base.GetComponentInChildren<IUserFullBodyBipedIK>().IK;
			if (this.m_ik == null)
			{
				throw new ArgumentNullException("m_ik", "m_ik null reference.");
			}
			this.m_animator = base.GetComponentInChildren<Animator>();
			if (this.m_animator == null)
			{
				throw new ArgumentNullException("m_animator", "m_animator null reference.");
			}
			if (this.m_ik.solver.initiated)
			{
				this.canillaR.Initiate(this.m_animator, HumanBodyBones.RightUpperLeg, HumanBodyBones.RightLowerLeg);
				this.canillaL.Initiate(this.m_animator, HumanBodyBones.LeftUpperLeg, HumanBodyBones.LeftLowerLeg);
				this.OnPostInitiate();
				return;
			}
			IKSolverFullBodyBiped solver = this.m_ik.solver;
			solver.OnPostInitiate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPostInitiate, new IKSolver.UpdateDelegate(this.OnPostInitiate));
			this.canillaR.Initiate(this.m_animator, HumanBodyBones.RightUpperLeg, HumanBodyBones.RightLowerLeg);
			this.canillaL.Initiate(this.m_animator, HumanBodyBones.LeftUpperLeg, HumanBodyBones.LeftLowerLeg);
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00014828 File Offset: 0x00012A28
		private void OnPostInitiate()
		{
			IKSolverFullBodyBiped solver = this.m_ik.solver;
			solver.OnPostInitiate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPostInitiate, new IKSolver.UpdateDelegate(this.OnPostInitiate));
			FBIKChain chain = this.m_ik.solver.GetChain(FullBodyBipedChain.RightLeg);
			FBIKChain chain2 = this.m_ik.solver.GetChain(FullBodyBipedChain.LeftLeg);
			IKConstraintBend bendConstraint = chain.bendConstraint;
			IKConstraintBend bendConstraint2 = chain2.bendConstraint;
			this.SetBendDirection(this.canillaR, bendConstraint);
			this.SetBendDirection(this.canillaL, bendConstraint2);
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x000148AC File Offset: 0x00012AAC
		private void SetBendDirection(FBBIKOverrideBendDirections.Point punto, IKConstraintBend constraint)
		{
			bool flag = this.debugDraw;
			Vector3 vector = punto.initialB2Rotation * punto.localAxis.normalized;
			Vector3 vector2 = Quaternion.Inverse(constraint.bone1.rotation) * vector;
			constraint.direction = vector;
			constraint.defaultLocalDirection = vector2;
			Vector3 vector3 = Vector3.Cross((constraint.bone3.position - constraint.bone1.position).normalized, vector);
			constraint.defaultChildDirection = Quaternion.Inverse(constraint.bone3.rotation) * vector3;
			bool flag2 = this.debugDraw;
		}

		// Token: 0x040002D9 RID: 729
		public FBBIKOverrideBendDirections.Point canillaR;

		// Token: 0x040002DA RID: 730
		public FBBIKOverrideBendDirections.Point canillaL;

		// Token: 0x040002DB RID: 731
		private FullBodyBipedIK m_ik;

		// Token: 0x040002DC RID: 732
		private Animator m_animator;

		// Token: 0x040002DD RID: 733
		public bool debugDraw;

		// Token: 0x02000164 RID: 356
		[Serializable]
		public class Point
		{
			// Token: 0x06000BAD RID: 2989 RVA: 0x000352F4 File Offset: 0x000334F4
			public void Initiate(Animator anim, HumanBodyBones bone1, HumanBodyBones bone2)
			{
				Transform boneTransform = anim.GetBoneTransform(bone1);
				Transform boneTransform2 = anim.GetBoneTransform(bone2);
				this.initialB1Rotation = boneTransform.rotation;
				this.initialB2Rotation = boneTransform2.rotation;
			}

			// Token: 0x04000805 RID: 2053
			[Tooltip("el axis local al bone 2(canilla,antebraxo ETC) q se va a usar como bendDirection")]
			public Vector3 localAxis;

			// Token: 0x04000806 RID: 2054
			[NonSerialized]
			public Quaternion initialB1Rotation;

			// Token: 0x04000807 RID: 2055
			[NonSerialized]
			public Quaternion initialB2Rotation;
		}
	}
}
