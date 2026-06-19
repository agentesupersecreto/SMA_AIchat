using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000030 RID: 48
	public abstract class HoleFondoHitSkin : EmulatedHitSkin, IHoleHitSkin
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00006047 File Offset: 0x00004247
		public sealed override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeFixedUpdates1);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000187 RID: 391 RVA: 0x00004252 File Offset: 0x00002452
		public override Side side
		{
			get
			{
				return Side.none;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00006B34 File Offset: 0x00004D34
		public override List<Collider> skinColliders
		{
			get
			{
				return this.m_emptyList;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000189 RID: 393 RVA: 0x00006B3C File Offset: 0x00004D3C
		public override HashSet<Collider> skinCollidersSet
		{
			get
			{
				return this.m_emptySet;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600018A RID: 394 RVA: 0x00006060 File Offset: 0x00004260
		public override Rigidbody rigid
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600018B RID: 395 RVA: 0x00006B44 File Offset: 0x00004D44
		public IReadOnlyList<HoleFondoHitSkin.Check> checksDeCollisiones
		{
			get
			{
				return this.m_checks;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600018C RID: 396 RVA: 0x00006B4C File Offset: 0x00004D4C
		public IReadOnlyDictionary<string, HoleFondoHitSkin.Check> checksDeCollisionesDicc
		{
			get
			{
				return this.m_checksDicc;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600018D RID: 397 RVA: 0x00006B54 File Offset: 0x00004D54
		public IHole hole
		{
			get
			{
				return this.m_hole;
			}
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00006B5C File Offset: 0x00004D5C
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
				bodyPartEnum = BodyPartEnum.fondoAnus;
				break;
			case FemalePenetracionTipo.vag:
				bodyPartEnum = BodyPartEnum.fondoVag;
				break;
			case FemalePenetracionTipo.facial:
				bodyPartEnum = BodyPartEnum.fondoBoca;
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			if (!hole.isStared)
			{
				throw new NotSupportedException();
			}
			this.m_hole = hole;
			SphereCollider sphereCollider = this.m_hole.fondoPhysics.CreateChild("MainFondo").gameObject.AddComponent<SphereCollider>();
			sphereCollider.transform.localPosition = this.m_hole.fondoPhysics.InverseTransformDirection(this.m_hole.worldOutHoleDirection).normalized * -0.01f;
			sphereCollider.radius = 0.001f;
			sphereCollider.isTrigger = true;
			sphereCollider.gameObject.layer = MapaSingleton<ConfiguracionGlobal>.instance.layers.ignoreAll;
			this.m_dummyColliders.Add(sphereCollider);
			for (int i = 0; i < hole.hardPointsList.Count; i++)
			{
				HoleVirtualHardPoint holeVirtualHardPoint = hole.hardPointsList[i];
				SphereCollider sphereCollider2 = this.m_hole.entrada.CreateChild(holeVirtualHardPoint.id).gameObject.AddComponent<SphereCollider>();
				sphereCollider2.radius = 0.001f;
				sphereCollider2.isTrigger = true;
				sphereCollider2.gameObject.layer = MapaSingleton<ConfiguracionGlobal>.instance.layers.ignoreAll;
				this.m_dummyColliders.Add(sphereCollider2);
				this.m_hardPointDeDummyCollider.Add(sphereCollider2, holeVirtualHardPoint);
			}
			HoleFondoHitSkin.UpdateDummyColliderDeFondo(this.m_dummyColliders[0], this.m_hole, this.physicsConfig.radiusInvMod);
			for (int j = 1; j < this.m_dummyColliders.Count; j++)
			{
				HoleVirtualHardPoint holeVirtualHardPoint2 = hole.hardPointsList[j - 1];
				HoleFondoHitSkin.UpdateDummyCollider(this.m_dummyColliders[j], holeVirtualHardPoint2.GetWorldProfundidad(this.m_hole.worldScaleReal), this.m_hole, holeVirtualHardPoint2.GetLocalRadiusFromHole(this.m_hole.worldScaleReal, this.m_hole.worldHoleScale), this.physicsConfig.puntoMiddle);
			}
			for (int k = 0; k < this.m_dummyColliders.Count; k++)
			{
				SphereCollider sphereCollider3 = this.m_dummyColliders[k];
				HoleFondoHitSkin.Check check = new HoleFondoHitSkin.Check(sphereCollider3, 0f, sphereCollider3.name);
				this.m_checks.Add(check);
				this.m_checksDicc.Add(check.id, check);
			}
			base.InitEmulated(bodyPartEnum, hole.fondoPhysics, VisualSkin);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00006DFC File Offset: 0x00004FFC
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			for (int i = 0; i < this.m_dummyColliders.Count; i++)
			{
				SphereCollider sphereCollider = this.m_dummyColliders[i];
				if (sphereCollider)
				{
					Object.Destroy(sphereCollider.gameObject);
				}
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00006E48 File Offset: 0x00005048
		public sealed override void OnUpdateEvent2()
		{
			this.m_doUpdate = this.m_hole.isPenetrated;
			HoleFondoHitSkin.UpdateDummyColliderDeFondo(this.m_dummyColliders[0], this.m_hole, this.physicsConfig.radiusInvMod);
			for (int i = 1; i < this.m_dummyColliders.Count; i++)
			{
				HoleVirtualHardPoint holeVirtualHardPoint = this.hole.hardPointsList[i - 1];
				HoleFondoHitSkin.UpdateDummyCollider(this.m_dummyColliders[i], holeVirtualHardPoint.GetWorldProfundidad(this.m_hole.worldScaleReal), this.m_hole, holeVirtualHardPoint.GetLocalRadiusFromHole(this.m_hole.worldScaleReal, this.m_hole.worldHoleScale), this.physicsConfig.puntoMiddle);
			}
			for (int j = 0; j < this.m_checks.Count; j++)
			{
				this.m_checks[j].ResetWeights();
			}
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00006F28 File Offset: 0x00005128
		private static void UpdateDummyCollider(SphereCollider col, float profundidadGlobal, IHole hole, float radiusLocalDesdeHole, float puntoMiddle)
		{
			Vector3 vector = (hole.isPenetrated ? (-hole.PenetradoPor().tipPhysics.forward) : hole.worldOutHoleDirection);
			col.transform.position = hole.entrada.position - vector * profundidadGlobal;
			col.center = Vector3.zero;
			col.radius = radiusLocalDesdeHole * (1f + puntoMiddle);
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00006F98 File Offset: 0x00005198
		private static void UpdateDummyColliderDeFondo(SphereCollider dummy, IHole hole, float radiusInvMod)
		{
			Vector3 vector = (hole.isPenetrated ? (-hole.PenetradoPor().tipPhysics.forward) : hole.worldOutHoleDirection);
			float num = hole.maxProfundidadPhysicsLocal * hole.worldScaleReal;
			dummy.transform.position = hole.entrada.position - vector * num;
			dummy.center = Vector3.zero;
			float maxProfundidadPhysicsLocal = hole.maxProfundidadPhysicsLocal;
			float num2 = maxProfundidadPhysicsLocal * 0.2f * radiusInvMod;
			float num3 = maxProfundidadPhysicsLocal - num2;
			dummy.radius = num3 * hole.worldScaleReal / hole.worldHoleScale;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000702E File Offset: 0x0000522E
		protected sealed override bool DetectedColliderIsValid(Collider other)
		{
			return this.m_hole.isPenetrated && this.m_hole.IsPenetratedBy(other);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00006B44 File Offset: 0x00004D44
		protected sealed override IReadOnlyList<EmulatedHitSkin.ColliderCheckerBase> ObtenerChecks()
		{
			return this.m_checks;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00006318 File Offset: 0x00004518
		protected sealed override QueryTriggerInteraction ObtenerQueryTriggerInteraction()
		{
			return QueryTriggerInteraction.Collide;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0000631B File Offset: 0x0000451B
		protected sealed override int ObtenerLayersDeCasteo()
		{
			return MapaSingleton<ConfiguracionGlobal>.instance.layers.penes.ToLayerMask();
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000704C File Offset: 0x0000524C
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
				bool flag = true;
				float num2 = 1f;
				HoleVirtualHardPoint holeVirtualHardPoint;
				if (this.m_hardPointDeDummyCollider.TryGetValue(sphereCollider, out holeVirtualHardPoint))
				{
					flag = false;
					num2 = holeVirtualHardPoint.resistenciaMod.OutPow(this.physicsConfig.hardPointsResistenciaOutPower);
				}
				Vector3 worldOutHoleDirection = this.m_hole.worldOutHoleDirection;
				float num3 = sphereCollider.radius * checker.currentColliderEscala;
				float num4 = MathfExtension.InverseLerpConMedio(0f, num3 * this.physicsConfig.puntoMiddle, num3, num).InOutPow(this.physicsConfig.outPower, this.physicsConfig.puntoMiddle);
				IPene pene = this.m_hole.PenetradoPor();
				if (pene != null)
				{
					normalized = Vector3.Lerp(normalized, -(this.m_hole.entrada.position - pene.root.position).normalized, this.penisDirectionInfluence).normalized;
				}
				if (Vector3.Dot(worldOutHoleDirection, normalized) <= 0f)
				{
					if (flag)
					{
						num4 = 1f;
					}
					physicsRelativeVelocity = -worldOutHoleDirection * (this.physicsConfig.maxDepenetrationVelocity * num4 * num2);
				}
				else
				{
					physicsRelativeVelocity = -normalized * (this.physicsConfig.maxDepenetrationVelocity * num4 * num2);
				}
				float num5 = Mathf.InverseLerp(0f, num3, num);
				((HoleFondoHitSkin.Check)checker).AddPenWeigthDeCollider(num5, num5 * num2, otherCollider);
			}
			return true;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00007218 File Offset: 0x00005418
		protected override void AfterProcesarCheckeo()
		{
			for (int i = 0; i < this.m_checks.Count; i++)
			{
				this.m_checks[i].AfterAllAddPensWeigthDeCollider();
			}
		}

		// Token: 0x040000D4 RID: 212
		public const string mainFondoCheckID = "MainFondo";

		// Token: 0x040000D5 RID: 213
		private List<Collider> m_emptyList = new List<Collider>();

		// Token: 0x040000D6 RID: 214
		private HashSet<Collider> m_emptySet = new HashSet<Collider>();

		// Token: 0x040000D7 RID: 215
		[ReadOnlyUI]
		[SerializeField]
		private List<HoleFondoHitSkin.Check> m_checks = new List<HoleFondoHitSkin.Check>();

		// Token: 0x040000D8 RID: 216
		private Dictionary<string, HoleFondoHitSkin.Check> m_checksDicc = new Dictionary<string, HoleFondoHitSkin.Check>();

		// Token: 0x040000D9 RID: 217
		[Range(0f, 1f)]
		public float penisDirectionInfluence = 0.1f;

		// Token: 0x040000DA RID: 218
		private IHole m_hole;

		// Token: 0x040000DB RID: 219
		[ReadOnlyUI]
		[SerializeField]
		private List<SphereCollider> m_dummyColliders = new List<SphereCollider>();

		// Token: 0x040000DC RID: 220
		public HoleFondoHitSkin.PhysicsConfig physicsConfig = new HoleFondoHitSkin.PhysicsConfig();

		// Token: 0x040000DD RID: 221
		private Dictionary<SphereCollider, HoleVirtualHardPoint> m_hardPointDeDummyCollider = new Dictionary<SphereCollider, HoleVirtualHardPoint>();

		// Token: 0x02000031 RID: 49
		[Serializable]
		public class PhysicsConfig
		{
			// Token: 0x040000DE RID: 222
			[Tooltip("1 para aumento linal 2 para aumento exponencial cuadrado 3 cubico... etc")]
			public float outPower = 2f;

			// Token: 0x040000DF RID: 223
			public float maxDepenetrationVelocity = 4f;

			// Token: 0x040000E0 RID: 224
			[Range(0f, 1f)]
			public float puntoMiddle = 0.25f;

			// Token: 0x040000E1 RID: 225
			public float radiusInvMod = 3f;

			// Token: 0x040000E2 RID: 226
			public float hardPointsResistenciaOutPower = 3f;
		}

		// Token: 0x02000032 RID: 50
		[Serializable]
		public sealed class Check : SingleSphereProxyHitSkin.SphereCheck
		{
			// Token: 0x0600019B RID: 411 RVA: 0x000072F6 File Offset: 0x000054F6
			public Check(SphereCollider collider, float offsetEnMetros, string Id)
				: base(collider, offsetEnMetros)
			{
				this.m_id = Id;
			}

			// Token: 0x17000085 RID: 133
			// (get) Token: 0x0600019C RID: 412 RVA: 0x0000731D File Offset: 0x0000551D
			public float lastPenetrationWeightSpacial
			{
				get
				{
					return this.m_maxPenSpacial;
				}
			}

			// Token: 0x17000086 RID: 134
			// (get) Token: 0x0600019D RID: 413 RVA: 0x00007325 File Offset: 0x00005525
			public float lastPenetrationWeightResistente
			{
				get
				{
					return this.m_maxPenConResistencia;
				}
			}

			// Token: 0x17000087 RID: 135
			// (get) Token: 0x0600019E RID: 414 RVA: 0x0000732D File Offset: 0x0000552D
			public string id
			{
				get
				{
					return this.m_id;
				}
			}

			// Token: 0x0600019F RID: 415 RVA: 0x00007335 File Offset: 0x00005535
			public void AddPenWeigthDeCollider(float wSpacial, float wResistente, Collider col)
			{
				this.m_lastPenetrationWeightsSpacial.Add(wSpacial);
				this.m_lastPenetrationWeightsResistente.Add(wResistente);
			}

			// Token: 0x060001A0 RID: 416 RVA: 0x00007350 File Offset: 0x00005550
			public void AfterAllAddPensWeigthDeCollider()
			{
				for (int i = 0; i < this.m_lastPenetrationWeightsSpacial.Count; i++)
				{
					this.m_maxPenSpacial = Mathf.Max(this.m_lastPenetrationWeightsSpacial[i], this.m_maxPenSpacial);
				}
				for (int j = 0; j < this.m_lastPenetrationWeightsResistente.Count; j++)
				{
					this.m_maxPenConResistencia = Mathf.Max(this.m_lastPenetrationWeightsResistente[j], this.m_maxPenConResistencia);
				}
			}

			// Token: 0x060001A1 RID: 417 RVA: 0x000073C4 File Offset: 0x000055C4
			public void ResetWeights()
			{
				this.m_maxPenSpacial = (this.m_maxPenConResistencia = 0f);
				this.m_lastPenetrationWeightsSpacial.Clear();
				this.m_lastPenetrationWeightsResistente.Clear();
			}

			// Token: 0x040000E3 RID: 227
			[SerializeField]
			[ReadOnlyUI]
			private string m_id;

			// Token: 0x040000E4 RID: 228
			[SerializeField]
			[ReadOnlyUI]
			private List<float> m_lastPenetrationWeightsSpacial = new List<float>();

			// Token: 0x040000E5 RID: 229
			[SerializeField]
			[ReadOnlyUI]
			private List<float> m_lastPenetrationWeightsResistente = new List<float>();

			// Token: 0x040000E6 RID: 230
			[SerializeField]
			[ReadOnlyUI]
			private float m_maxPenSpacial;

			// Token: 0x040000E7 RID: 231
			[SerializeField]
			[ReadOnlyUI]
			private float m_maxPenConResistencia;
		}
	}
}
