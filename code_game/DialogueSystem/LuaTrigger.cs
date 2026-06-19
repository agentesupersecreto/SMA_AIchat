using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x020002A6 RID: 678
	[AddComponentMenu("Dialogue System/Trigger/Lua Trigger")]
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/lua_trigger.html")]
	public class LuaTrigger : DialogueEventStarter
	{
		// Token: 0x06001C85 RID: 7301 RVA: 0x00035370 File Offset: 0x00033570
		public void OnBarkEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnBarkEnd)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001C86 RID: 7302 RVA: 0x00035390 File Offset: 0x00033590
		public void OnConversationEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnConversationEnd)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001C87 RID: 7303 RVA: 0x000353B0 File Offset: 0x000335B0
		public void OnSequenceEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnSequenceEnd)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001C88 RID: 7304 RVA: 0x000353D0 File Offset: 0x000335D0
		public void OnUse(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001C89 RID: 7305 RVA: 0x000353F4 File Offset: 0x000335F4
		public void OnUse(string message)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001C8A RID: 7306 RVA: 0x00035418 File Offset: 0x00033618
		public void OnUse()
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001C8B RID: 7307 RVA: 0x0003543C File Offset: 0x0003363C
		public void OnTriggerEnter(Collider other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001C8C RID: 7308 RVA: 0x00035464 File Offset: 0x00033664
		public void OnTriggerEnter2D(Collider2D other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001C8D RID: 7309 RVA: 0x0003548C File Offset: 0x0003368C
		public void OnTriggerExit(Collider other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001C8E RID: 7310 RVA: 0x000354B8 File Offset: 0x000336B8
		public void OnTriggerExit2D(Collider2D other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001C8F RID: 7311 RVA: 0x000354E4 File Offset: 0x000336E4
		public void OnCollisionEnter(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnCollisionEnter)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001C90 RID: 7312 RVA: 0x00035520 File Offset: 0x00033720
		public void OnCollisionEnter2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001C91 RID: 7313 RVA: 0x00035558 File Offset: 0x00033758
		public void OnCollisionExit(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001C92 RID: 7314 RVA: 0x00035594 File Offset: 0x00033794
		public void OnCollisionExit2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001C93 RID: 7315 RVA: 0x000355D0 File Offset: 0x000337D0
		public void Start()
		{
			if (this.trigger == DialogueTriggerEvent.OnStart)
			{
				base.StartCoroutine(this.StartAfterOneFrame());
			}
		}

		// Token: 0x06001C94 RID: 7316 RVA: 0x000355EC File Offset: 0x000337EC
		public void OnEnable()
		{
			this.listenForOnDestroy = true;
			if (this.trigger == DialogueTriggerEvent.OnEnable)
			{
				base.StartCoroutine(this.StartAfterOneFrame());
			}
		}

		// Token: 0x06001C95 RID: 7317 RVA: 0x00035610 File Offset: 0x00033810
		public void OnDisable()
		{
			if (this.listenForOnDestroy && this.trigger == DialogueTriggerEvent.OnDisable)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001C96 RID: 7318 RVA: 0x00035640 File Offset: 0x00033840
		public void OnLevelWillBeUnloaded()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06001C97 RID: 7319 RVA: 0x0003564C File Offset: 0x0003384C
		public void OnApplicationQuit()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06001C98 RID: 7320 RVA: 0x00035658 File Offset: 0x00033858
		public void OnDestroy()
		{
			if (this.listenForOnDestroy && this.trigger == DialogueTriggerEvent.OnDestroy)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001C99 RID: 7321 RVA: 0x00035688 File Offset: 0x00033888
		private IEnumerator StartAfterOneFrame()
		{
			yield return null;
			this.TryStart(null);
			yield break;
		}

		// Token: 0x06001C9A RID: 7322 RVA: 0x000356A4 File Offset: 0x000338A4
		public void TryStart(Transform actor)
		{
			if (this.tryingToStart)
			{
				return;
			}
			this.tryingToStart = true;
			try
			{
				if ((this.condition == null || this.condition.IsTrue(actor)) && !string.IsNullOrEmpty(this.luaCode))
				{
					Lua.Run(this.luaCode, DialogueDebug.LogInfo);
					DialogueManager.CheckAlerts();
					DialogueManager.SendUpdateTracker();
					base.DestroyIfOnce();
				}
			}
			finally
			{
				this.tryingToStart = false;
			}
		}

		// Token: 0x0400103D RID: 4157
		[DialogueTriggerEvent]
		public DialogueTriggerEvent trigger = DialogueTriggerEvent.OnUse;

		// Token: 0x0400103E RID: 4158
		public Condition condition;

		// Token: 0x0400103F RID: 4159
		[LuaScriptWizard(false)]
		public string luaCode;

		// Token: 0x04001040 RID: 4160
		private bool tryingToStart;

		// Token: 0x04001041 RID: 4161
		private bool listenForOnDestroy;
	}
}
