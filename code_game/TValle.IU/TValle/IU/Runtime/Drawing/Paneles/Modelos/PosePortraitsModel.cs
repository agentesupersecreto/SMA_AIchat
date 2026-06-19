using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos
{
	// Token: 0x02000105 RID: 261
	[Modelo]
	[Label("Select a Pose...", alignment = TextAlignmentOptions.MidlineLeft, color = ColorEnum.black, fontSize = 18)]
	[Panel(tipo = TipoDePanel.scrollableDePosePortraits)]
	[Serializable]
	public class PosePortraitsModel : PortraitsModelBase<MultipleValorElemento<string, bool>>
	{
		// Token: 0x17000242 RID: 578
		// (get) Token: 0x060007C1 RID: 1985 RVA: 0x0001B73C File Offset: 0x0001993C
		public override List<MultipleValorElemento<string, bool>> protraitsDisponibles
		{
			get
			{
				return this.disponibles;
			}
		}

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x060007C2 RID: 1986 RVA: 0x0001B744 File Offset: 0x00019944
		// (remove) Token: 0x060007C3 RID: 1987 RVA: 0x0001B77C File Offset: 0x0001997C
		public event Action<PosePortraitsModel> onBindig;

		// Token: 0x060007C4 RID: 1988 RVA: 0x0001B7B1 File Offset: 0x000199B1
		protected override void OnBindig()
		{
			Action<PosePortraitsModel> action = this.onBindig;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x0001B7C4 File Offset: 0x000199C4
		[MemberValueChangedListener(member = "disponibles")]
		protected void OnOverallChanged(IUIElementoConValor elemento)
		{
			ScrollablePosePortraitPanel scrollablePosePortraitPanel = (ScrollablePosePortraitPanel)base.panel;
			for (int i = 0; i < scrollablePosePortraitPanel.portraits.Count; i++)
			{
				if (scrollablePosePortraitPanel.portraits[i].toggle.isOn)
				{
					base.isSelected = true;
					this.m_currentSelected = i;
					return;
				}
			}
			this.m_currentSelected = -1;
			base.isSelected = false;
		}

		// Token: 0x0400030C RID: 780
		[PosePortrait]
		public List<MultipleValorElemento<string, bool>> disponibles;
	}
}
