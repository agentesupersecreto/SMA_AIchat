using System;
using Assets.TValle.BeachGirl.Runtime.Skins;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.PhysicsScripts;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands
{
	// Token: 0x02000279 RID: 633
	public class RedirectorDeSkinOnCollisionStayListiner : CustomMonobehaviour, ISkinOnCollisionStayListiner
	{
		// Token: 0x060010B0 RID: 4272 RVA: 0x0004E905 File Offset: 0x0004CB05
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_padre = base.transform.parent.GetComponentInParent<ISkinOnCollisionStayListiner>();
		}

		// Token: 0x060010B1 RID: 4273 RVA: 0x0004E923 File Offset: 0x0004CB23
		public void OnStay(ColisionBasicaV2 collision, Skin sender)
		{
			ISkinOnCollisionStayListiner padre = this.m_padre;
			if (padre == null)
			{
				return;
			}
			padre.OnStay(collision, sender);
		}

		// Token: 0x04000C2E RID: 3118
		private ISkinOnCollisionStayListiner m_padre;
	}
}
