using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200004B RID: 75
	public interface IHitSkinEstimulablePorToques : IEstimulablePorToques, IComponentStartable
	{
		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000249 RID: 585
		HitPartEnum hitParte { get; }
	}
}
