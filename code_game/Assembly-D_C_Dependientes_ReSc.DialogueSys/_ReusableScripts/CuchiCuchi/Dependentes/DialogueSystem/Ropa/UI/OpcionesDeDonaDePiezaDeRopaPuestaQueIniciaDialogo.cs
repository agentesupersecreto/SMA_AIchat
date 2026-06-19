using System;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.CuchiCuchi.Ropa.UI;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Ropa.UI
{
	// Token: 0x02000035 RID: 53
	[Obsolete("usar la version para THS")]
	public class OpcionesDeDonaDePiezaDeRopaPuestaQueIniciaDialogo : OpcionesDeDonaDePiezaDeRopaPuesta
	{
		// Token: 0x06000185 RID: 389 RVA: 0x00007BB0 File Offset: 0x00005DB0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00007BE3 File Offset: 0x00005DE3
		protected override void OnOpccionCliked(int index, string Key, IUIElementoConValor button, DonaDeInteraccionBase dona)
		{
			base.OnOpccionCliked(index, Key, button, dona);
			if (!DialogueManager.IsConversationActive)
			{
				this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversation);
			}
			dona.StopDrawing();
		}

		// Token: 0x040000C8 RID: 200
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversation;

		// Token: 0x040000C9 RID: 201
		private Character m_owner;
	}
}
