using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2
{
	// Token: 0x0200055E RID: 1374
	[Serializable]
	public struct SpotBonuses
	{
		// Token: 0x170008E3 RID: 2275
		// (get) Token: 0x06002164 RID: 8548 RVA: 0x0007C824 File Offset: 0x0007AA24
		public static SpotBonuses none
		{
			get
			{
				return new SpotBonuses
				{
					cercano = 1f,
					casiEnSpot = 1f,
					enSpot = 1f
				};
			}
		}

		// Token: 0x170008E4 RID: 2276
		// (get) Token: 0x06002165 RID: 8549 RVA: 0x0007C860 File Offset: 0x0007AA60
		public static SpotBonuses @default
		{
			get
			{
				return new SpotBonuses
				{
					cercano = 1.15f,
					casiEnSpot = 1.45f,
					enSpot = 2f
				};
			}
		}

		// Token: 0x170008E5 RID: 2277
		// (get) Token: 0x06002166 RID: 8550 RVA: 0x0007C89C File Offset: 0x0007AA9C
		public static SpotBonuses suave
		{
			get
			{
				return new SpotBonuses
				{
					cercano = 1.05f,
					casiEnSpot = 1.15f,
					enSpot = 1.35f
				};
			}
		}

		// Token: 0x06002167 RID: 8551 RVA: 0x0007C8D8 File Offset: 0x0007AAD8
		public float GetBonus(SpotScore spotScore)
		{
			float num = 1f;
			if (spotScore <= SpotScore.enSpot)
			{
				if (spotScore == SpotScore.fuera)
				{
					return num;
				}
				if (spotScore == SpotScore.enSpot)
				{
					return this.enSpot;
				}
			}
			else
			{
				if (spotScore == SpotScore.casiEnSpot)
				{
					return this.casiEnSpot;
				}
				if (spotScore == SpotScore.cercano)
				{
					return this.cercano;
				}
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x040015B0 RID: 5552
		public float cercano;

		// Token: 0x040015B1 RID: 5553
		public float casiEnSpot;

		// Token: 0x040015B2 RID: 5554
		public float enSpot;
	}
}
