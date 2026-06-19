using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.BeachGirl.Runtime.XRays
{
	// Token: 0x02000057 RID: 87
	public abstract class XRayUI : CustomMonobehaviour
	{
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000189 RID: 393 RVA: 0x00003330 File Offset: 0x00001530
		public Image blockedImage
		{
			get
			{
				return this.m_blockedImage;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600018A RID: 394 RVA: 0x00003338 File Offset: 0x00001538
		public RawImage xRayImage
		{
			get
			{
				return this.m_xRayImage;
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00003340 File Offset: 0x00001540
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_blockedImage == null)
			{
				throw new ArgumentNullException("m_blockedImage", "m_blockedImage null reference.");
			}
			if (this.m_xRayImage == null)
			{
				throw new ArgumentNullException("m_xRayImage", "m_xRayImage null reference.");
			}
		}

		// Token: 0x040000FB RID: 251
		[SerializeField]
		private Image m_blockedImage;

		// Token: 0x040000FC RID: 252
		[SerializeField]
		private RawImage m_xRayImage;
	}
}
