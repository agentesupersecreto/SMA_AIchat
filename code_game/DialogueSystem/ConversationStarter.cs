using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x020002A0 RID: 672
	[AddComponentMenu("")]
	public abstract class ConversationStarter : DialogueEventStarter
	{
		// Token: 0x06001C42 RID: 7234 RVA: 0x000340FC File Offset: 0x000322FC
		public void TryStartConversation(Transform actor)
		{
			this.TryStartConversation(actor, actor);
		}

		// Token: 0x06001C43 RID: 7235 RVA: 0x00034108 File Offset: 0x00032308
		public void TryStartConversation(Transform actor, Transform interactor)
		{
			if (!this.tryingToStart)
			{
				this.tryingToStart = true;
				try
				{
					if (this.condition == null || this.condition.IsTrue(interactor))
					{
						if (string.IsNullOrEmpty(this.conversation))
						{
							if (DialogueDebug.LogErrors)
							{
								Debug.LogError(string.Format("{0}: Conversation triggered on {1}, but conversation name is blank.", new object[] { "Dialogue System", base.name }));
							}
						}
						else if ((DialogueManager.IsConversationActive && !DialogueManager.AllowSimultaneousConversations) || (this.exclusive && DialogueManager.IsConversationActive))
						{
							if (DialogueDebug.LogInfo)
							{
								Debug.Log(string.Format("{0}: Conversation triggered on {1}, but another conversation is already active.", new object[] { "Dialogue System", base.name }));
							}
						}
						else
						{
							this.StartConversation(actor);
						}
						base.DestroyIfOnce();
					}
				}
				finally
				{
					this.tryingToStart = false;
				}
			}
		}

		// Token: 0x06001C44 RID: 7236 RVA: 0x0003421C File Offset: 0x0003241C
		private void StartConversation(Transform actor)
		{
			Transform transform = Tools.Select(new Transform[] { this.conversant, base.transform });
			bool flag = this.skipIfNoValidEntries && !DialogueManager.ConversationHasValidEntry(this.conversation, actor, transform);
			if (flag)
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Conversation triggered on {1}, but skipping because no entries are currently valid.", new object[] { "Dialogue System", base.name }));
				}
			}
			else
			{
				DialogueManager.StartConversation(this.conversation, actor, transform);
			}
		}

		// Token: 0x04000FF5 RID: 4085
		[Tooltip("Start this conversation.")]
		[ConversationPopup(true)]
		public string conversation;

		// Token: 0x04000FF6 RID: 4086
		public Condition condition;

		// Token: 0x04000FF7 RID: 4087
		[Tooltip("Only trigger if at least one entry's Conditions are currently true.")]
		public bool skipIfNoValidEntries;

		// Token: 0x04000FF8 RID: 4088
		[Tooltip("Only trigger if no other conversation is already active.")]
		public bool exclusive;

		// Token: 0x04000FF9 RID: 4089
		[Tooltip("The other actor (e.g., NPC). If unassigned, this GameObject.")]
		public Transform conversant;

		// Token: 0x04000FFA RID: 4090
		private bool tryingToStart;

		// Token: 0x04000FFB RID: 4091
		[HideInInspector]
		public bool useConversationTitlePicker = true;

		// Token: 0x04000FFC RID: 4092
		[HideInInspector]
		public DialogueDatabase selectedDatabase;
	}
}
