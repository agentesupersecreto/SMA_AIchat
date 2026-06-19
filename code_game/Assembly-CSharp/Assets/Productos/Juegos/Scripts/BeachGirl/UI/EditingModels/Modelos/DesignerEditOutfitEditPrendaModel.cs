using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Plugins.Runtime.UI;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;
using UnityEngine;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.UI.EditingModels.Modelos
{
	// Token: 0x0200008F RID: 143
	[Modelo]
	[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
	[HeightDinamico(dinamicoMethodTarget = "GetHeight")]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[Panel(tipo = TipoDePanel.nestedContainerConTitulo)]
	[IconPanelControl(listiner = "Remover", toolTip = "Take this off")]
	[Serializable]
	public class DesignerEditOutfitEditPrendaModel
	{
		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060002CC RID: 716 RVA: 0x00010210 File Offset: 0x0000E410
		// (remove) Token: 0x060002CD RID: 717 RVA: 0x00010248 File Offset: 0x0000E448
		public event Action<DesignerEditOutfitEditPrendaModel> takeOffClicked;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060002CE RID: 718 RVA: 0x00010280 File Offset: 0x0000E480
		// (remove) Token: 0x060002CF RID: 719 RVA: 0x000102B8 File Offset: 0x0000E4B8
		public event Action<MaterialParaRopaData, DesignerEditOutfitEditMaterialModel, DesignerEditOutfitEditPrendaModel> materialChanged;

		// Token: 0x060002D0 RID: 720 RVA: 0x000102ED File Offset: 0x0000E4ED
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x000102F5 File Offset: 0x0000E4F5
		public int GetHeight()
		{
			return 50 + this.materialesModels.Count * 170 + 20;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00010310 File Offset: 0x0000E510
		public void LoadMaterials()
		{
			this.materialesModels.Clear();
			if (this.prenda == null)
			{
				Debug.LogException(new ArgumentNullException("prenda", "prenda null reference."));
				return;
			}
			MaterialesParaRopa instance = AsyncSingleton<MaterialesParaRopa>.instance;
			List<List<MaterialParaRopaData>> list = new List<List<MaterialParaRopaData>>();
			instance.LoadPosiblesMaterialesDePrenda(this.prenda.dataDeRopa.stringId, list, null);
			Material[] sharedMaterials = this.prenda.skinnedMeshRenderer.sharedMaterials;
			for (int i = 0; i < list.Count; i++)
			{
				List<MaterialParaRopaData> list2 = list[i];
				string[] array = list2.Select((MaterialParaRopaData p) => p.nombreCompleto).ToArray<string>();
				MaterialParaRopaData materialParaRopaData = null;
				if (this.prenda.materialesData.ContieneIndexReadOnly(i))
				{
					SlotDeMaterialDeRopa slotMat = this.prenda.materialesData[i];
					materialParaRopaData = list2.FirstOrDefault((MaterialParaRopaData d) => d.stringId == slotMat.materialIDString);
				}
				Color color = Color.white;
				if (sharedMaterials.ContieneIndexReadOnly(i))
				{
					color = sharedMaterials[i].GetColor(PiezasDeRopaLoader._BaseColorID);
				}
				DesignerEditOutfitEditMaterialModel designerEditOutfitEditMaterialModel = new DesignerEditOutfitEditMaterialModel
				{
					materialIndex = i,
					materialsData = list2,
					materialesPosiblesDisplay = array,
					material = ((materialParaRopaData != null) ? materialParaRopaData.nombreCompleto : "Not Found"),
					color = color
				};
				designerEditOutfitEditMaterialModel.materialChanged += this.MatModel_materialChanged;
				designerEditOutfitEditMaterialModel.colorChanged += this.MatModel_colorChanged;
				this.materialesModels.Add(designerEditOutfitEditMaterialModel);
			}
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x000104A2 File Offset: 0x0000E6A2
		private void MatModel_colorChanged(Color arg1, DesignerEditOutfitEditMaterialModel arg2)
		{
			if (this.prenda == null)
			{
				Debug.LogException(new ArgumentNullException("prenda", "prenda null reference."));
				return;
			}
			this.prenda.ChangeMainColor(arg2.materialIndex, arg1);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x000104D9 File Offset: 0x0000E6D9
		private void MatModel_materialChanged(MaterialParaRopaData arg1, DesignerEditOutfitEditMaterialModel arg2)
		{
			Action<MaterialParaRopaData, DesignerEditOutfitEditMaterialModel, DesignerEditOutfitEditPrendaModel> action = this.materialChanged;
			if (action == null)
			{
				return;
			}
			action(arg1, arg2, this);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x000104EE File Offset: 0x0000E6EE
		public void Remover()
		{
			Action<DesignerEditOutfitEditPrendaModel> action = this.takeOffClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x04000134 RID: 308
		[Ignore]
		[NonSerialized]
		public string title = "Item Name";

		// Token: 0x04000135 RID: 309
		[Ignore]
		public PiezaDeRopaBase prenda;

		// Token: 0x04000136 RID: 310
		[Modelo]
		public List<DesignerEditOutfitEditMaterialModel> materialesModels = new List<DesignerEditOutfitEditMaterialModel>();

		// Token: 0x04000137 RID: 311
		private static List<Material> m_tempMaterials = new List<Material>();
	}
}
