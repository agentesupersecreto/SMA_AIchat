using System;
using System.Collections.Generic;
using Assets.Base.Joints;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000E3 RID: 227
	public sealed class AnusHole : Circular8BoneChain, IFemaleHole, IHole, IPenetrable, IComponentStartable, IPhysicsHole, IAnusHole
	{
		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06000935 RID: 2357 RVA: 0x0001D04C File Offset: 0x0001B24C
		public sealed override ICharacter owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06000936 RID: 2358 RVA: 0x0001D054 File Offset: 0x0001B254
		public override int updateEvent3Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06000937 RID: 2359 RVA: 0x0001D057 File Offset: 0x0001B257
		public Transform entradaTransform
		{
			get
			{
				return this.m_entradaTransform;
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06000938 RID: 2360 RVA: 0x0001D05F File Offset: 0x0001B25F
		public override Transform fondoPhysics
		{
			get
			{
				return this.m_fondoTransform;
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06000939 RID: 2361 RVA: 0x0001D067 File Offset: 0x0001B267
		public override Transform centroDePuntos
		{
			get
			{
				return this.entradaTransform;
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x0600093A RID: 2362 RVA: 0x0001D06F File Offset: 0x0001B26F
		[Obsolete]
		public override FondoOfHole fondoOfHole
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x0600093B RID: 2363 RVA: 0x0001D072 File Offset: 0x0001B272
		public override CircularChainPointStretcherJoint _1030
		{
			get
			{
				return this.m_1030;
			}
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x0600093C RID: 2364 RVA: 0x0001D07A File Offset: 0x0001B27A
		public override CircularChainPointStretcherJoint _12
		{
			get
			{
				return this.m_12;
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x0001D082 File Offset: 0x0001B282
		public override CircularChainPointStretcherJoint _130
		{
			get
			{
				return this.m_130;
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x0600093E RID: 2366 RVA: 0x0001D08A File Offset: 0x0001B28A
		public override CircularChainPointStretcherJoint _3
		{
			get
			{
				return this.m_3;
			}
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x0001D092 File Offset: 0x0001B292
		public override CircularChainPointStretcherJoint _430
		{
			get
			{
				return this.m_430;
			}
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x0001D09A File Offset: 0x0001B29A
		public override CircularChainPointStretcherJoint _6
		{
			get
			{
				return this.m_6;
			}
		}

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06000941 RID: 2369 RVA: 0x0001D0A2 File Offset: 0x0001B2A2
		public override CircularChainPointStretcherJoint _730
		{
			get
			{
				return this.m_730;
			}
		}

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x0001D0AA File Offset: 0x0001B2AA
		public override CircularChainPointStretcherJoint _9
		{
			get
			{
				return this.m_9;
			}
		}

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06000943 RID: 2371 RVA: 0x0001D0B2 File Offset: 0x0001B2B2
		// (set) Token: 0x06000944 RID: 2372 RVA: 0x0001D0BA File Offset: 0x0001B2BA
		public float suavidad
		{
			get
			{
				return this.m_suavidad;
			}
			set
			{
				this.m_suavidad = value;
				this.OnSuavidadCambio();
			}
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06000945 RID: 2373 RVA: 0x0001D0C9 File Offset: 0x0001B2C9
		// (set) Token: 0x06000946 RID: 2374 RVA: 0x0001D0D1 File Offset: 0x0001B2D1
		public float suavidadVertical
		{
			get
			{
				return this.m_suavidadVertical;
			}
			set
			{
				this.m_suavidadVertical = value;
				this.OnSuavidadVerticalCambio();
			}
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06000947 RID: 2375 RVA: 0x0001D0E0 File Offset: 0x0001B2E0
		// (set) Token: 0x06000948 RID: 2376 RVA: 0x0001D0E8 File Offset: 0x0001B2E8
		public float suavidadHorizontal
		{
			get
			{
				return this.m_suavidadHorizontal;
			}
			set
			{
				this.m_suavidadHorizontal = value;
				this.OnSuavidadHorizontalCambio();
			}
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06000949 RID: 2377 RVA: 0x0001D0F7 File Offset: 0x0001B2F7
		protected override bool chainRigidbodyIsKinematic
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x0600094A RID: 2378 RVA: 0x0001D0FA File Offset: 0x0001B2FA
		protected override bool useScaleBroadcaster
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x0600094B RID: 2379 RVA: 0x0001D0FD File Offset: 0x0001B2FD
		public float defaultStaticFriccion
		{
			get
			{
				return this.m_defaultStaticFricc;
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x0001D105 File Offset: 0x0001B305
		public float defaultDynamicFriccion
		{
			get
			{
				return this.m_defaultDynamicFricc;
			}
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x0600094D RID: 2381 RVA: 0x0001D10D File Offset: 0x0001B30D
		public PhysicMaterial currentPhysicMaterial
		{
			get
			{
				return this.m_PhysicMaterialWalls;
			}
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x0600094E RID: 2382 RVA: 0x0001D115 File Offset: 0x0001B315
		public IFemaleChar femaleChar
		{
			get
			{
				return this.m_FemaleChar;
			}
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x0600094F RID: 2383 RVA: 0x0001D11D File Offset: 0x0001B31D
		public Character characterOwner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06000950 RID: 2384 RVA: 0x0001D125 File Offset: 0x0001B325
		IFemaleChar IFemaleHole.femaleChar
		{
			get
			{
				return this.m_FemaleChar;
			}
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x0001D130 File Offset: 0x0001B330
		public void ObtenerHolesCollidersDelCharExcluyendo(List<Collider> result, IHole hole)
		{
			if (hole == null)
			{
				result.AddRange(this.m_FemaleChar.vagColliders);
				result.AddRange(this.m_FemaleChar.anusColliders);
				result.AddRange(this.m_FemaleChar.bocaColliders);
				return;
			}
			if (hole != this.m_FemaleChar.vagHole && this.m_FemaleChar.vagColliders != null)
			{
				result.AddRange(this.m_FemaleChar.vagColliders);
			}
			if (hole != this.m_FemaleChar.anusHole && this.m_FemaleChar.anusColliders != null)
			{
				result.AddRange(this.m_FemaleChar.anusColliders);
			}
			if (hole != this.m_FemaleChar.bocaHole && this.m_FemaleChar.bocaColliders != null)
			{
				result.AddRange(this.m_FemaleChar.bocaColliders);
			}
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x0001D1F8 File Offset: 0x0001B3F8
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.penetrationJointConfig.zDriveDamperV2 *= 1.5f;
			this.polaridadLimiterConfig.toleranceMod = 0.2f;
			this.holeConfig.wallCollidersProfundidad = 0.015f;
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06000953 RID: 2387 RVA: 0x0001D237 File Offset: 0x0001B437
		public override IHoleInternals internals
		{
			get
			{
				return this.m_AnusInternals;
			}
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x0001D240 File Offset: 0x0001B440
		protected override void AwakeUnityEvent()
		{
			this.m_AnusInternals = this.GetComponentEnRoot(false);
			this.m_hardPointDeRectus.id = "RECTUS";
			this.m_hardPointDeRectus.SetProfundidadLocal(0.04f);
			this.m_hardPointDeRectus.SetRadiusLocal(0.015f);
			this.m_hardPointDeRectus.resistenciaMod = 1f;
			this.m_hardPointDeRectus.passResistenciaMod = 2f;
			this.m_hardPointDeRectus.maxDesgastePorSegundo = 0.04f;
			this.m_hardPointDeRectus.aiWeight = 0.2f;
			base.AddOrReplacePunto(this.m_hardPointDeRectus);
			this.m_hardPointDeIntestines.id = "INTESTINES";
			this.m_hardPointDeIntestines.SetProfundidadLocal(0.12f);
			this.m_hardPointDeIntestines.SetRadiusLocal(0.025f);
			this.m_hardPointDeIntestines.resistenciaMod = 1f;
			this.m_hardPointDeIntestines.passResistenciaMod = 4f;
			this.m_hardPointDeIntestines.maxDesgastePorSegundo = 0.02f;
			this.m_hardPointDeIntestines.aiWeight = 1f;
			base.AddOrReplacePunto(this.m_hardPointDeIntestines);
			this.m_layer = Singleton<ConfiguracionGeneral>.instance.layers.holeSegundario;
			this.m_BoneMap = Singleton<MapasDeHuesos>.instance.mapas.anusHoleMap;
			if (this.m_BoneMap == null)
			{
				throw new ArgumentNullException("m_BoneMap", "m_BoneMap null reference.");
			}
			this.m_entradaTransform = base.transform.Find(this.m_BoneMap.entrada);
			if (this.m_entradaTransform == null)
			{
				throw new ArgumentNullException("m_entradaTransform", "m_entradaTransform null reference.");
			}
			base.AwakeUnityEvent();
			this.m_Root = base.transform.FindDeepParent(this.m_BoneMap.root);
			if (this.m_Root == null)
			{
				throw new ArgumentNullException("m_Root", "m_Root null reference.");
			}
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x0001D414 File Offset: 0x0001B614
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.IgnorarCollisionesConSigoMismo();
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x0001D424 File Offset: 0x0001B624
		protected override void StartUnityEvent()
		{
			this.m_owner = base.GetComponentInParent<Character>();
			this.m_FemaleChar = this.m_owner as IFemaleChar;
			if (this.m_FemaleChar == null)
			{
				throw new ArgumentNullException("m_FemaleChar", "m_FemaleChar null reference.");
			}
			base.transform.ExecDeepChild(delegate(Transform t)
			{
				t.gameObject.layer = this.m_layer;
			}, true);
			base.DefaultGenerarFondoTransform(ref this.m_fondoTransform);
			this.AsignarPuntos();
			base.StartUnityEvent();
			foreach (CircularChainPointCopier circularChainPointCopier in this.m_bonesCopiadores)
			{
				circularChainPointCopier.ManualStart();
			}
			HoleDeformationScaleAdmin componentNotNull = this.GetComponentNotNull<HoleDeformationScaleAdmin>();
			Transform transform = this.m_Root.FindDeepChild(this.m_BoneMap.entradaDef, true);
			componentNotNull.Init(transform);
			this.InitSuavidad();
			this.IgnorarCollisionesConSigoMismo();
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x0001D50C File Offset: 0x0001B70C
		protected sealed override bool CercaDeHardPointsExtra()
		{
			return false;
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x0001D510 File Offset: 0x0001B710
		public override void OnUpdateEvent3()
		{
			float num = this.modificableDeFriccionGeneral.ModificarValor(1f);
			if (this.m_LastModFriccionGeneral == null || !ExtendedMonoBehaviour.AlmostEqual(this.m_LastModFriccionGeneral.Value, num, 0.01f))
			{
				this.m_LastModFriccionGeneral = new float?(num);
				this.m_PhysicMaterialWalls.dynamicFriction = this.m_defaultDynamicFricc * num;
				this.m_PhysicMaterialWalls.staticFriction = this.m_defaultStaticFricc * num;
			}
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0001D588 File Offset: 0x0001B788
		protected override void OnValidateUnityEvent()
		{
			base.OnValidateUnityEvent();
			if (this.m_lastSuavidad != this.m_suavidad)
			{
				this.m_lastSuavidad = this.m_suavidad;
				this.OnSuavidadCambio();
			}
			if (this.m_lastSuavidadVertical != this.m_suavidadVertical)
			{
				this.m_lastSuavidadVertical = this.m_suavidadVertical;
				this.OnSuavidadVerticalCambio();
			}
			if (this.m_lastSuavidadHorizontal != this.m_suavidadHorizontal)
			{
				this.m_lastSuavidadHorizontal = this.m_suavidadHorizontal;
				this.OnSuavidadHorizontalCambio();
			}
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0001D5FC File Offset: 0x0001B7FC
		public void AsignarPuntos()
		{
			if (this.m_BoneMap == null)
			{
				throw new ArgumentNullException("m_BoneMap", "m_BoneMap null reference.");
			}
			try
			{
				if (this.colliderConfig.material == null)
				{
					this.colliderConfig.material = Singleton<ColecionDePhysicsMaterials>.instance.innerAnus;
				}
				this.m_PhysicMaterialWalls = Object.Instantiate<PhysicMaterial>(this.colliderConfig.material);
				this.colliderConfig.material = this.m_PhysicMaterialWalls;
				this.m_defaultStaticFricc = this.m_PhysicMaterialWalls.staticFriction;
				this.m_defaultDynamicFricc = this.m_PhysicMaterialWalls.dynamicFriction;
				Transform transform = base.transform.Find(this.m_BoneMap.inners._12);
				CircularChainPointCopier componentNotNull = transform.GetComponentNotNull<CircularChainPointCopier>();
				CircularChainPointStretcherCreator componentNotNull2 = transform.Copy(null).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull2, base.transform.Find(this.m_BoneMap.outers._12), Circular8BoneChain.Punto._12, componentNotNull);
				this.m_12 = componentNotNull2.chainPointStretcherJoint;
				this.CreateRefAndInit(this.m_BoneMap.inners._1030, this.m_BoneMap.outers._1030, Circular8BoneChain.Punto._1030, ref this.m_1030);
				this.CreateRefAndInit(this.m_BoneMap.inners._130, this.m_BoneMap.outers._130, Circular8BoneChain.Punto._130, ref this.m_130);
				this.CreateRefAndInit(this.m_BoneMap.inners._3, this.m_BoneMap.outers._3, Circular8BoneChain.Punto._3, ref this.m_3);
				this.CreateRefAndInit(this.m_BoneMap.inners._430, this.m_BoneMap.outers._430, Circular8BoneChain.Punto._430, ref this.m_430);
				this.CreateRefAndInit(this.m_BoneMap.inners._6, this.m_BoneMap.outers._6, Circular8BoneChain.Punto._6, ref this.m_6);
				this.CreateRefAndInit(this.m_BoneMap.inners._730, this.m_BoneMap.outers._730, Circular8BoneChain.Punto._730, ref this.m_730);
				this.CreateRefAndInit(this.m_BoneMap.inners._9, this.m_BoneMap.outers._9, Circular8BoneChain.Punto._9, ref this.m_9);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, base.gameObject);
			}
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0001D860 File Offset: 0x0001BA60
		private void CreateRefAndInit(string boneInnerName, string boneOutterName, Circular8BoneChain.Punto punto, ref CircularChainPointStretcherJoint reff)
		{
			Transform transform = base.transform.Find(boneInnerName);
			CircularChainPointCopier componentNotNull = transform.GetComponentNotNull<CircularChainPointCopier>();
			CircularChainPointStretcherCreator componentNotNull2 = transform.Copy(null).GetComponentNotNull<CircularChainPointStretcherCreator>();
			this.InitCreadorDePunto(componentNotNull2, base.transform.Find(boneOutterName), punto, componentNotNull);
			reff = componentNotNull2.chainPointStretcherJoint;
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0001D8AA File Offset: 0x0001BAAA
		protected override Vector3 GetEdgeOfColliderWorldPosition(CircularChainPointStretcherJoint chainPoint)
		{
			return this.m_CollidersDePntos[chainPoint].GetEdgeOfColliderWorldPosition();
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0001D8BD File Offset: 0x0001BABD
		protected override Vector3 GetColliderLocalOffset(CircularChainPointStretcherJoint chainPoint)
		{
			return this.m_CollidersDePntos[chainPoint].GetAddedLocalOffset();
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0001D8D0 File Offset: 0x0001BAD0
		protected sealed override void UpdateWallColliders()
		{
			bool isPenetrated = this.isPenetrated;
			float num = (isPenetrated ? 0.001f : 0.005f);
			float num2 = (isPenetrated ? 0.01f : 0.02f);
			float num3 = Mathf.InverseLerp(num, num2, base.estadoDePuntos.actualLocal.maxLimpiaLocalHole);
			this.m_CollidersDePntos[this.m_1030].UpdateCollider(num3, true);
			this.m_CollidersDePntos[this.m_12].UpdateCollider(num3, true);
			this.m_CollidersDePntos[this.m_130].UpdateCollider(num3, true);
			this.m_CollidersDePntos[this.m_3].UpdateCollider(num3, true);
			this.m_CollidersDePntos[this.m_430].UpdateCollider(num3, true);
			this.m_CollidersDePntos[this.m_6].UpdateCollider(num3, true);
			this.m_CollidersDePntos[this.m_730].UpdateCollider(num3, true);
			this.m_CollidersDePntos[this.m_9].UpdateCollider(num3, true);
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0001D9DC File Offset: 0x0001BBDC
		private void InitCreadorDePunto(CircularChainPointStretcherCreator creadorDePunto, Transform outter, Circular8BoneChain.Punto p, CircularChainPointCopier bone = null)
		{
			creadorDePunto.SetManualStart();
			creadorDePunto.configuracion = this.creatorConfig;
			creadorDePunto.configTipo = ChainPointStretcherJoint.ConfigTipo.anus;
			Rigidbody componentNotNull = creadorDePunto.GetComponentNotNull<Rigidbody>();
			componentNotNull.isKinematic = true;
			componentNotNull.useGravity = false;
			HoleWallPointCollider componentNotNull2 = creadorDePunto.GetComponentNotNull<HoleWallPointCollider>();
			componentNotNull2.SetManualStart();
			componentNotNull2.configuracion = this.colliderConfig;
			componentNotNull2.CrearColliders(this, Vector3.forward, (int)p);
			creadorDePunto.ManualStart();
			creadorDePunto.CrearPunto(outter);
			this.m_CollidersDePntos.Add(creadorDePunto.chainPointStretcherJoint, componentNotNull2);
			componentNotNull2.InitColliders();
			componentNotNull2.ManualStart();
			if (bone != null && this.activarCopiadores)
			{
				bone.Init(creadorDePunto.chainPointStretcherJoint);
				this.m_bonesCopiadores.Add(bone);
			}
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x0001DA92 File Offset: 0x0001BC92
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_PhysicMaterialWalls != null)
			{
				Object.DestroyImmediate(this.m_PhysicMaterialWalls);
			}
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x0001DAB4 File Offset: 0x0001BCB4
		private void OnSuavidadCambio()
		{
			if (this.m_points == null)
			{
				return;
			}
			foreach (CircularChainPointStretcherJoint circularChainPointStretcherJoint in this.m_points)
			{
				if (circularChainPointStretcherJoint)
				{
					circularChainPointStretcherJoint.suavidad = this.m_suavidad;
				}
			}
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x0001DB18 File Offset: 0x0001BD18
		private void OnSuavidadVerticalCambio()
		{
			if (this.m_points == null)
			{
				return;
			}
			foreach (CircularChainPointStretcherJoint circularChainPointStretcherJoint in this.m_points)
			{
				if (circularChainPointStretcherJoint)
				{
					circularChainPointStretcherJoint.suavidadVertical = this.m_suavidadVertical;
				}
			}
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x0001DB7C File Offset: 0x0001BD7C
		private void OnSuavidadHorizontalCambio()
		{
			if (this.m_points == null)
			{
				return;
			}
			foreach (CircularChainPointStretcherJoint circularChainPointStretcherJoint in this.m_points)
			{
				if (circularChainPointStretcherJoint)
				{
					circularChainPointStretcherJoint.suavidadHorizontal = this.m_suavidadHorizontal;
				}
			}
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x0001DBE0 File Offset: 0x0001BDE0
		public void IgnorarCollisionesConSigoMismo()
		{
			List<Collider> list = new List<Collider>();
			if (this.m_points != null && this.m_points.Count > 0)
			{
				foreach (CircularChainPointStretcherJoint circularChainPointStretcherJoint in this.m_points)
				{
					list.AddRange(circularChainPointStretcherJoint.ObtenerCollidersDePunto());
				}
			}
			list.Colisionar(delegate(Collider a, Collider b)
			{
				Physics.IgnoreCollision(a, b);
			});
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x0001DC74 File Offset: 0x0001BE74
		private void InitSuavidad()
		{
			this.m_lastSuavidad = this.m_suavidad;
			this.m_lastSuavidadVertical = this.m_suavidadVertical;
			this.m_lastSuavidadHorizontal = this.m_suavidadHorizontal;
			if (this.m_suavidad != 1f)
			{
				this.OnSuavidadCambio();
			}
			if (1f != this.m_suavidadVertical)
			{
				this.OnSuavidadVerticalCambio();
			}
			if (1f != this.m_suavidadHorizontal)
			{
				this.OnSuavidadHorizontalCambio();
			}
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x0001DD8E File Offset: 0x0001BF8E
		GameObject IHole.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x040004CC RID: 1228
		[ReadOnlyUI]
		[SerializeField]
		private int m_layer;

		// Token: 0x040004CD RID: 1229
		public bool activarCopiadores = true;

		// Token: 0x040004CE RID: 1230
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_entradaTransform;

		// Token: 0x040004CF RID: 1231
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_fondoTransform;

		// Token: 0x040004D0 RID: 1232
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_1030;

		// Token: 0x040004D1 RID: 1233
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_12;

		// Token: 0x040004D2 RID: 1234
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_130;

		// Token: 0x040004D3 RID: 1235
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_3;

		// Token: 0x040004D4 RID: 1236
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_430;

		// Token: 0x040004D5 RID: 1237
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_6;

		// Token: 0x040004D6 RID: 1238
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_730;

		// Token: 0x040004D7 RID: 1239
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_9;

		// Token: 0x040004D8 RID: 1240
		[Range(0.1f, 10f)]
		[SerializeField]
		private float m_suavidad = 1f;

		// Token: 0x040004D9 RID: 1241
		private float m_lastSuavidad = 1f;

		// Token: 0x040004DA RID: 1242
		[Range(0.1f, 10f)]
		[SerializeField]
		private float m_suavidadVertical = 1f;

		// Token: 0x040004DB RID: 1243
		private float m_lastSuavidadVertical = 1f;

		// Token: 0x040004DC RID: 1244
		[Range(0.1f, 10f)]
		[SerializeField]
		private float m_suavidadHorizontal = 1f;

		// Token: 0x040004DD RID: 1245
		private float m_lastSuavidadHorizontal = 1f;

		// Token: 0x040004DE RID: 1246
		private float m_defaultStaticFricc;

		// Token: 0x040004DF RID: 1247
		private float m_defaultDynamicFricc;

		// Token: 0x040004E0 RID: 1248
		private float? m_LastModFriccionGeneral;

		// Token: 0x040004E1 RID: 1249
		public ModificableDeFloat modificableDeFriccionGeneral = new ModificableDeFloat(1f);

		// Token: 0x040004E2 RID: 1250
		private PhysicMaterial m_PhysicMaterialWalls;

		// Token: 0x040004E3 RID: 1251
		public HoleWallPointCollider.Configuracion colliderConfig = new HoleWallPointCollider.Configuracion();

		// Token: 0x040004E4 RID: 1252
		public CircularChainPointStretcherCreator.Configuracion creatorConfig = new CircularChainPointStretcherCreator.Configuracion();

		// Token: 0x040004E5 RID: 1253
		private AnusHoleMap m_BoneMap;

		// Token: 0x040004E6 RID: 1254
		private Transform m_Root;

		// Token: 0x040004E7 RID: 1255
		private Dictionary<CircularChainPointStretcherJoint, HoleWallPointCollider> m_CollidersDePntos = new Dictionary<CircularChainPointStretcherJoint, HoleWallPointCollider>();

		// Token: 0x040004E8 RID: 1256
		private List<CircularChainPointCopier> m_bonesCopiadores = new List<CircularChainPointCopier>();

		// Token: 0x040004E9 RID: 1257
		private Character m_owner;

		// Token: 0x040004EA RID: 1258
		private IFemaleChar m_FemaleChar;

		// Token: 0x040004EB RID: 1259
		[NonSerialized]
		private HoleVirtualHardPoint m_hardPointDeRectus = new HoleVirtualHardPoint();

		// Token: 0x040004EC RID: 1260
		[NonSerialized]
		private HoleVirtualHardPoint m_hardPointDeIntestines = new HoleVirtualHardPoint();

		// Token: 0x040004ED RID: 1261
		private IAnusInternals m_AnusInternals;
	}
}
