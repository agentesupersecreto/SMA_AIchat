using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Particulas
{
	// Token: 0x02000155 RID: 341
	public class ParticleCollisionBroadCaster : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x060007B7 RID: 1975 RVA: 0x000081F8 File Offset: 0x000063F8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x00023F3F File Offset: 0x0002213F
		public void Init(ParticulasParaHitSkin owner)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner", "owner null reference.");
			}
			this.m_owner = owner;
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x00023F6D File Offset: 0x0002216D
		private void OnParticleCollision(GameObject particlesOriginales)
		{
			if (this.m_owner == null)
			{
				return;
			}
			((ParticulasParaHitSkin.IOnCollisionListiner)this.m_owner).OnCollision(particlesOriginales, this);
		}

		// Token: 0x04000615 RID: 1557
		private ParticulasParaHitSkin m_owner;
	}
}
