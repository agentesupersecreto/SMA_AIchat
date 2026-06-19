using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200006D RID: 109
	[Serializable]
	public class LabelData2 : IMultipleValorElemento<string, string, string, Color?>, IMultipleValorElemento<string, string, string>, IMultipleValorElemento<string, string>, IMultipleValorElemento<string>
	{
		// Token: 0x06000329 RID: 809 RVA: 0x000077EF File Offset: 0x000059EF
		public LabelData2()
		{
		}

		// Token: 0x0600032A RID: 810 RVA: 0x000077F7 File Offset: 0x000059F7
		public LabelData2(string id, string Label, string Description, Color? Color)
		{
			this.ID = id;
			this.label = Label;
			this.description = Description;
			this.color = Color;
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x0600032B RID: 811 RVA: 0x0000781C File Offset: 0x00005A1C
		public string item1
		{
			get
			{
				return this.ID;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x0600032C RID: 812 RVA: 0x00007824 File Offset: 0x00005A24
		public string item2
		{
			get
			{
				return this.label;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600032D RID: 813 RVA: 0x0000782C File Offset: 0x00005A2C
		public string item3
		{
			get
			{
				return this.description;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600032E RID: 814 RVA: 0x00007834 File Offset: 0x00005A34
		public Color? item4
		{
			get
			{
				return this.color;
			}
		}

		// Token: 0x04000138 RID: 312
		public string ID;

		// Token: 0x04000139 RID: 313
		public string label;

		// Token: 0x0400013A RID: 314
		public string description;

		// Token: 0x0400013B RID: 315
		public Color? color;
	}
}
