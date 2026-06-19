using System;
using System.Collections.Generic;
using Assets.Base.Joints;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000E7 RID: 231
	public sealed class VagHole : Circular8BoneChain, IFemaleHole, IHole, IPenetrable, IComponentStartable, IPhysicsHole, IVagHole
	{
		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x06000981 RID: 2433 RVA: 0x0001E22F File Offset: 0x0001C42F
		public sealed override ICharacter owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x0001E237 File Offset: 0x0001C437
		public override int updateEvent3Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06000983 RID: 2435 RVA: 0x0001E23A File Offset: 0x0001C43A
		protected override bool useScaleBroadcaster
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x0001E23D File Offset: 0x0001C43D
		public VagHoleMap vagBoneMap
		{
			get
			{
				return this.m_vagBoneMap;
			}
		}

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06000985 RID: 2437 RVA: 0x0001E245 File Offset: 0x0001C445
		public ClitAndMiddleBoneMap clitAndMiddleBoneMap
		{
			get
			{
				return this.m_clitAndMiddleBoneMap;
			}
		}

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x0001E24D File Offset: 0x0001C44D
		public VagLabiaBonesMap vagLabiaBonesMap
		{
			get
			{
				return this.m_vagLabiaBonesMap;
			}
		}

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06000987 RID: 2439 RVA: 0x0001E255 File Offset: 0x0001C455
		public Transform vagRoot
		{
			get
			{
				return this.m_vagRoot;
			}
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x0001E25D File Offset: 0x0001C45D
		public Transform clitBaseTransform
		{
			get
			{
				return this.m_clitBaseTransform;
			}
		}

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06000989 RID: 2441 RVA: 0x0001E265 File Offset: 0x0001C465
		public Transform backLabiaPointIn
		{
			get
			{
				return this.m_backLabiaPointIn;
			}
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x0600098A RID: 2442 RVA: 0x0001E26D File Offset: 0x0001C46D
		// (set) Token: 0x0600098B RID: 2443 RVA: 0x0001E275 File Offset: 0x0001C475
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

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x0600098C RID: 2444 RVA: 0x0001E284 File Offset: 0x0001C484
		// (set) Token: 0x0600098D RID: 2445 RVA: 0x0001E28C File Offset: 0x0001C48C
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

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x0600098E RID: 2446 RVA: 0x0001E29B File Offset: 0x0001C49B
		// (set) Token: 0x0600098F RID: 2447 RVA: 0x0001E2A3 File Offset: 0x0001C4A3
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

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06000990 RID: 2448 RVA: 0x0001E2B2 File Offset: 0x0001C4B2
		public override CircularChainPointStretcherJoint _1030
		{
			get
			{
				return this.m_1030;
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06000991 RID: 2449 RVA: 0x0001E2BA File Offset: 0x0001C4BA
		public override CircularChainPointStretcherJoint _12
		{
			get
			{
				return this.m_12;
			}
		}

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06000992 RID: 2450 RVA: 0x0001E2C2 File Offset: 0x0001C4C2
		public override CircularChainPointStretcherJoint _130
		{
			get
			{
				return this.m_130;
			}
		}

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06000993 RID: 2451 RVA: 0x0001E2CA File Offset: 0x0001C4CA
		public override CircularChainPointStretcherJoint _3
		{
			get
			{
				return this.m_3;
			}
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x06000994 RID: 2452 RVA: 0x0001E2D2 File Offset: 0x0001C4D2
		public override CircularChainPointStretcherJoint _430
		{
			get
			{
				return this.m_430;
			}
		}

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x06000995 RID: 2453 RVA: 0x0001E2DA File Offset: 0x0001C4DA
		public override CircularChainPointStretcherJoint _6
		{
			get
			{
				return this.m_6;
			}
		}

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06000996 RID: 2454 RVA: 0x0001E2E2 File Offset: 0x0001C4E2
		public override CircularChainPointStretcherJoint _730
		{
			get
			{
				return this.m_730;
			}
		}

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06000997 RID: 2455 RVA: 0x0001E2EA File Offset: 0x0001C4EA
		public override CircularChainPointStretcherJoint _9
		{
			get
			{
				return this.m_9;
			}
		}

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06000998 RID: 2456 RVA: 0x0001E2F2 File Offset: 0x0001C4F2
		public Transform entradaTransform
		{
			get
			{
				return this.m_entradaTransform;
			}
		}

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06000999 RID: 2457 RVA: 0x0001E2FA File Offset: 0x0001C4FA
		public override Transform fondoPhysics
		{
			get
			{
				return this.m_fondoTransform;
			}
		}

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x0600099A RID: 2458 RVA: 0x0001E302 File Offset: 0x0001C502
		public override Transform centroDePuntos
		{
			get
			{
				return this.entradaTransform;
			}
		}

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x0600099B RID: 2459 RVA: 0x0001E30A File Offset: 0x0001C50A
		[Obsolete]
		public override FondoOfHole fondoOfHole
		{
			get
			{
				return this.m_FondoOfHole;
			}
		}

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x0600099C RID: 2460 RVA: 0x0001E312 File Offset: 0x0001C512
		public float defaultStaticFriccion
		{
			get
			{
				return this.m_defaultStaticFricc;
			}
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x0600099D RID: 2461 RVA: 0x0001E31A File Offset: 0x0001C51A
		public float defaultDynamicFriccion
		{
			get
			{
				return this.m_defaultDynamicFricc;
			}
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x0600099E RID: 2462 RVA: 0x0001E322 File Offset: 0x0001C522
		public PhysicMaterial currentPhysicMaterial
		{
			get
			{
				return this.m_PhysicMaterialVagWalls;
			}
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x0600099F RID: 2463 RVA: 0x0001E32A File Offset: 0x0001C52A
		protected override bool chainRigidbodyIsKinematic
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x060009A0 RID: 2464 RVA: 0x0001E32D File Offset: 0x0001C52D
		public IFemaleChar femaleChar
		{
			get
			{
				return this.m_FemaleChar;
			}
		}

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x060009A1 RID: 2465 RVA: 0x0001E335 File Offset: 0x0001C535
		public Character characterOwner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x060009A2 RID: 2466 RVA: 0x0001E33D File Offset: 0x0001C53D
		IFemaleChar IFemaleHole.femaleChar
		{
			get
			{
				return this.m_FemaleChar;
			}
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0001E348 File Offset: 0x0001C548
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

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x060009A4 RID: 2468 RVA: 0x0001E410 File Offset: 0x0001C610
		public override IHoleInternals internals
		{
			get
			{
				return this.m_VagInternals;
			}
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0001E418 File Offset: 0x0001C618
		protected override void AwakeUnityEvent()
		{
			this.m_VagInternals = this.GetComponentEnRoot(false);
			this.m_hardPointDeCervix.id = "CERVIX";
			this.m_hardPointDeCervix.SetProfundidadLocal(0.0975f);
			this.m_hardPointDeCervix.SetRadiusLocal(0.01666f);
			this.m_hardPointDeCervix.resistenciaMod = 1f;
			this.m_hardPointDeCervix.passResistenciaMod = 25f;
			this.m_hardPointDeCervix.maxDesgastePorSegundo = 0.01f;
			this.m_hardPointDeCervix.aiWeight = 1f;
			base.AddOrReplacePunto(this.m_hardPointDeCervix);
			this.m_layer = Singleton<ConfiguracionGeneral>.instance.layers.holePrimario;
			this.m_vagBoneMap = Singleton<MapasDeHuesos>.instance.mapas.vagHoleMap;
			this.m_vagLabiaBonesMap = Singleton<MapasDeHuesos>.instance.mapas.vagLabiaBonesMap;
			this.m_clitAndMiddleBoneMap = Singleton<MapasDeHuesos>.instance.mapas.clitAndMiddleBoneMap;
			if (this.m_vagBoneMap == null)
			{
				throw new ArgumentNullException("m_vagBoneMap", "m_vagBoneMap null reference.");
			}
			if (this.m_vagLabiaBonesMap == null)
			{
				throw new ArgumentNullException("m_vagLabiaBonesMap", "m_vagLabiaBonesMap null reference.");
			}
			if (this.m_clitAndMiddleBoneMap == null)
			{
				throw new ArgumentNullException("m_clitAndMiddleBoneMap", "m_clitAndMiddleBoneMap null reference.");
			}
			this.m_entradaTransform = base.transform.Find(this.m_vagBoneMap.entrada);
			if (this.m_entradaTransform == null)
			{
				throw new ArgumentNullException("m_entradaTransform", "m_entradaTransform null reference.");
			}
			this.creatorConfig.center = this.m_entradaTransform;
			base.AwakeUnityEvent();
			this.m_vagRoot = base.transform.FindDeepParent(this.m_vagBoneMap.vagRoot);
			if (this.m_vagRoot == null)
			{
				Debug.LogWarning("no se encontro vag root");
				this.m_vagRoot = base.transform.parent;
			}
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x0001E5F4 File Offset: 0x0001C7F4
		protected override void StartUnityEvent()
		{
			this.m_owner = base.GetComponentInParent<Character>();
			this.m_FemaleChar = this.m_owner as IFemaleChar;
			if (this.m_FemaleChar == null)
			{
				Debug.LogWarning("m_FemaleChar null reference.", this);
			}
			base.transform.ExecDeepChild(delegate(Transform t)
			{
				t.gameObject.layer = this.m_layer;
			}, true);
			this.m_clitBaseTransform = this.m_vagRoot.FindDeepChild(this.m_clitAndMiddleBoneMap.clitBase01Root, true);
			if (this.m_clitBaseTransform == null)
			{
				throw new ArgumentNullException("clitBaseTransform", "clitBaseTransform null reference.");
			}
			this.m_backLabiaPointIn = this.m_vagRoot.FindDeepChild(this.m_vagLabiaBonesMap.vagLabiaInBack, true);
			if (this.m_backLabiaPointIn == null)
			{
				throw new ArgumentNullException("m_backLabiaPoint", "m_backLabiaPoint null reference.");
			}
			base.DefaultGenerarFondoTransform(ref this.m_fondoTransform);
			this.AsignarPuntos();
			base.StartUnityEvent();
			HoleDeformationScaleAdmin componentNotNull = this.GetComponentNotNull<HoleDeformationScaleAdmin>();
			Transform transform = this.m_vagRoot.FindDeepChild(this.m_vagBoneMap.entradaDef, true);
			componentNotNull.Init(transform);
			this.InitSuavidad();
			this.StartJointHole();
			this.IgnorarCollisionesConSigoMismo();
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x0001E70D File Offset: 0x0001C90D
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.IgnorarCollisionesConSigoMismo();
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0001E71C File Offset: 0x0001C91C
		public override void OnUpdateEvent3()
		{
			float num = this.modificableDeFriccionGeneral.ModificarValor(1f);
			if (this.m_LastModFriccionGeneral == null || !ExtendedMonoBehaviour.AlmostEqual(this.m_LastModFriccionGeneral.Value, num, 0.01f))
			{
				this.m_LastModFriccionGeneral = new float?(num);
				this.m_PhysicMaterialVagWalls.dynamicFriction = this.m_defaultDynamicFricc * num;
				this.m_PhysicMaterialVagWalls.staticFriction = this.m_defaultStaticFricc * num;
			}
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x0001E791 File Offset: 0x0001C991
		private void StartJointHole()
		{
			this.m_VagHoleJoint = this.GetComponentNotNull<VagHoleJoint>();
			this.m_VagHoleJoint.configuracion = this.holeJointConfig;
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x0001E7B0 File Offset: 0x0001C9B0
		protected sealed override bool CercaDeHardPointsExtra()
		{
			return false;
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x0001E7B3 File Offset: 0x0001C9B3
		[Obsolete]
		private void AddFondoCollider()
		{
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x0001E7B8 File Offset: 0x0001C9B8
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

		// Token: 0x060009AD RID: 2477 RVA: 0x0001E82B File Offset: 0x0001CA2B
		public void ActualizarAperturaDefault(float apertura)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x0001E834 File Offset: 0x0001CA34
		public void AsignarPuntos()
		{
			if (this.m_vagBoneMap == null)
			{
				throw new ArgumentNullException("m_vagBoneMap", "m_vagBoneMap null reference.");
			}
			try
			{
				if (this.colliderConfig.material == null)
				{
					this.colliderConfig.material = Singleton<ColecionDePhysicsMaterials>.instance.innerVag;
				}
				this.m_PhysicMaterialVagWalls = Object.Instantiate<PhysicMaterial>(this.colliderConfig.material);
				this.colliderConfig.material = this.m_PhysicMaterialVagWalls;
				this.m_defaultStaticFricc = this.m_PhysicMaterialVagWalls.staticFriction;
				this.m_defaultDynamicFricc = this.m_PhysicMaterialVagWalls.dynamicFriction;
				CircularChainPointStretcherCreator componentNotNull = base.transform.Find(this.m_vagBoneMap._12).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull, Circular8BoneChain.Punto._12);
				this.m_12 = componentNotNull.chainPointStretcherJoint;
				CircularChainPointStretcherCreator componentNotNull2 = base.transform.Find(this.m_vagBoneMap._1030).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull2, Circular8BoneChain.Punto._1030);
				this.m_1030 = componentNotNull2.chainPointStretcherJoint;
				CircularChainPointStretcherCreator componentNotNull3 = base.transform.Find(this.m_vagBoneMap._130).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull3, Circular8BoneChain.Punto._130);
				this.m_130 = componentNotNull3.chainPointStretcherJoint;
				CircularChainPointStretcherCreator componentNotNull4 = base.transform.Find(this.m_vagBoneMap._3).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull4, Circular8BoneChain.Punto._3);
				this.m_3 = componentNotNull4.chainPointStretcherJoint;
				CircularChainPointStretcherCreator componentNotNull5 = base.transform.Find(this.m_vagBoneMap._430).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull5, Circular8BoneChain.Punto._430);
				this.m_430 = componentNotNull5.chainPointStretcherJoint;
				CircularChainPointStretcherCreator componentNotNull6 = base.transform.Find(this.m_vagBoneMap._6).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull6, Circular8BoneChain.Punto._6);
				this.m_6 = componentNotNull6.chainPointStretcherJoint;
				CircularChainPointStretcherCreator componentNotNull7 = base.transform.Find(this.m_vagBoneMap._730).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull7, Circular8BoneChain.Punto._730);
				this.m_730 = componentNotNull7.chainPointStretcherJoint;
				CircularChainPointStretcherCreator componentNotNull8 = base.transform.Find(this.m_vagBoneMap._9).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull8, Circular8BoneChain.Punto._9);
				this.m_9 = componentNotNull8.chainPointStretcherJoint;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, base.gameObject);
			}
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x0001EA88 File Offset: 0x0001CC88
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

		// Token: 0x060009B0 RID: 2480 RVA: 0x0001EB1C File Offset: 0x0001CD1C
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

		// Token: 0x060009B1 RID: 2481 RVA: 0x0001EB86 File Offset: 0x0001CD86
		protected override Vector3 GetEdgeOfColliderWorldPosition(CircularChainPointStretcherJoint chainPoint)
		{
			return this.m_CollidersDePntos[chainPoint].GetEdgeOfColliderWorldPosition();
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x0001EB99 File Offset: 0x0001CD99
		protected override Vector3 GetColliderLocalOffset(CircularChainPointStretcherJoint chainPoint)
		{
			return this.m_CollidersDePntos[chainPoint].GetAddedLocalOffset();
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x0001EBAC File Offset: 0x0001CDAC
		protected override void UpdateWallColliders()
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

		// Token: 0x060009B4 RID: 2484 RVA: 0x0001ECB8 File Offset: 0x0001CEB8
		private void InitCreadorDePunto(CircularChainPointStretcherCreator creadorDePunto, Circular8BoneChain.Punto p)
		{
			creadorDePunto.SetManualStart();
			creadorDePunto.configuracion = this.creatorConfig;
			creadorDePunto.configTipo = ChainPointStretcherJoint.ConfigTipo.vag;
			Rigidbody componentNotNull = creadorDePunto.GetComponentNotNull<Rigidbody>();
			componentNotNull.isKinematic = true;
			componentNotNull.useGravity = false;
			VagPointCollider componentNotNull2 = creadorDePunto.GetComponentNotNull<VagPointCollider>();
			componentNotNull2.SetManualStart();
			componentNotNull2.configuracion = this.colliderConfig;
			componentNotNull2.CrearColliders(this, p);
			if (p != Circular8BoneChain.Punto._6)
			{
				creadorDePunto.CrearPuntoCreandoStretchBase(base.transform, 0f);
				this.m_CollidersDePntos.Add(creadorDePunto.chainPointStretcherJoint, componentNotNull2);
			}
			switch (p)
			{
			case Circular8BoneChain.Punto._12:
				componentNotNull2.CrearColliderApertura(this);
				break;
			case Circular8BoneChain.Punto._6:
				creadorDePunto.CrearPuntoCreandoStretchBase(base.transform, -0.006f);
				this.m_CollidersDePntos.Add(creadorDePunto.chainPointStretcherJoint, componentNotNull2);
				break;
			case Circular8BoneChain.Punto._130:
			case Circular8BoneChain.Punto._1030:
			{
				VagPointCollider vagPointCollider = this.m_CollidersDePntos[this._12];
				componentNotNull2.CrearColliderApertura(this);
				componentNotNull2.ActualizarAperturaDireccionPorDefecto(vagPointCollider.coliderSegundarioTransform.forward);
				break;
			}
			}
			componentNotNull2.InitColliders();
			componentNotNull2.ManualStart();
			creadorDePunto.ManualStart();
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0001EDCB File Offset: 0x0001CFCB
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_PhysicMaterialVagWalls != null)
			{
				Object.DestroyImmediate(this.m_PhysicMaterialVagWalls);
			}
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x0001EDF0 File Offset: 0x0001CFF0
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

		// Token: 0x060009B7 RID: 2487 RVA: 0x0001EE54 File Offset: 0x0001D054
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

		// Token: 0x060009B8 RID: 2488 RVA: 0x0001EEB8 File Offset: 0x0001D0B8
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

		// Token: 0x060009BA RID: 2490 RVA: 0x0001EFB8 File Offset: 0x0001D1B8
		GameObject IHole.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x040004FB RID: 1275
		[ReadOnlyUI]
		[SerializeField]
		private int m_layer;

		// Token: 0x040004FC RID: 1276
		private Transform m_vagRoot;

		// Token: 0x040004FD RID: 1277
		private Transform m_clitBaseTransform;

		// Token: 0x040004FE RID: 1278
		private Transform m_backLabiaPointIn;

		// Token: 0x040004FF RID: 1279
		private VagHoleMap m_vagBoneMap;

		// Token: 0x04000500 RID: 1280
		private ClitAndMiddleBoneMap m_clitAndMiddleBoneMap;

		// Token: 0x04000501 RID: 1281
		private VagLabiaBonesMap m_vagLabiaBonesMap;

		// Token: 0x04000502 RID: 1282
		public CircularChainPointStretcherCreator.Configuracion creatorConfig = new CircularChainPointStretcherCreator.Configuracion();

		// Token: 0x04000503 RID: 1283
		public VagPointCollider.Configuracion colliderConfig = new VagPointCollider.Configuracion();

		// Token: 0x04000504 RID: 1284
		public VagHoleJoint.Configuracion holeJointConfig = new VagHoleJoint.Configuracion();

		// Token: 0x04000505 RID: 1285
		[Range(0.1f, 10f)]
		[SerializeField]
		private float m_suavidad = 1f;

		// Token: 0x04000506 RID: 1286
		private float m_lastSuavidad = 1f;

		// Token: 0x04000507 RID: 1287
		[Range(0.1f, 10f)]
		[SerializeField]
		private float m_suavidadVertical = 1f;

		// Token: 0x04000508 RID: 1288
		private float m_lastSuavidadVertical = 1f;

		// Token: 0x04000509 RID: 1289
		[Range(0.1f, 10f)]
		[SerializeField]
		private float m_suavidadHorizontal = 1f;

		// Token: 0x0400050A RID: 1290
		private float m_lastSuavidadHorizontal = 1f;

		// Token: 0x0400050B RID: 1291
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_1030;

		// Token: 0x0400050C RID: 1292
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_12;

		// Token: 0x0400050D RID: 1293
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_130;

		// Token: 0x0400050E RID: 1294
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_3;

		// Token: 0x0400050F RID: 1295
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_430;

		// Token: 0x04000510 RID: 1296
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_6;

		// Token: 0x04000511 RID: 1297
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_730;

		// Token: 0x04000512 RID: 1298
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_9;

		// Token: 0x04000513 RID: 1299
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_entradaTransform;

		// Token: 0x04000514 RID: 1300
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_fondoTransform;

		// Token: 0x04000515 RID: 1301
		[Obsolete]
		private FondoOfHole m_FondoOfHole;

		// Token: 0x04000516 RID: 1302
		[SerializeField]
		[ReadOnlyUI]
		private VagHoleJoint m_VagHoleJoint;

		// Token: 0x04000517 RID: 1303
		private float m_defaultStaticFricc;

		// Token: 0x04000518 RID: 1304
		private float m_defaultDynamicFricc;

		// Token: 0x04000519 RID: 1305
		private float? m_LastModFriccionGeneral;

		// Token: 0x0400051A RID: 1306
		public ModificableDeFloat modificableDeFriccionGeneral = new ModificableDeFloat(1f);

		// Token: 0x0400051B RID: 1307
		private PhysicMaterial m_PhysicMaterialVagWalls;

		// Token: 0x0400051C RID: 1308
		private Dictionary<CircularChainPointStretcherJoint, VagPointCollider> m_CollidersDePntos = new Dictionary<CircularChainPointStretcherJoint, VagPointCollider>();

		// Token: 0x0400051D RID: 1309
		private Character m_owner;

		// Token: 0x0400051E RID: 1310
		private IFemaleChar m_FemaleChar;

		// Token: 0x0400051F RID: 1311
		[NonSerialized]
		private HoleVirtualHardPoint m_hardPointDeCervix = new HoleVirtualHardPoint();

		// Token: 0x04000520 RID: 1312
		private IVagInternals m_VagInternals;
	}
}
