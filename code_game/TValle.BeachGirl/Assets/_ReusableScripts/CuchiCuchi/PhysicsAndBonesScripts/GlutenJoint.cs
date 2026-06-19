using System;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000F8 RID: 248
	[RequireComponent(typeof(Rigidbody))]
	public class GlutenJoint : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06000A97 RID: 2711 RVA: 0x000227F4 File Offset: 0x000209F4
		// (set) Token: 0x06000A98 RID: 2712 RVA: 0x000227FC File Offset: 0x000209FC
		public GlobalUpdater.UpdateType updateEvent
		{
			get
			{
				return this.m_UpdateEvent;
			}
			set
			{
				this.m_UpdateEvent = value;
			}
		}

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06000A99 RID: 2713 RVA: 0x00022805 File Offset: 0x00020A05
		public sealed override int updateEvent1Index
		{
			get
			{
				return (int)this.m_UpdateEvent;
			}
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x00022810 File Offset: 0x00020A10
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
			this.m_joint = this.GetComponentNotNull<ConfigurableJoint>();
			this.reset();
			this.m_drivesAdmin = this.GetComponentNotNull<JointDrivesAdmin>();
			this.m_distancesAdmin = this.GetComponentNotNull<JointDistancesAdmin>();
			this.m_densityAdmin = this.GetComponentNotNull<DensityAdminByScaleV2>();
			this.m_drivesAdmin.customUpdatedConfig.manualStart = true;
			this.m_distancesAdmin.customUpdatedConfig.manualStart = true;
			this.m_densityAdmin.customUpdatedConfig.manualStart = true;
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x00022898 File Offset: 0x00020A98
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_densityAdmin.references = this.densityReferences;
			this.m_densityAdmin.config.userCalculedInitialVolumen = this.jiggleConfig.glutenVolumen;
			this.m_densityAdmin.config.material = this.jiggleConfig.glutenMaterial;
			this.m_drivesAdmin.ManualStart();
			this.m_distancesAdmin.ManualStart();
			this.m_densityAdmin.ManualStart();
			this.ApplyConfig();
			this.LoadBroadcasters();
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x00022920 File Offset: 0x00020B20
		private void LoadBroadcasters()
		{
			this.m_scalerScaledBroadcaster = base.gameObject.AddComponent<ScaleChangedBroadcaster>();
			this.m_scalerScaledBroadcaster.AddTarget(this.densityReferences.scaler, true);
			this.m_scalerScaledBroadcaster.updateEvent = this.m_UpdateEvent;
			this.m_scalerScaledBroadcaster.ScaleChanged += new ScaleChangedBroadcaster.ScaleChangedHandler(this.ScaleChanged);
			this.m_rootScaledBroadcaster = base.gameObject.AddComponent<ScaleChangedBroadcaster>();
			this.m_rootScaledBroadcaster.AddTarget(this.densityReferences.nonStrechedParent, false);
			this.m_rootScaledBroadcaster.updateEvent = this.m_UpdateEvent;
			this.m_rootScaledBroadcaster.ScaleChanged += new ScaleChangedBroadcaster.ScaleChangedHandler(this.ScaleChanged);
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x000229D0 File Offset: 0x00020BD0
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_scalerScaledBroadcaster != null)
			{
				this.m_scalerScaledBroadcaster.ScaleChanged -= new ScaleChangedBroadcaster.ScaleChangedHandler(this.ScaleChanged);
			}
			if (this.m_rootScaledBroadcaster != null)
			{
				this.m_rootScaledBroadcaster.ScaleChanged -= new ScaleChangedBroadcaster.ScaleChangedHandler(this.ScaleChanged);
			}
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x00022A2E File Offset: 0x00020C2E
		private void ScaleChanged(object target)
		{
			this.ApplyConfig();
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x00022A38 File Offset: 0x00020C38
		private void reset()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
			this.m_Rigidbody.isKinematic = true;
			this.m_joint.autoConfigureConnectedAnchor = false;
			this.m_joint.projectionMode = JointProjectionMode.PositionAndRotation;
			this.m_joint.breakForce = float.PositiveInfinity;
			this.m_joint.breakTorque = float.PositiveInfinity;
			this.m_joint.anchor = Vector3.zero;
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x00022AA8 File Offset: 0x00020CA8
		public void ApplyConfig()
		{
			GlutenJoint.JiggleConfig.Angular angular = this.jiggleConfig.angular;
			if (angular.activeJiggleVertical)
			{
				this.m_joint.angularXMotion = ConfigurableJointMotion.Limited;
			}
			if (angular.activeJiggleHorizontal)
			{
				this.m_joint.angularYMotion = ConfigurableJointMotion.Limited;
			}
			if (angular.activeJiggleRoll)
			{
				this.m_joint.angularZMotion = ConfigurableJointMotion.Limited;
			}
			this.m_joint.lowAngularXLimit = GlutenJoint.GetLimit(angular.minimoAnguloVertical);
			this.m_joint.highAngularXLimit = GlutenJoint.GetLimit(angular.maximoAnguloVertical);
			this.m_joint.angularYLimit = GlutenJoint.GetLimit(angular.minimoYMaximoAnguloHorizontal);
			this.m_joint.angularZLimit = GlutenJoint.GetLimit(angular.minimoYMaximoAnguloRoll);
			this.m_densityAdmin.config.material = this.jiggleConfig.glutenMaterial;
			JointDrivesAdmin.Configuracion configuracion = this.m_drivesAdmin.configuracion;
			GlutenJoint.JiggleConfig.Angular angular2 = this.jiggleConfig.angular;
			configuracion.xAngularDamper = angular2.jiggleDamperVertical;
			configuracion.xAngularSpring = angular2.jiggleVertical;
			configuracion.YZAngularDamper = angular2.jiggleDamperHorizontalAndRoll;
			configuracion.YZAngularSpring = angular2.jiggleHorizontalAndRoll;
			this.m_densityAdmin.UpdateMass();
			this.m_drivesAdmin.FixDrivers(this.m_densityAdmin.currentNonStrechedMass);
			this.m_distancesAdmin.FixDistances();
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x00022BE4 File Offset: 0x00020DE4
		private static SoftJointLimit GetLimit(float limit)
		{
			return new SoftJointLimit
			{
				limit = limit,
				contactDistance = Math.Abs(limit * 0.5f)
			};
		}

		// Token: 0x0400059F RID: 1439
		[SerializeField]
		protected GlobalUpdater.UpdateType m_UpdateEvent = GlobalUpdater.UpdateType.fixedUpdate1;

		// Token: 0x040005A0 RID: 1440
		private Rigidbody m_Rigidbody;

		// Token: 0x040005A1 RID: 1441
		private ConfigurableJoint m_joint;

		// Token: 0x040005A2 RID: 1442
		private JointDrivesAdmin m_drivesAdmin;

		// Token: 0x040005A3 RID: 1443
		private JointDistancesAdmin m_distancesAdmin;

		// Token: 0x040005A4 RID: 1444
		private DensityAdminByScaleV2 m_densityAdmin;

		// Token: 0x040005A5 RID: 1445
		private ScaleChangedBroadcaster m_rootScaledBroadcaster;

		// Token: 0x040005A6 RID: 1446
		private ScaleChangedBroadcaster m_scalerScaledBroadcaster;

		// Token: 0x040005A7 RID: 1447
		public GlutenJoint.JiggleConfig jiggleConfig = new GlutenJoint.JiggleConfig();

		// Token: 0x040005A8 RID: 1448
		public DensityAdminByScaleV2.References densityReferences = new DensityAdminByScaleV2.References();

		// Token: 0x020001D1 RID: 465
		[Serializable]
		public class JiggleConfig
		{
			// Token: 0x04000A41 RID: 2625
			public MaterialDensityMap.Material glutenMaterial = MaterialDensityMap.Material.fatMeat;

			// Token: 0x04000A42 RID: 2626
			[Tooltip("m3")]
			public float glutenVolumen = 0.011f;

			// Token: 0x04000A43 RID: 2627
			public GlutenJoint.JiggleConfig.Angular angular = new GlutenJoint.JiggleConfig.Angular();

			// Token: 0x02000232 RID: 562
			[Serializable]
			public class Angular
			{
				// Token: 0x04000B49 RID: 2889
				public bool activeJiggleVertical = true;

				// Token: 0x04000B4A RID: 2890
				public bool activeJiggleHorizontal = true;

				// Token: 0x04000B4B RID: 2891
				public bool activeJiggleRoll = true;

				// Token: 0x04000B4C RID: 2892
				[Range(-177f, 0f)]
				public float minimoAnguloVertical = -60f;

				// Token: 0x04000B4D RID: 2893
				[Range(0f, 177f)]
				public float maximoAnguloVertical = 45f;

				// Token: 0x04000B4E RID: 2894
				[Range(3f, 177f)]
				public float minimoYMaximoAnguloHorizontal = 45f;

				// Token: 0x04000B4F RID: 2895
				[Range(3f, 177f)]
				public float minimoYMaximoAnguloRoll = 45f;

				// Token: 0x04000B50 RID: 2896
				[Tooltip("rotacion en local x axis desde joint, al aumentar la masa no es necesario cambiar este valor")]
				[Range(0f, 100f)]
				public float jiggleVertical = 8f;

				// Token: 0x04000B51 RID: 2897
				[Tooltip("rotacion en local yz axis desde joint, al aumentar la masa no es necesario cambiar este valor")]
				[Range(0f, 100f)]
				public float jiggleHorizontalAndRoll = 8f;

				// Token: 0x04000B52 RID: 2898
				[Tooltip("al aumentar la masa no es necesario cambiar este valor")]
				[Range(0f, 100f)]
				public float jiggleDamperVertical;

				// Token: 0x04000B53 RID: 2899
				[Tooltip("al aumentar la masa no es necesario cambiar este valor")]
				[Range(0f, 100f)]
				public float jiggleDamperHorizontalAndRoll;
			}
		}
	}
}
