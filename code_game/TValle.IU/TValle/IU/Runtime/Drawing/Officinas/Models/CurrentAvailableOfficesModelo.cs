using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;

namespace Assets.TValle.IU.Runtime.Drawing.Officinas.Models
{
	// Token: 0x02000107 RID: 263
	[Modelo]
	[Label("Select an Office...", alignment = TextAlignmentOptions.MidlineLeft, color = ColorEnum.black, fontSize = 18)]
	[Panel(tipo = TipoDePanel.scrollableOfficePortraits)]
	[Serializable]
	public class CurrentAvailableOfficesModelo : PortraitsModelBase<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>
	{
		// Token: 0x17000244 RID: 580
		// (get) Token: 0x060007CA RID: 1994 RVA: 0x0001B848 File Offset: 0x00019A48
		public override List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> protraitsDisponibles
		{
			get
			{
				return this.disponibles;
			}
		}

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x060007CB RID: 1995 RVA: 0x0001B850 File Offset: 0x00019A50
		// (remove) Token: 0x060007CC RID: 1996 RVA: 0x0001B888 File Offset: 0x00019A88
		public event Action<CurrentAvailableOfficesModelo> onBindig;

		// Token: 0x060007CD RID: 1997 RVA: 0x0001B8BD File Offset: 0x00019ABD
		protected override void OnBindig()
		{
			Action<CurrentAvailableOfficesModelo> action = this.onBindig;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x0001B8D0 File Offset: 0x00019AD0
		protected override void Binded(IUIPanel to)
		{
			base.Binded(to);
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x0001B8D9 File Offset: 0x00019AD9
		private string ShowInfo(out float widthMod, int index)
		{
			widthMod = 0.5f;
			return this.infoGetter(index);
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x0001B8F0 File Offset: 0x00019AF0
		[MemberValueChangedListener(member = "disponibles")]
		protected void OnOverallChanged(IUIElementoConValor elemento)
		{
			ScrollableOfficePortraitPanel scrollableOfficePortraitPanel = (ScrollableOfficePortraitPanel)base.panel;
			for (int i = 0; i < scrollableOfficePortraitPanel.portraits.Count; i++)
			{
				if (scrollableOfficePortraitPanel.portraits[i].toggle.isOn)
				{
					base.isSelected = true;
					this.m_currentSelected = i;
					return;
				}
			}
			this.m_currentSelected = -1;
			base.isSelected = false;
		}

		// Token: 0x0400030E RID: 782
		[DescripcionDinamica(dinamicoMethodTarget = "ShowInfo")]
		[OfficePortrait(imageIsDiskAsset = true)]
		public List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> disponibles;

		// Token: 0x04000310 RID: 784
		public Func<int, string> infoGetter;
	}
}
