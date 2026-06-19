using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000339 RID: 825
	public static class SpotScoreExt
	{
		// Token: 0x060011BF RID: 4543 RVA: 0x0004C1C8 File Offset: 0x0004A3C8
		public static float SpotScoreToWeight(this SpotScore score)
		{
			if (score <= SpotScore.enSpot)
			{
				if (score == SpotScore.fuera)
				{
					return 0.45f;
				}
				if (score == SpotScore.enSpot)
				{
					return 1f;
				}
			}
			else
			{
				if (score == SpotScore.casiEnSpot)
				{
					return 0.9f;
				}
				if (score == SpotScore.cercano)
				{
					return 0.75f;
				}
			}
			throw new ArgumentOutOfRangeException(score.ToString());
		}
	}
}
