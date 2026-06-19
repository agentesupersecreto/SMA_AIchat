using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000007 RID: 7
	public class ConversationMixerBehaviour : PlayableBehaviour
	{
		// Token: 0x0600000E RID: 14 RVA: 0x000022B0 File Offset: 0x000004B0
		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
			GameObject gameObject = playerData as GameObject;
			if (!gameObject)
			{
				return;
			}
			int inputCount = playable.GetInputCount<Playable>();
			for (int i = 0; i < inputCount; i++)
			{
				float inputWeight = playable.GetInputWeight(i);
				if (inputWeight > 0.001f && !this.played.Contains(i))
				{
					this.played.Add(i);
					StartConversationBehaviour behaviour = ((ScriptPlayable<T>)playable.GetInput(i)).GetBehaviour();
					if (Application.isPlaying)
					{
						if (behaviour.entryID <= 0)
						{
							DialogueManager.StartConversation(behaviour.conversation, gameObject.transform, behaviour.conversant);
						}
						else
						{
							DialogueManager.StartConversation(behaviour.conversation, gameObject.transform, behaviour.conversant, behaviour.entryID);
						}
					}
					else
					{
						string actorName = OverrideActorName.GetActorName(gameObject.transform);
						string text = " conversation: ";
						Transform conversant = behaviour.conversant;
						PreviewUI.ShowMessage(actorName + text + ((conversant != null) ? conversant.ToString() : null), 2f, 0);
					}
				}
				else if (inputWeight <= 0.001f && this.played.Contains(i))
				{
					this.played.Remove(i);
				}
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000023D4 File Offset: 0x000005D4
		public override void OnGraphStart(Playable playable)
		{
			base.OnGraphStart(playable);
			this.played.Clear();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000023E8 File Offset: 0x000005E8
		public override void OnGraphStop(Playable playable)
		{
			base.OnGraphStop(playable);
			this.played.Clear();
		}

		// Token: 0x04000008 RID: 8
		private HashSet<int> played = new HashSet<int>();
	}
}
