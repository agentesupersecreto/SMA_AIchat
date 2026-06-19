using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x020002AA RID: 682
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/sequence_trigger.html")]
	[AddComponentMenu("Dialogue System/Trigger/Sequence Trigger")]
	public class SequenceTrigger : SequenceStarter
	{
		// Token: 0x06001CB8 RID: 7352 RVA: 0x00035DB0 File Offset: 0x00033FB0
		public void OnBarkEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnBarkEnd)
			{
				base.TryStartSequence(actor);
			}
		}

		// Token: 0x06001CB9 RID: 7353 RVA: 0x00035DD0 File Offset: 0x00033FD0
		public void OnConversationEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnConversationEnd)
			{
				base.TryStartSequence(actor);
			}
		}

		// Token: 0x06001CBA RID: 7354 RVA: 0x00035DF0 File Offset: 0x00033FF0
		public void OnSequenceEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnSequenceEnd)
			{
				base.TryStartSequence(actor);
			}
		}

		// Token: 0x06001CBB RID: 7355 RVA: 0x00035E10 File Offset: 0x00034010
		public void OnUse(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				base.TryStartSequence(actor);
			}
		}

		// Token: 0x06001CBC RID: 7356 RVA: 0x00035E34 File Offset: 0x00034034
		public void OnUse(string message)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				base.TryStartSequence(null);
			}
		}

		// Token: 0x06001CBD RID: 7357 RVA: 0x00035E58 File Offset: 0x00034058
		public void OnUse()
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				base.TryStartSequence(null);
			}
		}

		// Token: 0x06001CBE RID: 7358 RVA: 0x00035E7C File Offset: 0x0003407C
		public void OnTriggerEnter(Collider other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				base.TryStartSequence(other.transform, other.transform);
			}
		}

		// Token: 0x06001CBF RID: 7359 RVA: 0x00035EB4 File Offset: 0x000340B4
		public void OnTriggerEnter2D(Collider2D other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				base.TryStartSequence(other.transform, other.transform);
			}
		}

		// Token: 0x06001CC0 RID: 7360 RVA: 0x00035EEC File Offset: 0x000340EC
		public void OnTriggerExit(Collider other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				base.TryStartSequence(other.transform, other.transform);
			}
		}

		// Token: 0x06001CC1 RID: 7361 RVA: 0x00035F28 File Offset: 0x00034128
		public void OnTriggerExit2D(Collider2D other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				base.TryStartSequence(other.transform, other.transform);
			}
		}

		// Token: 0x06001CC2 RID: 7362 RVA: 0x00035F64 File Offset: 0x00034164
		public void OnCollisionEnter(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnCollisionEnter)
			{
				base.TryStartSequence(collision.collider.transform, collision.collider.transform);
			}
		}

		// Token: 0x06001CC3 RID: 7363 RVA: 0x00035FA8 File Offset: 0x000341A8
		public void OnCollisionEnter2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				base.TryStartSequence(collision.collider.transform, collision.collider.transform);
			}
		}

		// Token: 0x06001CC4 RID: 7364 RVA: 0x00035FE8 File Offset: 0x000341E8
		public void OnCollisionExit(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				base.TryStartSequence(collision.collider.transform, collision.collider.transform);
			}
		}

		// Token: 0x06001CC5 RID: 7365 RVA: 0x0003602C File Offset: 0x0003422C
		public void OnCollisionExit2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				base.TryStartSequence(collision.collider.transform, collision.collider.transform);
			}
		}

		// Token: 0x06001CC6 RID: 7366 RVA: 0x00036070 File Offset: 0x00034270
		public void Start()
		{
			if (this.trigger == DialogueTriggerEvent.OnStart)
			{
				base.StartCoroutine(this.StartSequenceAfterOneFrame());
			}
		}

		// Token: 0x06001CC7 RID: 7367 RVA: 0x0003608C File Offset: 0x0003428C
		public void OnEnable()
		{
			this.listenForOnDestroy = true;
			if (this.trigger == DialogueTriggerEvent.OnEnable)
			{
				base.StartCoroutine(this.StartSequenceAfterOneFrame());
			}
		}

		// Token: 0x06001CC8 RID: 7368 RVA: 0x000360B0 File Offset: 0x000342B0
		public void OnDisable()
		{
			if (this.listenForOnDestroy && this.trigger == DialogueTriggerEvent.OnDisable)
			{
				base.TryStartSequence(null);
			}
		}

		// Token: 0x06001CC9 RID: 7369 RVA: 0x000360E0 File Offset: 0x000342E0
		public void OnLevelWillBeUnloaded()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06001CCA RID: 7370 RVA: 0x000360EC File Offset: 0x000342EC
		public void OnApplicationQuit()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06001CCB RID: 7371 RVA: 0x000360F8 File Offset: 0x000342F8
		public void OnDestroy()
		{
			if (this.listenForOnDestroy && this.trigger == DialogueTriggerEvent.OnDestroy)
			{
				base.TryStartSequence(null);
			}
		}

		// Token: 0x06001CCC RID: 7372 RVA: 0x00036128 File Offset: 0x00034328
		private IEnumerator StartSequenceAfterOneFrame()
		{
			if (this.waitOneFrameOnStartOrEnable)
			{
				yield return null;
			}
			base.TryStartSequence(null);
			yield break;
		}

		// Token: 0x0400105A RID: 4186
		[DialogueTriggerEvent]
		[Tooltip("Trigger that starts the conversation.")]
		public DialogueTriggerEvent trigger = DialogueTriggerEvent.OnUse;

		// Token: 0x0400105B RID: 4187
		[Tooltip("Tick to wait one frame to allow other components to finish their OnStart/OnEnable.")]
		public bool waitOneFrameOnStartOrEnable = true;

		// Token: 0x0400105C RID: 4188
		private bool listenForOnDestroy;
	}
}
