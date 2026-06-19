using System;
using System.Runtime.CompilerServices;

namespace Assets.TValle.Tools.Runtime.Characters.Atts.Emotions
{
	// Token: 0x0200007D RID: 125
	[Serializable]
	public struct EmotionDamagePair
	{
		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600034E RID: 846 RVA: 0x00008D7E File Offset: 0x00006F7E
		public bool isValid
		{
			get
			{
				return this.main != Emotion.None && this.secondary > Emotion.None;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600034F RID: 847 RVA: 0x00008D93 File Offset: 0x00006F93
		public ValueTuple<Emotion, EmotionPercentageRange, Emotion, EmotionPercentageRange> valueId
		{
			get
			{
				return new ValueTuple<Emotion, EmotionPercentageRange, Emotion, EmotionPercentageRange>(this.main, this.mainRange, this.secondary, this.secondaryRange);
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000350 RID: 848 RVA: 0x00008DB2 File Offset: 0x00006FB2
		public ITuple id
		{
			get
			{
				return this.valueId;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000351 RID: 849 RVA: 0x00008DBF File Offset: 0x00006FBF
		public float damageScore
		{
			get
			{
				return this.damageScoreTotal / (float)this.times;
			}
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00008DCF File Offset: 0x00006FCF
		public void StackToSelf(ref EmotionDamagePair Other)
		{
			this.times += Other.times;
			this.damagePercentageTotal += Other.damagePercentageTotal;
			this.damageScoreTotal += Other.damageScoreTotal;
		}

		// Token: 0x040001B4 RID: 436
		public Emotion main;

		// Token: 0x040001B5 RID: 437
		public EmotionPercentageRange mainRange;

		// Token: 0x040001B6 RID: 438
		public Emotion secondary;

		// Token: 0x040001B7 RID: 439
		public EmotionPercentageRange secondaryRange;

		// Token: 0x040001B8 RID: 440
		public int times;

		// Token: 0x040001B9 RID: 441
		public float damagePercentageTotal;

		// Token: 0x040001BA RID: 442
		public float damageScoreTotal;
	}
}
