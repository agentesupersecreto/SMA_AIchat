using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000053 RID: 83
	[AddComponentMenu("")]
	public class SequencerCommandAudioWWW : SequencerCommand
	{
		// Token: 0x0600026C RID: 620 RVA: 0x0000D084 File Offset: 0x0000B284
		public void Start()
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: AudioWWW({1}).", new object[]
				{
					"Dialogue System",
					string.Join(", ", base.Parameters)
				}));
			}
			for (int i = 0; i < base.Parameters.Length - 1; i++)
			{
				string parameter = base.GetParameter(i, null);
				if (!string.IsNullOrEmpty(parameter))
				{
					this.audioURLs.Enqueue(parameter);
				}
			}
			Transform transform = null;
			string text = ((base.Parameters.Length != 0) ? base.GetParameter(base.Parameters.Length - 1, null) : string.Empty);
			if (!string.IsNullOrEmpty(text))
			{
				transform = base.GetSubject(base.Parameters.Length - 1, null);
				if (transform == null)
				{
					transform = base.Sequencer.Speaker;
					this.audioURLs.Enqueue(text);
				}
			}
			if (this.audioURLs.Count == 0)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: AudioWWW(): No URLs specified.", new object[] { "Dialogue System" }));
				}
				base.Stop();
				return;
			}
			AudioSource audioSource = SequencerTools.GetAudioSource(transform);
			if (audioSource == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: AudioWWW(): can't find or add AudioSource to {1}.", new object[]
					{
						"Dialogue System",
						Tools.GetGameObjectName(transform)
					}));
				}
				base.Stop();
				return;
			}
			if (Tools.ApproximatelyZero(audioSource.volume))
			{
				audioSource.volume = 1f;
			}
			if (base.IsAudioMuted() && DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: AudioWWW({1}): audio is muted; waiting but not playing.", new object[]
				{
					"Dialogue System",
					string.Join(", ", base.Parameters)
				}));
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000D230 File Offset: 0x0000B430
		public void Update()
		{
			switch (this.state)
			{
			case SequencerCommandAudioWWW.State.Idle:
				this.LoadNextAudio();
				return;
			case SequencerCommandAudioWWW.State.Loading:
				this.CheckLoadProgress();
				return;
			case SequencerCommandAudioWWW.State.Playing:
				this.CheckPlayProgress();
				return;
			default:
				return;
			}
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000D26C File Offset: 0x0000B46C
		private void LoadNextAudio()
		{
			if (this.audioURLs.Count > 0)
			{
				string text = this.audioURLs.Dequeue();
				if (!string.IsNullOrEmpty(text))
				{
					if (text.EndsWith(".ogg", StringComparison.OrdinalIgnoreCase))
					{
						if (DialogueDebug.LogInfo)
						{
							Debug.Log(string.Format("{0}: AudioWWW(): Retrieving {1}", new object[] { "Dialogue System", text }));
						}
						this.www = new WWW(text);
						if (this.www != null)
						{
							this.state = SequencerCommandAudioWWW.State.Loading;
							return;
						}
						if (DialogueDebug.LogInfo)
						{
							Debug.Log(string.Format("{0}: AudioWWW(): Failed to retrieve {1}", new object[] { "Dialogue System", text }));
							return;
						}
					}
					else if (DialogueDebug.LogWarnings)
					{
						Debug.Log(string.Format("{0}: AudioWWW(): Sorry, the player only supports .ogg files. Can't load {1}", new object[] { "Dialogue System", text }));
						return;
					}
				}
			}
			else
			{
				base.Stop();
			}
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000D34C File Offset: 0x0000B54C
		private void CheckLoadProgress()
		{
			if (this.www.isDone)
			{
				AudioClip audioClip = this.www.GetAudioClip(false);
				if (audioClip != null)
				{
					if (!base.IsAudioMuted())
					{
						this.audioSource.PlayOneShot(audioClip);
					}
					this.stopTime = DialogueTime.time + audioClip.length;
					this.state = SequencerCommandAudioWWW.State.Playing;
					return;
				}
				this.state = SequencerCommandAudioWWW.State.Idle;
			}
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000D3B1 File Offset: 0x0000B5B1
		private void CheckPlayProgress()
		{
			if (DialogueTime.time >= this.stopTime)
			{
				this.state = SequencerCommandAudioWWW.State.Idle;
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000D3C7 File Offset: 0x0000B5C7
		private void OnDestroy()
		{
			if (this.audioSource != null && this.audioSource.isPlaying)
			{
				this.audioSource.Stop();
			}
		}

		// Token: 0x04000204 RID: 516
		private SequencerCommandAudioWWW.State state;

		// Token: 0x04000205 RID: 517
		private AudioSource audioSource;

		// Token: 0x04000206 RID: 518
		private Queue<string> audioURLs = new Queue<string>();

		// Token: 0x04000207 RID: 519
		private WWW www;

		// Token: 0x04000208 RID: 520
		private float stopTime;

		// Token: 0x02000095 RID: 149
		private enum State
		{
			// Token: 0x040002EF RID: 751
			Idle,
			// Token: 0x040002F0 RID: 752
			Loading,
			// Token: 0x040002F1 RID: 753
			Playing
		}
	}
}
