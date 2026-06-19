using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000B4 RID: 180
	public interface ICharacterHighHeelable
	{
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600052A RID: 1322
		ModificableDeFloat grounderIkWeigthModificable { get; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600052B RID: 1323
		float currentHeelLocalHeight { get; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600052C RID: 1324
		float currentToeLocalHeight { get; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x0600052D RID: 1325
		float currentHeelWorldHeight { get; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600052E RID: 1326
		float currentToeWorldHeight { get; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600052F RID: 1327
		float currentRealHeelLocalHeight { get; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000530 RID: 1328
		float currentRealToeLocalHeight { get; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000531 RID: 1329
		float currentHeelWorldTotalHeight { get; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000532 RID: 1330
		float currentToeWorldTotalHeight { get; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000533 RID: 1331
		float currentRealHeelWorldHeight { get; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000534 RID: 1332
		float currentRealToeWorldHeight { get; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000535 RID: 1333
		float currentRealHeelWorldTotalHeight { get; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000536 RID: 1334
		float currentRealToeWorldTotalHeight { get; }

		// Token: 0x06000537 RID: 1335
		void ResetHeight();

		// Token: 0x06000538 RID: 1336
		void SetHeight(float toeLocalHeight, float heelLocalHeight, float toePoseWeight, float heelPoseWeight);

		// Token: 0x06000539 RID: 1337
		Vector3 GetDownDirectionFromHeelsR();

		// Token: 0x0600053A RID: 1338
		Vector3 GetDownDirectionFromHeelsL();

		// Token: 0x0600053B RID: 1339
		Vector3 GetDownDirectionFromToesR();

		// Token: 0x0600053C RID: 1340
		Vector3 GetDownDirectionFromToesL();

		// Token: 0x0600053D RID: 1341
		Vector3 GetVirtualDownDirectionFromHeelR();

		// Token: 0x0600053E RID: 1342
		Vector3 GetVirtualDownDirectionFromHeelL();

		// Token: 0x0600053F RID: 1343
		Vector3 GetVirtualDownDirectionFromToeR();

		// Token: 0x06000540 RID: 1344
		Vector3 GetVirtualDownDirectionFromToeL();
	}
}
