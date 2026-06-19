using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Modelos
{
	// Token: 0x02000114 RID: 276
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[FontProConfigUI(alignment = TextAlignmentOptions.Midline, color = ColorEnum.white, fontSize = 25, fontStyle = FontStyles.Bold | FontStyles.UpperCase)]
	[Panel(tipo = TipoDePanel.panel1by3Detalles, panelLayoutDynamicMethodTarget = "GetLayout")]
	[Cerrable(accion = CerrableAttribute.Accion.destruir)]
	[Serializable]
	public class TabsWithCustomInfoModelo : BindableModel
	{
		// Token: 0x0600082D RID: 2093 RVA: 0x0001C632 File Offset: 0x0001A832
		public IPanelLayoutAttribute GetLayout()
		{
			return this.layout;
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x0001C63A File Offset: 0x0001A83A
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x04000338 RID: 824
		[Ignore]
		public IPanelLayoutAttribute layout;

		// Token: 0x04000339 RID: 825
		[Ignore]
		public string title = "No se especifico el titulo del panel";

		// Token: 0x0400033A RID: 826
		[Modelo]
		[ParentPanelTarget(index = 0)]
		public TabsListaModelo tabsList = new TabsListaModelo();

		// Token: 0x0400033B RID: 827
		[Modelo]
		[ParentPanelTarget(index = 1)]
		[SerializeReference]
		public object informacionGeneral;
	}
}
