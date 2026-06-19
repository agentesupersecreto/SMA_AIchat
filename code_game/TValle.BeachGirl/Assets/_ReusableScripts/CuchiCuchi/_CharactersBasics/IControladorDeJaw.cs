using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi._CharactersBasics
{
	// Token: 0x02000132 RID: 306
	public interface IControladorDeJaw : IControladorDirecto, IComponentStartable
	{
		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x06000D51 RID: 3409
		bool estaObstruido { get; }

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x06000D52 RID: 3410
		Vector3 animationAngles { get; }

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x06000D53 RID: 3411
		Vector3 controlladorAngles { get; }
	}
}
