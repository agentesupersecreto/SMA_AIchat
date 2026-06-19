using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000246 RID: 582
	[AddComponentMenu("")]
	public class SequencerCommandVoice : SequencerCommand
	{
		// Token: 0x060019EA RID: 6634 RVA: 0x0002B440 File Offset: 0x00029640
		public void Start()
		{
			string parameter = base.GetParameter(0, null);
			string parameter2 = base.GetParameter(1, null);
			this.finalClipName = base.GetParameter(2, null);
			this.subject = base.GetSubject(3, null);
			this.anim = ((!(this.subject == null)) ? this.subject.GetComponent<Animation>() : null);
			AudioClip audioClip = (string.IsNullOrEmpty(parameter) ? null : (DialogueManager.LoadAsset(parameter) as AudioClip));
			if (this.subject == null || this.anim == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: Voice({1}, {2}, {3}, {4}) command: No Animation component found on {3}.", new object[]
					{
						"Dialogue System",
						parameter,
						parameter2,
						this.finalClipName,
						(!(this.subject != null)) ? base.GetParameter(2, null) : this.subject.name
					}));
				}
			}
			else if (audioClip == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: Voice({1}, {2}, {3}, {4}) command: Clip is null.", new object[]
					{
						"Dialogue System",
						parameter,
						parameter2,
						this.finalClipName,
						this.subject.name
					}));
				}
			}
			else if (string.IsNullOrEmpty(parameter2))
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: Voice({1}, {2}, {3}, {4}) command: Animation name is blank.", new object[]
					{
						"Dialogue System",
						parameter,
						parameter2,
						this.finalClipName,
						this.subject.name
					}));
				}
			}
			else
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Sequencer: Voice({1}, {2}, {3}, {4})", new object[]
					{
						"Dialogue System",
						parameter,
						parameter2,
						this.finalClipName,
						Tools.GetObjectName(this.subject)
					}));
				}
				this.audioSource = SequencerTools.GetAudioSource(this.subject);
				if (this.audioSource == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: Voice() command: can't find or add AudioSource to {1}.", new object[]
						{
							"Dialogue System",
							this.subject.name
						}));
					}
				}
				else
				{
					if (base.IsAudioMuted())
					{
						if (DialogueDebug.LogInfo)
						{
							Debug.Log(string.Format("{0}: Sequencer: Voice({1}, {2}, {3}, {4}): Audio is muted; not playing it.", new object[]
							{
								"Dialogue System",
								parameter,
								parameter2,
								this.finalClipName,
								Tools.GetObjectName(this.subject)
							}));
						}
					}
					else
					{
						this.audioSource.clip = audioClip;
						this.audioSource.Play();
					}
					this.anim.CrossFade(parameter2);
					try
					{
						this.stopTime = DialogueTime.time + Mathf.Max(0.1f, this.anim[parameter2].length - 0.3f);
						if (audioClip.length > this.anim[parameter2].length)
						{
							this.stopTime = DialogueTime.time + audioClip.length;
						}
					}
					catch (Exception)
					{
						this.stopTime = 0f;
					}
				}
			}
		}

		// Token: 0x060019EB RID: 6635 RVA: 0x0002B7A0 File Offset: 0x000299A0
		public void Update()
		{
			if (DialogueTime.time >= this.stopTime)
			{
				base.Stop();
			}
		}

		// Token: 0x060019EC RID: 6636 RVA: 0x0002B7B8 File Offset: 0x000299B8
		public void OnDialogueSystemPause()
		{
			if (this.audioSource == null)
			{
				return;
			}
			this.audioSource.Pause();
		}

		// Token: 0x060019ED RID: 6637 RVA: 0x0002B7D8 File Offset: 0x000299D8
		public void OnDialogueSystemUnpause()
		{
			if (this.audioSource == null)
			{
				return;
			}
			this.audioSource.Play();
		}

		// Token: 0x060019EE RID: 6638 RVA: 0x0002B7F8 File Offset: 0x000299F8
		public void OnDestroy()
		{
			if (this.subject != null && this.anim != null)
			{
				if (!string.IsNullOrEmpty(this.finalClipName))
				{
					this.anim.CrossFade(this.finalClipName);
				}
				else if (this.anim.clip != null)
				{
					this.anim.CrossFade(this.anim.clip.name);
				}
			}
			if (this.audioSource != null && DialogueTime.time < this.stopTime)
			{
				this.audioSource.Stop();
			}
		}

		// Token: 0x04000E82 RID: 3714
		private float stopTime;

		// Token: 0x04000E83 RID: 3715
		private Transform subject;

		// Token: 0x04000E84 RID: 3716
		private string finalClipName = string.Empty;

		// Token: 0x04000E85 RID: 3717
		private Animation anim;

		// Token: 0x04000E86 RID: 3718
		private AudioSource audioSource;
	}
}
