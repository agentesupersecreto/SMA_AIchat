using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x02000008 RID: 8
	[Modelo]
	[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[Panel(tipo = TipoDePanel.nestedContainerConTitulo)]
	[Serializable]
	public class EmailsModel
	{
		// Token: 0x0600005F RID: 95 RVA: 0x00003E90 File Offset: 0x00002090
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000060 RID: 96 RVA: 0x00003E98 File Offset: 0x00002098
		// (remove) Token: 0x06000061 RID: 97 RVA: 0x00003ED0 File Offset: 0x000020D0
		public event Action<EmailsModel.Item, int, EmailsModel> itemClicked;

		// Token: 0x06000062 RID: 98 RVA: 0x00003F08 File Offset: 0x00002108
		[MemberBotonClickedListener(member = "items")]
		protected void OnItemClicked(IUIBoton elemento)
		{
			EmailsModel.Item valueOrDefault = this.items.GetValueOrDefault(elemento.modelItemIndex);
			Action<EmailsModel.Item, int, EmailsModel> action = this.itemClicked;
			if (action == null)
			{
				return;
			}
			action(valueOrDefault, elemento.modelItemIndex, this);
		}

		// Token: 0x04000043 RID: 67
		[Ignore]
		[NonSerialized]
		public string title = "Inbox";

		// Token: 0x04000045 RID: 69
		[ClickableLabelDescriptableCompacto(confirmar = false)]
		public List<EmailsModel.Item> items = new List<EmailsModel.Item>();

		// Token: 0x02000151 RID: 337
		[Serializable]
		public class Item : IMultipleValorElemento<string, string, string, Color?, string>, IMultipleValorElemento<string, string, string, Color?>, IMultipleValorElemento<string, string, string>, IMultipleValorElemento<string, string>, IMultipleValorElemento<string>
		{
			// Token: 0x06000B63 RID: 2915 RVA: 0x0003AF1B File Offset: 0x0003911B
			public Item()
			{
			}

			// Token: 0x06000B64 RID: 2916 RVA: 0x0003AF23 File Offset: 0x00039123
			public Item(string id, string Label, string Descripcion, Color? Color, string Date)
			{
				this.ID = id;
				this.label = Label;
				this.descripcion = Descripcion;
				this.color = Color;
				this.date = Date;
			}

			// Token: 0x17000193 RID: 403
			// (get) Token: 0x06000B65 RID: 2917 RVA: 0x0003AF50 File Offset: 0x00039150
			public string item1
			{
				get
				{
					return this.ID;
				}
			}

			// Token: 0x17000194 RID: 404
			// (get) Token: 0x06000B66 RID: 2918 RVA: 0x0003AF58 File Offset: 0x00039158
			public string item2
			{
				get
				{
					return this.label;
				}
			}

			// Token: 0x17000195 RID: 405
			// (get) Token: 0x06000B67 RID: 2919 RVA: 0x0003AF60 File Offset: 0x00039160
			public string item3
			{
				get
				{
					return this.descripcion;
				}
			}

			// Token: 0x17000196 RID: 406
			// (get) Token: 0x06000B68 RID: 2920 RVA: 0x0003AF68 File Offset: 0x00039168
			public Color? item4
			{
				get
				{
					return this.color;
				}
			}

			// Token: 0x17000197 RID: 407
			// (get) Token: 0x06000B69 RID: 2921 RVA: 0x0003AF70 File Offset: 0x00039170
			public string item5
			{
				get
				{
					return this.date;
				}
			}

			// Token: 0x040005A6 RID: 1446
			public string ID;

			// Token: 0x040005A7 RID: 1447
			public string label;

			// Token: 0x040005A8 RID: 1448
			public string descripcion;

			// Token: 0x040005A9 RID: 1449
			public Color? color;

			// Token: 0x040005AA RID: 1450
			public string date;
		}
	}
}
