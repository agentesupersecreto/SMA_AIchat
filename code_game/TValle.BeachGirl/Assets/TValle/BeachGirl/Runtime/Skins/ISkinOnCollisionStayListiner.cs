using System;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.PhysicsScripts;

namespace Assets.TValle.BeachGirl.Runtime.Skins
{
	// Token: 0x02000066 RID: 102
	public interface ISkinOnCollisionStayListiner
	{
		// Token: 0x060001D0 RID: 464
		void OnStay(ColisionBasicaV2 collision, Skin sender);
	}
}
