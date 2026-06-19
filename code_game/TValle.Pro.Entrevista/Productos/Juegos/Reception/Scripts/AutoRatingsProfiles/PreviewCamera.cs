using System;
using TValleCustomClases;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles
{
	// Token: 0x0200001D RID: 29
	[RequireComponent(typeof(Camera))]
	public class PreviewCamera : CustomMonobehaviour
	{
		// Token: 0x06000120 RID: 288 RVA: 0x00006B65 File Offset: 0x00004D65
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Camera = base.GetComponent<Camera>();
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00006B79 File Offset: 0x00004D79
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_Camera.enabled = false;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00006B8D File Offset: 0x00004D8D
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			RenderPipelineManager.endCameraRendering += this.RenderPipelineManager_endCameraRendering;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00006BA6 File Offset: 0x00004DA6
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			RenderPipelineManager.endCameraRendering -= this.RenderPipelineManager_endCameraRendering;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00006BC0 File Offset: 0x00004DC0
		private void RenderPipelineManager_endCameraRendering(ScriptableRenderContext arg1, Camera arg2)
		{
			try
			{
				if (this.m_flagRenderAFrame)
				{
					base.CancelInvoke("EnableCamera");
					base.Invoke("EnableCamera", this.delay);
					this.m_coolDown.ApplyNext(this.duration);
				}
				else if (!this.m_coolDown.isOn)
				{
					this.m_Camera.enabled = false;
				}
			}
			finally
			{
				this.m_flagRenderAFrame = false;
			}
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00006C38 File Offset: 0x00004E38
		private void EnableCamera()
		{
			this.m_Camera.enabled = true;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00006C46 File Offset: 0x00004E46
		public void TakeFrame()
		{
			this.m_flagRenderAFrame = true;
		}

		// Token: 0x040000B2 RID: 178
		private Camera m_Camera;

		// Token: 0x040000B3 RID: 179
		private CoolDown m_coolDown = new CoolDown();

		// Token: 0x040000B4 RID: 180
		[SerializeField]
		private bool m_flagRenderAFrame;

		// Token: 0x040000B5 RID: 181
		public float delay = 0.1f;

		// Token: 0x040000B6 RID: 182
		public float duration = 1f;
	}
}
