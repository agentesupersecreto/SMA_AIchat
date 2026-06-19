using System;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x02000024 RID: 36
	public interface IFemaleSkins : IHitSkinnedCharacter, ISkinnedCharacter, IComponentStartable, IComponentAwakeable
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000BF RID: 191
		// (remove) Token: 0x060000C0 RID: 192
		event Action<object> mainSkinsAdded;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060000C1 RID: 193
		// (remove) Token: 0x060000C2 RID: 194
		event Action<ArmatureSkins, Skin> skinAdded;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060000C3 RID: 195
		// (remove) Token: 0x060000C4 RID: 196
		event Action<ArmatureSkins, Skin> skinRemoved;

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060000C5 RID: 197
		SkinnedMeshRenderer amigdalas { get; }
	}
}
