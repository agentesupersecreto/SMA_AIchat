using System;
using System.Collections.Generic;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;

namespace Assets.TValle.Tools.Runtime.Characters.Scenes
{
	// Token: 0x02000047 RID: 71
	public interface ICharactersSceneInteractions
	{
		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000177 RID: 375
		// (remove) Token: 0x06000178 RID: 376
		event OnInteractionHandler onInteraction;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x06000179 RID: 377
		// (remove) Token: 0x0600017A RID: 378
		event OnInteractionStackHandler onStackingInteraction;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x0600017B RID: 379
		// (remove) Token: 0x0600017C RID: 380
		event OnInteractionStackHandler onInteractionStacked;

		// Token: 0x0600017D RID: 381
		IReadOnlyList<Interaction> Peek();

		// Token: 0x0600017E RID: 382
		void Peek(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue, out Interaction interaction);

		// Token: 0x0600017F RID: 383
		[Obsolete("all interaction can be stacked into one now, no need for a list", true)]
		IReadOnlyList<Interaction> PeekMany(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue);

		// Token: 0x06000180 RID: 384
		int PeekTimes(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue);

		// Token: 0x06000181 RID: 385
		bool PeekIsValid(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue);

		// Token: 0x06000182 RID: 386
		int PeekEndFrame(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue);

		// Token: 0x06000183 RID: 387
		int PeekStartFrame(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue);

		// Token: 0x06000184 RID: 388
		float PeekDuration(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue);

		// Token: 0x06000185 RID: 389
		float PeekDamagePercentageDone(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool reachedMaxValue);
	}
}
