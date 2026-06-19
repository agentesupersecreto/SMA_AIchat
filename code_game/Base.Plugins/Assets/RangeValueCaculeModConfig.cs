using System;

namespace Assets
{
	// Token: 0x0200013B RID: 315
	[Serializable]
	public struct RangeValueCaculeModConfig
	{
		// Token: 0x17000195 RID: 405
		// (get) Token: 0x0600090D RID: 2317 RVA: 0x0001DD78 File Offset: 0x0001BF78
		public static RangeValueCaculeModConfig getDefault
		{
			get
			{
				return new RangeValueCaculeModConfig
				{
					promedio = 0.5f,
					maxMod = 1f,
					minMod = 0f,
					returnZeroIfOutOfRange = true
				};
			}
		}

		// Token: 0x04000253 RID: 595
		public float promedio;

		// Token: 0x04000254 RID: 596
		public bool returnZeroIfOutOfRange;

		// Token: 0x04000255 RID: 597
		public float minMod;

		// Token: 0x04000256 RID: 598
		public float maxMod;
	}
}
