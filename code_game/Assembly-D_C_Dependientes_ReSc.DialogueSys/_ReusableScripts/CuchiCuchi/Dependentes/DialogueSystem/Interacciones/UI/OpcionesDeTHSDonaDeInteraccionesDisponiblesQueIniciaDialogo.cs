using System;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Interacciones.UI
{
	// Token: 0x02000043 RID: 67
	public sealed class OpcionesDeTHSDonaDeInteraccionesDisponiblesQueIniciaDialogo : OpcionesDeTHSDonaDeInteraccionesDisponibles
	{
		// Token: 0x060001ED RID: 493 RVA: 0x00009863 File Offset: 0x00007A63
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00009898 File Offset: 0x00007A98
		protected override void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			base.OnItemClicked(currentUserData, dona, sender);
			if (!DialogueManager.IsConversationActive)
			{
				base.SetVariables();
				if (!this.esDetener)
				{
					this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversationEjecutar);
				}
				else
				{
					this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversationDetener);
				}
			}
			dona.StopDrawing();
		}

		// Token: 0x060001EF RID: 495 RVA: 0x000098F9 File Offset: 0x00007AF9
		protected override bool LoadOnlyEjecutandose()
		{
			return false;
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x000098FC File Offset: 0x00007AFC
		protected override void OnLoadedItems(LoaderDeTHSDona caller)
		{
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x000098FE File Offset: 0x00007AFE
		protected override void OnUserAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00009900 File Offset: 0x00007B00
		protected override void OnUserGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x040000E2 RID: 226
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationEjecutar;

		// Token: 0x040000E3 RID: 227
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationDetener;

		// Token: 0x040000E4 RID: 228
		private Character m_owner;
	}
}
