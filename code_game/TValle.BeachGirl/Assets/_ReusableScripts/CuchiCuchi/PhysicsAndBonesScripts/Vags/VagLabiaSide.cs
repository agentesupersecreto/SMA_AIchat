using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Vags
{
	// Token: 0x02000110 RID: 272
	public class VagLabiaSide : Linear7BoneChain<VagLabiaPoint>
	{
		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x06000BFC RID: 3068 RVA: 0x000285B0 File Offset: 0x000267B0
		public override VagLabiaPoint _000
		{
			get
			{
				return this.m_point.m_000;
			}
		}

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x06000BFD RID: 3069 RVA: 0x000285BD File Offset: 0x000267BD
		public override VagLabiaPoint _001
		{
			get
			{
				return this.m_point.m_001;
			}
		}

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x06000BFE RID: 3070 RVA: 0x000285CA File Offset: 0x000267CA
		public override VagLabiaPoint _002
		{
			get
			{
				return this.m_point.m_002;
			}
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x06000BFF RID: 3071 RVA: 0x000285D7 File Offset: 0x000267D7
		public override VagLabiaPoint _003
		{
			get
			{
				return this.m_point.m_003;
			}
		}

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x06000C00 RID: 3072 RVA: 0x000285E4 File Offset: 0x000267E4
		public override VagLabiaPoint _004
		{
			get
			{
				return this.m_point.m_004;
			}
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x06000C01 RID: 3073 RVA: 0x000285F1 File Offset: 0x000267F1
		public override VagLabiaPoint _005
		{
			get
			{
				return this.m_point.m_005;
			}
		}

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x06000C02 RID: 3074 RVA: 0x000285FE File Offset: 0x000267FE
		public override VagLabiaPoint _006
		{
			get
			{
				return this.m_point.m_006;
			}
		}

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x06000C03 RID: 3075 RVA: 0x0002860B File Offset: 0x0002680B
		// (set) Token: 0x06000C04 RID: 3076 RVA: 0x00028613 File Offset: 0x00026813
		public Side side
		{
			get
			{
				return this.m_side;
			}
			set
			{
				this.m_side = value;
			}
		}

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x06000C05 RID: 3077 RVA: 0x0002861C File Offset: 0x0002681C
		public ModificadorDeDriversDeJoint suavizadorGeneralDeSide
		{
			get
			{
				return this.m_suavizadorGeneralDeSide;
			}
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x00028624 File Offset: 0x00026824
		protected override void StartUnityEvent()
		{
			this.m_VagHole = this.GetComponentEnRoot(false);
			this.m_suavizadorGeneralDeSide = new ModificadorDeDriversDeJoint("Mod de " + base.name + " side " + this.m_side.ToString());
			this.LoadPoints();
			base.StartUnityEvent();
			this.CrearPointToPointJoints();
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x00028684 File Offset: 0x00026884
		private void CrearPointToPointJoints()
		{
			VagLabiaPoint backPoint = this.vagLabia.backPoint;
			this.AddPointToPointJoint(this._000.otherBody, this._001.otherBody, this.pointToPointJointConfig, 0);
			this.AddPointToPointJoint(this._001.otherBody, this._002.otherBody, this.pointToPointJointConfig, 1);
			this.AddPointToPointJoint(this._002.otherBody, this._003.otherBody, this.pointToPointJointConfig, 2);
			this.AddPointToPointJoint(this._003.otherBody, this._004.otherBody, this.pointToPointJointConfig, 3);
			this.AddPointToPointJoint(this._004.otherBody, this._005.otherBody, this.pointToPointJointConfig, 4);
			this.AddPointToPointJoint(this._005.otherBody, this._006.otherBody, this.pointToPointJointConfig, 5);
			this.AddPointToPointJoint(this._006.otherBody, backPoint.otherBody, this.pointToPointJointConfig, 6);
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x00028790 File Offset: 0x00026990
		public List<SphereCollider> ObtenerColliders()
		{
			List<SphereCollider> list = new List<SphereCollider>();
			foreach (VagLabiaPoint vagLabiaPoint in base.puntos)
			{
				foreach (Collider collider in vagLabiaPoint.vagLabiaPointColliders.colliders)
				{
					SphereCollider sphereCollider = collider as SphereCollider;
					if (sphereCollider != null)
					{
						list.Add(sphereCollider);
					}
				}
			}
			return list;
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x0002882C File Offset: 0x00026A2C
		public sealed override void OnUpdateEvent2()
		{
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x00028830 File Offset: 0x00026A30
		public sealed override void OnUpdateEvent6()
		{
			float num = ((!this.m_VagHole.isPenetrated) ? 0f : Mathf.InverseLerp(0.001f, 0.006f, this.vagLabia.GetMaxAnchuraLimpiaLocal()));
			for (int i = 0; i < base.puntos.Count; i++)
			{
				base.puntos[i].vagLabiaPointColliders.UpdateCollider(num, true);
			}
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x0002889C File Offset: 0x00026A9C
		private void AddPointToPointJoint(Rigidbody current, Rigidbody target, VagLipPointToPointJoint.Configuraciones pointToPointJointConfig, int index)
		{
			VagLipPointToPointJoint vagLipPointToPointJoint = current.gameObject.AddComponent<VagLipPointToPointJoint>();
			vagLipPointToPointJoint.SetManualStart();
			vagLipPointToPointJoint.SetConnectedBody(target, index, this.m_suavizadorGeneralDeSide);
			vagLipPointToPointJoint.configuraciones = pointToPointJointConfig;
			vagLipPointToPointJoint.ManualStart();
			this.m_pointToPointJoints.Add(vagLipPointToPointJoint);
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x000288E3 File Offset: 0x00026AE3
		public bool IsTouchedByAny()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x000288EA File Offset: 0x00026AEA
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.FixPointToPointJoints();
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x000288F8 File Offset: 0x00026AF8
		public void FixPointToPointJoints()
		{
			foreach (VagLipPointToPointJoint vagLipPointToPointJoint in this.m_pointToPointJoints)
			{
				vagLipPointToPointJoint.UpdateFixers();
			}
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x00028948 File Offset: 0x00026B48
		[Obsolete]
		public void IgnoreSelfCollisions()
		{
			List<Collider> list = new List<Collider>();
			if (base.puntos != null && base.puntos.Count > 0)
			{
				foreach (VagLabiaPoint vagLabiaPoint in base.puntos)
				{
					list.AddRange(vagLabiaPoint.vagLabiaPointColliders.colliders);
				}
			}
			list.Colisionar(delegate(Collider a, Collider b)
			{
				Physics.IgnoreCollision(a, b);
			});
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x000289E0 File Offset: 0x00026BE0
		protected void LoadPoints()
		{
			if (this.map == null)
			{
				throw new ArgumentNullException("map", "map null reference.");
			}
			Transform transform = base.transform.FindDeepParent(this.map.vagRoot).FindDeepChild(this.map.vagLabiaRoot, true);
			if (transform != base.transform)
			{
				throw new InvalidOperationException();
			}
			VagLabiaSide.LoadSidePoint(ref this.m_point.m_000, this.vagLabia, this.vagLabiaPointConfiguracion, this.side, this.map.inLabia._000, this.map.outLabia._000, transform, this.colliderConfig, true, this.vagLabia.maximasAperturas._000);
			VagLabiaSide.LoadSidePoint(ref this.m_point.m_001, this.vagLabia, this.vagLabiaPointConfiguracion, this.side, this.map.inLabia._001, this.map.outLabia._001, transform, this.colliderConfig, true, this.vagLabia.maximasAperturas._001);
			VagLabiaSide.LoadSidePoint(ref this.m_point.m_002, this.vagLabia, this.vagLabiaPointConfiguracion, this.side, this.map.inLabia._002, this.map.outLabia._002, transform, this.colliderConfig, true, this.vagLabia.maximasAperturas._002);
			VagLabiaSide.LoadSidePoint(ref this.m_point.m_003, this.vagLabia, this.vagLabiaPointConfiguracion, this.side, this.map.inLabia._003, this.map.outLabia._003, transform, this.colliderConfig, true, this.vagLabia.maximasAperturas._003);
			VagLabiaSide.LoadSidePoint(ref this.m_point.m_004, this.vagLabia, this.vagLabiaPointConfiguracion, this.side, this.map.inLabia._004, this.map.outLabia._004, transform, this.colliderConfig, true, this.vagLabia.maximasAperturas._004);
			VagLabiaSide.LoadSidePoint(ref this.m_point.m_005, this.vagLabia, this.vagLabiaPointConfiguracion, this.side, this.map.inLabia._005, this.map.outLabia._005, transform, this.colliderConfig, true, this.vagLabia.maximasAperturas._005);
			VagLabiaSide.LoadSidePoint(ref this.m_point.m_006, this.vagLabia, this.vagLabiaPointConfiguracion, this.side, this.map.inLabia._006, this.map.outLabia._006, transform, this.colliderConfig, true, this.vagLabia.maximasAperturas._006);
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x00028CC0 File Offset: 0x00026EC0
		public static void LoadSidePoint(ref VagLabiaPoint point, VagLabia vagLabia, VagLabiaPoint.VagLabiaPointConfiguracion vagLabiaPointConfiguracion, Side side, BoneNameIndexPar inLabiaPar, BoneNameIndexPar outLabiaPar, Transform labiaRoot, VagLabiaPointColliders.Configuracion colliderConfig, bool startPoint, float maxAperture = 3.4028235E+38f)
		{
			Transform transform = labiaRoot.FindDeepChild(inLabiaPar.Get_FullName(side), true);
			if (transform == null)
			{
				throw new ArgumentNullException("inTrans", "inTrans null reference.");
			}
			Transform transform2 = labiaRoot.FindDeepChild(outLabiaPar.Get_FullName(side), true);
			if (transform2 == null)
			{
				throw new ArgumentNullException("outTrans", "outTrans null reference.");
			}
			VagLabiaSide.LoadPoint(ref point, vagLabia, vagLabiaPointConfiguracion, transform, transform2, side, ChainPointStretcherJoint.ConfigTipo.vagLipsSide, colliderConfig, startPoint, maxAperture);
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x00028D34 File Offset: 0x00026F34
		public static void LoadPoint(ref VagLabiaPoint point, VagLabia vagLabia, VagLabiaPoint.VagLabiaPointConfiguracion vagLabiaPointConfiguracion, Transform inLabia, Transform outLabia, Side side, ChainPointStretcherJoint.ConfigTipo configTipo, VagLabiaPointColliders.Configuracion colliderConfig, bool startPoint, float maxAperture = 3.4028235E+38f)
		{
			if (inLabia == null)
			{
				throw new ArgumentNullException("inTrans", "inTrans null reference.");
			}
			if (outLabia == null)
			{
				throw new ArgumentNullException("outTrans", "outTrans null reference.");
			}
			if (vagLabia == null)
			{
				throw new ArgumentNullException("vagLabia", "vagLabia null reference.");
			}
			point = ChainPointStretcherJoint.Crear<VagLabiaPoint>(outLabia, inLabia, configTipo);
			point.SetManualStart();
			if (point == null)
			{
				throw new ArgumentNullException("point", "point null reference.");
			}
			point.vagLabia = vagLabia;
			point.colliderConfig = colliderConfig;
			point.vagLabiaPointConfiguracion = vagLabiaPointConfiguracion;
			point.side = side;
			point.maxLocalLimit = maxAperture;
			if (startPoint)
			{
				point.ManualStart();
			}
		}

		// Token: 0x04000680 RID: 1664
		[SerializeField]
		private ModificadorDeDriversDeJoint m_suavizadorGeneralDeSide;

		// Token: 0x04000681 RID: 1665
		public VagLabia vagLabia;

		// Token: 0x04000682 RID: 1666
		public VagLabiaBonesMap map;

		// Token: 0x04000683 RID: 1667
		[SerializeField]
		private Side m_side;

		// Token: 0x04000684 RID: 1668
		public VagLabiaPointColliders.Configuracion colliderConfig = new VagLabiaPointColliders.Configuracion();

		// Token: 0x04000685 RID: 1669
		public VagLipPointToPointJoint.Configuraciones pointToPointJointConfig = new VagLipPointToPointJoint.Configuraciones();

		// Token: 0x04000686 RID: 1670
		public VagLabiaPoint.VagLabiaPointConfiguracion vagLabiaPointConfiguracion = new VagLabiaPoint.VagLabiaPointConfiguracion();

		// Token: 0x04000687 RID: 1671
		[Obsolete]
		[NonSerialized]
		public MaxMovementLimiter.Configuracion movementLimiterConfig = new MaxMovementLimiter.Configuracion();

		// Token: 0x04000688 RID: 1672
		[ReadOnlyUI]
		[SerializeField]
		private VagLabiaSide.Points m_point = new VagLabiaSide.Points();

		// Token: 0x04000689 RID: 1673
		private List<VagLipPointToPointJoint> m_pointToPointJoints = new List<VagLipPointToPointJoint>();

		// Token: 0x0400068A RID: 1674
		private VagHole m_VagHole;

		// Token: 0x020001F0 RID: 496
		[Serializable]
		public class Points
		{
			// Token: 0x04000ABB RID: 2747
			public VagLabiaPoint m_000;

			// Token: 0x04000ABC RID: 2748
			public VagLabiaPoint m_001;

			// Token: 0x04000ABD RID: 2749
			public VagLabiaPoint m_002;

			// Token: 0x04000ABE RID: 2750
			public VagLabiaPoint m_003;

			// Token: 0x04000ABF RID: 2751
			public VagLabiaPoint m_004;

			// Token: 0x04000AC0 RID: 2752
			public VagLabiaPoint m_005;

			// Token: 0x04000AC1 RID: 2753
			public VagLabiaPoint m_006;
		}
	}
}
