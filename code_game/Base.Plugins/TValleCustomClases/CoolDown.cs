using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000052 RID: 82
	[Serializable]
	public class CoolDown
	{
		// Token: 0x0600028A RID: 650 RVA: 0x0000CF4F File Offset: 0x0000B14F
		public CoolDown()
		{
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000CF6D File Offset: 0x0000B16D
		public CoolDown(float defaultTime)
		{
			this.m_default = Mathf.Abs(defaultTime);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000CF98 File Offset: 0x0000B198
		public CoolDown(float defaultTime, float randomMod)
		{
			if (randomMod <= 0f || randomMod >= 1f)
			{
				throw new InvalidOperationException();
			}
			randomMod = Mathf.Abs(randomMod);
			this.m_default = Mathf.Abs(Random.Range(defaultTime - defaultTime * randomMod, defaultTime + defaultTime * randomMod));
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600028D RID: 653 RVA: 0x0000CFF9 File Offset: 0x0000B1F9
		public float @default
		{
			get
			{
				return this.m_default;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600028E RID: 654 RVA: 0x0000D001 File Offset: 0x0000B201
		public bool isOn
		{
			get
			{
				return Time.time - this.m_lastUseTime < this.current;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600028F RID: 655 RVA: 0x0000D018 File Offset: 0x0000B218
		public float left
		{
			get
			{
				float num = this.m_lastUseTime + this.current - Time.time;
				if (num <= 0f)
				{
					return 0f;
				}
				return num;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000290 RID: 656 RVA: 0x0000D048 File Offset: 0x0000B248
		public float current
		{
			get
			{
				return this.m_current.total;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000291 RID: 657 RVA: 0x0000D055 File Offset: 0x0000B255
		public float lastUseTime
		{
			get
			{
				return this.m_lastUseTime;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000292 RID: 658 RVA: 0x0000D05D File Offset: 0x0000B25D
		public float mod
		{
			get
			{
				return 1f - Mathf.InverseLerp(this.m_lastUseTime, this.m_lastUseTime + this.current, Time.time);
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000D082 File Offset: 0x0000B282
		public void SetDefault(float defaultTime)
		{
			this.m_default = Mathf.Abs(defaultTime);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000D090 File Offset: 0x0000B290
		public void SetDefault(float defaultTime, float randomMod)
		{
			randomMod = Mathf.Abs(randomMod);
			this.m_default = Mathf.Abs(Random.Range(defaultTime - defaultTime * randomMod, defaultTime + defaultTime * randomMod));
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000D0B4 File Offset: 0x0000B2B4
		public bool IsOn(float mod = 1f)
		{
			return Time.time - this.m_lastUseTime < this.current * mod;
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000D0CC File Offset: 0x0000B2CC
		public void ApplyRandomMod(float maxMod = 1f)
		{
			this.m_lastUseTime = Time.time;
			maxMod = Mathf.Clamp01(maxMod);
			this.m_current.@base = Random.Range(this.m_default - this.m_default * maxMod, this.m_default + this.m_default * maxMod);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000D11A File Offset: 0x0000B31A
		public void ApplyNext(float next)
		{
			this.m_lastUseTime = Time.time;
			this.m_current.@base = next;
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000D133 File Offset: 0x0000B333
		public void ApplyNextModed(float next, float mod)
		{
			this.m_lastUseTime = Time.time;
			this.m_current.@base = next * mod;
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000D14E File Offset: 0x0000B34E
		public void ApplyNextRandomMod(float next, float maxMod)
		{
			this.m_lastUseTime = Time.time;
			this.m_current.@base = Random.Range(next - next * maxMod, next + next * maxMod);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000D175 File Offset: 0x0000B375
		public void ApplyMod(float mod)
		{
			this.m_lastUseTime = Time.time;
			this.m_current.@base = this.m_default * mod;
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000D195 File Offset: 0x0000B395
		public void Apply()
		{
			this.m_lastUseTime = Time.time;
			this.m_current.@base = this.m_default;
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000D1B3 File Offset: 0x0000B3B3
		public void OverrideLastTimeUse(float time)
		{
			this.m_lastUseTime = time;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000D1BC File Offset: 0x0000B3BC
		public void Reset()
		{
			this.m_lastUseTime = -this.current;
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000D1CC File Offset: 0x0000B3CC
		public void Clear()
		{
			this.m_default = 0f;
			this.m_lastUseTime = float.NegativeInfinity;
			this.m_current.@base = 0f;
			this.m_current.moded = 0f;
			this.m_current.percentModed = 0f;
		}

		// Token: 0x0400008B RID: 139
		[Range(0f, 3600f)]
		[SerializeField]
		private float m_default;

		// Token: 0x0400008C RID: 140
		[SerializeField]
		private float m_lastUseTime = float.NegativeInfinity;

		// Token: 0x0400008D RID: 141
		[SerializeField]
		private Modificable m_current = new Modificable();
	}
}
