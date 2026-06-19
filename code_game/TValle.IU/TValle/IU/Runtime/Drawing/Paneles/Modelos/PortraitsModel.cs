using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos
{
	// Token: 0x02000104 RID: 260
	[Modelo]
	[Label("Select a Model...", alignment = TextAlignmentOptions.MidlineLeft, color = ColorEnum.black, fontSize = 18)]
	[Panel(tipo = TipoDePanel.scrollableDePortraits)]
	[Serializable]
	public class PortraitsModel : PortraitsModelBase<MultipleValorElemento<string, bool>>
	{
		// Token: 0x17000241 RID: 577
		// (get) Token: 0x060007BD RID: 1981 RVA: 0x0001B66E File Offset: 0x0001986E
		public override List<MultipleValorElemento<string, bool>> protraitsDisponibles
		{
			get
			{
				return this.disponibles;
			}
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0001B678 File Offset: 0x00019878
		protected override void OnBindig()
		{
			List<string> list;
			this.disponibles = (from e in ArchivosEnDisco.ExistentesPorFechaModificacion(".png", out list, new GameFolders.Tipo[]
				{
					GameFolders.Tipo.charactersV2,
					GameFolders.Tipo.characters
				})
				select new MultipleValorElemento<string, bool>(e, false)).ToList<MultipleValorElemento<string, bool>>();
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x0001B6D0 File Offset: 0x000198D0
		[MemberValueChangedListener(member = "disponibles")]
		protected void OnOverallChanged(IUIElementoConValor elemento)
		{
			ScrollablePortraitPanel scrollablePortraitPanel = (ScrollablePortraitPanel)base.panel;
			for (int i = 0; i < scrollablePortraitPanel.portraits.Count; i++)
			{
				if (scrollablePortraitPanel.portraits[i].toggle.isOn)
				{
					base.isSelected = true;
					this.m_currentSelected = i;
					return;
				}
			}
			this.m_currentSelected = -1;
			base.isSelected = false;
		}

		// Token: 0x0400030B RID: 779
		[Portrait]
		public List<MultipleValorElemento<string, bool>> disponibles;
	}
}
