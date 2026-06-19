using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200000F RID: 15
	public class AlertMixerBehaviour : PlayableBehaviour
	{
		// Token: 0x06000022 RID: 34 RVA: 0x000026E8 File Offset: 0x000008E8
		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
			int inputCount = playable.GetInputCount<Playable>();
			for (int i = 0; i < inputCount; i++)
			{
				float inputWeight = playable.GetInputWeight(i);
				if (inputWeight > 0.001f && !this.played.Contains(i))
				{
					this.played.Add(i);
					ScriptPlayable<ShowAlertBehaviour> scriptPlayable = (ScriptPlayable<T>)playable.GetInput(i);
					ShowAlertBehaviour behaviour = scriptPlayable.GetBehaviour();
					string message = behaviour.message;
					float num = (behaviour.useTextLengthForDuration ? 0f : ((float)scriptPlayable.GetDuration<ScriptPlayable<ShowAlertBehaviour>>()));
					if (Application.isPlaying)
					{
						DialogueManager.ShowAlert(message, num);
					}
					else
					{
						PreviewUI.ShowMessage(message, num, -1);
					}
				}
				else if (inputWeight <= 0.001f && this.played.Contains(i))
				{
					this.played.Remove(i);
				}
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000027AD File Offset: 0x000009AD
		public override void OnGraphStart(Playable playable)
		{
			base.OnGraphStart(playable);
			this.played.Clear();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000027C1 File Offset: 0x000009C1
		public override void OnGraphStop(Playable playable)
		{
			base.OnGraphStop(playable);
			this.played.Clear();
		}

		// Token: 0x04000017 RID: 23
		private HashSet<int> played = new HashSet<int>();
	}
}
