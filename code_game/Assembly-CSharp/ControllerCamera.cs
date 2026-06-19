using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class ControllerCamera : MonoBehaviour
{
	// Token: 0x06000004 RID: 4 RVA: 0x0000221C File Offset: 0x0000041C
	private void Start()
	{
		this.camLookOffset.x = this.cameraTarget.transform.localPosition.x;
		this.camLookOffset.y = this.cameraTarget.transform.localPosition.y;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x0000226C File Offset: 0x0000046C
	private void LateUpdate()
	{
		if (this.setCamera == null)
		{
			this.setCamera = Camera.main.transform;
		}
		if (Input.mousePosition.x > 365f && Input.mousePosition.y < 648f && Input.mousePosition.y > 50f)
		{
			if (Input.GetMouseButton(0))
			{
				this.MouseRotationDistance = Input.GetAxisRaw("Mouse X") * 2.7f;
				this.MouseVerticalDistance = Input.GetAxisRaw("Mouse Y") * 2.7f;
			}
			else
			{
				this.MouseRotationDistance = 0f;
				this.MouseVerticalDistance = 0f;
			}
			this.MouseScrollDistance = Input.GetAxisRaw("Mouse ScrollWheel");
			if (Input.GetMouseButton(2))
			{
				this.camLookOffset.x = this.camLookOffset.x + Input.GetAxisRaw("Mouse X") * 0.001f;
				this.camLookOffset.y = this.camLookOffset.y + Input.GetAxisRaw("Mouse Y") * 0.001f;
			}
		}
		else
		{
			this.MouseRotationDistance = 0f;
			this.MouseVerticalDistance = 0f;
		}
		this.followHeight = 1.5f;
		Vector3 vector = new Vector3(this.cameraTarget.transform.eulerAngles.x - this.MouseVerticalDistance, this.cameraTarget.transform.eulerAngles.y - this.MouseRotationDistance, this.cameraTarget.transform.eulerAngles.z);
		this.cameraTarget.transform.eulerAngles = vector;
		Vector3 vector2 = new Vector3(this.camLookOffset.x, this.camLookOffset.y, this.cameraTarget.transform.localPosition.z);
		this.cameraTarget.transform.localPosition = vector2;
		Vector3 vector3 = new Vector3(this.setCamera.localPosition.x, this.setCamera.localPosition.y, Mathf.Clamp(this.setCamera.localPosition.z, -9.73f, -9.66f));
		this.setCamera.localPosition = vector3;
		if (this.setCamera.localPosition.z >= -9.73f && this.setCamera.localPosition.z <= -9.66f && this.MouseScrollDistance != 0f)
		{
			this.setCamera.transform.Translate(-Vector3.forward * this.MouseScrollDistance * 0.02f, base.transform);
		}
	}

	// Token: 0x0400000F RID: 15
	public Transform setCamera;

	// Token: 0x04000010 RID: 16
	public Transform cameraTarget;

	// Token: 0x04000011 RID: 17
	public float followDistance = 5f;

	// Token: 0x04000012 RID: 18
	public float followHeight = 1f;

	// Token: 0x04000013 RID: 19
	public float followSensitivity = 2f;

	// Token: 0x04000014 RID: 20
	public bool useRaycast = true;

	// Token: 0x04000015 RID: 21
	public Vector2 axisSensitivity = new Vector2(4f, 4f);

	// Token: 0x04000016 RID: 22
	public float camFOV = 35f;

	// Token: 0x04000017 RID: 23
	public float camRotation;

	// Token: 0x04000018 RID: 24
	public float camHeight;

	// Token: 0x04000019 RID: 25
	public float camYDamp;

	// Token: 0x0400001A RID: 26
	public Vector2 camLookOffset = new Vector2(0f, 0f);

	// Token: 0x0400001B RID: 27
	private float MouseRotationDistance;

	// Token: 0x0400001C RID: 28
	private float MouseVerticalDistance;

	// Token: 0x0400001D RID: 29
	private float MouseScrollDistance;
}
