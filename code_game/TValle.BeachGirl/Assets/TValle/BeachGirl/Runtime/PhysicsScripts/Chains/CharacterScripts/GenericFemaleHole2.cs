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
	// Token: 0x02000079 RID: 121
	public abstract class GenericFemaleHole2 : BoneStretchedChain, IFemaleHole, IHole, IPenetrable, IComponentStartable, IPhysicsHole
	{
		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x00008918 File Offset: 0x00006B18
		public Transform root
		{
			get
			{
				return this.m_Root;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x00008920 File Offset: 0x00006B20
		// (set) Token: 0x060002C2 RID: 706 RVA: 0x00008928 File Offset: 0x00006B28
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

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x00008937 File Offset: 0x00006B37
		// (set) Token: 0x060002C4 RID: 708 RVA: 0x0000893F File Offset: 0x00006B3F
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

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x0000894E File Offset: 0x00006B4E
		// (set) Token: 0x060002C6 RID: 710 RVA: 0x00008956 File Offset: 0x00006B56
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

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x00008965 File Offset: 0x00006B65
		public override CircularChainPointStretcherJoint _12
		{
			get
			{
				return this.m_12;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x0000896D File Offset: 0x00006B6D
		public override CircularChainPointStretcherJoint _6
		{
			get
			{
				return this.m_6;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x00008975 File Offset: 0x00006B75
		public Transform entradaTransform
		{
			get
			{
				return this.m_entradaTransform;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060002CA RID: 714 RVA: 0x0000897D File Offset: 0x00006B7D
		public override Transform fondoPhysics
		{
			get
			{
				return this.m_fondoTransform;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060002CB RID: 715 RVA: 0x00008985 File Offset: 0x00006B85
		public override Transform centroDePuntos
		{
			get
			{
				return this.entradaTransform;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060002CC RID: 716 RVA: 0x0000898D File Offset: 0x00006B8D
		public float defaultStaticFriccion
		{
			get
			{
				return this.m_defaultStaticFricc;
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060002CD RID: 717 RVA: 0x00008995 File Offset: 0x00006B95
		public float defaultDynamicFriccion
		{
			get
			{
				return this.m_defaultDynamicFricc;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060002CE RID: 718 RVA: 0x0000899D File Offset: 0x00006B9D
		public PhysicMaterial currentPhysicMaterial
		{
			get
			{
				return this.m_PhysicMaterialWalls;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060002CF RID: 719 RVA: 0x000089A5 File Offset: 0x00006BA5
		protected override bool chainRigidbodyIsKinematic
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x000089A8 File Offset: 0x00006BA8
		public sealed override ICharacter owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x000089B0 File Offset: 0x00006BB0
		public IFemaleChar femaleChar
		{
			get
			{
				return this.m_FemaleChar;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x000089B8 File Offset: 0x00006BB8
		public Character characterOwner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060002D3 RID: 723 RVA: 0x000089C0 File Offset: 0x00006BC0
		IFemaleChar IFemaleHole.femaleChar
		{
			get
			{
				return this.m_FemaleChar;
			}
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x000089C8 File Offset: 0x00006BC8
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

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060002D5 RID: 725
		protected abstract PhysicMaterial wallMaterial { get; }

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060002D6 RID: 726
		protected abstract string boneRootName { get; }

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060002D7 RID: 727
		protected abstract string boneEntradaName { get; }

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x00008A90 File Offset: 0x00006C90
		protected virtual string boneFondoName { get; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060002D9 RID: 729 RVA: 0x00008A98 File Offset: 0x00006C98
		protected virtual string boneEntradaDefName { get; }

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060002DA RID: 730
		protected abstract string _12Name { get; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060002DB RID: 731
		protected abstract string _6Name { get; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060002DC RID: 732
		protected abstract ChainPointStretcherJoint.ConfigTipo wallJointsConfigTipo { get; }

		// Token: 0x060002DD RID: 733 RVA: 0x00008AA0 File Offset: 0x00006CA0
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

		// Token: 0x060002DE RID: 734 RVA: 0x00008B50 File Offset: 0x00006D50
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

		// Token: 0x060002DF RID: 735 RVA: 0x00008C12 File Offset: 0x00006E12
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.IgnorarCollisionesConSigoMismo();
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00008C20 File Offset: 0x00006E20
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

		// Token: 0x060002E1 RID: 737 RVA: 0x00008C98 File Offset: 0x00006E98
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

		// Token: 0x060002E2 RID: 738 RVA: 0x00008D0B File Offset: 0x00006F0B
		public void ActualizarAperturaDefault(float apertura)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00008D14 File Offset: 0x00006F14
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
				CircularChainPointStretcherCreator componentNotNull2 = base.transform.FindDeepChild(this._6Name, true).GetComponentNotNull<CircularChainPointStretcherCreator>();
				this.InitCreadorDePunto(componentNotNull2, 1);
				this.m_6 = componentNotNull2.chainPointStretcherJoint;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, base.gameObject);
			}
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00008DDC File Offset: 0x00006FDC
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

		// Token: 0x060002E5 RID: 741 RVA: 0x00008E70 File Offset: 0x00007070
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

		// Token: 0x060002E6 RID: 742 RVA: 0x00008EDA File Offset: 0x000070DA
		protected override Vector3 GetEdgeOfColliderWorldPosition(CircularChainPointStretcherJoint chainPoint)
		{
			return this.m_CollidersDePntos[chainPoint].GetEdgeOfColliderWorldPosition();
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00008EED File Offset: 0x000070ED
		protected override Vector3 GetColliderLocalOffset(CircularChainPointStretcherJoint chainPoint)
		{
			return this.m_CollidersDePntos[chainPoint].GetAddedLocalOffset();
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00008F00 File Offset: 0x00007100
		private void InitCreadorDePunto(CircularChainPointStretcherCreator creadorDePunto, int puntoID)
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
			this.CrearColliders(componentNotNull2, puntoID);
			this.CrearPuntoCreandoStretchBase(creadorDePunto, base.transform, 0f, puntoID);
			this.m_CollidersDePntos.Add(creadorDePunto.chainPointStretcherJoint, componentNotNull2);
			componentNotNull2.InitColliders();
			componentNotNull2.ManualStart();
			creadorDePunto.ManualStart();
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00008F9B File Offset: 0x0000719B
		protected virtual void CrearColliders(HoleWallPointCollider col, int puntoID)
		{
			if (!this.creatorConfig.overrideOutDirection)
			{
				col.CrearColliders(this, Vector3.forward, puntoID);
				return;
			}
			col.CrearColliders(this, puntoID, this.creatorConfig.overridingOutDirection.normalized);
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00008FD0 File Offset: 0x000071D0
		protected virtual void CrearPuntoCreandoStretchBase(CircularChainPointStretcherCreator creadorDePunto, Transform pointParent, float upOffset, int puntoID)
		{
			creadorDePunto.CrearPuntoCreandoStretchBase(base.transform, upOffset);
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00008FDF File Offset: 0x000071DF
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_PhysicMaterialWalls != null)
			{
				Object.DestroyImmediate(this.m_PhysicMaterialWalls);
			}
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00009004 File Offset: 0x00007204
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

		// Token: 0x060002ED RID: 749 RVA: 0x00009068 File Offset: 0x00007268
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

		// Token: 0x060002EE RID: 750 RVA: 0x000090CC File Offset: 0x000072CC
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

		// Token: 0x060002F0 RID: 752 RVA: 0x000091B6 File Offset: 0x000073B6
		GameObject IHole.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x040001B2 RID: 434
		[Range(0.1f, 10f)]
		[SerializeField]
		private float m_suavidad = 1f;

		// Token: 0x040001B3 RID: 435
		private float m_lastSuavidad = 1f;

		// Token: 0x040001B4 RID: 436
		[Range(0.1f, 10f)]
		[SerializeField]
		private float m_suavidadVertical = 1f;

		// Token: 0x040001B5 RID: 437
		private float m_lastSuavidadVertical = 1f;

		// Token: 0x040001B6 RID: 438
		[Range(0.1f, 10f)]
		[SerializeField]
		private float m_suavidadHorizontal = 1f;

		// Token: 0x040001B7 RID: 439
		private float m_lastSuavidadHorizontal = 1f;

		// Token: 0x040001B8 RID: 440
		public CircularChainPointStretcherCreator.Configuracion creatorConfig = new CircularChainPointStretcherCreator.Configuracion();

		// Token: 0x040001B9 RID: 441
		public HoleWallPointCollider.Configuracion colliderConfig = new HoleWallPointCollider.Configuracion();

		// Token: 0x040001BA RID: 442
		private Transform m_Root;

		// Token: 0x040001BB RID: 443
		[ReadOnlyUI]
		[SerializeField]
		protected int m_layer;

		// Token: 0x040001BC RID: 444
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_12;

		// Token: 0x040001BD RID: 445
		[SerializeField]
		[ReadOnlyUI]
		private CircularChainPointStretcherJoint m_6;

		// Token: 0x040001BE RID: 446
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_entradaTransform;

		// Token: 0x040001BF RID: 447
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_fondoTransform;

		// Token: 0x040001C0 RID: 448
		private float m_defaultStaticFricc;

		// Token: 0x040001C1 RID: 449
		private float m_defaultDynamicFricc;

		// Token: 0x040001C2 RID: 450
		private float? m_LastModFriccionGeneral;

		// Token: 0x040001C3 RID: 451
		public ModificableDeFloat modificableDeFriccionGeneral = new ModificableDeFloat(1f);

		// Token: 0x040001C4 RID: 452
		private PhysicMaterial m_PhysicMaterialWalls;

		// Token: 0x040001C5 RID: 453
		private Dictionary<CircularChainPointStretcherJoint, HoleWallPointCollider> m_CollidersDePntos = new Dictionary<CircularChainPointStretcherJoint, HoleWallPointCollider>();

		// Token: 0x040001C6 RID: 454
		private Character m_owner;

		// Token: 0x040001C7 RID: 455
		private IFemaleChar m_FemaleChar;
	}
}
