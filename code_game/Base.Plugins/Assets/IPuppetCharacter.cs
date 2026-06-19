using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000B9 RID: 185
	public interface IPuppetCharacter : ICharacter, ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable
	{
		// Token: 0x06000595 RID: 1429
		float TryGetMuscleMass(HumanBodyBones humanBone, float defaultValue);

		// Token: 0x06000596 RID: 1430
		void GetCollidersHead(List<Collider> result);

		// Token: 0x06000597 RID: 1431
		void GetCollidersBrazoL(List<Collider> result);

		// Token: 0x06000598 RID: 1432
		void GetCollidersBrazoR(List<Collider> result);

		// Token: 0x06000599 RID: 1433
		void GetCollidersAnteBrazoL(List<Collider> result);

		// Token: 0x0600059A RID: 1434
		void GetCollidersAnteBrazoR(List<Collider> result);

		// Token: 0x0600059B RID: 1435
		void GetCollidersHandL(List<Collider> result);

		// Token: 0x0600059C RID: 1436
		void GetCollidersHandR(List<Collider> result);

		// Token: 0x0600059D RID: 1437
		void GetCollidersPiernaL(List<Collider> result);

		// Token: 0x0600059E RID: 1438
		void GetCollidersPiernaR(List<Collider> result);

		// Token: 0x0600059F RID: 1439
		void GetCollidersCanillaL(List<Collider> result);

		// Token: 0x060005A0 RID: 1440
		void GetCollidersCanillaR(List<Collider> result);

		// Token: 0x060005A1 RID: 1441
		void GetCollidersPieL(List<Collider> result);

		// Token: 0x060005A2 RID: 1442
		void GetCollidersPieR(List<Collider> result);

		// Token: 0x060005A3 RID: 1443
		void GetCollidersHips(List<Collider> result);

		// Token: 0x060005A4 RID: 1444
		void GetCollidersSpine(List<Collider> result);

		// Token: 0x060005A5 RID: 1445
		void GetCollidersChest(List<Collider> result);
	}
}
