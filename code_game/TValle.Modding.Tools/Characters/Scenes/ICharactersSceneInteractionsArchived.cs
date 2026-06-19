using System;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;

namespace Assets.TValle.Tools.Runtime.Characters.Scenes
{
	// Token: 0x0200004A RID: 74
	public interface ICharactersSceneInteractionsArchived : ICharactersSceneInteractionsClearable, ICharactersSceneInteractions
	{
		// Token: 0x060001A0 RID: 416
		void PeekEmotionDamagePair(Emotion main, EmotionPercentageRange mainRange, Emotion secondary, EmotionPercentageRange secondaryRange, out EmotionDamagePair emotionDamagePair);

		// Token: 0x060001A1 RID: 417
		int PeekTriggeringBodyPartCount(SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue);

		// Token: 0x060001A2 RID: 418
		int PeekSensitiveBodyPartCount(TriggeringBodyPart fromPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue);

		// Token: 0x060001A3 RID: 419
		int PeekInterationReceivedTypeCount(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, Emotion emotion, bool reachedMaxValue);

		// Token: 0x060001A4 RID: 420
		int PeekEmotionCount(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, bool reachedMaxValue);
	}
}
