using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200029D RID: 669
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/bark_trigger.html")]
	[AddComponentMenu("Dialogue System/Trigger/Bark Trigger")]
	public class BarkTrigger : BarkStarter
	{
		// Token: 0x06001C20 RID: 7200 RVA: 0x00033928 File Offset: 0x00031B28
		public void OnBarkEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnBarkEnd)
			{
				base.TryBark(Tools.Select(new Transform[] { this.target, actor }));
			}
		}

		// Token: 0x06001C21 RID: 7201 RVA: 0x00033960 File Offset: 0x00031B60
		public void OnConversationEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnConversationEnd)
			{
				base.TryBark(Tools.Select(new Transform[] { this.target, actor }));
			}
		}

		// Token: 0x06001C22 RID: 7202 RVA: 0x00033998 File Offset: 0x00031B98
		public void OnSequenceEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnSequenceEnd)
			{
				base.TryBark(Tools.Select(new Transform[] { this.target, actor }));
			}
		}

		// Token: 0x06001C23 RID: 7203 RVA: 0x000339D0 File Offset: 0x00031BD0
		public void OnUse(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				base.TryBark(Tools.Select(new Transform[] { this.target, actor }));
			}
		}

		// Token: 0x06001C24 RID: 7204 RVA: 0x00033A14 File Offset: 0x00031C14
		public void OnUse(string message)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				Transform[] array = new Transform[2];
				array[0] = this.target;
				base.TryBark(Tools.Select(array));
			}
		}

		// Token: 0x06001C25 RID: 7205 RVA: 0x00033A54 File Offset: 0x00031C54
		public void OnUse()
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				Transform[] array = new Transform[2];
				array[0] = this.target;
				base.TryBark(Tools.Select(array));
			}
		}

		// Token: 0x06001C26 RID: 7206 RVA: 0x00033A94 File Offset: 0x00031C94
		public void OnTriggerEnter(Collider other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				base.TryBark(Tools.Select(new Transform[] { this.target, other.transform }), other.transform);
			}
		}

		// Token: 0x06001C27 RID: 7207 RVA: 0x00033AE4 File Offset: 0x00031CE4
		public void OnTriggerEnter2D(Collider2D other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				base.TryBark(Tools.Select(new Transform[] { this.target, other.transform }), other.transform);
			}
		}

		// Token: 0x06001C28 RID: 7208 RVA: 0x00033B34 File Offset: 0x00031D34
		public void OnTriggerExit(Collider other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				base.TryBark(Tools.Select(new Transform[] { this.target, other.transform }), other.transform);
			}
		}

		// Token: 0x06001C29 RID: 7209 RVA: 0x00033B88 File Offset: 0x00031D88
		public void OnTriggerExit2D(Collider2D other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				base.TryBark(Tools.Select(new Transform[] { this.target, other.transform }), other.transform);
			}
		}

		// Token: 0x06001C2A RID: 7210 RVA: 0x00033BDC File Offset: 0x00031DDC
		public void OnCollisionEnter(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnCollisionEnter)
			{
				base.TryBark(Tools.Select(new Transform[]
				{
					this.target,
					collision.collider.transform
				}), collision.collider.transform);
			}
		}

		// Token: 0x06001C2B RID: 7211 RVA: 0x00033C38 File Offset: 0x00031E38
		public void OnCollisionEnter2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				base.TryBark(Tools.Select(new Transform[]
				{
					this.target,
					collision.collider.transform
				}), collision.collider.transform);
			}
		}

		// Token: 0x06001C2C RID: 7212 RVA: 0x00033C90 File Offset: 0x00031E90
		public void OnCollisionExit(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				base.TryBark(Tools.Select(new Transform[]
				{
					this.target,
					collision.collider.transform
				}), collision.collider.transform);
			}
		}

		// Token: 0x06001C2D RID: 7213 RVA: 0x00033CEC File Offset: 0x00031EEC
		public void OnCollisionExit2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				base.TryBark(Tools.Select(new Transform[]
				{
					this.target,
					collision.collider.transform
				}), collision.collider.transform);
			}
		}

		// Token: 0x06001C2E RID: 7214 RVA: 0x00033D48 File Offset: 0x00031F48
		public void Start()
		{
			if (this.trigger == DialogueTriggerEvent.OnStart)
			{
				base.StartCoroutine(this.BarkAfterOneFrame());
			}
		}

		// Token: 0x06001C2F RID: 7215 RVA: 0x00033D64 File Offset: 0x00031F64
		protected override void OnEnable()
		{
			base.OnEnable();
			this.listenForOnDestroy = true;
			if (this.trigger == DialogueTriggerEvent.OnEnable)
			{
				base.StartCoroutine(this.BarkAfterOneFrame());
			}
		}

		// Token: 0x06001C30 RID: 7216 RVA: 0x00033D90 File Offset: 0x00031F90
		protected override void OnDisable()
		{
			base.OnDisable();
			if (!this.listenForOnDestroy)
			{
				return;
			}
			if (this.trigger == DialogueTriggerEvent.OnDisable)
			{
				base.TryBark(this.target);
			}
		}

		// Token: 0x06001C31 RID: 7217 RVA: 0x00033DCC File Offset: 0x00031FCC
		public void OnLevelWillBeUnloaded()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06001C32 RID: 7218 RVA: 0x00033DD8 File Offset: 0x00031FD8
		public void OnApplicationQuit()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06001C33 RID: 7219 RVA: 0x00033DE4 File Offset: 0x00031FE4
		public void OnDestroy()
		{
			if (!this.listenForOnDestroy)
			{
				return;
			}
			if (this.trigger == DialogueTriggerEvent.OnDestroy)
			{
				base.TryBark(this.target);
			}
		}

		// Token: 0x06001C34 RID: 7220 RVA: 0x00033E1C File Offset: 0x0003201C
		private IEnumerator BarkAfterOneFrame()
		{
			yield return null;
			base.TryBark(this.target);
			yield break;
		}

		// Token: 0x04000FE2 RID: 4066
		[Tooltip("The target that the bark is directed to. If assigned, the target will get an OnBarkEnd event.")]
		public Transform target;

		// Token: 0x04000FE3 RID: 4067
		[DialogueTriggerEvent]
		[Tooltip("Event that starts the conversation.")]
		public DialogueTriggerEvent trigger = DialogueTriggerEvent.OnUse;

		// Token: 0x04000FE4 RID: 4068
		private bool listenForOnDestroy;
	}
}
