using System;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.GoTo.UI
{
	// Token: 0x0200004C RID: 76
	public sealed class OpcionesDeTHSDonaDeGoToDisponiblesQueIniciaDialogo : OpcionesDeTHSDonaDeGoToDisponibles
	{
		// Token: 0x0600024D RID: 589 RVA: 0x0000C4AD File Offset: 0x0000A6AD
		protected override void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			base.OnItemClicked(currentUserData, dona, sender);
			if (!DialogueManager.IsConversationActive)
			{
				this.m_Character.TrySerConversarzado(MainChar.current, this.m_conversation);
			}
			dona.StopDrawing();
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000C4DC File Offset: 0x0000A6DC
		protected override void OnLoadedItems(LoaderDeTHSDona caller)
		{
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000C4DE File Offset: 0x0000A6DE
		protected override void OnUserAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000C4E0 File Offset: 0x0000A6E0
		protected override void OnUserGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x040000F4 RID: 244
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversation;
	}
}
