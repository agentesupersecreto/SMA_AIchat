using System;
using RootMotion;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Poses
{
	// Token: 0x0200008C RID: 140
	public abstract class PoserDeInterSys : SolverManager
	{
		// Token: 0x06000579 RID: 1401
		public abstract void AutoMapping();

		// Token: 0x0600057A RID: 1402
		protected abstract void InitiatePoser();

		// Token: 0x0600057B RID: 1403
		protected abstract void UpdatePoser();

		// Token: 0x0600057C RID: 1404
		protected abstract void FixPoserTransforms();

		// Token: 0x0600057D RID: 1405 RVA: 0x0001BA55 File Offset: 0x00019C55
		private void OnDestroy()
		{
			this.Unsubscribe();
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0001BA60 File Offset: 0x00019C60
		private void Subscribe()
		{
			if (this.m_currentIK != null)
			{
				IKSolverFullBodyBiped solver = this.m_currentIK.solver;
				solver.OnPostSolve = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPostSolve, new IKSolver.UpdateDelegate(this.OnIKPostSolve));
				IKSolverFullBodyBiped solver2 = this.m_currentIK.solver;
				solver2.OnFixTransforms = (IKSolver.UpdateDelegate)Delegate.Combine(solver2.OnFixTransforms, new IKSolver.UpdateDelegate(this.OnIKFixTransforms));
			}
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0001BAD4 File Offset: 0x00019CD4
		private void Unsubscribe()
		{
			if (this.m_currentIK != null)
			{
				IKSolverFullBodyBiped solver = this.m_currentIK.solver;
				solver.OnPostSolve = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPostSolve, new IKSolver.UpdateDelegate(this.OnIKPostSolve));
				IKSolverFullBodyBiped solver2 = this.m_currentIK.solver;
				solver2.OnFixTransforms = (IKSolver.UpdateDelegate)Delegate.Remove(solver2.OnFixTransforms, new IKSolver.UpdateDelegate(this.OnIKFixTransforms));
			}
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x0001BB47 File Offset: 0x00019D47
		private void OnIKPostSolve()
		{
			this.UpdateSolver();
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0001BB4F File Offset: 0x00019D4F
		private void OnIKFixTransforms()
		{
			this.FixTransforms();
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0001BB57 File Offset: 0x00019D57
		protected override void UpdateSolver()
		{
			base.enabled = false;
			if (!this.initiated)
			{
				this.InitiateSolver();
			}
			if (!this.initiated)
			{
				return;
			}
			this.UpdateSystem();
			this.UpdatePoser();
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0001BB84 File Offset: 0x00019D84
		public void UpdateSystem()
		{
			if (this.system != this.m_currentSystem)
			{
				base.enabled = false;
				this.Unsubscribe();
				this.m_currentSystem = this.system;
				InteractionSystem interactionSystem = this.system;
				this.m_currentIK = ((interactionSystem != null) ? interactionSystem.ik : null);
				this.Subscribe();
				return;
			}
			InteractionSystem currentSystem = this.m_currentSystem;
			if (((currentSystem != null) ? currentSystem.ik : null) != this.m_currentIK)
			{
				base.enabled = false;
				this.Unsubscribe();
				InteractionSystem currentSystem2 = this.m_currentSystem;
				this.m_currentIK = ((currentSystem2 != null) ? currentSystem2.ik : null);
				this.Subscribe();
				return;
			}
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x0001BC27 File Offset: 0x00019E27
		protected override void InitiateSolver()
		{
			if (this.initiated)
			{
				return;
			}
			this.InitiatePoser();
			this.initiated = true;
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x0001BC3F File Offset: 0x00019E3F
		protected override void FixTransforms()
		{
			if (!this.initiated)
			{
				return;
			}
			this.FixPoserTransforms();
		}

		// Token: 0x040003C6 RID: 966
		public InteractionSystem system;

		// Token: 0x040003C7 RID: 967
		private InteractionSystem m_currentSystem;

		// Token: 0x040003C8 RID: 968
		private FullBodyBipedIK m_currentIK;

		// Token: 0x040003C9 RID: 969
		public Transform poseRoot;

		// Token: 0x040003CA RID: 970
		[Range(0f, 1f)]
		public float weight;

		// Token: 0x040003CB RID: 971
		[Range(0f, 1f)]
		public float localRotationWeight = 1f;

		// Token: 0x040003CC RID: 972
		[Range(0f, 1f)]
		public float localPositionWeight;

		// Token: 0x040003CD RID: 973
		private bool initiated;
	}
}
