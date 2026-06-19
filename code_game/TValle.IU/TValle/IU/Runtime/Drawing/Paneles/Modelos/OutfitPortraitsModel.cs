using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos
{
	// Token: 0x02000102 RID: 258
	[Modelo]
	[Label("Select an Outfit...", alignment = TextAlignmentOptions.MidlineLeft, color = ColorEnum.black, fontSize = 18)]
	[Panel(tipo = TipoDePanel.scrollableDeOutfitPortraits)]
	[Serializable]
	public class OutfitPortraitsModel : PortraitsModelBase<MultipleValorElemento<string, bool>>
	{
		// Token: 0x17000240 RID: 576
		// (get) Token: 0x060007A9 RID: 1961 RVA: 0x0001B238 File Offset: 0x00019438
		public override List<MultipleValorElemento<string, bool>> protraitsDisponibles
		{
			get
			{
				return this.disponibles;
			}
		}

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x060007AA RID: 1962 RVA: 0x0001B240 File Offset: 0x00019440
		// (remove) Token: 0x060007AB RID: 1963 RVA: 0x0001B278 File Offset: 0x00019478
		public event Action<OutfitPortraitsModel> onBindig;

		// Token: 0x060007AC RID: 1964 RVA: 0x0001B2AD File Offset: 0x000194AD
		protected override void OnBindig()
		{
			Action<OutfitPortraitsModel> action = this.onBindig;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x0001B2C0 File Offset: 0x000194C0
		[MemberValueChangedListener(member = "disponibles")]
		protected void OnOverallChanged(IUIElementoConValor elemento)
		{
			ScrollableOutfitsPortraitPanel scrollableOutfitsPortraitPanel = (ScrollableOutfitsPortraitPanel)base.panel;
			for (int i = 0; i < scrollableOutfitsPortraitPanel.portraits.Count; i++)
			{
				if (scrollableOutfitsPortraitPanel.portraits[i].toggle.isOn)
				{
					base.isSelected = true;
					this.m_currentSelected = i;
					return;
				}
			}
			this.m_currentSelected = -1;
			base.isSelected = false;
		}

		// Token: 0x04000305 RID: 773
		[OutfitPortrait]
		public List<MultipleValorElemento<string, bool>> disponibles;
	}
}
