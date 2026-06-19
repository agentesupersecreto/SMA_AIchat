using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000014 RID: 20
	public static class BarkController
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000114 RID: 276 RVA: 0x000054F8 File Offset: 0x000036F8
		// (set) Token: 0x06000115 RID: 277 RVA: 0x00005500 File Offset: 0x00003700
		public static Sequencer LastSequencer { get; private set; } = null;

		// Token: 0x06000116 RID: 278 RVA: 0x00005508 File Offset: 0x00003708
		private static int GetSpeakerCurrentBarkPriority(Transform speaker)
		{
			return (!BarkController.currentBarkPriority.ContainsKey(speaker)) ? 0 : BarkController.currentBarkPriority[speaker];
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000552C File Offset: 0x0000372C
		private static void SetSpeakerCurrentBarkPriority(Transform speaker, int priority)
		{
			if (BarkController.currentBarkPriority.ContainsKey(speaker))
			{
				BarkController.currentBarkPriority[speaker] = priority;
			}
			else
			{
				BarkController.currentBarkPriority.Add(speaker, priority);
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000555C File Offset: 0x0000375C
		private static int GetEntryBarkPriority(DialogueEntry entry)
		{
			return (entry != null) ? Field.LookupInt(entry.fields, "Priority") : 0;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000557C File Offset: 0x0000377C
		public static IEnumerator Bark(string conversationTitle, Transform speaker, Transform listener, BarkHistory barkHistory, DialogueDatabase database = null, bool stopAtFirstValid = false)
		{
			if (BarkController.CheckDontBarkDuringConversation())
			{
				yield break;
			}
			bool barked = false;
			if (string.IsNullOrEmpty(conversationTitle) && DialogueDebug.LogWarnings)
			{
				Debug.Log(string.Format("{0}: Bark (speaker={1}, listener={2}): conversation title is blank", new object[] { "Dialogue System", speaker, listener }), speaker);
			}
			if (speaker == null)
			{
				speaker = DialogueManager.Instance.FindActorTransformFromConversation(conversationTitle, "Actor");
			}
			if (speaker == null && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' speaker is null", new object[] { "Dialogue System", speaker, listener, conversationTitle }));
			}
			if (string.IsNullOrEmpty(conversationTitle) || speaker == null)
			{
				yield break;
			}
			IBarkUI barkUI = speaker.GetComponentInChildren(typeof(IBarkUI)) as IBarkUI;
			if (barkUI == null && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' speaker has no bark UI", new object[] { "Dialogue System", speaker, listener, conversationTitle }), speaker);
			}
			bool firstValid = stopAtFirstValid || (barkHistory != null && barkHistory.order == BarkOrder.FirstValid);
			ConversationModel conversationModel = new ConversationModel(database ?? DialogueManager.MasterDatabase, conversationTitle, speaker, listener, DialogueManager.AllowLuaExceptions, DialogueManager.IsDialogueEntryValid, -1, firstValid, false);
			ConversationState firstState = conversationModel.FirstState;
			if (firstState == null && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' has no START entry", new object[] { "Dialogue System", speaker, listener, conversationTitle }), speaker);
			}
			if (firstState != null && !firstState.HasAnyResponses && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' has no valid bark at this time", new object[] { "Dialogue System", speaker, listener, conversationTitle }), speaker);
			}
			if (firstState != null && firstState.HasAnyResponses)
			{
				try
				{
					Response[] responses = ((!firstState.HasNPCResponse) ? firstState.pcResponses : firstState.npcResponses);
					int index = (barkHistory ?? new BarkHistory(BarkOrder.Random)).GetNextIndex(responses.Length);
					DialogueEntry barkEntry = responses[index].destinationEntry;
					if (barkEntry == null && DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' bark entry is null", new object[] { "Dialogue System", speaker, listener, conversationTitle }), speaker);
					}
					if (barkEntry != null)
					{
						int priority = BarkController.GetEntryBarkPriority(barkEntry);
						if (priority < BarkController.GetSpeakerCurrentBarkPriority(speaker))
						{
							if (DialogueDebug.LogInfo)
							{
								Debug.Log(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' currently barking a higher priority bark", new object[] { "Dialogue System", speaker, listener, conversationTitle }), speaker);
							}
							yield break;
						}
						BarkController.SetSpeakerCurrentBarkPriority(speaker, priority);
						barked = true;
						BarkController.InformParticipants("OnBarkStart", speaker, listener);
						ConversationState barkState = conversationModel.GetState(barkEntry, false, false, false);
						if (barkState == null)
						{
							if (DialogueDebug.LogWarnings)
							{
								Debug.LogWarning(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' can't find a valid dialogue entry", new object[] { "Dialogue System", speaker, listener, conversationTitle }), speaker);
							}
							yield break;
						}
						if (firstState.HasNPCResponse)
						{
							CharacterInfo tempInfo = barkState.subtitle.speakerInfo;
							barkState.subtitle.speakerInfo = barkState.subtitle.listenerInfo;
							barkState.subtitle.listenerInfo = tempInfo;
						}
						if (DialogueDebug.LogInfo)
						{
							Debug.Log(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}'", new object[]
							{
								"Dialogue System",
								speaker,
								listener,
								barkState.subtitle.formattedText.text
							}), speaker);
						}
						BarkController.InformParticipantsLine("OnBarkLine", speaker, barkState.subtitle);
						if ((barkUI == null || !(barkUI as MonoBehaviour).enabled) && DialogueDebug.LogWarnings)
						{
							Debug.LogWarning(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' bark UI is null or disabled", new object[]
							{
								"Dialogue System",
								speaker,
								listener,
								barkState.subtitle.formattedText.text
							}), speaker);
						}
						if (barkUI != null && (barkUI as MonoBehaviour).enabled)
						{
							barkUI.Bark(barkState.subtitle);
						}
						Sequencer sequencer = BarkController.PlayBarkSequence(barkState.subtitle, speaker, listener);
						BarkController.LastSequencer = sequencer;
						while ((sequencer != null && sequencer.IsPlaying) || (barkUI != null && barkUI.IsPlaying))
						{
							yield return null;
						}
						if (sequencer != null)
						{
							Object.Destroy(sequencer);
						}
					}
				}
				finally
				{
					if (barked)
					{
						BarkController.InformParticipants("OnBarkEnd", speaker, listener);
						BarkController.SetSpeakerCurrentBarkPriority(speaker, 0);
					}
				}
			}
			yield break;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000055E8 File Offset: 0x000037E8
		private static Sequencer PlayBarkSequence(Subtitle subtitle, Transform speaker, Transform listener)
		{
			if (!string.IsNullOrEmpty(subtitle.sequence))
			{
				string text = subtitle.sequence;
				if (text.Contains("{{end}}"))
				{
					string text2 = subtitle.formattedText.text;
					int num = ((!string.IsNullOrEmpty(text2)) ? Tools.StripRichTextCodes(text2).Length : 0);
					text = text.Replace("{{end}}", Mathf.Max(DialogueManager.DisplaySettings.GetMinSubtitleSeconds(), (float)num / Mathf.Max(1f, DialogueManager.DisplaySettings.GetSubtitleCharsPerSecond())).ToString());
				}
				return DialogueManager.PlaySequence(text, speaker, listener, false, false, subtitle.entrytag);
			}
			return null;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00005694 File Offset: 0x00003894
		public static IEnumerator Bark(Subtitle subtitle, Transform speaker, Transform listener, IBarkUI barkUI)
		{
			if (BarkController.CheckDontBarkDuringConversation())
			{
				yield break;
			}
			if (subtitle == null || subtitle.speakerInfo == null)
			{
				yield break;
			}
			int priority = BarkController.GetEntryBarkPriority(subtitle.dialogueEntry);
			if (priority < BarkController.GetSpeakerCurrentBarkPriority(speaker))
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' currently barking a higher priority bark", new object[]
					{
						"Dialogue System",
						speaker,
						listener,
						subtitle.formattedText.text
					}), speaker);
				}
				yield break;
			}
			BarkController.SetSpeakerCurrentBarkPriority(speaker, priority);
			BarkController.InformParticipants("OnBarkStart", speaker, listener);
			BarkController.InformParticipantsLine("OnBarkLine", speaker, subtitle);
			if (barkUI == null && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' speaker has no bark UI", new object[]
				{
					"Dialogue System",
					speaker,
					listener,
					subtitle.formattedText.text
				}), speaker);
			}
			if ((barkUI == null || !(barkUI as MonoBehaviour).enabled) && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' bark UI is null or disabled", new object[]
				{
					"Dialogue System",
					speaker,
					listener,
					subtitle.formattedText.text
				}), speaker);
			}
			if (barkUI != null && (barkUI as MonoBehaviour).enabled)
			{
				barkUI.Bark(subtitle);
			}
			Sequencer sequencer = BarkController.PlayBarkSequence(subtitle, speaker, listener);
			BarkController.LastSequencer = sequencer;
			while ((sequencer != null && sequencer.IsPlaying) || (barkUI != null && barkUI.IsPlaying))
			{
				yield return null;
			}
			if (sequencer != null)
			{
				Object.Destroy(sequencer);
			}
			BarkController.InformParticipants("OnBarkEnd", speaker, listener);
			BarkController.SetSpeakerCurrentBarkPriority(speaker, 0);
			yield break;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000056E0 File Offset: 0x000038E0
		public static IEnumerator Bark(Subtitle subtitle, bool skipSequence = false)
		{
			if (BarkController.CheckDontBarkDuringConversation())
			{
				yield break;
			}
			if (subtitle == null || subtitle.speakerInfo == null)
			{
				yield break;
			}
			Transform speaker = subtitle.speakerInfo.transform;
			Transform listener = ((subtitle.listenerInfo == null) ? null : subtitle.listenerInfo.transform);
			int priority = BarkController.GetEntryBarkPriority(subtitle.dialogueEntry);
			if (priority < BarkController.GetSpeakerCurrentBarkPriority(speaker))
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' currently barking a higher priority bark", new object[]
					{
						"Dialogue System",
						speaker,
						listener,
						subtitle.formattedText.text
					}), speaker);
				}
				yield break;
			}
			BarkController.SetSpeakerCurrentBarkPriority(speaker, priority);
			BarkController.InformParticipants("OnBarkStart", speaker, listener);
			BarkController.InformParticipantsLine("OnBarkLine", speaker, subtitle);
			IBarkUI barkUI = speaker.GetComponentInChildren(typeof(IBarkUI)) as IBarkUI;
			if (barkUI == null && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' speaker has no bark UI", new object[]
				{
					"Dialogue System",
					speaker,
					listener,
					subtitle.formattedText.text
				}), speaker);
			}
			if ((barkUI == null || !(barkUI as MonoBehaviour).enabled) && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Bark (speaker={1}, listener={2}): '{3}' bark UI is null or disabled", new object[]
				{
					"Dialogue System",
					speaker,
					listener,
					subtitle.formattedText.text
				}), speaker);
			}
			if (barkUI != null && (barkUI as MonoBehaviour).enabled)
			{
				barkUI.Bark(subtitle);
			}
			Sequencer sequencer = null;
			if (!skipSequence && !string.IsNullOrEmpty(subtitle.sequence))
			{
				sequencer = DialogueManager.PlaySequence(subtitle.sequence, speaker, listener, false, false, subtitle.entrytag);
			}
			BarkController.LastSequencer = sequencer;
			while ((sequencer != null && sequencer.IsPlaying) || (barkUI != null && barkUI.IsPlaying))
			{
				yield return null;
			}
			if (sequencer != null)
			{
				Object.Destroy(sequencer);
			}
			BarkController.InformParticipants("OnBarkEnd", speaker, listener);
			BarkController.SetSpeakerCurrentBarkPriority(speaker, 0);
			yield break;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00005710 File Offset: 0x00003910
		private static bool CheckDontBarkDuringConversation()
		{
			return DialogueManager.IsConversationActive && DialogueManager.DisplaySettings != null && DialogueManager.DisplaySettings.barkSettings != null && !DialogueManager.DisplaySettings.barkSettings.allowBarksDuringConversations;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00005758 File Offset: 0x00003958
		private static void InformParticipants(string message, Transform speaker, Transform listener)
		{
			if (speaker != null)
			{
				speaker.BroadcastMessage(message, speaker, SendMessageOptions.DontRequireReceiver);
				if (listener != null && listener != speaker)
				{
					listener.BroadcastMessage(message, speaker, SendMessageOptions.DontRequireReceiver);
				}
			}
			Transform transform = DialogueManager.Instance.transform;
			if (transform != speaker && transform != listener)
			{
				DialogueManager.Instance.BroadcastMessage(message, speaker, SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000057CC File Offset: 0x000039CC
		private static void InformParticipantsLine(string message, Transform speaker, Subtitle subtitle)
		{
			if (speaker != null)
			{
				speaker.BroadcastMessage(message, subtitle, SendMessageOptions.DontRequireReceiver);
			}
			Transform transform = DialogueManager.Instance.transform;
			if (transform != speaker)
			{
				DialogueManager.Instance.BroadcastMessage(message, subtitle, SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x04000065 RID: 101
		private static Dictionary<Transform, int> currentBarkPriority = new Dictionary<Transform, int>();
	}
}
