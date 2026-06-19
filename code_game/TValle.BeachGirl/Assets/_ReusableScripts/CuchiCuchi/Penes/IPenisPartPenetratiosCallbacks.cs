using System;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Penes
{
	// Token: 0x02000117 RID: 279
	public interface IPenisPartPenetratiosCallbacks
	{
		// Token: 0x06000C38 RID: 3128
		void OnHelperHit(RaycastHit hit, BoneStretchedChain hole, float largoDeRayo);

		// Token: 0x06000C39 RID: 3129
		void TryingEnter(Penetraciones.TryPenetrationArgs args, PenisPartHit hit, Penetraciones penetracionesChecker);

		// Token: 0x06000C3A RID: 3130
		void OnEnter(PenisPartHit hit, Penetraciones penetracionesChecker);

		// Token: 0x06000C3B RID: 3131
		void OnStay(PenisPartHit hit, Penetraciones penetracionesChecker);

		// Token: 0x06000C3C RID: 3132
		void OnExit(Penetraciones penetracionesChecker);
	}
}
