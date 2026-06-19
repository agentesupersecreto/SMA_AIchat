using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.AI.Reactores.Effector
{
	// Token: 0x020002D4 RID: 724
	[Serializable]
	public class ConfigDeReacctorConEffector
	{
		// Token: 0x04000D76 RID: 3446
		public bool invertirNormales = true;

		// Token: 0x04000D77 RID: 3447
		[Tooltip("no es el general , sino q es por tipo")]
		public float effectorsTipoCoolDownTime = 0.55f;

		// Token: 0x04000D78 RID: 3448
		public float effectorDefaultLocalDistance = 0.045f;

		// Token: 0x04000D79 RID: 3449
		[Range(0f, 1f)]
		public float effectorDefaultLocalDistanceRandomRangeModV2 = 0.2f;

		// Token: 0x04000D7A RID: 3450
		public float effectorDefaultDuration = 1.5f;

		// Token: 0x04000D7B RID: 3451
		[Range(0f, 1f)]
		public float effectorDefaultDurationRandomRangeModV2 = 0.2f;
	}
}
