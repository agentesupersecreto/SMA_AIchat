using System;
using Assets.Base.CustomMonoBehaviours.Runtime;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Camaras
{
	// Token: 0x020000BC RID: 188
	[RequireComponent(typeof(Camera))]
	public class MainInternalsXRayCamera : InstantiatedSingleton<MainInternalsXRayCamera>
	{
		// Token: 0x060005CD RID: 1485 RVA: 0x00012567 File Offset: 0x00010767
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Camera = base.GetComponent<Camera>();
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x0001257B File Offset: 0x0001077B
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			base.gameObject.SetActive(false);
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x0001258F File Offset: 0x0001078F
		public void OnlyVag()
		{
			this.m_Camera.cullingMask = this.m_onlyVaginaMask;
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x000125A7 File Offset: 0x000107A7
		public void OnlyAnus()
		{
			this.m_Camera.cullingMask = this.m_onlyAnalMask;
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x000125BF File Offset: 0x000107BF
		public void All()
		{
			this.m_Camera.cullingMask = this.m_AllMask;
		}

		// Token: 0x040003BC RID: 956
		[SerializeField]
		private LayerMask m_onlyVaginaMask;

		// Token: 0x040003BD RID: 957
		[SerializeField]
		private LayerMask m_onlyAnalMask;

		// Token: 0x040003BE RID: 958
		[SerializeField]
		private LayerMask m_AllMask;

		// Token: 0x040003BF RID: 959
		private Camera m_Camera;
	}
}
