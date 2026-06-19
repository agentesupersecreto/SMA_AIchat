using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x02000027 RID: 39
	public interface IHitSkin
	{
		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060000CF RID: 207
		Rigidbody rigid { get; }

		// Token: 0x060000D0 RID: 208
		bool PointIsInside(Vector3 worldPoint);
	}
}
