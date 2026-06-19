using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class EyeAdv_AutoDilation : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void Start()
	{
		this.eyeRenderer = base.gameObject.GetComponent<Renderer>();
		if (this.sceneLightObject != null)
		{
			this.sceneLight = this.sceneLightObject.GetComponent<Light>();
		}
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002084 File Offset: 0x00000284
	private void LateUpdate()
	{
		if (this.sceneLight != null)
		{
			this.lightIntensity = this.sceneLight.intensity;
			if (this.enableAutoDilation)
			{
				if (this.currTargetDilation != this.targetDilation || this.currLightSensitivity != this.lightSensitivity)
				{
					this.dilateTime = 0f;
					this.currTargetDilation = this.targetDilation;
					this.currLightSensitivity = this.lightSensitivity;
				}
				this.lightAngle = Vector3.Angle(this.sceneLightObject.transform.forward, base.transform.forward) / 180f;
				this.targetDilation = Mathf.Lerp(1f, 0f, this.lightAngle * this.lightIntensity * this.lightSensitivity);
				this.dilateTime += Time.deltaTime * this.dilationSpeed;
				this.pupilDilation = Mathf.Clamp(this.pupilDilation, 0f, this.maxDilation);
				this.pupilDilation = Mathf.Lerp(this.pupilDilation, this.targetDilation, this.dilateTime);
				this.eyeRenderer.sharedMaterial.SetFloat("_pupilSize", this.pupilDilation);
			}
		}
	}

	// Token: 0x04000001 RID: 1
	public bool enableAutoDilation = true;

	// Token: 0x04000002 RID: 2
	public Transform sceneLightObject;

	// Token: 0x04000003 RID: 3
	public float lightSensitivity = 1f;

	// Token: 0x04000004 RID: 4
	public float dilationSpeed = 0.1f;

	// Token: 0x04000005 RID: 5
	public float maxDilation = 1f;

	// Token: 0x04000006 RID: 6
	private Light sceneLight;

	// Token: 0x04000007 RID: 7
	private float lightIntensity;

	// Token: 0x04000008 RID: 8
	private float lightAngle;

	// Token: 0x04000009 RID: 9
	private float dilateTime;

	// Token: 0x0400000A RID: 10
	private float pupilDilation = 0.5f;

	// Token: 0x0400000B RID: 11
	private float currTargetDilation = -1f;

	// Token: 0x0400000C RID: 12
	private float targetDilation;

	// Token: 0x0400000D RID: 13
	private float currLightSensitivity = -1f;

	// Token: 0x0400000E RID: 14
	private Renderer eyeRenderer;
}
