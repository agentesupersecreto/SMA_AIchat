using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200002A RID: 42
	public class HoleAnchuraHitSkin : EmulatedHitSkin, IHoleHitSkin
	{
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000153 RID: 339 RVA: 0x00006047 File Offset: 0x00004247
		public sealed override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeFixedUpdates1);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000154 RID: 340 RVA: 0x00004252 File Offset: 0x00002452
		public override Side side
		{
			get
			{
				return Side.none;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000155 RID: 341 RVA: 0x00006050 File Offset: 0x00004250
		public override List<Collider> skinColliders
		{
			get
			{
				return this.m_emptyList;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000156 RID: 342 RVA: 0x00006058 File Offset: 0x00004258
		public override HashSet<Collider> skinCollidersSet
		{
			get
			{
				return this.m_emptySet;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000157 RID: 343 RVA: 0x00006060 File Offset: 0x00004260
		public override Rigidbody rigid
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000158 RID: 344 RVA: 0x00006063 File Offset: 0x00004263
		public IReadOnlyList<HoleAnchuraHitSkin.Check> checksDeCollisiones
		{
			get
			{
				return this.m_checks;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000159 RID: 345 RVA: 0x0000606B File Offset: 0x0000426B
		public IHole hole
		{
			get
			{
				return this.m_hole;
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00006074 File Offset: 0x00004274
		public void Init(IHole hole, Skin VisualSkin, FemalePenetracionTipo tipo)
		{
			if (hole == null)
			{
				throw new ArgumentNullException("hole", "hole null reference.");
			}
			BodyPartEnum bodyPartEnum;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				bodyPartEnum = BodyPartEnum.anchoAnus;
				break;
			case FemalePenetracionTipo.vag:
				bodyPartEnum = BodyPartEnum.anchoVag;
				break;
			case FemalePenetracionTipo.facial:
				bodyPartEnum = BodyPartEnum.anchoBoca;
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			if (!hole.isStared)
			{
				throw new NotSupportedException();
			}
			this.m_hole = hole;
			SphereCollider sphereCollider = this.m_hole.entrada.CreateChild("HitSkinAnchuraDummyCollider").gameObject.AddComponent<SphereCollider>();
			sphereCollider.radius = 0.001f;
			sphereCollider.isTrigger = true;
			sphereCollider.gameObject.layer = MapaSingleton<ConfiguracionGlobal>.instance.layers.ignoreAll;
			this.m_dummyCollider = sphereCollider;
			sphereCollider.enabled = false;
			HoleAnchuraHitSkin.UpdateDummyCollider(this.m_dummyCollider, this.m_hole);
			this.m_check = new HoleAnchuraHitSkin.Check(this.m_dummyCollider, 0f, this.m_dummyCollider.name);
			this.m_checks = new HoleAnchuraHitSkin.Check[] { this.m_check };
			base.InitEmulated(bodyPartEnum, hole.entrada, VisualSkin);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0000618E File Offset: 0x0000438E
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_dummyCollider)
			{
				Object.Destroy(this.m_dummyCollider.gameObject);
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x000061B4 File Offset: 0x000043B4
		public sealed override void OnUpdateEvent2()
		{
			this.m_doUpdate = this.m_hole.isPenetrated;
			HoleAnchuraHitSkin.UpdateDummyCollider(this.m_dummyCollider, this.m_hole);
			this.m_check.ResetWeights();
		}

		// Token: 0x0600015D RID: 349 RVA: 0x000061E4 File Offset: 0x000043E4
		private static void UpdateDummyCollider(SphereCollider col, IHole hole)
		{
			Transform transform = col.transform;
			transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			transform.localScale = Vector3.one;
			Transform transform2 = (hole.tieneInternals ? hole.internals.root : hole.entrada);
			float anchuraVirtualUnClampWeigth = hole.anchuraVirtualUnClampWeigth;
			if (anchuraVirtualUnClampWeigth < 0.85f)
			{
				col.enabled = false;
				return;
			}
			if (!col.enabled)
			{
				col.enabled = true;
			}
			float num = hole.maxAnchuraVirtualLocal * 0.5f;
			float profundidadInternalsLocalActual = hole.profundidadInternalsLocalActual;
			float num2 = profundidadInternalsLocalActual + num + 0.001f;
			Vector3 vector = (hole.isPenetrated ? transform2.InverseTransformDirection(hole.PenetradoPor().tipPhysics.forward) : (-Vector3.forward));
			Vector3 vector2 = vector * num2;
			Vector3 vector3 = vector * profundidadInternalsLocalActual;
			float num3 = Mathf.InverseLerp(0.85f, 1.15f, anchuraVirtualUnClampWeigth);
			Vector3 vector4 = Vector3.Lerp(vector2, vector3, num3);
			col.radius = num * hole.worldScaleReal / hole.worldHoleScale;
			col.center = transform.InverseTransformPoint(transform2.TransformPoint(vector4));
		}

		// Token: 0x0600015E RID: 350 RVA: 0x000062FB File Offset: 0x000044FB
		protected sealed override bool DetectedColliderIsValid(Collider other)
		{
			return this.m_hole.isPenetrated && this.m_hole.IsPenetratedBy(other);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00006063 File Offset: 0x00004263
		protected sealed override IReadOnlyList<EmulatedHitSkin.ColliderCheckerBase> ObtenerChecks()
		{
			return this.m_checks;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00006318 File Offset: 0x00004518
		protected sealed override QueryTriggerInteraction ObtenerQueryTriggerInteraction()
		{
			return QueryTriggerInteraction.Collide;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000631B File Offset: 0x0000451B
		protected sealed override int ObtenerLayersDeCasteo()
		{
			return MapaSingleton<ConfiguracionGlobal>.instance.layers.penes.ToLayerMask();
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00006334 File Offset: 0x00004534
		protected sealed override bool UsaPhysicsRelativeVelocity(IColisionEmuladaData data, EmulatedHitSkin.ColliderCheckerBase checker, RaycastHit hit, Vector3 emulatedRelativeVelocity, out Vector3 physicsRelativeVelocity)
		{
			physicsRelativeVelocity = emulatedRelativeVelocity;
			SphereCollider sphereCollider = (SphereCollider)data.ownCollider;
			Collider otherCollider = data.otherCollider;
			Transform transform = sphereCollider.transform;
			Transform transform2 = otherCollider.transform;
			Vector3 normalized;
			float num;
			if (Physics.ComputePenetration(otherCollider, transform2.position, transform2.rotation, sphereCollider, transform.position, transform.rotation, out normalized, out num))
			{
				float num2 = 1f;
				IPene pene = this.m_hole.PenetradoPor();
				if (pene != null)
				{
					normalized = Vector3.Lerp(normalized, -(this.m_hole.entrada.position - pene.root.position).normalized, this.penisDirectionInfluence).normalized;
					num2 = Mathf.InverseLerp(0f, 0.25f, pene.penetratingLengthMod.InPow(2f));
				}
				Vector3 worldOutHoleDirection = this.m_hole.worldOutHoleDirection;
				float num3 = Vector3.Dot(worldOutHoleDirection, normalized);
				float num4 = sphereCollider.radius * checker.currentColliderEscala;
				float num5 = 1f;
				if (num3 <= 0f)
				{
					physicsRelativeVelocity = -worldOutHoleDirection * (this.physicsConfig.maxDepenetrationVelocity * num2);
				}
				else
				{
					num5 = Mathf.InverseLerp(0f, num4, num).InPow(2f);
					physicsRelativeVelocity = -normalized * (this.physicsConfig.maxDepenetrationVelocity * num5 * num2);
				}
				((HoleAnchuraHitSkin.Check)checker).AddPenWeigthDeCollider(Mathf.InverseLerp(0f, num4, num) * num5 * num2, otherCollider);
			}
			return true;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000064C9 File Offset: 0x000046C9
		protected override void AfterProcesarCheckeo()
		{
			this.m_check.AfterAllAddPensWeigthDeCollider();
		}

		// Token: 0x040000B9 RID: 185
		[ReadOnlyUI]
		[SerializeField]
		private HoleAnchuraHitSkin.Check[] m_checks;

		// Token: 0x040000BA RID: 186
		private List<Collider> m_emptyList = new List<Collider>();

		// Token: 0x040000BB RID: 187
		private HashSet<Collider> m_emptySet = new HashSet<Collider>();

		// Token: 0x040000BC RID: 188
		[ReadOnlyUI]
		[SerializeField]
		private HoleAnchuraHitSkin.Check m_check;

		// Token: 0x040000BD RID: 189
		[Range(0f, 1f)]
		public float penisDirectionInfluence = 0.1f;

		// Token: 0x040000BE RID: 190
		private IHole m_hole;

		// Token: 0x040000BF RID: 191
		[ReadOnlyUI]
		[SerializeField]
		private SphereCollider m_dummyCollider;

		// Token: 0x040000C0 RID: 192
		public HoleAnchuraHitSkin.PhysicsConfig physicsConfig = new HoleAnchuraHitSkin.PhysicsConfig();

		// Token: 0x0200002B RID: 43
		[Serializable]
		public class PhysicsConfig
		{
			// Token: 0x040000C1 RID: 193
			public float maxDepenetrationVelocity = 3f;
		}

		// Token: 0x0200002C RID: 44
		[Serializable]
		public sealed class Check : SingleSphereProxyHitSkin.SphereCheck
		{
			// Token: 0x06000166 RID: 358 RVA: 0x0000651D File Offset: 0x0000471D
			public Check(SphereCollider collider, float offsetEnMetros, string Id)
				: base(collider, offsetEnMetros)
			{
				this.m_id = Id;
			}

			// Token: 0x17000071 RID: 113
			// (get) Token: 0x06000167 RID: 359 RVA: 0x00006539 File Offset: 0x00004739
			public float lastPenetrationWeight
			{
				get
				{
					return this.m_max;
				}
			}

			// Token: 0x17000072 RID: 114
			// (get) Token: 0x06000168 RID: 360 RVA: 0x00006541 File Offset: 0x00004741
			public string id
			{
				get
				{
					return this.m_id;
				}
			}

			// Token: 0x06000169 RID: 361 RVA: 0x00006549 File Offset: 0x00004749
			public void AddPenWeigthDeCollider(float w, Collider col)
			{
				this.m_lastPenetrationWeights.Add(w);
			}

			// Token: 0x0600016A RID: 362 RVA: 0x00006558 File Offset: 0x00004758
			public void AfterAllAddPensWeigthDeCollider()
			{
				for (int i = 0; i < this.m_lastPenetrationWeights.Count; i++)
				{
					this.m_max = Mathf.Max(this.m_lastPenetrationWeights[i], this.m_max);
				}
			}

			// Token: 0x0600016B RID: 363 RVA: 0x00006598 File Offset: 0x00004798
			public void ResetWeights()
			{
				this.m_max = 0f;
				this.m_lastPenetrationWeights.Clear();
			}

			// Token: 0x040000C2 RID: 194
			[SerializeField]
			[ReadOnlyUI]
			private string m_id;

			// Token: 0x040000C3 RID: 195
			[SerializeField]
			[ReadOnlyUI]
			private List<float> m_lastPenetrationWeights = new List<float>();

			// Token: 0x040000C4 RID: 196
			[SerializeField]
			[ReadOnlyUI]
			private float m_max;
		}
	}
}
