using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Modelos
{
	// Token: 0x02000111 RID: 273
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft, color = ColorEnum.black, fontSize = 18)]
	[Panel(tipo = TipoDePanel.panel1by3Detalles)]
	[Cerrable(accion = CerrableAttribute.Accion.destruir)]
	[Serializable]
	public class InformacionDetalladaDeItemsModelo : BindableModel
	{
		// Token: 0x06000816 RID: 2070 RVA: 0x0001C24D File Offset: 0x0001A44D
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x0400032B RID: 811
		[Ignore]
		public string title = "No se especifico el titulo del panel";

		// Token: 0x0400032C RID: 812
		[Modelo]
		[ParentPanelTarget(index = 0)]
		public ItemsListaModelo agenciasListaModelo = new ItemsListaModelo();

		// Token: 0x0400032D RID: 813
		[Modelo]
		[ParentPanelTarget(index = 1)]
		public DetallesDeItemModelo detalles = new DetallesDeItemModelo();
	}
}
