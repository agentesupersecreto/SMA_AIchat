using System;

namespace Assets
{
	// Token: 0x02000135 RID: 309
	public abstract class SimplePool
	{
		// Token: 0x060008C6 RID: 2246 RVA: 0x0001D124 File Offset: 0x0001B324
		public SimplePool()
		{
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060008C7 RID: 2247
		protected abstract Type type { get; }

		// Token: 0x060008C8 RID: 2248 RVA: 0x0001D135 File Offset: 0x0001B335
		public void IncrementarDeudaBy(long times)
		{
			this.m_deudaADeclarar *= times;
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x0001D145 File Offset: 0x0001B345
		public void ignorarDeduda(long cantidad)
		{
			this.m_deuda -= cantidad;
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x0001D155 File Offset: 0x0001B355
		protected void OnGetItem(object item)
		{
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x0001D157 File Offset: 0x0001B357
		protected void OnReturnItem(object item)
		{
		}

		// Token: 0x0400024B RID: 587
		private Guid m_id;

		// Token: 0x0400024C RID: 588
		private long m_deuda;

		// Token: 0x0400024D RID: 589
		private long m_deudaADeclarar = 100L;
	}
}
