using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000143 RID: 323
	public class SmoothFloatsV2
	{
		// Token: 0x060009A9 RID: 2473 RVA: 0x0001FA90 File Offset: 0x0001DC90
		public SmoothFloatsV2(float time, float initialValue = 0f)
		{
			this.m_timeToReach = Mathf.Clamp(time, 1E-05f, float.MaxValue);
			this.m_currentVal = initialValue;
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x060009AA RID: 2474 RVA: 0x0001FAB5 File Offset: 0x0001DCB5
		public float suavizado
		{
			get
			{
				return this.m_currentVal;
			}
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x0001FABD File Offset: 0x0001DCBD
		public void Add(float item)
		{
			this.m_lastframe = Time.frameCount;
			this.m_currentVal = Mathf.Lerp(this.m_currentVal, item, Time.deltaTime / this.m_timeToReach);
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x0001FAE8 File Offset: 0x0001DCE8
		public void Update()
		{
			if (this.m_lastframe == Time.frameCount)
			{
				return;
			}
			this.m_currentVal = Mathf.Lerp(this.m_currentVal, 0f, Time.deltaTime / this.m_timeToReach);
		}

		// Token: 0x04000261 RID: 609
		private float m_timeToReach;

		// Token: 0x04000262 RID: 610
		private float m_currentVal;

		// Token: 0x04000263 RID: 611
		private int m_lastframe;
	}
}
