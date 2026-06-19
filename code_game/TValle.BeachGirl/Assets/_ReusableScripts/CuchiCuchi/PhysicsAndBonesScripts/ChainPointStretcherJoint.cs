using System;
using System.Collections.Generic;
using Assets.Base.Joints;
using Assets.PhysicsAndBonesScripts;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000FE RID: 254
	[RequireComponent(typeof(ConfigurableJoint))]
	public class ChainPointStretcherJoint : AplicableBehaviour, IPhysicsHolePoint
	{
		// Token: 0x06000AD6 RID: 2774 RVA: 0x00024188 File Offset: 0x00022388
		public static T Crear<T>(Transform kinematicTransform, Transform dynamicTransform, ChainPointStretcherJoint.ConfigTipo configTipo, ChainPointStretcherJoint.Configuraciones configuraciones) where T : ChainPointStretcherJoint
		{
			if (kinematicTransform == dynamicTransform)
			{
				throw new InvalidOperationException();
			}
			Rigidbody componentNotNull = kinematicTransform.GetComponentNotNull<Rigidbody>();
			Rigidbody componentNotNull2 = dynamicTransform.GetComponentNotNull<Rigidbody>();
			componentNotNull.isKinematic = (componentNotNull2.isKinematic = true);
			componentNotNull.GetComponentNotNull<ConfigurableJoint>().connectedBody = componentNotNull2;
			T componentNotNull3 = componentNotNull.GetComponentNotNull<T>();
			componentNotNull3.configuraciones = configuraciones;
			componentNotNull3.configTipo = configTipo;
			return componentNotNull3;
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x000241EA File Offset: 0x000223EA
		public static T Crear<T>(Transform kinematicTransform, Transform dynamicTransform, ChainPointStretcherJoint.ConfigTipo configTipo) where T : ChainPointStretcherJoint
		{
			return ChainPointStretcherJoint.Crear<T>(kinematicTransform, dynamicTransform, configTipo, new ChainPointStretcherJoint.Configuraciones());
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x000241F9 File Offset: 0x000223F9
		public static ChainPointStretcherJoint Crear(Transform kinematicTransform, Transform dynamicTransform, ChainPointStretcherJoint.ConfigTipo configTipo, ChainPointStretcherJoint.Configuraciones configuraciones)
		{
			return ChainPointStretcherJoint.Crear<ChainPointStretcherJoint>(kinematicTransform, dynamicTransform, configTipo, configuraciones);
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x00024204 File Offset: 0x00022404
		public static ChainPointStretcherJoint Crear(Transform kinematicTransform, Transform dynamicTransform, ChainPointStretcherJoint.ConfigTipo configTipo)
		{
			return ChainPointStretcherJoint.Crear(kinematicTransform, dynamicTransform, configTipo, new ChainPointStretcherJoint.Configuraciones());
		}

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x06000ADA RID: 2778 RVA: 0x00024213 File Offset: 0x00022413
		public ChainStretched parent
		{
			get
			{
				return this.parentChain;
			}
		}

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x06000ADB RID: 2779 RVA: 0x0002421B File Offset: 0x0002241B
		public Rigidbody otherBody
		{
			get
			{
				return this.m_joint.connectedBody;
			}
		}

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x06000ADC RID: 2780 RVA: 0x00024228 File Offset: 0x00022428
		public ConfigurableJoint joint
		{
			get
			{
				return this.m_joint;
			}
		}

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x06000ADD RID: 2781 RVA: 0x00024230 File Offset: 0x00022430
		public JointDrivesAdmin.Modificador driveModificadores
		{
			get
			{
				return this.m_modificador;
			}
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06000ADE RID: 2782 RVA: 0x00024238 File Offset: 0x00022438
		public JointDistancesAdmin jointDistancesAdmin
		{
			get
			{
				return this.m_JointDistancesAdmin;
			}
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06000ADF RID: 2783 RVA: 0x00024240 File Offset: 0x00022440
		public JointDrivesAdmin jointDrivesAdmin
		{
			get
			{
				return this.m_JointDrivesAdmin;
			}
		}

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06000AE0 RID: 2784 RVA: 0x00024248 File Offset: 0x00022448
		public JointAxisAdmin jointAxisAdmin
		{
			get
			{
				return this.m_JointAxisAdmin;
			}
		}

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06000AE1 RID: 2785 RVA: 0x00024250 File Offset: 0x00022450
		public Vector3 jointLocalForward
		{
			get
			{
				return this.m_JointAxisAdmin.localForward;
			}
		}

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x06000AE2 RID: 2786 RVA: 0x0002425D File Offset: 0x0002245D
		public Vector3 jointWorldForward
		{
			get
			{
				return this.m_JointAxisAdmin.worldForward;
			}
		}

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x06000AE3 RID: 2787 RVA: 0x0002426A File Offset: 0x0002246A
		// (set) Token: 0x06000AE4 RID: 2788 RVA: 0x00024272 File Offset: 0x00022472
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

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06000AE5 RID: 2789 RVA: 0x00024281 File Offset: 0x00022481
		// (set) Token: 0x06000AE6 RID: 2790 RVA: 0x00024289 File Offset: 0x00022489
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

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x06000AE7 RID: 2791 RVA: 0x00024298 File Offset: 0x00022498
		// (set) Token: 0x06000AE8 RID: 2792 RVA: 0x000242A0 File Offset: 0x000224A0
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

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06000AE9 RID: 2793 RVA: 0x000242AF File Offset: 0x000224AF
		public float CurrentStretchInterval
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06000AEA RID: 2794 RVA: 0x000242B6 File Offset: 0x000224B6
		public float CurrentLocalDistanceFormInitialPoint
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x000242BD File Offset: 0x000224BD
		public IList<Collider> ObtenerCollidersDePunto()
		{
			return this.m_joint.connectedBody.GetComponentsInChildren<Collider>();
		}

		// Token: 0x14000055 RID: 85
		// (add) Token: 0x06000AEC RID: 2796 RVA: 0x000242D0 File Offset: 0x000224D0
		// (remove) Token: 0x06000AED RID: 2797 RVA: 0x00024308 File Offset: 0x00022508
		public event Action<ChainPointStretcherJoint> afterGenerateConfig;

		// Token: 0x06000AEE RID: 2798 RVA: 0x00024340 File Offset: 0x00022540
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_joint = base.GetComponent<ConfigurableJoint>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
			this.m_Rigidbody.isKinematic = true;
			this.InitJoinOtherbodyAdmin();
			this.InitJointDrivesAdmin();
			this.InitJointDistancesAdmin();
			this.InitJointAxisAdmin();
			this.InitJoinMotiosAdmin();
			this.InitJointAnglesAdmin();
			this.m_modificador = this.m_JointDrivesAdmin.AñadirModificador(base.GetInstanceID());
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x000243B4 File Offset: 0x000225B4
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.configuraciones == null)
			{
				this.configuraciones = new ChainPointStretcherJoint.Configuraciones();
			}
			this.configuraciones.Start(this.configTipo);
			this.LoadDefaultJointConfig();
			this.StartJointOtherbodyAdmin();
			this.StartJointDistancesAdmin();
			this.StartJointDrivesAdmin();
			this.StartJointAxisAdmin();
			this.StartJoinMotiosAdmin();
			this.StartJointAnglesAdmin();
			this.InitJointPolaridadLimiter();
			this.StartJointPolaridadLimiter();
			this.AfterGenerateConfig();
			this.UpdateFixers();
			this.LoadBroadcasters();
			this.m_connectedBodyDefPosition = this.otherBody.transform.localPosition;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x0002444C File Offset: 0x0002264C
		protected virtual void AfterGenerateConfig()
		{
			Action<ChainPointStretcherJoint> action = this.afterGenerateConfig;
			if (action != null)
			{
				action(this);
			}
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x0002446A File Offset: 0x0002266A
		public void RestaurarPosicion()
		{
			this.otherBody.transform.localPosition = this.m_connectedBodyDefPosition;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x00024482 File Offset: 0x00022682
		public void EliminarFuerzas()
		{
			this.otherBody.Sleep();
			this.otherBody.WakeUp();
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0002449A File Offset: 0x0002269A
		private void InitJointDistancesAdmin()
		{
			this.m_JointDistancesAdmin = this.GetComponentNotNull<JointDistancesAdmin>();
			this.m_JointDistancesAdmin.customUpdatedConfig.manualStart = true;
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x000244B9 File Offset: 0x000226B9
		private void StartJointDistancesAdmin()
		{
			this.m_JointDistancesAdmin.configuracion = this.configuraciones.jointDistancesAdmin;
			this.m_JointDistancesAdmin.ManualStart();
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x000244DC File Offset: 0x000226DC
		private void InitJointDrivesAdmin()
		{
			this.m_JointDrivesAdmin = this.GetComponentNotNull<JointDrivesAdmin>();
			this.m_JointDrivesAdmin.customUpdatedConfig.manualStart = true;
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x000244FB File Offset: 0x000226FB
		private void StartJointDrivesAdmin()
		{
			this.m_JointDrivesAdmin.configuracion = this.configuraciones.jointDrivesAdmin;
			this.m_JointDrivesAdmin.ManualStart();
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x0002451E File Offset: 0x0002271E
		private void InitJointAxisAdmin()
		{
			this.m_JointAxisAdmin = this.GetComponentNotNull<JointAxisAdmin>();
			this.m_JointAxisAdmin.customUpdatedConfig.manualStart = true;
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x0002453D File Offset: 0x0002273D
		private void StartJointAxisAdmin()
		{
			this.m_JointAxisAdmin.configuracion = this.configuraciones.jointAxisAdmin;
			this.m_JointAxisAdmin.ManualStart();
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x00024560 File Offset: 0x00022760
		private void InitJoinOtherbodyAdmin()
		{
			this.m_JointOtherbodyAdmin = this.GetComponentNotNull<JointOtherbodyAdmin>();
			this.m_JointOtherbodyAdmin.customUpdatedConfig.manualStart = true;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x0002457F File Offset: 0x0002277F
		private void StartJointOtherbodyAdmin()
		{
			this.m_JointOtherbodyAdmin.configuracion = this.configuraciones.jointOtherbodyAdmin;
			this.m_JointOtherbodyAdmin.ManualStart();
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x000245A2 File Offset: 0x000227A2
		private void InitJoinMotiosAdmin()
		{
			this.m_JointMotionsAdmin = this.GetComponentNotNull<JointMotionsAdmin>();
			this.m_JointMotionsAdmin.customUpdatedConfig.manualStart = true;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x000245C1 File Offset: 0x000227C1
		private void StartJoinMotiosAdmin()
		{
			this.m_JointMotionsAdmin.configuracion = this.configuraciones.jointMotionsAdmin;
			this.m_JointMotionsAdmin.ManualStart();
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x000245E4 File Offset: 0x000227E4
		private void InitJointAnglesAdmin()
		{
			this.m_JointAnglesAdmin = this.GetComponentNotNull<JointAnglesAdmin>();
			this.m_JointAnglesAdmin.customUpdatedConfig.manualStart = true;
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x00024603 File Offset: 0x00022803
		private void StartJointAnglesAdmin()
		{
			this.m_JointAnglesAdmin.configuracion = this.configuraciones.jointAnglesAdmin;
			this.m_JointAnglesAdmin.ManualStart();
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x00024628 File Offset: 0x00022828
		private void InitJointPolaridadLimiter()
		{
			ChainPointStretcherJoint.VagLipsBackConfigs.LimitarPolaridadDeAxisConfig limitarPolaridadDeAxis = this.configuraciones.limitarPolaridadDeAxis;
			if (((limitarPolaridadDeAxis != null) ? new bool?(limitarPolaridadDeAxis.usar) : null).GetValueOrDefault())
			{
				this.m_LimitarPolaridadDeAxis = this.GetComponentNotNull<LimitarPolaridadDeAxis>();
				this.m_LimitarPolaridadDeAxis.customUpdatedConfig.manualStart = true;
			}
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x00024680 File Offset: 0x00022880
		private void StartJointPolaridadLimiter()
		{
			ChainPointStretcherJoint.VagLipsBackConfigs.LimitarPolaridadDeAxisConfig limitarPolaridadDeAxis = this.configuraciones.limitarPolaridadDeAxis;
			if (((limitarPolaridadDeAxis != null) ? new bool?(limitarPolaridadDeAxis.usar) : null).GetValueOrDefault())
			{
				this.m_LimitarPolaridadDeAxis.configuracion = this.configuraciones.limitarPolaridadDeAxis;
				this.m_LimitarPolaridadDeAxis.ManualStart();
			}
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x000246DC File Offset: 0x000228DC
		private void LoadDefaultJointConfig()
		{
			this.m_joint.projectionMode = JointProjectionMode.PositionAndRotation;
			this.m_joint.projectionDistance = 0.001f;
			this.m_joint.breakForce = float.PositiveInfinity;
			this.m_joint.breakTorque = float.PositiveInfinity;
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x0002471C File Offset: 0x0002291C
		private void LoadBroadcasters()
		{
			this.m_ScaleChangedBroadcaster = this.GetComponentNotNull<ScaleChangedBroadcaster>();
			this.m_ScaleChangedBroadcaster.AddTarget(base.transform, false);
			this.m_ScaleChangedBroadcaster.updateEvent = GlobalUpdater.UpdateType.fixedUpdate1;
			this.m_ScaleChangedBroadcaster.ScaleChanged += new ScaleChangedBroadcaster.ScaleChangedHandler(this.ScaleChanged);
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x0002476C File Offset: 0x0002296C
		private void ScaleChanged(object target)
		{
			this.UpdateFixers();
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x00024774 File Offset: 0x00022974
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.UpdateFixers();
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x00024784 File Offset: 0x00022984
		public void UpdateFixers()
		{
			this.m_JointDistancesAdmin.FixDistances();
			this.m_JointOtherbodyAdmin.Fix();
			this.m_JointDrivesAdmin.FixDrivers();
			this.m_JointMotionsAdmin.Fix();
			this.m_JointAnglesAdmin.Fix();
			if (this.m_LimitarPolaridadDeAxis != null && this.m_LimitarPolaridadDeAxis.enabled != this.configuraciones.limitarPolaridadDeAxis.usar)
			{
				this.m_LimitarPolaridadDeAxis.enabled = this.configuraciones.limitarPolaridadDeAxis.usar;
			}
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x0002480E File Offset: 0x00022A0E
		protected void OnSuavidadCambio()
		{
			this.m_JointDrivesAdmin.modificador = this.m_suavidad;
			if (this.m_JointDrivesAdmin.isStared)
			{
				this.m_JointDrivesAdmin.FixDrivers();
			}
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x00024839 File Offset: 0x00022A39
		protected void OnSuavidadVerticalCambio()
		{
			this.driveModificadores.y = this.m_suavidadVertical;
			if (this.m_JointDrivesAdmin.isStared)
			{
				this.m_JointDrivesAdmin.FixDrivers();
			}
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x00024864 File Offset: 0x00022A64
		protected void OnSuavidadHorizontalCambio()
		{
			this.driveModificadores.z = this.m_suavidadHorizontal;
			if (this.m_JointDrivesAdmin.isStared)
			{
				this.m_JointDrivesAdmin.FixDrivers();
			}
		}

		// Token: 0x040005C8 RID: 1480
		protected ConfigurableJoint m_joint;

		// Token: 0x040005C9 RID: 1481
		private Rigidbody m_Rigidbody;

		// Token: 0x040005CA RID: 1482
		private ScaleChangedBroadcaster m_ScaleChangedBroadcaster;

		// Token: 0x040005CB RID: 1483
		protected JointDrivesAdmin m_JointDrivesAdmin;

		// Token: 0x040005CC RID: 1484
		protected JointDistancesAdmin m_JointDistancesAdmin;

		// Token: 0x040005CD RID: 1485
		protected JointAxisAdmin m_JointAxisAdmin;

		// Token: 0x040005CE RID: 1486
		protected JointOtherbodyAdmin m_JointOtherbodyAdmin;

		// Token: 0x040005CF RID: 1487
		protected JointMotionsAdmin m_JointMotionsAdmin;

		// Token: 0x040005D0 RID: 1488
		protected JointAnglesAdmin m_JointAnglesAdmin;

		// Token: 0x040005D1 RID: 1489
		protected LimitarPolaridadDeAxis m_LimitarPolaridadDeAxis;

		// Token: 0x040005D2 RID: 1490
		[ReadOnlyUI]
		public ChainStretched parentChain;

		// Token: 0x040005D3 RID: 1491
		public ChainPointStretcherJoint.ConfigTipo configTipo;

		// Token: 0x040005D4 RID: 1492
		public ChainPointStretcherJoint.Configuraciones configuraciones;

		// Token: 0x040005D5 RID: 1493
		private JointDrivesAdmin.Modificador m_modificador;

		// Token: 0x040005D6 RID: 1494
		[Range(0.01f, 3f)]
		[SerializeField]
		private float m_suavidad = 1f;

		// Token: 0x040005D7 RID: 1495
		[Range(0.01f, 3f)]
		[SerializeField]
		private float m_suavidadVertical = 1f;

		// Token: 0x040005D8 RID: 1496
		[Range(0.01f, 3f)]
		[SerializeField]
		private float m_suavidadHorizontal = 1f;

		// Token: 0x040005D9 RID: 1497
		private Vector3 m_connectedBodyDefPosition;

		// Token: 0x020001DB RID: 475
		[Serializable]
		public class Configuraciones
		{
			// Token: 0x06000F96 RID: 3990 RVA: 0x00034BB8 File Offset: 0x00032DB8
			public void Start(ChainPointStretcherJoint.ConfigTipo configTipo)
			{
				switch (configTipo)
				{
				case ChainPointStretcherJoint.ConfigTipo.input:
					return;
				case ChainPointStretcherJoint.ConfigTipo.anus:
					this.jointDrivesAdmin = new ChainPointStretcherJoint.AnusConfigs.JointDriveConfig();
					this.jointDistancesAdmin = new ChainPointStretcherJoint.AnusConfigs.JointDistancesConfig();
					this.jointAxisAdmin = new ChainPointStretcherJoint.AnusConfigs.JointAxisConfig();
					this.jointOtherbodyAdmin = new ChainPointStretcherJoint.AnusConfigs.JointOtherbodyConfig();
					this.jointMotionsAdmin = new ChainPointStretcherJoint.AnusConfigs.JointMotionsConfig();
					this.jointAnglesAdmin = new ChainPointStretcherJoint.AnusConfigs.JointAnglesAdminConfig();
					return;
				case ChainPointStretcherJoint.ConfigTipo.vag:
					this.jointDrivesAdmin = new ChainPointStretcherJoint.VagConfigs.JointDriveConfig();
					this.jointDistancesAdmin = new ChainPointStretcherJoint.VagConfigs.JointDistancesConfig();
					this.jointAxisAdmin = new ChainPointStretcherJoint.VagConfigs.JointAxisConfig();
					this.jointOtherbodyAdmin = new ChainPointStretcherJoint.VagConfigs.JointOtherbodyConfig();
					this.jointMotionsAdmin = new ChainPointStretcherJoint.VagConfigs.JointMotionsConfig();
					this.jointAnglesAdmin = new ChainPointStretcherJoint.VagConfigs.JointAnglesAdminConfig();
					return;
				case ChainPointStretcherJoint.ConfigTipo.bocaHole:
					this.jointDrivesAdmin = new ChainPointStretcherJoint.BocaConfigs.JointDriveConfig();
					this.jointDistancesAdmin = new ChainPointStretcherJoint.BocaConfigs.JointDistancesConfig();
					this.jointAxisAdmin = new ChainPointStretcherJoint.BocaConfigs.JointAxisConfig();
					this.jointOtherbodyAdmin = new ChainPointStretcherJoint.BocaConfigs.JointOtherbodyConfig();
					this.jointMotionsAdmin = new ChainPointStretcherJoint.BocaConfigs.JointMotionsConfig();
					this.jointAnglesAdmin = new ChainPointStretcherJoint.BocaConfigs.JointAnglesAdminConfig();
					return;
				case ChainPointStretcherJoint.ConfigTipo.vagLipsSide:
					this.jointDrivesAdmin = new ChainPointStretcherJoint.VagLipsConfigs.JointDriveConfig();
					this.jointDistancesAdmin = new ChainPointStretcherJoint.VagLipsConfigs.JointDistancesConfig();
					this.jointAxisAdmin = new ChainPointStretcherJoint.VagLipsConfigs.JointAxisConfig();
					this.jointOtherbodyAdmin = new ChainPointStretcherJoint.VagLipsConfigs.JointOtherbodyConfig();
					this.jointMotionsAdmin = new ChainPointStretcherJoint.VagLipsConfigs.JointMotionsConfig();
					this.jointAnglesAdmin = new ChainPointStretcherJoint.VagLipsConfigs.JointAnglesAdminConfig();
					return;
				case ChainPointStretcherJoint.ConfigTipo.vagLipsBack:
					this.jointDrivesAdmin = new ChainPointStretcherJoint.VagLipsBackConfigs.JointDriveConfig();
					this.jointDistancesAdmin = new ChainPointStretcherJoint.VagLipsBackConfigs.JointDistancesConfig();
					this.jointAxisAdmin = new ChainPointStretcherJoint.VagLipsBackConfigs.JointAxisConfig();
					this.jointOtherbodyAdmin = new ChainPointStretcherJoint.VagLipsBackConfigs.JointOtherbodyConfig();
					this.jointMotionsAdmin = new ChainPointStretcherJoint.VagLipsBackConfigs.JointMotionsConfig();
					this.jointAnglesAdmin = new ChainPointStretcherJoint.VagLipsBackConfigs.JointAnglesAdminConfig();
					this.limitarPolaridadDeAxis = new ChainPointStretcherJoint.VagLipsBackConfigs.LimitarPolaridadDeAxisConfig();
					return;
				}
				throw new ArgumentOutOfRangeException();
			}

			// Token: 0x04000A7F RID: 2687
			public JointDistancesAdmin.Configuracion jointDistancesAdmin = new JointDistancesAdmin.Configuracion();

			// Token: 0x04000A80 RID: 2688
			public JointDrivesAdmin.Configuracion jointDrivesAdmin = new JointDrivesAdmin.Configuracion();

			// Token: 0x04000A81 RID: 2689
			public JointAxisAdmin.Configuracion jointAxisAdmin = new JointAxisAdmin.Configuracion();

			// Token: 0x04000A82 RID: 2690
			public JointOtherbodyAdmin.Configuracion jointOtherbodyAdmin = new JointOtherbodyAdmin.Configuracion();

			// Token: 0x04000A83 RID: 2691
			public JointMotionsAdmin.Configuracion jointMotionsAdmin = new JointMotionsAdmin.Configuracion();

			// Token: 0x04000A84 RID: 2692
			public JointAnglesAdmin.Configuracion jointAnglesAdmin = new JointAnglesAdmin.Configuracion();

			// Token: 0x04000A85 RID: 2693
			public ChainPointStretcherJoint.VagLipsBackConfigs.LimitarPolaridadDeAxisConfig limitarPolaridadDeAxis;
		}

		// Token: 0x020001DC RID: 476
		public enum ConfigTipo
		{
			// Token: 0x04000A87 RID: 2695
			[Tooltip("carga la configuracion puesta en el editor")]
			input,
			// Token: 0x04000A88 RID: 2696
			[Tooltip("carga la configuracion del ano por defecto")]
			anus,
			// Token: 0x04000A89 RID: 2697
			[Tooltip("carga la configuracion del vag por defecto")]
			vag,
			// Token: 0x04000A8A RID: 2698
			[Obsolete("", true)]
			vagLips,
			// Token: 0x04000A8B RID: 2699
			bocaHole,
			// Token: 0x04000A8C RID: 2700
			vagLipsSide,
			// Token: 0x04000A8D RID: 2701
			vagLipsBack
		}

		// Token: 0x020001DD RID: 477
		public static class AnusConfigs
		{
			// Token: 0x02000233 RID: 563
			public class JointDriveConfig : JointDrivesAdmin.Configuracion
			{
				// Token: 0x06001064 RID: 4196 RVA: 0x00036B7C File Offset: 0x00034D7C
				public JointDriveConfig()
				{
					this.isInverted = true;
					this.xSpring = 0f;
					this.xDamper = 0f;
					this.ySpring = 1000f;
					this.yDamper = 50f;
					this.zSpring = 1050f;
					this.zDamper = 95f;
					this.xAngularSpring = 0f;
					this.YZAngularSpring = 0f;
					this.xAngularDamper = 0f;
					this.YZAngularDamper = 0f;
				}
			}

			// Token: 0x02000234 RID: 564
			public class JointDistancesConfig : JointDistancesAdmin.Configuracion
			{
				// Token: 0x06001065 RID: 4197 RVA: 0x00036C04 File Offset: 0x00034E04
				public JointDistancesConfig()
				{
					this.targetPosition.mode = JointDistancesAdmin.TargetPositionMode.maxZLinearMovementAtInitalPoint_ConnectionAtInitialTrack;
					this.targetPosition.offsetEnZMod = 1f;
				}
			}

			// Token: 0x02000235 RID: 565
			public class JointAxisConfig : JointAxisAdmin.Configuracion
			{
				// Token: 0x06001066 RID: 4198 RVA: 0x00036C28 File Offset: 0x00034E28
				public JointAxisConfig()
				{
					this.localUpAxis = Vector3.forward;
				}
			}

			// Token: 0x02000236 RID: 566
			public class JointOtherbodyConfig : JointOtherbodyAdmin.Configuracion
			{
				// Token: 0x06001067 RID: 4199 RVA: 0x00036C3C File Offset: 0x00034E3C
				public JointOtherbodyConfig()
				{
					this.density = 0.0009f;
					this.locaCenterOffMass = Vector3.zero;
					this.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
					this.maxDepenetrationVelocity = 0.25f;
					this.maxVelocity = 0.1f;
					this.solverIterations = 12;
					this.solverVelocityIterations = 1;
				}
			}

			// Token: 0x02000237 RID: 567
			public class JointMotionsConfig : JointMotionsAdmin.Configuracion
			{
				// Token: 0x06001068 RID: 4200 RVA: 0x00036C91 File Offset: 0x00034E91
				public JointMotionsConfig()
				{
					this.yMotion = ConfigurableJointMotion.Limited;
					this.zMotion = ConfigurableJointMotion.Limited;
				}
			}

			// Token: 0x02000238 RID: 568
			public class JointAnglesAdminConfig : JointAnglesAdmin.Configuracion
			{
			}
		}

		// Token: 0x020001DE RID: 478
		public static class VagConfigs
		{
			// Token: 0x02000239 RID: 569
			public class JointDriveConfig : JointDrivesAdmin.Configuracion
			{
				// Token: 0x0600106A RID: 4202 RVA: 0x00036CB0 File Offset: 0x00034EB0
				public JointDriveConfig()
				{
					this.isInverted = true;
					this.xSpring = 0f;
					this.xDamper = 0f;
					this.ySpring = 3650f;
					this.yDamper = 125f;
					this.zSpring = 1050f;
					this.zDamper = 95f;
					this.xAngularSpring = 0f;
					this.YZAngularSpring = 0f;
					this.xAngularDamper = 0f;
					this.YZAngularDamper = 0f;
				}
			}

			// Token: 0x0200023A RID: 570
			public class JointDistancesConfig : JointDistancesAdmin.Configuracion
			{
				// Token: 0x0600106B RID: 4203 RVA: 0x00036D38 File Offset: 0x00034F38
				public JointDistancesConfig()
				{
					this.targetPosition.mode = JointDistancesAdmin.TargetPositionMode.maxZLinearMovementAtInitalPoint_ConnectionAtInitialTrack;
					this.targetPosition.offsetEnZMod = 1f;
				}
			}

			// Token: 0x0200023B RID: 571
			public class JointAxisConfig : JointAxisAdmin.Configuracion
			{
				// Token: 0x0600106C RID: 4204 RVA: 0x00036D5C File Offset: 0x00034F5C
				public JointAxisConfig()
				{
					this.localUpAxis = Vector3.up;
				}
			}

			// Token: 0x0200023C RID: 572
			public class JointOtherbodyConfig : JointOtherbodyAdmin.Configuracion
			{
				// Token: 0x0600106D RID: 4205 RVA: 0x00036D70 File Offset: 0x00034F70
				public JointOtherbodyConfig()
				{
					this.density = 0.0009f;
					this.locaCenterOffMass = Vector3.zero;
					this.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
					this.maxDepenetrationVelocity = 0.1f;
					this.maxVelocity = 0.1f;
					this.solverIterations = 12;
					this.solverVelocityIterations = 1;
				}
			}

			// Token: 0x0200023D RID: 573
			public class JointMotionsConfig : JointMotionsAdmin.Configuracion
			{
				// Token: 0x0600106E RID: 4206 RVA: 0x00036DC5 File Offset: 0x00034FC5
				public JointMotionsConfig()
				{
					this.yMotion = ConfigurableJointMotion.Limited;
					this.zMotion = ConfigurableJointMotion.Limited;
				}
			}

			// Token: 0x0200023E RID: 574
			public class JointAnglesAdminConfig : JointAnglesAdmin.Configuracion
			{
			}
		}

		// Token: 0x020001DF RID: 479
		public static class VagLipsConfigs
		{
			// Token: 0x0200023F RID: 575
			public class JointDriveConfig : JointDrivesAdmin.Configuracion
			{
				// Token: 0x06001070 RID: 4208 RVA: 0x00036DE4 File Offset: 0x00034FE4
				public JointDriveConfig()
				{
					this.isInverted = true;
					this.xSpring = 0f;
					this.xDamper = 0f;
					this.ySpring = 2000f;
					this.yDamper = 300f;
					this.zSpring = 2000f;
					this.zDamper = 300f;
					this.xAngularSpring = 0f;
					this.YZAngularSpring = 0f;
					this.xAngularDamper = 0f;
					this.YZAngularDamper = 0f;
				}
			}

			// Token: 0x02000240 RID: 576
			public class JointDistancesConfig : JointDistancesAdmin.Configuracion
			{
				// Token: 0x06001071 RID: 4209 RVA: 0x00036E6C File Offset: 0x0003506C
				public JointDistancesConfig()
				{
					this.targetPosition.mode = JointDistancesAdmin.TargetPositionMode.customTrackOnZ;
					this.targetPosition.offsetEnZMod = 1f;
					this.targetPosition.customTrackMod = 0.62f;
				}
			}

			// Token: 0x02000241 RID: 577
			public class JointAxisConfig : JointAxisAdmin.Configuracion
			{
				// Token: 0x06001072 RID: 4210 RVA: 0x00036EA0 File Offset: 0x000350A0
				public JointAxisConfig()
				{
					this.localUpAxis = Vector3.forward;
				}
			}

			// Token: 0x02000242 RID: 578
			public class JointOtherbodyConfig : JointOtherbodyAdmin.Configuracion
			{
				// Token: 0x06001073 RID: 4211 RVA: 0x00036EB4 File Offset: 0x000350B4
				public JointOtherbodyConfig()
				{
					this.density = 8E-05f;
					this.locaCenterOffMass = Vector3.zero;
					this.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
					this.maxDepenetrationVelocity = 0.3f;
					this.maxVelocity = 0.1f;
					this.solverIterations = 12;
					this.solverVelocityIterations = 1;
				}
			}

			// Token: 0x02000243 RID: 579
			public class JointMotionsConfig : JointMotionsAdmin.Configuracion
			{
				// Token: 0x06001074 RID: 4212 RVA: 0x00036F09 File Offset: 0x00035109
				public JointMotionsConfig()
				{
					this.yMotion = ConfigurableJointMotion.Limited;
					this.zMotion = ConfigurableJointMotion.Limited;
				}
			}

			// Token: 0x02000244 RID: 580
			public class JointAnglesAdminConfig : JointAnglesAdmin.Configuracion
			{
			}
		}

		// Token: 0x020001E0 RID: 480
		public static class VagLipsBackConfigs
		{
			// Token: 0x02000245 RID: 581
			public class JointDriveConfig : JointDrivesAdmin.Configuracion
			{
				// Token: 0x06001076 RID: 4214 RVA: 0x00036F28 File Offset: 0x00035128
				public JointDriveConfig()
				{
					this.isInverted = true;
					this.xSpring = 0f;
					this.xDamper = 0f;
					this.ySpring = 3000f;
					this.yDamper = 300f;
					this.xSpring = 6000f;
					this.xDamper = 400f;
					this.zSpring = 2000f;
					this.zDamper = 300f;
					this.xAngularSpring = 0f;
					this.YZAngularSpring = 0f;
					this.xAngularDamper = 0f;
					this.YZAngularDamper = 0f;
				}
			}

			// Token: 0x02000246 RID: 582
			public class JointDistancesConfig : JointDistancesAdmin.Configuracion
			{
				// Token: 0x06001077 RID: 4215 RVA: 0x00036FC6 File Offset: 0x000351C6
				public JointDistancesConfig()
				{
					this.targetPosition.mode = JointDistancesAdmin.TargetPositionMode.freeTrack;
					this.targetPosition.freeTrackOptions = new JointDistancesAdmin.Configuracion.TargetPosition.FreeTargetOptions
					{
						minDistanceMod = -0.5f,
						maxDistanceMod = 1.5f
					};
				}
			}

			// Token: 0x02000247 RID: 583
			public class JointAxisConfig : JointAxisAdmin.Configuracion
			{
				// Token: 0x06001078 RID: 4216 RVA: 0x00037000 File Offset: 0x00035200
				public JointAxisConfig()
				{
					this.localUpAxis = Vector3.forward;
				}
			}

			// Token: 0x02000248 RID: 584
			public class JointOtherbodyConfig : JointOtherbodyAdmin.Configuracion
			{
				// Token: 0x06001079 RID: 4217 RVA: 0x00037014 File Offset: 0x00035214
				public JointOtherbodyConfig()
				{
					this.density = 8E-05f;
					this.locaCenterOffMass = Vector3.zero;
					this.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
					this.maxDepenetrationVelocity = 0.3f;
					this.maxVelocity = 0.1f;
					this.solverIterations = 12;
					this.solverVelocityIterations = 1;
				}
			}

			// Token: 0x02000249 RID: 585
			public class JointMotionsConfig : JointMotionsAdmin.Configuracion
			{
				// Token: 0x0600107A RID: 4218 RVA: 0x00037069 File Offset: 0x00035269
				public JointMotionsConfig()
				{
					this.yMotion = ConfigurableJointMotion.Limited;
					this.zMotion = ConfigurableJointMotion.Limited;
					this.xMotion = ConfigurableJointMotion.Limited;
				}
			}

			// Token: 0x0200024A RID: 586
			public class JointAnglesAdminConfig : JointAnglesAdmin.Configuracion
			{
			}

			// Token: 0x0200024B RID: 587
			public class LimitarPolaridadDeAxisConfig : LimitarPolaridadDeAxis.Configuracion
			{
				// Token: 0x0600107C RID: 4220 RVA: 0x0003708E File Offset: 0x0003528E
				public LimitarPolaridadDeAxisConfig()
				{
					this.usar = true;
					this.axisPolarizado = AxisPolarizado.yPositive;
					this.toleranceMod = 0.1f;
				}

				// Token: 0x04000B54 RID: 2900
				public bool usar;
			}
		}

		// Token: 0x020001E1 RID: 481
		public static class BocaConfigs
		{
			// Token: 0x0200024C RID: 588
			public class JointDriveConfig : JointDrivesAdmin.Configuracion
			{
				// Token: 0x0600107D RID: 4221 RVA: 0x000370B0 File Offset: 0x000352B0
				public JointDriveConfig()
				{
					this.isInverted = true;
					this.xSpring = 0f;
					this.xDamper = 0f;
					this.ySpring = 0f;
					this.yDamper = 0f;
					this.zSpring = 1050f;
					this.zDamper = 9.5f;
					this.xAngularSpring = 0f;
					this.YZAngularSpring = 0f;
					this.xAngularDamper = 0f;
					this.YZAngularDamper = 0f;
				}
			}

			// Token: 0x0200024D RID: 589
			public class JointDistancesConfig : JointDistancesAdmin.Configuracion
			{
				// Token: 0x0600107E RID: 4222 RVA: 0x00037138 File Offset: 0x00035338
				public JointDistancesConfig()
				{
					this.targetPosition.mode = JointDistancesAdmin.TargetPositionMode.maxZLinearMovementAtInitalPoint_ConnectionAtInitialTrack;
					this.targetPosition.offsetEnZMod = 1f;
				}
			}

			// Token: 0x0200024E RID: 590
			public class JointAxisConfig : JointAxisAdmin.Configuracion
			{
				// Token: 0x0600107F RID: 4223 RVA: 0x0003715C File Offset: 0x0003535C
				public JointAxisConfig()
				{
					this.localUpAxis = Vector3.up;
				}
			}

			// Token: 0x0200024F RID: 591
			public class JointOtherbodyConfig : JointOtherbodyAdmin.Configuracion
			{
				// Token: 0x06001080 RID: 4224 RVA: 0x00037170 File Offset: 0x00035370
				public JointOtherbodyConfig()
				{
					this.density = 0.0009f;
					this.locaCenterOffMass = Vector3.zero;
					this.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
					this.maxDepenetrationVelocity = 0.09f;
					this.maxVelocity = 0.1f;
					this.solverIterations = 12;
					this.solverVelocityIterations = 1;
				}
			}

			// Token: 0x02000250 RID: 592
			public class JointMotionsConfig : JointMotionsAdmin.Configuracion
			{
				// Token: 0x06001081 RID: 4225 RVA: 0x000371C5 File Offset: 0x000353C5
				public JointMotionsConfig()
				{
					this.zMotion = ConfigurableJointMotion.Limited;
				}
			}

			// Token: 0x02000251 RID: 593
			public class JointAnglesAdminConfig : JointAnglesAdmin.Configuracion
			{
			}
		}
	}
}
