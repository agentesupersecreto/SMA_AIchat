using System;
using Assets.FinalIk;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000067 RID: 103
	public interface ILookAtOjosTargets
	{
		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600042D RID: 1069
		LookAtIKTargets.Targets primarios { get; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x0600042E RID: 1070
		LookAtIKTargets.Targets segundarios { get; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x0600042F RID: 1071
		LookAtTargetWieghtParCollection primariosCollection { get; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000430 RID: 1072
		LookAtTargetWieghtParCollection segundariosCollection { get; }
	}
}
