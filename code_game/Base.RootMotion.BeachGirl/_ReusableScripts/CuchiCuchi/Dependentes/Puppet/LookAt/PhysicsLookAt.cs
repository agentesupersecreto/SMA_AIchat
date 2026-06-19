using System;
using Assets.TValle.BeachGirl.Runtime.IK;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using InterfaceFields;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.LookAt
{
	// Token: 0x0200010B RID: 267
	public sealed class PhysicsLookAt : CustomMonobehaviour
	{
		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000A6C RID: 2668 RVA: 0x0002E89F File Offset: 0x0002CA9F
		private ILookAtIK lookAt
		{
			get
			{
				return this.m_lookAt as ILookAtIK;
			}
		}

		// Token: 0x140000A1 RID: 161
		// (add) Token: 0x06000A6D RID: 2669 RVA: 0x0002E8AC File Offset: 0x0002CAAC
		// (remove) Token: 0x06000A6E RID: 2670 RVA: 0x0002E8E4 File Offset: 0x0002CAE4
		public event Action<PhysicsLookAt> updating;

		// Token: 0x140000A2 RID: 162
		// (add) Token: 0x06000A6F RID: 2671 RVA: 0x0002E91C File Offset: 0x0002CB1C
		// (remove) Token: 0x06000A70 RID: 2672 RVA: 0x0002E954 File Offset: 0x0002CB54
		public event Action<PhysicsLookAt> updated;

		// Token: 0x06000A71 RID: 2673 RVA: 0x0002E98C File Offset: 0x0002CB8C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			ICharacter componentInParent = base.GetComponentInParent<ICharacter>();
			if (componentInParent == null)
			{
				throw new ArgumentNullException("@char", "@char null reference.");
			}
			this.m_updater = componentInParent.GetComponentInChildren<IPhysicsIKJustUpdater>();
			if (this.m_lookAt == null)
			{
				throw new ArgumentNullException("m_lookAt", "m_lookAt null reference.");
			}
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
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

		// Token: 0x06000A72 RID: 2674 RVA: 0x0002EA5B File Offset: 0x0002CC5B
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_PostPhysicsLookAtIK.Init(this.m_anim);
			this.m_postSuavizador.Add(this.m_PostPhysicsLookAtIK.head, 1f);
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x0002EA90 File Offset: 0x0002CC90
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (this.m_updater != null)
			{
				this.m_updater.physicsIKJustUpdated += this.M_updater_physicsIKUpdated;
				this.m_updater.physicsIKJustUpdating += this.M_updater_physicsIKUpdating;
			}
			if (this.m_PostPhysicsLookAtIK != null)
			{
				this.m_PostPhysicsLookAtIK.onPreSolve += this.OnPreSolve;
				this.m_PostPhysicsLookAtIK.onPostSolve += this.OnPostSolve;
			}
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x0002EB18 File Offset: 0x0002CD18
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_updater != null)
			{
				this.m_updater.physicsIKJustUpdated -= this.M_updater_physicsIKUpdated;
				this.m_updater.physicsIKJustUpdating -= this.M_updater_physicsIKUpdating;
			}
			if (this.m_PostPhysicsLookAtIK != null)
			{
				this.m_PostPhysicsLookAtIK.onPreSolve -= this.OnPreSolve;
				this.m_PostPhysicsLookAtIK.onPostSolve -= this.OnPostSolve;
			}
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x0002EB9E File Offset: 0x0002CD9E
		private void M_updater_physicsIKUpdating(IPhysicsIKJustUpdater obj)
		{
			Action<PhysicsLookAt> action = this.updating;
			if (action != null)
			{
				action(this);
			}
			this.headPhyscisStates.UpdatePreIKState();
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x0002EBC0 File Offset: 0x0002CDC0
		private void M_updater_physicsIKUpdated(IPhysicsIKJustUpdater obj)
		{
			this.headPhyscisStates.UpdatePostIKState();
			IKSolverLookAt solver = this.lookAt.mainLookAtIK.solver;
			float num = (this.config.usar ? solver.IKPositionWeight : 0f);
			Vector3 vector = Math3d.ProjectPointOnPlane(this.headPhyscisStates.postIK.up, this.headPhyscisStates.postIK.position, solver.IKPosition);
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
				this.m_PostPhysicsLookAtIK.clampWeightHead = solver.clampWeightHead * this.config.clampWeightHeadMod;
				this.m_PostPhysicsLookAtIK.clampSmoothing = solver.clampSmoothing;
				this.m_PostPhysicsLookAtIK.IKPositionWeight = Mathf.MoveTowards(this.m_PostPhysicsLookAtIK.IKPositionWeight, num, this.LookAtWeightChangeVelocity * Time.deltaTime);
				this.m_PostPhysicsLookAtIK.IKPosition = vector;
				this.m_PostPhysicsLookAtIK.Solve();
			}
			Action<PhysicsLookAt> action = this.updated;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x0002ED4C File Offset: 0x0002CF4C
		private void OnPreSolve(HeadLookAtSolver obj)
		{
			this.m_postSuavizador.OnPreIKUpdate();
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x0002ED59 File Offset: 0x0002CF59
		private void OnPostSolve(HeadLookAtSolver obj)
		{
			this.m_postSuavizador.OnPostIKUpdate();
		}

		// Token: 0x04000657 RID: 1623
		public bool debugDraw;

		// Token: 0x04000658 RID: 1624
		public PhysicsLookAt.Config config = new PhysicsLookAt.Config();

		// Token: 0x04000659 RID: 1625
		[SerializeField]
		[ConstraintType(typeof(ILookAtIK), required = true)]
		private Object m_lookAt;

		// Token: 0x0400065A RID: 1626
		private IPhysicsIKJustUpdater m_updater;

		// Token: 0x0400065B RID: 1627
		private HeadLookAtSolver m_PostPhysicsLookAtIK;

		// Token: 0x0400065C RID: 1628
		private PostSuavizadorDeRotacionesGenerico m_postSuavizador;

		// Token: 0x0400065D RID: 1629
		public EstadosDeBone headPhyscisStates = new EstadosDeBone();

		// Token: 0x0400065E RID: 1630
		private Animator m_anim;

		// Token: 0x0400065F RID: 1631
		public float LookAtWeightChangeVelocity = 0.5f;

		// Token: 0x020001D1 RID: 465
		[Serializable]
		public class Config
		{
			// Token: 0x040009F9 RID: 2553
			public bool usar = true;

			// Token: 0x040009FA RID: 2554
			public float clampWeightHeadMod = 1f;

			// Token: 0x040009FB RID: 2555
			public float minAngle = 2f;

			// Token: 0x040009FC RID: 2556
			public float maxAngle = 10f;
		}
	}
}
