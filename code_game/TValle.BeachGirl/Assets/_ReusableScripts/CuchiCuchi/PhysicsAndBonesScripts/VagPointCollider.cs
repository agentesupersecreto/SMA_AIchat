using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000ED RID: 237
	public class VagPointCollider : BodyPartCollider
	{
		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x060009E3 RID: 2531 RVA: 0x0001FC56 File Offset: 0x0001DE56
		// (set) Token: 0x060009E4 RID: 2532 RVA: 0x0001FC5E File Offset: 0x0001DE5E
		public GlobalUpdater.UpdateType updateEvent
		{
			get
			{
				return this.m_UpdateEvent;
			}
			set
			{
				this.m_UpdateEvent = value;
			}
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x060009E5 RID: 2533 RVA: 0x0001FC67 File Offset: 0x0001DE67
		public sealed override int updateEvent1Index
		{
			get
			{
				return (int)this.m_UpdateEvent;
			}
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x060009E6 RID: 2534 RVA: 0x0001FC6F File Offset: 0x0001DE6F
		public Transform coliderSegundarioTransform
		{
			get
			{
				return this.m_coliderSegundarioTransform;
			}
		}

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x060009E7 RID: 2535 RVA: 0x0001FC77 File Offset: 0x0001DE77
		public Collider wallCollider
		{
			get
			{
				return this.m_wallCollider;
			}
		}

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x060009E8 RID: 2536 RVA: 0x0001FC7F File Offset: 0x0001DE7F
		public Collider apertureCollider
		{
			get
			{
				return this.m_apertureCollider;
			}
		}

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x060009E9 RID: 2537 RVA: 0x0001FC87 File Offset: 0x0001DE87
		protected BoneStretchedChain.HoleConfig holeConfig
		{
			get
			{
				return this.m_VagHole.holeConfig;
			}
		}

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x060009EA RID: 2538 RVA: 0x0001FC94 File Offset: 0x0001DE94
		protected override HashSet<Collider> misColliders
		{
			get
			{
				return this.m_misColliders;
			}
		}

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x060009EB RID: 2539 RVA: 0x0001FC9C File Offset: 0x0001DE9C
		public override float contactOffset
		{
			get
			{
				return 0.001f;
			}
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x0001FCA3 File Offset: 0x0001DEA3
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x0001FCAB File Offset: 0x0001DEAB
		public void ActualizarAperturaDireccionPorDefecto(Vector3 worldDirection)
		{
			this.coliderSegundarioTransform.forward = worldDirection;
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x0001FCBC File Offset: 0x0001DEBC
		public void CrearColliders(VagHole vagHole, Circular8BoneChain.Punto p)
		{
			this.m_puntoEnum = p;
			this.m_VagHole = vagHole;
			CapsuleCollider componentNotNull = this.GetComponentNotNull<CapsuleCollider>();
			this.m_wallCollider = componentNotNull;
			this.ConfigurarCollider(vagHole.centroDePuntos.position);
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x0001FCF6 File Offset: 0x0001DEF6
		public void InitColliders()
		{
			this.m_misColliders = new HashSet<Collider> { this.m_wallCollider };
			if (this.m_apertureCollider != null)
			{
				this.m_misColliders.Add(this.m_apertureCollider);
			}
			base.initColliders();
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x0001FD38 File Offset: 0x0001DF38
		public void CrearColliderApertura(VagHole vagHole)
		{
			this.CrearTrasnformApertura();
			CapsuleCollider componentNotNull = this.m_coliderSegundarioTransform.GetComponentNotNull<CapsuleCollider>();
			this.m_apertureCollider = componentNotNull;
			this.ConfigurarColliderApertura(componentNotNull);
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x0001FD65 File Offset: 0x0001DF65
		public override void OnUpdateEvent1()
		{
			if (this.coliderSegundarioTransform)
			{
				this.AcualizarSegundarioScala();
			}
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x0001FD7C File Offset: 0x0001DF7C
		private float ObtenerMagnitudDeDireccionClitBaseA12()
		{
			Transform clitBaseTransform = this.m_VagHole.clitBaseTransform;
			return base.transform.InverseTransformPoint(clitBaseTransform.position).magnitude;
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x0001FDB0 File Offset: 0x0001DFB0
		private float ObtenerMagnitudDeDireccionClitBaseACentro()
		{
			Transform clitBaseTransform = this.m_VagHole.clitBaseTransform;
			return this.m_VagHole.centroDePuntos.InverseTransformPoint(clitBaseTransform.position).magnitude;
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x0001FDE8 File Offset: 0x0001DFE8
		private float ObtenerMagnitudDeDireccionPuntoACentro()
		{
			Transform centroDePuntos = this.m_VagHole.centroDePuntos;
			return base.transform.InverseTransformPoint(centroDePuntos.position).magnitude;
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x0001FE1C File Offset: 0x0001E01C
		public void AcualizarSegundarioScala()
		{
			float num = this.ObtenerMagnitudDeDireccionClitBaseA12();
			float num2 = this.ObtenerMagnitudDeDireccionClitBaseACentro();
			float num3 = this.ObtenerMagnitudDeDireccionPuntoACentro();
			float num4 = num / this.m_magnitudInicial;
			if (num3 >= num2)
			{
				num4 = 0f;
			}
			if (!float.IsNaN(num4))
			{
				this.m_coliderSegundarioTransform.localScale = new Vector3(1f, 1f, num4);
			}
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x0001FE74 File Offset: 0x0001E074
		private void ConfigurarCollider(Vector3 wCentroDePuntos)
		{
			Vector3 vector = base.transform.position - wCentroDePuntos;
			this.m_localDirCentroHaciaAfuera = base.transform.InverseTransformDirection(vector).normalized;
			this.m_wallCollider.direction = this.configuracion.direction;
			this.m_wallCollider.sharedMaterial = this.configuracion.material;
			this.UpdateCollider(0f, false);
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x0001FEE5 File Offset: 0x0001E0E5
		private Vector3 GetPenetratedLocalOffset()
		{
			return this.m_localDirCentroHaciaAfuera * this.configuracion.penetratedOffset * this.configuracion.penetratedRadius;
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x0001FF0D File Offset: 0x0001E10D
		private Vector3 GetInitialLocalOffset()
		{
			return this.m_localDirCentroHaciaAfuera * this.configuracion.initialOffset * this.configuracion.initialRadius;
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x0001FF35 File Offset: 0x0001E135
		public Vector3 GetAddedLocalOffset()
		{
			return this.GetPenetratedLocalOffset() - this.m_localDirCentroHaciaAfuera * this.configuracion.penetratedRadius;
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x0001FF58 File Offset: 0x0001E158
		public Vector3 GetEdgeOfColliderWorldPosition()
		{
			Vector3 addedLocalOffset = this.GetAddedLocalOffset();
			return base.transform.TransformPoint(addedLocalOffset);
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x0001FF78 File Offset: 0x0001E178
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

		// Token: 0x060009FC RID: 2556 RVA: 0x00020070 File Offset: 0x0001E270
		private void ConfigurarColliderApertura(CapsuleCollider collider)
		{
			this.m_coliderSegundarioTransform.localScale = Vector3.one;
			float num = this.ObtenerMagnitudDeDireccionClitBaseA12();
			float num2 = (this.m_magnitudInicial = num);
			collider.center = new Vector3(0f, 0f, num2 * 0.5f - this.configuracion.aperuraConfig.radius);
			collider.direction = this.configuracion.aperuraConfig.direction;
			collider.height = num2;
			collider.radius = this.configuracion.aperuraConfig.radius;
			collider.sharedMaterial = this.configuracion.material;
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x00020110 File Offset: 0x0001E310
		private void CrearTrasnformApertura()
		{
			Transform transform = base.transform;
			Transform centroDePuntos = this.m_VagHole.centroDePuntos;
			Vector3 normalized = (transform.position - centroDePuntos.position).normalized;
			Vector3 worldOutHoleDirection = this.m_VagHole.worldOutHoleDirection;
			Vector3 normalized2 = Vector3.Slerp(normalized, worldOutHoleDirection, this.configuracion.aperuraConfig.colliderSecundarioAngleMod).normalized;
			float num = 1f;
			float num2 = 1f;
			Circular8BoneChain.Punto puntoEnum = this.m_puntoEnum;
			if (puntoEnum == Circular8BoneChain.Punto._130 || puntoEnum == Circular8BoneChain.Punto._1030)
			{
				num *= 1.5f;
				num2 *= 0.5f;
			}
			Transform transform2 = new GameObject(base.name + "_ColliderDeApertura").transform;
			transform2.gameObject.layer = base.gameObject.layer;
			transform2.parent = transform;
			transform2.position = transform.position - transform.forward * this.configuracion.aperuraConfig.radius * num2 + normalized2 * this.configuracion.aperuraConfig.radius * num;
			transform2.rotation = Quaternion.LookRotation(normalized2, worldOutHoleDirection);
			this.m_coliderSegundarioTransform = transform2;
		}

		// Token: 0x04000544 RID: 1348
		[SerializeField]
		protected GlobalUpdater.UpdateType m_UpdateEvent = GlobalUpdater.UpdateType.fixedUpdate1;

		// Token: 0x04000545 RID: 1349
		private Vector3 m_localDirCentroHaciaAfuera;

		// Token: 0x04000546 RID: 1350
		[ReadOnlyUI]
		[SerializeField]
		private Circular8BoneChain.Punto m_puntoEnum;

		// Token: 0x04000547 RID: 1351
		private VagHole m_VagHole;

		// Token: 0x04000548 RID: 1352
		private Transform m_coliderSegundarioTransform;

		// Token: 0x04000549 RID: 1353
		private CapsuleCollider m_wallCollider;

		// Token: 0x0400054A RID: 1354
		private CapsuleCollider m_apertureCollider;

		// Token: 0x0400054B RID: 1355
		private HashSet<Collider> m_misColliders;

		// Token: 0x0400054C RID: 1356
		private float m_magnitudInicial;

		// Token: 0x0400054D RID: 1357
		public VagPointCollider.Configuracion configuracion = new VagPointCollider.Configuracion();

		// Token: 0x020001C3 RID: 451
		[Serializable]
		public class Configuracion
		{
			// Token: 0x04000A0D RID: 2573
			[Obsolete("ahora se usa la profundidad de la vag", true)]
			[NonSerialized]
			public Vector3 center = new Vector3(0f, 0f, -0.05f);

			// Token: 0x04000A0E RID: 2574
			public int direction = 2;

			// Token: 0x04000A0F RID: 2575
			[Obsolete("ahora se usa la profundidad de la vag", true)]
			[NonSerialized]
			public float height = 0.1f;

			// Token: 0x04000A10 RID: 2576
			[Obsolete]
			[HideInInspector]
			public float radius = 0.008f;

			// Token: 0x04000A11 RID: 2577
			[Obsolete]
			[HideInInspector]
			public float offset = 1f;

			// Token: 0x04000A12 RID: 2578
			public PhysicMaterial material;

			// Token: 0x04000A13 RID: 2579
			public VagPointCollider.AperuraConfig aperuraConfig;

			// Token: 0x04000A14 RID: 2580
			public float initialRadius = 0.008f;

			// Token: 0x04000A15 RID: 2581
			public float initialOffset = 1f;

			// Token: 0x04000A16 RID: 2582
			public float penetratedRadius = 0.008f;

			// Token: 0x04000A17 RID: 2583
			public float penetratedOffset = 1f;
		}

		// Token: 0x020001C4 RID: 452
		[Serializable]
		public class AperuraConfig
		{
			// Token: 0x1700051F RID: 1311
			// (get) Token: 0x06000F57 RID: 3927 RVA: 0x00034511 File Offset: 0x00032711
			public float colliderSecundarioAngleMod
			{
				get
				{
					return this.angleV4 / 90f;
				}
			}

			// Token: 0x04000A18 RID: 2584
			[Range(0f, 90f)]
			public float angleV4 = 3.4f;

			// Token: 0x04000A19 RID: 2585
			public int direction = 2;

			// Token: 0x04000A1A RID: 2586
			public float largo = 0.012f;

			// Token: 0x04000A1B RID: 2587
			public float radius = 0.008f;
		}
	}
}
