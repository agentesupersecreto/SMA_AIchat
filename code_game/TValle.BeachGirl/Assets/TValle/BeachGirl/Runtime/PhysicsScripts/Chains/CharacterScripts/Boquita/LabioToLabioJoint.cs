using System;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita
{
	// Token: 0x02000091 RID: 145
	public class LabioToLabioJoint : CustomMonobehaviour
	{
		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x0000DD41 File Offset: 0x0000BF41
		public ModificadorDeDriversDeJoint suavizadorPropioDePoint
		{
			get
			{
				return this.m_suavizadorPropioDePoint;
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x0000DD49 File Offset: 0x0000BF49
		public ConfigurableJoint joint
		{
			get
			{
				return this.m_joint;
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x0000DD51 File Offset: 0x0000BF51
		public Transform jointTransform
		{
			get
			{
				return base.transform;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x0000DD59 File Offset: 0x0000BF59
		public LabioPoint target
		{
			get
			{
				return this.m_target;
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x0000DD61 File Offset: 0x0000BF61
		public LabioPoint self
		{
			get
			{
				return this.m_self;
			}
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0000DD69 File Offset: 0x0000BF69
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_joint = base.gameObject.AddComponent<ConfigurableJoint>();
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x0000DD84 File Offset: 0x0000BF84
		public void SetConnectedBody(LabioPoint other, LabioPoint Self, int index, ModificadorDeDriversDeJoint modDeSide = null)
		{
			if (base.isStared)
			{
				throw new NotSupportedException();
			}
			if (other == null)
			{
				throw new ArgumentNullException("other", "other null reference.");
			}
			if (Self == null)
			{
				throw new ArgumentNullException("Self", "Self null reference.");
			}
			this.m_target = other;
			this.m_self = Self;
			this.InitJointAdmins();
			if (modDeSide != null)
			{
				this.m_JointDrivesAdmin.suavisable.TryAddModificador(modDeSide);
			}
			this.m_suavizadorPropioDePoint = this.m_JointDrivesAdmin.suavisable.AddModificador("mod_" + base.name);
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0000DE24 File Offset: 0x0000C024
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_joint.connectedBody = this.m_target.targetBodyTransform.GetComponent<Rigidbody>();
			if (this.m_joint.connectedBody == null)
			{
				throw new ArgumentNullException("m_joint.connectedBody", "m_joint.connectedBody null reference.");
			}
			if (this.m_joint.connectedBody == null)
			{
				throw new ArgumentNullException("m_joint.connectedBody", "m_joint.connectedBody null reference.");
			}
			if (this.configuraciones == null)
			{
				this.configuraciones = new LabioToLabioJoint.Configuraciones();
			}
			this.LoadDefaultJointConfig();
			this.StartJointAdmins();
			this.FixAdmins();
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x0000DEC0 File Offset: 0x0000C0C0
		private void LoadDefaultJointConfig()
		{
			this.m_joint.projectionMode = JointProjectionMode.PositionAndRotation;
			this.m_joint.autoConfigureConnectedAnchor = false;
			this.m_joint.projectionDistance = 0.001f;
			this.m_joint.breakForce = float.PositiveInfinity;
			this.m_joint.breakTorque = float.PositiveInfinity;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x0000DF15 File Offset: 0x0000C115
		public void FixAdmins()
		{
			this.m_JointDrivesAdmin.FixDrivers();
			this.m_JointAxisAdmin.Fix();
			this.m_JointDistancesAdmin.Fix();
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x0000DF38 File Offset: 0x0000C138
		public void SetTarget(Vector3 customWorldPoint)
		{
			this.m_JointAxisAdmin.RecalculeAxisTo(customWorldPoint);
			this.m_JointDistancesAdmin.SetJointTargetPosition(customWorldPoint);
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x0000DF54 File Offset: 0x0000C154
		private void InitJointAdmins()
		{
			Transform transform = base.transform.CreateChild(base.transform.name + "_To_" + this.m_target.name);
			this.m_JointDrivesAdmin = transform.GetComponentNotNull<JointDrivesAdminV2>();
			this.m_JointDrivesAdmin.customUpdatedConfig.manualStart = true;
			this.m_JointDrivesAdmin.SetConfigurableJoint(this.m_joint);
			this.m_JointAxisAdmin = transform.GetComponentNotNull<JointAxisAdmin>();
			this.m_JointAxisAdmin.customUpdatedConfig.manualStart = true;
			this.m_JointAxisAdmin.SetConfigurableJoint(this.m_joint);
			this.m_JointDistancesAdmin = transform.GetComponentNotNull<JointDistancesAdmin>();
			this.m_JointDistancesAdmin.customUpdatedConfig.manualStart = true;
			this.m_JointDistancesAdmin.SetConfigurableJoint(this.m_joint);
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x0000E018 File Offset: 0x0000C218
		private void StartJointAdmins()
		{
			this.m_JointDrivesAdmin.configuracion = this.configuraciones.jointDrivesAdmin;
			this.m_JointDrivesAdmin.ManualStart();
			this.m_JointAxisAdmin.configuracion = this.configuraciones.jointAxisAdmin;
			this.m_JointAxisAdmin.ManualStart();
			this.m_JointDistancesAdmin.configuracion = this.configuraciones.jointDistancesAdmin;
			this.m_JointDistancesAdmin.ManualStart();
		}

		// Token: 0x04000294 RID: 660
		[SerializeField]
		private ModificadorDeDriversDeJoint m_suavizadorPropioDePoint;

		// Token: 0x04000295 RID: 661
		private JointDrivesAdminV2 m_JointDrivesAdmin;

		// Token: 0x04000296 RID: 662
		private JointAxisAdmin m_JointAxisAdmin;

		// Token: 0x04000297 RID: 663
		private JointDistancesAdmin m_JointDistancesAdmin;

		// Token: 0x04000298 RID: 664
		private ConfigurableJoint m_joint;

		// Token: 0x04000299 RID: 665
		public LabioToLabioJoint.Configuraciones configuraciones = new LabioToLabioJoint.Configuraciones();

		// Token: 0x0400029A RID: 666
		[SerializeField]
		[ReadOnlyUI]
		private LabioPoint m_target;

		// Token: 0x0400029B RID: 667
		[SerializeField]
		[ReadOnlyUI]
		private LabioPoint m_self;

		// Token: 0x02000184 RID: 388
		[Serializable]
		public class Configuraciones
		{
			// Token: 0x040008C4 RID: 2244
			public JointDrivesAdminV2.Configuracion jointDrivesAdmin = new JointDrivesAdminV2.Configuracion
			{
				isInverted = true,
				xDrive = new JointDriveConfiguration(1500f)
				{
					addingSpringToDamperPercent = 1f
				},
				yDrive = new JointDriveConfiguration(1500f)
				{
					addingSpringToDamperPercent = 1f
				},
				zDrive = new JointDriveConfiguration(1500f)
				{
					addingSpringToDamperPercent = 1f
				}
			};

			// Token: 0x040008C5 RID: 2245
			public JointAxisAdmin.Configuracion jointAxisAdmin = new JointAxisAdmin.Configuracion
			{
				localUpAxis = Vector3.forward
			};

			// Token: 0x040008C6 RID: 2246
			public JointDistancesAdmin.Configuracion jointDistancesAdmin = new JointDistancesAdmin.Configuracion
			{
				isInverted = true,
				targetPosition = new JointDistancesAdmin.Configuracion.TargetPosition
				{
					mode = JointDistancesAdmin.TargetPositionMode.freeTrack,
					freeTrackOptions = new JointDistancesAdmin.Configuracion.TargetPosition.FreeTargetOptions
					{
						minDistanceMod = 0.05f,
						maxDistanceMod = 5f
					}
				},
				fixigOptions = new JointDistancesAdmin.Configuracion.FixigOptions
				{
					fixOtherPosition = true,
					fixOwnPosition = true
				},
				RestoreJointPositionAndRotationAfterFix = true,
				RestoreOtherBodyPositionAndRotationAfterFix = true,
				RestoreLocalSpaceAfterFix = true
			};
		}
	}
}
