using System;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers.GoTo.UI;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.GoTo.UI
{
	// Token: 0x0200004B RID: 75
	public class OpcionesDeDonaDeGoToDisponiblesQueIniciaDialogo : OpcionesDeDonaDeGoToDisponibles
	{
		// Token: 0x0600024A RID: 586 RVA: 0x0000C440 File Offset: 0x0000A640
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000C473 File Offset: 0x0000A673
		protected override void OnOpccionCliked(int index, string Key, IUIElementoConValor button, DonaDeInteraccionBase dona)
		{
			base.OnOpccionCliked(index, Key, button, dona);
			if (!DialogueManager.IsConversationActive)
			{
				this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversation);
			}
			dona.StopDrawing();
		}

		// Token: 0x040000F2 RID: 242
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversation;

		// Token: 0x040000F3 RID: 243
		private Character m_owner;
	}
}
