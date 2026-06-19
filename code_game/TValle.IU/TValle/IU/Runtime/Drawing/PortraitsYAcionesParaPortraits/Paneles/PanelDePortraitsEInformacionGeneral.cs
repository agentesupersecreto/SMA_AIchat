using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.PortraitsYAcionesParaPortraits.Modelos;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.PortraitsYAcionesParaPortraits.Paneles
{
	// Token: 0x020000EF RID: 239
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class PanelDePortraitsEInformacionGeneral : PanelBaseSingleModel<InformacionGeneralDePortraitModelo>
	{
		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000734 RID: 1844 RVA: 0x0001A0F4 File Offset: 0x000182F4
		// (remove) Token: 0x06000735 RID: 1845 RVA: 0x0001A12C File Offset: 0x0001832C
		public event PanelDePortraitsEInformacionGeneral.LoadingHandler loading;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06000736 RID: 1846 RVA: 0x0001A164 File Offset: 0x00018364
		// (remove) Token: 0x06000737 RID: 1847 RVA: 0x0001A19C File Offset: 0x0001839C
		public event PanelDePortraitsEInformacionGeneral.LoadingPortraitsHandler loadingItems;

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06000738 RID: 1848 RVA: 0x0001A1D4 File Offset: 0x000183D4
		// (remove) Token: 0x06000739 RID: 1849 RVA: 0x0001A20C File Offset: 0x0001840C
		public event PanelDePortraitsEInformacionGeneral.LoadingInformacionGeneraDePortraitHandler loadingInformacionGeneraDePortrait;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x0600073A RID: 1850 RVA: 0x0001A244 File Offset: 0x00018444
		// (remove) Token: 0x0600073B RID: 1851 RVA: 0x0001A27C File Offset: 0x0001847C
		public event PanelDePortraitsEInformacionGeneral.ItemsFavoriteStateChangedHandler itemsFavoriteStateChanged;

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x0600073C RID: 1852 RVA: 0x0001A2B4 File Offset: 0x000184B4
		// (remove) Token: 0x0600073D RID: 1853 RVA: 0x0001A2EC File Offset: 0x000184EC
		public event Action onCleared;

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x0001A321 File Offset: 0x00018521
		public InformacionGeneralDePortraitModelo currentModel
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x0001A329 File Offset: 0x00018529
		protected override void OnBinding()
		{
			base.OnBinding();
			PanelDePortraitsEInformacionGeneral.LoadingHandler loadingHandler = this.loading;
			if (loadingHandler != null)
			{
				loadingHandler(ref this.m_model, this);
			}
			this.OnLoading();
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x0001A350 File Offset: 0x00018550
		protected override void OnBinded()
		{
			base.OnBinded();
			this.m_model.portraitsLista.soloFavoritosChanged += this.SoloFavoritosChanged;
			this.m_model.portraitsLista.buscandoChanged += this.BuscandoChanged;
			this.m_model.portraitsLista.favoriteStateChanged += this.FavoriteStateChanged;
			this.m_model.portraitsLista.itemClicked += this.ItemClicked;
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x0001A3D4 File Offset: 0x000185D4
		protected override void OnClearing()
		{
			base.OnClearing();
			this.m_model.portraitsLista.soloFavoritosChanged -= this.SoloFavoritosChanged;
			this.m_model.portraitsLista.buscandoChanged -= this.BuscandoChanged;
			this.m_model.portraitsLista.favoriteStateChanged -= this.FavoriteStateChanged;
			this.m_model.portraitsLista.itemClicked -= this.ItemClicked;
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x0001A457 File Offset: 0x00018657
		protected override void OnCleared()
		{
			base.OnCleared();
			Action action = this.onCleared;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x0001A46F File Offset: 0x0001866F
		private void OnLoading()
		{
			PanelDePortraitsEInformacionGeneral.LoadingPortraitsHandler loadingPortraitsHandler = this.loadingItems;
			if (loadingPortraitsHandler == null)
			{
				return;
			}
			loadingPortraitsHandler(this.m_model.portraitsLista.soloFavoritos, this.m_model.portraitsLista.buscando, ref this.m_model, this);
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x0001A4A8 File Offset: 0x000186A8
		private void SoloFavoritosChanged(bool arg1, PortraitsListaModelo arg2)
		{
			PanelDePortraitsEInformacionGeneral.LoadingPortraitsHandler loadingPortraitsHandler = this.loadingItems;
			if (loadingPortraitsHandler != null)
			{
				loadingPortraitsHandler(this.m_model.portraitsLista.soloFavoritos, this.m_model.portraitsLista.buscando, ref this.m_model, this);
			}
			this.OnLoading();
			this.ReDrawLista();
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x0001A4FC File Offset: 0x000186FC
		private void BuscandoChanged(string arg1, PortraitsListaModelo arg2)
		{
			PanelDePortraitsEInformacionGeneral.LoadingPortraitsHandler loadingPortraitsHandler = this.loadingItems;
			if (loadingPortraitsHandler != null)
			{
				loadingPortraitsHandler(this.m_model.portraitsLista.soloFavoritos, this.m_model.portraitsLista.buscando, ref this.m_model, this);
			}
			this.OnLoading();
			this.ReDrawLista();
			string text = "portraitsLista";
			IUIElemento iuielemento;
			if (base.UIPanel.elementoPorModelo.TryGetValue(text, out iuielemento))
			{
				TMP_InputField buscadorInput = (iuielemento as ScrollablePanelConBuscadorYFavoritos).buscadorInput;
				buscadorInput.Select();
				buscadorInput.ActivateInputField();
				buscadorInput.caretPosition = buscadorInput.text.Length;
			}
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x0001A58F File Offset: 0x0001878F
		private void FavoriteStateChanged(PortraitsListaModelo.Item item, int arg1, PortraitsListaModelo arg2)
		{
			PanelDePortraitsEInformacionGeneral.ItemsFavoriteStateChangedHandler itemsFavoriteStateChangedHandler = this.itemsFavoriteStateChanged;
			if (itemsFavoriteStateChangedHandler == null)
			{
				return;
			}
			itemsFavoriteStateChangedHandler(item.favorito, item, this);
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x0001A5A9 File Offset: 0x000187A9
		private void ItemClicked(PortraitsListaModelo.Item item, int arg1, PortraitsListaModelo arg2)
		{
			PanelDePortraitsEInformacionGeneral.LoadingInformacionGeneraDePortraitHandler loadingInformacionGeneraDePortraitHandler = this.loadingInformacionGeneraDePortrait;
			if (loadingInformacionGeneraDePortraitHandler != null)
			{
				loadingInformacionGeneraDePortraitHandler(item, arg1, ref this.m_model.informacionGeneral, this);
			}
			this.ReDrawDetalles();
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x0001A5D0 File Offset: 0x000187D0
		private void ReDrawLista()
		{
			IUIPanel iuipanel = null;
			string text = "portraitsLista";
			IUIElemento iuielemento;
			if (base.UIPanel.elementoPorModelo.TryGetValue(text, out iuielemento))
			{
				iuipanel = iuielemento as IUIPanel;
			}
			base.ReDrawSubModelo(this.m_model.portraitsLista, text, ref iuipanel, base.UIPanel, base.UIPanel.GetParentPara(0));
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x0001A628 File Offset: 0x00018828
		public void ReDrawDetalles()
		{
			IUIPanel iuipanel = null;
			string text = "informacionGeneral";
			IUIElemento iuielemento;
			if (base.UIPanel.elementoPorModelo.TryGetValue(text, out iuielemento))
			{
				iuipanel = iuielemento as IUIPanel;
			}
			base.ReDrawSubModelo(this.m_model.informacionGeneral, text, ref iuipanel, base.UIPanel, base.UIPanel.GetParentPara(1));
		}

		// Token: 0x020001BE RID: 446
		// (Invoke) Token: 0x06000C0D RID: 3085
		public delegate void LoadingHandler(ref InformacionGeneralDePortraitModelo modelo, PanelDePortraitsEInformacionGeneral sender);

		// Token: 0x020001BF RID: 447
		// (Invoke) Token: 0x06000C11 RID: 3089
		public delegate void LoadingPortraitsHandler(bool soloFavoritos, string buscando, ref InformacionGeneralDePortraitModelo modelo, PanelDePortraitsEInformacionGeneral sender);

		// Token: 0x020001C0 RID: 448
		// (Invoke) Token: 0x06000C15 RID: 3093
		public delegate void LoadingInformacionGeneraDePortraitHandler(PortraitsListaModelo.Item portraitsData, int index, ref object subModeloInformacionGeneralDePortrait, PanelDePortraitsEInformacionGeneral sender);

		// Token: 0x020001C1 RID: 449
		// (Invoke) Token: 0x06000C19 RID: 3097
		public delegate void ItemsFavoriteStateChangedHandler(bool newValue, PortraitsListaModelo.Item portraitsData, PanelDePortraitsEInformacionGeneral sender);
	}
}
