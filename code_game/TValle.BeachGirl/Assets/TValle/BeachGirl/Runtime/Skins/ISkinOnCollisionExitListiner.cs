using System;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.PhysicsScripts;

namespace Assets.TValle.BeachGirl.Runtime.Skins
{
	// Token: 0x02000067 RID: 103
	public interface ISkinOnCollisionExitListiner
	{
		// Token: 0x060001D1 RID: 465
		void OnExit(ColisionBasicaV2 collision, Skin sender);
	}
}
