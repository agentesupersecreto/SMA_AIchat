using System;
using System.Collections.Generic;
using Assets.Base.Joints;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts
{
	// Token: 0x0200007A RID: 122
	[Obsolete("", true)]
	public abstract class GenericFemaleHole8 : Circular8BoneChain, IFemaleHole, IHole, IPenetrable, IComponentStartable, IPhysicsHole
	{
		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x000091D1 File Offset: 0x000073D1
		public Transform root
		{
			get
			{
				return this.m_Root;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x000091D9 File Offset: 0x000073D9
		// (set) Token: 0x060002F4 RID: 756 RVA: 0x000091E1 File Offset: 0x000073E1
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

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x000091F0 File Offset: 0x000073F0
		// (set) Token: 0x060002F6 RID: 758 RVA: 0x000091F8 File Offset: 0x000073F8
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

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x00009207 File Offset: 0x00007407
		// (set) Token: 0x060002F8 RID: 760 RVA: 0x0000920F File Offset: 0x0000740F
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

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x0000921E File Offset: 0x0000741E
		public override CircularChainPointStretcherJoint _1030
		{
			get
			{
				return this.m_1030;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060002FA RID: 762 RVA: 0x00009226 File Offset: 0x00007426
		public override CircularChainPointStretcherJoint _12
		{
			get
			{
				return this.m_12;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060002FB RID: 763 RVA: 0x0000922E File Offset: 0x0000742E
		public override CircularChainPointStretcherJoint _130
		{
			get
			{
				return this.m_130;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060002FC RID: 764 RVA: 0x00009236 File Offset: 0x00007436
		public override CircularChainPointStretcherJoint _3
		{
			get
			{
				return this.m_3;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060002FD RID: 765 RVA: 0x0000923E File Offset: 0x0000743E
		public override CircularChainPointStretcherJoint _430
		{
			get
			{
				return this.m_430;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060002FE RID: 766 RVA: 0x00009246 File Offset: 0x00007446
		public override CircularChainPointStretcherJoint _6
		{
			get
			{
				return this.m_6;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060002FF RID: 767 RVA: 0x0000924E File Offset: 0x0000744E
		public override CircularChainPointStretcherJoint _730
		{
			get
			{
				return this.m_730;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000300 RID: 768 RVA: 0x00009256 File Offset: 0x00007456
		public override CircularChainPointStretcherJoint _9
		{
			get
			{
				return this.m_9;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000301 RID: 769 RVA: 0x0000925E File Offset: 0x0000745E
		public Transform entradaTransform
		{
			get
			{
				return this.m_entradaTransform;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000302 RID: 770 RVA: 0x00009266 File Offset: 0x00007466
		public override Transform fondoPhysics
		{
			get
			{
				return this.m_fondoTransform;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000303 RID: 771 RVA: 0x0000926E File Offset: 0x0000746E
		public override Transform centroDePuntos
		{
			get
			{
				return this.entradaTransform;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000304 RID: 772 RVA: 0x00009276 File Offset: 0x00007476
		public float defaultStaticFriccion
		{
			get
			{
				return this.m_defaultStaticFricc;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000305 RID: 773 RVA: 0x0000927E File Offset: 0x0000747E
		public float defaultDynamicFriccion
		{
			get
			{
				return this.m_defaultDynamicFricc;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000306 RID: 774 RVA: 0x00009286 File Offset: 0x00007486
		public PhysicMaterial currentPhysicMaterial
		{
			get
			{
				return this.m_PhysicMaterialWalls;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000307 RID: 775 RVA: 0x0000928E File Offset: 0x0000748E
		protected override bool chainRigidbodyIsKinematic
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000308 RID: 776 RVA: 0x00009291 File Offset: 0x00007491
		public sealed override ICharacter owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000309 RID: 777 RVA: 0x00009299 File Offset: 0x00007499
		public IFemaleChar femaleChar
		{
			get
			{
				return this.m_FemaleChar;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600030A RID: 778 RVA: 0x000092A1 File Offset: 0x000074A1
		public Character characterOwner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600030B RID: 779 RVA: 0x000092A9 File Offset: 0x000074A9
		IFemaleChar IFemaleHole.femaleChar
		{
			get
			{
				return this.m_FemaleChar;
			}
		}

		// Token: 0x0600030C RID: 780 RVA: 0x000092B4 File Offset: 0x000074B4
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

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x0600030D RID: 781
		protected abstract PhysicMaterial wallMaterial { get; }

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x0600030E RID: 782
		protected abstract string boneRootName { get; }

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600030F RID: 783
		protected abstract string boneEntradaName { get; }

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000310 RID: 784 RVA: 0x0000937C File Offset: 0x0000757C
		protected virtual string boneFondoName { get; }

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000311 RID: 785 RVA: 0x00009384 File Offset: 0x00007584
		protected virtual string boneEntradaDefName { get; }

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000312 RID: 786
		protected abstract string _12Name { get; }

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000313 RID: 787
		protected abstract string _130Name { get; }

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000314 RID: 788
		protected abstract string _3Name { get; }

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000315 RID: 789
		protected abstract string _430Name { get; }

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000316 RID: 790
		protected abstract string _6Name { get; }

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000317 RID: 791
		protected abstract string _730Name { get; }

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000318 RID: 792
		protected abstract string _9Name { get; }

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000319 RID: 793
		protected abstract string _1030Name { get; }

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x0600031A RID: 794
		protected abstract ChainPointStretcherJoint.ConfigTipo wallJointsConfigTipo { get; }

		// Token: 0x0600031B RID: 795 RVA: 0x0000938C File Offset: 0x0000758C
		protected override void AwakeUnityEvent()
		{
			this.m_layer = Singleton<ConfiguracionGeneral>.instance.layers.holePrimario;
			this.m_entradaTransform = base.transform.FindDeepChild(this.boneEntradaName, true);
			if (this.m_entradaTransform == null)
			{
				throw new ArgumentNullException("m_entradaTransform", "m_entradaTransform null reference.");
			}
			this.creatorConfig.center = this.m_entradaTransform;
			base.AwakeUnityEvent();
			this.m_Root = base.transform.FindDeepParent(this.boneRootName);
			if (this.m_Root == null)
			{
				Debug.LogWarning("no se encontro vag root");
				this.m_Root = base.transform.parent;
			}
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0000943C File Offset: 0x0000763C
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
			this.m_fondoTransform = base.transform.FindDeepChild(this.boneFondoName, false);
			base.DefaultGenerarFondoTransform(ref this.m_fondoTransform);
			this.AsignarPuntos();
			base.StartUnityEvent();
			if (!string.IsNullOrEmpty(this.boneEntradaDefName))
			{
				HoleDeformationScaleAdmin componentNotNull = this.GetComponentNotNull<HoleDeformationScaleAdmin>();
				Transform transform = this.m_Root.FindDeepChild(this.boneEntradaDefName, true);
				componentNotNull.Init(transform);
			}
			this.InitSuavidad();
			this.IgnorarCollisionesConSigoMismo();
		}

		// Token: 0x0600031D RID: 797 RVA: 0x000094FE File Offset: 0x000076FE
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.IgnorarCollisionesConSigoMismo();
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0000950C File Offset: 0x0000770C
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

		// Token: 0x0600031F RID: 799 RVA: 0x00009584 File Offset: 0x00007784
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

		// Token: 0x06000320 RID: 800 RVA: 0x000095F7 File Offset: 0x000077F7
		public void ActualizarAperturaDefault(float apertura)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00009600 File Offset: 0x00007800
		public void AsignarPuntos()
		{
			try
			{
				this.m_PhysicMaterialWalls = Object.Instantiate<PhysicMaterial>(this.wallMaterial);
				this.colliderConfig.material = this.m_PhysicMaterialWalls;
				this.m_defaultStaticFricc = this.m_PhysicMaterialWalls.staticFriction;
				this.m_defaultDynamicFricc = this.m_PhysicMaterialWalls.dynamicFriction;
				CircularChainPointStretcherCreator componentNotNull = base.transform.FindDeepChild(this._12Name, true).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull, 0);
				this.m_12 = componentNotNull.chainPointStretcherJoint;
				CircularChainPointStretcherCreator componentNotNull2 = base.transform.FindDeepChild(this._1030Name, true).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull2, 6);
				this.m_1030 = componentNotNull2.chainPointStretcherJoint;
				CircularChainPointStretcherCreator componentNotNull3 = base.transform.FindDeepChild(this._130Name, true).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull3, 4);
				this.m_130 = componentNotNull3.chainPointStretcherJoint;
				CircularChainPointStretcherCreator componentNotNull4 = base.transform.FindDeepChild(this._3Name, true).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull4, 2);
				this.m_3 = componentNotNull4.chainPointStretcherJoint;
				CircularChainPointStretcherCreator componentNotNull5 = base.transform.FindDeepChild(this._430Name, true).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull5, 5);
				this.m_430 = componentNotNull5.chainPointStretcherJoint;
				CircularChainPointStretcherCreator componentNotNull6 = base.transform.FindDeepChild(this._6Name, true).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull6, 1);
				this.m_6 = componentNotNull6.chainPointStretcherJoint;
				CircularChainPointStretcherCreator componentNotNull7 = base.transform.FindDeepChild(this._730Name, true).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull7, 7);
				this.m_730 = componentNotNull7.chainPointStretcherJoint;
				CircularChainPointStretcherCreator componentNotNull8 = base.transform.FindDeepChild(this._9Name, true).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull8, 3);
				this.m_9 = componentNotNull8.chainPointStretcherJoint;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, base.gameObject);
			}
		}

		// Token: 0x06000322 RID: 802 RVA: 0x000097E8 File Offset: 0x000079E8
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

		// Token: 0x06000323 RID: 803 RVA: 0x0000987C File Offset: 0x00007A7C
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

		// Token: 0x06000324 RID: 804 RVA: 0x000098E8 File Offset: 0x00007AE8
		private void InitCreadorDePunto(CircularChainPointStretcherCreator creadorDePunto, int p)
		{
			creadorDePunto.SetManualStart();
			creadorDePunto.configuracion = this.creatorConfig.Copy();
			creadorDePunto.configTipo = this.wallJointsConfigTipo;
			Rigidbody componentNotNull = creadorDePunto.GetComponentNotNull<Rigidbody>();
			componentNotNull.isKinematic = true;
			componentNotNull.useGravity = false;
			HoleWallPointCollider componentNotNull2 = creadorDePunto.GetComponentNotNull<HoleWallPointCollider>();
			componentNotNull2.SetManualStart();
			componentNotNull2.configuracion = this.colliderConfig;
			this.CrearColliders(componentNotNull2, p);
			this.CrearPuntoCreandoStretchBase(creadorDePunto, base.transform, 0f, p);
			this.m_CollidersDePntos.Add(creadorDePunto.chainPointStretcherJoint, componentNotNull2);
			componentNotNull2.InitColliders();
			componentNotNull2.ManualStart();
			creadorDePunto.ManualStart();
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00009983 File Offset: 0x00007B83
		protected virtual void CrearColliders(HoleWallPointCollider col, int puntoID)
		{
			if (!this.creatorConfig.overrideOutDirection)
			{
				col.CrearColliders(this, Vector3.forward, puntoID);
				return;
			}
			col.CrearColliders(this, puntoID, this.creatorConfig.overridingOutDirection.normalized);
		}

		// Token: 0x06000326 RID: 806 RVA: 0x000099B8 File Offset: 0x00007BB8
		protected virtual void CrearPuntoCreandoStretchBase(CircularChainPointStretcherCreator creadorDePunto, Transform pointParent, float upOffset, int puntoID)
		{
			creadorDePunto.CrearPuntoCreandoStretchBase(base.transform, upOffset);
		}

		// Token: 0x06000327 RID: 807 RVA: 0x000099C7 File Offset: 0x00007BC7
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_PhysicMaterialWalls != null)
			{
				Object.DestroyImmediate(this.m_PhysicMaterialWalls);
			}
		}

		// Token: 0x06000328 RID: 808 RVA: 0x000099EC File Offset: 0x00007BEC
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

		// Token: 0x06000329 RID: 809 RVA: 0x00009A50 File Offset: 0x00007C50
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

		// Token: 0x0600032A RID: 810 RVA: 0x00009AB4 File Offset: 0x00007CB4
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

		// Token: 0x0600032C RID: 812 RVA: 0x00009B9E File Offset: 0x00007D9E
		GameObject IHole.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x040001CA RID: 458
		[Range(0.1f, 10f)]
		[SerializeField]
		private float m_suavidad = 1f;

		// Token: 0x040001CB RID: 459
		private float m_lastSuavidad = 1f;

		// Token: 0x040001CC RID: 460
		[Range(0.1f, 10f)]
		[SerializeField]
		private float m_suavidadVertical = 1f;

		// Token: 0x040001CD RID: 461
		private float m_lastSuavidadVertical = 1f;

		// Token: 0x040001CE RID: 462
		[Range(0.1f, 10f)]
		[SerializeField]
		private float m_suavidadHorizontal = 1f;

		// Token: 0x040001CF RID: 463
		private float m_lastSuavidadHorizontal = 1f;

		// Token: 0x040001D0 RID: 464
		public CircularChainPointStretcherCreator.Configuracion creatorConfig = new CircularChainPointStretcherCreator.Configuracion();

		// Token: 0x040001D1 RID: 465
		public HoleWallPointCollider.Configuracion colliderConfig = new HoleWallPointCollider.Configuracion();

		// Token: 0x040001D2 RID: 466
		private Transform m_Root;

		// Token: 0x040001D3 RID: 467
		[ReadOnlyUI]
		[SerializeField]
		protected int m_layer;

		// Token: 0x040001D4 RID: 468
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_1030;

		// Token: 0x040001D5 RID: 469
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_12;

		// Token: 0x040001D6 RID: 470
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_130;

		// Token: 0x040001D7 RID: 471
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_3;

		// Token: 0x040001D8 RID: 472
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_430;

		// Token: 0x040001D9 RID: 473
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_6;

		// Token: 0x040001DA RID: 474
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_730;

		// Token: 0x040001DB RID: 475
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_9;

		// Token: 0x040001DC RID: 476
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_entradaTransform;

		// Token: 0x040001DD RID: 477
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_fondoTransform;

		// Token: 0x040001DE RID: 478
		private float m_defaultStaticFricc;

		// Token: 0x040001DF RID: 479
		private float m_defaultDynamicFricc;

		// Token: 0x040001E0 RID: 480
		private float? m_LastModFriccionGeneral;

		// Token: 0x040001E1 RID: 481
		public ModificableDeFloat modificableDeFriccionGeneral = new ModificableDeFloat(1f);

		// Token: 0x040001E2 RID: 482
		private PhysicMaterial m_PhysicMaterialWalls;

		// Token: 0x040001E3 RID: 483
		private Dictionary<CircularChainPointStretcherJoint, HoleWallPointCollider> m_CollidersDePntos = new Dictionary<CircularChainPointStretcherJoint, HoleWallPointCollider>();

		// Token: 0x040001E4 RID: 484
		private Character m_owner;

		// Token: 0x040001E5 RID: 485
		private IFemaleChar m_FemaleChar;
	}
}
