using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200000B RID: 11
	public class QuestStateMixerBehaviour : PlayableBehaviour
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00002484 File Offset: 0x00000684
		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
			int inputCount = playable.GetInputCount<Playable>();
			for (int i = 0; i < inputCount; i++)
			{
				float inputWeight = playable.GetInputWeight(i);
				if (inputWeight > 0.001f && !this.played.Contains(i))
				{
					this.played.Add(i);
					SetQuestStateBehaviour behaviour = ((ScriptPlayable<T>)playable.GetInput(i)).GetBehaviour();
					if (Application.isPlaying)
					{
						if (behaviour.setQuestState)
						{
							QuestLog.SetQuestState(behaviour.quest, behaviour.questState);
						}
						if (behaviour.setQuestEntryState)
						{
							QuestLog.SetQuestEntryState(behaviour.quest, behaviour.questEntryNumber, behaviour.questEntryState);
						}
					}
					else
					{
						string text = string.Empty;
						if (behaviour.setQuestState)
						{
							text = "Set quest " + behaviour.quest + " to " + behaviour.questState.ToString();
							if (behaviour.setQuestEntryState)
							{
								text = string.Concat(new string[]
								{
									text,
									" and entry #",
									behaviour.questEntryNumber.ToString(),
									" to ",
									behaviour.questEntryState.ToString()
								});
							}
						}
						else if (behaviour.setQuestEntryState)
						{
							text = string.Concat(new string[]
							{
								"Set quest ",
								behaviour.quest,
								" entry #",
								behaviour.questEntryNumber.ToString(),
								" to ",
								behaviour.questEntryState.ToString()
							});
						}
						if (!string.IsNullOrEmpty(text))
						{
							PreviewUI.ShowMessage(text, 2f, -2);
						}
					}
				}
				else if (inputWeight <= 0.001f && this.played.Contains(i))
				{
					this.played.Remove(i);
				}
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002665 File Offset: 0x00000865
		public override void OnGraphStart(Playable playable)
		{
			base.OnGraphStart(playable);
			this.played.Clear();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002679 File Offset: 0x00000879
		public override void OnGraphStop(Playable playable)
		{
			base.OnGraphStop(playable);
			this.played.Clear();
		}

		// Token: 0x0400000F RID: 15
		private HashSet<int> played = new HashSet<int>();
	}
}
