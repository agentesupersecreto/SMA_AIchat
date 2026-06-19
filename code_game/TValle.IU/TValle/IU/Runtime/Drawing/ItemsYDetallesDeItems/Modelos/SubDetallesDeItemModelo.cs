using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;

namespace Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Modelos
{
	// Token: 0x0200010F RID: 271
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[Panel(tipo = TipoDePanel.panel1by1)]
	[Serializable]
	public class SubDetallesDeItemModelo
	{
		// Token: 0x06000812 RID: 2066 RVA: 0x0001C1DC File Offset: 0x0001A3DC
		public string GetTittle()
		{
			return this.nombre;
		}

		// Token: 0x04000326 RID: 806
		[Ignore]
		public string nombre = "---";

		// Token: 0x04000327 RID: 807
		[Modelo]
		[ParentPanelTarget(index = 0)]
		public listaDeSubDetallesDeItemModelo subDetallesIzq = new listaDeSubDetallesDeItemModelo();

		// Token: 0x04000328 RID: 808
		[Modelo]
		[ParentPanelTarget(index = 1)]
		public listaDeSubDetallesDeItemModelo subDetallesDer = new listaDeSubDetallesDeItemModelo();
	}
}
