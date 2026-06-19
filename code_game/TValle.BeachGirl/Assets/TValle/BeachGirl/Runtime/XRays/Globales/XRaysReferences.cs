using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.XRays.Globales
{
	// Token: 0x02000060 RID: 96
	public class XRaysReferences : Singleton<XRaysReferences>
	{
		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060001AF RID: 431 RVA: 0x00003D2A File Offset: 0x00001F2A
		public GameObject pelvisCameraPrefab
		{
			get
			{
				return this.m_pelvisCameraPrefab;
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x00003D32 File Offset: 0x00001F32
		public GameObject bocaCameraPrefab
		{
			get
			{
				return this.m_bocaCameraPrefab;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x00003D3A File Offset: 0x00001F3A
		public XRayBocaUI xRayBocaUI
		{
			get
			{
				return this.m_XRayBocaUI;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x00003D42 File Offset: 0x00001F42
		public XRayPelvisUI xRayPelvisUI
		{
			get
			{
				return this.m_XRayPelvisUI;
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00003D4C File Offset: 0x00001F4C
		protected override void InitData(bool esEditorTime)
		{
			base.InitData(esEditorTime);
			if (this.m_bocaCameraPrefab == null)
			{
				throw new ArgumentNullException("m_bocaCameraPrefab", "m_bocaCameraPrefab null reference.");
			}
			if (this.m_pelvisCameraPrefab == null)
			{
				throw new ArgumentNullException("m_pelvisCameraPrefab", "m_pelvisCameraPrefab null reference.");
			}
			if (this.m_XRayBocaUI == null)
			{
				throw new ArgumentNullException("m_XRayBocaUI", "m_XRayBocaUI null reference.");
			}
			if (this.m_XRayPelvisUI == null)
			{
				throw new ArgumentNullException("m_XRayPelvisUI", "m_XRayPelvisUI null reference.");
			}
		}

		// Token: 0x04000113 RID: 275
		[SerializeField]
		private GameObject m_pelvisCameraPrefab;

		// Token: 0x04000114 RID: 276
		[SerializeField]
		private GameObject m_bocaCameraPrefab;

		// Token: 0x04000115 RID: 277
		[SerializeField]
		private XRayBocaUI m_XRayBocaUI;

		// Token: 0x04000116 RID: 278
		[SerializeField]
		private XRayPelvisUI m_XRayPelvisUI;
	}
}
