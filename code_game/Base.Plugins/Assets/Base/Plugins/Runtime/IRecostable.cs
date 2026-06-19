using System;
using UnityEngine;

namespace Assets.Base.Plugins.Runtime
{
	// Token: 0x0200017D RID: 381
	public interface IRecostable
	{
		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000B50 RID: 2896
		[Obsolete("usar root")]
		object transform { get; }

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000B51 RID: 2897
		Transform pivot { get; }

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000B52 RID: 2898
		float worldAltura { get; }

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000B53 RID: 2899
		Vector3 idleRootWorldPositon { get; }

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000B54 RID: 2900
		Vector3 edgeGroundWorldPositon { get; }

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000B55 RID: 2901
		Quaternion worldRotation { get; }

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000B56 RID: 2902
		Vector3 worldForward { get; }

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000B57 RID: 2903
		Vector3 worldUp { get; }

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000B58 RID: 2904
		Vector3 gotoWorldPositon { get; }

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000B59 RID: 2905
		float gotoWorldRadius { get; }

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000B5A RID: 2906
		Vector3 superficieWorldPositon { get; }

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000B5B RID: 2907
		Vector3 edgeWorldPositon { get; }

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000B5C RID: 2908
		Vector3 groundWorldPositon { get; }

		// Token: 0x06000B5D RID: 2909
		void UpdateGoto(ICharacter sentador);

		// Token: 0x06000B5E RID: 2910
		bool IsOnGotoPosition(ICharacter sentador, float radiusMod = 1.5f);

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000B5F RID: 2911
		Vector3 dinamicOffset { get; }
	}
}
