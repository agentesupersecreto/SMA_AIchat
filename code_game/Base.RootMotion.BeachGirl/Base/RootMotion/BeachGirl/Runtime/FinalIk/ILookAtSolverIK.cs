using System;
using Assets.TValle.BeachGirl.Runtime;
using RootMotion.FinalIK;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk
{
	// Token: 0x02000018 RID: 24
	public interface ILookAtSolverIK : ILookAt, IComponentStartable
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000C9 RID: 201
		LookAtIK mainLookAtIK { get; }
	}
}
