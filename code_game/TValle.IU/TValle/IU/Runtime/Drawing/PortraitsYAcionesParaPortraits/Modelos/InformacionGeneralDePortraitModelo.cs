using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.PortraitsYAcionesParaPortraits.Modelos
{
	// Token: 0x020000F0 RID: 240
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[FontProConfigUI(alignment = TextAlignmentOptions.Midline, color = ColorEnum.white, fontSize = 25, fontStyle = FontStyles.Bold | FontStyles.UpperCase)]
	[Panel(tipo = TipoDePanel.panel1by3Detalles)]
	[Cerrable(accion = CerrableAttribute.Accion.destruir)]
	[Serializable]
	public class InformacionGeneralDePortraitModelo : BindableModel
	{
		// Token: 0x0600074B RID: 1867 RVA: 0x0001A687 File Offset: 0x00018887
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x040002E3 RID: 739
		[Ignore]
		public string title = "No se especifico el titulo del panel";

		// Token: 0x040002E4 RID: 740
		[Modelo]
		[ParentPanelTarget(index = 0)]
		public PortraitsListaModelo portraitsLista = new PortraitsListaModelo();

		// Token: 0x040002E5 RID: 741
		[Modelo]
		[ParentPanelTarget(index = 1)]
		[SerializeReference]
		public object informacionGeneral;
	}
}
