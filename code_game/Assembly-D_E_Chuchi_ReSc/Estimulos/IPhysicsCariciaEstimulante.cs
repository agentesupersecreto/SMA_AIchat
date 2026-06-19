using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos
{
	// Token: 0x0200029D RID: 669
	[Obsolete]
	public interface IPhysicsCariciaEstimulante : IInteraccionEstimulante
	{
		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06000EB8 RID: 3768
		List<Collider> colliders { get; }

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x06000EB9 RID: 3769
		List<Rigidbody> rigids { get; }

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x06000EBA RID: 3770
		float maxMaxRelativeVelocity { get; }

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x06000EBB RID: 3771
		float maxTotalRelativeVelocity { get; }

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06000EBC RID: 3772
		float maxMaxImpulse { get; }

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06000EBD RID: 3773
		float maxTotalImpulse { get; }

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000EBE RID: 3774
		float maxMaxEmulatedRelativeStepVelocity { get; }

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000EBF RID: 3775
		float maxTotalEmulatedRelativeStepVelocity { get; }
	}
}
