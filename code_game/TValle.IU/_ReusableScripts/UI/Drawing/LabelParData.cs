using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000070 RID: 112
	[Serializable]
	public class LabelParData : IMultipleValorElemento<string, string, string, string>, IMultipleValorElemento<string, string, string>, IMultipleValorElemento<string, string>, IMultipleValorElemento<string>
	{
		// Token: 0x0600033A RID: 826 RVA: 0x00007981 File Offset: 0x00005B81
		public LabelParData()
		{
		}

		// Token: 0x0600033B RID: 827 RVA: 0x000079AC File Offset: 0x00005BAC
		public LabelParData(string Label1, string Label2, string Descripcion1)
		{
			if (Label1 != null)
			{
				this.label1 = Label1;
			}
			if (Label2 != null)
			{
				this.label2 = Label2;
			}
			if (Descripcion1 != null)
			{
				this.descripcion1 = Descripcion1;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600033C RID: 828 RVA: 0x000079FE File Offset: 0x00005BFE
		string IMultipleValorElemento<string>.item1
		{
			get
			{
				return this.label1;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600033D RID: 829 RVA: 0x00007A06 File Offset: 0x00005C06
		string IMultipleValorElemento<string, string>.item2
		{
			get
			{
				return this.label2;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600033E RID: 830 RVA: 0x00007A0E File Offset: 0x00005C0E
		string IMultipleValorElemento<string, string, string>.item3
		{
			get
			{
				return this.descripcion1;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600033F RID: 831 RVA: 0x00007A16 File Offset: 0x00005C16
		string IMultipleValorElemento<string, string, string, string>.item4
		{
			get
			{
				return ":";
			}
		}

		// Token: 0x04000140 RID: 320
		public string label1 = "-----";

		// Token: 0x04000141 RID: 321
		public string label2 = "-----";

		// Token: 0x04000142 RID: 322
		public string descripcion1 = string.Empty;
	}
}
