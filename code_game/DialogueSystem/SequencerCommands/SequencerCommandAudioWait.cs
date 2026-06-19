using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200023C RID: 572
	[AddComponentMenu("")]
	public class SequencerCommandAudioWait : SequencerCommand
	{
		// Token: 0x060019C0 RID: 6592 RVA: 0x00029AA4 File Offset: 0x00027CA4
		public IEnumerator Start()
		{
			string audioClipName = base.GetParameter(0, null);
			Transform subject = base.GetSubject(1, null);
			this.nextClipIndex = 2;
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: AudioWait({1})", new object[]
				{
					"Dialogue System",
					base.GetParameters()
				}));
			}
			this.audioSource = SequencerTools.GetAudioSource(subject);
			if (this.audioSource == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: AudioWait() command: can't find or add AudioSource to {1}.", new object[] { "Dialogue System", subject.name }));
				}
				base.Stop();
			}
			else
			{
				this.originalClip = this.audioSource.clip;
				this.stopTime = DialogueTime.time + 1f;
				yield return null;
				this.originalClip = this.audioSource.clip;
				this.TryAudioClip(audioClipName);
			}
			yield break;
		}

		// Token: 0x060019C1 RID: 6593 RVA: 0x00029AC0 File Offset: 0x00027CC0
		private void TryAudioClip(string audioClipName)
		{
			try
			{
				AudioClip audioClip = (string.IsNullOrEmpty(audioClipName) ? null : (DialogueManager.LoadAsset(audioClipName) as AudioClip));
				if (audioClip == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: AudioWait() command: Clip '{1}' wasn't found.", new object[] { "Dialogue System", audioClipName }));
					}
				}
				else if (base.IsAudioMuted())
				{
					if (DialogueDebug.LogInfo)
					{
						Debug.Log(string.Format("{0}: Sequencer: AudioWait(): waiting but not playing '{1}'; audio is muted.", new object[] { "Dialogue System", audioClipName }));
					}
				}
				else
				{
					if (DialogueDebug.LogInfo)
					{
						Debug.Log(string.Format("{0}: Sequencer: AudioWait(): playing '{1}'.", new object[] { "Dialogue System", audioClipName }));
					}
					this.currentClip = audioClip;
					this.audioSource.clip = audioClip;
					this.audioSource.Play();
				}
				this.stopTime = DialogueTime.time + audioClip.length;
			}
			catch (Exception)
			{
				this.stopTime = 0f;
			}
		}

		// Token: 0x060019C2 RID: 6594 RVA: 0x00029BF0 File Offset: 0x00027DF0
		public void Update()
		{
			if (DialogueTime.time >= this.stopTime)
			{
				if (this.nextClipIndex < base.Parameters.Length)
				{
					this.TryAudioClip(base.GetParameter(this.nextClipIndex, null));
					this.nextClipIndex++;
				}
				else
				{
					base.Stop();
				}
			}
		}

		// Token: 0x060019C3 RID: 6595 RVA: 0x00029C4C File Offset: 0x00027E4C
		public void OnDialogueSystemPause()
		{
			if (this.audioSource == null)
			{
				return;
			}
			this.audioSource.Pause();
		}

		// Token: 0x060019C4 RID: 6596 RVA: 0x00029C6C File Offset: 0x00027E6C
		public void OnDialogueSystemUnpause()
		{
			if (this.audioSource == null)
			{
				return;
			}
			this.audioSource.Play();
		}

		// Token: 0x060019C5 RID: 6597 RVA: 0x00029C8C File Offset: 0x00027E8C
		public void OnDestroy()
		{
			if (this.audioSource != null)
			{
				if (this.audioSource.isPlaying && this.audioSource.clip == this.currentClip)
				{
					this.audioSource.Stop();
				}
				if (this.restoreOriginalClip)
				{
					this.audioSource.clip = this.originalClip;
				}
			}
		}

		// Token: 0x04000E3E RID: 3646
		private float stopTime;

		// Token: 0x04000E3F RID: 3647
		private AudioSource audioSource;

		// Token: 0x04000E40 RID: 3648
		private int nextClipIndex = 2;

		// Token: 0x04000E41 RID: 3649
		private AudioClip currentClip;

		// Token: 0x04000E42 RID: 3650
		private AudioClip originalClip;

		// Token: 0x04000E43 RID: 3651
		private bool restoreOriginalClip;
	}
}
