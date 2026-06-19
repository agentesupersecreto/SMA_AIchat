using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Testing.PhyscisAnus
{
	// Token: 0x02000015 RID: 21
	[ExecuteInEditMode]
	public class CalculeAndShowJointAxis : MonoBehaviour
	{
		// Token: 0x06000083 RID: 131 RVA: 0x00003E78 File Offset: 0x00002078
		private void Update()
		{
			if (this.calcule && this.target != null)
			{
				this.calcule = false;
				Vector3 forward = base.transform.forward;
				Vector3 normalized = (this.target.position - base.transform.position).normalized;
				Vector3 vector = Vector3.Cross(forward, normalized);
				Debug.DrawRay(base.transform.position, forward, Color.green, 1f, false);
				Debug.DrawRay(base.transform.position, normalized, Color.blue, 1f, false);
				Debug.DrawRay(base.transform.position, vector, Color.red, 1f, false);
				this.resultForward = base.transform.InverseTransformDirection(normalized);
				this.resultUp = Vector3.forward;
				this.resultRight = Vector3.Cross(this.resultUp, this.resultForward);
				this.resultUp = Vector3.Cross(this.resultForward, this.resultRight);
				if (this.joint != null)
				{
					this.joint.axis = this.resultRight;
					this.joint.secondaryAxis = this.resultUp;
				}
			}
		}

		// Token: 0x0400006B RID: 107
		public Transform target;

		// Token: 0x0400006C RID: 108
		public ConfigurableJoint joint;

		// Token: 0x0400006D RID: 109
		public bool calcule;

		// Token: 0x0400006E RID: 110
		public Vector3 resultRight;

		// Token: 0x0400006F RID: 111
		public Vector3 resultUp;

		// Token: 0x04000070 RID: 112
		public Vector3 resultForward;
	}
}
