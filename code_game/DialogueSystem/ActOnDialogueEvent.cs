using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200027F RID: 639
	[AddComponentMenu("")]
	public abstract class ActOnDialogueEvent : MonoBehaviour
	{
		// Token: 0x06001B95 RID: 7061 RVA: 0x00031FC8 File Offset: 0x000301C8
		public void OnBarkStart(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueEvent.OnBark)
			{
				this.TryStartActions(actor);
			}
		}

		// Token: 0x06001B96 RID: 7062 RVA: 0x00031FE8 File Offset: 0x000301E8
		public void OnBarkEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueEvent.OnBark)
			{
				this.TryEndActions(actor);
				this.DestroyIfOnce();
			}
		}

		// Token: 0x06001B97 RID: 7063 RVA: 0x0003201C File Offset: 0x0003021C
		public void OnConversationStart(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueEvent.OnConversation)
			{
				this.TryStartActions(actor);
			}
		}

		// Token: 0x06001B98 RID: 7064 RVA: 0x0003203C File Offset: 0x0003023C
		public void OnConversationEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueEvent.OnConversation)
			{
				this.TryEndActions(actor);
				this.DestroyIfOnce();
			}
		}

		// Token: 0x06001B99 RID: 7065 RVA: 0x00032070 File Offset: 0x00030270
		public void OnSequenceStart(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueEvent.OnSequence)
			{
				this.TryStartActions(actor);
			}
		}

		// Token: 0x06001B9A RID: 7066 RVA: 0x00032090 File Offset: 0x00030290
		public void OnSequenceEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueEvent.OnSequence)
			{
				this.TryEndActions(actor);
				this.DestroyIfOnce();
			}
		}

		// Token: 0x06001B9B RID: 7067
		public abstract void TryStartActions(Transform actor);

		// Token: 0x06001B9C RID: 7068
		public abstract void TryEndActions(Transform actor);

		// Token: 0x06001B9D RID: 7069 RVA: 0x000320C4 File Offset: 0x000302C4
		private void DestroyIfOnce()
		{
			if (this.once)
			{
				Object.Destroy(this);
			}
		}

		// Token: 0x04000F89 RID: 3977
		[Tooltip("Trigger when this dialogue event occurs.")]
		public DialogueEvent trigger;

		// Token: 0x04000F8A RID: 3978
		[Tooltip("Destroy this component after triggering. If you need to remember across scene changes and saved games, use a Condition instead.")]
		public bool once;

		// Token: 0x04000F8B RID: 3979
		[HideInInspector]
		public DialogueDatabase selectedDatabase;

		// Token: 0x02000280 RID: 640
		[Serializable]
		public class Action
		{
			// Token: 0x04000F8C RID: 3980
			public Condition condition = new Condition();
		}
	}
}
