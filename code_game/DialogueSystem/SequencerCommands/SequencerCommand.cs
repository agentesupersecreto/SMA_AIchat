using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000237 RID: 567
	public abstract class SequencerCommand : MonoBehaviour
	{
		// Token: 0x17000A45 RID: 2629
		// (get) Token: 0x0600199B RID: 6555 RVA: 0x00028FE8 File Offset: 0x000271E8
		// (set) Token: 0x0600199C RID: 6556 RVA: 0x00028FF0 File Offset: 0x000271F0
		public bool IsPlaying { get; protected set; }

		// Token: 0x17000A46 RID: 2630
		// (get) Token: 0x0600199D RID: 6557 RVA: 0x00028FFC File Offset: 0x000271FC
		// (set) Token: 0x0600199E RID: 6558 RVA: 0x00029004 File Offset: 0x00027204
		private protected Sequencer Sequencer { protected get; private set; }

		// Token: 0x17000A47 RID: 2631
		// (get) Token: 0x0600199F RID: 6559 RVA: 0x00029010 File Offset: 0x00027210
		// (set) Token: 0x060019A0 RID: 6560 RVA: 0x00029018 File Offset: 0x00027218
		private protected string[] Parameters { protected get; private set; }

		// Token: 0x17000A48 RID: 2632
		// (get) Token: 0x060019A1 RID: 6561 RVA: 0x00029024 File Offset: 0x00027224
		// (set) Token: 0x060019A2 RID: 6562 RVA: 0x0002902C File Offset: 0x0002722C
		public string endMessage { get; private set; }

		// Token: 0x060019A3 RID: 6563 RVA: 0x00029038 File Offset: 0x00027238
		public void Initialize(Sequencer sequencer, string endMessage, params string[] parameters)
		{
			this.Sequencer = sequencer;
			this.endMessage = endMessage;
			this.Parameters = parameters;
			this.IsPlaying = true;
		}

		// Token: 0x060019A4 RID: 6564 RVA: 0x00029064 File Offset: 0x00027264
		public void Initialize(Sequencer sequencer, params string[] parameters)
		{
			this.Initialize(sequencer, null, parameters);
		}

		// Token: 0x060019A5 RID: 6565 RVA: 0x00029070 File Offset: 0x00027270
		protected void Stop()
		{
			this.IsPlaying = false;
		}

		// Token: 0x060019A6 RID: 6566 RVA: 0x0002907C File Offset: 0x0002727C
		protected Transform GetSubject(string specifier, Transform defaultSubject = null)
		{
			return SequencerTools.GetSubject(specifier, this.Sequencer.Speaker, this.Sequencer.Listener, defaultSubject);
		}

		// Token: 0x060019A7 RID: 6567 RVA: 0x000290A8 File Offset: 0x000272A8
		protected Transform GetSubject(int i, Transform defaultSubject = null)
		{
			return this.GetSubject(this.GetParameter(i, null), defaultSubject);
		}

		// Token: 0x060019A8 RID: 6568 RVA: 0x000290BC File Offset: 0x000272BC
		protected string GetParameter(int i, string defaultValue = null)
		{
			return SequencerTools.GetParameter(this.Parameters, i, defaultValue);
		}

		// Token: 0x060019A9 RID: 6569 RVA: 0x000290CC File Offset: 0x000272CC
		protected T GetParameterAs<T>(int i, T defaultValue)
		{
			return SequencerTools.GetParameterAs<T>(this.Parameters, i, defaultValue);
		}

		// Token: 0x060019AA RID: 6570 RVA: 0x000290DC File Offset: 0x000272DC
		protected float GetParameterAsFloat(int i, float defaultValue = 0f)
		{
			return this.GetParameterAs<float>(i, defaultValue);
		}

		// Token: 0x060019AB RID: 6571 RVA: 0x000290E8 File Offset: 0x000272E8
		protected int GetParameterAsInt(int i, int defaultValue = 0)
		{
			return this.GetParameterAs<int>(i, defaultValue);
		}

		// Token: 0x060019AC RID: 6572 RVA: 0x000290F4 File Offset: 0x000272F4
		protected bool GetParameterAsBool(int i, bool defaultValue = false)
		{
			return this.GetParameterAs<bool>(i, defaultValue);
		}

		// Token: 0x060019AD RID: 6573 RVA: 0x00029100 File Offset: 0x00027300
		protected string GetParameters()
		{
			return string.Join(",", this.Parameters);
		}

		// Token: 0x060019AE RID: 6574 RVA: 0x00029114 File Offset: 0x00027314
		protected bool IsAudioMuted()
		{
			return SequencerTools.IsAudioMuted();
		}
	}
}
