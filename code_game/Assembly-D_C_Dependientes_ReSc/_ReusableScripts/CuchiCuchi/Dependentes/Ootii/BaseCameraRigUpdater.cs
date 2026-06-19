using System;
using com.ootii.Cameras;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii
{
	// Token: 0x02000160 RID: 352
	[RequireComponent(typeof(BaseCameraRig))]
	public class BaseCameraRigUpdater : CustomUpdatedMonobehaviourBase, ITValleCamControllerUpdater
	{
		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000755 RID: 1877 RVA: 0x00026E53 File Offset: 0x00025053
		public override int updateEvent1Index
		{
			get
			{
				return 34;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000756 RID: 1878 RVA: 0x00026E57 File Offset: 0x00025057
		public override int updateEvent2Index
		{
			get
			{
				return 38;
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000757 RID: 1879 RVA: 0x00026E5B File Offset: 0x0002505B
		public override int updateEvent3Index
		{
			get
			{
				return 35;
			}
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x00026E5F File Offset: 0x0002505F
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Controller = base.GetComponent<BaseCameraRig>();
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x00026E73 File Offset: 0x00025073
		public override void OnUpdateEvent1()
		{
			if (this.m_Controller.enabled)
			{
				this.m_Controller.UpdateCamera();
			}
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x00026E8D File Offset: 0x0002508D
		public override void OnUpdateEvent2()
		{
			if (this.m_Controller.enabled)
			{
				this.m_Controller.LateUpdateCamera();
			}
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x00026EA7 File Offset: 0x000250A7
		public override void OnUpdateEvent3()
		{
			if (this.m_Controller.enabled)
			{
				this.m_Controller.FixedUpdateCamera();
			}
		}

		// Token: 0x040005D2 RID: 1490
		private BaseCameraRig m_Controller;
	}
}
