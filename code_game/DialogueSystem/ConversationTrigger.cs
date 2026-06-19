using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x020002A1 RID: 673
	[AddComponentMenu("Dialogue System/Trigger/Conversation Trigger")]
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/conversation_trigger.html")]
	public class ConversationTrigger : ConversationStarter
	{
		// Token: 0x06001C46 RID: 7238 RVA: 0x000342C0 File Offset: 0x000324C0
		public void OnBarkEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnBarkEnd)
			{
				base.TryStartConversation(Tools.Select(new Transform[] { this.actor, actor }));
			}
		}

		// Token: 0x06001C47 RID: 7239 RVA: 0x000342F8 File Offset: 0x000324F8
		public void OnConversationEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnConversationEnd)
			{
				base.TryStartConversation(Tools.Select(new Transform[] { this.actor, actor }));
			}
		}

		// Token: 0x06001C48 RID: 7240 RVA: 0x00034330 File Offset: 0x00032530
		public void OnSequenceEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnSequenceEnd)
			{
				base.TryStartConversation(Tools.Select(new Transform[] { this.actor, actor }));
			}
		}

		// Token: 0x06001C49 RID: 7241 RVA: 0x00034368 File Offset: 0x00032568
		public void OnUse(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				base.TryStartConversation(Tools.Select(new Transform[] { this.actor, actor }));
			}
		}

		// Token: 0x06001C4A RID: 7242 RVA: 0x000343AC File Offset: 0x000325AC
		public void OnUse(string message)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				base.TryStartConversation(this.actor);
			}
		}

		// Token: 0x06001C4B RID: 7243 RVA: 0x000343E0 File Offset: 0x000325E0
		public void OnUse()
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				base.TryStartConversation(this.actor);
			}
		}

		// Token: 0x06001C4C RID: 7244 RVA: 0x00034414 File Offset: 0x00032614
		public void OnTriggerEnter(Collider other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStartConversationOnTriggerEnter(other.transform);
			}
		}

		// Token: 0x06001C4D RID: 7245 RVA: 0x0003443C File Offset: 0x0003263C
		public void OnTriggerExit(Collider other)
		{
			this.CheckOnTriggerExit(other.transform);
		}

		// Token: 0x06001C4E RID: 7246 RVA: 0x0003444C File Offset: 0x0003264C
		public void OnTriggerExit2D(Collider2D other)
		{
			this.CheckOnTriggerExit(other.transform);
		}

		// Token: 0x06001C4F RID: 7247 RVA: 0x0003445C File Offset: 0x0003265C
		public void OnCollisionEnter(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnCollisionEnter)
			{
				base.TryStartConversation(collision.collider.transform);
			}
		}

		// Token: 0x06001C50 RID: 7248 RVA: 0x00034498 File Offset: 0x00032698
		public void OnCollisionEnter2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				base.TryStartConversation(collision.collider.transform);
			}
		}

		// Token: 0x06001C51 RID: 7249 RVA: 0x000344D0 File Offset: 0x000326D0
		public void OnCollisionExit(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				base.TryStartConversation(collision.collider.transform);
			}
		}

		// Token: 0x06001C52 RID: 7250 RVA: 0x0003450C File Offset: 0x0003270C
		public void OnCollisionExit2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				base.TryStartConversation(collision.collider.transform);
			}
		}

		// Token: 0x06001C53 RID: 7251 RVA: 0x00034548 File Offset: 0x00032748
		public void OnTriggerEnter2D(Collider2D other)
		{
			if (!DialogueManager.IsConversationActive && base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStartConversationOnTriggerEnter(other.transform);
			}
		}

		// Token: 0x06001C54 RID: 7252 RVA: 0x00034578 File Offset: 0x00032778
		private void TryStartConversationOnTriggerEnter(Transform otherTransform)
		{
			if (otherTransform != this.actor && !this.condition.IsTrue(otherTransform))
			{
				return;
			}
			base.TryStartConversation(Tools.Select(new Transform[] { this.actor, otherTransform }), otherTransform);
			this.earliestTimeToAllowTriggerExit = Time.time + 0.2f;
		}

		// Token: 0x06001C55 RID: 7253 RVA: 0x000345D8 File Offset: 0x000327D8
		private void CheckOnTriggerExit(Transform otherTransform)
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.stopConversationOnTriggerExit && DialogueManager.IsConversationActive && Time.time > this.earliestTimeToAllowTriggerExit && (DialogueManager.CurrentActor == otherTransform || DialogueManager.CurrentConversant == otherTransform))
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Stopping conversation because {1} exited trigger area.", new object[] { "Dialogue System", otherTransform.name }));
				}
				DialogueManager.StopConversation();
			}
			else if (this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStartConversationOnTriggerEnter(otherTransform);
			}
		}

		// Token: 0x06001C56 RID: 7254 RVA: 0x00034688 File Offset: 0x00032888
		public void Start()
		{
			if (this.trigger == DialogueTriggerEvent.OnStart)
			{
				base.StartCoroutine(this.StartConversationAfterOneFrame());
			}
		}

		// Token: 0x06001C57 RID: 7255 RVA: 0x000346A4 File Offset: 0x000328A4
		public void OnEnable()
		{
			this.listenForOnDestroy = true;
			if (this.trigger == DialogueTriggerEvent.OnEnable)
			{
				base.StartCoroutine(this.StartConversationAfterOneFrame());
			}
		}

		// Token: 0x06001C58 RID: 7256 RVA: 0x000346C8 File Offset: 0x000328C8
		public void OnDisable()
		{
			if (!this.listenForOnDestroy)
			{
				return;
			}
			if (this.trigger == DialogueTriggerEvent.OnDisable)
			{
				base.TryStartConversation(this.actor);
			}
		}

		// Token: 0x06001C59 RID: 7257 RVA: 0x00034700 File Offset: 0x00032900
		public void OnLevelWillBeUnloaded()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06001C5A RID: 7258 RVA: 0x0003470C File Offset: 0x0003290C
		public void OnApplicationQuit()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06001C5B RID: 7259 RVA: 0x00034718 File Offset: 0x00032918
		public void OnDestroy()
		{
			if (!this.listenForOnDestroy)
			{
				return;
			}
			if (this.trigger == DialogueTriggerEvent.OnDestroy)
			{
				base.TryStartConversation(this.actor);
			}
		}

		// Token: 0x06001C5C RID: 7260 RVA: 0x00034750 File Offset: 0x00032950
		private IEnumerator StartConversationAfterOneFrame()
		{
			yield return null;
			base.TryStartConversation(this.actor);
			yield break;
		}

		// Token: 0x04000FFD RID: 4093
		private const float MarginToAllowTriggerExit = 0.2f;

		// Token: 0x04000FFE RID: 4094
		[Tooltip("The primary actor (e.g., player). If unassigned, the GameObject that triggered the conversation.")]
		public Transform actor;

		// Token: 0x04000FFF RID: 4095
		[Tooltip("Try to start the conversation when this event occurs.")]
		[DialogueTriggerEvent]
		public DialogueTriggerEvent trigger = DialogueTriggerEvent.OnUse;

		// Token: 0x04001000 RID: 4096
		[Tooltip("Stop the triggered conversation if this GameObject receives OnTriggerExit.")]
		public bool stopConversationOnTriggerExit;

		// Token: 0x04001001 RID: 4097
		private float earliestTimeToAllowTriggerExit;

		// Token: 0x04001002 RID: 4098
		private bool listenForOnDestroy;
	}
}
