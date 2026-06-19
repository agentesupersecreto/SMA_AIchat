using System;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;

namespace Assets._ReusableScripts.CuchiCuchi.Penes
{
	// Token: 0x02000119 RID: 281
	public interface IPenisPenetratiosCallbacks
	{
		// Token: 0x06000C3D RID: 3133
		void TryingEnter(Penetraciones.TryPenetrationArgs args, Penetraciones penetracionesChecker);

		// Token: 0x06000C3E RID: 3134
		void OnEnter(Penetraciones penetracionesChecker);

		// Token: 0x06000C3F RID: 3135
		void OnStay(Penetraciones penetracionesChecker);

		// Token: 0x06000C40 RID: 3136
		void OnExit(Penetraciones penetracionesChecker);
	}
}
