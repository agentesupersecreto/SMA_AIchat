using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x0200021B RID: 539
	public interface ICharacterControllerChar
	{
		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06000DAA RID: 3498
		Vector3 movingOnDirection { get; }

		// Token: 0x06000DAB RID: 3499
		void UpdateActorControllerColliders();

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x06000DAC RID: 3500
		HashSetList<Collider> characterControllerColliders { get; }
	}
}
