using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;

namespace Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Modelos
{
	// Token: 0x02000110 RID: 272
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[Panel(tipo = TipoDePanel.nestedContainer, heightMod = 0.5f)]
	[Serializable]
	public class listaDeSubDetallesDeItemModelo
	{
		// Token: 0x06000814 RID: 2068 RVA: 0x0001C20D File Offset: 0x0001A40D
		public string GetTittle()
		{
			return this.nombre;
		}

		// Token: 0x04000329 RID: 809
		[Ignore]
		public string nombre = "---";

		// Token: 0x0400032A RID: 810
		[LayoutConfigUI(height = 25)]
		[LayoutConfigUI(height = 25)]
		[LayoutConfigUI(height = 25)]
		[FontProConfigUI(color = ColorEnum.pink, fontStyle = FontStyles.Italic)]
		[FontProConfigUI(color = ColorEnum.white)]
		[FontProConfigUI(color = ColorEnum.gray)]
		[LabelPar]
		public List<listaDeSubDetallesDeItemModelo.Par> subDetalles = new List<listaDeSubDetallesDeItemModelo.Par>
		{
			new listaDeSubDetallesDeItemModelo.Par("-----", "-----", string.Empty)
		};

		// Token: 0x020001CC RID: 460
		[Serializable]
		public class Par : IMultipleValorElemento<string, string, string, string>, IMultipleValorElemento<string, string, string>, IMultipleValorElemento<string, string>, IMultipleValorElemento<string>
		{
			// Token: 0x06000C42 RID: 3138 RVA: 0x000253EA File Offset: 0x000235EA
			public Par()
			{
			}

			// Token: 0x06000C43 RID: 3139 RVA: 0x00025413 File Offset: 0x00023613
			public Par(string Label1, string Label2, string Descripcion1)
			{
				this.label1 = Label1;
				this.label2 = Label2;
				this.descripcion1 = Descripcion1;
			}

			// Token: 0x17000307 RID: 775
			// (get) Token: 0x06000C44 RID: 3140 RVA: 0x00025451 File Offset: 0x00023651
			string IMultipleValorElemento<string>.item1
			{
				get
				{
					return this.label1;
				}
			}

			// Token: 0x17000308 RID: 776
			// (get) Token: 0x06000C45 RID: 3141 RVA: 0x00025459 File Offset: 0x00023659
			string IMultipleValorElemento<string, string>.item2
			{
				get
				{
					return this.label2;
				}
			}

			// Token: 0x17000309 RID: 777
			// (get) Token: 0x06000C46 RID: 3142 RVA: 0x00025461 File Offset: 0x00023661
			string IMultipleValorElemento<string, string, string>.item3
			{
				get
				{
					return this.descripcion1;
				}
			}

			// Token: 0x1700030A RID: 778
			// (get) Token: 0x06000C47 RID: 3143 RVA: 0x00025469 File Offset: 0x00023669
			string IMultipleValorElemento<string, string, string, string>.item4
			{
				get
				{
					return ":";
				}
			}

			// Token: 0x040005B8 RID: 1464
			public string label1 = "-----";

			// Token: 0x040005B9 RID: 1465
			public string label2 = "-----";

			// Token: 0x040005BA RID: 1466
			public string descripcion1 = string.Empty;
		}
	}
}
