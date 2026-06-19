using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk;
using Assets.TValle.BeachGirl.Runtime.IK;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.LookAt;
using InterfaceFields;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.OralAt
{
	// Token: 0x0200010A RID: 266
	public sealed class PhysicsOralAt : CustomMonobehaviour
	{
		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000A5E RID: 2654 RVA: 0x0002E394 File Offset: 0x0002C594
		private ILookAtSolverIK lookAt
		{
			get
			{
				return this.m_lookAt as ILookAtSolverIK;
			}
		}

		// Token: 0x1400009F RID: 159
		// (add) Token: 0x06000A5F RID: 2655 RVA: 0x0002E3A4 File Offset: 0x0002C5A4
		// (remove) Token: 0x06000A60 RID: 2656 RVA: 0x0002E3DC File Offset: 0x0002C5DC
		public event Action<PhysicsOralAt> postUpdating;

		// Token: 0x140000A0 RID: 160
		// (add) Token: 0x06000A61 RID: 2657 RVA: 0x0002E414 File Offset: 0x0002C614
		// (remove) Token: 0x06000A62 RID: 2658 RVA: 0x0002E44C File Offset: 0x0002C64C
		public event Action<PhysicsOralAt> updated;

		// Token: 0x06000A63 RID: 2659 RVA: 0x0002E484 File Offset: 0x0002C684
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			ICharacter componentInParent = base.GetComponentInParent<ICharacter>();
			if (componentInParent == null)
			{
				throw new ArgumentNullException("@char", "@char null reference.");
			}
			if (this.m_lookAt == null)
			{
				throw new ArgumentNullException("m_lookAt", "m_lookAt null reference.");
			}
			this.m_PhysicsLookAt = componentInParent.GetComponentInChildren<PhysicsLookAt>();
			if (this.m_PhysicsLookAt == null)
			{
				throw new ArgumentNullException("m_PhysicsLookAt", "m_PhysicsLookAt null reference.");
			}
			this.m_PostPhysicsLookAtIK = this.GetComponentNotNull<HeadLookAtSolver>();
			this.m_postSuavizador = this.GetComponentNotNull<PostSuavizadorDeRotacionesGenerico>();
			this.m_anim = componentInParent.bodyAnimator;
			if (this.m_anim == null)
			{
				throw new ArgumentNullException("m_anim", "m_anim null reference.");
			}
			this.headPhyscisStates.Init(this.m_anim.GetBoneTransform(HumanBodyBones.Head), this.m_anim);
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x0002E559 File Offset: 0x0002C759
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_PostPhysicsLookAtIK.Init(this.m_anim);
			this.m_postSuavizador.Add(this.m_PostPhysicsLookAtIK.head, 1f);
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x0002E590 File Offset: 0x0002C790
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (this.m_PhysicsLookAt != null)
			{
				this.m_PhysicsLookAt.updating += this.M_otherPhysicsLookAt_updating;
				this.m_PhysicsLookAt.updated += this.M_otherPhysicsLookAt_updated;
			}
			if (this.m_PostPhysicsLookAtIK != null)
			{
				this.m_PostPhysicsLookAtIK.onPreSolve += this.OnPreSolve;
				this.m_PostPhysicsLookAtIK.onPostSolve += this.OnPostSolve;
			}
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x0002E61C File Offset: 0x0002C81C
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_PhysicsLookAt != null)
			{
				this.m_PhysicsLookAt.updating -= this.M_otherPhysicsLookAt_updating;
				this.m_PhysicsLookAt.updated -= this.M_otherPhysicsLookAt_updated;
			}
			if (this.m_PostPhysicsLookAtIK != null)
			{
				this.m_PostPhysicsLookAtIK.onPreSolve -= this.OnPreSolve;
				this.m_PostPhysicsLookAtIK.onPostSolve -= this.OnPostSolve;
			}
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x0002E6A8 File Offset: 0x0002C8A8
		private void M_otherPhysicsLookAt_updating(PhysicsLookAt obj)
		{
			this.headPhyscisStates.UpdatePreIKState();
			Action<PhysicsOralAt> action = this.postUpdating;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x0002E6C8 File Offset: 0x0002C8C8
		private void M_otherPhysicsLookAt_updated(PhysicsLookAt obj)
		{
			this.headPhyscisStates.UpdatePostIKState();
			IKSolverLookAt solver = this.lookAt.mainLookAtIK.solver;
			float num = (this.config.usar ? solver.IKPositionWeight : 0f);
			Vector3 vector = Math3d.ProjectPointOnPlane(this.headPhyscisStates.postIK.up, this.headPhyscisStates.postIK.position, this.headPhyscisStates.preIK.forwardPoint);
			try
			{
				if (!this.config.usar || solver.IKPositionWeight == 0f)
				{
					return;
				}
				float num2 = Vector3.Angle(this.headPhyscisStates.preIK.forward, this.headPhyscisStates.postIK.forward);
				bool flag = this.debugDraw;
				float num3 = Mathf.InverseLerp(this.config.minAngle, this.config.maxAngle, num2).InPow(2f);
				num *= num3;
			}
			finally
			{
				this.m_PostPhysicsLookAtIK.headWeight = solver.headWeight;
				this.m_PostPhysicsLookAtIK.clampWeightHead = Mathf.Clamp01(this.config.clampWeightHead);
				this.m_PostPhysicsLookAtIK.clampSmoothing = solver.clampSmoothing;
				this.m_PostPhysicsLookAtIK.IKPositionWeight = Mathf.MoveTowards(this.m_PostPhysicsLookAtIK.IKPositionWeight, num, this.LookAtWeightChangeVelocity * Time.deltaTime);
				this.m_PostPhysicsLookAtIK.IKPosition = vector;
				this.m_PostPhysicsLookAtIK.Solve();
			}
			Action<PhysicsOralAt> action = this.updated;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x0002E85C File Offset: 0x0002CA5C
		private void OnPreSolve(HeadLookAtSolver obj)
		{
			this.m_postSuavizador.OnPreIKUpdate();
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x0002E869 File Offset: 0x0002CA69
		private void OnPostSolve(HeadLookAtSolver obj)
		{
			this.m_postSuavizador.OnPostIKUpdate();
		}

		// Token: 0x0400064C RID: 1612
		public bool debugDraw;

		// Token: 0x0400064D RID: 1613
		public PhysicsOralAt.Config config = new PhysicsOralAt.Config();

		// Token: 0x0400064E RID: 1614
		[SerializeField]
		[ConstraintType(typeof(ILookAtSolverIK), required = true)]
		private Object m_lookAt;

		// Token: 0x0400064F RID: 1615
		private PhysicsLookAt m_PhysicsLookAt;

		// Token: 0x04000650 RID: 1616
		private HeadLookAtSolver m_PostPhysicsLookAtIK;

		// Token: 0x04000651 RID: 1617
		private PostSuavizadorDeRotacionesGenerico m_postSuavizador;

		// Token: 0x04000652 RID: 1618
		public EstadosDeBone headPhyscisStates = new EstadosDeBone();

		// Token: 0x04000653 RID: 1619
		private Animator m_anim;

		// Token: 0x04000654 RID: 1620
		public float LookAtWeightChangeVelocity = 1f;

		// Token: 0x020001D0 RID: 464
		[Serializable]
		public class Config
		{
			// Token: 0x040009F5 RID: 2549
			public bool usar = true;

			// Token: 0x040009F6 RID: 2550
			[Range(0f, 1f)]
			public float clampWeightHead = 0.5f;

			// Token: 0x040009F7 RID: 2551
			public float minAngle = 0.2f;

			// Token: 0x040009F8 RID: 2552
			public float maxAngle = 3f;
		}
	}
}
