using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Anuss
{
	// Token: 0x02000112 RID: 274
	public class Anus : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x06000C18 RID: 3096 RVA: 0x00028FC3 File Offset: 0x000271C3
		public List<Collider> allColliders
		{
			get
			{
				return this.m_allColliders;
			}
		}

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x06000C19 RID: 3097 RVA: 0x00028FCB File Offset: 0x000271CB
		public AnusHole hole
		{
			get
			{
				if (this.m_hole == null)
				{
					this.m_hole = base.GetComponentInChildren<AnusHole>();
				}
				return this.m_hole;
			}
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x00028FF0 File Offset: 0x000271F0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.GetComponentsInChildren<CustomUpdatedMonobehaviourBase>(true, this.m_customMonos);
			this.m_customMonos.Remove(this);
			this.m_customMonos.ForEach(delegate(CustomUpdatedMonobehaviourBase c)
			{
				if (c.gameObject.activeInHierarchy && !c.customUpdatedConfig.yieldStart)
				{
					c.customUpdatedConfig.manualStart = true;
				}
			});
			this.m_hole = base.GetComponentInChildren<AnusHole>();
			if (this.m_hole == null)
			{
				throw new ArgumentNullException("m_hole", "m_hole null reference.");
			}
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x00029074 File Offset: 0x00027274
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			Rigidbody componentInParent = base.GetComponentInParent<Rigidbody>();
			if (componentInParent != null && componentInParent.gameObject != base.gameObject)
			{
				Debug.LogWarning("anus tiene un rigid como padre, podrian haber errores. name: " + componentInParent.name, componentInParent);
			}
			this.m_customMonos.ForEach(delegate(CustomUpdatedMonobehaviourBase c)
			{
				if (c.gameObject.activeInHierarchy && !c.customUpdatedConfig.yieldStart)
				{
					c.ManualStart();
				}
			});
			base.GetComponentsInChildren<Collider>(true, this.m_allColliders);
			this.IgnoreAllSelfCollisions();
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x000290FD File Offset: 0x000272FD
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared)
			{
				this.IgnoreAllSelfCollisions();
			}
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x00029113 File Offset: 0x00027313
		public void IgnoreAllSelfCollisions()
		{
			this.m_allColliders.Colisionar(delegate(Collider a, Collider b)
			{
				Physics.IgnoreCollision(a, b);
			});
		}

		// Token: 0x04000690 RID: 1680
		[Obsolete("", true)]
		[NonSerialized]
		private int m_layer;

		// Token: 0x04000691 RID: 1681
		private List<Collider> m_allColliders = new List<Collider>();

		// Token: 0x04000692 RID: 1682
		private List<CustomUpdatedMonobehaviourBase> m_customMonos = new List<CustomUpdatedMonobehaviourBase>();

		// Token: 0x04000693 RID: 1683
		private AnusHole m_hole;
	}
}
