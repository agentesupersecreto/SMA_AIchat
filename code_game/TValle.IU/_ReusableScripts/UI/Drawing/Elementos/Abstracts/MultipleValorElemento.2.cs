using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x0200009B RID: 155
	[Serializable]
	public struct MultipleValorElemento<T1, T2, T3>
	{
		// Token: 0x060004FE RID: 1278 RVA: 0x00014808 File Offset: 0x00012A08
		public MultipleValorElemento(T1 Item1, T2 Item2, T3 Item3)
		{
			this.item1 = Item1;
			this.item2 = Item2;
			this.item3 = Item3;
		}

		// Token: 0x040001F1 RID: 497
		public T1 item1;

		// Token: 0x040001F2 RID: 498
		public T2 item2;

		// Token: 0x040001F3 RID: 499
		public T3 item3;
	}
}
