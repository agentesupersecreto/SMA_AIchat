using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000049 RID: 73
	public abstract class ConvexDynamicSkin : DynamicHitSkin
	{
		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600023C RID: 572 RVA: 0x00008280 File Offset: 0x00006480
		public Vector3 velocityBeforeCollisions
		{
			get
			{
				return this.m_velocityBeforeCollisions;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600023D RID: 573
		protected abstract BodyPartEnum? requiereBodyPartEnumCalculoConvex { get; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600023E RID: 574 RVA: 0x00008288 File Offset: 0x00006488
		public sealed override BodyPartEnum? requiereBodyPartEnumCalculo
		{
			get
			{
				return this.requiereBodyPartEnumCalculoConvex;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600023F RID: 575 RVA: 0x00008290 File Offset: 0x00006490
		public sealed override int updateEvent4Index
		{
			get
			{
				return 30;
			}
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00008294 File Offset: 0x00006494
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			try
			{
				this.m_dynamicCollider.convex = true;
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Exception ahead, " + base.name, base.gameObject);
				throw ex;
			}
		}

		// Token: 0x06000241 RID: 577 RVA: 0x000082E4 File Offset: 0x000064E4
		[Obsolete("", true)]
		public override void UpdateCollider()
		{
			if (!this.m_dynamicCollider.convex)
			{
				this.m_dynamicCollider.convex = true;
			}
			base.UpdateCollider();
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00008305 File Offset: 0x00006505
		protected override void Scheduling()
		{
			base.Scheduling();
			if (!this.m_dynamicCollider.convex)
			{
				this.m_dynamicCollider.convex = true;
			}
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00008326 File Offset: 0x00006526
		public override void OnUpdateEvent4()
		{
			this.m_velocityBeforeCollisions = this.rigid.velocity;
		}

		// Token: 0x04000116 RID: 278
		private Vector3 m_velocityBeforeCollisions;
	}
}
