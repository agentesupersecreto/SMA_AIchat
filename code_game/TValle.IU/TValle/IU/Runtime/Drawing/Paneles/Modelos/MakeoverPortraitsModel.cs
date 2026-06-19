using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos
{
	// Token: 0x02000101 RID: 257
	[Modelo]
	[Label("Select Makeover...", alignment = TextAlignmentOptions.MidlineLeft, color = ColorEnum.black, fontSize = 18)]
	[Panel(tipo = TipoDePanel.scrollableDeMakeoverPortraits)]
	[Serializable]
	public class MakeoverPortraitsModel : PortraitsModelBase<MultipleValorElemento<string, bool>>
	{
		// Token: 0x1700023F RID: 575
		// (get) Token: 0x060007A3 RID: 1955 RVA: 0x0001B144 File Offset: 0x00019344
		public override List<MultipleValorElemento<string, bool>> protraitsDisponibles
		{
			get
			{
				return this.disponibles;
			}
		}

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x060007A4 RID: 1956 RVA: 0x0001B14C File Offset: 0x0001934C
		// (remove) Token: 0x060007A5 RID: 1957 RVA: 0x0001B184 File Offset: 0x00019384
		public event Action<MakeoverPortraitsModel> onBindig;

		// Token: 0x060007A6 RID: 1958 RVA: 0x0001B1B9 File Offset: 0x000193B9
		protected override void OnBindig()
		{
			Action<MakeoverPortraitsModel> action = this.onBindig;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0001B1CC File Offset: 0x000193CC
		[MemberValueChangedListener(member = "disponibles")]
		protected void OnOverallChanged(IUIElementoConValor elemento)
		{
			ScrollableMakeoverPortraitPanel scrollableMakeoverPortraitPanel = (ScrollableMakeoverPortraitPanel)base.panel;
			for (int i = 0; i < scrollableMakeoverPortraitPanel.portraits.Count; i++)
			{
				if (scrollableMakeoverPortraitPanel.portraits[i].toggle.isOn)
				{
					base.isSelected = true;
					this.m_currentSelected = i;
					return;
				}
			}
			this.m_currentSelected = -1;
			base.isSelected = false;
		}

		// Token: 0x04000303 RID: 771
		[MakeoverPortrait]
		public List<MultipleValorElemento<string, bool>> disponibles;
	}
}
