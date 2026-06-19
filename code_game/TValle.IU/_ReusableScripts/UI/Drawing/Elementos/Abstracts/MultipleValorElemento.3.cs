using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x0200009C RID: 156
	[Serializable]
	public struct MultipleValorElemento<T1, T2, T3, T4> : IMultipleValorElemento<T1, T2, T3, T4>, IMultipleValorElemento<T1, T2, T3>, IMultipleValorElemento<T1, T2>, IMultipleValorElemento<T1>
	{
		// Token: 0x060004FF RID: 1279 RVA: 0x0001481F File Offset: 0x00012A1F
		public MultipleValorElemento(T1 Item1, T2 Item2, T3 Item3, T4 Item4)
		{
			this.item1 = Item1;
			this.item2 = Item2;
			this.item3 = Item3;
			this.item4 = Item4;
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x0001483E File Offset: 0x00012A3E
		T1 IMultipleValorElemento<T1>.item1
		{
			get
			{
				return this.item1;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x00014846 File Offset: 0x00012A46
		T2 IMultipleValorElemento<T1, T2>.item2
		{
			get
			{
				return this.item2;
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x0001484E File Offset: 0x00012A4E
		T3 IMultipleValorElemento<T1, T2, T3>.item3
		{
			get
			{
				return this.item3;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000503 RID: 1283 RVA: 0x00014856 File Offset: 0x00012A56
		T4 IMultipleValorElemento<T1, T2, T3, T4>.item4
		{
			get
			{
				return this.item4;
			}
		}

		// Token: 0x040001F4 RID: 500
		public T1 item1;

		// Token: 0x040001F5 RID: 501
		public T2 item2;

		// Token: 0x040001F6 RID: 502
		public T3 item3;

		// Token: 0x040001F7 RID: 503
		public T4 item4;
	}
}
