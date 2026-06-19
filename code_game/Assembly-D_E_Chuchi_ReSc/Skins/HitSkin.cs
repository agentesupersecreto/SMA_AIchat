using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Skins;
using Assets.TValle.BeachGirl.Runtime.Skins.PhysicsScripts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000023 RID: 35
	public abstract class HitSkin : HitSkinBasica, IUserDeCollisionesPhysicas<HitSkin.Colision>, IBasicUser<HitSkin.Colision, Collision>, IStepVelocitySaverEmulated, IStepVelocitySaver, IUnityColisionable, IColisionableContraColliders, ICollisionable, IColisionableContraColliders<HitSkin.Colision>, IHitSkinEstimulablePorToques, IEstimulablePorToques, IComponentStartable
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00004ECA File Offset: 0x000030CA
		public IMassModifier massModifier
		{
			get
			{
				return this.m_Saver.massModifier;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00004ED7 File Offset: 0x000030D7
		public Vector3 velocidadEnDeltaTime
		{
			get
			{
				return this.m_Saver.velocidadEnDeltaTime;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00004EE4 File Offset: 0x000030E4
		[Obsolete("", true)]
		public Vector3 velocidadEnFixedDeltaTime
		{
			get
			{
				return this.m_Saver.velocidadEnFixedDeltaTime;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00004EF1 File Offset: 0x000030F1
		public Vector3 metrosPorSegundo
		{
			get
			{
				return this.m_Saver.metrosPorSegundo;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00004EFE File Offset: 0x000030FE
		public bool usaRigidBody
		{
			get
			{
				return this.m_Saver.usaRigidBody;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x00004F0B File Offset: 0x0000310B
		public Vector3 physicsMetrosPorSegundo
		{
			get
			{
				return this.m_Saver.physicsMetrosPorSegundo;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00004F18 File Offset: 0x00003118
		public sealed override int updateEvent1Index
		{
			get
			{
				return 66;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x00004F1C File Offset: 0x0000311C
		public sealed override int updateEvent2Index
		{
			get
			{
				return 28;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00004F20 File Offset: 0x00003120
		public HitPartEnum hitParte
		{
			get
			{
				return this.m_hitParte;
			}
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060000EA RID: 234 RVA: 0x00004F28 File Offset: 0x00003128
		// (remove) Token: 0x060000EB RID: 235 RVA: 0x00004F60 File Offset: 0x00003160
		public event Action<Collision> onCollisionEnter;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060000EC RID: 236 RVA: 0x00004F98 File Offset: 0x00003198
		// (remove) Token: 0x060000ED RID: 237 RVA: 0x00004FD0 File Offset: 0x000031D0
		public event Action<Collision> onCollisionStay;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060000EE RID: 238 RVA: 0x00005008 File Offset: 0x00003208
		// (remove) Token: 0x060000EF RID: 239 RVA: 0x00005040 File Offset: 0x00003240
		public event Action<Collision> onCollisionExit;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060000F0 RID: 240 RVA: 0x00005075 File Offset: 0x00003275
		// (remove) Token: 0x060000F1 RID: 241 RVA: 0x00005083 File Offset: 0x00003283
		event Action<ColisionBasicaV2> IColisionableContraColliders.collisionEnterBase
		{
			add
			{
				this.m_HistorialColisionesContraColliders.collisionEnterBase += value;
			}
			remove
			{
				this.m_HistorialColisionesContraColliders.collisionEnterBase -= value;
			}
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060000F2 RID: 242 RVA: 0x00005091 File Offset: 0x00003291
		// (remove) Token: 0x060000F3 RID: 243 RVA: 0x0000509F File Offset: 0x0000329F
		event Action<ColisionBasicaV2> IColisionableContraColliders.collisionStayBase
		{
			add
			{
				this.m_HistorialColisionesContraColliders.collisionStayBase += value;
			}
			remove
			{
				this.m_HistorialColisionesContraColliders.collisionStayBase -= value;
			}
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060000F4 RID: 244 RVA: 0x000050AD File Offset: 0x000032AD
		// (remove) Token: 0x060000F5 RID: 245 RVA: 0x000050BB File Offset: 0x000032BB
		event Action<ColisionBasicaV2> IColisionableContraColliders.collisionExitBase
		{
			add
			{
				this.m_HistorialColisionesContraColliders.collisionExitBase += value;
			}
			remove
			{
				this.m_HistorialColisionesContraColliders.collisionExitBase -= value;
			}
		}

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060000F6 RID: 246 RVA: 0x000050C9 File Offset: 0x000032C9
		// (remove) Token: 0x060000F7 RID: 247 RVA: 0x000050D7 File Offset: 0x000032D7
		event Action<HitSkin.Colision> IColisionableContraColliders<HitSkin.Colision>.collisionEnter
		{
			add
			{
				this.m_HistorialColisionesContraColliders.collisionEnter += value;
			}
			remove
			{
				this.m_HistorialColisionesContraColliders.collisionEnter -= value;
			}
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060000F8 RID: 248 RVA: 0x000050E5 File Offset: 0x000032E5
		// (remove) Token: 0x060000F9 RID: 249 RVA: 0x000050F3 File Offset: 0x000032F3
		event Action<HitSkin.Colision> IColisionableContraColliders<HitSkin.Colision>.collisionStay
		{
			add
			{
				this.m_HistorialColisionesContraColliders.collisionStay += value;
			}
			remove
			{
				this.m_HistorialColisionesContraColliders.collisionStay -= value;
			}
		}

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060000FA RID: 250 RVA: 0x00005101 File Offset: 0x00003301
		// (remove) Token: 0x060000FB RID: 251 RVA: 0x0000510F File Offset: 0x0000330F
		event Action<HitSkin.Colision> IColisionableContraColliders<HitSkin.Colision>.collisionExit
		{
			add
			{
				this.m_HistorialColisionesContraColliders.collisionExit += value;
			}
			remove
			{
				this.m_HistorialColisionesContraColliders.collisionExit -= value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000FC RID: 252 RVA: 0x0000511D File Offset: 0x0000331D
		// (set) Token: 0x060000FD RID: 253 RVA: 0x00005125 File Offset: 0x00003325
		public bool autoFollowTarget
		{
			get
			{
				return this.m_autofollowTarget;
			}
			set
			{
				this.m_autofollowTarget = value;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000FE RID: 254 RVA: 0x0000512E File Offset: 0x0000332E
		public sealed override Rigidbody rigid
		{
			get
			{
				return this.m_rigid;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00005136 File Offset: 0x00003336
		public HistorialDeCollisionesPhysicas<HitSkin.Colision> historialDeCollisionesContraColliders
		{
			get
			{
				return this.m_HistorialColisionesContraColliders;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000100 RID: 256 RVA: 0x0000513E File Offset: 0x0000333E
		public ModificableDeFloat modificableDeFriccionGeneral
		{
			get
			{
				return this.m_modificableDeFriccionGeneral;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00005146 File Offset: 0x00003346
		public float defaultStaticFriccion
		{
			get
			{
				return this.m_defaultStaticFricc;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000102 RID: 258 RVA: 0x0000514E File Offset: 0x0000334E
		public float defaultDynamicFriccion
		{
			get
			{
				return this.m_defaultDynamicFricc;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00005156 File Offset: 0x00003356
		public HitSkin.TouchedByObj touchedByCharacteres
		{
			get
			{
				return this.m_TouchedByCharacteres;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000104 RID: 260 RVA: 0x0000515E File Offset: 0x0000335E
		protected virtual bool? isKinematic
		{
			get
			{
				return new bool?(true);
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00005168 File Offset: 0x00003368
		public PhysicMaterial ownPhysicMaterial
		{
			get
			{
				if (this.m_OwnPhysicMaterial == null)
				{
					this.m_OwnPhysicMaterial = this.ObtenerClonePhysicMaterial();
					if (this.m_OwnPhysicMaterial == null)
					{
						throw new ArgumentNullException("m_OwnPhysicMaterial", "m_OwnPhysicMaterial null reference.");
					}
					this.m_defaultStaticFricc = this.m_OwnPhysicMaterial.staticFriction;
					this.m_defaultDynamicFricc = this.m_OwnPhysicMaterial.dynamicFriction;
				}
				return this.m_OwnPhysicMaterial;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00005156 File Offset: 0x00003356
		public sealed override EstimuledBy touchedBy
		{
			get
			{
				return this.m_TouchedByCharacteres;
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000051D8 File Offset: 0x000033D8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_rigid = this.GetComponentNotNull<Rigidbody>();
			if (this.isKinematic != null)
			{
				this.m_rigid.isKinematic = this.isKinematic.Value;
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00005220 File Offset: 0x00003420
		public virtual void Init(HitPartEnum hitParte, Transform boneTarget, Skin VisualSkin)
		{
			this.m_PrioridadesDeObjetoEstimulado = this.GetComponentEnRoot(false);
			if (this.m_PrioridadesDeObjetoEstimulado == null)
			{
				throw new ArgumentNullException("m_PrioridadesDeObjetoEstimulado", "m_PrioridadesDeObjetoEstimulado null reference.");
			}
			this.m_hitParte = hitParte;
			this.m_HistorialColisionesContraColliders = new HistorialDeCollisionesPhysicas<HitSkin.Colision>(this);
			this.m_HistorialColisionesContraColliders.collisionEnter += this.OnEnter;
			this.m_HistorialColisionesContraColliders.collisionStay += this.OnStay;
			this.m_HistorialColisionesContraColliders.collisionExit += this.OnExit;
			this.m_TouchedByCharacteres = new HitSkin.TouchedByObj(this, this.m_PrioridadesDeObjetoEstimulado, new TouchedBy<TocanteObjeto, HitSkin, HitSkin.Colision, HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats>.Config
			{
				buscarEn = TouchedBy<TocanteObjeto, HitSkin, HitSkin.Colision, HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats>.BuscarEn.colliders,
				buscarEnPadres = true
			});
			this.m_Saver = this.rigid.transform.GetComponentNotNull<EmulatedStepVelocitySaver>();
			this.m_myCharacter = base.GetComponentInParent<Character>();
			base.InitBasica(boneTarget, VisualSkin);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000052FC File Offset: 0x000034FC
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (!base.isHitSkinInit)
			{
				Debug.LogWarning("Skin: " + base.GetType().Name + " no fue iniciada.", base.gameObject);
				throw new InvalidOperationException();
			}
			foreach (Collider collider in this.skinColliders)
			{
				collider.sharedMaterial = this.ownPhysicMaterial;
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0000538C File Offset: 0x0000358C
		public sealed override bool IsTouchedBy(ICharacter character, List<EstimuloTactil> toques)
		{
			return this.m_TouchedByCharacteres.ContieneEstimulosDeCharacter<EstimuloTactil>(character, toques);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00004538 File Offset: 0x00002738
		public bool ContieneCollider(Collider collider)
		{
			return this.skinCollidersSet.Contains(collider);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000539B File Offset: 0x0000359B
		protected virtual PhysicMaterial ObtenerClonePhysicMaterial()
		{
			return Object.Instantiate<PhysicMaterial>(Singleton<ColecionDePhysicsMaterials>.instance.skin);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000053AC File Offset: 0x000035AC
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_OwnPhysicMaterial != null)
			{
				Object.DestroyImmediate(this.m_OwnPhysicMaterial);
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000053CE File Offset: 0x000035CE
		public void ObtenerCollider(List<Collider> result)
		{
			base.GetComponentsInChildren<Collider>(result);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000053D8 File Offset: 0x000035D8
		public sealed override void OnUpdateEvent1()
		{
			float num = this.m_modificableDeFriccionGeneral.ModificarValor(1f);
			if (this.m_LastModFriccionGeneral == null || !ExtendedMonoBehaviour.AlmostEqual(this.m_LastModFriccionGeneral.Value, num, 0.01f))
			{
				this.m_LastModFriccionGeneral = new float?(num);
				this.m_OwnPhysicMaterial.dynamicFriction = this.m_defaultDynamicFricc * num;
				this.m_OwnPhysicMaterial.staticFriction = this.m_defaultStaticFricc * num;
			}
			if (this.m_debugDrawDistanceBetweenSkinAndBone)
			{
				Vector3 position = this.rigid.transform.position;
				Vector3 position2 = base.boneTarget.position;
			}
			if (this.m_autofollowTarget)
			{
				base.FollowTargetBone();
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00005480 File Offset: 0x00003680
		public sealed override void OnUpdateEvent2()
		{
			this.m_HistorialColisionesContraColliders.debugReport = this.customUpdatedConfig.profilePerformance;
			this.m_HistorialColisionesContraColliders.AfterCollision();
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000054A3 File Offset: 0x000036A3
		private void OnCollisionEnter(Collision collision)
		{
			bool profileCollisionsEvents = this.m_profileCollisionsEvents;
			Action<Collision> action = this.onCollisionEnter;
			if (action != null)
			{
				action(collision);
			}
			this.m_HistorialColisionesContraColliders.OnCollisionEnter(collision);
			bool profileCollisionsEvents2 = this.m_profileCollisionsEvents;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000054D1 File Offset: 0x000036D1
		private void OnCollisionStay(Collision collision)
		{
			bool profileCollisionsEvents = this.m_profileCollisionsEvents;
			Action<Collision> action = this.onCollisionStay;
			if (action != null)
			{
				action(collision);
			}
			this.m_HistorialColisionesContraColliders.OnCollisionStay(collision);
			bool profileCollisionsEvents2 = this.m_profileCollisionsEvents;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000054FF File Offset: 0x000036FF
		private void OnCollisionExit(Collision collision)
		{
			bool profileCollisionsEvents = this.m_profileCollisionsEvents;
			Action<Collision> action = this.onCollisionExit;
			if (action != null)
			{
				action(collision);
			}
			this.m_HistorialColisionesContraColliders.OnCollisionExit(collision);
			bool profileCollisionsEvents2 = this.m_profileCollisionsEvents;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00005530 File Offset: 0x00003730
		bool IBasicUser<HitSkin.Colision, Collision>.PoblarColision(HitSkin.Colision fromPool, Collision collision)
		{
			bool flag;
			try
			{
				RaycastHit raycastHit;
				if (!this.CalcularPuntoYNormal(collision, null, out raycastHit, null, null, this.isDebug || this.m_debugDrawColisionCalcules))
				{
					flag = false;
				}
				else
				{
					this.CalcularPartesImpactadas(raycastHit, this.m_temp);
					if (this.m_debugLog)
					{
						MonoBehaviour.print("**partes Impactadas");
						foreach (BodyPartEnum bodyPartEnum in this.m_temp)
						{
							MonoBehaviour.print(bodyPartEnum.ToString());
						}
					}
					fromPool.Poblar(this, collision, raycastHit, this.m_temp);
					flag = true;
				}
			}
			finally
			{
				this.m_temp.Clear();
			}
			return flag;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00005614 File Offset: 0x00003814
		protected virtual void OnEnter(HitSkin.Colision collision)
		{
			if (this.isDebug || this.m_debugLog || this.m_debugDraw)
			{
				if (this.m_debugLog)
				{
					Debug.Log(string.Concat(new string[]
					{
						base.name,
						"->OnEnter: parte impactada: ",
						collision.partesImpactadas[0].ToString(),
						". impacto contra: ",
						collision.rigidbodyChocandonos.name
					}), base.gameObject);
				}
				bool debugDraw = this.m_debugDraw;
			}
			bool debugDrawRelativeVelocity = this.m_debugDrawRelativeVelocity;
			bool debugDrawImpulse = this.m_debugDrawImpulse;
			if (collision.chocandonosTieneRigidbody)
			{
				collision.rigidbodyChocandonos.GetComponents<ISkinOnCollisionEnterListiner>(HitSkin.m_enterListenersTemp);
			}
			else
			{
				collision.colliderChocandonos.GetComponents<ISkinOnCollisionEnterListiner>(HitSkin.m_enterListenersTemp);
			}
			try
			{
				for (int i = 0; i < HitSkin.m_enterListenersTemp.Count; i++)
				{
					ISkinOnCollisionEnterListiner skinOnCollisionEnterListiner = HitSkin.m_enterListenersTemp[i];
					if (skinOnCollisionEnterListiner != null)
					{
						skinOnCollisionEnterListiner.OnEnter(collision, this);
					}
				}
			}
			finally
			{
				HitSkin.m_enterListenersTemp.Clear();
			}
			IHitSkinCollisionListener component = collision.colliderChocandonos.GetComponent<IHitSkinCollisionListener>();
			if (component != null)
			{
				component.OnEnter(collision);
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000573C File Offset: 0x0000393C
		protected virtual void OnStay(HitSkin.Colision collision)
		{
			if (this.isDebug || this.m_debugLog || this.m_debugDraw)
			{
				if (this.m_debugLog)
				{
					Debug.Log(string.Concat(new string[]
					{
						base.name,
						"->OnStay: parte impactada: ",
						collision.partesImpactadas[0].ToString(),
						". impacto contra: ",
						collision.rigidbodyChocandonos.name
					}), base.gameObject);
				}
				bool debugDraw = this.m_debugDraw;
			}
			bool debugDrawRelativeVelocity = this.m_debugDrawRelativeVelocity;
			bool debugDrawImpulse = this.m_debugDrawImpulse;
			if (collision.chocandonosTieneRigidbody)
			{
				collision.rigidbodyChocandonos.GetComponents<ISkinOnCollisionStayListiner>(HitSkin.m_stayListenersTemp);
			}
			else
			{
				collision.colliderChocandonos.GetComponents<ISkinOnCollisionStayListiner>(HitSkin.m_stayListenersTemp);
			}
			try
			{
				for (int i = 0; i < HitSkin.m_stayListenersTemp.Count; i++)
				{
					ISkinOnCollisionStayListiner skinOnCollisionStayListiner = HitSkin.m_stayListenersTemp[i];
					if (skinOnCollisionStayListiner != null)
					{
						skinOnCollisionStayListiner.OnStay(collision, this);
					}
				}
			}
			finally
			{
				HitSkin.m_stayListenersTemp.Clear();
			}
			IHitSkinCollisionListener component = collision.colliderChocandonos.GetComponent<IHitSkinCollisionListener>();
			if (component != null)
			{
				component.OnStay(collision);
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00005864 File Offset: 0x00003A64
		protected virtual void OnExit(HitSkin.Colision lastCollision)
		{
			if (base.applicationQuit)
			{
				return;
			}
			if (this.isDebug || this.m_debugLog || this.m_debugDraw)
			{
				if (this.m_debugLog)
				{
					Debug.Log(string.Concat(new string[]
					{
						base.name,
						"->OnExit: parte impactada: ",
						lastCollision.partesImpactadas[0].ToString(),
						". impacto contra: ",
						lastCollision.rigidbodyChocandonos.name
					}), base.gameObject);
				}
				bool debugDraw = this.m_debugDraw;
			}
			bool debugDrawRelativeVelocity = this.m_debugDrawRelativeVelocity;
			bool debugDrawImpulse = this.m_debugDrawImpulse;
			if (lastCollision.chocandonosTieneRigidbody)
			{
				if (lastCollision.rigidbodyChocandonos)
				{
					lastCollision.rigidbodyChocandonos.GetComponents<ISkinOnCollisionExitListiner>(HitSkin.m_exiListenersTemp);
				}
			}
			else if (lastCollision.colliderChocandonos)
			{
				lastCollision.colliderChocandonos.GetComponents<ISkinOnCollisionExitListiner>(HitSkin.m_exiListenersTemp);
			}
			try
			{
				for (int i = 0; i < HitSkin.m_exiListenersTemp.Count; i++)
				{
					ISkinOnCollisionExitListiner skinOnCollisionExitListiner = HitSkin.m_exiListenersTemp[i];
					if (skinOnCollisionExitListiner != null)
					{
						skinOnCollisionExitListiner.OnExit(lastCollision, this);
					}
				}
			}
			finally
			{
				HitSkin.m_exiListenersTemp.Clear();
			}
			if (lastCollision.colliderChocandonos != null)
			{
				IHitSkinCollisionListener component = lastCollision.colliderChocandonos.GetComponent<IHitSkinCollisionListener>();
				if (component != null)
				{
					component.OnExit(lastCollision);
				}
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x000059BC File Offset: 0x00003BBC
		public sealed override bool TryCalcularPartesImpactadasDeCollision(Collision collision, Collider ownCollider, out RaycastHit hit, IList<BodyPartEnum> result, Vector3? impactDirection = null, Vector3? impactPoint = null, bool debugDraw = false)
		{
			return this.CalcularPuntoYNormal(collision, ownCollider, out hit, impactDirection, impactPoint, debugDraw) && this.CalcularPartesImpactadas(hit, result);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000059DF File Offset: 0x00003BDF
		public sealed override bool TryCalcularPartesImpactadasDeCollision(Vector3 collisionPunto, Vector3 collisionNormal, Collider ownCollider, out RaycastHit hit, IList<BodyPartEnum> result, bool debugDraw = false)
		{
			return this.CalcularPuntoYNormal(collisionPunto, collisionNormal, ownCollider, out hit, debugDraw) && this.CalcularPartesImpactadas(hit, result);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00005A01 File Offset: 0x00003C01
		protected bool CalcularPuntoYNormal(Collision collision, Collider ownCollider, out RaycastHit hit, Vector3? impactDirection = null, Vector3? impactPoint = null, bool debugDraw = false)
		{
			return collision.TryCastCollision(this.m_promediarContactos, true, out hit, ownCollider, impactDirection, impactPoint, debugDraw);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00005A18 File Offset: 0x00003C18
		protected bool CalcularPuntoYNormal(Vector3 collisionPunto, Vector3 collisionNormal, Collider ownCollider, out RaycastHit hit, bool debugDraw = false)
		{
			return ExtendedMonoBehaviour.TryGetHitFormCollider(ownCollider, collisionPunto, collisionNormal, true, out hit, ownCollider.contactOffset, 1f, debugDraw, 1f);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00005A42 File Offset: 0x00003C42
		[Obsolete("ahora se devulven varias partes impactadas", true)]
		protected bool CalcularParteImpactada(Collision collision, RaycastHit hit, out BodyPartEnum parte)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600011D RID: 285
		protected abstract bool CalcularPartesImpactadas(RaycastHit hit, IList<BodyPartEnum> result);

		// Token: 0x06000120 RID: 288 RVA: 0x00005A9A File Offset: 0x00003C9A
		string IStepVelocitySaver.get_name()
		{
			return base.name;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool IStepVelocitySaver.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00005AAA File Offset: 0x00003CAA
		void IStepVelocitySaver.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00005AB3 File Offset: 0x00003CB3
		Transform IStepVelocitySaver.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000097 RID: 151
		private Character m_myCharacter;

		// Token: 0x04000098 RID: 152
		[SerializeField]
		[ReadOnlyUI]
		private Rigidbody m_rigid;

		// Token: 0x04000099 RID: 153
		[SerializeField]
		[ReadOnlyUI]
		private HitPartEnum m_hitParte;

		// Token: 0x0400009A RID: 154
		[SerializeField]
		private bool m_profileCollisionsEvents;

		// Token: 0x0400009B RID: 155
		[SerializeField]
		private bool m_autofollowTarget = true;

		// Token: 0x0400009C RID: 156
		[SerializeField]
		private bool m_debugLog;

		// Token: 0x0400009D RID: 157
		[SerializeField]
		private bool m_debugDraw;

		// Token: 0x0400009E RID: 158
		[SerializeField]
		private bool m_debugDrawColisionCalcules;

		// Token: 0x0400009F RID: 159
		[SerializeField]
		private bool m_debugDrawRelativeVelocity;

		// Token: 0x040000A0 RID: 160
		[SerializeField]
		private bool m_debugDrawImpulse;

		// Token: 0x040000A1 RID: 161
		[SerializeField]
		private bool m_promediarContactos = true;

		// Token: 0x040000A2 RID: 162
		[SerializeField]
		private bool m_debugDrawDistanceBetweenSkinAndBone;

		// Token: 0x040000A3 RID: 163
		private EmulatedStepVelocitySaver m_Saver;

		// Token: 0x040000A4 RID: 164
		private IParteDelCuerpoHumanoPrioridades m_PrioridadesDeObjetoEstimulado;

		// Token: 0x040000A5 RID: 165
		[SerializeField]
		private HistorialDeCollisionesPhysicas<HitSkin.Colision> m_HistorialColisionesContraColliders;

		// Token: 0x040000A6 RID: 166
		private ModificableDeFloat m_modificableDeFriccionGeneral = new ModificableDeFloat(1f);

		// Token: 0x040000A7 RID: 167
		private float m_defaultStaticFricc;

		// Token: 0x040000A8 RID: 168
		private float m_defaultDynamicFricc;

		// Token: 0x040000A9 RID: 169
		private float? m_LastModFriccionGeneral;

		// Token: 0x040000AA RID: 170
		private HitSkin.TouchedByObj m_TouchedByCharacteres;

		// Token: 0x040000AB RID: 171
		private PhysicMaterial m_OwnPhysicMaterial;

		// Token: 0x040000AC RID: 172
		private List<BodyPartEnum> m_temp = new List<BodyPartEnum>();

		// Token: 0x040000AD RID: 173
		private static List<ISkinOnCollisionEnterListiner> m_enterListenersTemp = new List<ISkinOnCollisionEnterListiner>();

		// Token: 0x040000AE RID: 174
		private static List<ISkinOnCollisionStayListiner> m_stayListenersTemp = new List<ISkinOnCollisionStayListiner>();

		// Token: 0x040000AF RID: 175
		private static List<ISkinOnCollisionExitListiner> m_exiListenersTemp = new List<ISkinOnCollisionExitListiner>();

		// Token: 0x02000024 RID: 36
		[Serializable]
		public sealed class Colision : HitSkinColision, IColisionContraBodyPartes
		{
			// Token: 0x17000057 RID: 87
			// (get) Token: 0x06000124 RID: 292 RVA: 0x00005ABB File Offset: 0x00003CBB
			// (set) Token: 0x06000125 RID: 293 RVA: 0x00005AC3 File Offset: 0x00003CC3
			public HitSkin hitSkin { get; private set; }

			// Token: 0x17000058 RID: 88
			// (get) Token: 0x06000126 RID: 294 RVA: 0x00005ACC File Offset: 0x00003CCC
			// (set) Token: 0x06000127 RID: 295 RVA: 0x00005AD4 File Offset: 0x00003CD4
			public IList<BodyPartEnum> partesImpactadas { get; private set; }

			// Token: 0x17000059 RID: 89
			// (get) Token: 0x06000128 RID: 296 RVA: 0x00005ADD File Offset: 0x00003CDD
			IReadOnlyList<BodyPartEnum> IColisionContraBodyPartes.partesImpactadas
			{
				get
				{
					return (List<BodyPartEnum>)this.partesImpactadas;
				}
			}

			// Token: 0x06000129 RID: 297 RVA: 0x00005AEC File Offset: 0x00003CEC
			public void Poblar(HitSkin skin, Collision collision, RaycastHit hit, IList<BodyPartEnum> partesImpactadasCopia)
			{
				if (skin == null)
				{
					throw new ArgumentNullException("skin", "skin null reference.");
				}
				this.hitSkin = skin;
				if (this.partesImpactadas == null)
				{
					this.partesImpactadas = new List<BodyPartEnum>();
				}
				if (this.partesImpactadas.Count > 0)
				{
					this.partesImpactadas.Clear();
				}
				for (int i = 0; i < partesImpactadasCopia.Count; i++)
				{
					this.partesImpactadas.Add(partesImpactadasCopia[i]);
				}
				try
				{
					for (int j = 0; j < partesImpactadasCopia.Count; j++)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano = partesImpactadasCopia[j].ParseAParteHumana();
						if (HitSkin.Colision.m_TEMp2.Add((int)parteDelCuerpoHumano))
						{
							HitSkin.Colision.m_TEMp.Add(parteDelCuerpoHumano);
						}
					}
					base.Poblar(skin, skin, skin.boneTarget, collision, hit, HitSkin.Colision.m_TEMp);
				}
				finally
				{
					HitSkin.Colision.m_TEMp2.Clear();
					HitSkin.Colision.m_TEMp.Clear();
				}
			}

			// Token: 0x0600012A RID: 298 RVA: 0x00005BE0 File Offset: 0x00003DE0
			protected override void OnClearPhysica()
			{
				base.OnClearPhysica();
				this.hitSkin = null;
				if (this.partesImpactadas != null)
				{
					this.partesImpactadas.Clear();
				}
			}

			// Token: 0x040000B2 RID: 178
			private static List<ParteDelCuerpoHumano> m_TEMp = new List<ParteDelCuerpoHumano>();

			// Token: 0x040000B3 RID: 179
			private static HashSet<int> m_TEMp2 = new HashSet<int>();
		}

		// Token: 0x02000025 RID: 37
		public sealed class TouchedByObj : HitSkin.TouchedBy<TocanteObjeto>
		{
			// Token: 0x0600012D RID: 301 RVA: 0x00005C20 File Offset: 0x00003E20
			public TouchedByObj(HitSkin skin, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado, TouchedBy<TocanteObjeto, HitSkin, HitSkin.Colision, HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats>.Config config)
				: base(skin, PrioridadesDeObjetoEstimulado, config)
			{
			}
		}

		// Token: 0x02000026 RID: 38
		public class TouchedBy<T> : TouchedBy<T, HitSkin, HitSkin.Colision, HitSkin.TouchedBy<T>.SkinTouchStats> where T : TocanteObjeto
		{
			// Token: 0x0600012E RID: 302 RVA: 0x00005C2B File Offset: 0x00003E2B
			public TouchedBy(HitSkin skin, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado, TouchedBy<T, HitSkin, HitSkin.Colision, HitSkin.TouchedBy<T>.SkinTouchStats>.Config config)
				: base(skin, PrioridadesDeObjetoEstimulado, skin.historialDeCollisionesContraColliders, config)
			{
				if (skin == null)
				{
					throw new ArgumentNullException("skin", "skin null reference.");
				}
				if (config == null)
				{
					throw new ArgumentNullException("config", "config null reference.");
				}
			}

			// Token: 0x02000027 RID: 39
			[Serializable]
			public sealed class SkinTouchStats : TouchedBy<T, HitSkin, HitSkin.Colision, HitSkin.TouchedBy<T>.SkinTouchStats>.TouchStats
			{
				// Token: 0x1700005A RID: 90
				// (get) Token: 0x0600012F RID: 303 RVA: 0x00005C68 File Offset: 0x00003E68
				// (set) Token: 0x06000130 RID: 304 RVA: 0x00005C70 File Offset: 0x00003E70
				public List<BodyPartEnum> partesTocadasLista { get; private set; }

				// Token: 0x1700005B RID: 91
				// (get) Token: 0x06000131 RID: 305 RVA: 0x00005C79 File Offset: 0x00003E79
				// (set) Token: 0x06000132 RID: 306 RVA: 0x00005C81 File Offset: 0x00003E81
				public HashSet<int> partesTocadasSet { get; private set; }

				// Token: 0x06000133 RID: 307 RVA: 0x00005C8C File Offset: 0x00003E8C
				public override void Poblar(T sub, HitSkin owner, IParteDelCuerpoHumanoPrioridades touchedMonoPrioridades, List<HitSkin.Colision> cols, bool limpiar)
				{
					if (this.partesTocadasLista == null)
					{
						this.partesTocadasLista = new List<BodyPartEnum>(10);
					}
					if (this.partesTocadasSet == null)
					{
						this.partesTocadasSet = new HashSet<int>();
					}
					if (limpiar)
					{
						this.clear();
					}
					for (int i = 0; i < cols.Count; i++)
					{
						HitSkin.Colision colision = cols[i];
						for (int j = 0; j < colision.partesImpactadas.Count; j++)
						{
							BodyPartEnum bodyPartEnum = colision.partesImpactadas[j];
							if (this.partesTocadasSet.Add((int)bodyPartEnum))
							{
								this.partesTocadasLista.Add(bodyPartEnum);
							}
						}
					}
					base.Poblar(sub, owner, touchedMonoPrioridades, cols, false);
				}

				// Token: 0x06000134 RID: 308 RVA: 0x00005D30 File Offset: 0x00003F30
				protected override Side ObtenerSide(T sub, HitSkin owner, List<HitSkin.Colision> cols)
				{
					Side side = base.ObtenerSide(sub, owner, cols);
					if (side != Side.none)
					{
						return side;
					}
					int i = 0;
					while (i < this.partesTocadasLista.Count)
					{
						switch (this.partesTocadasLista[i])
						{
						case BodyPartEnum.cabeza:
						case BodyPartEnum.cuello:
						case BodyPartEnum.mandibula:
						case BodyPartEnum.boca:
						case BodyPartEnum.bocaInterno:
						case BodyPartEnum.nariz:
						case BodyPartEnum.frente:
						case BodyPartEnum.pecho:
						case BodyPartEnum.espalda:
						case BodyPartEnum.abdomen:
						case BodyPartEnum.cintura:
						case BodyPartEnum.coxis:
						case BodyPartEnum.vientre:
						case BodyPartEnum.vagina:
						case BodyPartEnum.perineo:
						case BodyPartEnum.anoHole:
						case BodyPartEnum.vagHole:
						case BodyPartEnum.hombligo:
						case BodyPartEnum.lengua:
							i++;
							break;
						case BodyPartEnum.mejilla_L:
						case BodyPartEnum.ojo_L:
						case BodyPartEnum.ojoInterno_L:
						case BodyPartEnum.ceja_L:
						case BodyPartEnum.ciene_L:
						case BodyPartEnum.hombro_L:
						case BodyPartEnum.axila_L:
						case BodyPartEnum.brazo_L:
						case BodyPartEnum.anteBrazo_L:
						case BodyPartEnum.mano_L:
						case BodyPartEnum.seno_L:
						case BodyPartEnum.pezon_L:
						case BodyPartEnum.cadera_L:
						case BodyPartEnum.nalga_L:
						case BodyPartEnum.pierna_L:
						case BodyPartEnum.rodilla_L:
						case BodyPartEnum.canilla_L:
						case BodyPartEnum.pie_L:
							return Side.L;
						case BodyPartEnum.mejilla_R:
						case BodyPartEnum.ojo_R:
						case BodyPartEnum.ojoInterno_R:
						case BodyPartEnum.ceja_R:
						case BodyPartEnum.ciene_R:
						case BodyPartEnum.hombro_R:
						case BodyPartEnum.axila_R:
						case BodyPartEnum.brazo_R:
						case BodyPartEnum.anteBrazo_R:
						case BodyPartEnum.mano_R:
						case BodyPartEnum.seno_R:
						case BodyPartEnum.pezon_R:
						case BodyPartEnum.cadera_R:
						case BodyPartEnum.nalga_R:
						case BodyPartEnum.pierna_R:
						case BodyPartEnum.rodilla_R:
						case BodyPartEnum.canilla_R:
						case BodyPartEnum.pie_R:
							return Side.R;
						default:
							throw new ArgumentOutOfRangeException(this.partesTocadasLista[i].ToString());
						}
					}
					return Side.none;
				}

				// Token: 0x06000135 RID: 309 RVA: 0x00005E7E File Offset: 0x0000407E
				private void clear()
				{
					if (this.partesTocadasLista != null)
					{
						this.partesTocadasLista.Clear();
					}
					if (this.partesTocadasSet != null)
					{
						this.partesTocadasSet.Clear();
					}
				}

				// Token: 0x06000136 RID: 310 RVA: 0x00005EA6 File Offset: 0x000040A6
				public sealed override void Clear()
				{
					base.Clear();
					this.clear();
				}

				// Token: 0x06000137 RID: 311 RVA: 0x00005EB4 File Offset: 0x000040B4
				protected override void CargarPartesTocadas()
				{
					List<BodyPartEnum> partesTocadasLista = this.partesTocadasLista;
					for (int i = 0; i < partesTocadasLista.Count; i++)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano = partesTocadasLista[i].ParseAParteHumana();
						base.AddParteEstimulada(parteDelCuerpoHumano);
					}
				}
			}
		}
	}
}
