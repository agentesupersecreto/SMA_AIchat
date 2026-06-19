using System;
using Assets.FinalIk;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000063 RID: 99
	public interface ILookAtHeadTargets
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600040E RID: 1038
		LookAtIKTargets.Targets primarios { get; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x0600040F RID: 1039
		LookAtIKTargets.Targets segundarios { get; }

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000410 RID: 1040
		LookAtTargetWieghtParCollection primariosCollection { get; }

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000411 RID: 1041
		LookAtTargetWieghtParCollection segundariosCollection { get; }
	}
}
