using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Vags
{
	// Token: 0x0200010C RID: 268
	public class Vagi : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x000273B8 File Offset: 0x000255B8
		public List<Collider> allVagColliders
		{
			get
			{
				return this.m_AllVagColliders;
			}
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06000BC3 RID: 3011 RVA: 0x000273C0 File Offset: 0x000255C0
		public VagHole hole
		{
			get
			{
				if (this.m_hole == null)
				{
					this.m_hole = base.GetComponentInChildren<VagHole>();
				}
				return this.m_hole;
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06000BC4 RID: 3012 RVA: 0x000273E2 File Offset: 0x000255E2
		public VagLabia labia
		{
			get
			{
				if (this.m_labia == null)
				{
					this.m_labia = base.GetComponentInChildren<VagLabia>();
				}
				return this.m_labia;
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06000BC5 RID: 3013 RVA: 0x00027404 File Offset: 0x00025604
		public Clitoris clitoris
		{
			get
			{
				if (this.m_Clitoris == null)
				{
					this.m_Clitoris = base.GetComponentInChildren<Clitoris>();
				}
				return this.m_Clitoris;
			}
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x00027428 File Offset: 0x00025628
		protected override void AwakeUnityEvent()
		{
			this.m_layer = Singleton<ConfiguracionGeneral>.instance.layers.holeExtras;
			base.AwakeUnityEvent();
			this.m_hole = base.GetComponentInChildren<VagHole>();
			this.m_labia = base.GetComponentInChildren<VagLabia>();
			this.m_Clitoris = base.GetComponentInChildren<Clitoris>();
			if (this.m_hole == null)
			{
				throw new ArgumentNullException("m_hole", "m_hole null reference.");
			}
			if (this.m_labia == null)
			{
				throw new ArgumentNullException("m_labia", "m_labia null reference.");
			}
			if (this.m_Clitoris == null)
			{
				throw new ArgumentNullException("m_Clitoris", "m_Clitoris null reference.");
			}
			base.GetComponentsInChildren<CustomUpdatedMonobehaviourBase>(true, this.m_customMonos);
			this.m_customMonos.Remove(this);
			this.m_customMonos.RemoveAll((CustomUpdatedMonobehaviourBase item) => item.transform.IsChildOf(this.m_Clitoris.transform) && item != this.m_Clitoris);
			if (base.enabled)
			{
				this.m_customMonos.ForEach(delegate(CustomUpdatedMonobehaviourBase c)
				{
					if (c.gameObject.activeInHierarchy && !c.customUpdatedConfig.yieldStart)
					{
						c.customUpdatedConfig.manualStart = true;
					}
				});
			}
		}

		// Token: 0x06000BC7 RID: 3015 RVA: 0x00027534 File Offset: 0x00025734
		protected override void StartUnityEvent()
		{
			base.transform.ExecDeepChild(delegate(Transform t)
			{
				t.gameObject.layer = this.m_layer;
			}, true);
			base.StartUnityEvent();
			Rigidbody componentInParent = base.GetComponentInParent<Rigidbody>();
			if (componentInParent != null && componentInParent.gameObject != base.gameObject)
			{
				Debug.LogWarning("vagina tiene un rigid como padre, podrian haber errores. name: " + componentInParent.name, componentInParent);
			}
			this.m_customMonos.ForEach(delegate(CustomUpdatedMonobehaviourBase c)
			{
				if (c.gameObject.activeInHierarchy && !c.isStared && !c.customUpdatedConfig.yieldStart)
				{
					c.ManualStart();
				}
			});
			base.GetComponentsInChildren<Collider>(true, this.m_AllVagColliders);
			this.IgnoreAllSelfCollisions();
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x000275D5 File Offset: 0x000257D5
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared)
			{
				this.IgnoreAllSelfCollisions();
			}
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x000275EB File Offset: 0x000257EB
		public void IgnoreAllSelfCollisions()
		{
			this.m_AllVagColliders.Colisionar(delegate(Collider a, Collider b)
			{
				Physics.IgnoreCollision(a, b);
			});
		}

		// Token: 0x0400064E RID: 1614
		private int m_layer;

		// Token: 0x0400064F RID: 1615
		private List<Collider> m_AllVagColliders = new List<Collider>();

		// Token: 0x04000650 RID: 1616
		private List<CustomUpdatedMonobehaviourBase> m_customMonos = new List<CustomUpdatedMonobehaviourBase>();

		// Token: 0x04000651 RID: 1617
		private VagHole m_hole;

		// Token: 0x04000652 RID: 1618
		private VagLabia m_labia;

		// Token: 0x04000653 RID: 1619
		private Clitoris m_Clitoris;
	}
}
