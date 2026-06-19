using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Modelos;
using Assets.TValle.UI.Runtime.Drawing.ItemsYDetallesDeItems.Paneles;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Testing
{
	// Token: 0x0200010C RID: 268
	[RequireComponent(typeof(PanelDeItemsYDetallesDeItems))]
	public class PanelDeItemsYDetallesDeItemsDummyData : CustomMonobehaviour
	{
		// Token: 0x060007F2 RID: 2034 RVA: 0x0001BC34 File Offset: 0x00019E34
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_panel = base.GetComponent<PanelDeItemsYDetallesDeItems>();
			this.m_panel.loadingItems += this.M_panel_loadingItems;
			this.m_panel.loadingDetalles += this.M_panel_loadingDetalles;
			this.m_panel.itemsFavoriteStateChanged += this.M_panel_itemsFavoriteStateChanged;
			this.m_panel.itemsClicked += this.M_panel_itemsClicked;
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0001BCB0 File Offset: 0x00019EB0
		private void M_panel_loadingItems(bool soloFavoritos, string buscando, ref InformacionDetalladaDeItemsModelo modelo, PanelDeItemsYDetallesDeItems sender)
		{
			IEnumerable<ItemsListaModelo.Item> enumerable = this.dummyData.Select((PanelDeItemsYDetallesDeItemsDummyData.Item it) => it.itemEnLista);
			if (soloFavoritos)
			{
				enumerable.Filtrar((ItemsListaModelo.Item item) => item.label, buscando, modelo.agenciasListaModelo.items, (ItemsListaModelo.Item item) => item.favorito);
				return;
			}
			enumerable.Filtrar((ItemsListaModelo.Item item) => item.label, buscando, modelo.agenciasListaModelo.items, null);
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x0001BD70 File Offset: 0x00019F70
		private void M_panel_loadingDetalles(ItemsListaModelo.Item item, int index, ref DetallesDeItemModelo modelo, PanelDeItemsYDetallesDeItems sender)
		{
			modelo = this.dummyData[index].detalles;
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x0001BD85 File Offset: 0x00019F85
		private void M_panel_itemsFavoriteStateChanged(bool newValue, ItemsListaModelo.Item item, PanelDeItemsYDetallesDeItems sender)
		{
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x0001BD87 File Offset: 0x00019F87
		private void M_panel_itemsClicked(ItemsListaModelo.Item item, PanelDeItemsYDetallesDeItems sender)
		{
		}

		// Token: 0x04000318 RID: 792
		public List<PanelDeItemsYDetallesDeItemsDummyData.Item> dummyData = new List<PanelDeItemsYDetallesDeItemsDummyData.Item>();

		// Token: 0x04000319 RID: 793
		private PanelDeItemsYDetallesDeItems m_panel;

		// Token: 0x020001C7 RID: 455
		[Serializable]
		public class Item
		{
			// Token: 0x040005B1 RID: 1457
			public ItemsListaModelo.Item itemEnLista;

			// Token: 0x040005B2 RID: 1458
			public DetallesDeItemModelo detalles;
		}
	}
}
