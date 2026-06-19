using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.TavoBehaviours
{
	// Token: 0x02000007 RID: 7
	[Obsolete]
	[RequireComponent(typeof(Camera))]
	public class UICamera : Singleton<UICamera>
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000029CA File Offset: 0x00000BCA
		public static Camera camera
		{
			get
			{
				return Singleton<UICamera>.instance.m_camera;
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000029D6 File Offset: 0x00000BD6
		protected override void InitData(bool esEditorTime)
		{
			this.m_camera = base.GetComponent<Camera>();
			if (this.m_camera == null)
			{
				throw new ArgumentNullException("m_camera", "m_camera null reference.");
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002A04 File Offset: 0x00000C04
		private void Start()
		{
			if (this.m_mainCamera == null)
			{
				this.m_mainCamera = Camera.main;
				if (this.m_mainCamera == null)
				{
					this.m_mainCamera = base.GetComponentInParent<Camera>();
				}
				if (this.m_mainCamera == null)
				{
					throw new ArgumentNullException("m_mainCamera", "m_mainCamera null reference.");
				}
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002A64 File Offset: 0x00000C64
		private void OnPreCull()
		{
			if (Application.isEditor && this.m_mainCamera.cullingMask.IsAnyFlagSet(this.m_camera.cullingMask))
			{
				Debug.LogError("Camara de UI esta dibujando lo mismo q camara principal, corregir camera principal", this);
			}
			Transform transform = this.m_mainCamera.transform;
			this.m_camera.transform.SetPositionAndRotation(transform.position, transform.rotation);
			this.m_camera.fieldOfView = this.m_mainCamera.fieldOfView;
		}

		// Token: 0x04000021 RID: 33
		private Camera m_camera;

		// Token: 0x04000022 RID: 34
		[SerializeField]
		private Camera m_mainCamera;
	}
}
