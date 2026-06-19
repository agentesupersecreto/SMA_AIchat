using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200001A RID: 26
	public abstract class ColliderChecker<TCollider> : EmulatedHitSkin.ColliderCheckerBase where TCollider : Collider
	{
		// Token: 0x06000090 RID: 144 RVA: 0x000041C8 File Offset: 0x000023C8
		public ColliderChecker(TCollider collider)
		{
			if (collider == null)
			{
				throw new ArgumentNullException("collider", "collider null reference.");
			}
			this.m_collider = collider;
			Transform transform = ((collider.attachedRigidbody != null) ? collider.attachedRigidbody.transform : collider.transform);
			this.m_saver = transform.GetComponentNotNull<EmulatedStepVelocitySaver>();
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000091 RID: 145 RVA: 0x0000423D File Offset: 0x0000243D
		public sealed override Collider ownCollider
		{
			get
			{
				return this.m_collider;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000092 RID: 146 RVA: 0x0000424A File Offset: 0x0000244A
		public sealed override IStepVelocitySaverEmulated saver
		{
			get
			{
				return this.m_saver;
			}
		}

		// Token: 0x04000076 RID: 118
		private IStepVelocitySaverEmulated m_saver;

		// Token: 0x04000077 RID: 119
		[SerializeField]
		protected TCollider m_collider;
	}
}
