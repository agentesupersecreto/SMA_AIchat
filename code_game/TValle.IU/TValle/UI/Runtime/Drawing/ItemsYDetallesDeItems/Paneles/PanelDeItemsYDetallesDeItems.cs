using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Modelos;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets.TValle.UI.Runtime.Drawing.ItemsYDetallesDeItems.Paneles
{
	// Token: 0x020000C5 RID: 197
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class PanelDeItemsYDetallesDeItems : PanelBaseSingleModel<InformacionDetalladaDeItemsModelo>
	{
		// Token: 0x1400000B RID: 11
		// (add) Token: 0x0600057A RID: 1402 RVA: 0x000152EC File Offset: 0x000134EC
		// (remove) Token: 0x0600057B RID: 1403 RVA: 0x00015324 File Offset: 0x00013524
		public event PanelDeItemsYDetallesDeItems.LoadingHandler loading;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600057C RID: 1404 RVA: 0x0001535C File Offset: 0x0001355C
		// (remove) Token: 0x0600057D RID: 1405 RVA: 0x00015394 File Offset: 0x00013594
		public event PanelDeItemsYDetallesDeItems.LoadingItemsHandler loadingItems;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x0600057E RID: 1406 RVA: 0x000153CC File Offset: 0x000135CC
		// (remove) Token: 0x0600057F RID: 1407 RVA: 0x00015404 File Offset: 0x00013604
		public event PanelDeItemsYDetallesDeItems.LoadingDetallesHandler loadingDetalles;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000580 RID: 1408 RVA: 0x0001543C File Offset: 0x0001363C
		// (remove) Token: 0x06000581 RID: 1409 RVA: 0x00015474 File Offset: 0x00013674
		public event PanelDeItemsYDetallesDeItems.ItemsFavoriteStateChangedHandler itemsFavoriteStateChanged;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000582 RID: 1410 RVA: 0x000154AC File Offset: 0x000136AC
		// (remove) Token: 0x06000583 RID: 1411 RVA: 0x000154E4 File Offset: 0x000136E4
		public event PanelDeItemsYDetallesDeItems.ItemsClickedHandler itemsClicked;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000584 RID: 1412 RVA: 0x0001551C File Offset: 0x0001371C
		// (remove) Token: 0x06000585 RID: 1413 RVA: 0x00015554 File Offset: 0x00013754
		public event PanelDeItemsYDetallesDeItems.DetallesAccionHandler accion1Clicked;

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000586 RID: 1414 RVA: 0x00015589 File Offset: 0x00013789
		public InformacionDetalladaDeItemsModelo agenciasModel
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00015591 File Offset: 0x00013791
		protected override void OnBinding()
		{
			base.OnBinding();
			PanelDeItemsYDetallesDeItems.LoadingHandler loadingHandler = this.loading;
			if (loadingHandler != null)
			{
				loadingHandler(ref this.m_model, this);
			}
			this.OnLoading();
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x000155B8 File Offset: 0x000137B8
		protected override void OnBinded()
		{
			base.OnBinded();
			this.m_model.agenciasListaModelo.soloFavoritosChanged += this.AgenciasListaModelo_soloFavoritosChanged;
			this.m_model.agenciasListaModelo.buscandoChanged += this.AgenciasListaModelo_buscandoChanged;
			this.m_model.agenciasListaModelo.favoriteStateChanged += this.AgenciasListaModelo_favoriteStateChanged;
			this.m_model.agenciasListaModelo.itemClicked += this.AgenciasListaModelo_itemClicked;
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x0001563C File Offset: 0x0001383C
		protected override void OnClearing()
		{
			base.OnClearing();
			this.m_model.agenciasListaModelo.soloFavoritosChanged -= this.AgenciasListaModelo_soloFavoritosChanged;
			this.m_model.agenciasListaModelo.buscandoChanged -= this.AgenciasListaModelo_buscandoChanged;
			this.m_model.agenciasListaModelo.favoriteStateChanged -= this.AgenciasListaModelo_favoriteStateChanged;
			this.m_model.agenciasListaModelo.itemClicked -= this.AgenciasListaModelo_itemClicked;
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x000156BF File Offset: 0x000138BF
		private void OnLoading()
		{
			PanelDeItemsYDetallesDeItems.LoadingItemsHandler loadingItemsHandler = this.loadingItems;
			if (loadingItemsHandler == null)
			{
				return;
			}
			loadingItemsHandler(this.m_model.agenciasListaModelo.soloFavoritos, this.m_model.agenciasListaModelo.buscando, ref this.m_model, this);
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x000156F8 File Offset: 0x000138F8
		private void AgenciasListaModelo_buscandoChanged(string arg1, ItemsListaModelo arg2)
		{
			PanelDeItemsYDetallesDeItems.LoadingItemsHandler loadingItemsHandler = this.loadingItems;
			if (loadingItemsHandler != null)
			{
				loadingItemsHandler(this.m_model.agenciasListaModelo.soloFavoritos, this.m_model.agenciasListaModelo.buscando, ref this.m_model, this);
			}
			this.OnLoading();
			this.ReDrawLista();
			string text = "agenciasListaModelo";
			IUIElemento iuielemento;
			if (base.UIPanel.elementoPorModelo.TryGetValue(text, out iuielemento))
			{
				TMP_InputField buscadorInput = (iuielemento as ScrollablePanelConBuscadorYFavoritos).buscadorInput;
				buscadorInput.Select();
				buscadorInput.ActivateInputField();
				buscadorInput.caretPosition = buscadorInput.text.Length;
			}
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x0001578C File Offset: 0x0001398C
		private void AgenciasListaModelo_soloFavoritosChanged(bool arg1, ItemsListaModelo arg2)
		{
			PanelDeItemsYDetallesDeItems.LoadingItemsHandler loadingItemsHandler = this.loadingItems;
			if (loadingItemsHandler != null)
			{
				loadingItemsHandler(this.m_model.agenciasListaModelo.soloFavoritos, this.m_model.agenciasListaModelo.buscando, ref this.m_model, this);
			}
			this.OnLoading();
			this.ReDrawLista();
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x000157DD File Offset: 0x000139DD
		private void AgenciasListaModelo_favoriteStateChanged(ItemsListaModelo.Item item, int arg1, ItemsListaModelo arg2)
		{
			PanelDeItemsYDetallesDeItems.ItemsFavoriteStateChangedHandler itemsFavoriteStateChangedHandler = this.itemsFavoriteStateChanged;
			if (itemsFavoriteStateChangedHandler == null)
			{
				return;
			}
			itemsFavoriteStateChangedHandler(item.favorito, item, this);
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x000157F8 File Offset: 0x000139F8
		private void AgenciasListaModelo_itemClicked(ItemsListaModelo.Item item, int arg1, ItemsListaModelo arg2)
		{
			this.m_model.detalles.accion1 -= this.Detalles_accion1;
			PanelDeItemsYDetallesDeItems.LoadingDetallesHandler loadingDetallesHandler = this.loadingDetalles;
			if (loadingDetallesHandler != null)
			{
				loadingDetallesHandler(item, arg1, ref this.m_model.detalles, this);
			}
			this.m_model.detalles.ID = item.ID;
			this.m_model.detalles.accion1 += this.Detalles_accion1;
			this.ReDrawDetalles();
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00015878 File Offset: 0x00013A78
		private void Detalles_accion1(DetallesDeItemModelo obj)
		{
			PanelDeItemsYDetallesDeItems.DetallesAccionHandler detallesAccionHandler = this.accion1Clicked;
			if (detallesAccionHandler == null)
			{
				return;
			}
			detallesAccionHandler((obj != null) ? obj.ID : null, obj, this);
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00015898 File Offset: 0x00013A98
		private void ReDrawDetalles()
		{
			IUIPanel iuipanel = null;
			string text = "detalles";
			IUIElemento iuielemento;
			if (base.UIPanel.elementoPorModelo.TryGetValue(text, out iuielemento))
			{
				iuipanel = iuielemento as IUIPanel;
			}
			base.ReDrawSubModelo(this.m_model.detalles, text, ref iuipanel, base.UIPanel, base.UIPanel.GetParentPara(1));
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x000158F0 File Offset: 0x00013AF0
		private void ReDrawLista()
		{
			IUIPanel iuipanel = null;
			string text = "agenciasListaModelo";
			IUIElemento iuielemento;
			if (base.UIPanel.elementoPorModelo.TryGetValue(text, out iuielemento))
			{
				iuipanel = iuielemento as IUIPanel;
			}
			base.ReDrawSubModelo(this.m_model.agenciasListaModelo, text, ref iuipanel, base.UIPanel, base.UIPanel.GetParentPara(0));
		}

		// Token: 0x02000197 RID: 407
		// (Invoke) Token: 0x06000B46 RID: 2886
		public delegate void LoadingHandler(ref InformacionDetalladaDeItemsModelo modelo, PanelDeItemsYDetallesDeItems sender);

		// Token: 0x02000198 RID: 408
		// (Invoke) Token: 0x06000B4A RID: 2890
		public delegate void LoadingItemsHandler(bool soloFavoritos, string buscando, ref InformacionDetalladaDeItemsModelo modelo, PanelDeItemsYDetallesDeItems sender);

		// Token: 0x02000199 RID: 409
		// (Invoke) Token: 0x06000B4E RID: 2894
		public delegate void LoadingDetallesHandler(ItemsListaModelo.Item item, int index, ref DetallesDeItemModelo modelo, PanelDeItemsYDetallesDeItems sender);

		// Token: 0x0200019A RID: 410
		// (Invoke) Token: 0x06000B52 RID: 2898
		public delegate void ItemsFavoriteStateChangedHandler(bool newValue, ItemsListaModelo.Item item, PanelDeItemsYDetallesDeItems sender);

		// Token: 0x0200019B RID: 411
		// (Invoke) Token: 0x06000B56 RID: 2902
		public delegate void ItemsClickedHandler(ItemsListaModelo.Item item, PanelDeItemsYDetallesDeItems sender);

		// Token: 0x0200019C RID: 412
		// (Invoke) Token: 0x06000B5A RID: 2906
		public delegate void DetallesAccionHandler(string itemID, DetallesDeItemModelo detalles, PanelDeItemsYDetallesDeItems sender);
	}
}
