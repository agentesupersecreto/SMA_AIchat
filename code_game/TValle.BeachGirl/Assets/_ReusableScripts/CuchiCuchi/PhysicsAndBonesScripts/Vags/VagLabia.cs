using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Vags
{
	// Token: 0x0200010D RID: 269
	public sealed class VagLabia : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06000BCD RID: 3021 RVA: 0x00027670 File Offset: 0x00025870
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06000BCE RID: 3022 RVA: 0x00027673 File Offset: 0x00025873
		public override GlobalUpdater.UpdateType? updateEvent6
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeFixedUpdates3);
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x06000BCF RID: 3023 RVA: 0x0002767C File Offset: 0x0002587C
		public VagLabiaSide r
		{
			get
			{
				return this.m_VagLabiaSideR;
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x00027684 File Offset: 0x00025884
		public VagLabiaSide l
		{
			get
			{
				return this.m_VagLabiaSideL;
			}
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x06000BD1 RID: 3025 RVA: 0x0002768C File Offset: 0x0002588C
		public VagLabiaPoint backPoint
		{
			get
			{
				if (this.m_VagLipMiddleBackPointCreator == null)
				{
					return null;
				}
				return this.m_VagLipMiddleBackPointCreator.vagLabiaPoint;
			}
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x000276A9 File Offset: 0x000258A9
		public float defaultStaticFriccion
		{
			get
			{
				return this.m_defaultStaticFricc;
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x06000BD3 RID: 3027 RVA: 0x000276B1 File Offset: 0x000258B1
		public float defaultDynamicFriccion
		{
			get
			{
				return this.m_defaultDynamicFricc;
			}
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06000BD4 RID: 3028 RVA: 0x000276B9 File Offset: 0x000258B9
		public PhysicMaterial currentPhysicMaterial
		{
			get
			{
				return this.m_currentMaterial;
			}
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x06000BD5 RID: 3029 RVA: 0x000276C1 File Offset: 0x000258C1
		public Transform vagRoot
		{
			get
			{
				return this.m_vagRoot;
			}
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x000276C9 File Offset: 0x000258C9
		protected override void AwakeUnityEvent()
		{
			this.m_worldScale = base.transform.lossyScale.Escala();
			base.AwakeUnityEvent();
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x000276E8 File Offset: 0x000258E8
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_VagHole = this.GetComponentEnRoot(false);
			this.map = Singleton<MapasDeHuesos>.instance.mapas.vagLabiaBonesMap;
			this.m_vagRoot = base.transform.FindDeepParent(this.map.vagRoot);
			if (this.colliderConfig.material == null)
			{
				this.colliderConfig.material = Singleton<ColecionDePhysicsMaterials>.instance.vagLabia;
			}
			this.m_currentMaterial = (this.colliderConfig.material = Object.Instantiate<PhysicMaterial>(this.colliderConfig.material));
			this.m_defaultStaticFricc = this.m_currentMaterial.staticFriction;
			this.m_defaultDynamicFricc = this.m_currentMaterial.dynamicFriction;
			this.CreateMiddleBack();
			this.CrearSides();
			this.GetComponentNotNull<VagLabiaScalerAnusStateMover>();
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x000277BC File Offset: 0x000259BC
		public override void OnUpdateEvent1()
		{
			float num = this.modificableDeFriccionGeneral.ModificarValor(1f);
			if (this.m_LastModFriccionGeneral == null || !ExtendedMonoBehaviour.AlmostEqual(this.m_LastModFriccionGeneral.Value, num, 0.01f))
			{
				this.m_LastModFriccionGeneral = new float?(num);
				this.m_currentMaterial.dynamicFriction = this.m_defaultDynamicFricc * num;
				this.m_currentMaterial.staticFriction = this.m_defaultStaticFricc * num;
			}
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x00027834 File Offset: 0x00025A34
		public override void OnUpdateEvent6()
		{
			this.m_worldScale = base.transform.lossyScale.Escala();
			float maxAnchuraLimpiaLocal = this.GetMaxAnchuraLimpiaLocal();
			float num = ((!this.m_VagHole.isPenetrated) ? 0f : Mathf.InverseLerp(0.001f, 0.006f, maxAnchuraLimpiaLocal));
			this.backPoint.vagLabiaPointColliders.UpdateCollider(num, true);
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x00027895 File Offset: 0x00025A95
		public float GetMaxAnchuraLimpiaLocal()
		{
			return this.m_VagHole.estadoDePuntos.actualLocal.maxLimpiaLocalHole * this.m_VagHole.worldHoleScale / this.m_worldScale;
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x000278BF File Offset: 0x00025ABF
		public VagLabiaSide GetSide(Side side)
		{
			switch (side)
			{
			case Side.L:
				return this.m_VagLabiaSideL;
			case Side.R:
				return this.m_VagLabiaSideR;
			}
			throw new InvalidOperationException();
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x000278F0 File Offset: 0x00025AF0
		[Obsolete]
		public void IgnoreSelfCollisions()
		{
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x000278F4 File Offset: 0x00025AF4
		private void CreateMiddleBack()
		{
			Transform transform = this.vagRoot.FindDeepChild(this.map.vagLabiaRoot, true).FindDeepChild(this.map.vagLabiaInBack, true);
			if (transform == null)
			{
				throw new ArgumentNullException("backT", "backT null reference.");
			}
			this.m_VagLipMiddleBackPointCreator = transform.GetComponentNotNull<VagLipMiddleBackPointCreator>();
			this.m_VagLipMiddleBackPointCreator.SetManualStart();
			this.m_VagLipMiddleBackPointCreator.vagLabia = this;
			this.m_VagLipMiddleBackPointCreator.vagLabiaPointConfiguracion = this.vagLabiaPointConfiguracion;
			this.m_VagLipMiddleBackPointCreator.configuracion = this.backPointCreatorConfig;
			this.m_VagLipMiddleBackPointCreator.colliderConfig = this.colliderConfig.Clone();
			this.m_VagLipMiddleBackPointCreator.colliderConfig.initialRadius *= this.backPointCreatorConfig.radiusModInitialMod;
			this.m_VagLipMiddleBackPointCreator.colliderConfig.penetratedRadius *= this.backPointCreatorConfig.radiusModPenMod;
			this.m_VagLipMiddleBackPointCreator.colliderConfig.initialOffset *= this.backPointCreatorConfig.initiaOffsetMod;
			this.m_VagLipMiddleBackPointCreator.colliderConfig.penetratedOffset *= this.backPointCreatorConfig.penOffsetMod;
			this.m_VagLipMiddleBackPointCreator.ManualStart();
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x00027A34 File Offset: 0x00025C34
		private void CrearSides()
		{
			this.ClearComponents<VagLabiaSide>();
			this.m_VagLabiaSideR = base.gameObject.AddComponent<VagLabiaSide>();
			this.m_VagLabiaSideR.SetManualStart();
			this.m_VagLabiaSideR.colliderConfig = this.colliderConfig;
			this.m_VagLabiaSideR.side = Side.R;
			this.m_VagLabiaSideR.map = this.map;
			this.m_VagLabiaSideR.vagLabia = this;
			this.m_VagLabiaSideR.vagLabiaPointConfiguracion = this.vagLabiaPointConfiguracion;
			this.m_VagLabiaSideR.pointToPointJointConfig = this.pointToPointJointConfig;
			this.m_VagLabiaSideR.ManualStart();
			this.m_VagLabiaSideL = base.gameObject.AddComponent<VagLabiaSide>();
			this.m_VagLabiaSideL.SetManualStart();
			this.m_VagLabiaSideL.colliderConfig = this.colliderConfig;
			this.m_VagLabiaSideL.side = Side.L;
			this.m_VagLabiaSideL.map = this.map;
			this.m_VagLabiaSideL.vagLabia = this;
			this.m_VagLabiaSideL.vagLabiaPointConfiguracion = this.vagLabiaPointConfiguracion;
			this.m_VagLabiaSideL.pointToPointJointConfig = this.pointToPointJointConfig;
			this.m_VagLabiaSideL.ManualStart();
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x00027B50 File Offset: 0x00025D50
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_currentMaterial != null)
			{
				Object.DestroyImmediate(this.m_currentMaterial);
				this.m_currentMaterial = (this.colliderConfig.material = null);
			}
		}

		// Token: 0x04000654 RID: 1620
		[NonSerialized]
		public VagLabiaBonesMap map;

		// Token: 0x04000655 RID: 1621
		public VagLabiaPointColliders.Configuracion colliderConfig = new VagLabiaPointColliders.Configuracion();

		// Token: 0x04000656 RID: 1622
		public VagLipMiddleBackPointCreator.Configuracion backPointCreatorConfig = new VagLipMiddleBackPointCreator.Configuracion(1.2f, 1.2f);

		// Token: 0x04000657 RID: 1623
		public VagLipPointToPointJoint.Configuraciones pointToPointJointConfig = new VagLipPointToPointJoint.Configuraciones();

		// Token: 0x04000658 RID: 1624
		public VagLabiaPoint.VagLabiaPointConfiguracion vagLabiaPointConfiguracion = new VagLabiaPoint.VagLabiaPointConfiguracion();

		// Token: 0x04000659 RID: 1625
		[Obsolete]
		[NonSerialized]
		public MaxMovementLimiter.Configuracion movementLimiterConfig = new MaxMovementLimiter.Configuracion(0.005f);

		// Token: 0x0400065A RID: 1626
		private VagLabiaSide m_VagLabiaSideR;

		// Token: 0x0400065B RID: 1627
		private VagLabiaSide m_VagLabiaSideL;

		// Token: 0x0400065C RID: 1628
		private VagLipMiddleBackPointCreator m_VagLipMiddleBackPointCreator;

		// Token: 0x0400065D RID: 1629
		public VagLabia.MaximasAperturas maximasAperturas = new VagLabia.MaximasAperturas();

		// Token: 0x0400065E RID: 1630
		private float m_defaultStaticFricc;

		// Token: 0x0400065F RID: 1631
		private float m_defaultDynamicFricc;

		// Token: 0x04000660 RID: 1632
		private float? m_LastModFriccionGeneral;

		// Token: 0x04000661 RID: 1633
		public ModificableDeFloat modificableDeFriccionGeneral = new ModificableDeFloat(1f);

		// Token: 0x04000662 RID: 1634
		private PhysicMaterial m_currentMaterial;

		// Token: 0x04000663 RID: 1635
		private Transform m_vagRoot;

		// Token: 0x04000664 RID: 1636
		private VagHole m_VagHole;

		// Token: 0x04000665 RID: 1637
		private float m_worldScale = 1f;

		// Token: 0x020001ED RID: 493
		public class MaximasAperturas
		{
			// Token: 0x04000AAD RID: 2733
			public float _000 = 0.035f;

			// Token: 0x04000AAE RID: 2734
			public float _001 = 0.04f;

			// Token: 0x04000AAF RID: 2735
			public float _002 = 0.045f;

			// Token: 0x04000AB0 RID: 2736
			public float _003 = 0.05f;

			// Token: 0x04000AB1 RID: 2737
			public float _004 = 0.045f;

			// Token: 0x04000AB2 RID: 2738
			public float _005 = 0.04f;

			// Token: 0x04000AB3 RID: 2739
			public float _006 = 0.035f;
		}
	}
}
