using System;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.GoTo.UI.Abstract
{
	// Token: 0x0200004F RID: 79
	public abstract class OpcionesDeTHSDonaDeRecostarseisponiblesQueIniciaDialogo : OpcionesDeTHSDonaDeRecostarseDisponibles
	{
		// Token: 0x06000256 RID: 598 RVA: 0x0000C500 File Offset: 0x0000A700
		protected override void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			base.OnItemClicked(currentUserData, dona, sender);
			if (!DialogueManager.IsConversationActive)
			{
				this.m_Character.TrySerConversarzado(MainChar.current, this.m_conversation);
			}
			dona.StopDrawing();
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000C52F File Offset: 0x0000A72F
		protected override void OnLoadedItems(LoaderDeTHSDona caller)
		{
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000C531 File Offset: 0x0000A731
		protected override void OnUserAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000C533 File Offset: 0x0000A733
		protected override void OnUserGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x040000F5 RID: 245
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversation;
	}
}
