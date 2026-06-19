using System;
using System.Collections.Generic;

namespace Assets
{
	// Token: 0x02000138 RID: 312
	public class SimplePoolDeCollection<T_Collection, T> : SimplePool<T_Collection> where T_Collection : class, ICollection<T>, new()
	{
		// Token: 0x060008D2 RID: 2258 RVA: 0x0001D1A9 File Offset: 0x0001B3A9
		public override T_Collection GetItem()
		{
			T_Collection item = base.GetItem();
			item.Clear();
			return item;
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x0001D1BC File Offset: 0x0001B3BC
		protected override void ReturningItem(T_Collection item)
		{
			base.ReturningItem(item);
			item.Clear();
		}
	}
}
