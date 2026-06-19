using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x0200001F RID: 31
	public interface IFemaleChar : ICharacter, ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600007A RID: 122
		ICharacter self { get; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600007B RID: 123
		IFemaleSkins skins { get; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600007C RID: 124
		IHole vagHole { get; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600007D RID: 125
		IHole anusHole { get; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600007E RID: 126
		IHole bocaHole { get; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600007F RID: 127
		IReadOnlyList<Collider> vagColliders { get; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000080 RID: 128
		IReadOnlyList<Collider> anusColliders { get; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000081 RID: 129
		IReadOnlyList<Collider> bocaColliders { get; }

		// Token: 0x06000082 RID: 130
		void IgnoreCollisions(IList<Collider> others, bool ignore = true);

		// Token: 0x06000083 RID: 131
		void IgnoreCollisionsAgaintsVagLabia(IList<Collider> others, bool ignore = true);

		// Token: 0x06000084 RID: 132
		void IgnoreCollisionsAgaintsGlutenAperture(IList<Collider> others, bool ignore = true);

		// Token: 0x06000085 RID: 133
		void IgnoreCollisionsAgaintsVag(IList<Collider> others, bool ignore = true);

		// Token: 0x06000086 RID: 134
		void IgnoreCollisionsAgaintsAnus(IList<Collider> others, bool ignore = true);

		// Token: 0x06000087 RID: 135
		void IgnoreCollisionsAgaintsLabios(IReadOnlyList<Collider> others, bool ignore = true);

		// Token: 0x06000088 RID: 136
		void IgnoreCollisionsAgaintsBoca(IList<Collider> others, bool ignore = true);
	}
}
