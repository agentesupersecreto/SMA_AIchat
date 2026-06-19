using System;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200003A RID: 58
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/dialogue_system_events.html")]
	[AddComponentMenu("Dialogue System/Miscellaneous/Dialogue System Events")]
	public class DialogueSystemEvents : MonoBehaviour
	{
		// Token: 0x0600019D RID: 413 RVA: 0x00009225 File Offset: 0x00007425
		public void OnConversationStart(Transform actor)
		{
			this.conversationEvents.onConversationStart.Invoke(actor);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00009238 File Offset: 0x00007438
		public void OnConversationEnd(Transform actor)
		{
			this.conversationEvents.onConversationEnd.Invoke(actor);
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0000924B File Offset: 0x0000744B
		public void OnConversationCancelled(Transform actor)
		{
			this.conversationEvents.onConversationCancelled.Invoke(actor);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0000925E File Offset: 0x0000745E
		public void OnConversationLine(Subtitle subtitle)
		{
			this.conversationEvents.onConversationLine.Invoke(subtitle);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00009271 File Offset: 0x00007471
		public void OnConversationLineEnd(Subtitle subtitle)
		{
			this.conversationEvents.onConversationLineEnd.Invoke(subtitle);
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00009284 File Offset: 0x00007484
		public void OnConversationLineCancelled(Subtitle subtitle)
		{
			this.conversationEvents.onConversationLineCancelled.Invoke(subtitle);
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00009297 File Offset: 0x00007497
		public void OnConversationResponseMenu(Response[] responses)
		{
			this.conversationEvents.onConversationResponseMenu.Invoke(responses);
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x000092AA File Offset: 0x000074AA
		public void OnConversationTimeout()
		{
			this.conversationEvents.onConversationResponseMenuTimeout.Invoke();
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x000092BC File Offset: 0x000074BC
		public void OnLinkedConversationStart(Transform actor)
		{
			this.conversationEvents.onLinkedConversationStart.Invoke(actor);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000092CF File Offset: 0x000074CF
		public void OnBarkStart(Transform actor)
		{
			this.barkEvents.onBarkStart.Invoke(actor);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000092E2 File Offset: 0x000074E2
		public void OnBarkEnd(Transform actor)
		{
			this.barkEvents.onBarkEnd.Invoke(actor);
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000092F5 File Offset: 0x000074F5
		public void OnBarkLine(Subtitle subtitle)
		{
			this.barkEvents.onBarkLine.Invoke(subtitle);
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00009308 File Offset: 0x00007508
		public void OnSequenceStart(Transform actor)
		{
			this.sequenceEvents.onSequenceStart.Invoke(actor);
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000931B File Offset: 0x0000751B
		public void OnSequenceEnd(Transform actor)
		{
			this.sequenceEvents.onSequenceEnd.Invoke(actor);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000932E File Offset: 0x0000752E
		public void OnQuestStateChange(string title)
		{
			this.questEvents.onQuestStateChange.Invoke(title);
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00009341 File Offset: 0x00007541
		public void OnQuestTrackingEnabled(string title)
		{
			this.questEvents.onQuestTrackingEnabled.Invoke(title);
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00009354 File Offset: 0x00007554
		public void OnQuestTrackingDisabled(string title)
		{
			this.questEvents.onQuestTrackingDisabled.Invoke(title);
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00009367 File Offset: 0x00007567
		public void UpdateTracker()
		{
			this.questEvents.onUpdateQuestTracker.Invoke();
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00009379 File Offset: 0x00007579
		public void OnDialogueSystemPause()
		{
			this.pauseEvents.onDialogueSystemPause.Invoke();
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000938B File Offset: 0x0000758B
		public void OnDialogueSystemUnpause()
		{
			this.pauseEvents.onDialogueSystemUnpause.Invoke();
		}

		// Token: 0x0400013E RID: 318
		public DialogueSystemEvents.ConversationEvents conversationEvents = new DialogueSystemEvents.ConversationEvents();

		// Token: 0x0400013F RID: 319
		public DialogueSystemEvents.BarkEvents barkEvents = new DialogueSystemEvents.BarkEvents();

		// Token: 0x04000140 RID: 320
		public DialogueSystemEvents.SequenceEvents sequenceEvents = new DialogueSystemEvents.SequenceEvents();

		// Token: 0x04000141 RID: 321
		public DialogueSystemEvents.QuestEvents questEvents = new DialogueSystemEvents.QuestEvents();

		// Token: 0x04000142 RID: 322
		public DialogueSystemEvents.PauseEvents pauseEvents = new DialogueSystemEvents.PauseEvents();

		// Token: 0x02000079 RID: 121
		[Serializable]
		public class StringEvent : UnityEvent<string>
		{
		}

		// Token: 0x0200007A RID: 122
		[Serializable]
		public class TransformEvent : UnityEvent<Transform>
		{
		}

		// Token: 0x0200007B RID: 123
		[Serializable]
		public class SubtitleEvent : UnityEvent<Subtitle>
		{
		}

		// Token: 0x0200007C RID: 124
		[Serializable]
		public class ResponsesEvent : UnityEvent<Response[]>
		{
		}

		// Token: 0x0200007D RID: 125
		[Serializable]
		public class ConversationEvents
		{
			// Token: 0x04000297 RID: 663
			[Tooltip("Invoked when a conversation starts. Transform is primary actor (typically player).")]
			public DialogueSystemEvents.TransformEvent onConversationStart = new DialogueSystemEvents.TransformEvent();

			// Token: 0x04000298 RID: 664
			[Tooltip("Invoked when a conversation ends. Transform is primary actor (typically player).")]
			public DialogueSystemEvents.TransformEvent onConversationEnd = new DialogueSystemEvents.TransformEvent();

			// Token: 0x04000299 RID: 665
			[Tooltip("Invoked when a conversation is cancelled. Transform is primary actor (typically player).")]
			public DialogueSystemEvents.TransformEvent onConversationCancelled = new DialogueSystemEvents.TransformEvent();

			// Token: 0x0400029A RID: 666
			[Tooltip("Invoked just before a line is delivered. Passes Subtitle.")]
			public DialogueSystemEvents.SubtitleEvent onConversationLine = new DialogueSystemEvents.SubtitleEvent();

			// Token: 0x0400029B RID: 667
			[Tooltip("Invoked when a line has finished. Passes Subtitle.")]
			public DialogueSystemEvents.SubtitleEvent onConversationLineEnd = new DialogueSystemEvents.SubtitleEvent();

			// Token: 0x0400029C RID: 668
			[Tooltip("Invoked if player presses cancel button while line is being delivered.")]
			public DialogueSystemEvents.SubtitleEvent onConversationLineCancelled = new DialogueSystemEvents.SubtitleEvent();

			// Token: 0x0400029D RID: 669
			[Tooltip("Invoked when showing a response menu. Passes Response[] array.")]
			public DialogueSystemEvents.ResponsesEvent onConversationResponseMenu = new DialogueSystemEvents.ResponsesEvent();

			// Token: 0x0400029E RID: 670
			[Tooltip("Invoked when a response menu times out.")]
			public UnityEvent onConversationResponseMenuTimeout = new UnityEvent();

			// Token: 0x0400029F RID: 671
			[Tooltip("Invoked when a conversation follows a link to another conversation. Transform is primary actor (typically player).")]
			public DialogueSystemEvents.TransformEvent onLinkedConversationStart = new DialogueSystemEvents.TransformEvent();
		}

		// Token: 0x0200007E RID: 126
		[Serializable]
		public class BarkEvents
		{
			// Token: 0x040002A0 RID: 672
			[Tooltip("Invoked when a bark starts. Transform is recipient of bark.")]
			public DialogueSystemEvents.TransformEvent onBarkStart = new DialogueSystemEvents.TransformEvent();

			// Token: 0x040002A1 RID: 673
			[Tooltip("Invoked when a bark ends. Transform is recipient of bark.")]
			public DialogueSystemEvents.TransformEvent onBarkEnd = new DialogueSystemEvents.TransformEvent();

			// Token: 0x040002A2 RID: 674
			[Tooltip("Invoked just before a bark line is delivered. Passes Subtitle.")]
			public DialogueSystemEvents.SubtitleEvent onBarkLine = new DialogueSystemEvents.SubtitleEvent();
		}

		// Token: 0x0200007F RID: 127
		[Serializable]
		public class SequenceEvents
		{
			// Token: 0x040002A3 RID: 675
			[Tooltip("Invoked when a sequence starts. Transform is 'listener' of sequence.")]
			public DialogueSystemEvents.TransformEvent onSequenceStart = new DialogueSystemEvents.TransformEvent();

			// Token: 0x040002A4 RID: 676
			[Tooltip("Invoked when a sequence ends. Transform is 'listener' of sequence.")]
			public DialogueSystemEvents.TransformEvent onSequenceEnd = new DialogueSystemEvents.TransformEvent();
		}

		// Token: 0x02000080 RID: 128
		[Serializable]
		public class QuestEvents
		{
			// Token: 0x040002A5 RID: 677
			[Tooltip("Invoked when a quest state or quest entry state changes. String is quest title.")]
			public DialogueSystemEvents.StringEvent onQuestStateChange = new DialogueSystemEvents.StringEvent();

			// Token: 0x040002A6 RID: 678
			[Tooltip("Invoked when tracking is enabled for a quest. String is quest title.")]
			public DialogueSystemEvents.StringEvent onQuestTrackingEnabled = new DialogueSystemEvents.StringEvent();

			// Token: 0x040002A7 RID: 679
			[Tooltip("Invoked when tracking is disabled for a quest. String is quest title.")]
			public DialogueSystemEvents.StringEvent onQuestTrackingDisabled = new DialogueSystemEvents.StringEvent();

			// Token: 0x040002A8 RID: 680
			[Tooltip("Invoked when updating quest tracker.")]
			public UnityEvent onUpdateQuestTracker = new UnityEvent();
		}

		// Token: 0x02000081 RID: 129
		[Serializable]
		public class PauseEvents
		{
			// Token: 0x040002A9 RID: 681
			[Tooltip("Invoked when DialogueManager.Pause() is called.")]
			public UnityEvent onDialogueSystemPause = new UnityEvent();

			// Token: 0x040002AA RID: 682
			[Tooltip("Invoked when DialogueManager.Unpause() is called.")]
			public UnityEvent onDialogueSystemUnpause = new UnityEvent();
		}
	}
}
