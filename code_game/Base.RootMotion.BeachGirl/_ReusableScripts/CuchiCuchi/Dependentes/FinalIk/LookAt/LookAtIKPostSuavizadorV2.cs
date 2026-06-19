using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.LookAt
{
	// Token: 0x0200008E RID: 142
	[RequireComponent(typeof(LookAtIK))]
	public sealed class LookAtIKPostSuavizadorV2 : PostSuavizadorDeRotacionesGenerico
	{
		// Token: 0x0600058E RID: 1422 RVA: 0x0001BF74 File Offset: 0x0001A174
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_LookAtIK = base.GetComponent<LookAtIK>();
			if (this.m_LookAtIK.solver.initiated)
			{
				this.Initiate();
				return;
			}
			IKSolverLookAt solver = this.m_LookAtIK.solver;
			solver.OnPostInitiate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPostInitiate, new IKSolver.UpdateDelegate(this.Initiate));
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x0001BFD8 File Offset: 0x0001A1D8
		private void Initiate()
		{
			IKSolverLookAt solver = this.m_LookAtIK.solver;
			solver.OnPostInitiate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPostInitiate, new IKSolver.UpdateDelegate(this.Initiate));
			foreach (IKSolverLookAt.LookAtBone lookAtBone in this.m_LookAtIK.solver.spine)
			{
				base.Add(lookAtBone.transform, 1f);
			}
			if (this.m_LookAtIK.solver.headWeight > 0f)
			{
				base.Add(this.m_LookAtIK.solver.head.transform, 1f);
			}
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x0001C080 File Offset: 0x0001A280
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			IKSolverLookAt solver = this.m_LookAtIK.solver;
			solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.M_updater_updating));
			IKSolverLookAt solver2 = this.m_LookAtIK.solver;
			solver2.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver2.OnPostUpdate, new IKSolver.UpdateDelegate(this.M_updater_updated));
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x0001C0EC File Offset: 0x0001A2EC
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			LookAtIK lookAtIK = this.m_LookAtIK;
			if (((lookAtIK != null) ? lookAtIK.solver : null) != null)
			{
				IKSolverLookAt solver = this.m_LookAtIK.solver;
				solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.M_updater_updating));
				IKSolverLookAt solver2 = this.m_LookAtIK.solver;
				solver2.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver2.OnPostUpdate, new IKSolver.UpdateDelegate(this.M_updater_updated));
			}
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0001C16C File Offset: 0x0001A36C
		private static float IkStep(int i, int spineLength)
		{
			return 1f / (float)(spineLength - 1) * (float)i;
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x0001C17C File Offset: 0x0001A37C
		private void M_updater_updating()
		{
			int num = this.m_LookAtIK.solver.spine.Length;
			for (int i = 0; i < num; i++)
			{
				Transform transform = this.m_LookAtIK.solver.spine[i].transform;
				float num2 = this.spineWeight;
				if (this.autoSpineWeight)
				{
					float num3 = this.m_LookAtIK.solver.spineWeightCurve.Evaluate(LookAtIKPostSuavizadorV2.IkStep(i, num));
					num2 *= Mathf.Lerp(1f, num3, this.autoSpineWeightMod);
				}
				this.m_TargetDeTrans[transform].weight = num2;
			}
			base.OnPreIKUpdate();
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x0001C21A File Offset: 0x0001A41A
		private void M_updater_updated()
		{
			base.OnPostIKUpdate();
		}

		// Token: 0x040003D3 RID: 979
		private LookAtIK m_LookAtIK;

		// Token: 0x040003D4 RID: 980
		public bool autoSpineWeight = true;

		// Token: 0x040003D5 RID: 981
		[Range(0f, 1f)]
		public float autoSpineWeightMod = 0.75f;

		// Token: 0x040003D6 RID: 982
		[Range(0f, 10f)]
		public float spineWeight = 1f;
	}
}
