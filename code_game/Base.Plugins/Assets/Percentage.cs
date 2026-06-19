using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000130 RID: 304
	[Serializable]
	public struct Percentage
	{
		// Token: 0x0600088C RID: 2188 RVA: 0x0001C876 File Offset: 0x0001AA76
		public Percentage(float value)
		{
			this.m_value = value;
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x0600088D RID: 2189 RVA: 0x0001C87F File Offset: 0x0001AA7F
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

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x0600088E RID: 2190 RVA: 0x0001C8AD File Offset: 0x0001AAAD
		public float mod
		{
			get
			{
				return this.value / 100f;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x0600088F RID: 2191 RVA: 0x0001C8BB File Offset: 0x0001AABB
		public float total
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x0001C8C3 File Offset: 0x0001AAC3
		public static implicit operator Percentage(float d)
		{
			return new Percentage(d);
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x0001C8CB File Offset: 0x0001AACB
		public static implicit operator Percentage(int d)
		{
			return new Percentage((float)d);
		}

		// Token: 0x04000234 RID: 564
		[SerializeField]
		private float m_value;
	}
}
