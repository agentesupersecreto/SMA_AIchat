using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200006C RID: 108
	[Serializable]
	public class LabelData : IMultipleValorElemento<string, string, Color?>, IMultipleValorElemento<string, string>, IMultipleValorElemento<string>
	{
		// Token: 0x06000324 RID: 804 RVA: 0x000077B2 File Offset: 0x000059B2
		public LabelData()
		{
		}

		// Token: 0x06000325 RID: 805 RVA: 0x000077BA File Offset: 0x000059BA
		public LabelData(string id, string Label, Color? Color)
		{
			this.ID = id;
			this.label = Label;
			this.color = Color;
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000326 RID: 806 RVA: 0x000077D7 File Offset: 0x000059D7
		public string item1
		{
			get
			{
				return this.ID;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000327 RID: 807 RVA: 0x000077DF File Offset: 0x000059DF
		public string item2
		{
			get
			{
				return this.label;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000328 RID: 808 RVA: 0x000077E7 File Offset: 0x000059E7
		public Color? item3
		{
			get
			{
				return this.color;
			}
		}

		// Token: 0x04000135 RID: 309
		public string ID;

		// Token: 0x04000136 RID: 310
		public string label;

		// Token: 0x04000137 RID: 311
		public Color? color;
	}
}
