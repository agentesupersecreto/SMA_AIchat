using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Runtime.Guias;
using Assets.TValle.MeshCalcules.ShapingSkinningPoints.Runtime.VertexPoints.SkinningShaping.SystemasLocales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita
{
	// Token: 0x0200008A RID: 138
	public class LabioPointCollider : BodyPartCollider
	{
		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x0000BCDE File Offset: 0x00009EDE
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.onAI2);
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x060003E3 RID: 995 RVA: 0x0000BCE7 File Offset: 0x00009EE7
		public float escala
		{
			get
			{
				return this.m_escala;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x0000BCEF File Offset: 0x00009EEF
		protected override HashSet<Collider> misColliders
		{
			get
			{
				return this.m_misColliders;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x0000BCF7 File Offset: 0x00009EF7
		public override float contactOffset
		{
			get
			{
				return 0.001f;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x0000BCFE File Offset: 0x00009EFE
		public SphereCollider main
		{
			get
			{
				return this.m_collider;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x0000BD06 File Offset: 0x00009F06
		public LabioPoint punto
		{
			get
			{
				return this.m_punto;
			}
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0000BD0E File Offset: 0x00009F0E
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetManualStart();
			base.SetInicializable();
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0000BD24 File Offset: 0x00009F24
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			Animator bodyAnimator = this.GetRoot().bodyAnimator;
			Renderer renderer = MapaSingleton<MapaSingletonDeMainSkins>.instance.ObtenerRenderer(bodyAnimator, MapaSingleton<MapaSingletonDeMainSkins>.instance.body);
			this.m_boneGuias = renderer.GetComponentInChildren<CollecionDeGuiasSlaveChildOf>();
			this.m_guias = renderer.GetComponentInChildren<SysLocSkinShapeVertexTransforms>();
			if (this.m_boneGuias == null)
			{
				throw new ArgumentNullException("m_boneGuias", "m_boneGuias null reference.");
			}
			if (this.m_guias == null)
			{
				throw new ArgumentNullException("m_guias", "m_guias null reference.");
			}
			this.m_collider = this.GetComponentNotNull<SphereCollider>();
			if (this.configuracion.material != null)
			{
				this.m_collider.sharedMaterial = this.configuracion.material;
			}
			this.configuracion.UpdateRadiusMod(0f, false);
			this.m_collider.radius = this.configuracion.radius * this.configuracion.currentRadiusMod;
			this.m_misColliders = new HashSet<Collider> { this.m_collider };
			base.initColliders();
			this.m_fixer = this.GetComponentNotNull<LabioPointColliderOverStretchFixer>();
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0000BE40 File Offset: 0x0000A040
		public void Init(string boneGuiaName, string guiaNameForward, string guiaNameEdge, LabioPoint Punto)
		{
			this.m_boneGuiaName = boneGuiaName;
			this.m_guiaNameForward = guiaNameForward;
			this.m_guiaNameEdge = guiaNameEdge;
			if (Punto == null)
			{
				throw new ArgumentNullException("Punto", "Punto null reference.");
			}
			this.m_punto = Punto;
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0000BE90 File Offset: 0x0000A090
		public override void OnUpdateEvent1()
		{
			if (!this.m_guias.initiated)
			{
				return;
			}
			Transform transform;
			if (!this.m_guias.transPorNombre.TryGetValue(this.m_guiaNameForward, out transform))
			{
				throw new InvalidOperationException();
			}
			Transform transform2;
			if (!this.m_guias.transPorNombre.TryGetValue(this.m_guiaNameEdge, out transform2))
			{
				throw new InvalidOperationException();
			}
			Vector3 position = transform.position;
			Vector3 vector = transform2.position - position;
			Vector3 vector2 = Vector3.Cross(transform.forward, transform2.forward);
			Vector3 normalized = Vector3.Cross(vector.normalized, vector2.normalized).normalized;
			Quaternion quaternion = Quaternion.LookRotation(vector, -normalized);
			quaternion *= Quaternion.AngleAxis(45f, -Vector3.right);
			Vector3 vector3 = position + quaternion * Vector3.forward * vector.magnitude * 0.70710677f;
			Transform transform3 = this.m_collider.transform;
			Vector3 vector4 = transform3.InverseTransformPoint(vector3);
			Vector3 vector5 = transform3.InverseTransformPoint(position);
			this.m_collider.center = vector4;
			this.m_collider.radius = (vector4 - vector5).magnitude * this.configuracion.currentRadiusMod;
			this.m_escala = transform3.lossyScale.Escala();
		}

		// Token: 0x0400023D RID: 573
		private SphereCollider m_collider;

		// Token: 0x0400023E RID: 574
		private HashSet<Collider> m_misColliders;

		// Token: 0x0400023F RID: 575
		public LabioPointCollider.Configuracion configuracion = new LabioPointCollider.Configuracion();

		// Token: 0x04000240 RID: 576
		[SerializeField]
		[ReadOnlyUI]
		private float m_escala;

		// Token: 0x04000241 RID: 577
		[SerializeField]
		[ReadOnlyUI]
		private string m_boneGuiaName;

		// Token: 0x04000242 RID: 578
		[SerializeField]
		[ReadOnlyUI]
		private string m_guiaNameForward;

		// Token: 0x04000243 RID: 579
		[SerializeField]
		[ReadOnlyUI]
		private string m_guiaNameEdge;

		// Token: 0x04000244 RID: 580
		[SerializeField]
		[ReadOnlyUI]
		private LabioPoint m_punto;

		// Token: 0x04000245 RID: 581
		private CollecionDeGuiasSlaveChildOf m_boneGuias;

		// Token: 0x04000246 RID: 582
		private SysLocSkinShapeVertexTransforms m_guias;

		// Token: 0x04000247 RID: 583
		private LabioPointColliderOverStretchFixer m_fixer;

		// Token: 0x02000182 RID: 386
		[Serializable]
		public class Configuracion
		{
			// Token: 0x17000504 RID: 1284
			// (get) Token: 0x06000E9F RID: 3743 RVA: 0x00031FCC File Offset: 0x000301CC
			public float currentRadiusMod
			{
				get
				{
					return this.m_currentRadiusMod;
				}
			}

			// Token: 0x06000EA0 RID: 3744 RVA: 0x00031FD4 File Offset: 0x000301D4
			public void UpdateRadiusMod(float penetrationAnchuraW, bool smooth)
			{
				float num = Mathf.Lerp(this.initialRadiusMod, this.penetratedRadiusMod, penetrationAnchuraW);
				if (smooth)
				{
					this.m_currentRadiusMod = Mathf.Lerp(this.m_currentRadiusMod, num, Time.deltaTime * 5f);
					return;
				}
				this.m_currentRadiusMod = num;
			}

			// Token: 0x040008AE RID: 2222
			public PhysicMaterial material;

			// Token: 0x040008AF RID: 2223
			public float radius = 0.0075f;

			// Token: 0x040008B0 RID: 2224
			[Obsolete]
			[HideInInspector]
			public float radiusMod = 1f;

			// Token: 0x040008B1 RID: 2225
			public float initialRadiusMod = 1f;

			// Token: 0x040008B2 RID: 2226
			public float penetratedRadiusMod = 1f;

			// Token: 0x040008B3 RID: 2227
			[ReadOnlyUI]
			[SerializeField]
			private float m_currentRadiusMod = 1f;
		}
	}
}
