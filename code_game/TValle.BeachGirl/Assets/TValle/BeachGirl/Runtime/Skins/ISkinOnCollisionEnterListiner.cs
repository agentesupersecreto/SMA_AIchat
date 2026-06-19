using System;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.PhysicsScripts;

namespace Assets.TValle.BeachGirl.Runtime.Skins
{
	// Token: 0x02000065 RID: 101
	public interface ISkinOnCollisionEnterListiner
	{
		// Token: 0x060001CF RID: 463
		void OnEnter(ColisionBasicaV2 collision, Skin sender);
	}
}
