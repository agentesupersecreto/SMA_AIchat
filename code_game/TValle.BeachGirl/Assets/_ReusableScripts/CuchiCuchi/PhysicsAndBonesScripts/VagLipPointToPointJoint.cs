using System;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000EC RID: 236
	[RequireComponent(typeof(Rigidbody))]
	public class VagLipPointToPointJoint : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x060009D8 RID: 2520 RVA: 0x0001FA1A File Offset: 0x0001DC1A
		public ModificadorDeDriversDeJoint suavizadorPropioDePoint
		{
			get
			{
				return this.m_suavizadorPropioDePoint;
			}
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x0001FA22 File Offset: 0x0001DC22
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_joint = this.GetComponentNotNull<ConfigurableJoint>();
			this.InitJointDrivesAdmin();
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x0001FA3C File Offset: 0x0001DC3C
		public void SetConnectedBody(Rigidbody other, int index, ModificadorDeDriversDeJoint modDeSide = null)
		{
			if (this.m_joint == null)
			{
				throw new ArgumentNullException("m_joint", "m_joint null reference.");
			}
			this.m_joint.connectedBody = other;
			if (modDeSide != null)
			{
				this.m_JointDrivesAdmin.suavisable.TryAddModificador(modDeSide);
			}
			this.m_suavizadorPropioDePoint = this.m_JointDrivesAdmin.suavisable.AddModificador("mod_" + base.name);
			float num = Mathf.InverseLerp(0f, 6f, (float)index);
			num = num.OutPow(2f);
			num = Mathf.Lerp(0.5f, 1f, num);
			this.m_suavizadorPropioDePoint.SetAllToNotAngular(num, 1f, true);
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x0001FAF0 File Offset: 0x0001DCF0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.m_joint.connectedBody == null)
			{
				throw new ArgumentNullException("m_joint.connectedBody", "m_joint.connectedBody null reference.");
			}
			if (this.configuraciones == null)
			{
				this.configuraciones = new VagLipPointToPointJoint.Configuraciones();
			}
			this.LoadDefaultJointConfig();
			this.StartJointDrivesAdmin();
			this.UpdateFixers();
			this.LoadBroadcasters();
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x0001FB51 File Offset: 0x0001DD51
		private void LoadDefaultJointConfig()
		{
			this.m_joint.projectionMode = JointProjectionMode.PositionAndRotation;
			this.m_joint.projectionDistance = 0.001f;
			this.m_joint.breakForce = float.PositiveInfinity;
			this.m_joint.breakTorque = float.PositiveInfinity;
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x0001FB90 File Offset: 0x0001DD90
		private void LoadBroadcasters()
		{
			this.m_ScaleChangedBroadcaster = this.GetComponentNotNull<ScaleChangedBroadcaster>();
			this.m_ScaleChangedBroadcaster.AddTarget(base.transform, false);
			this.m_ScaleChangedBroadcaster.updateEvent = this.m_UpdateEvent;
			this.m_ScaleChangedBroadcaster.ScaleChanged += new ScaleChangedBroadcaster.ScaleChangedHandler(this.ScaleChanged);
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x0001FBE4 File Offset: 0x0001DDE4
		public void UpdateFixers()
		{
			this.m_JointDrivesAdmin.FixDrivers();
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x0001FBF1 File Offset: 0x0001DDF1
		private void ScaleChanged(object target)
		{
			this.UpdateFixers();
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x0001FBF9 File Offset: 0x0001DDF9
		private void InitJointDrivesAdmin()
		{
			this.m_JointDrivesAdmin = this.GetComponentNotNull<JointDrivesAdminV2>();
			this.m_JointDrivesAdmin.customUpdatedConfig.manualStart = true;
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x0001FC18 File Offset: 0x0001DE18
		private void StartJointDrivesAdmin()
		{
			this.m_JointDrivesAdmin.configuracion = this.configuraciones.jointDrivesAdmin;
			this.m_JointDrivesAdmin.ManualStart();
		}

		// Token: 0x0400053E RID: 1342
		[SerializeField]
		protected GlobalUpdater.UpdateType m_UpdateEvent = GlobalUpdater.UpdateType.fixedUpdate2;

		// Token: 0x0400053F RID: 1343
		[SerializeField]
		private ModificadorDeDriversDeJoint m_suavizadorPropioDePoint;

		// Token: 0x04000540 RID: 1344
		private JointDrivesAdminV2 m_JointDrivesAdmin;

		// Token: 0x04000541 RID: 1345
		private ConfigurableJoint m_joint;

		// Token: 0x04000542 RID: 1346
		private ScaleChangedBroadcaster m_ScaleChangedBroadcaster;

		// Token: 0x04000543 RID: 1347
		public VagLipPointToPointJoint.Configuraciones configuraciones = new VagLipPointToPointJoint.Configuraciones();

		// Token: 0x020001C2 RID: 450
		[Serializable]
		public class Configuraciones
		{
			// Token: 0x04000A0C RID: 2572
			public JointDrivesAdminV2.Configuracion jointDrivesAdmin = new JointDrivesAdminV2.Configuracion
			{
				xDrive = new JointDriveConfiguration(4000f, 0f),
				yDrive = new JointDriveConfiguration(4000f, 0f),
				zDrive = new JointDriveConfiguration(15000f, 0f)
			};
		}
	}
}
