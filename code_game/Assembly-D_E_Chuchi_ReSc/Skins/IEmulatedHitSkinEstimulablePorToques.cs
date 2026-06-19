using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200004C RID: 76
	public interface IEmulatedHitSkinEstimulablePorToques : IEstimulablePorToques, IComponentStartable
	{
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600024A RID: 586
		BodyPartEnum bodyPart { get; }
	}
}
