using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.UI.EditingModels.Modelos
{
	// Token: 0x0200008C RID: 140
	[Panel(tipo = TipoDePanel.panel1by1, height = 1000, width = 800)]
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[FontProConfigUI(alignment = TextAlignmentOptions.Midline, color = ColorEnum.white)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Serializable]
	public class DesignerEditOutfitTypeModel : BindableModel
	{
		// Token: 0x060002B6 RID: 694 RVA: 0x0000FD0A File Offset: 0x0000DF0A
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060002B7 RID: 695 RVA: 0x0000FD14 File Offset: 0x0000DF14
		// (remove) Token: 0x060002B8 RID: 696 RVA: 0x0000FD4C File Offset: 0x0000DF4C
		public event Action<DesignerEditOutfitTypeModel> goBackClicked;

		// Token: 0x060002B9 RID: 697 RVA: 0x0000FD81 File Offset: 0x0000DF81
		[Label("Go Back", "US")]
		[BotonDePanel]
		public void Done()
		{
			Action<DesignerEditOutfitTypeModel> action = this.goBackClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000FD94 File Offset: 0x0000DF94
		protected override void Bindig()
		{
			base.Bindig();
			this.existentesModel.LoadElements(this.tipo);
			this.puestasModel.LoadElements(this.tipo);
		}

		// Token: 0x04000125 RID: 293
		[Ignore]
		public MapaDeRopa.TipoDePrenda tipo;

		// Token: 0x04000126 RID: 294
		[Ignore]
		[NonSerialized]
		public string title = "OutfitType";

		// Token: 0x04000128 RID: 296
		[Modelo]
		[ParentPanelTarget(index = 0)]
		public DesignerEditOutfitTypeExistentesModel existentesModel = new DesignerEditOutfitTypeExistentesModel();

		// Token: 0x04000129 RID: 297
		[Modelo]
		[ParentPanelTarget(index = 1)]
		public DesignerEditOutfitEditPrendasModel puestasModel = new DesignerEditOutfitEditPrendasModel();
	}
}
