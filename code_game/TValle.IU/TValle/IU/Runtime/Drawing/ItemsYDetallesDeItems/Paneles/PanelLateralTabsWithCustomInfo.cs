using System;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Modelos;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;

namespace Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Paneles
{
	// Token: 0x0200010D RID: 269
	public class PanelLateralTabsWithCustomInfo : PanelBaseSingleModel<TabsWithCustomInfoModelo>
	{
		// Token: 0x14000034 RID: 52
		// (add) Token: 0x060007F8 RID: 2040 RVA: 0x0001BD9C File Offset: 0x00019F9C
		// (remove) Token: 0x060007F9 RID: 2041 RVA: 0x0001BDD4 File Offset: 0x00019FD4
		public event PanelLateralTabsWithCustomInfo.LoadingHandler loading;

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x060007FA RID: 2042 RVA: 0x0001BE0C File Offset: 0x0001A00C
		// (remove) Token: 0x060007FB RID: 2043 RVA: 0x0001BE44 File Offset: 0x0001A044
		public event PanelLateralTabsWithCustomInfo.LoadingPortraitsHandler loadingItems;

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x060007FC RID: 2044 RVA: 0x0001BE7C File Offset: 0x0001A07C
		// (remove) Token: 0x060007FD RID: 2045 RVA: 0x0001BEB4 File Offset: 0x0001A0B4
		public event PanelLateralTabsWithCustomInfo.LoadingInformacionGeneraDePortraitHandler loadingInformacionGenera;

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x060007FE RID: 2046 RVA: 0x0001BEEC File Offset: 0x0001A0EC
		// (remove) Token: 0x060007FF RID: 2047 RVA: 0x0001BF24 File Offset: 0x0001A124
		public event Action onCleared;

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000800 RID: 2048 RVA: 0x0001BF59 File Offset: 0x0001A159
		public TabsWithCustomInfoModelo currentModel
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x0001BF61 File Offset: 0x0001A161
		protected override void OnBinding()
		{
			base.OnBinding();
			PanelLateralTabsWithCustomInfo.LoadingHandler loadingHandler = this.loading;
			if (loadingHandler != null)
			{
				loadingHandler(ref this.m_model, this);
			}
			this.OnLoading();
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x0001BF87 File Offset: 0x0001A187
		protected override void OnBinded()
		{
			base.OnBinded();
			this.m_model.tabsList.itemClicked += this.ItemClicked;
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x0001BFAB File Offset: 0x0001A1AB
		protected override void OnClearing()
		{
			base.OnClearing();
			this.m_model.tabsList.itemClicked -= this.ItemClicked;
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x0001BFCF File Offset: 0x0001A1CF
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

		// Token: 0x06000805 RID: 2053 RVA: 0x0001BFE7 File Offset: 0x0001A1E7
		private void OnLoading()
		{
			PanelLateralTabsWithCustomInfo.LoadingPortraitsHandler loadingPortraitsHandler = this.loadingItems;
			if (loadingPortraitsHandler == null)
			{
				return;
			}
			loadingPortraitsHandler(ref this.m_model, this);
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x0001C000 File Offset: 0x0001A200
		private void ItemClicked(LabelData item, int arg1, TabsListaModelo arg2)
		{
			PanelLateralTabsWithCustomInfo.LoadingInformacionGeneraDePortraitHandler loadingInformacionGeneraDePortraitHandler = this.loadingInformacionGenera;
			if (loadingInformacionGeneraDePortraitHandler != null)
			{
				loadingInformacionGeneraDePortraitHandler(item, arg1, ref this.m_model.informacionGeneral, this);
			}
			this.ReDrawDetalles();
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x0001C028 File Offset: 0x0001A228
		public void ReDrawLista()
		{
			IUIPanel iuipanel = null;
			string text = "tabsList";
			IUIElemento iuielemento;
			if (base.UIPanel.elementoPorModelo.TryGetValue(text, out iuielemento))
			{
				iuipanel = iuielemento as IUIPanel;
			}
			base.ReDrawSubModelo(this.m_model.tabsList, text, ref iuipanel, base.UIPanel, base.UIPanel.GetParentPara(0));
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x0001C080 File Offset: 0x0001A280
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

		// Token: 0x020001C9 RID: 457
		// (Invoke) Token: 0x06000C37 RID: 3127
		public delegate void LoadingHandler(ref TabsWithCustomInfoModelo modelo, PanelLateralTabsWithCustomInfo sender);

		// Token: 0x020001CA RID: 458
		// (Invoke) Token: 0x06000C3B RID: 3131
		public delegate void LoadingPortraitsHandler(ref TabsWithCustomInfoModelo modelo, PanelLateralTabsWithCustomInfo sender);

		// Token: 0x020001CB RID: 459
		// (Invoke) Token: 0x06000C3F RID: 3135
		public delegate void LoadingInformacionGeneraDePortraitHandler(LabelData itemData, int index, ref object subModeloInformacionGeneral, PanelLateralTabsWithCustomInfo sender);
	}
}
