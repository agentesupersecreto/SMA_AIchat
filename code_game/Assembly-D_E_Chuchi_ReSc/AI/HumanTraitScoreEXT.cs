using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000333 RID: 819
	public static class HumanTraitScoreEXT
	{
		// Token: 0x060011AE RID: 4526 RVA: 0x0004BA20 File Offset: 0x00049C20
		public static int GetValorPolarizadoDeScore(this HumanTraitScore score)
		{
			switch (score)
			{
			case HumanTraitScore.normal:
				return 0;
			case HumanTraitScore.alto:
				return 1;
			case HumanTraitScore.muyAlto:
				return 2;
			case HumanTraitScore.bajo:
				return -1;
			case HumanTraitScore.muyBajo:
				return -2;
			default:
				throw new ArgumentOutOfRangeException(score.ToString());
			}
		}

		// Token: 0x060011AF RID: 4527 RVA: 0x0004BA5C File Offset: 0x00049C5C
		public static float GetWeigthDeScore(this HumanTraitScore score)
		{
			int valorPolarizadoDeScore = score.GetValorPolarizadoDeScore();
			return MathfExtension.InverseLerpConMedio(-2f, 0f, 2f, (float)valorPolarizadoDeScore);
		}

		// Token: 0x060011B0 RID: 4528 RVA: 0x0004BA86 File Offset: 0x00049C86
		public static int GetValorPolarizadoDeScore(this HumanTraitScore scoreA, HumanTraitScore scoreB)
		{
			return Mathf.Clamp(Mathf.RoundToInt(((float)scoreA.GetValorPolarizadoDeScore() + (float)scoreB.GetValorPolarizadoDeScore()) / 2f), -2, 2);
		}

		// Token: 0x060011B1 RID: 4529 RVA: 0x0004BAAA File Offset: 0x00049CAA
		public static int GetValorPolarizadoDeScore(this HumanTraitScore scoreA, HumanTraitScore scoreB, HumanTraitScore scoreC)
		{
			return Mathf.Clamp(Mathf.RoundToInt(((float)scoreA.GetValorPolarizadoDeScore() + (float)scoreB.GetValorPolarizadoDeScore() + (float)scoreC.GetValorPolarizadoDeScore()) / 3f), -2, 2);
		}

		// Token: 0x060011B2 RID: 4530 RVA: 0x0004BAD6 File Offset: 0x00049CD6
		public static int GetValorPolarizadoDeScore(this HumanTraitScore scoreA, HumanTraitScore scoreB, HumanTraitScore scoreC, HumanTraitScore scoreD)
		{
			return Mathf.Clamp(Mathf.RoundToInt(((float)scoreA.GetValorPolarizadoDeScore() + (float)scoreB.GetValorPolarizadoDeScore() + (float)scoreC.GetValorPolarizadoDeScore() + (float)scoreD.GetValorPolarizadoDeScore()) / 4f), -2, 2);
		}

		// Token: 0x060011B3 RID: 4531 RVA: 0x0004BB0A File Offset: 0x00049D0A
		public static int GetValorPolarizadoDeScore(this HumanTraitScore scoreA, HumanTraitScore scoreB, HumanTraitScore scoreC, HumanTraitScore scoreD, HumanTraitScore scoreE)
		{
			return Mathf.Clamp(Mathf.RoundToInt(((float)scoreA.GetValorPolarizadoDeScore() + (float)scoreB.GetValorPolarizadoDeScore() + (float)scoreC.GetValorPolarizadoDeScore() + (float)scoreD.GetValorPolarizadoDeScore() + (float)scoreE.GetValorPolarizadoDeScore()) / 5f), -2, 2);
		}
	}
}
