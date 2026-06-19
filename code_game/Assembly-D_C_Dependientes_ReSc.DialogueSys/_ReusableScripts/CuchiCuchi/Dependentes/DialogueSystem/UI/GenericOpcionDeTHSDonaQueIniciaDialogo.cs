using System;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.UI
{
	// Token: 0x0200002A RID: 42
	public class GenericOpcionDeTHSDonaQueIniciaDialogo : GenericOpcionDeTHSDona
	{
		// Token: 0x06000164 RID: 356 RVA: 0x00006F4A File Offset: 0x0000514A
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00006F7D File Offset: 0x0000517D
		protected override void OnClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			base.OnClicked(currentUserData, dona, sender);
			if (!DialogueManager.IsConversationActive)
			{
				this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversation);
			}
			dona.StopDrawing();
		}

		// Token: 0x040000BA RID: 186
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversation;

		// Token: 0x040000BB RID: 187
		private Character m_owner;
	}
}
