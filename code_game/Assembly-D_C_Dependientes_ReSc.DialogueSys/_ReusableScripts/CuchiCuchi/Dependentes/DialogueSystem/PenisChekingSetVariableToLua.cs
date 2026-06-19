using System;
using PixelCrushers.DialogueSystem;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x0200001C RID: 28
	public class PenisChekingSetVariableToLua : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00005808 File Offset: 0x00003A08
		public sealed override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000580B File Offset: 0x00003A0B
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_penis = this.GetComponentEnCharacter(false);
			if (this.m_penis == null)
			{
				throw new ArgumentNullException("m_penis", "m_penis null reference.");
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000583E File Offset: 0x00003A3E
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.n_lastState = null;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00005854 File Offset: 0x00003A54
		public sealed override void OnUpdateEvent1()
		{
			bool flag = !this.m_penis.isActiveAndEnabled || !this.m_penis.isStared || this.m_penis.hidden;
			if (this.n_lastState == null || flag != this.n_lastState.Value)
			{
				this.n_lastState = new bool?(flag);
				DialogueLua.SetActorField("Player", "PeneAfuera", !flag);
			}
		}

		// Token: 0x04000077 RID: 119
		private bool? n_lastState;

		// Token: 0x04000078 RID: 120
		private Penis m_penis;
	}
}
