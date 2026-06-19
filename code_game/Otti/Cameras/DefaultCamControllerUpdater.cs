using System;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x02000088 RID: 136
	[RequireComponent(typeof(BaseCameraRig))]
	public class DefaultCamControllerUpdater : MonoBehaviour, ITValleCamControllerUpdater
	{
		// Token: 0x060006FE RID: 1790 RVA: 0x00025885 File Offset: 0x00023A85
		private void Awake()
		{
			this.m_Controller = base.GetComponent<BaseCameraRig>();
			if (this.m_Controller == null)
			{
				throw new ArgumentNullException("m_Controller", "m_Controller null reference.");
			}
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x000258B1 File Offset: 0x00023AB1
		public void FixedUpdate()
		{
			if (this.m_Controller.enabled)
			{
				this.m_Controller.FixedUpdateCamera();
			}
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x000258CB File Offset: 0x00023ACB
		public void LateUpdate()
		{
			if (this.m_Controller.enabled)
			{
				this.m_Controller.LateUpdateCamera();
			}
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x000258E5 File Offset: 0x00023AE5
		public void Update()
		{
			if (this.m_Controller.enabled)
			{
				this.m_Controller.UpdateCamera();
			}
		}

		// Token: 0x04000366 RID: 870
		private BaseCameraRig m_Controller;
	}
}
