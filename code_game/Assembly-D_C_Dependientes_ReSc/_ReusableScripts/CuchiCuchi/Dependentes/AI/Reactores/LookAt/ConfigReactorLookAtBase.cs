using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.AI.Reactores.LookAt
{
	// Token: 0x020002CD RID: 717
	[Serializable]
	public class ConfigReactorLookAtBase
	{
		// Token: 0x04000D54 RID: 3412
		public ConfigReactorLookAtBase.CoolDownTimes coolDownTimes = new ConfigReactorLookAtBase.CoolDownTimes();

		// Token: 0x04000D55 RID: 3413
		public ConfigReactorLookAtBase.Chances chancesMods = new ConfigReactorLookAtBase.Chances();

		// Token: 0x020002CE RID: 718
		[Serializable]
		public class CoolDownTimes
		{
			// Token: 0x04000D56 RID: 3414
			public float evade = 12.5f;

			// Token: 0x04000D57 RID: 3415
			public float cambioDeMiradaMod = 1f;
		}

		// Token: 0x020002CF RID: 719
		[Serializable]
		public class Chances
		{
			// Token: 0x04000D58 RID: 3416
			[Range(0f, 10f)]
			public float lookAtEstimulePosition = 1f;

			// Token: 0x04000D59 RID: 3417
			[Range(0f, 10f)]
			public float chanceToEvade = 1f;
		}
	}
}
