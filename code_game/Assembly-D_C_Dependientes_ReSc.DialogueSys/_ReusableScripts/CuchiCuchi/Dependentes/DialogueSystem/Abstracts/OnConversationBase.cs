using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Abstracts
{
	// Token: 0x02000076 RID: 118
	public abstract class OnConversationBase : MonoBehaviour
	{
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x00014AF0 File Offset: 0x00012CF0
		public bool enConversacion
		{
			get
			{
				return this.m_enconversacion;
			}
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00014AF8 File Offset: 0x00012CF8
		protected void OnEnable()
		{
			if (!Singleton<MainDialogueSystemEvents>.IsInScene)
			{
				Debug.LogWarning("No hay MainDialogueSystemEvents en scena");
				return;
			}
			DialogueSystemEvents dialogueSystemEvents = Singleton<MainDialogueSystemEvents>.instance.dialogueSystemEvents;
			dialogueSystemEvents.conversationEvents.onConversationStart.AddListener(new UnityAction<Transform>(this.onConversationStart));
			dialogueSystemEvents.conversationEvents.onConversationEnd.AddListener(new UnityAction<Transform>(this.onConversationEnds));
			if (DialogueManager.IsConversationActive)
			{
				this.onConversationStart(DialogueManager.CurrentActor);
			}
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00014B6C File Offset: 0x00012D6C
		protected void OnDisable()
		{
			if (!Singleton<MainDialogueSystemEvents>.IsInScene)
			{
				return;
			}
			DialogueSystemEvents dialogueSystemEvents = Singleton<MainDialogueSystemEvents>.instance.dialogueSystemEvents;
			dialogueSystemEvents.conversationEvents.onConversationStart.RemoveListener(new UnityAction<Transform>(this.onConversationStart));
			dialogueSystemEvents.conversationEvents.onConversationEnd.RemoveListener(new UnityAction<Transform>(this.onConversationEnds));
			if (this.m_enconversacion)
			{
				this.OnEndC();
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00014BD0 File Offset: 0x00012DD0
		private bool isCurrentActor()
		{
			if (!this.soloSiEsCurrentActor)
			{
				return true;
			}
			Transform currentActor = DialogueManager.CurrentActor;
			Transform currentConversant = DialogueManager.CurrentConversant;
			Transform transform = this.ObtenerCurrentActor();
			return currentActor.IsChildOf(transform) || currentConversant.IsChildOf(transform);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00014C0A File Offset: 0x00012E0A
		private void onConversationStart(Transform actor)
		{
			if (!this.isCurrentActor())
			{
				return;
			}
			if (this.m_enconversacion)
			{
				this.OnEndC();
			}
			this.OnStartC();
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00014C29 File Offset: 0x00012E29
		private void onConversationEnds(Transform actor)
		{
			if (this.m_enconversacion)
			{
				this.OnEndC();
			}
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00014C39 File Offset: 0x00012E39
		private void OnStartC()
		{
			this.m_currentActor = DialogueManager.CurrentActor;
			this.m_currentConversant = DialogueManager.CurrentConversant;
			this.m_enconversacion = true;
			this.OnConversationComienza(this.m_currentActor, this.m_currentConversant);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00014C6C File Offset: 0x00012E6C
		private void OnEndC()
		{
			Transform currentActor = this.m_currentActor;
			Transform currentConversant = this.m_currentConversant;
			this.m_currentActor = null;
			this.m_currentConversant = null;
			this.m_enconversacion = false;
			this.OnConversationTermina(currentActor, currentConversant);
		}

		// Token: 0x060003CC RID: 972
		protected abstract void OnConversationComienza(Transform currentActor, Transform currentConversant);

		// Token: 0x060003CD RID: 973
		protected abstract void OnConversationTermina(Transform currentActor, Transform currentConversant);

		// Token: 0x060003CE RID: 974
		protected abstract Transform ObtenerCurrentActor();

		// Token: 0x04000152 RID: 338
		public bool soloSiEsCurrentActor;

		// Token: 0x04000153 RID: 339
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_currentActor;

		// Token: 0x04000154 RID: 340
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_currentConversant;

		// Token: 0x04000155 RID: 341
		[ReadOnlyUI]
		[SerializeField]
		private bool m_enconversacion;
	}
}
