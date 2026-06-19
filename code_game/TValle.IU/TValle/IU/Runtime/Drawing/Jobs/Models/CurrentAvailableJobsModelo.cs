using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;

namespace Assets.TValle.IU.Runtime.Drawing.Jobs.Models
{
	// Token: 0x0200010B RID: 267
	[Modelo]
	[Label("Select a Job...", alignment = TextAlignmentOptions.MidlineLeft, color = ColorEnum.black, fontSize = 18)]
	[Panel(tipo = TipoDePanel.scrollableJobPortraits)]
	[Serializable]
	public class CurrentAvailableJobsModelo : PortraitsModelBase<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>
	{
		// Token: 0x17000248 RID: 584
		// (get) Token: 0x060007E8 RID: 2024 RVA: 0x0001BAC0 File Offset: 0x00019CC0
		public override List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> protraitsDisponibles
		{
			get
			{
				return this.disponibles;
			}
		}

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x060007E9 RID: 2025 RVA: 0x0001BAC8 File Offset: 0x00019CC8
		// (remove) Token: 0x060007EA RID: 2026 RVA: 0x0001BB00 File Offset: 0x00019D00
		public event Action<CurrentAvailableJobsModelo> onBindig;

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x060007EB RID: 2027 RVA: 0x0001BB38 File Offset: 0x00019D38
		// (remove) Token: 0x060007EC RID: 2028 RVA: 0x0001BB70 File Offset: 0x00019D70
		public event Action<string> onPortraitClicked;

		// Token: 0x060007ED RID: 2029 RVA: 0x0001BBA5 File Offset: 0x00019DA5
		protected override void OnBindig()
		{
			Action<CurrentAvailableJobsModelo> action = this.onBindig;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0001BBB8 File Offset: 0x00019DB8
		protected override void Binded(IUIPanel to)
		{
			base.Binded(to);
			IUIElemento iuielemento;
			if (to.elementoPorModelo.TryGetValue("Start", out iuielemento))
			{
				iuielemento.transform.gameObject.SetActive(false);
			}
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x0001BBF1 File Offset: 0x00019DF1
		[MemberClickedListener(member = "disponibles")]
		protected void OnPortraitClicked(IUIElementoClickable elemento)
		{
			if (elemento is SelectablePortraitBase)
			{
				Action<string> action = this.onPortraitClicked;
				if (action == null)
				{
					return;
				}
				action(((SelectablePortraitBase)elemento).idDeProtrait);
			}
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x0001BC16 File Offset: 0x00019E16
		private string ShowInfo(out float widthMod, int index)
		{
			widthMod = 0.5f;
			return this.infoGetter(index);
		}

		// Token: 0x04000314 RID: 788
		[DescripcionDinamica(dinamicoMethodTarget = "ShowInfo")]
		[JobPortrait(imageIsDiskAsset = true)]
		public List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> disponibles;

		// Token: 0x04000317 RID: 791
		public Func<int, string> infoGetter;
	}
}
