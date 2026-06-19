using System;
using UnityEngine;

namespace com.ootii.Actors
{
	// Token: 0x02000093 RID: 147
	public class BasicController : MonoBehaviour
	{
		// Token: 0x06000846 RID: 2118 RVA: 0x0002C2A6 File Offset: 0x0002A4A6
		public void Awake()
		{
			this.mTransform = base.gameObject.transform;
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x0002C2BC File Offset: 0x0002A4BC
		public void Update()
		{
			if (this.RotationEnabled)
			{
				float num = (Input.GetKey(KeyCode.E) ? 1f : 0f);
				num -= (Input.GetKey(KeyCode.Q) ? 1f : 0f);
				if (num != 0f)
				{
					this.mTransform.rotation = this.mTransform.rotation * Quaternion.AngleAxis(num * this.RotationSpeed * Time.deltaTime, Vector3.up);
				}
			}
			Vector3 vector = Vector3.zero;
			vector.z = ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) ? 1f : 0f);
			vector.z -= ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) ? 1f : 0f);
			vector.x = ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) ? 1f : 0f);
			vector.x -= ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) ? 1f : 0f);
			if (this.UseGamepad && vector.x == 0f && vector.z == 0f)
			{
				vector.z = Input.GetAxis("Vertical");
				vector.x = Input.GetAxis("Horizontal");
			}
			if (this.RotateToInput && this.Camera != null && vector.sqrMagnitude > 0f)
			{
				Quaternion quaternion = Quaternion.Euler(0f, this.Camera.rotation.eulerAngles.y, 0f);
				this.mTransform.rotation = Quaternion.LookRotation(quaternion * vector, Vector3.up);
				vector.z = vector.magnitude;
				vector.x = 0f;
			}
			if (vector.magnitude >= 1f)
			{
				vector.Normalize();
			}
			if (this.MovementRelative)
			{
				vector = this.mTransform.rotation * vector;
			}
			this.mTransform.position = this.mTransform.position + vector * (this.MovementSpeed * Time.deltaTime);
		}

		// Token: 0x04000445 RID: 1093
		public Transform Camera;

		// Token: 0x04000446 RID: 1094
		public bool UseGamepad;

		// Token: 0x04000447 RID: 1095
		public bool MovementRelative = true;

		// Token: 0x04000448 RID: 1096
		public float MovementSpeed = 3f;

		// Token: 0x04000449 RID: 1097
		public bool RotationEnabled = true;

		// Token: 0x0400044A RID: 1098
		public bool RotateToInput;

		// Token: 0x0400044B RID: 1099
		public float RotationSpeed = 180f;

		// Token: 0x0400044C RID: 1100
		protected Transform mTransform;
	}
}
