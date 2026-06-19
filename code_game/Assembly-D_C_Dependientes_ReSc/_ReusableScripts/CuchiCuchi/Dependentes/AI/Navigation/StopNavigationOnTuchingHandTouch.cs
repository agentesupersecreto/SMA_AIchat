using System;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Navigation
{
	// Token: 0x0200038D RID: 909
	public class StopNavigationOnTuchingHandTouch : CustomMonobehaviour
	{
		// Token: 0x06001699 RID: 5785 RVA: 0x0006BBF4 File Offset: 0x00069DF4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_FemaleSkins = this.GetComponentEnRoot(false);
			if (this.m_FemaleSkins == null)
			{
				throw new ArgumentNullException("m_FemaleSkins", "m_FemaleSkins null reference.");
			}
			this.m_SimpleFemaleNavigation = this.GetComponentEnRoot(false);
			if (this.m_SimpleFemaleNavigation == null)
			{
				throw new ArgumentNullException("m_SimpleFemaleNavigation", "m_SimpleFemaleNavigation null reference.");
			}
			this.m_FemaleSkins.stared += this.M_FemaleSkins_stared;
		}

		// Token: 0x0600169A RID: 5786 RVA: 0x0006BC74 File Offset: 0x00069E74
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared && this.m_FemaleSkins.isStared)
			{
				this.Sub();
			}
		}

		// Token: 0x0600169B RID: 5787 RVA: 0x0006BC97 File Offset: 0x00069E97
		private void M_FemaleSkins_stared(object sender)
		{
			this.Sub();
		}

		// Token: 0x0600169C RID: 5788 RVA: 0x0006BC9F File Offset: 0x00069E9F
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.DeSub();
		}

		// Token: 0x0600169D RID: 5789 RVA: 0x0006BCB0 File Offset: 0x00069EB0
		private void Sub()
		{
			for (int i = 0; i < this.m_FemaleSkins.hitSkins.hitSkins.Count; i++)
			{
				HitSkin hitSkin = this.m_FemaleSkins.hitSkins.hitSkins[i] as HitSkin;
				if (!(hitSkin == null))
				{
					hitSkin.onCollisionEnter += this.Hs_onCollision;
					hitSkin.onCollisionStay += this.Hs_onCollision;
				}
			}
		}

		// Token: 0x0600169E RID: 5790 RVA: 0x0006BD28 File Offset: 0x00069F28
		private void DeSub()
		{
			if (this.m_FemaleSkins == null)
			{
				return;
			}
			for (int i = 0; i < this.m_FemaleSkins.hitSkins.hitSkins.Count; i++)
			{
				HitSkin hitSkin = this.m_FemaleSkins.hitSkins.hitSkins[i] as HitSkin;
				if (!(hitSkin == null))
				{
					hitSkin.onCollisionEnter -= this.Hs_onCollision;
					hitSkin.onCollisionStay -= this.Hs_onCollision;
				}
			}
		}

		// Token: 0x0600169F RID: 5791 RVA: 0x0006BDB0 File Offset: 0x00069FB0
		private void Hs_onCollision(Collision obj)
		{
			if (!this.m_SimpleFemaleNavigation.isNavigating && !this.m_SimpleFemaleNavigation.isGoingToNavite)
			{
				return;
			}
			if (obj.collider.gameObject.layer != ConfiguracionGlobal.layersStatic.touchingHand)
			{
				return;
			}
			this.m_SimpleFemaleNavigation.Interrupt();
		}

		// Token: 0x04001063 RID: 4195
		private FemaleSkins m_FemaleSkins;

		// Token: 0x04001064 RID: 4196
		private SimpleFemaleNavigation m_SimpleFemaleNavigation;
	}
}
