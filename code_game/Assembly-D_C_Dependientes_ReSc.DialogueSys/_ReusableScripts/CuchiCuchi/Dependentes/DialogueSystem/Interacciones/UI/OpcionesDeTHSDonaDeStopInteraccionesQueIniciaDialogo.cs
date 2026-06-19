using System;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Interacciones.UI
{
	// Token: 0x02000044 RID: 68
	public class OpcionesDeTHSDonaDeStopInteraccionesQueIniciaDialogo : OpcionesDeTHSDonaDeInteraccionesDisponibles
	{
		// Token: 0x060001F4 RID: 500 RVA: 0x0000990A File Offset: 0x00007B0A
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0000993D File Offset: 0x00007B3D
		protected override void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			base.OnItemClicked(currentUserData, dona, sender);
			if (!DialogueManager.IsConversationActive)
			{
				base.SetVariables();
				this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversationDetener);
			}
			dona.StopDrawing();
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00009972 File Offset: 0x00007B72
		protected override bool LoadOnlyEjecutandose()
		{
			return true;
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00009975 File Offset: 0x00007B75
		protected override void OnLoadedItems(LoaderDeTHSDona caller)
		{
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00009977 File Offset: 0x00007B77
		protected override void OnUserAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00009979 File Offset: 0x00007B79
		protected override void OnUserGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x040000E5 RID: 229
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationDetener;

		// Token: 0x040000E6 RID: 230
		private Character m_owner;
	}
}
