using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000179 RID: 377
	public class TValleBodyTilt : OffsetModifier
	{
		// Token: 0x06000826 RID: 2086 RVA: 0x0002AE8C File Offset: 0x0002908C
		protected override void Start()
		{
			base.Start();
			if (this.ik == null)
			{
				throw new ArgumentNullException("ik", "ik null reference.");
			}
			this.lastForward = base.transform.forward;
			this.lastPosition = base.transform.position;
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x0002AEE0 File Offset: 0x000290E0
		protected override void OnModifyOffset()
		{
			Quaternion quaternion = Quaternion.FromToRotation(this.lastForward, base.transform.forward);
			this.m_currentVelocity = (base.transform.position - this.lastPosition).magnitude / base.deltaTime;
			float num;
			Vector3 vector;
			quaternion.ToAngleAxis(out num, out vector);
			if (vector.y > 0f)
			{
				num = -num;
			}
			num *= this.tiltSensitivity * 0.01f;
			num *= Mathf.InverseLerp(this.minSpeed, this.maxSpeed, this.m_currentVelocity);
			num /= base.deltaTime;
			num = Mathf.Clamp(num, -1f, 1f);
			this.tiltAngle = Mathf.Lerp(this.tiltAngle, num, base.deltaTime * this.tiltSpeed);
			float num2 = Mathf.Abs(this.tiltAngle) / 1f;
			if (this.tiltAngle < 0f)
			{
				this.poseRight.Apply(this.ik.solver, num2);
			}
			else
			{
				this.poseLeft.Apply(this.ik.solver, num2);
			}
			this.lastForward = base.transform.forward;
			this.lastPosition = base.transform.position;
		}

		// Token: 0x04000682 RID: 1666
		[Tooltip("Speed of tilting")]
		public float tiltSpeed = 6f;

		// Token: 0x04000683 RID: 1667
		[Tooltip("Sensitivity of tilting")]
		public float tiltSensitivity = 0.5f;

		// Token: 0x04000684 RID: 1668
		public float minSpeed;

		// Token: 0x04000685 RID: 1669
		public float maxSpeed = 2f;

		// Token: 0x04000686 RID: 1670
		[Tooltip("The OffsetPose components")]
		public TValleOffsetPose poseLeft;

		// Token: 0x04000687 RID: 1671
		[Tooltip("The OffsetPose components")]
		public TValleOffsetPose poseRight;

		// Token: 0x04000688 RID: 1672
		private float tiltAngle;

		// Token: 0x04000689 RID: 1673
		private Vector3 lastForward;

		// Token: 0x0400068A RID: 1674
		private Vector3 lastPosition;

		// Token: 0x0400068B RID: 1675
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentVelocity;
	}
}
