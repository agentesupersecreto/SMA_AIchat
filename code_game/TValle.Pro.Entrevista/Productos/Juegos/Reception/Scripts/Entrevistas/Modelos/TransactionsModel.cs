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
	// Token: 0x0200000B RID: 11
	[Modelo]
	[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[Panel(tipo = TipoDePanel.nestedContainerConTitulo)]
	[Serializable]
	public class TransactionsModel
	{
		// Token: 0x06000067 RID: 103 RVA: 0x00003F96 File Offset: 0x00002196
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000068 RID: 104 RVA: 0x00003FA0 File Offset: 0x000021A0
		// (remove) Token: 0x06000069 RID: 105 RVA: 0x00003FD8 File Offset: 0x000021D8
		public event Action<TransactionsModel.Item, int, TransactionsModel> itemClicked;

		// Token: 0x0600006A RID: 106 RVA: 0x00004010 File Offset: 0x00002210
		[MemberBotonClickedListener(member = "items")]
		protected void OnItemClicked(IUIBoton elemento)
		{
			TransactionsModel.Item valueOrDefault = this.items.GetValueOrDefault(elemento.modelItemIndex);
			Action<TransactionsModel.Item, int, TransactionsModel> action = this.itemClicked;
			if (action == null)
			{
				return;
			}
			action(valueOrDefault, elemento.modelItemIndex, this);
		}

		// Token: 0x0400004A RID: 74
		[Ignore]
		[NonSerialized]
		public string title = "Transactions";

		// Token: 0x0400004C RID: 76
		[ClickableLabelDescriptableCompacto(confirmar = false)]
		public List<TransactionsModel.Item> items = new List<TransactionsModel.Item>();

		// Token: 0x02000152 RID: 338
		[Serializable]
		public class Item : IMultipleValorElemento<string, string, string, Color?, string>, IMultipleValorElemento<string, string, string, Color?>, IMultipleValorElemento<string, string, string>, IMultipleValorElemento<string, string>, IMultipleValorElemento<string>
		{
			// Token: 0x06000B6A RID: 2922 RVA: 0x0003AF78 File Offset: 0x00039178
			public Item()
			{
			}

			// Token: 0x06000B6B RID: 2923 RVA: 0x0003AF80 File Offset: 0x00039180
			public Item(string id, string Label, string Descripcion, Color? Color, string Date)
			{
				this.ID = id;
				this.label = Label;
				this.descripcion = Descripcion;
				this.color = Color;
				this.date = Date;
			}

			// Token: 0x17000198 RID: 408
			// (get) Token: 0x06000B6C RID: 2924 RVA: 0x0003AFAD File Offset: 0x000391AD
			public string item1
			{
				get
				{
					return this.ID;
				}
			}

			// Token: 0x17000199 RID: 409
			// (get) Token: 0x06000B6D RID: 2925 RVA: 0x0003AFB5 File Offset: 0x000391B5
			public string item2
			{
				get
				{
					return this.label;
				}
			}

			// Token: 0x1700019A RID: 410
			// (get) Token: 0x06000B6E RID: 2926 RVA: 0x0003AFBD File Offset: 0x000391BD
			public string item3
			{
				get
				{
					return this.descripcion;
				}
			}

			// Token: 0x1700019B RID: 411
			// (get) Token: 0x06000B6F RID: 2927 RVA: 0x0003AFC5 File Offset: 0x000391C5
			public Color? item4
			{
				get
				{
					return this.color;
				}
			}

			// Token: 0x1700019C RID: 412
			// (get) Token: 0x06000B70 RID: 2928 RVA: 0x0003AFCD File Offset: 0x000391CD
			public string item5
			{
				get
				{
					return this.date;
				}
			}

			// Token: 0x040005AB RID: 1451
			public string ID;

			// Token: 0x040005AC RID: 1452
			public string label;

			// Token: 0x040005AD RID: 1453
			public string descripcion;

			// Token: 0x040005AE RID: 1454
			public Color? color;

			// Token: 0x040005AF RID: 1455
			public string date;
		}
	}
}
