using System;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.PhysicsScripts;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes
{
	// Token: 0x0200004F RID: 79
	[RequireComponent(typeof(Animator))]
	public class PuppetCollidersToConvexAdder : AplicableBehaviour
	{
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600034E RID: 846 RVA: 0x000109D4 File Offset: 0x0000EBD4
		public PuppetColliderToConvex hipsCollider
		{
			get
			{
				return this.m_HipsCollider;
			}
		}

		// Token: 0x0600034F RID: 847 RVA: 0x000109DC File Offset: 0x0000EBDC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_puppet = base.transform.parent.GetComponentInChildren<PuppetMaster>();
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00010A08 File Offset: 0x0000EC08
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			Transform transform = this.m_Animator.transform.CreateChild("ConvexColliders_Root");
			this.AddColliders(transform);
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00010A38 File Offset: 0x0000EC38
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.m_HipsCollider.Aplicar();
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00010A4B File Offset: 0x0000EC4B
		private void AddColliders(Transform parent)
		{
			this.AddHipsColliders(parent);
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00010A54 File Offset: 0x0000EC54
		private void AddHipsColliders(Transform parent)
		{
			PuppetMaster puppet = this.m_puppet;
			Muscle muscle = PuppetCollidersToConvexAdder.GetMuscle(this.m_Animator, puppet, HumanBodyBones.Hips);
			Transform transform = parent.CreateChild(muscle.name + "_ConvexCollider");
			this.m_HipsCollider = transform.gameObject.AddComponent<PuppetColliderToConvex>();
			this.m_HipsCollider.Init(this.m_Layer, puppet, muscle, this.jointConfig);
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00010AB8 File Offset: 0x0000ECB8
		public static Muscle GetMuscle(Animator anim, PuppetMaster puppet, HumanBodyBones bone)
		{
			Transform boneTransform = anim.GetBoneTransform(bone);
			foreach (Muscle muscle in puppet.muscles)
			{
				if (muscle.target == boneTransform)
				{
					return muscle;
				}
			}
			return null;
		}

		// Token: 0x04000248 RID: 584
		[SerializeField]
		[ReadOnlyUI]
		private PuppetColliderToConvex m_HipsCollider;

		// Token: 0x04000249 RID: 585
		private PuppetMaster m_puppet;

		// Token: 0x0400024A RID: 586
		private Animator m_Animator;

		// Token: 0x0400024B RID: 587
		[SerializeField]
		private int m_Layer;

		// Token: 0x0400024C RID: 588
		public GenericReconfigurableJoint.Configuracion jointConfig = new GenericReconfigurableJoint.Configuracion
		{
			jointAnglesAdmin = new JointAnglesAdmin.Configuracion
			{
				highAngularXLimit = 45f,
				lowAngularXLimit = -45f,
				angularYLimit = 45f,
				angularZLimit = -45f
			},
			jointAxisAdmin = new JointAxisAdmin.Configuracion
			{
				localUpAxis = Vector3.left
			},
			jointBodyAdmin = new JointBodyAdmin.Configuracion
			{
				isInverted = true,
				ownRigidIsKinematic = true,
				solverIterations = 12,
				solverVelocityIterations = 2,
				useGravity = false
			},
			jointDistancesAdmin = new JointDistancesAdmin.Configuracion
			{
				invertirConnectedAnchorPorAnchor = true
			},
			jointDrivesAdminV2 = new JointDrivesAdminV2.Configuracion
			{
				isInverted = true,
				xAngularDrive = new JointDriveConfiguration(65f, 0f),
				yzAngularDrive = new JointDriveConfiguration(65f, 0f),
				xDrive = new JointDriveConfiguration(3000f, 0f),
				yDrive = new JointDriveConfiguration(3000f, 0f),
				zDrive = new JointDriveConfiguration(3000f, 0f)
			},
			jointMotionsAdmin = new JointMotionsAdmin.Configuracion
			{
				angularXMotion = ConfigurableJointMotion.Limited,
				angularYMotion = ConfigurableJointMotion.Limited,
				angularZMotion = ConfigurableJointMotion.Limited,
				xMotion = ConfigurableJointMotion.Limited,
				yMotion = ConfigurableJointMotion.Limited,
				zMotion = ConfigurableJointMotion.Limited
			}
		};
	}
}
