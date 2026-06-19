using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;

namespace Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Modelos
{
	// Token: 0x02000113 RID: 275
	[Modelo]
	[UnTittle]
	[Panel(tipo = TipoDePanel.scrollableFlotante, panelLayoutDynamicMethodTarget = "GetLayout")]
	[Serializable]
	public class TabsListaModelo
	{
		// Token: 0x06000828 RID: 2088 RVA: 0x0001C56F File Offset: 0x0001A76F
		public IPanelLayoutAttribute GetLayout()
		{
			return this.layout;
		}

		// Token: 0x1400003D RID: 61
		// (add) Token: 0x06000829 RID: 2089 RVA: 0x0001C578 File Offset: 0x0001A778
		// (remove) Token: 0x0600082A RID: 2090 RVA: 0x0001C5B0 File Offset: 0x0001A7B0
		public event Action<LabelData, int, TabsListaModelo> itemClicked;

		// Token: 0x0600082B RID: 2091 RVA: 0x0001C5E8 File Offset: 0x0001A7E8
		[MemberBotonClickedListener(member = "items")]
		protected void OnItemClicked(IUIBoton elemento)
		{
			LabelData valueOrDefault = this.items.GetValueOrDefault(elemento.modelItemIndex);
			Action<LabelData, int, TabsListaModelo> action = this.itemClicked;
			if (action == null)
			{
				return;
			}
			action(valueOrDefault, elemento.modelItemIndex, this);
		}

		// Token: 0x04000335 RID: 821
		[Ignore]
		public IPanelLayoutAttribute layout;

		// Token: 0x04000337 RID: 823
		[ClickableLabelConValor]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
		public List<LabelData> items = new List<LabelData>();
	}
}
