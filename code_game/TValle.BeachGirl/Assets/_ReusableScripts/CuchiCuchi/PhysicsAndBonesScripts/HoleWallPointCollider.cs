using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000E5 RID: 229
	public class HoleWallPointCollider : BodyPartCollider
	{
		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06000969 RID: 2409 RVA: 0x0001DDA9 File Offset: 0x0001BFA9
		public Collider wallCollider
		{
			get
			{
				return this.m_wallCollider;
			}
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x0600096A RID: 2410 RVA: 0x0001DDB1 File Offset: 0x0001BFB1
		protected BoneStretchedChain.HoleConfig holeConfig
		{
			get
			{
				return this.m_Hole.holeConfig;
			}
		}

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x0600096B RID: 2411 RVA: 0x0001DDBE File Offset: 0x0001BFBE
		protected override HashSet<Collider> misColliders
		{
			get
			{
				return this.m_misColliders;
			}
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x0600096C RID: 2412 RVA: 0x0001DDC6 File Offset: 0x0001BFC6
		public override float contactOffset
		{
			get
			{
				return 0.001f;
			}
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0001DDCD File Offset: 0x0001BFCD
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0001DDD8 File Offset: 0x0001BFD8
		public void CrearColliders(BoneStretchedChain hole, Vector3 localPlane, int puntoID)
		{
			this.m_Hole = hole;
			CapsuleCollider componentNotNull = this.GetComponentNotNull<CapsuleCollider>();
			this.m_wallCollider = componentNotNull;
			Vector3 vector = Math3d.ProjectPointOnPlane(base.transform.TransformDirection(localPlane), base.transform.position, hole.centroDePuntos.position);
			this.ConfigurarColliderW(vector);
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0001DE2C File Offset: 0x0001C02C
		public void CrearColliders(BoneStretchedChain hole, int puntoID, Vector3 localDirCentroHaciaAfuera)
		{
			this.m_Hole = hole;
			CapsuleCollider componentNotNull = this.GetComponentNotNull<CapsuleCollider>();
			this.m_wallCollider = componentNotNull;
			this.m_localDirCentroHaciaAfuera = localDirCentroHaciaAfuera;
			this.ConfigurarColliderL();
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x0001DE5B File Offset: 0x0001C05B
		public void InitColliders()
		{
			this.m_misColliders = new HashSet<Collider> { this.m_wallCollider };
			base.initColliders();
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0001DE7C File Offset: 0x0001C07C
		private void ConfigurarColliderW(Vector3 wCentroDePuntos)
		{
			Vector3 vector = base.transform.position - wCentroDePuntos;
			this.m_localDirCentroHaciaAfuera = base.transform.InverseTransformDirection(vector).normalized;
			this.ConfigurarColliderL();
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x0001DEBB File Offset: 0x0001C0BB
		private void ConfigurarColliderL()
		{
			this.m_wallCollider.direction = this.configuracion.direction;
			this.m_wallCollider.sharedMaterial = this.configuracion.material;
			this.UpdateCollider(0f, false);
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x0001DEF5 File Offset: 0x0001C0F5
		private Vector3 GetPenetratedLocalOffset()
		{
			return this.m_localDirCentroHaciaAfuera * this.configuracion.penetratedOffset * this.configuracion.penetratedRadius;
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x0001DF1D File Offset: 0x0001C11D
		private Vector3 GetInitialLocalOffset()
		{
			return this.m_localDirCentroHaciaAfuera * this.configuracion.initialOffset * this.configuracion.initialRadius;
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x0001DF45 File Offset: 0x0001C145
		public Vector3 GetAddedLocalOffset()
		{
			return this.GetPenetratedLocalOffset() - this.m_localDirCentroHaciaAfuera * this.configuracion.penetratedRadius;
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x0001DF68 File Offset: 0x0001C168
		public Vector3 GetEdgeOfColliderWorldPosition()
		{
			Vector3 addedLocalOffset = this.GetAddedLocalOffset();
			return base.transform.TransformPoint(addedLocalOffset);
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0001DF88 File Offset: 0x0001C188
		public void UpdateCollider(float penetrationAnchuraW, bool smooth)
		{
			Vector3 vector = new Vector3(0f, 0f, this.holeConfig.wallCollidersProfundidad * -0.5f);
			Vector3 vector2 = Vector3.Lerp(this.GetInitialLocalOffset(), this.GetPenetratedLocalOffset(), penetrationAnchuraW);
			if (smooth)
			{
				Vector3 vector3 = Vector3.Lerp(this.m_wallCollider.center - vector, vector2, Time.deltaTime * 5f);
				this.m_wallCollider.center = vector + vector3;
			}
			else
			{
				this.m_wallCollider.center = vector + vector2;
			}
			this.m_wallCollider.height = this.holeConfig.wallCollidersProfundidad;
			float num = Mathf.Lerp(this.configuracion.initialRadius, this.configuracion.penetratedRadius, penetrationAnchuraW);
			if (smooth)
			{
				this.m_wallCollider.radius = Mathf.Lerp(this.m_wallCollider.radius, num, Time.deltaTime * 5f);
				return;
			}
			this.m_wallCollider.radius = num;
		}

		// Token: 0x040004EE RID: 1262
		private BoneStretchedChain m_Hole;

		// Token: 0x040004EF RID: 1263
		private CapsuleCollider m_wallCollider;

		// Token: 0x040004F0 RID: 1264
		private HashSet<Collider> m_misColliders;

		// Token: 0x040004F1 RID: 1265
		private Vector3 m_localDirCentroHaciaAfuera;

		// Token: 0x040004F2 RID: 1266
		private float m_magnitudInicial;

		// Token: 0x040004F3 RID: 1267
		public HoleWallPointCollider.Configuracion configuracion = new HoleWallPointCollider.Configuracion();

		// Token: 0x020001BB RID: 443
		[Serializable]
		public class Configuracion
		{
			// Token: 0x040009EE RID: 2542
			public int direction = 2;

			// Token: 0x040009EF RID: 2543
			[Obsolete]
			[HideInInspector]
			public float radius = 0.006f;

			// Token: 0x040009F0 RID: 2544
			[Obsolete]
			[HideInInspector]
			public float offset = 1f;

			// Token: 0x040009F1 RID: 2545
			public PhysicMaterial material;

			// Token: 0x040009F2 RID: 2546
			public float initialRadius = 0.006f;

			// Token: 0x040009F3 RID: 2547
			public float initialOffset = 1f;

			// Token: 0x040009F4 RID: 2548
			public float penetratedRadius = 0.006f;

			// Token: 0x040009F5 RID: 2549
			public float penetratedOffset = 1f;
		}
	}
}
