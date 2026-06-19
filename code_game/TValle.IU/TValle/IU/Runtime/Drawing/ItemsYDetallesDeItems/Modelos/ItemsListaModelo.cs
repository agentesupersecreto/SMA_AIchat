using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Modelos
{
	// Token: 0x02000112 RID: 274
	[Modelo]
	[UnTittle]
	[Panel(tipo = TipoDePanel.scrollableFlotanteBuscable)]
	[Serializable]
	public class ItemsListaModelo
	{
		// Token: 0x14000039 RID: 57
		// (add) Token: 0x06000818 RID: 2072 RVA: 0x0001C280 File Offset: 0x0001A480
		// (remove) Token: 0x06000819 RID: 2073 RVA: 0x0001C2B8 File Offset: 0x0001A4B8
		public event Action<bool, ItemsListaModelo> soloFavoritosChanged;

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x0600081A RID: 2074 RVA: 0x0001C2F0 File Offset: 0x0001A4F0
		// (remove) Token: 0x0600081B RID: 2075 RVA: 0x0001C328 File Offset: 0x0001A528
		public event Action<string, ItemsListaModelo> buscandoChanged;

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x0600081C RID: 2076 RVA: 0x0001C360 File Offset: 0x0001A560
		// (remove) Token: 0x0600081D RID: 2077 RVA: 0x0001C398 File Offset: 0x0001A598
		public event Action<ItemsListaModelo.Item, int, ItemsListaModelo> favoriteStateChanged;

		// Token: 0x1400003C RID: 60
		// (add) Token: 0x0600081E RID: 2078 RVA: 0x0001C3D0 File Offset: 0x0001A5D0
		// (remove) Token: 0x0600081F RID: 2079 RVA: 0x0001C408 File Offset: 0x0001A608
		public event Action<ItemsListaModelo.Item, int, ItemsListaModelo> itemClicked;

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000820 RID: 2080 RVA: 0x0001C43D File Offset: 0x0001A63D
		// (set) Token: 0x06000821 RID: 2081 RVA: 0x0001C445 File Offset: 0x0001A645
		[ModeloExtraData(para = "SOLO_FAVORITOS")]
		public bool soloFavoritos
		{
			get
			{
				return this.m_soloFavoritos;
			}
			set
			{
				this.m_soloFavoritos = value;
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000822 RID: 2082 RVA: 0x0001C44E File Offset: 0x0001A64E
		// (set) Token: 0x06000823 RID: 2083 RVA: 0x0001C456 File Offset: 0x0001A656
		[ModeloExtraData(para = "BUSCANDO")]
		public string buscando
		{
			get
			{
				return this.m_buscando;
			}
			set
			{
				this.m_buscando = value;
			}
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x0001C460 File Offset: 0x0001A660
		[MemberValueChangedListener(member = "items")]
		protected void OnFavoriteStateChanged(IUIElementoConValor elemento)
		{
			ItemsListaModelo.Item valueOrDefault = this.items.GetValueOrDefault(elemento.modelItemIndex);
			valueOrDefault.favorito = !valueOrDefault.favorito;
			Action<ItemsListaModelo.Item, int, ItemsListaModelo> action = this.favoriteStateChanged;
			if (action == null)
			{
				return;
			}
			action(valueOrDefault, elemento.modelItemIndex, this);
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0001C4A8 File Offset: 0x0001A6A8
		[MemberBotonClickedListener(member = "items")]
		protected void OnItemClicked(IUIBoton elemento)
		{
			ItemsListaModelo.Item valueOrDefault = this.items.GetValueOrDefault(elemento.modelItemIndex);
			Action<ItemsListaModelo.Item, int, ItemsListaModelo> action = this.itemClicked;
			if (action == null)
			{
				return;
			}
			action(valueOrDefault, elemento.modelItemIndex, this);
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x0001C4E0 File Offset: 0x0001A6E0
		[PanelEventListener]
		protected void OnPanelEvent(string eventID, object data, IUIPanelConEventos panel)
		{
			if (!(eventID == "BUSCANDO"))
			{
				if (!(eventID == "SOLO_FAVORITOS"))
				{
					throw new ArgumentOutOfRangeException(eventID.ToString());
				}
				this.m_soloFavoritos = Convert.ToBoolean(data);
				Action<bool, ItemsListaModelo> action = this.soloFavoritosChanged;
				if (action == null)
				{
					return;
				}
				action(this.m_soloFavoritos, this);
				return;
			}
			else
			{
				this.m_buscando = Convert.ToString(data);
				Action<string, ItemsListaModelo> action2 = this.buscandoChanged;
				if (action2 == null)
				{
					return;
				}
				action2(this.m_buscando, this);
				return;
			}
		}

		// Token: 0x04000332 RID: 818
		[Ignore]
		[SerializeField]
		private bool m_soloFavoritos;

		// Token: 0x04000333 RID: 819
		[Ignore]
		[SerializeField]
		private string m_buscando;

		// Token: 0x04000334 RID: 820
		[ClickableFavoritableLabel]
		public List<ItemsListaModelo.Item> items = new List<ItemsListaModelo.Item>();

		// Token: 0x020001CD RID: 461
		[Serializable]
		public class Item : IMultipleValorElemento<string, string, bool, Color?, string>, IMultipleValorElemento<string, string, bool, Color?>, IMultipleValorElemento<string, string, bool>, IMultipleValorElemento<string, string>, IMultipleValorElemento<string>
		{
			// Token: 0x06000C48 RID: 3144 RVA: 0x00025470 File Offset: 0x00023670
			public Item()
			{
			}

			// Token: 0x06000C49 RID: 3145 RVA: 0x00025478 File Offset: 0x00023678
			public Item(string id, string Label, bool esFavorito, Color? Color, string ResaltoText)
			{
				this.ID = id;
				this.label = Label;
				this.favorito = esFavorito;
				this.color = Color;
				this.resaltoText = ResaltoText;
			}

			// Token: 0x1700030B RID: 779
			// (get) Token: 0x06000C4A RID: 3146 RVA: 0x000254A5 File Offset: 0x000236A5
			public string item1
			{
				get
				{
					return this.ID;
				}
			}

			// Token: 0x1700030C RID: 780
			// (get) Token: 0x06000C4B RID: 3147 RVA: 0x000254AD File Offset: 0x000236AD
			public string item2
			{
				get
				{
					return this.label;
				}
			}

			// Token: 0x1700030D RID: 781
			// (get) Token: 0x06000C4C RID: 3148 RVA: 0x000254B5 File Offset: 0x000236B5
			public bool item3
			{
				get
				{
					return this.favorito;
				}
			}

			// Token: 0x1700030E RID: 782
			// (get) Token: 0x06000C4D RID: 3149 RVA: 0x000254BD File Offset: 0x000236BD
			public Color? item4
			{
				get
				{
					return this.color;
				}
			}

			// Token: 0x1700030F RID: 783
			// (get) Token: 0x06000C4E RID: 3150 RVA: 0x000254C5 File Offset: 0x000236C5
			public string item5
			{
				get
				{
					return this.resaltoText;
				}
			}

			// Token: 0x040005BB RID: 1467
			public string ID;

			// Token: 0x040005BC RID: 1468
			public string label;

			// Token: 0x040005BD RID: 1469
			public bool favorito;

			// Token: 0x040005BE RID: 1470
			public Color? color;

			// Token: 0x040005BF RID: 1471
			public string resaltoText;
		}
	}
}
