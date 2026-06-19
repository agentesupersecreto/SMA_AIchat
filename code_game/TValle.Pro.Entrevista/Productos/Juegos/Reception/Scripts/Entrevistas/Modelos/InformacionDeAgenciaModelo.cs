using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x02000007 RID: 7
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[FontProConfigUI(alignment = TextAlignmentOptions.Midline, color = ColorEnum.white)]
	[Panel(tipo = TipoDePanel.panel1by1)]
	[Cerrable(accion = CerrableAttribute.Accion.destruir)]
	[Serializable]
	public class InformacionDeAgenciaModelo : BindableModel
	{
		// Token: 0x0600005D RID: 93 RVA: 0x00003E5F File Offset: 0x0000205F
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x04000040 RID: 64
		[Ignore]
		[NonSerialized]
		public string title = "Agency Information";

		// Token: 0x04000041 RID: 65
		[Modelo]
		[ParentPanelTarget(index = 0)]
		public EmailsModel emails = new EmailsModel();

		// Token: 0x04000042 RID: 66
		[Modelo]
		[ParentPanelTarget(index = 1)]
		public AcountModel acount = new AcountModel();
	}
}
