using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x02000025 RID: 37
	public interface IHitSkinnedCharacter : ISkinnedCharacter, IComponentStartable, IComponentAwakeable
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060000C6 RID: 198
		bool usesHitSkins { get; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060000C7 RID: 199
		bool enableHitSkins { get; }

		// Token: 0x060000C8 RID: 200
		void ReIgnoreSkinSelfCollisions();

		// Token: 0x060000C9 RID: 201
		void IgnoreSkinCollisionsVersus(Collider other, bool ignore = true);

		// Token: 0x060000CA RID: 202
		void GetConvexColliders(List<MeshCollider> convexCollidersResult);

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060000CB RID: 203
		IReadOnlyList<IHitSkin> hitSkins { get; }
	}
}
