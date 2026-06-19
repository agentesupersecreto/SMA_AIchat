using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000056 RID: 86
	public class SequencerCommandTimeline : SequencerCommand
	{
		// Token: 0x06000277 RID: 631 RVA: 0x0000D524 File Offset: 0x0000B724
		public IEnumerator Start()
		{
			string text = base.GetParameter(0, null).ToLower();
			Transform subject = base.GetSubject(1, base.Sequencer.Speaker);
			bool flag = string.Equals(base.GetParameter(2, null), "nowait", StringComparison.OrdinalIgnoreCase) || string.Equals(base.GetParameter(3, null), "nowait", StringComparison.OrdinalIgnoreCase);
			this.nostop = string.Equals(base.GetParameter(2, null), "nostop", StringComparison.OrdinalIgnoreCase) || string.Equals(base.GetParameter(3, null), "nostop", StringComparison.OrdinalIgnoreCase);
			this.playableDirector = ((subject != null) ? subject.GetComponent<PlayableDirector>() : null);
			this.timelineAsset = DialogueManager.LoadAsset(base.GetParameter(1, null), typeof(TimelineAsset)) as TimelineAsset;
			if (this.timelineAsset != null)
			{
				this.playableDirector = new GameObject(base.GetParameter(1, null), new Type[] { typeof(PlayableDirector) }).GetComponent<PlayableDirector>();
				this.playableDirector.playableAsset = this.timelineAsset;
				this.mustDestroyPlayableDirector = true;
			}
			if (this.playableDirector == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Concat(new string[]
					{
						"Dialogue System: Sequencer: Timeline(",
						base.GetParameters(),
						"): Can't find playable director '",
						base.GetParameter(0, null),
						"'."
					}));
				}
			}
			else if (this.playableDirector.playableAsset == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning("Dialogue System: Sequencer: Timeline(" + base.GetParameters() + "): No timeline asset is assigned to the Playable Director.", this.playableDirector);
				}
			}
			else if (!(text == "play") && !(text == "pause") && !(text == "resume") && !(text == "stop"))
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Concat(new string[]
					{
						"Dialogue System: Sequencer: Timeline(",
						base.GetParameters(),
						"): Invalid mode '",
						text,
						"'. Expected 'play', 'pause', 'resume', or 'stop'."
					}));
				}
			}
			else
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log("Dialogue System: Sequencer: Timeline(" + base.GetParameters() + ")");
				}
				TimelineAsset timelineAsset = this.playableDirector.playableAsset as TimelineAsset;
				if (timelineAsset != null)
				{
					for (int i = 2; i < base.Parameters.Length; i++)
					{
						string parameter = base.GetParameter(i, null);
						if (parameter.Contains(":"))
						{
							int num = parameter.IndexOf(":");
							int num2 = Tools.StringToInt(parameter.Substring(0, num));
							string text2 = parameter.Substring(num + 1);
							TrackAsset outputTrack = timelineAsset.GetOutputTrack(num2);
							if (outputTrack != null)
							{
								this.playableDirector.SetGenericBinding(outputTrack, Tools.GameObjectHardFind(text2));
							}
						}
					}
				}
				if (!(text == "play"))
				{
					if (!(text == "pause"))
					{
						if (!(text == "resume"))
						{
							if (text == "stop")
							{
								this.playableDirector.Stop();
								this.nostop = false;
							}
						}
						else
						{
							this.playableDirector.Resume();
							double resumedEndTime = (flag ? 0.0 : ((double)DialogueTime.time + this.playableDirector.playableAsset.duration - this.playableDirector.time));
							while ((double)DialogueTime.time < resumedEndTime)
							{
								yield return null;
							}
						}
					}
					else
					{
						this.playableDirector.Pause();
						this.nostop = true;
					}
				}
				else
				{
					this.playableDirector.Play();
					double endTime = (flag ? 0.0 : ((double)DialogueTime.time + this.playableDirector.playableAsset.duration));
					while ((double)DialogueTime.time < endTime)
					{
						yield return null;
					}
				}
			}
			base.Stop();
			yield break;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000D533 File Offset: 0x0000B733
		public void OnDestroy()
		{
			if (this.playableDirector != null && !this.nostop)
			{
				this.playableDirector.Stop();
				if (this.mustDestroyPlayableDirector)
				{
					Object.Destroy(this.playableDirector.gameObject);
				}
			}
		}

		// Token: 0x04000209 RID: 521
		private PlayableDirector playableDirector;

		// Token: 0x0400020A RID: 522
		private TimelineAsset timelineAsset;

		// Token: 0x0400020B RID: 523
		private bool nostop;

		// Token: 0x0400020C RID: 524
		private bool mustDestroyPlayableDirector;
	}
}
