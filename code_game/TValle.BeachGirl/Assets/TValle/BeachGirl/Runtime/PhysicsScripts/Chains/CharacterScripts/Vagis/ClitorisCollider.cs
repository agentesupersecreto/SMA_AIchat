using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Vagis
{
	// Token: 0x0200007E RID: 126
	public class ClitorisCollider : BodyPartCollider
	{
		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600034F RID: 847 RVA: 0x0000A03D File Offset: 0x0000823D
		protected override HashSet<Collider> misColliders
		{
			get
			{
				return this.m_misColliders;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000350 RID: 848 RVA: 0x0000A045 File Offset: 0x00008245
		public override float contactOffset
		{
			get
			{
				return 0.001f;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000351 RID: 849 RVA: 0x0000A04C File Offset: 0x0000824C
		public SphereCollider punta
		{
			get
			{
				return this.m_collider;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000352 RID: 850 RVA: 0x0000A054 File Offset: 0x00008254
		public SphereCollider @base
		{
			get
			{
				return this.m_baseCollider;
			}
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000A05C File Offset: 0x0000825C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetManualStart();
			base.SetInicializable();
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0000A070 File Offset: 0x00008270
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_collider = this.m_punta.GetComponentNotNull<SphereCollider>();
			this.m_baseCollider = this.m_collider.transform.gameObject.AddComponent<SphereCollider>();
			if (this.configuracion.material != null)
			{
				this.m_baseCollider.sharedMaterial = (this.m_collider.sharedMaterial = this.configuracion.material);
			}
			this.m_collider.center = this.configuracion.boneForward.normalized * (this.configuracion.virtualTipDistance * 0.5f);
			this.m_collider.radius = this.configuracion.initialRadius;
			Vector3 vector = this.m_baseClit.position - this.m_baseCollider.transform.position;
			this.m_baseCollider.radius = this.configuracion.initialRadiusBase;
			this.m_baseCollider.center = this.m_baseCollider.transform.InverseTransformPoint(this.m_baseCollider.transform.position + vector.normalized * this.m_baseCollider.radius);
			this.m_misColliders = new HashSet<Collider> { this.m_collider };
			base.initColliders();
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0000A1C9 File Offset: 0x000083C9
		public void Init(Transform punta, Transform baseClit)
		{
			this.m_punta = punta;
			this.m_baseClit = baseClit;
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000A1E8 File Offset: 0x000083E8
		private void OnDrawGizmosSelected()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (this.m_punta != null)
			{
				Vector3 vector = this.m_punta.TransformPoint(new Vector3(0f, 0f, this.configuracion.virtualTipDistance));
				Gizmos.DrawLine(this.m_punta.position, vector);
			}
		}

		// Token: 0x040001F1 RID: 497
		private SphereCollider m_baseCollider;

		// Token: 0x040001F2 RID: 498
		private SphereCollider m_collider;

		// Token: 0x040001F3 RID: 499
		private HashSet<Collider> m_misColliders;

		// Token: 0x040001F4 RID: 500
		public ClitorisCollider.Configuracion configuracion = new ClitorisCollider.Configuracion();

		// Token: 0x040001F5 RID: 501
		private Transform m_punta;

		// Token: 0x040001F6 RID: 502
		private Transform m_baseClit;

		// Token: 0x02000171 RID: 369
		[Serializable]
		public class Configuracion
		{
			// Token: 0x0400087A RID: 2170
			public PhysicMaterial material;

			// Token: 0x0400087B RID: 2171
			public Vector3 boneForward = Vector3.forward;

			// Token: 0x0400087C RID: 2172
			public float initialRadius = 0.0032f;

			// Token: 0x0400087D RID: 2173
			public float virtualTipDistance = 0.0031f;

			// Token: 0x0400087E RID: 2174
			public float initialRadiusBase = 0.005f;
		}
	}
}
