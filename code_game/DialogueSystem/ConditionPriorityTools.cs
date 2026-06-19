using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000212 RID: 530
	public static class ConditionPriorityTools
	{
		// Token: 0x060017E2 RID: 6114 RVA: 0x0001EDEC File Offset: 0x0001CFEC
		public static ConditionPriority StringToConditionPriority(string s)
		{
			if (string.Equals(s, "High"))
			{
				return ConditionPriority.High;
			}
			if (string.Equals(s, "AboveNormal"))
			{
				return ConditionPriority.AboveNormal;
			}
			if (string.Equals(s, "BelowNormal"))
			{
				return ConditionPriority.BelowNormal;
			}
			if (string.Equals(s, "Low"))
			{
				return ConditionPriority.Low;
			}
			return ConditionPriority.Normal;
		}
	}
}
