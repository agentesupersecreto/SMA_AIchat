using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.PortraitsYAcionesParaPortraits.Modelos
{
	// Token: 0x020000F1 RID: 241
	[Modelo]
	[UnTittle]
	[Panel(tipo = TipoDePanel.scrollableFlotanteBuscableDePortraits, panelLayoutDynamicMethodTarget = "GetLayout", width = 250)]
	[Serializable]
	public class PortraitsListaModelo
	{
		// Token: 0x0600074D RID: 1869 RVA: 0x0001A6AD File Offset: 0x000188AD
		public IPanelLayoutAttribute GetLayout()
		{
			return this.layout;
		}

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x0600074E RID: 1870 RVA: 0x0001A6B8 File Offset: 0x000188B8
		// (remove) Token: 0x0600074F RID: 1871 RVA: 0x0001A6F0 File Offset: 0x000188F0
		public event Action<bool, PortraitsListaModelo> soloFavoritosChanged;

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06000750 RID: 1872 RVA: 0x0001A728 File Offset: 0x00018928
		// (remove) Token: 0x06000751 RID: 1873 RVA: 0x0001A760 File Offset: 0x00018960
		public event Action<string, PortraitsListaModelo> buscandoChanged;

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x06000752 RID: 1874 RVA: 0x0001A798 File Offset: 0x00018998
		// (remove) Token: 0x06000753 RID: 1875 RVA: 0x0001A7D0 File Offset: 0x000189D0
		public event Action<PortraitsListaModelo.Item, int, PortraitsListaModelo> favoriteStateChanged;

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x06000754 RID: 1876 RVA: 0x0001A808 File Offset: 0x00018A08
		// (remove) Token: 0x06000755 RID: 1877 RVA: 0x0001A840 File Offset: 0x00018A40
		public event Action<PortraitsListaModelo.Item, int, PortraitsListaModelo> itemClicked;

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000756 RID: 1878 RVA: 0x0001A875 File Offset: 0x00018A75
		// (set) Token: 0x06000757 RID: 1879 RVA: 0x0001A87D File Offset: 0x00018A7D
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

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000758 RID: 1880 RVA: 0x0001A886 File Offset: 0x00018A86
		// (set) Token: 0x06000759 RID: 1881 RVA: 0x0001A88E File Offset: 0x00018A8E
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

		// Token: 0x0600075A RID: 1882 RVA: 0x0001A898 File Offset: 0x00018A98
		[MemberValueChangedListener(member = "items")]
		protected void OnFavoriteStateChanged(IUIElementoConValor elemento)
		{
			PortraitsListaModelo.Item valueOrDefault = this.items.GetValueOrDefault(elemento.modelItemIndex);
			valueOrDefault.favorito = !valueOrDefault.favorito;
			Action<PortraitsListaModelo.Item, int, PortraitsListaModelo> action = this.favoriteStateChanged;
			if (action == null)
			{
				return;
			}
			action(valueOrDefault, elemento.modelItemIndex, this);
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x0001A8E0 File Offset: 0x00018AE0
		[MemberClickedListener(member = "items")]
		protected void OnItemClicked(IUIElementoClickable elemento)
		{
			PortraitsListaModelo.Item valueOrDefault = this.items.GetValueOrDefault(elemento.modelItemIndex);
			Action<PortraitsListaModelo.Item, int, PortraitsListaModelo> action = this.itemClicked;
			if (action == null)
			{
				return;
			}
			action(valueOrDefault, elemento.modelItemIndex, this);
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x0001A918 File Offset: 0x00018B18
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
				Action<bool, PortraitsListaModelo> action = this.soloFavoritosChanged;
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
				Action<string, PortraitsListaModelo> action2 = this.buscandoChanged;
				if (action2 == null)
				{
					return;
				}
				action2(this.m_buscando, this);
				return;
			}
		}

		// Token: 0x040002E6 RID: 742
		[Ignore]
		public IPanelLayoutAttribute layout;

		// Token: 0x040002EB RID: 747
		[Ignore]
		[SerializeField]
		private bool m_soloFavoritos;

		// Token: 0x040002EC RID: 748
		[Ignore]
		[SerializeField]
		private string m_buscando;

		// Token: 0x040002ED RID: 749
		[FavoritableGenericPortrait]
		public List<PortraitsListaModelo.Item> items = new List<PortraitsListaModelo.Item>();

		// Token: 0x020001C2 RID: 450
		[Serializable]
		public class Item : IMultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, string, bool>, IMultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, string>, IMultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler>, IMultipleValorElemento<string, string>, IMultipleValorElemento<string>
		{
			// Token: 0x06000C1C RID: 3100 RVA: 0x000252F6 File Offset: 0x000234F6
			public Item()
			{
			}

			// Token: 0x06000C1D RID: 3101 RVA: 0x000252FE File Offset: 0x000234FE
			public Item(string id, string NombreCompleto, SelectablePortraitCargarThumbnailHandler Loader, string ResaltoText, bool esFavorito)
			{
				this.ID = id;
				this.nombreCompleto = NombreCompleto;
				this.loader = Loader;
				this.resaltoText = ResaltoText;
				this.favorito = esFavorito;
			}

			// Token: 0x17000302 RID: 770
			// (get) Token: 0x06000C1E RID: 3102 RVA: 0x0002532B File Offset: 0x0002352B
			public string item1
			{
				get
				{
					return this.ID;
				}
			}

			// Token: 0x17000303 RID: 771
			// (get) Token: 0x06000C1F RID: 3103 RVA: 0x00025333 File Offset: 0x00023533
			public string item2
			{
				get
				{
					return this.nombreCompleto;
				}
			}

			// Token: 0x17000304 RID: 772
			// (get) Token: 0x06000C20 RID: 3104 RVA: 0x0002533B File Offset: 0x0002353B
			public SelectablePortraitCargarThumbnailHandler item3
			{
				get
				{
					return this.loader;
				}
			}

			// Token: 0x17000305 RID: 773
			// (get) Token: 0x06000C21 RID: 3105 RVA: 0x00025343 File Offset: 0x00023543
			public string item4
			{
				get
				{
					return this.resaltoText;
				}
			}

			// Token: 0x17000306 RID: 774
			// (get) Token: 0x06000C22 RID: 3106 RVA: 0x0002534B File Offset: 0x0002354B
			public bool item5
			{
				get
				{
					return this.favorito;
				}
			}

			// Token: 0x040005A7 RID: 1447
			public string ID;

			// Token: 0x040005A8 RID: 1448
			public string nombreCompleto;

			// Token: 0x040005A9 RID: 1449
			public SelectablePortraitCargarThumbnailHandler loader;

			// Token: 0x040005AA RID: 1450
			public string resaltoText;

			// Token: 0x040005AB RID: 1451
			public bool favorito;
		}
	}
}
