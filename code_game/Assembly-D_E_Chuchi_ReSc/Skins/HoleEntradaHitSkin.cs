using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200002D RID: 45
	public abstract class HoleEntradaHitSkin : EmulatedHitSkin, IHoleHitSkin
	{
		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600016C RID: 364 RVA: 0x00006047 File Offset: 0x00004247
		public sealed override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeFixedUpdates1);
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600016D RID: 365 RVA: 0x00004252 File Offset: 0x00002452
		public override Side side
		{
			get
			{
				return Side.none;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600016E RID: 366 RVA: 0x000065B0 File Offset: 0x000047B0
		public override List<Collider> skinColliders
		{
			get
			{
				return this.m_emptyList;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600016F RID: 367 RVA: 0x000065B8 File Offset: 0x000047B8
		public override HashSet<Collider> skinCollidersSet
		{
			get
			{
				return this.m_emptySet;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000170 RID: 368 RVA: 0x00006060 File Offset: 0x00004260
		public override Rigidbody rigid
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000171 RID: 369 RVA: 0x000065C0 File Offset: 0x000047C0
		public IReadOnlyList<HoleEntradaHitSkin.Check> checksDeCollisiones
		{
			get
			{
				return this.m_checks;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000172 RID: 370 RVA: 0x000065C8 File Offset: 0x000047C8
		public IReadOnlyDictionary<string, HoleEntradaHitSkin.Check> checksDeCollisionesDicc
		{
			get
			{
				return this.m_checksDicc;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000173 RID: 371 RVA: 0x000065D0 File Offset: 0x000047D0
		public IHole hole
		{
			get
			{
				return this.m_hole;
			}
		}

		// Token: 0x06000174 RID: 372 RVA: 0x000065D8 File Offset: 0x000047D8
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
				bodyPartEnum = BodyPartEnum.entradaAnus;
				break;
			case FemalePenetracionTipo.vag:
				bodyPartEnum = BodyPartEnum.entradaVag;
				break;
			case FemalePenetracionTipo.facial:
				bodyPartEnum = BodyPartEnum.entradaBoca;
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			if (!hole.isStared)
			{
				throw new NotSupportedException();
			}
			this.m_hole = hole;
			SphereCollider sphereCollider = this.m_hole.entrada.CreateChild("HitSkinEntradaDummyCollider").gameObject.AddComponent<SphereCollider>();
			sphereCollider.transform.rotation = Quaternion.LookRotation(this.m_hole.worldOutHoleDirection, this.m_hole.worldUpHoleDirection);
			sphereCollider.radius = 0.001f;
			sphereCollider.isTrigger = true;
			sphereCollider.gameObject.layer = MapaSingleton<ConfiguracionGlobal>.instance.layers.ignoreAll;
			this.m_dummyCollider = sphereCollider;
			HoleEntradaHitSkin.UpdateDummyColliderDeEntrada(this.m_dummyCollider, this.m_hole, this.physicsConfig.radiusInvMod);
			HoleEntradaHitSkin.Check check = new HoleEntradaHitSkin.Check(this.m_dummyCollider, 0f, this.m_dummyCollider.name);
			this.m_checks.Add(check);
			this.m_checksDicc.Add(check.id, check);
			base.InitEmulated(bodyPartEnum, hole.fondoPhysics, VisualSkin);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00006720 File Offset: 0x00004920
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_dummyCollider)
			{
				Object.Destroy(this.m_dummyCollider.gameObject);
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00006748 File Offset: 0x00004948
		public sealed override void OnUpdateEvent2()
		{
			this.m_doUpdate = this.m_hole.isPenetrated;
			HoleEntradaHitSkin.UpdateDummyColliderDeEntrada(this.m_dummyCollider, this.m_hole, this.physicsConfig.radiusInvMod);
			for (int i = 0; i < this.m_checks.Count; i++)
			{
				this.m_checks[i].ResetWeights();
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x000067AC File Offset: 0x000049AC
		private static void UpdateDummyColliderDeEntrada(SphereCollider dummy, IHole hole, float radiusInvMod)
		{
			dummy.transform.rotation = Quaternion.LookRotation(hole.worldOutHoleDirection, hole.worldUpHoleDirection);
			float num = 0.010000001f * radiusInvMod;
			float num2 = 0.05f - num;
			dummy.radius = num2 * hole.worldScaleReal / hole.worldHoleScale;
			float num3 = 0.03f * hole.worldScaleReal / hole.worldHoleScale;
			dummy.center = Vector3.forward * num3;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000681F File Offset: 0x00004A1F
		protected sealed override bool DetectedColliderIsValid(Collider other)
		{
			return this.m_hole.isPenetrated && this.m_hole.IsPenetratedBy(other) && this.m_hole.PenetradoPor().EsPuntaOrLastPart(other);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000065C0 File Offset: 0x000047C0
		protected sealed override IReadOnlyList<EmulatedHitSkin.ColliderCheckerBase> ObtenerChecks()
		{
			return this.m_checks;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00006318 File Offset: 0x00004518
		protected sealed override QueryTriggerInteraction ObtenerQueryTriggerInteraction()
		{
			return QueryTriggerInteraction.Collide;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000631B File Offset: 0x0000451B
		protected sealed override int ObtenerLayersDeCasteo()
		{
			return MapaSingleton<ConfiguracionGlobal>.instance.layers.penes.ToLayerMask();
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00006850 File Offset: 0x00004A50
		protected sealed override bool UsaPhysicsRelativeVelocity(IColisionEmuladaData data, EmulatedHitSkin.ColliderCheckerBase checker, RaycastHit hit, Vector3 emulatedRelativeVelocity, out Vector3 physicsRelativeVelocity)
		{
			physicsRelativeVelocity = emulatedRelativeVelocity;
			SphereCollider sphereCollider = (SphereCollider)data.ownCollider;
			Collider otherCollider = data.otherCollider;
			Transform transform = sphereCollider.transform;
			Transform transform2 = otherCollider.transform;
			Vector3 vector;
			float num;
			bool flag = Physics.ComputePenetration(otherCollider, transform2.position, transform2.rotation, sphereCollider, transform.position, transform.rotation, out vector, out num);
			vector = -vector;
			if (flag)
			{
				float num2 = 1f;
				Vector3 worldOutHoleDirection = this.m_hole.worldOutHoleDirection;
				float num3 = sphereCollider.radius * checker.currentColliderEscala;
				float num4 = MathfExtension.InverseLerpConMedio(0f, num3 * this.physicsConfig.puntoMiddle, num3, num).InOutPow(this.physicsConfig.outPower, this.physicsConfig.puntoMiddle);
				IPene pene = this.m_hole.PenetradoPor();
				if (pene != null)
				{
					vector = Vector3.Lerp(vector, (pene.root.position - this.m_hole.entrada.position).normalized, this.penisDirectionInfluence).normalized;
				}
				float num5 = Vector3.Dot(worldOutHoleDirection, emulatedRelativeVelocity);
				float num6 = MathfExtension.InverseLerpConMedio(-1f, 0f, 1f, num5);
				num6 = MathfExtension.LerpConMedio(0f, 0.333f, 1f, num6);
				physicsRelativeVelocity = vector * (this.physicsConfig.maxDepenetrationVelocity * num4 * num2) * num6;
				((HoleEntradaHitSkin.Check)checker).AddPenWeigthDeCollider(Mathf.InverseLerp(0f, num3, num) * num2, otherCollider);
			}
			return true;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x000069E4 File Offset: 0x00004BE4
		protected override void AfterProcesarCheckeo()
		{
			for (int i = 0; i < this.m_checks.Count; i++)
			{
				this.m_checks[i].AfterAllAddPensWeigthDeCollider();
			}
		}

		// Token: 0x040000C5 RID: 197
		private List<Collider> m_emptyList = new List<Collider>();

		// Token: 0x040000C6 RID: 198
		private HashSet<Collider> m_emptySet = new HashSet<Collider>();

		// Token: 0x040000C7 RID: 199
		[ReadOnlyUI]
		[SerializeField]
		private List<HoleEntradaHitSkin.Check> m_checks = new List<HoleEntradaHitSkin.Check>();

		// Token: 0x040000C8 RID: 200
		private Dictionary<string, HoleEntradaHitSkin.Check> m_checksDicc = new Dictionary<string, HoleEntradaHitSkin.Check>();

		// Token: 0x040000C9 RID: 201
		[Range(0f, 1f)]
		public float penisDirectionInfluence = 0.9f;

		// Token: 0x040000CA RID: 202
		private IHole m_hole;

		// Token: 0x040000CB RID: 203
		[ReadOnlyUI]
		[SerializeField]
		private SphereCollider m_dummyCollider;

		// Token: 0x040000CC RID: 204
		public HoleEntradaHitSkin.PhysicsConfig physicsConfig = new HoleEntradaHitSkin.PhysicsConfig();

		// Token: 0x0200002E RID: 46
		[Serializable]
		public class PhysicsConfig
		{
			// Token: 0x040000CD RID: 205
			[Tooltip("1 para aumento linal 2 para aumento exponencial cuadrado 3 cubico... etc")]
			public float outPower = 2f;

			// Token: 0x040000CE RID: 206
			public float maxDepenetrationVelocity = 4f;

			// Token: 0x040000CF RID: 207
			[Range(0f, 1f)]
			public float puntoMiddle = 0.25f;

			// Token: 0x040000D0 RID: 208
			public float radiusInvMod = 1f;
		}

		// Token: 0x0200002F RID: 47
		[Serializable]
		public sealed class Check : SingleSphereProxyHitSkin.SphereCheck
		{
			// Token: 0x06000180 RID: 384 RVA: 0x00006AA1 File Offset: 0x00004CA1
			public Check(SphereCollider collider, float offsetEnMetros, string Id)
				: base(collider, offsetEnMetros)
			{
				this.m_id = Id;
			}

			// Token: 0x1700007B RID: 123
			// (get) Token: 0x06000181 RID: 385 RVA: 0x00006ABD File Offset: 0x00004CBD
			public float lastPenetrationWeight
			{
				get
				{
					return this.m_max;
				}
			}

			// Token: 0x1700007C RID: 124
			// (get) Token: 0x06000182 RID: 386 RVA: 0x00006AC5 File Offset: 0x00004CC5
			public string id
			{
				get
				{
					return this.m_id;
				}
			}

			// Token: 0x06000183 RID: 387 RVA: 0x00006ACD File Offset: 0x00004CCD
			public void AddPenWeigthDeCollider(float w, Collider col)
			{
				this.m_lastPenetrationWeights.Add(w);
			}

			// Token: 0x06000184 RID: 388 RVA: 0x00006ADC File Offset: 0x00004CDC
			public void AfterAllAddPensWeigthDeCollider()
			{
				for (int i = 0; i < this.m_lastPenetrationWeights.Count; i++)
				{
					this.m_max = Mathf.Max(this.m_lastPenetrationWeights[i], this.m_max);
				}
			}

			// Token: 0x06000185 RID: 389 RVA: 0x00006B1C File Offset: 0x00004D1C
			public void ResetWeights()
			{
				this.m_max = 0f;
				this.m_lastPenetrationWeights.Clear();
			}

			// Token: 0x040000D1 RID: 209
			[SerializeField]
			[ReadOnlyUI]
			private string m_id;

			// Token: 0x040000D2 RID: 210
			[SerializeField]
			[ReadOnlyUI]
			private List<float> m_lastPenetrationWeights = new List<float>();

			// Token: 0x040000D3 RID: 211
			[SerializeField]
			[ReadOnlyUI]
			private float m_max;
		}
	}
}
