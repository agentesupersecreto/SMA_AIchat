using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.ControllerPoses.SubStates
{
	// Token: 0x02000219 RID: 537
	public class RecostadaTracker : StateMachineBehaviour
	{
		// Token: 0x06000DA2 RID: 3490 RVA: 0x0003D263 File Offset: 0x0003B463
		public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
		{
			animator.SetBool(FemaleAnimController.FemaleAnimatorVariables.Recostada, true);
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x0003D271 File Offset: 0x0003B471
		public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
		{
			animator.SetBool(FemaleAnimController.FemaleAnimatorVariables.Recostada, false);
		}
	}
}
