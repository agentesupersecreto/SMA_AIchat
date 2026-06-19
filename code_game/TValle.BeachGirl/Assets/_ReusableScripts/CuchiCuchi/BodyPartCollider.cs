using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000D7 RID: 215
	public abstract class BodyPartCollider : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06000832 RID: 2098 RVA: 0x00019B81 File Offset: 0x00017D81
		public IList<Collider> colliders
		{
			get
			{
				return this.m_colliders;
			}
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06000833 RID: 2099 RVA: 0x00019B89 File Offset: 0x00017D89
		public IReadOnlyList<Collider> collidersV2
		{
			get
			{
				return this.m_colliders;
			}
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06000834 RID: 2100 RVA: 0x00019B91 File Offset: 0x00017D91
		public IReadOnlyCollection<Collider> collidersSet
		{
			get
			{
				return this.misColliders;
			}
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06000835 RID: 2101
		protected abstract HashSet<Collider> misColliders { get; }

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000836 RID: 2102
		public abstract float contactOffset { get; }

		// Token: 0x06000837 RID: 2103 RVA: 0x00019B99 File Offset: 0x00017D99
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x00019BA4 File Offset: 0x00017DA4
		protected void initColliders()
		{
			List<Collider> list = new List<Collider>(this.misColliders.Count);
			foreach (Collider collider in this.misColliders)
			{
				collider.contactOffset = this.contactOffset;
				list.Add(collider);
			}
			this.m_colliders = list;
		}

		// Token: 0x04000481 RID: 1153
		private List<Collider> m_colliders;
	}
}
