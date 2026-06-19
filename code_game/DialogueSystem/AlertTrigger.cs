using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200029A RID: 666
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/alert_trigger.html")]
	[AddComponentMenu("Dialogue System/Trigger/Alert Trigger")]
	public class AlertTrigger : DialogueEventStarter
	{
		// Token: 0x06001BF2 RID: 7154 RVA: 0x00032F14 File Offset: 0x00031114
		public void OnBarkEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnBarkEnd)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001BF3 RID: 7155 RVA: 0x00032F34 File Offset: 0x00031134
		public void OnConversationEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnConversationEnd)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001BF4 RID: 7156 RVA: 0x00032F54 File Offset: 0x00031154
		public void OnSequenceEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnSequenceEnd)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001BF5 RID: 7157 RVA: 0x00032F74 File Offset: 0x00031174
		public void OnUse(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001BF6 RID: 7158 RVA: 0x00032F98 File Offset: 0x00031198
		public void OnUse(string message)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001BF7 RID: 7159 RVA: 0x00032FBC File Offset: 0x000311BC
		public void OnUse()
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001BF8 RID: 7160 RVA: 0x00032FE0 File Offset: 0x000311E0
		public void OnTriggerEnter(Collider other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001BF9 RID: 7161 RVA: 0x00033008 File Offset: 0x00031208
		public void OnTriggerEnter2D(Collider2D other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001BFA RID: 7162 RVA: 0x00033030 File Offset: 0x00031230
		public void OnTriggerExit(Collider other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001BFB RID: 7163 RVA: 0x0003305C File Offset: 0x0003125C
		public void OnTriggerExit2D(Collider2D other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001BFC RID: 7164 RVA: 0x00033088 File Offset: 0x00031288
		public void OnCollisionEnter(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnCollisionEnter)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001BFD RID: 7165 RVA: 0x000330C4 File Offset: 0x000312C4
		public void OnCollisionEnter2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001BFE RID: 7166 RVA: 0x000330FC File Offset: 0x000312FC
		public void OnCollisionExit(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001BFF RID: 7167 RVA: 0x00033138 File Offset: 0x00031338
		public void OnCollisionExit2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001C00 RID: 7168 RVA: 0x00033174 File Offset: 0x00031374
		public void Start()
		{
			if (this.trigger == DialogueTriggerEvent.OnStart)
			{
				base.StartCoroutine(this.StartAfterOneFrame());
			}
		}

		// Token: 0x06001C01 RID: 7169 RVA: 0x00033190 File Offset: 0x00031390
		public void OnEnable()
		{
			this.listenForOnDestroy = true;
			if (this.trigger == DialogueTriggerEvent.OnEnable)
			{
				base.StartCoroutine(this.StartAfterOneFrame());
			}
		}

		// Token: 0x06001C02 RID: 7170 RVA: 0x000331B4 File Offset: 0x000313B4
		public void OnDisable()
		{
			if (!this.listenForOnDestroy)
			{
				return;
			}
			if (this.trigger == DialogueTriggerEvent.OnDisable)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001C03 RID: 7171 RVA: 0x000331DC File Offset: 0x000313DC
		public void OnLevelWillBeUnloaded()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06001C04 RID: 7172 RVA: 0x000331E8 File Offset: 0x000313E8
		public void OnApplicationQuit()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06001C05 RID: 7173 RVA: 0x000331F4 File Offset: 0x000313F4
		public void OnDestroy()
		{
			if (!this.listenForOnDestroy)
			{
				return;
			}
			if (this.trigger == DialogueTriggerEvent.OnDestroy)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001C06 RID: 7174 RVA: 0x0003321C File Offset: 0x0003141C
		private IEnumerator StartAfterOneFrame()
		{
			yield return null;
			this.TryStart(null);
			yield break;
		}

		// Token: 0x06001C07 RID: 7175 RVA: 0x00033238 File Offset: 0x00031438
		public void TryStart(Transform actor)
		{
			if (this.tryingToStart)
			{
				return;
			}
			this.tryingToStart = true;
			try
			{
				if ((this.condition == null || this.condition.IsTrue(actor)) && !string.IsNullOrEmpty(this.message))
				{
					string text = this.message;
					if (this.localizedTextTable != null && this.localizedTextTable.ContainsField(this.message))
					{
						text = this.localizedTextTable[this.message];
					}
					string text2 = FormattedText.Parse(text, DialogueManager.MasterDatabase.emphasisSettings).text;
					if (Mathf.Approximately(0f, this.duration))
					{
						DialogueManager.ShowAlert(text2);
					}
					else
					{
						DialogueManager.ShowAlert(text2, this.duration);
					}
					base.DestroyIfOnce();
				}
			}
			finally
			{
				this.tryingToStart = false;
			}
		}

		// Token: 0x04000FCF RID: 4047
		[DialogueTriggerEvent]
		public DialogueTriggerEvent trigger = DialogueTriggerEvent.OnUse;

		// Token: 0x04000FD0 RID: 4048
		[Tooltip("Optional localized text table; if assigned, Message is the field in the table.")]
		public LocalizedTextTable localizedTextTable;

		// Token: 0x04000FD1 RID: 4049
		[Tooltip("The message to display, which may contain tags such as [var=varName].")]
		public string message;

		// Token: 0x04000FD2 RID: 4050
		[Tooltip("The duration in seconds to display the message. If zero, use default defined on Dialogue Manager.")]
		public float duration = 5f;

		// Token: 0x04000FD3 RID: 4051
		public Condition condition;

		// Token: 0x04000FD4 RID: 4052
		private bool tryingToStart;

		// Token: 0x04000FD5 RID: 4053
		private bool listenForOnDestroy;
	}
}
