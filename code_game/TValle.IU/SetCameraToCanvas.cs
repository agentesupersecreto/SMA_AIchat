using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
[RequireComponent(typeof(Canvas))]
public class SetCameraToCanvas : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void Start()
	{
		this.m_canvas = base.GetComponent<Canvas>();
	}

	// Token: 0x06000002 RID: 2 RVA: 0x0000205E File Offset: 0x0000025E
	private void Update()
	{
		if (this.m_canvas.worldCamera != this.cameraToSetToCanvas)
		{
			this.m_canvas.worldCamera = this.cameraToSetToCanvas;
		}
	}

	// Token: 0x04000001 RID: 1
	private Canvas m_canvas;

	// Token: 0x04000002 RID: 2
	public Camera cameraToSetToCanvas;
}
