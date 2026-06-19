using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.UI.EditingModels.Modelos
{
	// Token: 0x0200008B RID: 139
	[Panel(height = 800)]
	[Modelo]
	[Label("Select a category", "US", fontStyle = FontStyles.Normal, alignment = TextAlignmentOptions.TopLeft)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Serializable]
	public class DesignerEditOutfitModel
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060002A3 RID: 675 RVA: 0x0000FB08 File Offset: 0x0000DD08
		// (remove) Token: 0x060002A4 RID: 676 RVA: 0x0000FB40 File Offset: 0x0000DD40
		public event Action<DesignerEditOutfitModel, MapaDeRopa.TipoDePrenda> editTipoClicked;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060002A5 RID: 677 RVA: 0x0000FB78 File Offset: 0x0000DD78
		// (remove) Token: 0x060002A6 RID: 678 RVA: 0x0000FBB0 File Offset: 0x0000DDB0
		public event Action<DesignerEditOutfitModel> onDoneClicked;

		// Token: 0x060002A7 RID: 679 RVA: 0x0000FBE5 File Offset: 0x0000DDE5
		[Label("Hats", "US")]
		[ClickableLabel(confirmar = false)]
		public void HatGlases()
		{
			Action<DesignerEditOutfitModel, MapaDeRopa.TipoDePrenda> action = this.editTipoClicked;
			if (action == null)
			{
				return;
			}
			action(this, MapaDeRopa.TipoDePrenda.hat);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000FBFA File Offset: 0x0000DDFA
		[Label("Glasses", "US")]
		[ClickableLabel(confirmar = false)]
		public void EditGlases()
		{
			Action<DesignerEditOutfitModel, MapaDeRopa.TipoDePrenda> action = this.editTipoClicked;
			if (action == null)
			{
				return;
			}
			action(this, MapaDeRopa.TipoDePrenda.glases);
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000FC0F File Offset: 0x0000DE0F
		[Label("Tops", "US")]
		[ClickableLabel(confirmar = false)]
		public void EditUpperBody()
		{
			Action<DesignerEditOutfitModel, MapaDeRopa.TipoDePrenda> action = this.editTipoClicked;
			if (action == null)
			{
				return;
			}
			action(this, MapaDeRopa.TipoDePrenda.superior);
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000FC23 File Offset: 0x0000DE23
		[Label("Bras", "US")]
		[ClickableLabel(confirmar = false)]
		public void EditUpperBodyUnderwear()
		{
			Action<DesignerEditOutfitModel, MapaDeRopa.TipoDePrenda> action = this.editTipoClicked;
			if (action == null)
			{
				return;
			}
			action(this, MapaDeRopa.TipoDePrenda.underwearSuperior);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000FC37 File Offset: 0x0000DE37
		[Label("Bottoms", "US")]
		[ClickableLabel(confirmar = false)]
		public void EditLowerBody()
		{
			Action<DesignerEditOutfitModel, MapaDeRopa.TipoDePrenda> action = this.editTipoClicked;
			if (action == null)
			{
				return;
			}
			action(this, MapaDeRopa.TipoDePrenda.inferior);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000FC4B File Offset: 0x0000DE4B
		[Label("Panties", "US")]
		[ClickableLabel(confirmar = false)]
		public void EditLowerBodyUnderwear()
		{
			Action<DesignerEditOutfitModel, MapaDeRopa.TipoDePrenda> action = this.editTipoClicked;
			if (action == null)
			{
				return;
			}
			action(this, MapaDeRopa.TipoDePrenda.underwearInferior);
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000FC5F File Offset: 0x0000DE5F
		[Label("Gloves", "US")]
		[ClickableLabel(confirmar = false)]
		public void EditGloves()
		{
			Action<DesignerEditOutfitModel, MapaDeRopa.TipoDePrenda> action = this.editTipoClicked;
			if (action == null)
			{
				return;
			}
			action(this, MapaDeRopa.TipoDePrenda.gloves);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000FC74 File Offset: 0x0000DE74
		[Label("Socks", "US")]
		[ClickableLabel(confirmar = false)]
		public void EditSocks()
		{
			Action<DesignerEditOutfitModel, MapaDeRopa.TipoDePrenda> action = this.editTipoClicked;
			if (action == null)
			{
				return;
			}
			action(this, MapaDeRopa.TipoDePrenda.socks);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000FC88 File Offset: 0x0000DE88
		[Label("Shoes", "US")]
		[ClickableLabel(confirmar = false)]
		public void EditShoes()
		{
			Action<DesignerEditOutfitModel, MapaDeRopa.TipoDePrenda> action = this.editTipoClicked;
			if (action == null)
			{
				return;
			}
			action(this, MapaDeRopa.TipoDePrenda.shoes);
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000FC9C File Offset: 0x0000DE9C
		[Label("Suits", "US")]
		[ClickableLabel(confirmar = false)]
		public void EditSuits()
		{
			Action<DesignerEditOutfitModel, MapaDeRopa.TipoDePrenda> action = this.editTipoClicked;
			if (action == null)
			{
				return;
			}
			action(this, MapaDeRopa.TipoDePrenda.swimsuit);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000FCB0 File Offset: 0x0000DEB0
		[Label("Accessories", "US")]
		[ClickableLabel(confirmar = false)]
		public void EditAccessories()
		{
			Action<DesignerEditOutfitModel, MapaDeRopa.TipoDePrenda> action = this.editTipoClicked;
			if (action == null)
			{
				return;
			}
			action(this, MapaDeRopa.TipoDePrenda.accessories);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000FCC5 File Offset: 0x0000DEC5
		[Label("Top Accessories", "US")]
		[ClickableLabel(confirmar = false)]
		public void EditSuperiorAccessories()
		{
			Action<DesignerEditOutfitModel, MapaDeRopa.TipoDePrenda> action = this.editTipoClicked;
			if (action == null)
			{
				return;
			}
			action(this, MapaDeRopa.TipoDePrenda.underwearSuperiorAccessories);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000FCDA File Offset: 0x0000DEDA
		[Label("Bottom Accessories", "US")]
		[ClickableLabel(confirmar = false)]
		public void EditInferiorAccessories()
		{
			Action<DesignerEditOutfitModel, MapaDeRopa.TipoDePrenda> action = this.editTipoClicked;
			if (action == null)
			{
				return;
			}
			action(this, MapaDeRopa.TipoDePrenda.underwearInferiorAccessories);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000FCEF File Offset: 0x0000DEEF
		[Label("Done", "US")]
		[BotonDePanel]
		public void Done()
		{
			Action<DesignerEditOutfitModel> action = this.onDoneClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}
	}
}
