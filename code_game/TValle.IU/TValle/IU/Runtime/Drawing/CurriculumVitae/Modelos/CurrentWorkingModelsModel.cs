using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;

namespace Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Modelos
{
	// Token: 0x02000153 RID: 339
	[Modelo]
	[Label("Hired Models (Select a Model...)", alignment = TextAlignmentOptions.MidlineLeft, color = ColorEnum.black, fontSize = 18)]
	[Panel(tipo = TipoDePanel.scrollableWorkingModelsPortraits)]
	[Serializable]
	public class CurrentWorkingModelsModel : PortraitsModelBase<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>
	{
		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x060009FA RID: 2554 RVA: 0x00021337 File Offset: 0x0001F537
		public override List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> protraitsDisponibles
		{
			get
			{
				return this.disponibles;
			}
		}

		// Token: 0x14000052 RID: 82
		// (add) Token: 0x060009FB RID: 2555 RVA: 0x00021340 File Offset: 0x0001F540
		// (remove) Token: 0x060009FC RID: 2556 RVA: 0x00021378 File Offset: 0x0001F578
		public event Action<CurrentWorkingModelsModel> onBindig;

		// Token: 0x14000053 RID: 83
		// (add) Token: 0x060009FD RID: 2557 RVA: 0x000213B0 File Offset: 0x0001F5B0
		// (remove) Token: 0x060009FE RID: 2558 RVA: 0x000213E8 File Offset: 0x0001F5E8
		public event Action<string> onPortraitClicked;

		// Token: 0x060009FF RID: 2559 RVA: 0x0002141D File Offset: 0x0001F61D
		protected override void OnBindig()
		{
			Action<CurrentWorkingModelsModel> action = this.onBindig;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x00021430 File Offset: 0x0001F630
		protected override void Binded(IUIPanel to)
		{
			base.Binded(to);
			IUIElemento iuielemento;
			if (to.elementoPorModelo.TryGetValue("Start", out iuielemento))
			{
				iuielemento.transform.gameObject.SetActive(false);
			}
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x00021469 File Offset: 0x0001F669
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

		// Token: 0x06000A02 RID: 2562 RVA: 0x0002148E File Offset: 0x0001F68E
		private string ShowInfo(out float widthMod, int index)
		{
			widthMod = 0.5f;
			return this.infoGetter(index);
		}

		// Token: 0x040003F9 RID: 1017
		[DescripcionDinamica(dinamicoMethodTarget = "ShowInfo")]
		[WorkingModelPortrait]
		public List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> disponibles;

		// Token: 0x040003FC RID: 1020
		public Func<int, string> infoGetter;
	}
}
