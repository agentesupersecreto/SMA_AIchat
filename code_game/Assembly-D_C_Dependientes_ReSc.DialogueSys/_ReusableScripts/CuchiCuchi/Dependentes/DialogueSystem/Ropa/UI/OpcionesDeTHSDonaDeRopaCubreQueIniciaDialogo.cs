using System;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.UI;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Ropa.UI
{
	// Token: 0x02000039 RID: 57
	public sealed class OpcionesDeTHSDonaDeRopaCubreQueIniciaDialogo : OpcionesDeTHSDonaDeRopaCubreConTextoMutado
	{
		// Token: 0x0600019B RID: 411 RVA: 0x00007DF4 File Offset: 0x00005FF4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00007E27 File Offset: 0x00006027
		protected override void OnDonaClosed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00007E29 File Offset: 0x00006029
		protected override void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			if (!DialogueManager.IsConversationActive)
			{
				this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversation);
			}
			dona.StopDrawing();
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00007E4F File Offset: 0x0000604F
		protected override void OnUserAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00007E51 File Offset: 0x00006051
		protected override void OnUserGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00007E53 File Offset: 0x00006053
		protected override void OnLoadedItems(LoaderDeTHSDona caller)
		{
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00007E55 File Offset: 0x00006055
		protected override void OnLoadingItems(LoaderDeTHSDona caller)
		{
		}

		// Token: 0x040000D0 RID: 208
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversation;

		// Token: 0x040000D1 RID: 209
		private Character m_owner;
	}
}
