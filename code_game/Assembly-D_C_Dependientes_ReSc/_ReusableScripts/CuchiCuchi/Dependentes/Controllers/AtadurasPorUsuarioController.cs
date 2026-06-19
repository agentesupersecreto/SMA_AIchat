using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using RootMotion.FinalIK;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers
{
	// Token: 0x0200019A RID: 410
	public class AtadurasPorUsuarioController : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x060009A7 RID: 2471 RVA: 0x0002FB7C File Offset: 0x0002DD7C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_IIKUpdater = this.GetComponentEnRoot(false);
			if (this.m_IIKUpdater == null)
			{
				throw new ArgumentNullException("m_IIKUpdater", "m_IIKUpdater null reference.");
			}
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0002FBAC File Offset: 0x0002DDAC
		public bool EstaAtado(FullBodyBipedEffector effectorEnum)
		{
			IUserFullBodyBipedIK iikupdater = this.m_IIKUpdater;
			IKEffector ikeffector;
			if (iikupdater == null)
			{
				ikeffector = null;
			}
			else
			{
				FullBodyBipedIK ik = iikupdater.IK;
				if (ik == null)
				{
					ikeffector = null;
				}
				else
				{
					IKSolverFullBodyBiped solver = ik.solver;
					ikeffector = ((solver != null) ? solver.GetEffector(effectorEnum) : null);
				}
			}
			IKEffector ikeffector2 = ikeffector;
			return ikeffector2 != null && this.m_IIKUpdater.IK.solver.IKPositionWeight > 0f && (ikeffector2.positionWeight > 0f || ikeffector2.rotationWeight > 0f);
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x0002FC24 File Offset: 0x0002DE24
		public bool EstanTodosAtados()
		{
			IReadOnlyList<int> enumValoresInt = typeof(FullBodyBipedEffector).GetEnumValoresInt();
			for (int i = 0; i < enumValoresInt.Count; i++)
			{
				if (!this.EstaAtado((FullBodyBipedEffector)enumValoresInt[i]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04000741 RID: 1857
		private IUserFullBodyBipedIK m_IIKUpdater;
	}
}
