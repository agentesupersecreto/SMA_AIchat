using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x0200021A RID: 538
	public interface IPuppetChar : IPuppetCharacter, ICharacter, ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable
	{
		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000DA5 RID: 3493
		Character character { get; }

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000DA6 RID: 3494
		HashSetList<Collider> puppetColliders { get; }

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06000DA7 RID: 3495
		CharacterMuscles musculos { get; }

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000DA8 RID: 3496
		AnimatorCharacter self { get; }

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000DA9 RID: 3497
		BehaviourPuppet puppetBehaviour { get; }
	}
}
