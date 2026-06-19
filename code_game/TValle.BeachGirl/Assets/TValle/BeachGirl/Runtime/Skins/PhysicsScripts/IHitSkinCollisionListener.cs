using System;

namespace Assets.TValle.BeachGirl.Runtime.Skins.PhysicsScripts
{
	// Token: 0x0200006B RID: 107
	public interface IHitSkinCollisionListener
	{
		// Token: 0x060001F6 RID: 502
		void OnEnter(HitSkinColision collision);

		// Token: 0x060001F7 RID: 503
		void OnStay(HitSkinColision collision);

		// Token: 0x060001F8 RID: 504
		void OnExit(HitSkinColision lastCollision);
	}
}
