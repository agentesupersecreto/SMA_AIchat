using System;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.AutoRatingProfilesDeGrupos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Elementos.Modales;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing.Elementos
{
	// Token: 0x02000092 RID: 146
	[CreateAssetMenu(fileName = "MapaSingletonDeUIPrefabs", menuName = "Objetos/UI/Mapa Singleton De UI Prefabs")]
	public sealed class MapaSingletonDeUIPrefabs : MapaSingleton<MapaSingletonDeUIPrefabs>
	{
		// Token: 0x060004A4 RID: 1188 RVA: 0x00013258 File Offset: 0x00011458
		protected override void OnJuegoLanzado()
		{
			if (this.panelBackgroundsSelection == null)
			{
				throw new ArgumentNullException("panelBackgroundsSelection", "panelBackgroundsSelection null reference.");
			}
			if (this.panelBackgroundsWindow == null)
			{
				throw new ArgumentNullException("panelBackgroundsWindow", "panelBackgroundsWindow null reference.");
			}
			if (this.separador == null)
			{
				throw new ArgumentNullException("separador", "separador null reference.");
			}
			if (this.espacio == null)
			{
				throw new ArgumentNullException("espacio", "espacio null reference.");
			}
			if (this.botonDePanel == null)
			{
				throw new ArgumentNullException("botonDePanel", "botonDePanel null reference.");
			}
			if (this.botonDePanelConfirmable == null)
			{
				throw new ArgumentNullException("botonDePanelConfirmable", "botonDePanelConfirmable null reference.");
			}
			if (this.pareonPanelButton == null)
			{
				throw new ArgumentNullException("pareonPanelButton", "pareonPanelButton null reference.");
			}
			if (this.discordPanelButton == null)
			{
				throw new ArgumentNullException("discordPanelButton", "discordPanelButton null reference.");
			}
			if (this.labelYDesciption == null)
			{
				throw new ArgumentNullException("labelYDesciption", "labelYDesciption null reference.");
			}
			if (this.desplegable == null)
			{
				throw new ArgumentNullException("desplegable", "desplegable null reference.");
			}
			if (this.desplegableHelpBoton == null)
			{
				throw new ArgumentNullException("desplegableHelpBoton", "desplegableHelpBoton null reference.");
			}
			if (this.desplegableConToolTip == null)
			{
				throw new ArgumentNullException("desplegableConToolTip", "desplegableConToolTip null reference.");
			}
			if (this.desplegableCompacto == null)
			{
				throw new ArgumentNullException("desplegableCompacto", "desplegableCompacto null reference.");
			}
			if (this.desplegableLabelCorto == null)
			{
				throw new ArgumentNullException("desplegableLabelCorto", "desplegableLabelCorto null reference.");
			}
			if (this.deslizable == null)
			{
				throw new ArgumentNullException("deslizable", "deslizable null reference.");
			}
			if (this.deslizableConToolTip == null)
			{
				throw new ArgumentNullException("deslizableConToolTip", "deslizableConToolTip null reference.");
			}
			if (this.deslizableHelpBoton == null)
			{
				throw new ArgumentNullException("deslizableHelpBoton", "deslizableHelpBoton null reference.");
			}
			if (this.deslizableLabelCorto == null)
			{
				throw new ArgumentNullException("deslizableLabelCorto", "deslizableLabelCorto null reference.");
			}
			if (this.inputToolTip == null)
			{
				throw new ArgumentNullException("inputElementToolTip", "inputElementToolTip null reference.");
			}
			if (this.profileIndependiente == null)
			{
				throw new ArgumentNullException("profile", "profile null reference.");
			}
			if (this.titulo == null)
			{
				throw new ArgumentNullException("titulo", "titulo null reference.");
			}
			if (this.label == null)
			{
				throw new ArgumentNullException("label", "label null reference.");
			}
			if (this.labelPar == null)
			{
				throw new ArgumentNullException("labelPar", "labelPar null reference.");
			}
			if (this.labelConrtoLAbelLargoPar == null)
			{
				throw new ArgumentNullException("labelConrtoLAbelLargoPar", "labelConrtoLAbelLargoPar null reference.");
			}
			if (this.infoLabel == null)
			{
				throw new ArgumentNullException("infoLabel", "infoLabel null reference.");
			}
			if (this.levelLabelLargo == null)
			{
				throw new ArgumentNullException("levelLabelLargo", "levelLabelLargo null reference.");
			}
			if (this.Imagen == null)
			{
				throw new ArgumentNullException("Imagen", "Imagen null reference.");
			}
			if (this.clickableLabelDescriptable == null)
			{
				throw new ArgumentNullException("clickableLabelDescriptable", "clickableLabelDescriptable null reference.");
			}
			if (this.clickableLabel == null)
			{
				throw new ArgumentNullException("clickableLabel", "clickableLabel null reference.");
			}
			if (this.clickableLabelConValor == null)
			{
				throw new ArgumentNullException("clickableLabelConValor", "clickableLabelConValor null reference.");
			}
			if (this.clickableFavoritableLabel == null)
			{
				throw new ArgumentNullException("clickableLabelFavoritable", "clickableLabelFavoritable null reference.");
			}
			if (this.clickableLabelDescriptableCompacto == null)
			{
				throw new ArgumentNullException("clickableLabelDescriptableCompacto", "clickableLabelDescriptableCompacto null reference.");
			}
			if (this.toggle == null)
			{
				throw new ArgumentNullException("toggle", "toggle null reference.");
			}
			if (this.colorToggle == null)
			{
				throw new ArgumentNullException("colorToggle", "colorToggle null reference.");
			}
			if (this.controlBoton == null)
			{
				throw new ArgumentNullException("controlBoton", "controlBoton null reference.");
			}
			if (this.controlBotonIconToolTip == null)
			{
				throw new ArgumentNullException("controlBotonIconToolTip", "controlBotonIconToolTip null reference.");
			}
			if (this.gameplayObjective == null)
			{
				throw new ArgumentNullException("gameplayObjective", "gameplayObjective null reference.");
			}
			if (this.analogueCalibration == null)
			{
				throw new ArgumentNullException("analogueCalibration", "analogueCalibration null reference.");
			}
			if (this.hairTroubleshooting == null)
			{
				throw new ArgumentNullException("hairTroubleshooting", "hairTroubleshooting null reference.");
			}
			if (this.scrollablePanel == null)
			{
				throw new ArgumentNullException("scrollablePanel", "scrollablePanel null reference.");
			}
			if (this.objectivesPanel == null)
			{
				throw new ArgumentNullException("objectivesPanel", "objectivesPanel null reference.");
			}
			if (this.scrollablePanelDeItemsConBuscador == null)
			{
				throw new ArgumentNullException("scrollablePanelDeItemsConBuscador", "scrollablePanelDeItemsConBuscador null reference.");
			}
			if (this.scrollablePanelDePortraitsConBuscador == null)
			{
				throw new ArgumentNullException("scrollablePanelDePortraitsConBuscador", "scrollablePanelDePortraitsConBuscador null reference.");
			}
			if (this.nestedContainer == null)
			{
				throw new ArgumentNullException("nestedContainer", "nestedContainer null reference.");
			}
			if (this.nestedContainerConTitulo == null)
			{
				throw new ArgumentNullException("nestedContainerConTitulo", "nestedContainerConTitulo null reference.");
			}
			if (this.panel1by1 == null)
			{
				throw new ArgumentNullException("panel1by1", "panel1by1 null reference.");
			}
			if (this.panel1by3 == null)
			{
				throw new ArgumentNullException("panel1by3", "panel1by3 null reference.");
			}
			if (this.panel1by3Detalles == null)
			{
				throw new ArgumentNullException("panel1by3Detalles", "panel1by3Detalles null reference.");
			}
			if (this.selectablePortrait == null)
			{
				throw new ArgumentNullException("selectablePortrait", "selectablePortrait null reference.");
			}
			if (this.selectablePosePortrait == null)
			{
				throw new ArgumentNullException("selectablePosePortrait", "selectablePosePortrait null reference.");
			}
			if (this.selectableOfficePortrait == null)
			{
				throw new ArgumentNullException("selectableOfficePortrait", "selectableOfficePortrait null reference.");
			}
			if (this.selectableGesturePortrait == null)
			{
				throw new ArgumentNullException("selectableGesturePortrait", "selectableGesturePortrait null reference.");
			}
			if (this.selectableMakeoverPortrait == null)
			{
				throw new ArgumentNullException("selectableMakeoverPortrait", "selectableMakeoverPortrait null reference.");
			}
			if (this.selectableOutfitPortrait == null)
			{
				throw new ArgumentNullException("selectableOutfitPortrait", "selectableOutfitPortrait null reference.");
			}
			if (this.scrollablePortraitPanel == null)
			{
				throw new ArgumentNullException("scrollablePortraitPanel", "scrollablePortraitPanel null reference.");
			}
			if (this.scrollablePosePortraitPanel == null)
			{
				throw new ArgumentNullException("scrollablePosePortraitPanel", "scrollablePosePortraitPanel null reference.");
			}
			if (this.scrollableGesturePortraitPanel == null)
			{
				throw new ArgumentNullException("scrollableGesturePortraitPanel", "scrollableGesturePortraitPanel null reference.");
			}
			if (this.scrollableMakeoverPortraitPanel == null)
			{
				throw new ArgumentNullException("scrollableMakeoverPortraitPanel", "scrollableMakeoverPortraitPanel null reference.");
			}
			if (this.scrollableOutfitPortraitPanel == null)
			{
				throw new ArgumentNullException("scrollableOutfitPortraitPanel", "scrollableOutfitPortraitPanel null reference.");
			}
			if (this.scrollableProfilePortraitPanel == null)
			{
				throw new ArgumentNullException("scrollableProfilePortraitPanel", "scrollableProfilePortraitPanel null reference.");
			}
			if (this.scrollableWorkingModelsPortraitsPanel == null)
			{
				throw new ArgumentNullException("scrollableWorkingModelsPortraitsPanel", "scrollableWorkingModelsPortraitsPanel null reference.");
			}
			if (this.scrollableJobPortraitPanel == null)
			{
				throw new ArgumentNullException("scrollableJobPortraitPanel", "scrollableJobPortraitPanel null reference.");
			}
			if (this.scrollableOfficePortraitPanel == null)
			{
				throw new ArgumentNullException("scrollableOfficePortraitPanel", "scrollableOfficePortraitPanel null reference.");
			}
			if (this.colorContainer == null)
			{
				throw new ArgumentNullException("colorContainer", "colorContainer null reference.");
			}
			if (this.autoRatingProfilesEditor == null)
			{
				throw new ArgumentNullException("autoRatingProfilesEditor", "autoRatingProfilesEditor null reference.");
			}
			if (this.selectableProfilePortrait == null)
			{
				throw new ArgumentNullException("selectableProfilePortrait", "selectableProfilePortrait null reference.");
			}
			if (this.selectableJobPortrait == null)
			{
				throw new ArgumentNullException("selectableJobPortrait", "selectableJobPortrait null reference.");
			}
			if (this.selectableFavoritableGenericPortrait == null)
			{
				throw new ArgumentNullException("selectableFavoritableGenericPortrait", "selectableFavoritableGenericPortrait null reference.");
			}
			if (this.selectableWorkingModelPortrait == null)
			{
				throw new ArgumentNullException("selectableWorkingModelPortrait", "selectableWorkingModelPortrait null reference.");
			}
			if (this.autoRatingProfilesDeGruposPanel == null)
			{
				throw new ArgumentNullException("autoRatingProfilesDeGruposPanel", "autoRatingProfilesDeGruposPanel null reference.");
			}
			if (this.thanksPanel == null)
			{
				throw new ArgumentNullException("thanksPanel", "thanksPanel null reference.");
			}
		}

		// Token: 0x04000187 RID: 391
		[Header("Controles")]
		public GameObject separador;

		// Token: 0x04000188 RID: 392
		public GameObject espacio;

		// Token: 0x04000189 RID: 393
		public BotonElement botonDePanel;

		// Token: 0x0400018A RID: 394
		public BotonElementConfirmable botonDePanelConfirmable;

		// Token: 0x0400018B RID: 395
		public TituloElement titulo;

		// Token: 0x0400018C RID: 396
		public SimpleLabelElement label;

		// Token: 0x0400018D RID: 397
		public LabelParElement labelPar;

		// Token: 0x0400018E RID: 398
		public LabelParElement labelConrtoLAbelLargoPar;

		// Token: 0x0400018F RID: 399
		public LabelParElement infoLabel;

		// Token: 0x04000190 RID: 400
		public LevelElementToolTip levelLabelLargo;

		// Token: 0x04000191 RID: 401
		public ImagenFieldElement Imagen;

		// Token: 0x04000192 RID: 402
		public DeslizableElement deslizable;

		// Token: 0x04000193 RID: 403
		public DeslizableElementToolTip deslizableConToolTip;

		// Token: 0x04000194 RID: 404
		public DeslizableElementHelpButton deslizableHelpBoton;

		// Token: 0x04000195 RID: 405
		public DeslizableElementToolTip deslizableLabelCorto;

		// Token: 0x04000196 RID: 406
		public InputElementToolTip inputToolTip;

		// Token: 0x04000197 RID: 407
		public DesplegableElement desplegable;

		// Token: 0x04000198 RID: 408
		public DesplegableElementHelpButton desplegableHelpBoton;

		// Token: 0x04000199 RID: 409
		public DesplegableElementToolTip desplegableConToolTip;

		// Token: 0x0400019A RID: 410
		public DesplegableElementToolTip desplegableCompacto;

		// Token: 0x0400019B RID: 411
		public DesplegableElementToolTip desplegableLabelCorto;

		// Token: 0x0400019C RID: 412
		public BotonElementBase clickableLabelDescriptable;

		// Token: 0x0400019D RID: 413
		public BotonElementBase clickableLabel;

		// Token: 0x0400019E RID: 414
		public BotonElementBase clickableLabelConValor;

		// Token: 0x0400019F RID: 415
		public BotonElementBase clickableFavoritableLabel;

		// Token: 0x040001A0 RID: 416
		public BotonElementBase clickableLabelDescriptableCompacto;

		// Token: 0x040001A1 RID: 417
		public UIElemento toggle;

		// Token: 0x040001A2 RID: 418
		public UIElemento colorToggle;

		// Token: 0x040001A3 RID: 419
		public UIElemento analogueCalibration;

		// Token: 0x040001A4 RID: 420
		public UIElemento pareonPanelButton;

		// Token: 0x040001A5 RID: 421
		public UIElemento discordPanelButton;

		// Token: 0x040001A6 RID: 422
		public UIElemento labelYDesciption;

		// Token: 0x040001A7 RID: 423
		public UIElemento hairTroubleshooting;

		// Token: 0x040001A8 RID: 424
		public SelectablePortrait selectablePortrait;

		// Token: 0x040001A9 RID: 425
		public SelectablePosePortrait selectablePosePortrait;

		// Token: 0x040001AA RID: 426
		public SelectableOfficePortrait selectableOfficePortrait;

		// Token: 0x040001AB RID: 427
		public SelectableGesturePortrait selectableGesturePortrait;

		// Token: 0x040001AC RID: 428
		public SelectableMakeoverPortrait selectableMakeoverPortrait;

		// Token: 0x040001AD RID: 429
		public SelectableOutfitPortrait selectableOutfitPortrait;

		// Token: 0x040001AE RID: 430
		public SelectableProfilePortrait selectableProfilePortrait;

		// Token: 0x040001AF RID: 431
		public SelectableWorkingModelPortrait selectableWorkingModelPortrait;

		// Token: 0x040001B0 RID: 432
		public SelectableFavoritableGenericPortrait selectableFavoritableGenericPortrait;

		// Token: 0x040001B1 RID: 433
		public SelectableJobPortrait selectableJobPortrait;

		// Token: 0x040001B2 RID: 434
		public GrupoProfileIndependiente profileIndependiente;

		// Token: 0x040001B3 RID: 435
		public GamePlayObjectiveUIElemento gameplayObjective;

		// Token: 0x040001B4 RID: 436
		[Header("Panel Controles")]
		public BotonElement controlBoton;

		// Token: 0x040001B5 RID: 437
		public BotonIconElementConToolTip controlBotonIconToolTip;

		// Token: 0x040001B6 RID: 438
		[Header("Paneles")]
		public ScrollablePanel scrollablePanel;

		// Token: 0x040001B7 RID: 439
		public ScrollablePanelConBuscadorYFavoritos scrollablePanelDeItemsConBuscador;

		// Token: 0x040001B8 RID: 440
		public ScrollablePanelConBuscadorYFavoritos scrollablePanelDePortraitsConBuscador;

		// Token: 0x040001B9 RID: 441
		public NestedContainer nestedContainer;

		// Token: 0x040001BA RID: 442
		public NestedContainerConTitulo nestedContainerConTitulo;

		// Token: 0x040001BB RID: 443
		public Panel1by1 panel1by1;

		// Token: 0x040001BC RID: 444
		public Panel1by3 panel1by3;

		// Token: 0x040001BD RID: 445
		public Panel1by3 panel1by3Detalles;

		// Token: 0x040001BE RID: 446
		public ScrollablePortraitPanel scrollablePortraitPanel;

		// Token: 0x040001BF RID: 447
		public ScrollablePosePortraitPanel scrollablePosePortraitPanel;

		// Token: 0x040001C0 RID: 448
		public ScrollableGesturePortraitPanel scrollableGesturePortraitPanel;

		// Token: 0x040001C1 RID: 449
		public ScrollableMakeoverPortraitPanel scrollableMakeoverPortraitPanel;

		// Token: 0x040001C2 RID: 450
		public ScrollableOutfitsPortraitPanel scrollableOutfitPortraitPanel;

		// Token: 0x040001C3 RID: 451
		public ScrollableProfilePortraitPanel scrollableProfilePortraitPanel;

		// Token: 0x040001C4 RID: 452
		public ScrollableCurrentWorkingModelsPortraitPanel scrollableWorkingModelsPortraitsPanel;

		// Token: 0x040001C5 RID: 453
		public ScrollableJobPortraitPanel scrollableJobPortraitPanel;

		// Token: 0x040001C6 RID: 454
		public ScrollableOfficePortraitPanel scrollableOfficePortraitPanel;

		// Token: 0x040001C7 RID: 455
		public ScrollablePanel objectivesPanel;

		// Token: 0x040001C8 RID: 456
		public PrimaryColorToggles colorContainer;

		// Token: 0x040001C9 RID: 457
		public AutoRatingProfilesEditor autoRatingProfilesEditor;

		// Token: 0x040001CA RID: 458
		public AutoRatingProfilesDeGruposPanel autoRatingProfilesDeGruposPanel;

		// Token: 0x040001CB RID: 459
		public ScrollablePanel thanksPanel;

		// Token: 0x040001CC RID: 460
		[Header("Panel Backgrounds")]
		public Sprite panelBackgroundsSelection;

		// Token: 0x040001CD RID: 461
		public Sprite panelBackgroundsWindow;
	}
}
