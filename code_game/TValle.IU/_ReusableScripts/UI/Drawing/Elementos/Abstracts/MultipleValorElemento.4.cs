using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x0200009D RID: 157
	[Serializable]
	public struct MultipleValorElemento<T1, T2, T3, T4, T5> : IMultipleValorElemento<T1, T2, T3, T4, T5>, IMultipleValorElemento<T1, T2, T3, T4>, IMultipleValorElemento<T1, T2, T3>, IMultipleValorElemento<T1, T2>, IMultipleValorElemento<T1>
	{
		// Token: 0x06000504 RID: 1284 RVA: 0x0001485E File Offset: 0x00012A5E
		public MultipleValorElemento(T1 Item1, T2 Item2, T3 Item3, T4 Item4, T5 Item5)
		{
			this.item1 = Item1;
			this.item2 = Item2;
			this.item3 = Item3;
			this.item4 = Item4;
			this.item5 = Item5;
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000505 RID: 1285 RVA: 0x00014885 File Offset: 0x00012A85
		T1 IMultipleValorElemento<T1>.item1
		{
			get
			{
				return this.item1;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x0001488D File Offset: 0x00012A8D
		T2 IMultipleValorElemento<T1, T2>.item2
		{
			get
			{
				return this.item2;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x00014895 File Offset: 0x00012A95
		T3 IMultipleValorElemento<T1, T2, T3>.item3
		{
			get
			{
				return this.item3;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x0001489D File Offset: 0x00012A9D
		T4 IMultipleValorElemento<T1, T2, T3, T4>.item4
		{
			get
			{
				return this.item4;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x000148A5 File Offset: 0x00012AA5
		T5 IMultipleValorElemento<T1, T2, T3, T4, T5>.item5
		{
			get
			{
				return this.item5;
			}
		}

		// Token: 0x040001F8 RID: 504
		public T1 item1;

		// Token: 0x040001F9 RID: 505
		public T2 item2;

		// Token: 0x040001FA RID: 506
		public T3 item3;

		// Token: 0x040001FB RID: 507
		public T4 item4;

		// Token: 0x040001FC RID: 508
		public T5 item5;
	}
}
