using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos
{
	// Token: 0x020000FF RID: 255
	[Modelo]
	[Label("Select a Gesture...", alignment = TextAlignmentOptions.MidlineLeft, color = ColorEnum.black, fontSize = 18)]
	[Panel(tipo = TipoDePanel.scrollableDeGesturePortraits)]
	[Serializable]
	public class GesturePortraitsModel : PortraitsModelBase<MultipleValorElemento<string, bool>>
	{
		// Token: 0x1700023C RID: 572
		// (get) Token: 0x0600078F RID: 1935 RVA: 0x0001AD94 File Offset: 0x00018F94
		public override List<MultipleValorElemento<string, bool>> protraitsDisponibles
		{
			get
			{
				return this.disponibles;
			}
		}

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x06000790 RID: 1936 RVA: 0x0001AD9C File Offset: 0x00018F9C
		// (remove) Token: 0x06000791 RID: 1937 RVA: 0x0001ADD4 File Offset: 0x00018FD4
		public event Action<GesturePortraitsModel> onBindig;

		// Token: 0x06000792 RID: 1938 RVA: 0x0001AE09 File Offset: 0x00019009
		protected override void OnBindig()
		{
			Action<GesturePortraitsModel> action = this.onBindig;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x0001AE1C File Offset: 0x0001901C
		[MemberValueChangedListener(member = "disponibles")]
		protected void OnOverallChanged(IUIElementoConValor elemento)
		{
			ScrollableGesturePortraitPanel scrollableGesturePortraitPanel = (ScrollableGesturePortraitPanel)base.panel;
			for (int i = 0; i < scrollableGesturePortraitPanel.portraits.Count; i++)
			{
				if (scrollableGesturePortraitPanel.portraits[i].toggle.isOn)
				{
					base.isSelected = true;
					this.m_currentSelected = i;
					return;
				}
			}
			this.m_currentSelected = -1;
			base.isSelected = false;
		}

		// Token: 0x040002FC RID: 764
		[GesturePortrait]
		public List<MultipleValorElemento<string, bool>> disponibles;
	}
}
