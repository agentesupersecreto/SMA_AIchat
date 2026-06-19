using System;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands
{
	// Token: 0x0200024F RID: 591
	public class FemaleHandPickHandler : HandPickHandlerBase
	{
		// Token: 0x06000FA6 RID: 4006 RVA: 0x00045BC0 File Offset: 0x00043DC0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_FemaleSkins = this.GetComponentEnRoot(false);
			if (this.m_FemaleSkins == null)
			{
				throw new ArgumentNullException("m_FemaleSkins", "m_FemaleSkins null reference.");
			}
			if (!this.m_FemaleSkins.isStared)
			{
				this.m_FemaleSkins.stared += this.M_FemaleSkins_stared;
				return;
			}
			this.M_FemaleSkins_stared(this.m_FemaleSkins);
		}

		// Token: 0x06000FA7 RID: 4007 RVA: 0x00045C30 File Offset: 0x00043E30
		private void M_FemaleSkins_stared(object sender)
		{
			Side side = this.m_side;
			if (side != Side.L)
			{
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(this.m_side.ToString());
				}
				this.m_HandHitSkin = this.m_FemaleSkins.hitSkins.partes.manos.r;
			}
			else
			{
				this.m_HandHitSkin = this.m_FemaleSkins.hitSkins.partes.manos.l;
			}
			base.InitFingers();
			base.SetUser(this.m_HandHitSkin.boneTarget, this.m_HandHitSkin.rigid, this.m_HandHitSkin.credorDeColliders);
		}

		// Token: 0x06000FA8 RID: 4008 RVA: 0x00045CD6 File Offset: 0x00043ED6
		public override CreadorDeCollidersParaManos GetHandColliders()
		{
			return this.m_HandHitSkin.credorDeColliders;
		}

		// Token: 0x04000ADA RID: 2778
		private FemaleSkins m_FemaleSkins;

		// Token: 0x04000ADB RID: 2779
		[Header("Female")]
		[SerializeField]
		private HandHitSkin m_HandHitSkin;
	}
}
