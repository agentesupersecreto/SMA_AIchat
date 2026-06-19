using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000238 RID: 568
	public class SequencerCommandAnimation : SequencerCommand
	{
		// Token: 0x060019B0 RID: 6576 RVA: 0x0002912C File Offset: 0x0002732C
		public void Start()
		{
			string parameter = base.GetParameter(0, null);
			this.subject = base.GetSubject(1, null);
			this.nextAnimationIndex = 2;
			this.anim = ((!(this.subject == null)) ? this.subject.GetComponent<Animation>() : null);
			if (this.subject == null || this.anim == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: Animation({1}, {2},...) command: No Animation component found on {2}.", new object[]
					{
						"Dialogue System",
						parameter,
						(!(this.subject != null)) ? base.GetParameter(1, null) : this.subject.name
					}));
				}
			}
			else if (string.IsNullOrEmpty(parameter))
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: Animation({1}, {2},...) command: Animation name is blank.", new object[]
					{
						"Dialogue System",
						parameter,
						this.subject.name
					}));
				}
			}
			else
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Sequencer: Animation({1}, {2},...)", new object[]
					{
						"Dialogue System",
						parameter,
						Tools.GetObjectName(this.subject)
					}));
				}
				this.TryAnimationClip(parameter);
			}
		}

		// Token: 0x060019B1 RID: 6577 RVA: 0x00029288 File Offset: 0x00027488
		private void TryAnimationClip(string clipName)
		{
			try
			{
				this.anim.CrossFade(clipName);
				this.stopTime = DialogueTime.time + Mathf.Max(0.1f, this.anim[clipName].length - 0.3f);
			}
			catch (Exception)
			{
				this.stopTime = 0f;
			}
		}

		// Token: 0x060019B2 RID: 6578 RVA: 0x00029300 File Offset: 0x00027500
		public void Update()
		{
			if (DialogueTime.time >= this.stopTime)
			{
				if (this.nextAnimationIndex < base.Parameters.Length)
				{
					this.TryAnimationClip(base.GetParameter(this.nextAnimationIndex, null));
					this.nextAnimationIndex++;
				}
				if (this.nextAnimationIndex >= base.Parameters.Length)
				{
					base.Stop();
				}
			}
		}

		// Token: 0x04000E27 RID: 3623
		private Transform subject;

		// Token: 0x04000E28 RID: 3624
		private int nextAnimationIndex = 2;

		// Token: 0x04000E29 RID: 3625
		private float stopTime;

		// Token: 0x04000E2A RID: 3626
		private Animation anim;
	}
}
