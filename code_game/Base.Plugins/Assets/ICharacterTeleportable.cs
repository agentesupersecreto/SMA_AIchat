using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000AB RID: 171
	public interface ICharacterTeleportable
	{
		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000508 RID: 1288
		ICharacter self { get; }

		// Token: 0x06000509 RID: 1289
		void SetPositionAndRotation(Transform targetTransform);

		// Token: 0x0600050A RID: 1290
		void SetPositionAndRotation(Vector3 position, Quaternion rotation);
	}
}
