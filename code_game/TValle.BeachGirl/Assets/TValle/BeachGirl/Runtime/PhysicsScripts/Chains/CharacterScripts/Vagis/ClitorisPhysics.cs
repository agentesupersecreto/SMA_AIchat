using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Vagis
{
	// Token: 0x0200007F RID: 127
	public class ClitorisPhysics : RecalculableJoint<ClitorisPhysics.Configuracion>
	{
		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000358 RID: 856 RVA: 0x0000A255 File Offset: 0x00008455
		// (set) Token: 0x06000359 RID: 857 RVA: 0x0000A25D File Offset: 0x0000845D
		public override ClitorisPhysics.Configuracion configuracion
		{
			get
			{
				return this.m_configuracion;
			}
			set
			{
				this.m_configuracion = value;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x0600035A RID: 858 RVA: 0x0000A266 File Offset: 0x00008466
		// (set) Token: 0x0600035B RID: 859 RVA: 0x0000A26E File Offset: 0x0000846E
		public override Transform jointTransform
		{
			get
			{
				return this.m_jointTransform;
			}
			set
			{
				this.m_jointTransform = value;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600035C RID: 860 RVA: 0x0000A277 File Offset: 0x00008477
		// (set) Token: 0x0600035D RID: 861 RVA: 0x0000A27F File Offset: 0x0000847F
		public override Transform targetBodyTransform
		{
			get
			{
				return this.m_targetBodyTransform;
			}
			set
			{
				this.m_targetBodyTransform = value;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x0600035E RID: 862 RVA: 0x0000A288 File Offset: 0x00008488
		// (set) Token: 0x0600035F RID: 863 RVA: 0x0000A290 File Offset: 0x00008490
		public override Transform scalerBone
		{
			get
			{
				return this.m_scalerBone;
			}
			set
			{
				this.m_scalerBone = value;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000360 RID: 864 RVA: 0x0000A299 File Offset: 0x00008499
		protected override bool fixOnEnable
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000361 RID: 865 RVA: 0x0000A29C File Offset: 0x0000849C
		public override bool useScaleChangedBroadcaster
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000362 RID: 866 RVA: 0x0000A29F File Offset: 0x0000849F
		public override bool jointIsInverted
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000363 RID: 867 RVA: 0x0000A2A2 File Offset: 0x000084A2
		public ClitorisCollider clitorisCollider
		{
			get
			{
				return this.m_ClitorisCollider;
			}
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0000A2AC File Offset: 0x000084AC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			this.m_scalerBone = base.transform.FindDeepChild(instance.DEFVagClit, true);
			this.m_jointTransform = base.transform.FindDeepChild(instance.VagClitBase, true);
			this.m_targetBodyTransform = base.transform.FindDeepChild(instance.VagClitBase_001, true);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0000A310 File Offset: 0x00008510
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			Transform transform = base.transform.FindDeepChild(instance.VagClitBase, true);
			this.m_ClitorisCollider = this.targetBodyTransform.gameObject.AddComponent<ClitorisCollider>();
			this.colliderConfig.material = Singleton<ColecionDePhysicsMaterials>.instance.zeroFriccion;
			this.m_ClitorisCollider.configuracion = this.colliderConfig;
			this.m_ClitorisCollider.Init(this.m_scalerBone, transform);
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0000A38A File Offset: 0x0000858A
		protected override void AddTargetsToScaleChangedBroadcaster()
		{
			base.AddTargetsToScaleChangedBroadcaster();
			this.m_ScaleChangedBroadcaster.AddTarget(this.m_jointTransform, false);
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0000A3A8 File Offset: 0x000085A8
		protected override void OnScaleChanged(object target)
		{
			if (Application.isEditor)
			{
				Vector3 lastScale = ((ScaleChangedBroadcaster.Target)target).lastScale;
				if (!ExtendedMonoBehaviour.AlmostEqual(lastScale.x, lastScale.y, 0.01f) || !ExtendedMonoBehaviour.AlmostEqual(lastScale.x, lastScale.z, 0.01f))
				{
					Debug.LogError("Nariz physcis NO es compatible con scaler NON uniform", this);
				}
			}
			base.OnScaleChanged(target);
		}

		// Token: 0x040001F7 RID: 503
		[SerializeField]
		private ClitorisPhysics.Configuracion m_configuracion = new ClitorisPhysics.Configuracion();

		// Token: 0x040001F8 RID: 504
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_jointTransform;

		// Token: 0x040001F9 RID: 505
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_targetBodyTransform;

		// Token: 0x040001FA RID: 506
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_scalerBone;

		// Token: 0x040001FB RID: 507
		private ClitorisCollider m_ClitorisCollider;

		// Token: 0x040001FC RID: 508
		public ClitorisCollider.Configuracion colliderConfig = new ClitorisCollider.Configuracion();

		// Token: 0x02000172 RID: 370
		[Serializable]
		public sealed class Configuracion : RecalculableJointBase.JointConfiguracion
		{
			// Token: 0x170004EE RID: 1262
			// (get) Token: 0x06000E59 RID: 3673 RVA: 0x000317DF File Offset: 0x0002F9DF
			// (set) Token: 0x06000E5A RID: 3674 RVA: 0x000317E7 File Offset: 0x0002F9E7
			public override RecalculableJointBase.LimitacionDeMotionConfig limitacionDeMotionConfig
			{
				get
				{
					return this.m_LimitacionDeMotionConfig;
				}
				set
				{
					this.m_LimitacionDeMotionConfig = value;
				}
			}

			// Token: 0x170004EF RID: 1263
			// (get) Token: 0x06000E5B RID: 3675 RVA: 0x000317F0 File Offset: 0x0002F9F0
			// (set) Token: 0x06000E5C RID: 3676 RVA: 0x000317F8 File Offset: 0x0002F9F8
			public override JointAnglesAdmin.Configuracion jointAnglesAdmin
			{
				get
				{
					return this.m_JointAnglesAdmin;
				}
				set
				{
					this.m_JointAnglesAdmin = value;
				}
			}

			// Token: 0x170004F0 RID: 1264
			// (get) Token: 0x06000E5D RID: 3677 RVA: 0x00031801 File Offset: 0x0002FA01
			// (set) Token: 0x06000E5E RID: 3678 RVA: 0x00031809 File Offset: 0x0002FA09
			public override JointAxisAdmin.Configuracion jointAxisAdmin
			{
				get
				{
					return this.m_JointAxisAdmin;
				}
				set
				{
					this.m_JointAxisAdmin = value;
				}
			}

			// Token: 0x170004F1 RID: 1265
			// (get) Token: 0x06000E5F RID: 3679 RVA: 0x00031812 File Offset: 0x0002FA12
			// (set) Token: 0x06000E60 RID: 3680 RVA: 0x0003181A File Offset: 0x0002FA1A
			public override JointBodyAdmin.Configuracion jointBodyAdmin
			{
				get
				{
					return this.m_JointBodyAdmin;
				}
				set
				{
					this.m_JointBodyAdmin = value;
				}
			}

			// Token: 0x170004F2 RID: 1266
			// (get) Token: 0x06000E61 RID: 3681 RVA: 0x00031823 File Offset: 0x0002FA23
			// (set) Token: 0x06000E62 RID: 3682 RVA: 0x0003182B File Offset: 0x0002FA2B
			public override JointDistancesAdmin.Configuracion jointDistancesAdmin
			{
				get
				{
					return this.m_JointDistancesAdmin;
				}
				set
				{
					this.m_JointDistancesAdmin = value;
				}
			}

			// Token: 0x170004F3 RID: 1267
			// (get) Token: 0x06000E63 RID: 3683 RVA: 0x00031834 File Offset: 0x0002FA34
			// (set) Token: 0x06000E64 RID: 3684 RVA: 0x0003183C File Offset: 0x0002FA3C
			public override JointDrivesAdminV2.Configuracion jointDrivesAdminV2
			{
				get
				{
					return this.m_JointDrivesAdminV2;
				}
				set
				{
					this.m_JointDrivesAdminV2 = value;
				}
			}

			// Token: 0x170004F4 RID: 1268
			// (get) Token: 0x06000E65 RID: 3685 RVA: 0x00031845 File Offset: 0x0002FA45
			// (set) Token: 0x06000E66 RID: 3686 RVA: 0x0003184D File Offset: 0x0002FA4D
			public override JointMotionsAdmin.Configuracion jointMotionsAdmin
			{
				get
				{
					return this.m_JointMotionsAdmin;
				}
				set
				{
					this.m_JointMotionsAdmin = value;
				}
			}

			// Token: 0x0400087F RID: 2175
			[SerializeField]
			private RecalculableJointBase.LimitacionDeMotionConfig m_LimitacionDeMotionConfig = new ClitorisPhysics.ClitorisConfigs.LimitacionesDeMotionConfig();

			// Token: 0x04000880 RID: 2176
			[SerializeField]
			private JointAnglesAdmin.Configuracion m_JointAnglesAdmin = new ClitorisPhysics.ClitorisConfigs.JointAnglesAdminConfig();

			// Token: 0x04000881 RID: 2177
			[SerializeField]
			private JointAxisAdmin.Configuracion m_JointAxisAdmin = new ClitorisPhysics.ClitorisConfigs.JointAxisConfig();

			// Token: 0x04000882 RID: 2178
			[SerializeField]
			private JointBodyAdmin.Configuracion m_JointBodyAdmin = new ClitorisPhysics.ClitorisConfigs.JointBodyConfig();

			// Token: 0x04000883 RID: 2179
			[SerializeField]
			private JointDistancesAdmin.Configuracion m_JointDistancesAdmin = new ClitorisPhysics.ClitorisConfigs.JointDistancesConfig();

			// Token: 0x04000884 RID: 2180
			[SerializeField]
			private JointDrivesAdminV2.Configuracion m_JointDrivesAdminV2 = new ClitorisPhysics.ClitorisConfigs.JointDriveConfig();

			// Token: 0x04000885 RID: 2181
			[SerializeField]
			private JointMotionsAdmin.Configuracion m_JointMotionsAdmin = new ClitorisPhysics.ClitorisConfigs.JointMotionsConfig();
		}

		// Token: 0x02000173 RID: 371
		public static class ClitorisConfigs
		{
			// Token: 0x0200020E RID: 526
			public class LimitacionesDeMotionConfig : RecalculableJointBase.LimitacionDeMotionConfig
			{
				// Token: 0x06001008 RID: 4104 RVA: 0x00035A63 File Offset: 0x00033C63
				public LimitacionesDeMotionConfig()
				{
					this.usar = false;
					this.limitaciones = new List<LimitarPolaridadDeAxis.Configuracion>
					{
						new LimitarPolaridadDeAxis.Configuracion
						{
							axisPolarizado = AxisPolarizado.yNegative,
							toleranceMod = 0f
						}
					};
				}
			}

			// Token: 0x0200020F RID: 527
			public class JointDriveConfig : JointDrivesAdminV2.Configuracion
			{
				// Token: 0x06001009 RID: 4105 RVA: 0x00035A9C File Offset: 0x00033C9C
				public JointDriveConfig()
				{
					this.isInverted = true;
					this.yDrive = new JointDriveConfiguration(12000f)
					{
						addingSpringToDamperPercent = 5f
					};
					this.xDrive = new JointDriveConfiguration(6000f)
					{
						addingSpringToDamperPercent = 5f
					};
					this.zDrive = new JointDriveConfiguration(3000f)
					{
						addingSpringToDamperPercent = 5f
					};
				}
			}

			// Token: 0x02000210 RID: 528
			public class JointDistancesConfig : JointDistancesAdmin.Configuracion
			{
				// Token: 0x0600100A RID: 4106 RVA: 0x00035B07 File Offset: 0x00033D07
				public JointDistancesConfig()
				{
					this.targetPosition.mode = JointDistancesAdmin.TargetPositionMode.freeTrack;
					this.targetPosition.freeTrackOptions.minDistanceMod = 0.1f;
					this.targetPosition.freeTrackOptions.maxDistanceMod = 2f;
				}
			}

			// Token: 0x02000211 RID: 529
			public class JointAxisConfig : JointAxisAdmin.Configuracion
			{
				// Token: 0x0600100B RID: 4107 RVA: 0x00035B45 File Offset: 0x00033D45
				public JointAxisConfig()
				{
					this.localUpAxis = Vector3.forward;
				}
			}

			// Token: 0x02000212 RID: 530
			public class JointBodyConfig : JointBodyAdmin.Configuracion
			{
				// Token: 0x0600100C RID: 4108 RVA: 0x00035B58 File Offset: 0x00033D58
				public JointBodyConfig()
				{
					this.density = 0.0022f;
					this.locaCenterOffMass = Vector3.zero;
					this.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
					this.maxDepenetrationVelocity = 0.03f;
					this.maxVelocity = 0.1f;
					this.solverIterations = 12;
					this.solverVelocityIterations = 1;
					this.angularDrag = 0.1f;
					this.drag = 0.1f;
				}
			}

			// Token: 0x02000213 RID: 531
			public class JointMotionsConfig : JointMotionsAdmin.Configuracion
			{
				// Token: 0x0600100D RID: 4109 RVA: 0x00035BC3 File Offset: 0x00033DC3
				public JointMotionsConfig()
				{
					this.xMotion = ConfigurableJointMotion.Limited;
					this.yMotion = ConfigurableJointMotion.Limited;
					this.zMotion = ConfigurableJointMotion.Limited;
					this.angularXMotion = ConfigurableJointMotion.Locked;
					this.angularYMotion = ConfigurableJointMotion.Locked;
					this.angularZMotion = ConfigurableJointMotion.Locked;
				}
			}

			// Token: 0x02000214 RID: 532
			public class JointAnglesAdminConfig : JointAnglesAdmin.Configuracion
			{
			}
		}
	}
}
