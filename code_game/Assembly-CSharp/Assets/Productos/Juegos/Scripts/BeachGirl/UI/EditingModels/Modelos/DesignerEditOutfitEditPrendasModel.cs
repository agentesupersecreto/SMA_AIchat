using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;
using UnityEngine;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.UI.EditingModels.Modelos
{
	// Token: 0x0200008E RID: 142
	[Modelo]
	[FontProConfigUI(alignment = TextAlignmentOptions.Midline)]
	[Panel(tipo = TipoDePanel.nestedContainerConTitulo, width = 450)]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[Serializable]
	public class DesignerEditOutfitEditPrendasModel
	{
		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060002C2 RID: 706 RVA: 0x0000FF54 File Offset: 0x0000E154
		// (remove) Token: 0x060002C3 RID: 707 RVA: 0x0000FF8C File Offset: 0x0000E18C
		public event Action<DesignerEditOutfitEditPrendaModel, DesignerEditOutfitEditPrendasModel> takeOffClicked;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060002C4 RID: 708 RVA: 0x0000FFC4 File Offset: 0x0000E1C4
		// (remove) Token: 0x060002C5 RID: 709 RVA: 0x0000FFFC File Offset: 0x0000E1FC
		public event Action<MaterialParaRopaData, DesignerEditOutfitEditMaterialModel, DesignerEditOutfitEditPrendaModel, DesignerEditOutfitEditPrendasModel> materialChanged;

		// Token: 0x060002C6 RID: 710 RVA: 0x00010031 File Offset: 0x0000E231
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0001003C File Offset: 0x0000E23C
		public void LoadElements(MapaDeRopa.TipoDePrenda tipo)
		{
			IRopaManager ropa = this.GetManager();
			if (ropa == null)
			{
				return;
			}
			this.currentPrendasPuestasDeTipo = ropa.piezasPuestas.Where((PiezaDeRopaBase r) => r.dataDeRopa.tipoDePrenda == tipo).ToList<PiezaDeRopaBase>();
			this.currentPrendasPuestasDeTipo.ForEach(delegate(PiezaDeRopaBase r)
			{
				ropa.OcultarPieza(r.dataDeRopa.stringId, false, null);
			});
			this.currentPrendasPuestasDeTipoModels = this.currentPrendasPuestasDeTipo.Select((PiezaDeRopaBase p) => new DesignerEditOutfitEditPrendaModel
			{
				title = p.dataDeRopa.nombreCompleto,
				prenda = p
			}).ToList<DesignerEditOutfitEditPrendaModel>();
			this.currentPrendasPuestasDeTipoModels.ForEach(delegate(DesignerEditOutfitEditPrendaModel m)
			{
				m.takeOffClicked += this.M_takeOffClicked;
			});
			this.currentPrendasPuestasDeTipoModels.ForEach(delegate(DesignerEditOutfitEditPrendaModel m)
			{
				m.materialChanged += this.M_materialChanged;
			});
			this.currentPrendasPuestasDeTipoModels.ForEach(delegate(DesignerEditOutfitEditPrendaModel m)
			{
				m.LoadMaterials();
			});
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0001013D File Offset: 0x0000E33D
		private void M_materialChanged(MaterialParaRopaData arg1, DesignerEditOutfitEditMaterialModel arg2, DesignerEditOutfitEditPrendaModel arg3)
		{
			Action<MaterialParaRopaData, DesignerEditOutfitEditMaterialModel, DesignerEditOutfitEditPrendaModel, DesignerEditOutfitEditPrendasModel> action = this.materialChanged;
			if (action == null)
			{
				return;
			}
			action(arg1, arg2, arg3, this);
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00010154 File Offset: 0x0000E354
		private void M_takeOffClicked(DesignerEditOutfitEditPrendaModel obj)
		{
			IRopaManager manager = this.GetManager();
			if (manager == null)
			{
				return;
			}
			manager.RemovePieza(obj.prenda.dataDeRopa.stringId, true, null);
			Action<DesignerEditOutfitEditPrendaModel, DesignerEditOutfitEditPrendasModel> action = this.takeOffClicked;
			if (action == null)
			{
				return;
			}
			action(obj, this);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00010198 File Offset: 0x0000E398
		private IRopaManager GetManager()
		{
			TargetChar current = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current;
			if (current == null)
			{
				Debug.LogError("No se pudo obtener el personaje target");
				return null;
			}
			Character character = current.character;
			IRopaManager ropaManager = ((character != null) ? character.GetComponentInChildren<IRopaManager>() : null);
			if (ropaManager == null)
			{
				string text = "No se pudo obtener RopaManager de personaje ";
				Character character2 = current.character;
				Debug.LogError(text + ((character2 != null) ? character2.nombreCompleto : null), current);
				return null;
			}
			return ropaManager;
		}

		// Token: 0x0400012F RID: 303
		[Ignore]
		[NonSerialized]
		public string title = "Wearing";

		// Token: 0x04000130 RID: 304
		[Ignore]
		public List<PiezaDeRopaBase> currentPrendasPuestasDeTipo;

		// Token: 0x04000131 RID: 305
		[Modelo]
		public List<DesignerEditOutfitEditPrendaModel> currentPrendasPuestasDeTipoModels;
	}
}
