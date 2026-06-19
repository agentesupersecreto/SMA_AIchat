using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Behaviours.Runtime.Physcis;
using Assets.Base.Bones.Runtime.V2.ConstraintsV2.Users;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.SystemasConstraints.StretchToConstraints.Abstracts;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Puntos;
using InterfaceFields;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Semens
{
	// Token: 0x0200006F RID: 111
	public sealed class SemenPunto : AplicableCustomMonobehaviour
	{
		// Token: 0x14000012 RID: 18
		// (add) Token: 0x0600022E RID: 558 RVA: 0x00006234 File Offset: 0x00004434
		// (remove) Token: 0x0600022F RID: 559 RVA: 0x0000626C File Offset: 0x0000446C
		public event SemenPunto.OnBindingHandler onBinding;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000230 RID: 560 RVA: 0x000062A4 File Offset: 0x000044A4
		// (remove) Token: 0x06000231 RID: 561 RVA: 0x000062DC File Offset: 0x000044DC
		public event SemenPunto.OnBindedHandler onBinded;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000232 RID: 562 RVA: 0x00006314 File Offset: 0x00004514
		// (remove) Token: 0x06000233 RID: 563 RVA: 0x0000634C File Offset: 0x0000454C
		public event Action<SemenPunto> onUnBinded;

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000234 RID: 564 RVA: 0x00006384 File Offset: 0x00004584
		// (remove) Token: 0x06000235 RID: 565 RVA: 0x000063BC File Offset: 0x000045BC
		public event Action<SemenPunto> onBreak;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000236 RID: 566 RVA: 0x000063F4 File Offset: 0x000045F4
		// (remove) Token: 0x06000237 RID: 567 RVA: 0x0000642C File Offset: 0x0000462C
		public event Action<SemenPunto> onBreakRested;

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000238 RID: 568 RVA: 0x00006461 File Offset: 0x00004661
		public ModificableDeFloat duracionModificador
		{
			get
			{
				return this.m_duracionModificador;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000239 RID: 569 RVA: 0x00006469 File Offset: 0x00004669
		public IStepVelocitySaverEmulated stepVelocity
		{
			get
			{
				return this.m_EmulatedStepVelocitySaver;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x0600023A RID: 570 RVA: 0x00006471 File Offset: 0x00004671
		public bool isBinded
		{
			get
			{
				return this.m_isBinded;
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600023B RID: 571 RVA: 0x00006479 File Offset: 0x00004679
		public bool isManualMode
		{
			get
			{
				return this.m_isManualMode;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600023C RID: 572 RVA: 0x00006481 File Offset: 0x00004681
		public Rigidbody body
		{
			get
			{
				return this.m_rigid;
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00006489 File Offset: 0x00004689
		public Transform bodyTransform
		{
			get
			{
				return this.m_rigidTransform;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600023E RID: 574 RVA: 0x00006491 File Offset: 0x00004691
		public SphereCollider semenCollider
		{
			get
			{
				return this.m_collider;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600023F RID: 575 RVA: 0x00006499 File Offset: 0x00004699
		public Vector3 lastImpulseApplyed
		{
			get
			{
				return this.m_lastVelocityChangeApplyed;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000240 RID: 576 RVA: 0x000064A1 File Offset: 0x000046A1
		public float particleWorldRarius
		{
			get
			{
				if (this.m_collider == null)
				{
					return 0f;
				}
				return this.m_collider.radius * this.m_collider.transform.lossyScale.Escala();
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000241 RID: 577 RVA: 0x000064D8 File Offset: 0x000046D8
		public CollisionEnterBroadcasterTValle collisionBroadCaster
		{
			get
			{
				return this.m_CollisionBroadCaster;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000242 RID: 578 RVA: 0x000064E0 File Offset: 0x000046E0
		// (set) Token: 0x06000243 RID: 579 RVA: 0x000064ED File Offset: 0x000046ED
		public ICharacter owner
		{
			get
			{
				return this.m_owner as ICharacter;
			}
			private set
			{
				this.m_owner = value as Object;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000244 RID: 580 RVA: 0x000064FB File Offset: 0x000046FB
		// (set) Token: 0x06000245 RID: 581 RVA: 0x00006508 File Offset: 0x00004708
		public IPeneSimple ownerPene
		{
			get
			{
				return this.m_ownerPene as IPeneSimple;
			}
			private set
			{
				this.m_ownerPene = value as Object;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000246 RID: 582 RVA: 0x00006516 File Offset: 0x00004716
		public SemenPunto previus
		{
			get
			{
				return this.m_previus;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000247 RID: 583 RVA: 0x0000651E File Offset: 0x0000471E
		public SemenPunto next
		{
			get
			{
				return this.m_next;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000248 RID: 584 RVA: 0x00006526 File Offset: 0x00004726
		// (set) Token: 0x06000249 RID: 585 RVA: 0x0000652E File Offset: 0x0000472E
		public float distanceToBreakMod
		{
			get
			{
				return this.m_distanceToBreakMod;
			}
			set
			{
				this.m_distanceToBreakMod = value;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600024A RID: 586 RVA: 0x00006537 File Offset: 0x00004737
		public ModificableDeBool puedeHacerBindAnd
		{
			get
			{
				return this.m_puedeHacerBindAnd;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600024B RID: 587 RVA: 0x0000653F File Offset: 0x0000473F
		public float startTime
		{
			get
			{
				return this.m_startTime;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600024C RID: 588 RVA: 0x00006547 File Offset: 0x00004747
		public TipoDeSemen tipo
		{
			get
			{
				return this.m_tipo;
			}
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000654F File Offset: 0x0000474F
		public void SetTipo(TipoDeSemen Tipo)
		{
			this.m_tipo = Tipo;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00006558 File Offset: 0x00004758
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetManualStart();
			base.SetInicializable();
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000656C File Offset: 0x0000476C
		public void Init(ICharacter Owner, IPeneSimple OwnerPene, int indexInChain, SemenPunto previus, SemenPunto next, Rigidbody rigid, SphereCollider collider, Renderer renderer)
		{
			this.owner = Owner;
			this.ownerPene = OwnerPene;
			this.m_previus = previus;
			this.m_next = next;
			this.m_rigid = rigid;
			this.m_rigidTransform = this.m_rigid.transform;
			this.m_Renderer = renderer;
			this.m_collider = collider;
			this.m_CollisionBroadCaster = this.m_rigid.GetComponentNotNull<CollisionEnterBroadcasterTValle>();
			this.m_CollisionBroadCaster.onCollision += this.M_CollisionBoradCaster_onCollision;
			this.m_PuntoGenerico = rigid.GetComponent<PuntoGenerico>();
			Transform transform;
			SemenPunto.FindSemenBones(base.transform, out this.m_skeleton, out transform, out this.m_bone1, out this.m_bone2, out this.m_StretchedBone);
			this.m_defaultLocalSkeletonPose.position = this.m_skeleton.localPosition;
			this.m_defaultLocalSkeletonPose.rotation = this.m_skeleton.localRotation;
			this.m_defaultLocalSkeletonPose.scale = this.m_skeleton.localScale;
			this.m_EmulatedStepVelocitySaver = this.m_rigid.GetComponentNotNull<EmulatedStepVelocitySaver>();
			this.m_bone2InitialLocalPositionFromBone1 = this.m_bone1.InverseTransformPoint(this.m_bone2.position);
			this.m_distanceToBreak = this.m_bone2InitialLocalPositionFromBone1.magnitude * 11f;
			this.m_PhysicMaterialOriginal = collider.sharedMaterial;
			base.Initialize();
		}

		// Token: 0x06000250 RID: 592 RVA: 0x000066B4 File Offset: 0x000048B4
		public static void FindSemenBones(Transform semen, out Transform skeleton, out Transform bone0, out Transform bone1, out Transform bone2, out Transform StretchedBone)
		{
			skeleton = semen.FindDeepChildStartWith("Skeleton", true);
			if (skeleton == null)
			{
				throw new ArgumentNullException("m_skeleton", "m_skeleton null reference.");
			}
			bone0 = semen.FindDeepChildStartWith("Bone0", true);
			if (bone0 == null)
			{
				throw new ArgumentNullException("m_bone0", "m_bone0 null reference.");
			}
			bone1 = semen.FindDeepChildStartWith("Bone1", true);
			if (bone1 == null)
			{
				throw new ArgumentNullException("m_bone1", "m_bone1 null reference.");
			}
			bone2 = semen.FindDeepChildStartWith("Bone2", true);
			if (bone2 == null)
			{
				throw new ArgumentNullException("m_bone2", "m_bone2 null reference.");
			}
			StretchedBone = semen.FindDeepChildStartWith("Stretched", true);
			if (StretchedBone == null)
			{
				throw new ArgumentNullException("m_StretchedBone", "m_StretchedBone null reference.");
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00006790 File Offset: 0x00004990
		public static void GetSemenBonesLocalScales(SemenPunto semen, out Vector3 skeletonLocalScales, out Vector3 bone1LocalScales, out Vector3 bone2LocalScales, out Vector3 StretchedBoneLocalScales)
		{
			skeletonLocalScales = semen.m_skeleton.lossyScale;
			bone1LocalScales = semen.m_bone1.localScale;
			bone2LocalScales = semen.m_bone2.localScale;
			StretchedBoneLocalScales = semen.m_StretchedBone.localScale;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000067E2 File Offset: 0x000049E2
		public static void GetSemenStretchedBoneLocalRotation(SemenPunto semen, out Quaternion stretchedBoneLocalRotation)
		{
			stretchedBoneLocalRotation = Quaternion.Inverse(semen.m_bone1.rotation) * semen.m_StretchedBone.rotation;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000680A File Offset: 0x00004A0A
		public void ChangeVelocity(Vector3 impulseDirection, float magniture)
		{
			impulseDirection = impulseDirection.normalized;
			this.m_lastVelocityChangeApplyed = impulseDirection * magniture;
			this.changeVelocity(this.m_lastVelocityChangeApplyed);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000682E File Offset: 0x00004A2E
		public void ReApplyLastVelocityChange()
		{
			this.changeVelocity(this.m_lastVelocityChangeApplyed);
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000683C File Offset: 0x00004A3C
		private void changeVelocity(Vector3 velocityChange)
		{
			this.m_rigid.AddForce(velocityChange, ForceMode.VelocityChange);
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000684C File Offset: 0x00004A4C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_BodyFollower = this.m_bone1.GetComponentNotNull<TransformFollowersNoScaleLastUser>();
			this.m_BodyFollower.Init(this.m_bone1, this.m_rigidTransform);
			if (this.m_next != null)
			{
				this.m_NextFollower = this.m_bone2.GetComponentNotNull<TransformFollowersAfterLastUser>();
				this.m_NextFollower.Init(this.m_bone2, base.transform, this.m_next.m_bone1, this.m_next.transform);
			}
			else
			{
				this.OnBreak(false);
			}
			this.m_StretchTo = this.m_StretchedBone.GetComponentNotNull<StretchToAfterLastStandaloneUser>();
			this.m_StretchTo.stretchToConfig = this.config.stretchToConfig;
			this.m_StretchTo.Init(this.m_StretchedBone, this.m_bone2);
			this.m_CheckDistanceToNextCoroutine = new CoroutineCapsule(this.CheckDistanceToNextRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00006940 File Offset: 0x00004B40
		public void StartCheckDuration()
		{
			if (this.m_CheckDurationCoroutine != null)
			{
				Debug.LogError("Solo se puede estableser CheckDuration una sola vez", this);
				return;
			}
			this.m_startTime = Time.time;
			this.m_CheckDurationCoroutine = new CoroutineCapsule(this.CheckDurationRutine(this.config.duracion / 20f), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
			if (base.isStared && !this.m_CheckDurationCoroutine.ejecutandose)
			{
				this.m_CheckDurationCoroutine.Start();
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x000069C4 File Offset: 0x00004BC4
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_ownDurationModPorBindState = this.m_duracionModificador.ObtenerModificadorNotNull(this);
			this.m_ownDurationModPorNextIsLost = this.m_duracionModificador.ObtenerModificadorNotNull("NextIsLost");
			this.m_ownDurationModPorPreviusIsLost = this.m_duracionModificador.ObtenerModificadorNotNull("PreviusIsLost");
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00006A18 File Offset: 0x00004C18
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			ModificadorDeFloat ownDurationModPorBindState = this.m_ownDurationModPorBindState;
			if (ownDurationModPorBindState != null)
			{
				ownDurationModPorBindState.TryRemoverDeOwner(true);
			}
			this.m_ownDurationModPorBindState = null;
			ModificadorDeFloat ownDurationModPorNextIsLost = this.m_ownDurationModPorNextIsLost;
			if (ownDurationModPorNextIsLost != null)
			{
				ownDurationModPorNextIsLost.TryRemoverDeOwner(true);
			}
			this.m_ownDurationModPorNextIsLost = null;
			ModificadorDeFloat ownDurationModPorPreviusIsLost = this.m_ownDurationModPorPreviusIsLost;
			if (ownDurationModPorPreviusIsLost != null)
			{
				ownDurationModPorPreviusIsLost.TryRemoverDeOwner(true);
			}
			this.m_ownDurationModPorPreviusIsLost = null;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00006A7C File Offset: 0x00004C7C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			SemenPunto previus = this.m_previus;
			if (previus != null)
			{
				previus.OnNextIsLost(this);
			}
			SemenPunto next = this.m_next;
			if (next != null)
			{
				next.OnPreviusIsLost(this);
			}
			if (this.m_PhysicMaterialInstance != null)
			{
				Object.Destroy(this.m_PhysicMaterialInstance);
			}
			this.m_PhysicMaterialInstance = null;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00006AD4 File Offset: 0x00004CD4
		public void SetWaitToBind(float waitToBindtime)
		{
			this.m_waitToBindTime = waitToBindtime;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00006AE0 File Offset: 0x00004CE0
		public void StartWaitToBind()
		{
			if (this.m_WaitToBindCoroutine != null)
			{
				Debug.LogError("Solo se puede estableser waitToBind una sola vez", this);
				return;
			}
			if (this.isBinded)
			{
				Debug.LogError("WaitToBind debe ser establecido antes", this);
				return;
			}
			this.m_WaitToBindCoroutine = new CoroutineCapsule(this.WaitToBindRutine(this.m_waitToBindTime), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
			if (base.isStared && !this.m_WaitToBindCoroutine.ejecutandose)
			{
				this.m_WaitToBindCoroutine.Start();
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00006B60 File Offset: 0x00004D60
		private IEnumerator WaitToBindRutine(float timeLeft)
		{
			float timeLeftInicial = timeLeft;
			this.m_puedeHacerBind = false;
			if (this.m_PhysicMaterialInstance != null)
			{
				Object.Destroy(this.m_PhysicMaterialInstance);
			}
			this.m_PhysicMaterialInstance = null;
			this.m_collider.sharedMaterial = this.m_PhysicMaterialOriginal;
			if (timeLeft > 0f)
			{
				this.m_PhysicMaterialInstance = Object.Instantiate<PhysicMaterial>(this.m_collider.sharedMaterial);
				this.m_collider.sharedMaterial = this.m_PhysicMaterialInstance;
				this.m_PhysicMaterialInstance.frictionCombine = PhysicMaterialCombine.Average;
				this.m_PhysicMaterialInstance.dynamicFriction = (this.m_PhysicMaterialInstance.staticFriction = 0f);
			}
			yield return null;
			while (timeLeft > 0f)
			{
				timeLeft -= Time.deltaTime;
				if (this.m_PhysicMaterialInstance != null)
				{
					this.m_PhysicMaterialInstance.dynamicFriction = (this.m_PhysicMaterialInstance.staticFriction = Mathf.InverseLerp(timeLeftInicial, 0f, timeLeft).OutPow(3f));
				}
				yield return null;
			}
			if (this.m_PhysicMaterialInstance != null)
			{
				Object.Destroy(this.m_PhysicMaterialInstance);
			}
			this.m_PhysicMaterialInstance = null;
			this.m_collider.sharedMaterial = this.m_PhysicMaterialOriginal;
			this.m_puedeHacerBind = true;
			this.m_WaitToBindCoroutine.Stop();
			yield break;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00006B76 File Offset: 0x00004D76
		private IEnumerator CheckDistanceToNextRutine()
		{
			WaitForSeconds w = new WaitForSeconds(0.1f.Random(0.333f));
			do
			{
				yield return w;
				if (this.m_next == null)
				{
					goto IL_007B;
				}
			}
			while (!this.DistanceToNextSuperada(1f));
			this.OnNextIsLost(this.m_next);
			IL_007B:
			this.m_CheckDistanceToNextCoroutine.Stop();
			yield break;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00006B85 File Offset: 0x00004D85
		private IEnumerator CheckDistanceToBindedRutine()
		{
			WaitForSeconds w = new WaitForSeconds(0.1f.Random(0.333f));
			do
			{
				yield return w;
				if (this.m_BindJoint == null)
				{
					goto IL_0088;
				}
			}
			while (!(this.m_BindJoint.connectedBody == null) && !this.DistanceToBindJointSuperada(0.333f));
			this.UnBind();
			IL_0088:
			yield break;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00006B94 File Offset: 0x00004D94
		public void DisableVisual(bool disable)
		{
			if (this.m_Renderer == null)
			{
				return;
			}
			if (disable)
			{
				this.m_Renderer.gameObject.layer = ConfiguracionGlobal.layersStatic.ignoreAll;
				return;
			}
			this.m_Renderer.gameObject.layer = ConfiguracionGlobal.layersStatic.@default;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00006BE8 File Offset: 0x00004DE8
		public void SendVisualToLayer(int layer)
		{
			if (this.m_Renderer == null)
			{
				return;
			}
			this.m_Renderer.gameObject.layer = layer;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00006C0A File Offset: 0x00004E0A
		public bool DistanceToNextSuperada(float distanceMod = 1f)
		{
			return !(this.m_next == null) && this.DistanceToSuperada(this.m_next.m_rigidTransform, distanceMod);
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00006C2E File Offset: 0x00004E2E
		public bool DistanceToNextSuperadaUnSafe(float distanceMod = 1f)
		{
			return this.DistanceToSuperada(this.m_next.m_rigidTransform, distanceMod);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00006C42 File Offset: 0x00004E42
		public bool DistanceToPreviusSuperada(float distanceMod = 1f)
		{
			return !(this.m_previus == null) && this.DistanceToSuperada(this.m_previus.m_rigidTransform, distanceMod);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00006C66 File Offset: 0x00004E66
		public float GetLocalDistanceToBreak()
		{
			return this.m_distanceToBreak * this.m_distanceToBreakMod;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00006C78 File Offset: 0x00004E78
		private bool DistanceToSuperada(Transform trans, float distanceMod = 1f)
		{
			float sqrMagnitude = this.m_rigidTransform.InverseTransformPoint(trans.position).sqrMagnitude;
			float num = this.GetLocalDistanceToBreak() * distanceMod;
			return sqrMagnitude >= num * num;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00006CB0 File Offset: 0x00004EB0
		private bool DistanceToBindJointSuperada(float distanceMod = 1f)
		{
			Joint bindJoint = this.m_BindJoint;
			Transform transform;
			if (bindJoint == null)
			{
				transform = null;
			}
			else
			{
				Rigidbody connectedBody = bindJoint.connectedBody;
				transform = ((connectedBody != null) ? connectedBody.transform : null);
			}
			Transform transform2 = transform;
			if (transform2 == null)
			{
				return true;
			}
			Vector3 vector = transform2.TransformPoint(this.m_BindJointLocalPosition);
			float sqrMagnitude = this.m_rigidTransform.InverseTransformPoint(vector).sqrMagnitude;
			float num = this.GetLocalDistanceToBreak() * distanceMod;
			return sqrMagnitude >= num * num;
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00006D1C File Offset: 0x00004F1C
		public void SyncToBody()
		{
			this.m_bone1.parent = null;
			if (this.m_bone2.parent != this.m_bone1)
			{
				this.m_bone2.parent = null;
			}
			this.m_rigidTransform.parent = null;
			base.transform.SetPositionAndRotation(this.m_rigidTransform.position, this.m_rigidTransform.rotation);
			this.m_skeleton.localPosition = this.m_defaultLocalSkeletonPose.position;
			this.m_skeleton.localRotation = this.m_defaultLocalSkeletonPose.rotation;
			this.m_skeleton.localScale = this.m_defaultLocalSkeletonPose.scale;
			this.m_bone1.SetPositionAndRotation(this.m_rigidTransform.position, this.m_rigidTransform.rotation);
			this.m_bone1.parent = this.m_skeleton;
			if (this.m_bone2.parent == null)
			{
				this.m_bone2.parent = this.m_skeleton;
			}
			this.m_rigidTransform.parent = base.transform;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00006E30 File Offset: 0x00005030
		public void SetManualMode()
		{
			this.UnBind();
			this.SyncToBody();
			this.m_isManualMode = true;
			this.m_rigid.isKinematic = true;
			this.m_collider.enabled = false;
			this.m_EmulatedStepVelocitySaver.enabled = false;
			this.m_CollisionBroadCaster.enabled = false;
			this.m_BodyFollower.enabled = false;
			if (this.IsJointUnnecessary())
			{
				this.DestroySemenJoint();
			}
			SemenPunto previus = this.m_previus;
			if (previus != null)
			{
				previus.OnNextManualMode(this);
			}
			SemenPunto next = this.m_next;
			if (next != null)
			{
				next.OnPreviusManualMode(this);
			}
			foreach (Component component in from c in this.m_rigid.GetComponentsInChildren<Component>()
				where c != this.m_rigid && !(c is Transform)
				select c)
			{
				Object.Destroy(component);
			}
			Object.Destroy(this.m_rigid);
			this.m_ownDurationModPorBindState.valor.valor = 1f;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00006F34 File Offset: 0x00005134
		public void OnPreviusManualMode(SemenPunto previus)
		{
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00006F36 File Offset: 0x00005136
		public void OnNextManualMode(SemenPunto next)
		{
			if (this.IsJointUnnecessary())
			{
				this.DestroySemenJoint();
			}
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00006F46 File Offset: 0x00005146
		public void OnPreviusIsLost(SemenPunto previus)
		{
			if (base.isDestroyed || this == null)
			{
				return;
			}
			this.m_previus = null;
			if (this.m_ownDurationModPorPreviusIsLost != null)
			{
				this.m_ownDurationModPorPreviusIsLost.valor.valor = 0.3333f;
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00006F80 File Offset: 0x00005180
		public void OnNextIsLost(SemenPunto next)
		{
			if (base.isDestroyed || this == null)
			{
				return;
			}
			this.DestroySemenJoint();
			this.OnBreak(true);
			this.m_next = null;
			if (this.m_ownDurationModPorNextIsLost != null)
			{
				this.m_ownDurationModPorNextIsLost.valor.valor = 0.3333f;
			}
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00006FD0 File Offset: 0x000051D0
		public void DestroySemenJoint()
		{
			PuntoGenerico puntoGenerico = this.m_PuntoGenerico;
			if (((puntoGenerico != null) ? puntoGenerico.joint : null) != null)
			{
				this.m_PuntoGenerico.OnJointBreak(float.PositiveInfinity);
				Object.Destroy(this.m_PuntoGenerico.joint);
				this.m_PuntoGenerico = null;
			}
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000701E File Offset: 0x0000521E
		public bool IsJointUnnecessary()
		{
			return this.m_isManualMode && this.m_next != null && this.m_next.m_isManualMode;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00007048 File Offset: 0x00005248
		private void M_CollisionBoradCaster_onCollision(Collision collision, Rigidbody arg2, Collider arg3)
		{
			if (!this.m_puedeHacerBindAnd.And(this.m_puedeHacerBind) || this.m_isManualMode || !base.isActiveAndEnabled)
			{
				return;
			}
			if (this.m_isBinded)
			{
				return;
			}
			Collider collider = collision.collider;
			if (this.m_ignoringColliders.Contains(collider))
			{
				return;
			}
			if (collider.GetComponentInParent<SemenPunto>() != null)
			{
				return;
			}
			this.m_OnBindingEventArgs.Clear();
			SemenPunto.OnBindingHandler onBindingHandler = this.onBinding;
			if (onBindingHandler != null)
			{
				onBindingHandler(collision, collider, this.m_OnBindingEventArgs, this);
			}
			if (this.m_OnBindingEventArgs.aborted)
			{
				if (this.m_OnBindingEventArgs.ignorarColliderPhysics)
				{
					Physics.IgnoreCollision(collider, this.m_collider, true);
				}
				if (this.m_OnBindingEventArgs.ignorarColliderScript)
				{
					this.m_ignoringColliders.Add(collider);
				}
				this.m_ownDurationModPorBindState.valor.valor = this.m_OnBindingEventArgs.durationTimeMod;
				return;
			}
			if (collider.attachedRigidbody == null)
			{
				this.m_BindCollider = collider;
				this.m_isBinded = true;
				Physics.IgnoreCollision(this.m_BindCollider, this.m_collider, true);
				this.SetManualMode();
				SemenPunto.OnBindedHandler onBindedHandler = this.onBinded;
				if (onBindedHandler != null)
				{
					onBindedHandler(collision, this.m_BindCollider, this);
				}
				this.m_ownDurationModPorBindState.valor.valor = 0.5f;
				return;
			}
			this.m_BindCollider = collider;
			if (this.m_BindCollider.attachedRigidbody.isKinematic)
			{
				this.m_BindJoint = this.m_rigid.gameObject.AddComponent<FixedJoint>();
			}
			else
			{
				ConfigurableJoint configurableJoint = this.m_rigid.gameObject.AddComponent<ConfigurableJoint>();
				configurableJoint.xMotion = (configurableJoint.yMotion = (configurableJoint.zMotion = (configurableJoint.angularXMotion = (configurableJoint.angularYMotion = (configurableJoint.angularZMotion = ConfigurableJointMotion.Free)))));
				this.m_BindJoint = configurableJoint;
				float num = 10000f * this.body.mass;
				float num2 = 500f * this.body.mass;
				configurableJoint.xDrive = new JointDrive
				{
					maximumForce = float.MaxValue,
					positionSpring = num
				};
				configurableJoint.yDrive = new JointDrive
				{
					maximumForce = float.MaxValue,
					positionSpring = num
				};
				configurableJoint.zDrive = new JointDrive
				{
					maximumForce = float.MaxValue,
					positionSpring = num
				};
				configurableJoint.angularXDrive = new JointDrive
				{
					maximumForce = float.MaxValue,
					positionSpring = num2
				};
				configurableJoint.angularYZDrive = new JointDrive
				{
					maximumForce = float.MaxValue,
					positionSpring = num2
				};
			}
			this.m_BindJoint.connectedBody = this.m_BindCollider.attachedRigidbody;
			this.m_BindJointLocalPosition = this.m_BindJoint.connectedBody.transform.InverseTransformPoint(this.bodyTransform.position);
			this.m_isBinded = true;
			Physics.IgnoreCollision(this.m_BindCollider, this.m_collider, true);
			SemenPunto.OnBindedHandler onBindedHandler2 = this.onBinded;
			if (onBindedHandler2 != null)
			{
				onBindedHandler2(collision, this.m_BindCollider, this);
			}
			this.m_ownDurationModPorBindState.valor.valor = 0.25f;
			base.StartCoroutine(this.CheckDistanceToBindedRutine());
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00007380 File Offset: 0x00005580
		private void OnBreak(bool force)
		{
			if (force || this.m_next == null || !this.m_next.m_isManualMode)
			{
				base.StartCoroutine(this.ActivateFollowBone2());
				SemenPunto next = this.m_next;
				if (next != null)
				{
					next.OnPreviusIsLost(this);
				}
				Action<SemenPunto> action = this.onBreak;
				if (action == null)
				{
					return;
				}
				action(this);
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x000073DC File Offset: 0x000055DC
		public void UnBind()
		{
			if (this.m_BindCollider && this.m_collider)
			{
				Physics.IgnoreCollision(this.m_BindCollider, this.m_collider, false);
				this.m_ignoringColliders.Clear();
			}
			if (this.m_rigid != null)
			{
				this.m_rigid.isKinematic = false;
			}
			if (this.m_BindJoint)
			{
				Object.Destroy(this.m_BindJoint);
			}
			this.m_BindJoint = null;
			this.m_BindCollider = null;
			this.m_BindJoint = null;
			this.m_isBinded = false;
			if (this.m_ownDurationModPorBindState != null)
			{
				this.m_ownDurationModPorBindState.valor.valor = 1f;
			}
			Action<SemenPunto> action = this.onUnBinded;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000749C File Offset: 0x0000569C
		private IEnumerator ActivateFollowBone2()
		{
			if (this.m_NextFollower != null)
			{
				Object.Destroy(this.m_NextFollower);
			}
			this.m_NextFollower = null;
			Vector3 smoothDampVelocity = Vector3.zero;
			Vector3 forward = this.m_bone2.forward;
			this.m_bone2.parent = null;
			this.m_bone2.parent = this.m_bone1;
			Vector3 localTargetOnBreak = this.m_bone1.InverseTransformDirection(forward).normalized * (this.config.colliderRadius * 0.25f);
			while (!ExtendedMonoBehaviour.AlmostEqual(this.m_bone2.localPosition, localTargetOnBreak, 0.001f) || !ExtendedMonoBehaviour.AlmostEqual(this.m_bone2.localRotation, Quaternion.identity, 0.1f))
			{
				yield return null;
				this.m_bone2.localPosition = Vector3.SmoothDamp(this.m_bone2.localPosition, localTargetOnBreak, ref smoothDampVelocity, 0.001f, this.config.maxVelocityOnBreak);
				this.m_bone2.localRotation = Quaternion.RotateTowards(this.m_bone2.localRotation, Quaternion.identity, 180f * Time.deltaTime * 0.2f);
			}
			Action<SemenPunto> action = this.onBreakRested;
			if (action != null)
			{
				action(this);
			}
			yield break;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x000074AB File Offset: 0x000056AB
		public float DuracionTotal()
		{
			return this.m_duracionModificador.ModificarValor(this.config.duracion) * Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.semenDurationMod;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x000074D3 File Offset: 0x000056D3
		private IEnumerator CheckDurationRutine(float interval)
		{
			WaitForSeconds w = new WaitForSeconds(interval.Random(0.2f));
			yield return null;
			float num = this.DuracionTotal();
			while (Time.time - this.m_startTime < num)
			{
				this.m_lifeTimeWeight = Mathf.InverseLerp(0f, num, Time.time - this.m_startTime);
				if (this.reduceScaleByLifeTime)
				{
					this.m_skeleton.localScale = Vector3.one * Mathf.Clamp(1f - this.m_lifeTimeWeight, 0.01f, 1f).InPow(3f);
				}
				yield return w;
				num = this.DuracionTotal();
			}
			this.m_CheckDurationCoroutine.Stop();
			if (base.gameObject != null)
			{
				Object.Destroy(base.gameObject);
			}
			yield break;
		}

		// Token: 0x06000276 RID: 630 RVA: 0x000074E9 File Offset: 0x000056E9
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Detener todas las corutines DEBUG",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00007502 File Offset: 0x00005702
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			CoroutineCapsule checkDistanceToNextCoroutine = this.m_CheckDistanceToNextCoroutine;
			if (checkDistanceToNextCoroutine != null)
			{
				checkDistanceToNextCoroutine.Stop();
			}
			CoroutineCapsule waitToBindCoroutine = this.m_WaitToBindCoroutine;
			if (waitToBindCoroutine != null)
			{
				waitToBindCoroutine.Stop();
			}
			CoroutineCapsule checkDurationCoroutine = this.m_CheckDurationCoroutine;
			if (checkDurationCoroutine == null)
			{
				return;
			}
			checkDurationCoroutine.Stop();
		}

		// Token: 0x0400015E RID: 350
		public const float defaultParticleRadius = 0.002f;

		// Token: 0x04000164 RID: 356
		[SerializeField]
		private ModificableDeFloat m_duracionModificador = new ModificableDeFloat(1f);

		// Token: 0x04000165 RID: 357
		public bool reduceScaleByLifeTime;

		// Token: 0x04000166 RID: 358
		public SemenPunto.Config config = new SemenPunto.Config();

		// Token: 0x04000167 RID: 359
		[SerializeReference]
		private ModificadorDeFloat m_ownDurationModPorBindState;

		// Token: 0x04000168 RID: 360
		[SerializeReference]
		private ModificadorDeFloat m_ownDurationModPorNextIsLost;

		// Token: 0x04000169 RID: 361
		[SerializeReference]
		private ModificadorDeFloat m_ownDurationModPorPreviusIsLost;

		// Token: 0x0400016A RID: 362
		[ReadOnlyUI]
		[SerializeField]
		private PuntoGenerico m_PuntoGenerico;

		// Token: 0x0400016B RID: 363
		[ReadOnlyUI]
		[SerializeField]
		private Renderer m_Renderer;

		// Token: 0x0400016C RID: 364
		[ReadOnlyUI]
		[SerializeField]
		private float m_lifeTimeWeight;

		// Token: 0x0400016D RID: 365
		[ReadOnlyUI]
		[SerializeField]
		private Rigidbody m_rigid;

		// Token: 0x0400016E RID: 366
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_rigidTransform;

		// Token: 0x0400016F RID: 367
		[ReadOnlyUI]
		[SerializeField]
		private SphereCollider m_collider;

		// Token: 0x04000170 RID: 368
		[ReadOnlyUI]
		[SerializeField]
		private CollisionEnterBroadcasterTValle m_CollisionBroadCaster;

		// Token: 0x04000171 RID: 369
		[ReadOnlyUI]
		[SerializeField]
		private bool m_isBinded;

		// Token: 0x04000172 RID: 370
		[ReadOnlyUI]
		[SerializeField]
		private bool m_isManualMode;

		// Token: 0x04000173 RID: 371
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_lastVelocityChangeApplyed;

		// Token: 0x04000174 RID: 372
		[SerializeField]
		private TipoDeSemen m_tipo;

		// Token: 0x04000175 RID: 373
		[ConstraintType(typeof(ICharacter), true)]
		[SerializeField]
		private Object m_owner;

		// Token: 0x04000176 RID: 374
		[ConstraintType(typeof(IPeneSimple), true)]
		[SerializeField]
		private Object m_ownerPene;

		// Token: 0x04000177 RID: 375
		[ReadOnlyUI]
		[SerializeField]
		private SemenPunto m_previus;

		// Token: 0x04000178 RID: 376
		[ReadOnlyUI]
		[SerializeField]
		private SemenPunto m_next;

		// Token: 0x04000179 RID: 377
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_skeleton;

		// Token: 0x0400017A RID: 378
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_bone1;

		// Token: 0x0400017B RID: 379
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_bone2;

		// Token: 0x0400017C RID: 380
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_StretchedBone;

		// Token: 0x0400017D RID: 381
		[ReadOnlyUI]
		[SerializeField]
		private TransformFollowersNoScaleLastUser m_BodyFollower;

		// Token: 0x0400017E RID: 382
		[ReadOnlyUI]
		[SerializeField]
		private TransformFollowersAfterLastUser m_NextFollower;

		// Token: 0x0400017F RID: 383
		[ReadOnlyUI]
		[SerializeField]
		private StretchToAfterLastStandaloneUser m_StretchTo;

		// Token: 0x04000180 RID: 384
		private Vector3 m_bone2InitialLocalPositionFromBone1;

		// Token: 0x04000181 RID: 385
		[ReadOnlyUI]
		[SerializeField]
		private EmulatedStepVelocitySaver m_EmulatedStepVelocitySaver;

		// Token: 0x04000182 RID: 386
		[ReadOnlyUI]
		[SerializeField]
		private Joint m_BindJoint;

		// Token: 0x04000183 RID: 387
		[ReadOnlyUI]
		[SerializeField]
		private Collider m_BindCollider;

		// Token: 0x04000184 RID: 388
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_BindJointLocalPosition;

		// Token: 0x04000185 RID: 389
		private SemenPunto.OnBindingEventArgs m_OnBindingEventArgs = new SemenPunto.OnBindingEventArgs();

		// Token: 0x04000186 RID: 390
		private SemenPunto.Pose m_defaultLocalSkeletonPose = new SemenPunto.Pose();

		// Token: 0x04000187 RID: 391
		private CoroutineCapsule m_CheckDistanceToNextCoroutine;

		// Token: 0x04000188 RID: 392
		private CoroutineCapsule m_WaitToBindCoroutine;

		// Token: 0x04000189 RID: 393
		private CoroutineCapsule m_CheckDurationCoroutine;

		// Token: 0x0400018A RID: 394
		[SerializeField]
		[ReadOnlyUI]
		private float m_distanceToBreak;

		// Token: 0x0400018B RID: 395
		[SerializeField]
		[ReadOnlyUI]
		private float m_distanceToBreakMod;

		// Token: 0x0400018C RID: 396
		[SerializeField]
		[ReadOnlyUI]
		private float m_waitToBindTime;

		// Token: 0x0400018D RID: 397
		[ReadOnlyUI]
		[SerializeField]
		private bool m_puedeHacerBind;

		// Token: 0x0400018E RID: 398
		[SerializeField]
		private ModificableDeBool m_puedeHacerBindAnd = new ModificableDeBool(true);

		// Token: 0x0400018F RID: 399
		[ReadOnlyUI]
		[SerializeField]
		private float m_startTime;

		// Token: 0x04000190 RID: 400
		[ReadOnlyUI]
		[SerializeField]
		private PhysicMaterial m_PhysicMaterialInstance;

		// Token: 0x04000191 RID: 401
		[ReadOnlyUI]
		[SerializeField]
		private PhysicMaterial m_PhysicMaterialOriginal;

		// Token: 0x04000192 RID: 402
		private HashSet<Collider> m_ignoringColliders = new HashSet<Collider>();

		// Token: 0x02000159 RID: 345
		public class OnBindingEventArgs
		{
			// Token: 0x170004D8 RID: 1240
			// (get) Token: 0x06000DF0 RID: 3568 RVA: 0x00030727 File Offset: 0x0002E927
			public bool aborted
			{
				get
				{
					return !this.m_forced && this.m_aborted;
				}
			}

			// Token: 0x170004D9 RID: 1241
			// (get) Token: 0x06000DF1 RID: 3569 RVA: 0x00030739 File Offset: 0x0002E939
			public bool forced
			{
				get
				{
					return this.m_forced;
				}
			}

			// Token: 0x170004DA RID: 1242
			// (get) Token: 0x06000DF2 RID: 3570 RVA: 0x00030741 File Offset: 0x0002E941
			public bool ignorarColliderPhysics
			{
				get
				{
					return this.m_ignorarColliderPhysics;
				}
			}

			// Token: 0x170004DB RID: 1243
			// (get) Token: 0x06000DF3 RID: 3571 RVA: 0x00030749 File Offset: 0x0002E949
			public bool ignorarColliderScript
			{
				get
				{
					return this.m_ignorarColliderScript;
				}
			}

			// Token: 0x170004DC RID: 1244
			// (get) Token: 0x06000DF4 RID: 3572 RVA: 0x00030751 File Offset: 0x0002E951
			public float durationTimeMod
			{
				get
				{
					return this.m_durationTimeMod;
				}
			}

			// Token: 0x06000DF5 RID: 3573 RVA: 0x00030759 File Offset: 0x0002E959
			[Obsolete("", true)]
			public void Abort(bool IgnorarCollider)
			{
				this.m_aborted = true;
			}

			// Token: 0x06000DF6 RID: 3574 RVA: 0x00030762 File Offset: 0x0002E962
			public void AbortV2(bool IgnorarColliderPhysics, bool IgnorarColliderScript, float durationTimeMod = 1f)
			{
				this.m_aborted = true;
				this.m_ignorarColliderPhysics = IgnorarColliderPhysics;
				this.m_ignorarColliderScript = IgnorarColliderScript;
				this.m_durationTimeMod = durationTimeMod;
			}

			// Token: 0x06000DF7 RID: 3575 RVA: 0x00030780 File Offset: 0x0002E980
			public void ForceBind()
			{
				this.m_forced = true;
			}

			// Token: 0x06000DF8 RID: 3576 RVA: 0x00030789 File Offset: 0x0002E989
			public void Clear()
			{
				this.m_aborted = false;
				this.m_forced = false;
				this.m_ignorarColliderPhysics = false;
				this.m_ignorarColliderScript = false;
				this.m_durationTimeMod = 1f;
			}

			// Token: 0x04000827 RID: 2087
			private bool m_aborted;

			// Token: 0x04000828 RID: 2088
			private bool m_forced;

			// Token: 0x04000829 RID: 2089
			private bool m_ignorarColliderPhysics;

			// Token: 0x0400082A RID: 2090
			private bool m_ignorarColliderScript;

			// Token: 0x0400082B RID: 2091
			private float m_durationTimeMod;
		}

		// Token: 0x0200015A RID: 346
		// (Invoke) Token: 0x06000DFB RID: 3579
		public delegate void OnBindingHandler(Collision collision, Collider other, SemenPunto.OnBindingEventArgs args, SemenPunto sender);

		// Token: 0x0200015B RID: 347
		// (Invoke) Token: 0x06000DFF RID: 3583
		public delegate void OnBindedHandler(Collision collision, Collider other, SemenPunto sender);

		// Token: 0x0200015C RID: 348
		public class Pose
		{
			// Token: 0x0400082C RID: 2092
			public Vector3 position;

			// Token: 0x0400082D RID: 2093
			public Quaternion rotation;

			// Token: 0x0400082E RID: 2094
			public Vector3 scale;
		}

		// Token: 0x0200015D RID: 349
		[Serializable]
		public class Config
		{
			// Token: 0x0400082F RID: 2095
			public float colliderRadius = 0.002f;

			// Token: 0x04000830 RID: 2096
			public float maxVelocityOnBreak = 60f;

			// Token: 0x04000831 RID: 2097
			public float duracion = 120f;

			// Token: 0x04000832 RID: 2098
			public StretchToConfig stretchToConfig = new StretchToConfig();
		}
	}
}
