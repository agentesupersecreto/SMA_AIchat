using System;

namespace Assets
{
	// Token: 0x02000137 RID: 311
	public class SimplePoolDeClearables<T> : SimplePool<T> where T : class, IClearable, new()
	{
		// Token: 0x060008CF RID: 2255 RVA: 0x0001D15C File Offset: 0x0001B35C
		public override T GetItem()
		{
			T t;
			for (t = base.GetItem(); t == null; t = base.GetItem())
			{
			}
			t.Clear();
			return t;
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x0001D18D File Offset: 0x0001B38D
		protected override void ReturningItem(T item)
		{
			base.ReturningItem(item);
			item.Clear();
		}
	}
}
