using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000007 RID: 7
	public static class MuscleUtilities
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000022EC File Offset: 0x000004EC
		public static ConfigurableJoint GenerateFollowerJoint(this Muscle muscle, Transform jointParent)
		{
			Transform transform = muscle.rigidbody.transform;
			Transform target = muscle.target;
			Vector3 position = transform.position;
			Quaternion rotation = transform.rotation;
			Transform transform2 = jointParent.CreateChild(muscle.name);
			transform2.SetPositionAndRotation(target.position, target.rotation);
			Rigidbody rigidbody = transform2.gameObject.AddComponent<Rigidbody>();
			rigidbody.isKinematic = true;
			transform.SetPositionAndRotation(target.position, target.rotation);
			ConfigurableJoint configurableJoint = rigidbody.gameObject.AddComponent<ConfigurableJoint>();
			configurableJoint.autoConfigureConnectedAnchor = false;
			configurableJoint.anchor = (configurableJoint.connectedAnchor = Vector3.zero);
			configurableJoint.projectionMode = JointProjectionMode.PositionAndRotation;
			configurableJoint.xMotion = ConfigurableJointMotion.Free;
			configurableJoint.yMotion = ConfigurableJointMotion.Free;
			configurableJoint.zMotion = ConfigurableJointMotion.Free;
			configurableJoint.angularXMotion = ConfigurableJointMotion.Free;
			configurableJoint.angularYMotion = ConfigurableJointMotion.Free;
			configurableJoint.angularZMotion = ConfigurableJointMotion.Free;
			configurableJoint.connectedBody = muscle.rigidbody;
			transform.SetPositionAndRotation(position, rotation);
			return configurableJoint;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000023C8 File Offset: 0x000005C8
		public static void UpdateDrivers(this ConfigurableJoint joint, bool usarDamp, Muscle muscle, float currentValue, float deltaTime, bool lockIfMax, ref float currentForceVelocity, float targetJointForce, float maxJointForce, float timeMod = 1f)
		{
			float num = maxJointForce * muscle.rigidbody.mass;
			float num2 = targetJointForce * muscle.rigidbody.mass;
			JointDrive jointDrive = default(JointDrive);
			float num3;
			if (usarDamp)
			{
				num3 = Mathf.SmoothDamp(currentValue, num2, ref currentForceVelocity, 3f * timeMod, float.MaxValue, deltaTime);
			}
			else
			{
				num3 = Mathf.MoveTowards(currentValue, num2, deltaTime * 0.25f * num * (1f / timeMod));
			}
			jointDrive.positionSpring = num3;
			jointDrive.positionDamper = num3 * 0.002f;
			jointDrive.maximumForce = 3.402823E+38f;
			joint.xDrive = jointDrive;
			joint.yDrive = jointDrive;
			joint.zDrive = jointDrive;
			if (lockIfMax && num.AlmostEqualV2(num3, num * 0.01f))
			{
				joint.xMotion = ConfigurableJointMotion.Locked;
				joint.yMotion = ConfigurableJointMotion.Locked;
				joint.zMotion = ConfigurableJointMotion.Locked;
				return;
			}
			joint.xMotion = ConfigurableJointMotion.Free;
			joint.yMotion = ConfigurableJointMotion.Free;
			joint.zMotion = ConfigurableJointMotion.Free;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000024AC File Offset: 0x000006AC
		public static void UpdateAngularDrivers(this ConfigurableJoint joint, bool usarDamp, Muscle muscle, float currentValue, float deltaTime, bool lockIfMax, ref float currentAngularForceVelocity, float targetJointAngularForce, float maxJointAngularForce, float timeMod = 1f)
		{
			float num = maxJointAngularForce * muscle.rigidbody.mass;
			float num2 = targetJointAngularForce * muscle.rigidbody.mass;
			JointDrive jointDrive = default(JointDrive);
			float num3;
			if (usarDamp)
			{
				num3 = Mathf.SmoothDamp(currentValue, num2, ref currentAngularForceVelocity, 3f * timeMod, float.MaxValue, deltaTime);
			}
			else
			{
				num3 = Mathf.MoveTowards(currentValue, num2, deltaTime * 0.25f * num * (1f / timeMod));
			}
			jointDrive.positionSpring = num3;
			jointDrive.positionDamper = num3 * 0.002f;
			jointDrive.maximumForce = 3.402823E+38f;
			joint.angularXDrive = jointDrive;
			joint.angularYZDrive = jointDrive;
			if (lockIfMax && num.AlmostEqualV2(num3, num * 0.01f))
			{
				joint.angularXMotion = ConfigurableJointMotion.Locked;
				joint.angularYMotion = ConfigurableJointMotion.Locked;
				joint.angularZMotion = ConfigurableJointMotion.Locked;
				return;
			}
			joint.angularXMotion = ConfigurableJointMotion.Free;
			joint.angularYMotion = ConfigurableJointMotion.Free;
			joint.angularZMotion = ConfigurableJointMotion.Free;
		}
	}
}
