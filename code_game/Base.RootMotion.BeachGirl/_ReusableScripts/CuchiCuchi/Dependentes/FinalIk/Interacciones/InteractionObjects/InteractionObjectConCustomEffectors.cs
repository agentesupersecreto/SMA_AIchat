using System;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.InteractionObjects
{
	// Token: 0x020000AE RID: 174
	public sealed class InteractionObjectConCustomEffectors : InteractionObjectV2Base
	{
		// Token: 0x060006B3 RID: 1715 RVA: 0x000209E8 File Offset: 0x0001EBE8
		public override void Applyed(IKSolverFullBodyBiped solver, InteractionEffector interactionEffector, FullBodyBipedEffector effector, InteractionTarget target, float timer, float weight, bool stoped)
		{
			try
			{
				base.ApplyCustomTargets(solver, timer, weight, this.customCurvas, stoped);
				base.ApplyDefaultTypeMultiV2(solver, timer, weight, this.multiplicadores, stoped);
				base.ApplyCustomTypeMulti(solver, timer, weight, this.multiplicadoresDeCustomCurvas, this.customCurvas, stoped);
			}
			finally
			{
				base.Applyed(solver, interactionEffector, effector, target, timer, weight, stoped);
			}
		}

		// Token: 0x0400048A RID: 1162
		[Header("CustomEffectors Configs")]
		public List<InteractionObjectV2Base.MultiplicadorNormal> multiplicadores = new List<InteractionObjectV2Base.MultiplicadorNormal>();

		// Token: 0x0400048B RID: 1163
		public List<InteractionObjectV2Base.CurvaForCustomEffector> customCurvas = new List<InteractionObjectV2Base.CurvaForCustomEffector>();

		// Token: 0x0400048C RID: 1164
		public List<InteractionObjectV2Base.MultiplicadorCustom> multiplicadoresDeCustomCurvas = new List<InteractionObjectV2Base.MultiplicadorCustom>();
	}
}
