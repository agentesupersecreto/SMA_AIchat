using System;
using System.Collections.Generic;
using System.Text;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000015 RID: 21
	[RequireComponent(typeof(DialogueSystemEvents))]
	public class DialogueSystemCurrentLine : Singleton<DialogueSystemCurrentLine>
	{
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000BE RID: 190 RVA: 0x0000428F File Offset: 0x0000248F
		public DialogueSystemEvents dialogueSystemEvents
		{
			get
			{
				return this.m_DialogueSystemEvents;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00004297 File Offset: 0x00002497
		public IReadOnlyList<Response> currentResponses
		{
			get
			{
				return this.m_currentResponses;
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000042A0 File Offset: 0x000024A0
		protected override void DoAwake()
		{
			Singleton<DialogueSystemCurrentLine>.TryIniciar();
			base.DoAwake();
			this.m_DialogueSystemEvents.conversationEvents.onConversationEnd.AddListener(new UnityAction<Transform>(this.OnConversationEnd));
			this.m_DialogueSystemEvents.conversationEvents.onConversationLine.AddListener(new UnityAction<Subtitle>(this.OnConversationLine));
			this.m_DialogueSystemEvents.conversationEvents.onConversationResponseMenu.AddListener(new UnityAction<Response[]>(this.OnConversationResponseMenu));
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000431C File Offset: 0x0000251C
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
			if (dialogueSystemEvents2 != null)
			{
				DialogueSystemEvents.ConversationEvents conversationEvents2 = dialogueSystemEvents2.conversationEvents;
				if (conversationEvents2 != null)
				{
					conversationEvents2.onConversationLine.RemoveListener(new UnityAction<Subtitle>(this.OnConversationLine));
				}
			}
			DialogueSystemEvents dialogueSystemEvents3 = this.m_DialogueSystemEvents;
			if (dialogueSystemEvents3 == null)
			{
				return;
			}
			DialogueSystemEvents.ConversationEvents conversationEvents3 = dialogueSystemEvents3.conversationEvents;
			if (conversationEvents3 == null)
			{
				return;
			}
			conversationEvents3.onConversationResponseMenu.RemoveListener(new UnityAction<Response[]>(this.OnConversationResponseMenu));
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000043B8 File Offset: 0x000025B8
		private void OnConversationLine(Subtitle sub)
		{
			this.currentEntry = sub.dialogueEntry;
			this.currentTextOriginal = sub.formattedText.text;
			ICharacterGestuable componentEnRoot = sub.speakerInfo.transform.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				this.currentTextModified = this.currentTextOriginal;
				return;
			}
			if (!string.IsNullOrEmpty(this.currentTextOriginal) && componentEnRoot.estadoDeBocaPorUser != CharacterEstadoDeBoca.None)
			{
				TextoPronunciable textoPronunciable = null;
				try
				{
					textoPronunciable = DecoDeTexto.Decodificar(this.currentTextOriginal, this.poolTextoPronunciable);
					textoPronunciable.ObtenerTextoAlterado(this.m_resultTEMP, componentEnRoot.estadoDeBocaPorUser);
					sub.formattedText.text = (this.currentTextModified = this.m_resultTEMP.ToString());
					return;
				}
				catch (Exception ex)
				{
					Debug.LogException(ex, this);
					this.currentTextModified = this.currentTextOriginal;
					return;
				}
				finally
				{
					if (textoPronunciable != null)
					{
						this.poolTextoPronunciable.ReturnItem(textoPronunciable);
					}
					this.m_resultTEMP.Clear();
				}
			}
			this.currentTextModified = this.currentTextOriginal;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000044B8 File Offset: 0x000026B8
		private void OnConversationResponseMenu(Response[] responses)
		{
			this.m_currentResponses = responses;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000044C1 File Offset: 0x000026C1
		private void OnConversationEnd(Transform actor)
		{
			this.currentEntry = null;
			this.m_currentResponses = null;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000044D1 File Offset: 0x000026D1
		protected override void Initiating()
		{
			base.Initiating();
			this.esGlobal = false;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000044E0 File Offset: 0x000026E0
		protected override void InitData(bool esEditorTime)
		{
			this.m_DialogueSystemEvents = base.GetComponent<DialogueSystemEvents>();
			if (this.m_DialogueSystemEvents == null)
			{
				throw new ArgumentNullException("m_DialogueSystemEvents", "m_DialogueSystemEvents null reference.");
			}
		}

		// Token: 0x04000049 RID: 73
		private DialogueSystemEvents m_DialogueSystemEvents;

		// Token: 0x0400004A RID: 74
		public string currentTextOriginal;

		// Token: 0x0400004B RID: 75
		public string currentTextModified;

		// Token: 0x0400004C RID: 76
		public DialogueEntry currentEntry;

		// Token: 0x0400004D RID: 77
		private Response[] m_currentResponses;

		// Token: 0x0400004E RID: 78
		private StringBuilder m_resultTEMP = new StringBuilder();

		// Token: 0x0400004F RID: 79
		private SimplePoolDeClearables<TextoPronunciable> poolTextoPronunciable = new SimplePoolDeClearables<TextoPronunciable>();
	}
}
