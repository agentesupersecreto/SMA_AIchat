using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000EB RID: 235
	public class VagLabiaPointColliders : BodyPartCollider
	{
		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x060009D2 RID: 2514 RVA: 0x0001F80C File Offset: 0x0001DA0C
		protected override HashSet<Collider> misColliders
		{
			get
			{
				return this.m_misColliders;
			}
		}

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x060009D3 RID: 2515 RVA: 0x0001F814 File Offset: 0x0001DA14
		public override float contactOffset
		{
			get
			{
				return 0.001f;
			}
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x0001F81C File Offset: 0x0001DA1C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_collider = this.GetComponentNotNull<SphereCollider>();
			if (this.configuracion.material != null)
			{
				this.m_collider.sharedMaterial = this.configuracion.material;
			}
			if (this.centerOffsetDirection != null)
			{
				this.centerOffsetDirection = new Vector3?(this.centerOffsetDirection.Value.normalized);
			}
			this.UpdateCollider(0f, false);
			this.m_misColliders = new HashSet<Collider> { this.m_collider };
			base.initColliders();
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x0001F8B9 File Offset: 0x0001DAB9
		public bool IsTouchedByAny()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0001F8C0 File Offset: 0x0001DAC0
		public void UpdateCollider(float penetrationAnchuraW, bool smooth)
		{
			float num = Mathf.Lerp(this.configuracion.initialRadius, this.configuracion.penetratedRadius, penetrationAnchuraW);
			if (smooth)
			{
				this.m_collider.radius = Mathf.Lerp(this.m_collider.radius, num, Time.deltaTime * 5f);
			}
			else
			{
				this.m_collider.radius = num;
			}
			Vector3 vector = this.verticalOffsetDirection * this.m_collider.radius * 0.333f;
			if (this.centerOffsetDirection == null)
			{
				this.m_collider.center = vector;
				return;
			}
			Vector3 value = this.centerOffsetDirection.Value;
			Vector3 vector2 = value * this.configuracion.initialRadius * this.configuracion.initialOffset;
			Vector3 vector3 = value * this.configuracion.penetratedRadius * this.configuracion.penetratedOffset;
			Vector3 vector4 = Vector3.Lerp(vector2, vector3, penetrationAnchuraW) + vector;
			if (smooth)
			{
				this.m_collider.center = Vector3.Lerp(this.m_collider.center, vector4, Time.deltaTime * 5f);
				return;
			}
			this.m_collider.center = vector4;
		}

		// Token: 0x04000539 RID: 1337
		private SphereCollider m_collider;

		// Token: 0x0400053A RID: 1338
		private HashSet<Collider> m_misColliders;

		// Token: 0x0400053B RID: 1339
		public VagLabiaPointColliders.Configuracion configuracion = new VagLabiaPointColliders.Configuracion();

		// Token: 0x0400053C RID: 1340
		public Vector3? centerOffsetDirection;

		// Token: 0x0400053D RID: 1341
		public Vector3 verticalOffsetDirection = -Vector3.forward;

		// Token: 0x020001C1 RID: 449
		[Serializable]
		public class Configuracion
		{
			// Token: 0x06000F53 RID: 3923 RVA: 0x000343CA File Offset: 0x000325CA
			public VagLabiaPointColliders.Configuracion Clone()
			{
				return (VagLabiaPointColliders.Configuracion)base.MemberwiseClone();
			}

			// Token: 0x04000A05 RID: 2565
			public PhysicMaterial material;

			// Token: 0x04000A06 RID: 2566
			[Obsolete]
			[HideInInspector]
			public float radius = 0.0075f;

			// Token: 0x04000A07 RID: 2567
			[Obsolete]
			[HideInInspector]
			public float offset = 1f;

			// Token: 0x04000A08 RID: 2568
			public float initialRadius = 0.0075f;

			// Token: 0x04000A09 RID: 2569
			public float initialOffset = 1f;

			// Token: 0x04000A0A RID: 2570
			public float penetratedRadius = 0.0075f;

			// Token: 0x04000A0B RID: 2571
			public float penetratedOffset = 1f;
		}
	}
}
