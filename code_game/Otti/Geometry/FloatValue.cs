using System;

namespace com.ootii.Geometry
{
	// Token: 0x02000048 RID: 72
	public struct FloatValue
	{
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000380 RID: 896 RVA: 0x00011B21 File Offset: 0x0000FD21
		// (set) Token: 0x06000381 RID: 897 RVA: 0x00011B29 File Offset: 0x0000FD29
		public int SampleCount
		{
			get
			{
				return this.mSampleCount;
			}
			set
			{
				this.mSampleCount = ((value > 0) ? value : 1);
				if (this.mSamples == null || this.mSamples.Length != this.mSampleCount)
				{
					this.Resize(this.mSampleCount, this.mDefault);
				}
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000382 RID: 898 RVA: 0x00011B63 File Offset: 0x0000FD63
		// (set) Token: 0x06000383 RID: 899 RVA: 0x00011B6B File Offset: 0x0000FD6B
		public float Value
		{
			get
			{
				return this.mValue;
			}
			set
			{
				this.Add(value);
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000384 RID: 900 RVA: 0x00011B75 File Offset: 0x0000FD75
		public float PrevValue
		{
			get
			{
				return this.mPrevValue;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000385 RID: 901 RVA: 0x00011B7D File Offset: 0x0000FD7D
		public float Sum
		{
			get
			{
				return this.mSum;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000386 RID: 902 RVA: 0x00011B85 File Offset: 0x0000FD85
		public float Average
		{
			get
			{
				return this.mAverage;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000387 RID: 903 RVA: 0x00011B8D File Offset: 0x0000FD8D
		public float TrendValue
		{
			get
			{
				return this.mTrendValue;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000388 RID: 904 RVA: 0x00011B95 File Offset: 0x0000FD95
		public int TrendDirection
		{
			get
			{
				return this.mTrendDirection;
			}
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00011BA0 File Offset: 0x0000FDA0
		public FloatValue(float rValue)
		{
			this.mSampleCount = 10;
			this.mValue = 0f;
			this.mPrevValue = 0f;
			this.mSum = 0f;
			this.mAverage = 0f;
			this.mDefault = 0f;
			this.mTrendDirection = 0;
			this.mTrendValue = 0f;
			this.mIndex = -1;
			this.mSamples = null;
			this.Resize(this.mSampleCount, this.mDefault);
			this.Add(rValue);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00011C28 File Offset: 0x0000FE28
		public FloatValue(float rValue, int rSampleCount)
		{
			this.mSampleCount = rSampleCount;
			this.mValue = 0f;
			this.mPrevValue = 0f;
			this.mSum = 0f;
			this.mAverage = 0f;
			this.mDefault = 0f;
			this.mTrendDirection = 0;
			this.mTrendValue = 0f;
			this.mIndex = -1;
			this.mSamples = null;
			this.Resize(this.mSampleCount, this.mDefault);
			this.Add(rValue);
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00011CB0 File Offset: 0x0000FEB0
		public void Clear(float rValue = 0f)
		{
			for (int i = 0; i < this.mSampleCount; i++)
			{
				this.mSamples[i] = rValue;
			}
			this.mValue = rValue;
			this.mPrevValue = rValue;
			this.mAverage = rValue;
			this.mTrendDirection = 0;
			this.mTrendValue = rValue;
			this.mIndex = -1;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00011D01 File Offset: 0x0000FF01
		public float Replace(float rValue)
		{
			this.mIndex--;
			if (this.mIndex < 0)
			{
				this.mIndex = this.mSampleCount - 1;
			}
			return this.Add(rValue);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00011D30 File Offset: 0x0000FF30
		public float Add(float rValue)
		{
			if (this.mSampleCount == 0)
			{
				this.Resize(10, this.mDefault);
			}
			this.mPrevValue = this.mValue;
			this.mValue = rValue;
			if (this.mValue == this.mPrevValue)
			{
				if (this.mTrendDirection != 0)
				{
					this.mTrendValue = this.mValue;
				}
				this.mTrendDirection = 0;
			}
			else if (this.mValue < this.mPrevValue)
			{
				if (this.mTrendDirection != 1)
				{
					this.mTrendValue = this.mValue;
				}
				this.mTrendDirection = 1;
			}
			else if ((float)this.mTrendDirection > this.mPrevValue)
			{
				if (this.mTrendDirection != 2)
				{
					this.mTrendValue = this.mValue;
				}
				this.mTrendDirection = 2;
			}
			this.mIndex++;
			if (this.mIndex >= this.mSampleCount)
			{
				this.mIndex = 0;
			}
			this.mSamples[this.mIndex] = this.mValue;
			this.mSum = 0f;
			for (int i = 0; i < this.mSampleCount; i++)
			{
				this.mSum += this.mSamples[i];
			}
			this.mAverage = this.mSum / (float)this.mSampleCount;
			return this.mAverage;
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00011E6C File Offset: 0x0001006C
		private void Resize(int rSize, float rDefault)
		{
			float[] array = new float[rSize];
			if (this.mSamples != null)
			{
				int num = this.mSamples.Length;
				Array.Copy(this.mSamples, array, Math.Min(num, rSize));
				for (int i = num; i < rSize; i++)
				{
					array[i] = rDefault;
				}
			}
			this.mSamples = array;
			this.mSampleCount = this.mSamples.Length;
			this.mIndex = -1;
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00011ED2 File Offset: 0x000100D2
		public static implicit operator FloatValue(float rValue)
		{
			return new FloatValue(rValue);
		}

		// Token: 0x040001F2 RID: 498
		public const int TREND_CONSTANT = 0;

		// Token: 0x040001F3 RID: 499
		public const int TREND_DECREASING = 1;

		// Token: 0x040001F4 RID: 500
		public const int TREND_INCREASING = 2;

		// Token: 0x040001F5 RID: 501
		private int mSampleCount;

		// Token: 0x040001F6 RID: 502
		private float mValue;

		// Token: 0x040001F7 RID: 503
		private float mPrevValue;

		// Token: 0x040001F8 RID: 504
		private float mSum;

		// Token: 0x040001F9 RID: 505
		private float mAverage;

		// Token: 0x040001FA RID: 506
		private float mTrendValue;

		// Token: 0x040001FB RID: 507
		private int mTrendDirection;

		// Token: 0x040001FC RID: 508
		private float[] mSamples;

		// Token: 0x040001FD RID: 509
		private float mDefault;

		// Token: 0x040001FE RID: 510
		private int mIndex;
	}
}
