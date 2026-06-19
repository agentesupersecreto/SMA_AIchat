using System;
using Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Modelos;
using Assets.TValle.UI.Runtime.Drawing.ItemsYDetallesDeItems.Paneles;
using Assets._ReusableScripts.CuchiCuchi;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.DialogueSystem
{
	// Token: 0x020000D6 RID: 214
	[RequireComponent(typeof(PanelDeItemsYDetallesDeItems))]
	public class ComenzarConversacionAlElegirOtraAgencia : CustomMonobehaviour
	{
		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060007DB RID: 2011 RVA: 0x0002D734 File Offset: 0x0002B934
		public PanelDeItemsYDetallesDeItems panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x0002D73C File Offset: 0x0002B93C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_panel = base.GetComponent<PanelDeItemsYDetallesDeItems>();
			this.m_panel.accion1Clicked += this.M_panel_accion1Clicked;
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x0002D768 File Offset: 0x0002B968
		private void M_panel_accion1Clicked(string itemID, DetallesDeItemModelo detalles, PanelDeItemsYDetallesDeItems sender)
		{
			if (!string.IsNullOrWhiteSpace(this.m_conversationEnviarAOtraAgencia) && !string.IsNullOrWhiteSpace(detalles.ID))
			{
				DialogueLua.SetVariable("SELECTED_AGENCY_BY_USER_ID", detalles.ID);
				DialogueLua.SetVariable("SELECTED_AGENCY_BY_USER_NAME", detalles.nombre);
				TargetChar.current.TrySerConversarzado(MainChar.current, this.m_conversationEnviarAOtraAgencia);
			}
			this.m_panel.Hide();
		}

		// Token: 0x04000492 RID: 1170
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationEnviarAOtraAgencia;

		// Token: 0x04000493 RID: 1171
		private PanelDeItemsYDetallesDeItems m_panel;
	}
}
