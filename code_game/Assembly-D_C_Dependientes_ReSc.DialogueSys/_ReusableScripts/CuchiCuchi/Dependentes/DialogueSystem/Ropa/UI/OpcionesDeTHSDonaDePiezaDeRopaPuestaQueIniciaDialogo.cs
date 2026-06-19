using System;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Ropa.UI
{
	// Token: 0x02000038 RID: 56
	public sealed class OpcionesDeTHSDonaDePiezaDeRopaPuestaQueIniciaDialogo : OpcionesDeTHSDonaDePiezaDeRopaPuesta
	{
		// Token: 0x06000195 RID: 405 RVA: 0x00007D8D File Offset: 0x00005F8D
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00007DC0 File Offset: 0x00005FC0
		protected override void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			if (!DialogueManager.IsConversationActive)
			{
				this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversation);
			}
			dona.StopDrawing();
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00007DE6 File Offset: 0x00005FE6
		protected override void OnLoadedItems(LoaderDeTHSDona caller)
		{
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00007DE8 File Offset: 0x00005FE8
		protected override void OnUserAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00007DEA File Offset: 0x00005FEA
		protected override void OnUserGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x040000CE RID: 206
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversation;

		// Token: 0x040000CF RID: 207
		private Character m_owner;
	}
}
