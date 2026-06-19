using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000052 RID: 82
	[AddComponentMenu("")]
	public class SequencerCommandAudioWaitOnce : SequencerCommand
	{
		// Token: 0x06000260 RID: 608 RVA: 0x0000CDE2 File Offset: 0x0000AFE2
		public IEnumerator Start()
		{
			string audioClipName = base.GetParameter(0, null);
			Transform subject = base.GetSubject(1, null);
			this._nextClipIndex = 2;
			if (audioClipName == null || audioClipName.Length < 1)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarningFormat("{0}: Sequencer: AudioWaitOnce(): no audio clip name given", new object[] { "Dialogue System" });
				}
				if (!this.hasNextClip())
				{
					base.Stop();
				}
			}
			if (DialogueDebug.LogInfo)
			{
				Debug.LogFormat("{0}: Sequencer: AudioWaitOnce({1})", new object[]
				{
					"Dialogue System",
					base.GetParameters()
				});
			}
			if (this.hasPlayedAlready(audioClipName) && DialogueDebug.LogInfo)
			{
				Debug.LogFormat("{0}: Sequencer: AudioWaitOnce(): clip {1} already played, skipping", new object[] { "Dialogue System", audioClipName });
				if (!this.hasNextClip())
				{
					base.Stop();
				}
			}
			this._audioSource = SequencerTools.GetAudioSource(subject);
			if (this._audioSource == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarningFormat("{0}: Sequencer: AudioWaitOnce(): can't find or add AudioSource to {1}.", new object[] { "Dialogue System", subject.name });
				}
				base.Stop();
			}
			else
			{
				this._originalClip = this._audioSource.clip;
				this._stopTime = DialogueTime.time + 1f;
				yield return null;
				this._originalClip = this._audioSource.clip;
				this.TryAudioClip(audioClipName);
			}
			yield break;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000CDF4 File Offset: 0x0000AFF4
		private void TryAudioClip(string audioClipName)
		{
			try
			{
				AudioClip audioClip = ((!string.IsNullOrEmpty(audioClipName)) ? (DialogueManager.LoadAsset(audioClipName) as AudioClip) : null);
				if (audioClip == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarningFormat("{0}: Sequencer: AudioWaitOnce(): Clip '{1}' wasn't found.", new object[] { "Dialogue System", audioClipName });
					}
				}
				else
				{
					if (base.IsAudioMuted())
					{
						if (DialogueDebug.LogInfo)
						{
							Debug.LogFormat("{0}: Sequencer: AudioWaitOnce(): waiting but not playing '{1}'; audio is muted.", new object[] { "Dialogue System", audioClipName });
						}
					}
					else
					{
						if (this.hasPlayedAlready(audioClipName))
						{
							Debug.LogFormat("{0}: Sequencer: AudioWaitOnce(): clip {1} already played, skipping", new object[] { "Dialogue System", audioClipName });
							this._stopTime = DialogueTime.time;
							return;
						}
						if (DialogueDebug.LogInfo)
						{
							Debug.LogFormat("{0}: Sequencer: AudioWaitOnce(): playing '{1}'.", new object[] { "Dialogue System", audioClipName });
						}
						this._currentClip = audioClip;
						this._audioSource.clip = audioClip;
						this._audioSource.Play();
						this.markAsPlayedAlready(audioClipName);
					}
					this._stopTime = DialogueTime.time + audioClip.length;
				}
			}
			catch (Exception)
			{
				this._stopTime = 0f;
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000CF34 File Offset: 0x0000B134
		private string buildOnceVarName(string audioClipName)
		{
			return SequencerCommandAudioWaitOnce._VarPrefix + audioClipName;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000CF44 File Offset: 0x0000B144
		private bool hasPlayedAlready(string audioClipName)
		{
			return DialogueLua.GetVariable(this.buildOnceVarName(audioClipName)).AsBool;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000CF65 File Offset: 0x0000B165
		private void markAsPlayedAlready(string audioClipName)
		{
			DialogueLua.SetVariable(this.buildOnceVarName(audioClipName), true);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000CF79 File Offset: 0x0000B179
		private bool hasNextClip()
		{
			return this._nextClipIndex < base.Parameters.Length;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000CF8B File Offset: 0x0000B18B
		public void Update()
		{
			if (DialogueTime.time >= this._stopTime)
			{
				if (this.hasNextClip())
				{
					this.TryAudioClip(base.GetParameter(this._nextClipIndex, null));
					this._nextClipIndex++;
					return;
				}
				base.Stop();
			}
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000CFCA File Offset: 0x0000B1CA
		public void OnDialogueSystemPause()
		{
			if (this._audioSource == null)
			{
				return;
			}
			this._audioSource.Pause();
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000CFE6 File Offset: 0x0000B1E6
		public void OnDialogueSystemUnpause()
		{
			if (this._audioSource == null)
			{
				return;
			}
			this._audioSource.Play();
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000D004 File Offset: 0x0000B204
		public void OnDestroy()
		{
			if (this._audioSource != null)
			{
				if (this._audioSource.isPlaying && this._audioSource.clip == this._currentClip)
				{
					this._audioSource.Stop();
				}
				if (this._restoreOriginalClip)
				{
					this._audioSource.clip = this._originalClip;
				}
			}
		}

		// Token: 0x040001FD RID: 509
		private static string _VarPrefix = "once_";

		// Token: 0x040001FE RID: 510
		private float _stopTime;

		// Token: 0x040001FF RID: 511
		private AudioSource _audioSource;

		// Token: 0x04000200 RID: 512
		private int _nextClipIndex = 2;

		// Token: 0x04000201 RID: 513
		private AudioClip _currentClip;

		// Token: 0x04000202 RID: 514
		private AudioClip _originalClip;

		// Token: 0x04000203 RID: 515
		private bool _restoreOriginalClip;
	}
}
