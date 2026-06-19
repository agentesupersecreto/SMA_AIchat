using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000AF RID: 175
	public interface IAnimatorCharacter : ICharacter, ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000514 RID: 1300
		Quaternion armatureOrientationOffSet { get; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000515 RID: 1301
		Vector3 boneForward { get; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000516 RID: 1302
		Vector3 boneUp { get; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000517 RID: 1303
		IMapaDeHuesosDeCharacter mapaDeHuesos { get; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000518 RID: 1304
		BonesTransforms bones { get; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000519 RID: 1305
		Transform interactedBodyAnimatorRootMotionTransform { get; }
	}
}
