using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets.TValle.Pro.Entrevista.Runtime.General.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.DialogueSys.UI
{
	// Token: 0x020000FF RID: 255
	public class GenericOpcionDeTHSDonaQueIniciaDialogos : GenericOpcionDeTHSDona
	{
		// Token: 0x0600088E RID: 2190 RVA: 0x00030CA1 File Offset: 0x0002EEA1
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x00030CD4 File Offset: 0x0002EED4
		protected override void OnClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			base.OnClicked(currentUserData, dona, sender);
			if (!DialogueManager.IsConversationActive)
			{
				string text;
				if (Singleton<SMAGameplayController>.instance.IsHired(this.m_owner.ID_UnicoString))
				{
					text = this.m_conversationHired;
				}
				else
				{
					text = this.m_conversationNoHired;
				}
				this.m_owner.TrySerConversarzado(MainChar.current, text);
			}
			dona.StopDrawing();
		}

		// Token: 0x040004BC RID: 1212
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationNoHired;

		// Token: 0x040004BD RID: 1213
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationHired;

		// Token: 0x040004BE RID: 1214
		private Character m_owner;
	}
}
