using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000AC RID: 172
	public interface ICharacterNavegable
	{
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600050B RID: 1291
		ICharacter self { get; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600050C RID: 1292
		bool isNavigating { get; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600050D RID: 1293
		bool isGoingToNavite { get; }

		// Token: 0x0600050E RID: 1294
		void NavToTarget(Transform target, bool interrupt, float maxMagnitude, float cornerDistanceMod, bool OnlyStrafe, Vector3? finalOrientation = null, Action staredCallback = null, Action<bool> stoppedCallback = null);

		// Token: 0x0600050F RID: 1295
		void TurnTo(Vector3 worldDirection, bool interrupt, float errorAngleMod = 1f, float startVelMod = 1f, float stopVelMod = 1f, Action staredCallback = null, Action<bool> stoppedCallback = null);
	}
}
