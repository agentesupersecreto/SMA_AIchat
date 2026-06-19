using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000FD RID: 253
	public static class ConfigurableJointExtensions
	{
		// Token: 0x06000AD3 RID: 2771 RVA: 0x000240C2 File Offset: 0x000222C2
		public static void SetTargetRotationLocal(this ConfigurableJoint joint, Quaternion targetLocalRotation, Quaternion startLocalRotation)
		{
			if (joint.configuredInWorldSpace)
			{
				Debug.LogError("SetTargetRotationLocal should not be used with joints that are configured in world space. For world space joints, use SetTargetRotation.", joint);
			}
			ConfigurableJointExtensions.SetTargetRotationInternal(joint, targetLocalRotation, startLocalRotation, Space.Self);
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x000240E0 File Offset: 0x000222E0
		public static void SetTargetRotation(this ConfigurableJoint joint, Quaternion targetWorldRotation, Quaternion startWorldRotation)
		{
			if (!joint.configuredInWorldSpace)
			{
				Debug.LogError("SetTargetRotation must be used with joints that are configured in world space. For local space joints, use SetTargetRotationLocal.", joint);
			}
			ConfigurableJointExtensions.SetTargetRotationInternal(joint, targetWorldRotation, startWorldRotation, Space.World);
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x00024100 File Offset: 0x00022300
		private static void SetTargetRotationInternal(ConfigurableJoint joint, Quaternion targetRotation, Quaternion startRotation, Space space)
		{
			Vector3 axis = joint.axis;
			Vector3 normalized = Vector3.Cross(joint.axis, joint.secondaryAxis).normalized;
			Vector3 normalized2 = Vector3.Cross(normalized, axis).normalized;
			Quaternion quaternion = Quaternion.LookRotation(normalized, normalized2);
			Quaternion quaternion2 = Quaternion.Inverse(quaternion);
			if (space == Space.World)
			{
				quaternion2 *= startRotation * Quaternion.Inverse(targetRotation);
			}
			else
			{
				quaternion2 *= Quaternion.Inverse(targetRotation) * startRotation;
			}
			quaternion2 *= quaternion;
			joint.targetRotation = quaternion2;
		}
	}
}
