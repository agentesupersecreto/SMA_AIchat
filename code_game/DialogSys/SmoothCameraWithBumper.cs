using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200003D RID: 61
	[AddComponentMenu("Dialogue System/Actor/Player/Smooth Camera With Bumper (community)")]
	public class SmoothCameraWithBumper : MonoBehaviour
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x00009A4E File Offset: 0x00007C4E
		// (set) Token: 0x060001D1 RID: 465 RVA: 0x00009A56 File Offset: 0x00007C56
		public Quaternion adjustQuaternion { get; set; }

		// Token: 0x060001D2 RID: 466 RVA: 0x00009A60 File Offset: 0x00007C60
		private void Awake()
		{
			Camera component = base.GetComponent<Camera>();
			if (component != null)
			{
				component.transform.parent = this.target;
			}
			this.adjustQuaternion = Quaternion.identity;
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00009A99 File Offset: 0x00007C99
		private void Start()
		{
			this.originalRotation = base.transform.localRotation;
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00009AAC File Offset: 0x00007CAC
		private void FixedUpdate()
		{
			Vector3 vector = this.target.TransformPoint(0f, this.height, -this.distance);
			Vector3 vector2 = this.target.transform.TransformDirection(-1f * Vector3.forward);
			RaycastHit raycastHit;
			if (Physics.Raycast(this.target.TransformPoint(this.bumperRayOffset), vector2, out raycastHit, this.bumperDistanceCheck) && raycastHit.transform != this.target)
			{
				vector.x = raycastHit.point.x;
				vector.z = raycastHit.point.z;
				vector.y = Mathf.Lerp(raycastHit.point.y + this.bumperCameraHeight, vector.y, Time.deltaTime * this.damping);
			}
			base.transform.position = Vector3.Lerp(base.transform.position, vector, Time.deltaTime * this.damping);
			Vector3 vector3 = this.target.TransformPoint(this.targetLookAtOffset);
			if (this.smoothRotation)
			{
				Quaternion quaternion = Quaternion.LookRotation(vector3 - base.transform.position, this.target.up);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, quaternion, Time.deltaTime * this.rotationDamping);
			}
			else
			{
				base.transform.rotation = Quaternion.LookRotation(vector3 - base.transform.position, this.target.up);
			}
			base.transform.localRotation = this.originalRotation * this.adjustQuaternion;
		}

		// Token: 0x0400014D RID: 333
		public Transform target;

		// Token: 0x0400014E RID: 334
		[SerializeField]
		private float distance = 3f;

		// Token: 0x0400014F RID: 335
		[SerializeField]
		private float height = 1f;

		// Token: 0x04000150 RID: 336
		[SerializeField]
		private float damping = 5f;

		// Token: 0x04000151 RID: 337
		[SerializeField]
		private bool smoothRotation = true;

		// Token: 0x04000152 RID: 338
		[SerializeField]
		private float rotationDamping = 10f;

		// Token: 0x04000153 RID: 339
		[SerializeField]
		private Vector3 targetLookAtOffset = Vector3.zero;

		// Token: 0x04000154 RID: 340
		[SerializeField]
		private float bumperDistanceCheck = 2.5f;

		// Token: 0x04000155 RID: 341
		[SerializeField]
		private float bumperCameraHeight = 1f;

		// Token: 0x04000156 RID: 342
		[SerializeField]
		private Vector3 bumperRayOffset = Vector3.zero;

		// Token: 0x04000158 RID: 344
		private Quaternion originalRotation;
	}
}
