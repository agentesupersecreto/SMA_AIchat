using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.DialogueSys.Globales
{
	// Token: 0x02000104 RID: 260
	public class DialoguesForActivities : AsyncSingleton<DialoguesForActivities>
	{
		// Token: 0x060008F8 RID: 2296 RVA: 0x00034B3B File Offset: 0x00032D3B
		protected override void InitSyncData(bool esEditorTime)
		{
			base.InitSyncData(esEditorTime);
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x00034B44 File Offset: 0x00032D44
		protected override IEnumerator PostInitData()
		{
			this.m_conversationPorKey = this.m_conversations.ToDictionary((DialoguesForActivities.ConversationPar m) => m.id);
			yield break;
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x00034B54 File Offset: 0x00032D54
		public string GetConversationID(string id)
		{
			DialoguesForActivities.ConversationPar conversationPar;
			if (!this.m_conversationPorKey.TryGetValue(id, out conversationPar))
			{
				Debug.LogError("No se encontro conversacion de id " + id);
				return null;
			}
			return conversationPar.conversation;
		}

		// Token: 0x040004C5 RID: 1221
		[SerializeField]
		private DialoguesForActivities.ConversationPar[] m_conversations;

		// Token: 0x040004C6 RID: 1222
		private Dictionary<string, DialoguesForActivities.ConversationPar> m_conversationPorKey;

		// Token: 0x02000279 RID: 633
		[Serializable]
		public class ConversationPar
		{
			// Token: 0x04000BA9 RID: 2985
			public string id;

			// Token: 0x04000BAA RID: 2986
			[ConversationPopup(false)]
			[SerializeField]
			public string conversation;
		}
	}
}
