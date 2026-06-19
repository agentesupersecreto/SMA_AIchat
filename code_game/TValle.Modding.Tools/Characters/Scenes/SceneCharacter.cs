using System;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.Scenes
{
	// Token: 0x0200004B RID: 75
	public abstract class SceneCharacter : MonoBehaviour
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001A5 RID: 421
		public abstract Guid ID { get; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001A6 RID: 422
		public abstract string stringID { get; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060001A7 RID: 423
		public abstract bool isLoaded { get; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001A8 RID: 424
		public abstract string fullName { get; }

		// Token: 0x060001A9 RID: 425
		public abstract void Teleport(Vector3 position, Quaternion rotation);
	}
}
