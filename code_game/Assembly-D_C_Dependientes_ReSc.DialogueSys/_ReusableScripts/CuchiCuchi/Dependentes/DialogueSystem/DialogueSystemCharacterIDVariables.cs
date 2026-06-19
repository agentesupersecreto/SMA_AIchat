using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000014 RID: 20
	[RequireComponent(typeof(DialogueSystemEvents))]
	public class DialogueSystemCharacterIDVariables : Singleton<DialogueSystemCharacterIDVariables>
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00003FAE File Offset: 0x000021AE
		public DialogueSystemEvents dialogueSystemEvents
		{
			get
			{
				return this.m_DialogueSystemEvents;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x00003FB6 File Offset: 0x000021B6
		public bool enConversacion
		{
			get
			{
				return this.m_enConversacion;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x00003FBE File Offset: 0x000021BE
		public Character actor
		{
			get
			{
				return this.m_actor;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00003FC6 File Offset: 0x000021C6
		public Character conversant
		{
			get
			{
				return this.m_conversant;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x00003FCE File Offset: 0x000021CE
		public string lastActorID
		{
			get
			{
				return this.m_lastActorID;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00003FD6 File Offset: 0x000021D6
		public string lastConversantID
		{
			get
			{
				return this.m_lastConversantID;
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003FE0 File Offset: 0x000021E0
		protected override void DoAwake()
		{
			base.DoAwake();
			DialogueSystemEvents dialogueSystemEvents = this.m_DialogueSystemEvents;
			if (dialogueSystemEvents != null)
			{
				DialogueSystemEvents.ConversationEvents conversationEvents = dialogueSystemEvents.conversationEvents;
				if (conversationEvents != null)
				{
					conversationEvents.onConversationEnd.AddListener(new UnityAction<Transform>(this.OnConversationEnd));
				}
			}
			DialogueSystemEvents dialogueSystemEvents2 = this.m_DialogueSystemEvents;
			if (dialogueSystemEvents2 == null)
			{
				return;
			}
			DialogueSystemEvents.ConversationEvents conversationEvents2 = dialogueSystemEvents2.conversationEvents;
			if (conversationEvents2 == null)
			{
				return;
			}
			conversationEvents2.onConversationStart.AddListener(new UnityAction<Transform>(this.OnConversationStart));
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000404C File Offset: 0x0000224C
		protected override void OnDestroyed(bool wasInitiated)
		{
			base.OnDestroyed(wasInitiated);
			DialogueSystemEvents dialogueSystemEvents = this.m_DialogueSystemEvents;
			if (dialogueSystemEvents != null)
			{
				DialogueSystemEvents.ConversationEvents conversationEvents = dialogueSystemEvents.conversationEvents;
				if (conversationEvents != null)
				{
					conversationEvents.onConversationEnd.RemoveListener(new UnityAction<Transform>(this.OnConversationEnd));
				}
			}
			DialogueSystemEvents dialogueSystemEvents2 = this.m_DialogueSystemEvents;
			if (dialogueSystemEvents2 == null)
			{
				return;
			}
			DialogueSystemEvents.ConversationEvents conversationEvents2 = dialogueSystemEvents2.conversationEvents;
			if (conversationEvents2 == null)
			{
				return;
			}
			conversationEvents2.onConversationStart.RemoveListener(new UnityAction<Transform>(this.OnConversationStart));
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000040B8 File Offset: 0x000022B8
		public void ForceToSetActorsVariables(ICharacterUnico actor, ICharacterUnico conversant)
		{
			this.m_lastActorID = null;
			this.m_lastConversantID = null;
			if (actor != null)
			{
				this.m_lastActorID = actor.ID_Unico.ToString();
				DialogueLua.SetVariable("ActorID", this.m_lastActorID);
				DialogueLua.SetVariable("ActorFirst", actor.nombre);
			}
			if (conversant != null)
			{
				this.m_lastConversantID = conversant.ID_Unico.ToString();
				DialogueLua.SetVariable("ConversantID", this.m_lastConversantID);
				DialogueLua.SetVariable("ConversantFirst", conversant.nombre);
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00004150 File Offset: 0x00002350
		public void OnConversationStart(Transform actor)
		{
			this.OnConversationEnd(actor);
			this.m_enConversacion = true;
			Transform currentActor = DialogueManager.CurrentActor;
			Transform currentConversant = DialogueManager.CurrentConversant;
			this.m_actor = currentActor.GetComponentEnRoot(false);
			if (this.m_actor)
			{
				DialogueLua.SetVariable("ActorID", this.m_actor.ID_Unico.ToString());
				DialogueLua.SetVariable("ActorFirst", this.m_actor.nombre);
			}
			this.m_conversant = currentConversant.GetComponentEnRoot(false);
			if (this.m_conversant)
			{
				DialogueLua.SetVariable("ConversantID", this.m_conversant.ID_Unico.ToString());
				DialogueLua.SetVariable("ConversantFirst", this.m_conversant.nombre);
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000421C File Offset: 0x0000241C
		public void OnConversationEnd(Transform actor)
		{
			this.m_enConversacion = false;
			this.m_actor = null;
			this.m_conversant = null;
			DialogueLua.SetVariable("ActorID", null);
			DialogueLua.SetVariable("ActorFirst", null);
			DialogueLua.SetVariable("ConversantID", null);
			DialogueLua.SetVariable("ConversantFirst", null);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000426A File Offset: 0x0000246A
		protected override void Initiating()
		{
			base.Initiating();
			this.esGlobal = false;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00004279 File Offset: 0x00002479
		protected override void InitData(bool esEditorTime)
		{
			this.m_DialogueSystemEvents = base.GetComponent<DialogueSystemEvents>();
		}

		// Token: 0x04000039 RID: 57
		public const string actorIDVarName = "ActorID";

		// Token: 0x0400003A RID: 58
		public const string conversantIDVarName = "ConversantID";

		// Token: 0x0400003B RID: 59
		public const string actorFirstNameVarName = "ActorFirst";

		// Token: 0x0400003C RID: 60
		public const string conversantFirstNameVarName = "ConversantFirst";

		// Token: 0x0400003D RID: 61
		public const string actorNameVarName = "Actor";

		// Token: 0x0400003E RID: 62
		public const string conversantNameVarName = "Conversant";

		// Token: 0x0400003F RID: 63
		public const string actorFirstNameDialogue = "[lua( Variable[\"ActorFirst\"] )]";

		// Token: 0x04000040 RID: 64
		public const string conversantFirstNameDialogue = "[lua( Variable[\"ConversantFirst\"] )]";

		// Token: 0x04000041 RID: 65
		public const string actorNameDialogue = "[lua( Variable[\"Actor\"] )]";

		// Token: 0x04000042 RID: 66
		public const string conversantNameDialogue = "[lua( Variable[\"Conversant\"] )]";

		// Token: 0x04000043 RID: 67
		private DialogueSystemEvents m_DialogueSystemEvents;

		// Token: 0x04000044 RID: 68
		[ReadOnlyUI]
		[SerializeField]
		private string m_lastActorID;

		// Token: 0x04000045 RID: 69
		[ReadOnlyUI]
		[SerializeField]
		private string m_lastConversantID;

		// Token: 0x04000046 RID: 70
		[ReadOnlyUI]
		[SerializeField]
		private bool m_enConversacion;

		// Token: 0x04000047 RID: 71
		[ReadOnlyUI]
		[SerializeField]
		private Character m_actor;

		// Token: 0x04000048 RID: 72
		[ReadOnlyUI]
		[SerializeField]
		private Character m_conversant;
	}
}
