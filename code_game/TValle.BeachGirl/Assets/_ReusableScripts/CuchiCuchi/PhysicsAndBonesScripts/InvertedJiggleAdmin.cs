using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000F9 RID: 249
	[Obsolete]
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(ConfigurableJoint))]
	public class InvertedJiggleAdmin : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06000AA3 RID: 2723 RVA: 0x00022C3B File Offset: 0x00020E3B
		// (set) Token: 0x06000AA4 RID: 2724 RVA: 0x00022C43 File Offset: 0x00020E43
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

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06000AA5 RID: 2725 RVA: 0x00022C4C File Offset: 0x00020E4C
		public sealed override int updateEvent1Index
		{
			get
			{
				return (int)this.m_UpdateEvent;
			}
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x00022C54 File Offset: 0x00020E54
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.reset();
			this.dynamicBoneChangesSeekerCallbacks = new InvertedJiggleAdmin.Callbacks
			{
				OnMassChaged = new Action<Rigidbody, float, float>(this.OnMassChaged)
			};
			this.m_dynamicBoneChangesSeeker = new InvertedJiggleAdmin.RigidbodyChangesSeeker(this.m_dynamicBone, this.dynamicBoneChangesSeekerCallbacks);
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x00022CA1 File Offset: 0x00020EA1
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.ApplyConfig();
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x00022CB0 File Offset: 0x00020EB0
		protected override void OnValidateUnityEvent()
		{
			base.OnValidateUnityEvent();
			if (Application.isPlaying && this.m_ConfigurableJoint != null && this.m_Rigidbody != null && this.m_dynamicBone != null)
			{
				this.OnConfigChaged();
				this.m_dynamicBone.WakeUp();
			}
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x00022D08 File Offset: 0x00020F08
		private void reset()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
			this.m_Rigidbody.isKinematic = true;
			this.m_ConfigurableJoint = base.GetComponent<ConfigurableJoint>();
			this.m_ConfigurableJoint.autoConfigureConnectedAnchor = false;
			this.m_ConfigurableJoint.projectionMode = JointProjectionMode.PositionAndRotation;
			this.m_ConfigurableJoint.breakForce = float.PositiveInfinity;
			this.m_ConfigurableJoint.breakTorque = float.PositiveInfinity;
			this.m_ConfigurableJoint.anchor = Vector3.zero;
			this.m_ConfigurableJoint.connectedAnchor = this.m_dynamicBone.transform.InverseTransformPoint(this.m_Rigidbody.transform.position);
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x00022DAC File Offset: 0x00020FAC
		public void ApplyConfig()
		{
			float mass = this.m_dynamicBone.mass;
			InvertedJiggleAdmin.JiggleConfig angular = this.config.angular;
			if (angular.activeJiggleVertical)
			{
				this.m_ConfigurableJoint.angularXMotion = ConfigurableJointMotion.Limited;
			}
			if (angular.activeJiggleHorizontal)
			{
				this.m_ConfigurableJoint.angularYMotion = ConfigurableJointMotion.Limited;
			}
			if (angular.activeJiggleRoll)
			{
				this.m_ConfigurableJoint.angularZMotion = ConfigurableJointMotion.Limited;
			}
			float num = mass * angular.jiggleVertical;
			float num2 = mass * angular.jiggleHorizontalAndRoll;
			float num3 = mass * angular.jiggleDamperVertical;
			float num4 = mass * angular.jiggleDamperHorizontalAndRoll;
			this.m_ConfigurableJoint.angularXDrive = InvertedJiggleAdmin.GetDrive(num, num3);
			this.m_ConfigurableJoint.angularYZDrive = InvertedJiggleAdmin.GetDrive(num2, num4);
			this.m_ConfigurableJoint.lowAngularXLimit = InvertedJiggleAdmin.GetLimit(angular.minimoAnguloVertical);
			this.m_ConfigurableJoint.highAngularXLimit = InvertedJiggleAdmin.GetLimit(angular.maximoAnguloVertical);
			this.m_ConfigurableJoint.angularYLimit = InvertedJiggleAdmin.GetLimit(angular.minimoYMaximoAnguloHorizontal);
			this.m_ConfigurableJoint.angularZLimit = InvertedJiggleAdmin.GetLimit(angular.minimoYMaximoAnguloRoll);
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x00022EAD File Offset: 0x000210AD
		public override void OnUpdateEvent1()
		{
			base.OnUpdateEvent1();
			this.m_dynamicBoneChangesSeeker.Update123();
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x00022EC0 File Offset: 0x000210C0
		private static JointDrive GetDrive(float spring, float damper = 0f)
		{
			return new JointDrive
			{
				maximumForce = 3.402823E+38f,
				positionDamper = damper,
				positionSpring = spring
			};
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x00022EF4 File Offset: 0x000210F4
		private static SoftJointLimit GetLimit(float limit)
		{
			return new SoftJointLimit
			{
				limit = limit,
				contactDistance = Math.Abs(limit * 0.5f)
			};
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x00022F25 File Offset: 0x00021125
		protected void OnMassChaged(Rigidbody changed, float last, float current)
		{
			this.ApplyConfig();
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x00022F2D File Offset: 0x0002112D
		protected void OnConfigChaged()
		{
			this.ApplyConfig();
		}

		// Token: 0x040005A9 RID: 1449
		private ConfigurableJoint m_ConfigurableJoint;

		// Token: 0x040005AA RID: 1450
		private Rigidbody m_Rigidbody;

		// Token: 0x040005AB RID: 1451
		[SerializeField]
		private Rigidbody m_dynamicBone;

		// Token: 0x040005AC RID: 1452
		[SerializeField]
		protected GlobalUpdater.UpdateType m_UpdateEvent = GlobalUpdater.UpdateType.fixedUpdate3;

		// Token: 0x040005AD RID: 1453
		private InvertedJiggleAdmin.RigidbodyChangesSeeker m_dynamicBoneChangesSeeker;

		// Token: 0x040005AE RID: 1454
		private InvertedJiggleAdmin.Callbacks dynamicBoneChangesSeekerCallbacks;

		// Token: 0x040005AF RID: 1455
		public InvertedJiggleAdmin.Config config;

		// Token: 0x020001D2 RID: 466
		private class RigidbodyChangesSeeker
		{
			// Token: 0x06000F7F RID: 3967 RVA: 0x000347BC File Offset: 0x000329BC
			public RigidbodyChangesSeeker(Rigidbody rigidbody, InvertedJiggleAdmin.Callbacks callbacks)
			{
				this.rigidbody = rigidbody;
				this.callbacks = callbacks;
				this.m_lastMass = rigidbody.mass;
			}

			// Token: 0x06000F80 RID: 3968 RVA: 0x000347E0 File Offset: 0x000329E0
			public void Update123()
			{
				float mass = this.rigidbody.mass;
				if (this.m_lastMass != mass)
				{
					float lastMass = this.m_lastMass;
					this.m_lastMass = mass;
					this.callbacks.OnMassChaged(this.rigidbody, lastMass, mass);
				}
			}

			// Token: 0x04000A44 RID: 2628
			private readonly InvertedJiggleAdmin.Callbacks callbacks;

			// Token: 0x04000A45 RID: 2629
			private readonly Rigidbody rigidbody;

			// Token: 0x04000A46 RID: 2630
			private float m_lastMass;
		}

		// Token: 0x020001D3 RID: 467
		private class Callbacks
		{
			// Token: 0x04000A47 RID: 2631
			public Action<Rigidbody, float, float> OnMassChaged;
		}

		// Token: 0x020001D4 RID: 468
		[Serializable]
		public class Config
		{
			// Token: 0x04000A48 RID: 2632
			public InvertedJiggleAdmin.JiggleConfig angular;
		}

		// Token: 0x020001D5 RID: 469
		[Serializable]
		public class JiggleConfig
		{
			// Token: 0x04000A49 RID: 2633
			public bool activeJiggleVertical = true;

			// Token: 0x04000A4A RID: 2634
			public bool activeJiggleHorizontal = true;

			// Token: 0x04000A4B RID: 2635
			public bool activeJiggleRoll = true;

			// Token: 0x04000A4C RID: 2636
			[Range(-177f, 0f)]
			public float minimoAnguloVertical = -45f;

			// Token: 0x04000A4D RID: 2637
			[Range(0f, 177f)]
			public float maximoAnguloVertical = 45f;

			// Token: 0x04000A4E RID: 2638
			[Range(3f, 177f)]
			public float minimoYMaximoAnguloHorizontal = 45f;

			// Token: 0x04000A4F RID: 2639
			[Range(3f, 177f)]
			public float minimoYMaximoAnguloRoll = 45f;

			// Token: 0x04000A50 RID: 2640
			[Tooltip("rotacion en local x axis desde joint, al aumentar la masa no es necesario cambiar este valor")]
			[Range(0f, 100f)]
			public float jiggleVertical = 1f;

			// Token: 0x04000A51 RID: 2641
			[Tooltip("rotacion en local yz axis desde joint, al aumentar la masa no es necesario cambiar este valor")]
			[Range(0f, 100f)]
			public float jiggleHorizontalAndRoll = 1f;

			// Token: 0x04000A52 RID: 2642
			[Tooltip("al aumentar la masa no es necesario cambiar este valor")]
			[Range(0f, 100f)]
			public float jiggleDamperVertical;

			// Token: 0x04000A53 RID: 2643
			[Tooltip("al aumentar la masa no es necesario cambiar este valor")]
			[Range(0f, 100f)]
			public float jiggleDamperHorizontalAndRoll;
		}
	}
}
