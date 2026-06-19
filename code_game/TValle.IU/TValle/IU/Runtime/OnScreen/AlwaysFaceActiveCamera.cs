using System;
using Assets.Base.Globales.Runtime.Cameras;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.OnScreen
{
	// Token: 0x020000CD RID: 205
	public class AlwaysFaceActiveCamera : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x060005C3 RID: 1475 RVA: 0x0001603D File Offset: 0x0001423D
		public override int updateEvent1Index
		{
			get
			{
				return 42;
			}
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x00016041 File Offset: 0x00014241
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.myTransform = base.transform;
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x00016058 File Offset: 0x00014258
		public override void OnUpdateEvent1()
		{
			Camera currentActivedCamera = Singleton<GameActiveCamerasController>.instance.currentActivedCamera;
			if (this.myTransform != null && currentActivedCamera != null)
			{
				if (this.yAxisOnly)
				{
					Vector3 vector = new Vector3(currentActivedCamera.transform.position.x, this.myTransform.position.y, currentActivedCamera.transform.position.z);
					this.myTransform.LookAt(this.myTransform.position - vector);
					return;
				}
				this.myTransform.rotation = Quaternion.LookRotation(this.myTransform.position - currentActivedCamera.transform.position);
			}
		}

		// Token: 0x04000237 RID: 567
		public bool yAxisOnly;

		// Token: 0x04000238 RID: 568
		private Transform myTransform;
	}
}
