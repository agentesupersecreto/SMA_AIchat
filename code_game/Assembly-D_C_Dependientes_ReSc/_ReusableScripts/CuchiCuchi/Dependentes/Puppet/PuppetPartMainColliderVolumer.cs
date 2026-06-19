using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Volumenes;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x02000116 RID: 278
	[RequireComponent(typeof(PuppetPart))]
	public class PuppetPartMainColliderVolumer : CustomUpdatedMonobehaviourBase, IModificableDeVolumenDeMusculo
	{
		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x000066D6 File Offset: 0x000048D6
		public override int updateEvent1Index
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060005B1 RID: 1457 RVA: 0x000205A7 File Offset: 0x0001E7A7
		public override int updateEvent2Index
		{
			get
			{
				return 7;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x000205AA File Offset: 0x0001E7AA
		public BoxModificable boxModificable
		{
			get
			{
				return this.m_BoxModificable;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060005B3 RID: 1459 RVA: 0x000205B2 File Offset: 0x0001E7B2
		public SphereModificable sphereModificable
		{
			get
			{
				return this.m_SphereModificable;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x000205BA File Offset: 0x0001E7BA
		public CapsuleModificable capsuleModificable
		{
			get
			{
				return this.m_CapsuleModificable;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060005B5 RID: 1461 RVA: 0x000205C2 File Offset: 0x0001E7C2
		public TipoDeCollider tipo
		{
			get
			{
				return this.m_Tipo;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060005B6 RID: 1462 RVA: 0x000205CA File Offset: 0x0001E7CA
		public Muscle muscle
		{
			get
			{
				return this.m_PuppetPart.muscle;
			}
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x000205D8 File Offset: 0x0001E7D8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PuppetPart = base.GetComponent<PuppetPart>();
			if (!this.m_PuppetPart.isStared)
			{
				this.m_PuppetPart.stared += this.M_PuppetPart_stared;
			}
			else
			{
				this.M_PuppetPart_stared(this.m_PuppetPart);
			}
			base.SetManualStart();
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x00020630 File Offset: 0x0001E830
		private void M_PuppetPart_stared(object obj)
		{
			this.m_mainCollider = this.m_PuppetPart.muscle.colliders[0];
			if (this.m_mainCollider == null)
			{
				throw new ArgumentNullException("m_mainCollider", "m_mainCollider null reference.");
			}
			if (this.m_mainCollider is CapsuleCollider)
			{
				this.m_Tipo = TipoDeCollider.capsule;
				this.m_CapsuleModificable = new CapsuleModificable(this.m_mainCollider as CapsuleCollider);
			}
			else if (this.m_mainCollider is BoxCollider)
			{
				this.m_Tipo = TipoDeCollider.box;
				this.m_BoxModificable = new BoxModificable(this.m_mainCollider as BoxCollider);
			}
			else
			{
				if (!(this.m_mainCollider is CapsuleCollider))
				{
					throw new NotSupportedException();
				}
				this.m_Tipo = TipoDeCollider.sphere;
				this.m_SphereModificable = new SphereModificable(this.m_mainCollider as SphereCollider);
			}
			base.ManualStart();
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x00020704 File Offset: 0x0001E904
		public void Fix()
		{
			switch (this.m_Tipo)
			{
			case TipoDeCollider.sphere:
				this.m_SphereModificable.Fix();
				return;
			case TipoDeCollider.capsule:
				this.m_CapsuleModificable.Fix();
				return;
			case TipoDeCollider.box:
				this.m_BoxModificable.Fix();
				return;
			default:
				throw new ArgumentOutOfRangeException(this.m_Tipo.ToString());
			}
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x00020768 File Offset: 0x0001E968
		public void Actualziar()
		{
			switch (this.m_Tipo)
			{
			case TipoDeCollider.sphere:
				this.m_SphereModificable.Actualizar();
				return;
			case TipoDeCollider.capsule:
				this.m_CapsuleModificable.Actualizar();
				return;
			case TipoDeCollider.box:
				this.m_BoxModificable.Actualizar();
				return;
			default:
				throw new ArgumentOutOfRangeException(this.m_Tipo.ToString());
			}
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x000207CA File Offset: 0x0001E9CA
		public override void OnUpdateEvent1()
		{
			if (this.fixScala)
			{
				this.Fix();
			}
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x000207DA File Offset: 0x0001E9DA
		public override void OnUpdateEvent2()
		{
			this.Actualziar();
		}

		// Token: 0x04000471 RID: 1137
		public bool fixScala;

		// Token: 0x04000472 RID: 1138
		private PuppetPart m_PuppetPart;

		// Token: 0x04000473 RID: 1139
		[SerializeField]
		private BoxModificable m_BoxModificable;

		// Token: 0x04000474 RID: 1140
		[SerializeField]
		private SphereModificable m_SphereModificable;

		// Token: 0x04000475 RID: 1141
		[SerializeField]
		private CapsuleModificable m_CapsuleModificable;

		// Token: 0x04000476 RID: 1142
		private TipoDeCollider m_Tipo;

		// Token: 0x04000477 RID: 1143
		private Collider m_mainCollider;

		// Token: 0x04000478 RID: 1144
		private Muscle m_muscle;
	}
}
