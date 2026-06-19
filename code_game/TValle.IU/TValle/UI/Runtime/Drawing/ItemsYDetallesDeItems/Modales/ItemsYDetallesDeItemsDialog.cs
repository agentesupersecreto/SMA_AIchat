using System;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.UI.Runtime.Drawing.ItemsYDetallesDeItems.Paneles;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.TValle.UI.Runtime.Drawing.ItemsYDetallesDeItems.Modales
{
	// Token: 0x020000C6 RID: 198
	public class ItemsYDetallesDeItemsDialog : UIElemento
	{
		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x0001594F File Offset: 0x00013B4F
		public GenericUserPanel genericUserPanel
		{
			get
			{
				return this.m_genericUserPanel;
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x00015957 File Offset: 0x00013B57
		public PanelDeItemsYDetallesDeItems panelDeModelo
		{
			get
			{
				return this.m_PanelDeModelo;
			}
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x00015960 File Offset: 0x00013B60
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_genericUserPanel == null)
			{
				throw new ArgumentNullException("m_genericUserPanel", "m_genericUserPanel null reference.");
			}
			if (this.m_PanelDeModelo == null)
			{
				throw new ArgumentNullException("m_PanelDePortraits", "m_PanelDePortraits null reference.");
			}
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x000159AF File Offset: 0x00013BAF
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_PanelDeModelo.CrearYDibujar(null);
		}

		// Token: 0x0400021F RID: 543
		[SerializeField]
		private GenericUserPanel m_genericUserPanel;

		// Token: 0x04000220 RID: 544
		[SerializeField]
		private PanelDeItemsYDetallesDeItems m_PanelDeModelo;
	}
}
