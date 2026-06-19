using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x0200009A RID: 154
	[Serializable]
	public struct MultipleValorElemento<T1, T2> : IMultipleValorElemento<T1, T2>, IMultipleValorElemento<T1>
	{
		// Token: 0x060004FB RID: 1275 RVA: 0x000147E8 File Offset: 0x000129E8
		public MultipleValorElemento(T1 Item1, T2 Item2)
		{
			this.item1 = Item1;
			this.item2 = Item2;
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x000147F8 File Offset: 0x000129F8
		T1 IMultipleValorElemento<T1>.item1
		{
			get
			{
				return this.item1;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x00014800 File Offset: 0x00012A00
		T2 IMultipleValorElemento<T1, T2>.item2
		{
			get
			{
				return this.item2;
			}
		}

		// Token: 0x040001EF RID: 495
		public T1 item1;

		// Token: 0x040001F0 RID: 496
		public T2 item2;
	}
}
