using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Elementos.AutoRatingProfilesDeGrupos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using TMPro;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos
{
	// Token: 0x02000103 RID: 259
	[Modelo]
	[Label("Auto Rating Profiles", alignment = TextAlignmentOptions.MidlineLeft, color = ColorEnum.black, fontStyle = FontStyles.Bold)]
	[Panel(tipo = TipoDePanel.autoRatingProfilesDeGrupos)]
	[Cerrable(accion = CerrableAttribute.Accion.destruir)]
	[HelpPanelControl(listiner = "ShowGuide")]
	[Serializable]
	public class PortraitsDeGruposModel : BindableModel
	{
		// Token: 0x1400002B RID: 43
		// (add) Token: 0x060007AF RID: 1967 RVA: 0x0001B32C File Offset: 0x0001952C
		// (remove) Token: 0x060007B0 RID: 1968 RVA: 0x0001B364 File Offset: 0x00019564
		public event PortraitsDeGruposModel.GrupoChangedHandler onCambiar;

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x060007B1 RID: 1969 RVA: 0x0001B39C File Offset: 0x0001959C
		// (remove) Token: 0x060007B2 RID: 1970 RVA: 0x0001B3D4 File Offset: 0x000195D4
		public event PortraitsDeGruposModel.GrupoChangedHandler onEditar;

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x060007B3 RID: 1971 RVA: 0x0001B40C File Offset: 0x0001960C
		// (remove) Token: 0x060007B4 RID: 1972 RVA: 0x0001B444 File Offset: 0x00019644
		public event PortraitsDeGruposModel.GrupoChangedHandler onRemover;

		// Token: 0x060007B5 RID: 1973 RVA: 0x0001B47C File Offset: 0x0001967C
		protected IList<IUIElemento> ProductorDeGruposUI(IUIPanel panel)
		{
			AutoRatingProfilesDeGruposPanel autoRatingProfilesDeGruposPanel = (AutoRatingProfilesDeGruposPanel)panel;
			return new List<IUIElemento> { autoRatingProfilesDeGruposPanel.grupoA, autoRatingProfilesDeGruposPanel.grupoB, autoRatingProfilesDeGruposPanel.grupoC, autoRatingProfilesDeGruposPanel.grupoD, autoRatingProfilesDeGruposPanel.grupoF, autoRatingProfilesDeGruposPanel.grupoE, autoRatingProfilesDeGruposPanel.grupoG, autoRatingProfilesDeGruposPanel.grupoH, autoRatingProfilesDeGruposPanel.grupoI, autoRatingProfilesDeGruposPanel.grupoJ };
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x0001B510 File Offset: 0x00019710
		protected override void Binded(IUIPanel to)
		{
			base.Binded(to);
			AutoRatingProfilesDeGruposPanel autoRatingProfilesDeGruposPanel = (AutoRatingProfilesDeGruposPanel)to;
			autoRatingProfilesDeGruposPanel.onCambiar += this.P_onCambiar;
			autoRatingProfilesDeGruposPanel.onEditar += this.P_onEditar;
			autoRatingProfilesDeGruposPanel.onRemover += this.P_onRemover;
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x0001B560 File Offset: 0x00019760
		protected override void Clearing()
		{
			base.Clearing();
			AutoRatingProfilesDeGruposPanel autoRatingProfilesDeGruposPanel = (AutoRatingProfilesDeGruposPanel)base.panel;
			if (autoRatingProfilesDeGruposPanel != null)
			{
				autoRatingProfilesDeGruposPanel.onCambiar -= this.P_onCambiar;
				autoRatingProfilesDeGruposPanel.onEditar -= this.P_onEditar;
				autoRatingProfilesDeGruposPanel.onRemover -= this.P_onRemover;
			}
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x0001B5BE File Offset: 0x000197BE
		[Ignore]
		private void P_onRemover(int grupoIndex, object grupo, object sender)
		{
			PortraitsDeGruposModel.GrupoChangedHandler grupoChangedHandler = this.onRemover;
			if (grupoChangedHandler == null)
			{
				return;
			}
			grupoChangedHandler(grupoIndex, grupo, sender, this);
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x0001B5D4 File Offset: 0x000197D4
		[Ignore]
		private void P_onEditar(int grupoIndex, object grupo, object sender)
		{
			PortraitsDeGruposModel.GrupoChangedHandler grupoChangedHandler = this.onEditar;
			if (grupoChangedHandler == null)
			{
				return;
			}
			grupoChangedHandler(grupoIndex, grupo, sender, this);
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x0001B5EA File Offset: 0x000197EA
		[Ignore]
		private void P_onCambiar(int grupoIndex, object grupo, object sender)
		{
			PortraitsDeGruposModel.GrupoChangedHandler grupoChangedHandler = this.onCambiar;
			if (grupoChangedHandler == null)
			{
				return;
			}
			grupoChangedHandler(grupoIndex, grupo, sender, this);
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x0001B600 File Offset: 0x00019800
		public void ShowGuide()
		{
			InfoDialog modalPanel = Singleton<ModalWindow>.instance.MostrarBigInfoDialog();
			modalPanel.pregunta.text = "Assign your profiles to groups. There are a total of ten groups available, which will be unlocked as you progress through the game. These profiles are used to rate the models automatically.";
			modalPanel.aceptar.onClick.AddListener(delegate
			{
				if (Singleton<ModalWindow>.IsInScene)
				{
					Singleton<ModalWindow>.instance.Clear(modalPanel);
				}
			});
		}

		// Token: 0x04000307 RID: 775
		[SelfDrawing(metodo = "ProductorDeGruposUI")]
		public List<MultipleValorElemento<string, bool>> grupos = new List<MultipleValorElemento<string, bool>>(10);

		// Token: 0x020001C4 RID: 452
		// (Invoke) Token: 0x06000C27 RID: 3111
		public delegate void GrupoChangedHandler(int grupoIndex, object grupo, object panel, PortraitsDeGruposModel sender);
	}
}
