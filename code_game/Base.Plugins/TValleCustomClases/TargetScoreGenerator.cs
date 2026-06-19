using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x0200006D RID: 109
	public class TargetScoreGenerator
	{
		// Token: 0x06000348 RID: 840 RVA: 0x0000E334 File Offset: 0x0000C534
		public TargetScoreGenerator(Transform actor)
		{
			if (actor == null)
			{
				throw new ArgumentNullException("actor", "actor null reference.");
			}
			this.m_actor = actor;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000E35C File Offset: 0x0000C55C
		public double Calcule(Transform target, TargetScoreGenerator.ScorePriority anglePriority, AngleLimits angleLimits, TargetScoreGenerator.ScorePriority distancePriority, DistanceLimits distanceLimits, float Mod = 1f)
		{
			Vector3 vector = target.position - this.m_actor.position;
			return this.getScore(vector, anglePriority, angleLimits, distancePriority, distanceLimits, Mod);
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000E390 File Offset: 0x0000C590
		private double getScore(Vector3 direction, TargetScoreGenerator.ScorePriority anglePriority, AngleLimits angleLimits, TargetScoreGenerator.ScorePriority distancePriority, DistanceLimits distanceLimits, float Mod)
		{
			if (distancePriority == TargetScoreGenerator.ScorePriority.none && anglePriority == TargetScoreGenerator.ScorePriority.none)
			{
				return 0.0;
			}
			double num = 0.0;
			if (distancePriority != TargetScoreGenerator.ScorePriority.none)
			{
				num = this.getDistanceScore(distanceLimits, direction, distancePriority, Mod);
			}
			double num2 = 0.0;
			if (anglePriority != TargetScoreGenerator.ScorePriority.none)
			{
				num2 = this.getAngleScore(angleLimits, direction, anglePriority, Mod);
			}
			return num + num2;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000E3E8 File Offset: 0x0000C5E8
		private double getAngleScore(AngleLimits angleLimits, Vector3 direction, TargetScoreGenerator.ScorePriority scorePriority, float Mod)
		{
			Vector3 vector = this.m_actor.InverseTransformDirection(direction);
			double num = (double)CalculeAimAngleLimits.LocalVerticalAngle(vector);
			double num2 = (double)CalculeAimAngleLimits.LocalHorizontalAngle(vector);
			double num3 = (num - (double)angleLimits.lowVertical) / (double)(angleLimits.highVertical - angleLimits.lowVertical);
			double num4 = num2 / (double)angleLimits.horizontal;
			double num5 = (num3 + num4) / 2.0;
			num5 = TargetScoreGenerator.GetScoreWithPriority(num5, scorePriority) * (double)Mod;
			return 1.0 / num5;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0000E458 File Offset: 0x0000C658
		private double getDistanceScore(DistanceLimits distanceLimits, Vector3 direction, TargetScoreGenerator.ScorePriority scorePriority, float Mod)
		{
			double num = (double)distanceLimits.sqrMin;
			double num2 = (double)distanceLimits.sqrMax;
			double num3 = ((double)direction.sqrMagnitude - num) / (num2 - num);
			num3 = TargetScoreGenerator.GetScoreWithPriority(num3, scorePriority) * (double)Mod;
			return 1.0 / num3;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0000E4A0 File Offset: 0x0000C6A0
		private static double GetScoreWithPriority(double score, TargetScoreGenerator.ScorePriority pri)
		{
			double num = TargetScoreGenerator.scorePriorityModificator(pri);
			score = TargetScoreGenerator.abs(score);
			switch (pri)
			{
			case TargetScoreGenerator.ScorePriority.none:
				return num;
			case TargetScoreGenerator.ScorePriority.low:
				return (score + 0.1) * num;
			case TargetScoreGenerator.ScorePriority.normal:
				return score * num;
			case TargetScoreGenerator.ScorePriority.high:
				return score * num;
			case TargetScoreGenerator.ScorePriority.extreme:
				return score * num;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0000E4F9 File Offset: 0x0000C6F9
		private static double abs(double v)
		{
			if (v < 0.0)
			{
				return v * -1.0;
			}
			return v;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000E514 File Offset: 0x0000C714
		private static double scorePriorityModificator(TargetScoreGenerator.ScorePriority pri)
		{
			switch (pri)
			{
			case TargetScoreGenerator.ScorePriority.none:
				return double.PositiveInfinity;
			case TargetScoreGenerator.ScorePriority.low:
				return 10000.0;
			case TargetScoreGenerator.ScorePriority.normal:
				return 1.0;
			case TargetScoreGenerator.ScorePriority.high:
				return 0.0001;
			case TargetScoreGenerator.ScorePriority.extreme:
				return 1E-08;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x040000B7 RID: 183
		private Transform m_actor;

		// Token: 0x020001AF RID: 431
		public enum ScorePriority
		{
			// Token: 0x04000403 RID: 1027
			none,
			// Token: 0x04000404 RID: 1028
			low,
			// Token: 0x04000405 RID: 1029
			normal,
			// Token: 0x04000406 RID: 1030
			high,
			// Token: 0x04000407 RID: 1031
			extreme
		}
	}
}
