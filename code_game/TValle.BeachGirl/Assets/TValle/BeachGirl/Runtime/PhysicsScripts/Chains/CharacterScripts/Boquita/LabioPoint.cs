using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita
{
	// Token: 0x02000089 RID: 137
	public class LabioPoint : RecalculableJoint<LabioPoint.Configuracion>
	{
		// Token: 0x1700019D RID: 413
		// (get) Token: 0x060003D3 RID: 979 RVA: 0x0000BC3C File Offset: 0x00009E3C
		// (set) Token: 0x060003D4 RID: 980 RVA: 0x0000BC44 File Offset: 0x00009E44
		public override LabioPoint.Configuracion configuracion
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

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x0000BC4D File Offset: 0x00009E4D
		// (set) Token: 0x060003D6 RID: 982 RVA: 0x0000BC55 File Offset: 0x00009E55
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

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x0000BC5E File Offset: 0x00009E5E
		// (set) Token: 0x060003D8 RID: 984 RVA: 0x0000BC66 File Offset: 0x00009E66
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

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x0000BC6F File Offset: 0x00009E6F
		// (set) Token: 0x060003DA RID: 986 RVA: 0x0000BC77 File Offset: 0x00009E77
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

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x060003DB RID: 987 RVA: 0x0000BC80 File Offset: 0x00009E80
		protected override bool fixOnEnable
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x060003DC RID: 988 RVA: 0x0000BC83 File Offset: 0x00009E83
		public override bool useScaleChangedBroadcaster
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x060003DD RID: 989 RVA: 0x0000BC86 File Offset: 0x00009E86
		public override bool jointIsInverted
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x060003DE RID: 990 RVA: 0x0000BC89 File Offset: 0x00009E89
		public LabioPointCollider puntoCollider
		{
			get
			{
				return this.m_LabioPointCollider;
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0000BC91 File Offset: 0x00009E91
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0000BC99 File Offset: 0x00009E99
		public void InitCollider(string boneGuiaName, string guiaNameForward, string guiaNameEdge)
		{
			this.m_LabioPointCollider = base.bodyAdmin.body.gameObject.AddComponent<LabioPointCollider>();
			this.m_LabioPointCollider.configuracion = this.colliderConfig;
			this.m_LabioPointCollider.Init(boneGuiaName, guiaNameForward, guiaNameEdge, this);
		}

		// Token: 0x04000237 RID: 567
		private LabioPoint.Configuracion m_configuracion;

		// Token: 0x04000238 RID: 568
		private Transform m_jointTransform;

		// Token: 0x04000239 RID: 569
		private Transform m_targetBodyTransform;

		// Token: 0x0400023A RID: 570
		private Transform m_scalerBone;

		// Token: 0x0400023B RID: 571
		private LabioPointCollider m_LabioPointCollider;

		// Token: 0x0400023C RID: 572
		public LabioPointCollider.Configuracion colliderConfig;

		// Token: 0x02000180 RID: 384
		[Serializable]
		public sealed class Configuracion : RecalculableJointBase.JointConfiguracion
		{
			// Token: 0x170004FD RID: 1277
			// (get) Token: 0x06000E90 RID: 3728 RVA: 0x00031EF3 File Offset: 0x000300F3
			// (set) Token: 0x06000E91 RID: 3729 RVA: 0x00031EFB File Offset: 0x000300FB
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

			// Token: 0x170004FE RID: 1278
			// (get) Token: 0x06000E92 RID: 3730 RVA: 0x00031F04 File Offset: 0x00030104
			// (set) Token: 0x06000E93 RID: 3731 RVA: 0x00031F0C File Offset: 0x0003010C
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

			// Token: 0x170004FF RID: 1279
			// (get) Token: 0x06000E94 RID: 3732 RVA: 0x00031F15 File Offset: 0x00030115
			// (set) Token: 0x06000E95 RID: 3733 RVA: 0x00031F1D File Offset: 0x0003011D
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

			// Token: 0x17000500 RID: 1280
			// (get) Token: 0x06000E96 RID: 3734 RVA: 0x00031F26 File Offset: 0x00030126
			// (set) Token: 0x06000E97 RID: 3735 RVA: 0x00031F2E File Offset: 0x0003012E
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

			// Token: 0x17000501 RID: 1281
			// (get) Token: 0x06000E98 RID: 3736 RVA: 0x00031F37 File Offset: 0x00030137
			// (set) Token: 0x06000E99 RID: 3737 RVA: 0x00031F3F File Offset: 0x0003013F
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

			// Token: 0x17000502 RID: 1282
			// (get) Token: 0x06000E9A RID: 3738 RVA: 0x00031F48 File Offset: 0x00030148
			// (set) Token: 0x06000E9B RID: 3739 RVA: 0x00031F50 File Offset: 0x00030150
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

			// Token: 0x17000503 RID: 1283
			// (get) Token: 0x06000E9C RID: 3740 RVA: 0x00031F59 File Offset: 0x00030159
			// (set) Token: 0x06000E9D RID: 3741 RVA: 0x00031F61 File Offset: 0x00030161
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

			// Token: 0x040008A7 RID: 2215
			[SerializeField]
			private RecalculableJointBase.LimitacionDeMotionConfig m_LimitacionDeMotionConfig = new LabioPoint.LabiosConfigs.LimitacionesDeMotionConfig();

			// Token: 0x040008A8 RID: 2216
			[SerializeField]
			private JointAnglesAdmin.Configuracion m_JointAnglesAdmin = new LabioPoint.LabiosConfigs.JointAnglesAdminConfig();

			// Token: 0x040008A9 RID: 2217
			[SerializeField]
			private JointAxisAdmin.Configuracion m_JointAxisAdmin = new LabioPoint.LabiosConfigs.JointAxisConfig();

			// Token: 0x040008AA RID: 2218
			[SerializeField]
			private JointBodyAdmin.Configuracion m_JointBodyAdmin = new LabioPoint.LabiosConfigs.JointBodyConfig();

			// Token: 0x040008AB RID: 2219
			[SerializeField]
			private JointDistancesAdmin.Configuracion m_JointDistancesAdmin = new LabioPoint.LabiosConfigs.JointDistancesConfig();

			// Token: 0x040008AC RID: 2220
			[SerializeField]
			private JointDrivesAdminV2.Configuracion m_JointDrivesAdminV2 = new LabioPoint.LabiosConfigs.JointDriveConfig();

			// Token: 0x040008AD RID: 2221
			[SerializeField]
			private JointMotionsAdmin.Configuracion m_JointMotionsAdmin = new LabioPoint.LabiosConfigs.JointMotionsConfig();
		}

		// Token: 0x02000181 RID: 385
		public static class LabiosConfigs
		{
			// Token: 0x0200021C RID: 540
			public class LimitacionesDeMotionConfig : RecalculableJointBase.LimitacionDeMotionConfig
			{
				// Token: 0x06001016 RID: 4118 RVA: 0x00035D8C File Offset: 0x00033F8C
				public LimitacionesDeMotionConfig()
				{
					this.usar = true;
					this.limitaciones = new List<LimitarPolaridadDeAxis.Configuracion>
					{
						new LimitarPolaridadDeAxis.Configuracion
						{
							axisPolarizado = AxisPolarizado.yNegative,
							toleranceMod = 1f
						},
						new LimitarPolaridadDeAxis.Configuracion
						{
							axisPolarizado = AxisPolarizado.xPositive,
							toleranceMod = 0.5f
						},
						new LimitarPolaridadDeAxis.Configuracion
						{
							axisPolarizado = AxisPolarizado.xNegative,
							toleranceMod = 0.5f
						}
					};
				}
			}

			// Token: 0x0200021D RID: 541
			public class JointDriveConfig : JointDrivesAdminV2.Configuracion
			{
				// Token: 0x06001017 RID: 4119 RVA: 0x00035E0C File Offset: 0x0003400C
				public JointDriveConfig()
				{
					this.isInverted = true;
					this.zDrive = new JointDriveConfiguration(3000f)
					{
						addingSpringToDamperPercent = 1f
					};
					JointDriveConfiguration jointDriveConfiguration = new JointDriveConfiguration(7500f);
					jointDriveConfiguration.addingSpringToDamperPercent = 1f;
					JointDriveConfiguration jointDriveConfiguration2 = jointDriveConfiguration;
					this.yDrive = jointDriveConfiguration;
					this.xDrive = jointDriveConfiguration2;
				}
			}

			// Token: 0x0200021E RID: 542
			public class JointDistancesConfig : JointDistancesAdmin.Configuracion
			{
				// Token: 0x06001018 RID: 4120 RVA: 0x00035E65 File Offset: 0x00034065
				public JointDistancesConfig()
				{
					this.targetPosition.mode = JointDistancesAdmin.TargetPositionMode.freeTrack;
					this.targetPosition.freeTrackOptions.minDistanceMod = 0.05f;
					this.targetPosition.freeTrackOptions.maxDistanceMod = 1.1f;
				}
			}

			// Token: 0x0200021F RID: 543
			public class JointAxisConfig : JointAxisAdmin.Configuracion
			{
				// Token: 0x06001019 RID: 4121 RVA: 0x00035EA3 File Offset: 0x000340A3
				public JointAxisConfig()
				{
					this.localUpAxis = Vector3.forward;
				}
			}

			// Token: 0x02000220 RID: 544
			public class JointBodyConfig : JointBodyAdmin.Configuracion
			{
				// Token: 0x0600101A RID: 4122 RVA: 0x00035EB8 File Offset: 0x000340B8
				public JointBodyConfig()
				{
					this.density = 0.0033f;
					this.locaCenterOffMass = Vector3.zero;
					this.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
					this.maxDepenetrationVelocity = 0.25f;
					this.maxVelocity = 0.1f;
					this.solverIterations = 24;
					this.solverVelocityIterations = 1;
					this.angularDrag = 0.1f;
					this.drag = 0.1f;
				}
			}

			// Token: 0x02000221 RID: 545
			public class JointMotionsConfig : JointMotionsAdmin.Configuracion
			{
				// Token: 0x0600101B RID: 4123 RVA: 0x00035F23 File Offset: 0x00034123
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

			// Token: 0x02000222 RID: 546
			public class JointAnglesAdminConfig : JointAnglesAdmin.Configuracion
			{
				// Token: 0x0600101C RID: 4124 RVA: 0x00035F55 File Offset: 0x00034155
				public JointAnglesAdminConfig()
				{
					this.lowAngularXLimit = -65f;
					this.highAngularXLimit = 65f;
				}
			}
		}
	}
}
