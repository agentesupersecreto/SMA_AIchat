using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000005 RID: 5
	public class BarkMixerBehaviour : PlayableBehaviour
	{
		// Token: 0x06000008 RID: 8 RVA: 0x0000214C File Offset: 0x0000034C
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
					BarkBehaviour behaviour = ((ScriptPlayable<T>)playable.GetInput(i)).GetBehaviour();
					if (Application.isPlaying)
					{
						if (behaviour.useConversation)
						{
							DialogueManager.Bark(behaviour.conversation, gameObject.transform, behaviour.listener);
						}
						else
						{
							DialogueManager.BarkString(behaviour.text, gameObject.transform, behaviour.listener, null);
						}
					}
					else
					{
						PreviewUI.ShowMessage(OverrideActorName.GetActorName(gameObject.transform) + " bark: " + behaviour.GetEditorBarkText(), 2f, 1);
					}
				}
				else if (inputWeight <= 0.001f && this.played.Contains(i))
				{
					this.played.Remove(i);
				}
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000225D File Offset: 0x0000045D
		public override void OnGraphStart(Playable playable)
		{
			base.OnGraphStart(playable);
			this.played.Clear();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002271 File Offset: 0x00000471
		public override void OnGraphStop(Playable playable)
		{
			base.OnGraphStop(playable);
			this.played.Clear();
		}

		// Token: 0x04000007 RID: 7
		private HashSet<int> played = new HashSet<int>();
	}
}
