using System;
using System.Collections.Generic;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;

namespace Assets.TValle.Tools.Runtime.Characters.Scenes
{
	// Token: 0x02000048 RID: 72
	public class EmptyCharactersSceneInteractions : ICharactersSceneInteractions, ICharactersSceneInteractionsArchived, ICharactersSceneInteractionsClearable
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000187 RID: 391 RVA: 0x00003865 File Offset: 0x00001A65
		// (set) Token: 0x06000188 RID: 392 RVA: 0x0000386C File Offset: 0x00001A6C
		public static EmptyCharactersSceneInteractions Instance { get; private set; } = new EmptyCharactersSceneInteractions();

		// Token: 0x06000189 RID: 393 RVA: 0x00003874 File Offset: 0x00001A74
		private EmptyCharactersSceneInteractions()
		{
		}

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x0600018A RID: 394 RVA: 0x0000387C File Offset: 0x00001A7C
		// (remove) Token: 0x0600018B RID: 395 RVA: 0x0000387E File Offset: 0x00001A7E
		public event OnInteractionHandler onInteraction
		{
			add
			{
			}
			remove
			{
			}
		}

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x0600018C RID: 396 RVA: 0x00003880 File Offset: 0x00001A80
		// (remove) Token: 0x0600018D RID: 397 RVA: 0x00003882 File Offset: 0x00001A82
		public event OnInteractionStackHandler onStackingInteraction
		{
			add
			{
			}
			remove
			{
			}
		}

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x0600018E RID: 398 RVA: 0x00003884 File Offset: 0x00001A84
		// (remove) Token: 0x0600018F RID: 399 RVA: 0x00003886 File Offset: 0x00001A86
		public event OnInteractionStackHandler onInteractionStacked
		{
			add
			{
			}
			remove
			{
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00003888 File Offset: 0x00001A88
		public void Clear()
		{
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000388A File Offset: 0x00001A8A
		public IReadOnlyList<Interaction> Peek()
		{
			return new List<Interaction>();
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00003891 File Offset: 0x00001A91
		public void Peek(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue, out Interaction interaction)
		{
			interaction = default(Interaction);
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000389B File Offset: 0x00001A9B
		public void PeekEmotionDamagePair(Emotion main, EmotionPercentageRange mainRange, Emotion secondary, EmotionPercentageRange secondaryRange, out EmotionDamagePair emotionDamagePair)
		{
			emotionDamagePair = default(EmotionDamagePair);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000038A5 File Offset: 0x00001AA5
		public int PeekEndFrame(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
		{
			return 0;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x000038A8 File Offset: 0x00001AA8
		public bool PeekIsValid(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
		{
			return false;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x000038AB File Offset: 0x00001AAB
		public IReadOnlyList<Interaction> PeekMany(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
		{
			return new List<Interaction>();
		}

		// Token: 0x06000197 RID: 407 RVA: 0x000038B2 File Offset: 0x00001AB2
		public int PeekStartFrame(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
		{
			return 0;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x000038B5 File Offset: 0x00001AB5
		public int PeekTimes(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
		{
			return 0;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000038B8 File Offset: 0x00001AB8
		public float PeekDuration(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
		{
			return 0f;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000038BF File Offset: 0x00001ABF
		public float PeekDamagePercentageDone(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
		{
			return 0f;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x000038C6 File Offset: 0x00001AC6
		public int PeekTriggeringBodyPartCount(SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
		{
			return 0;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x000038C9 File Offset: 0x00001AC9
		public int PeekSensitiveBodyPartCount(TriggeringBodyPart fromPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue)
		{
			return 0;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x000038CC File Offset: 0x00001ACC
		public int PeekInterationReceivedTypeCount(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, Emotion emotion, bool reachedMaxValue)
		{
			return 0;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x000038CF File Offset: 0x00001ACF
		public int PeekEmotionCount(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, bool reachedMaxValue)
		{
			return 0;
		}
	}
}
