using System;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.UI;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Interacciones.UI
{
	// Token: 0x02000042 RID: 66
	[Obsolete("usar la version para THS")]
	public class OpcionesDeDonaDeInteraccionesDisponiblesQueIniciaDialogo : OpcionesDeDonaDeInteraccionesDisponibles
	{
		// Token: 0x060001EA RID: 490 RVA: 0x000097C4 File Offset: 0x000079C4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
		}

		// Token: 0x060001EB RID: 491 RVA: 0x000097F8 File Offset: 0x000079F8
		protected override void OnOpccionCliked(int index, int Key, IUIElementoConValor button, DonaDeInteraccionBase dona)
		{
			base.OnOpccionCliked(index, Key, button, dona);
			if (!DialogueManager.IsConversationActive)
			{
				if (!base.lastClicked.esDetener)
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

		// Token: 0x040000DF RID: 223
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationEjecutar;

		// Token: 0x040000E0 RID: 224
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationDetener;

		// Token: 0x040000E1 RID: 225
		private Character m_owner;
	}
}
