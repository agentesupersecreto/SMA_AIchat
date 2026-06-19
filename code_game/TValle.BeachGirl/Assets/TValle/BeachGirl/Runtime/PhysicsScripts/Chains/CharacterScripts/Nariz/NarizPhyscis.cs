using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Nariz
{
	// Token: 0x02000081 RID: 129
	public class NarizPhyscis : RecalculableJoint<NarizPhyscis.Configuracion>
	{
		// Token: 0x17000171 RID: 369
		// (get) Token: 0x0600036C RID: 876 RVA: 0x0000A44B File Offset: 0x0000864B
		// (set) Token: 0x0600036D RID: 877 RVA: 0x0000A453 File Offset: 0x00008653
		public override NarizPhyscis.Configuracion configuracion
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

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x0600036E RID: 878 RVA: 0x0000A45C File Offset: 0x0000865C
		// (set) Token: 0x0600036F RID: 879 RVA: 0x0000A464 File Offset: 0x00008664
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

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000370 RID: 880 RVA: 0x0000A46D File Offset: 0x0000866D
		// (set) Token: 0x06000371 RID: 881 RVA: 0x0000A475 File Offset: 0x00008675
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

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000372 RID: 882 RVA: 0x0000A47E File Offset: 0x0000867E
		// (set) Token: 0x06000373 RID: 883 RVA: 0x0000A486 File Offset: 0x00008686
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

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000374 RID: 884 RVA: 0x0000A48F File Offset: 0x0000868F
		protected override bool fixOnEnable
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000375 RID: 885 RVA: 0x0000A492 File Offset: 0x00008692
		public override bool useScaleChangedBroadcaster
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06000376 RID: 886 RVA: 0x0000A495 File Offset: 0x00008695
		public override bool jointIsInverted
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000377 RID: 887 RVA: 0x0000A498 File Offset: 0x00008698
		public NarizPointCollider narizCollider
		{
			get
			{
				return this.m_NarizPointCollider;
			}
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0000A4A0 File Offset: 0x000086A0
		protected override void AwakeUnityEvent()
		{
			int m_layer = Singleton<ConfiguracionGeneral>.instance.layers.convexSkins;
			base.transform.ExecDeepChild(delegate(Transform t)
			{
				t.gameObject.layer = m_layer;
			}, true);
			base.AwakeUnityEvent();
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			this.m_scalerBone = base.transform.FindDeepChild(instance.TavoNarizSkinScaler, true);
			this.jointTransform = base.transform.FindDeepChild(instance.TavoNarizSkinPoint, true);
			this.targetBodyTransform = base.transform.FindDeepChild(instance.TavoNarizSkinTip, true);
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0000A534 File Offset: 0x00008734
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_NarizPointCollider = this.targetBodyTransform.gameObject.AddComponent<NarizPointCollider>();
			this.m_colliderConfig.material = Singleton<ColecionDePhysicsMaterials>.instance.skinNoBounce;
			this.m_NarizPointCollider.configuracion = this.m_colliderConfig;
			this.m_NarizPointCollider.ManualStart();
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000A590 File Offset: 0x00008790
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

		// Token: 0x040001FD RID: 509
		[SerializeField]
		private NarizPhyscis.Configuracion m_configuracion;

		// Token: 0x040001FE RID: 510
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_jointTransform;

		// Token: 0x040001FF RID: 511
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_targetBodyTransform;

		// Token: 0x04000200 RID: 512
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_scalerBone;

		// Token: 0x04000201 RID: 513
		[SerializeField]
		private NarizPointCollider.Configuracion m_colliderConfig = new NarizPointCollider.Configuracion();

		// Token: 0x04000202 RID: 514
		private NarizPointCollider m_NarizPointCollider;

		// Token: 0x02000174 RID: 372
		[Serializable]
		public sealed class Configuracion : RecalculableJointBase.JointConfiguracion
		{
			// Token: 0x170004F5 RID: 1269
			// (get) Token: 0x06000E68 RID: 3688 RVA: 0x000318B8 File Offset: 0x0002FAB8
			// (set) Token: 0x06000E69 RID: 3689 RVA: 0x000318C0 File Offset: 0x0002FAC0
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

			// Token: 0x170004F6 RID: 1270
			// (get) Token: 0x06000E6A RID: 3690 RVA: 0x000318C9 File Offset: 0x0002FAC9
			// (set) Token: 0x06000E6B RID: 3691 RVA: 0x000318D1 File Offset: 0x0002FAD1
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

			// Token: 0x170004F7 RID: 1271
			// (get) Token: 0x06000E6C RID: 3692 RVA: 0x000318DA File Offset: 0x0002FADA
			// (set) Token: 0x06000E6D RID: 3693 RVA: 0x000318E2 File Offset: 0x0002FAE2
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

			// Token: 0x170004F8 RID: 1272
			// (get) Token: 0x06000E6E RID: 3694 RVA: 0x000318EB File Offset: 0x0002FAEB
			// (set) Token: 0x06000E6F RID: 3695 RVA: 0x000318F3 File Offset: 0x0002FAF3
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

			// Token: 0x170004F9 RID: 1273
			// (get) Token: 0x06000E70 RID: 3696 RVA: 0x000318FC File Offset: 0x0002FAFC
			// (set) Token: 0x06000E71 RID: 3697 RVA: 0x00031904 File Offset: 0x0002FB04
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

			// Token: 0x170004FA RID: 1274
			// (get) Token: 0x06000E72 RID: 3698 RVA: 0x0003190D File Offset: 0x0002FB0D
			// (set) Token: 0x06000E73 RID: 3699 RVA: 0x00031915 File Offset: 0x0002FB15
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

			// Token: 0x170004FB RID: 1275
			// (get) Token: 0x06000E74 RID: 3700 RVA: 0x0003191E File Offset: 0x0002FB1E
			// (set) Token: 0x06000E75 RID: 3701 RVA: 0x00031926 File Offset: 0x0002FB26
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

			// Token: 0x04000886 RID: 2182
			[SerializeField]
			private RecalculableJointBase.LimitacionDeMotionConfig m_LimitacionDeMotionConfig = new NarizPhyscis.NarizConfigs.LimitacionesDeMotionConfig();

			// Token: 0x04000887 RID: 2183
			[SerializeField]
			private JointAnglesAdmin.Configuracion m_JointAnglesAdmin = new NarizPhyscis.NarizConfigs.JointAnglesAdminConfig();

			// Token: 0x04000888 RID: 2184
			[SerializeField]
			private JointAxisAdmin.Configuracion m_JointAxisAdmin = new NarizPhyscis.NarizConfigs.JointAxisConfig();

			// Token: 0x04000889 RID: 2185
			[SerializeField]
			private JointBodyAdmin.Configuracion m_JointBodyAdmin = new NarizPhyscis.NarizConfigs.JointBodyConfig();

			// Token: 0x0400088A RID: 2186
			[SerializeField]
			private JointDistancesAdmin.Configuracion m_JointDistancesAdmin = new NarizPhyscis.NarizConfigs.JointDistancesConfig();

			// Token: 0x0400088B RID: 2187
			[SerializeField]
			private JointDrivesAdminV2.Configuracion m_JointDrivesAdminV2 = new NarizPhyscis.NarizConfigs.JointDriveConfig();

			// Token: 0x0400088C RID: 2188
			[SerializeField]
			private JointMotionsAdmin.Configuracion m_JointMotionsAdmin = new NarizPhyscis.NarizConfigs.JointMotionsConfig();
		}

		// Token: 0x02000175 RID: 373
		public static class NarizConfigs
		{
			// Token: 0x02000215 RID: 533
			public class LimitacionesDeMotionConfig : RecalculableJointBase.LimitacionDeMotionConfig
			{
				// Token: 0x0600100F RID: 4111 RVA: 0x00035BFD File Offset: 0x00033DFD
				public LimitacionesDeMotionConfig()
				{
					this.usar = false;
					this.limitaciones = new List<LimitarPolaridadDeAxis.Configuracion>
					{
						new LimitarPolaridadDeAxis.Configuracion
						{
							axisPolarizado = AxisPolarizado.yNegative,
							toleranceMod = 1f
						}
					};
				}
			}

			// Token: 0x02000216 RID: 534
			public class JointDriveConfig : JointDrivesAdminV2.Configuracion
			{
				// Token: 0x06001010 RID: 4112 RVA: 0x00035C38 File Offset: 0x00033E38
				public JointDriveConfig()
				{
					this.isInverted = true;
					this.zDrive = new JointDriveConfiguration(20000f)
					{
						addingSpringToDamperPercent = 2f
					};
					JointDriveConfiguration jointDriveConfiguration = new JointDriveConfiguration(20000f);
					jointDriveConfiguration.addingSpringToDamperPercent = 2f;
					JointDriveConfiguration jointDriveConfiguration2 = jointDriveConfiguration;
					this.yDrive = jointDriveConfiguration;
					this.xDrive = jointDriveConfiguration2;
				}
			}

			// Token: 0x02000217 RID: 535
			public class JointDistancesConfig : JointDistancesAdmin.Configuracion
			{
				// Token: 0x06001011 RID: 4113 RVA: 0x00035C91 File Offset: 0x00033E91
				public JointDistancesConfig()
				{
					this.targetPosition.mode = JointDistancesAdmin.TargetPositionMode.freeTrack;
					this.targetPosition.freeTrackOptions.minDistanceMod = 0.3f;
					this.targetPosition.freeTrackOptions.maxDistanceMod = 1.33f;
				}
			}

			// Token: 0x02000218 RID: 536
			public class JointAxisConfig : JointAxisAdmin.Configuracion
			{
				// Token: 0x06001012 RID: 4114 RVA: 0x00035CCF File Offset: 0x00033ECF
				public JointAxisConfig()
				{
					this.localUpAxis = Vector3.forward;
				}
			}

			// Token: 0x02000219 RID: 537
			public class JointBodyConfig : JointBodyAdmin.Configuracion
			{
				// Token: 0x06001013 RID: 4115 RVA: 0x00035CE4 File Offset: 0x00033EE4
				public JointBodyConfig()
				{
					this.density = 0.15f;
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

			// Token: 0x0200021A RID: 538
			public class JointMotionsConfig : JointMotionsAdmin.Configuracion
			{
				// Token: 0x06001014 RID: 4116 RVA: 0x00035D4F File Offset: 0x00033F4F
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

			// Token: 0x0200021B RID: 539
			public class JointAnglesAdminConfig : JointAnglesAdmin.Configuracion
			{
			}
		}
	}
}
