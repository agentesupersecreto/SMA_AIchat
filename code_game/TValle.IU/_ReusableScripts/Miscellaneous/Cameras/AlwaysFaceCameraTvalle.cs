using System;
using UnityEngine;

namespace Assets._ReusableScripts.Miscellaneous.Cameras
{
	// Token: 0x020000C1 RID: 193
	public class AlwaysFaceCameraTvalle : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x0600056A RID: 1386 RVA: 0x00014F13 File Offset: 0x00013113
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x00014F16 File Offset: 0x00013116
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.myTransform = base.transform;
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x00014F2C File Offset: 0x0001312C
		public override void OnUpdateEvent1()
		{
			if (this.m_mainCamera == null)
			{
				this.m_mainCamera = Camera.main;
				if (this.m_mainCamera == null)
				{
					return;
				}
			}
			if (this.myTransform != null && this.m_mainCamera != null)
			{
				if (this.yAxisOnly)
				{
					Vector3 vector = new Vector3(this.m_mainCamera.transform.position.x, this.myTransform.position.y, this.m_mainCamera.transform.position.z);
					this.myTransform.LookAt(this.myTransform.position - vector);
					return;
				}
				this.myTransform.rotation = Quaternion.LookRotation(this.myTransform.position - this.m_mainCamera.transform.position);
			}
		}

		// Token: 0x04000212 RID: 530
		public bool yAxisOnly;

		// Token: 0x04000213 RID: 531
		private Transform myTransform;

		// Token: 0x04000214 RID: 532
		[SerializeField]
		private Camera m_mainCamera;
	}
}
