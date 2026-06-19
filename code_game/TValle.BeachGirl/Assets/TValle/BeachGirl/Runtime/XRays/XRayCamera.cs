using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.XRays
{
	// Token: 0x02000056 RID: 86
	public abstract class XRayCamera : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000181 RID: 385 RVA: 0x0000311E File Offset: 0x0000131E
		public sealed override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.lateUpdateAfterCameraController);
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00003128 File Offset: 0x00001328
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_camera = base.GetComponentInChildren<Camera>();
			if (this.m_camera == null)
			{
				throw new ArgumentNullException("m_camera", "m_camera null reference.");
			}
			this.m_defaultSize = this.m_camera.orthographicSize;
			this.m_defaultFar = this.m_camera.farClipPlane;
			this.TurnOff();
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000318D File Offset: 0x0000138D
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.TurnOff();
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000319C File Offset: 0x0000139C
		public sealed override void OnUpdateEvent1()
		{
			if (this.target == null)
			{
				this.TurnOff();
				return;
			}
			if (!this.m_camera.gameObject.activeSelf)
			{
				this.m_camera.gameObject.SetActive(true);
			}
			if (!this.m_camera.enabled)
			{
				this.m_camera.enabled = true;
			}
			Vector3 position = this.target.position;
			Quaternion rotation = this.target.rotation;
			Vector3 lossyScale = this.target.lossyScale;
			float num = lossyScale.Escala();
			this.Following(ref position, ref rotation, ref lossyScale, ref num);
			base.transform.SetPositionAndRotation(position, rotation);
			base.transform.localScale = lossyScale;
			float num2 = this.m_defaultSize * num;
			float num3 = this.m_defaultFar * num;
			this.m_camera.orthographicSize = num2;
			this.m_camera.farClipPlane = num3;
			this.m_camera.fieldOfView = 2f * Mathf.Atan(num2 * 0.5f * this.sizeMod / num3) * 57.29578f * this.fovMod;
			this.Followed(num);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000032B8 File Offset: 0x000014B8
		private void TurnOff()
		{
			if (this.m_camera != null)
			{
				this.m_camera.orthographicSize = this.m_defaultSize;
				this.m_camera.farClipPlane = this.m_defaultFar;
				this.m_camera.enabled = false;
				this.m_camera.gameObject.SetActive(false);
			}
		}

		// Token: 0x06000186 RID: 390
		protected abstract void Following(ref Vector3 targetPosition, ref Quaternion targetRotation, ref Vector3 targetScale, ref float targetScaleValue);

		// Token: 0x06000187 RID: 391
		protected abstract void Followed(float targetLossyScaleValue);

		// Token: 0x040000F5 RID: 245
		public Transform target;

		// Token: 0x040000F6 RID: 246
		private Camera m_camera;

		// Token: 0x040000F7 RID: 247
		private float m_defaultSize;

		// Token: 0x040000F8 RID: 248
		private float m_defaultFar;

		// Token: 0x040000F9 RID: 249
		[SerializeField]
		private float sizeMod = 4f;

		// Token: 0x040000FA RID: 250
		[SerializeField]
		private float fovMod = 1f;
	}
}
