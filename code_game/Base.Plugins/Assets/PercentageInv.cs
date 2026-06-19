using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000131 RID: 305
	[Serializable]
	public struct PercentageInv
	{
		// Token: 0x06000892 RID: 2194 RVA: 0x0001C8D4 File Offset: 0x0001AAD4
		public PercentageInv(float value)
		{
			this.m_valueInv = -value;
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000893 RID: 2195 RVA: 0x0001C8DE File Offset: 0x0001AADE
		private float m_value
		{
			get
			{
				return -this.m_valueInv;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000894 RID: 2196 RVA: 0x0001C8E7 File Offset: 0x0001AAE7
		public float value
		{
			get
			{
				if (this.m_value < 0f)
				{
					return 0f;
				}
				if (this.m_value > 100f)
				{
					return 100f;
				}
				return this.m_value;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000895 RID: 2197 RVA: 0x0001C915 File Offset: 0x0001AB15
		public float mod
		{
			get
			{
				return this.value / 100f;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000896 RID: 2198 RVA: 0x0001C923 File Offset: 0x0001AB23
		public float total
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0001C92B File Offset: 0x0001AB2B
		public static implicit operator PercentageInv(float d)
		{
			return new PercentageInv(d);
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x0001C933 File Offset: 0x0001AB33
		public static implicit operator PercentageInv(int d)
		{
			return new PercentageInv((float)d);
		}

		// Token: 0x04000235 RID: 565
		[SerializeField]
		private float m_valueInv;
	}
}
