using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using RootMotion.FinalIK;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000E5 RID: 229
	public interface IInteractionObjectPar
	{
		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000860 RID: 2144
		bool activado { get; }

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000861 RID: 2145
		InteractionObjectV2Base interactionObject { get; }

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000862 RID: 2146
		FullBodyBipedEffector effector { get; }

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000863 RID: 2147
		bool fijaPorAnimacion { get; }

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000864 RID: 2148
		bool puedeTrasladarse { get; }

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000865 RID: 2149
		bool puedeApoyarse { get; }

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000866 RID: 2150
		bool puedeApoyarseExtencion { get; }
	}
}
