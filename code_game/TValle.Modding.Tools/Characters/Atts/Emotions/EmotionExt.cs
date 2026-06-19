using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.TValle.Tools.Runtime.Characters.Atts.Emotions
{
	// Token: 0x02000080 RID: 128
	public static class EmotionExt
	{
		// Token: 0x06000354 RID: 852 RVA: 0x00008E82 File Offset: 0x00007082
		public static bool IsFemale(this Emotion emo)
		{
			return EmotionExt.femaleEmotionsSet.Contains((int)emo);
		}

		// Token: 0x06000355 RID: 853 RVA: 0x00008E8F File Offset: 0x0000708F
		public static bool IsMale(this Emotion emo)
		{
			return EmotionExt.maleEmotionsSet.Contains((int)emo);
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00008E9C File Offset: 0x0000709C
		public static bool IsGood(this Emotion emo)
		{
			if (emo - Emotion.enjoyment <= 4)
			{
				return true;
			}
			if (emo - Emotion.disappointment > 4)
			{
				throw new ArgumentOutOfRangeException(emo.ToString());
			}
			return false;
		}

		// Token: 0x040001CF RID: 463
		public static readonly Emotion[] emotionsWithDefaultValueBuff = new Emotion[]
		{
			Emotion.pleasure,
			Emotion.enjoyment,
			Emotion.disappointment,
			Emotion.rage,
			Emotion.pain,
			Emotion.fear
		};

		// Token: 0x040001D0 RID: 464
		public static readonly Emotion[] femaleEmotions = new Emotion[]
		{
			Emotion.arousal,
			Emotion.pleasure,
			Emotion.favorability,
			Emotion.relief,
			Emotion.enjoyment,
			Emotion.disappointment,
			Emotion.rage,
			Emotion.pain,
			Emotion.fear
		};

		// Token: 0x040001D1 RID: 465
		public static readonly HashSet<int> femaleEmotionsSet = EmotionExt.femaleEmotions.Cast<int>().ToHashSet<int>();

		// Token: 0x040001D2 RID: 466
		public static readonly Emotion[] maleEmotions = new Emotion[]
		{
			Emotion.pleasure,
			Emotion.disgust
		};

		// Token: 0x040001D3 RID: 467
		public static readonly HashSet<int> maleEmotionsSet = EmotionExt.maleEmotions.Cast<int>().ToHashSet<int>();
	}
}
