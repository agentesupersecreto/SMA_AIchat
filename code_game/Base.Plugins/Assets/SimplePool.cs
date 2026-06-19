using System;
using System.Collections.Generic;

namespace Assets
{
	// Token: 0x02000133 RID: 307
	public class SimplePool<T> : SimplePool where T : class, new()
	{
		// Token: 0x060008AA RID: 2218 RVA: 0x0001CB53 File Offset: 0x0001AD53
		public SimplePool()
		{
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x0001CB71 File Offset: 0x0001AD71
		public SimplePool(Action<T> ReturningAction)
		{
			this.m_ReturningAction = ReturningAction;
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060008AC RID: 2220 RVA: 0x0001CB96 File Offset: 0x0001AD96
		protected sealed override Type type
		{
			get
			{
				return SimplePool<T>.m_poolType;
			}
		}

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x060008AD RID: 2221 RVA: 0x0001CBA0 File Offset: 0x0001ADA0
		// (remove) Token: 0x060008AE RID: 2222 RVA: 0x0001CBD8 File Offset: 0x0001ADD8
		public event Action<SimplePool<T>, T> itemCreated;

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x060008AF RID: 2223 RVA: 0x0001CC10 File Offset: 0x0001AE10
		// (remove) Token: 0x060008B0 RID: 2224 RVA: 0x0001CC48 File Offset: 0x0001AE48
		public event Action<SimplePool<T>, T> itemReturning;

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x060008B1 RID: 2225 RVA: 0x0001CC80 File Offset: 0x0001AE80
		// (remove) Token: 0x060008B2 RID: 2226 RVA: 0x0001CCB8 File Offset: 0x0001AEB8
		public event Action<SimplePool<T>, T> itemReturned;

		// Token: 0x060008B3 RID: 2227 RVA: 0x0001CCF0 File Offset: 0x0001AEF0
		public virtual T GetItem()
		{
			if (this.m_pool.Count == 0)
			{
				T t = new T();
				Action<SimplePool<T>, T> action = this.itemCreated;
				if (action != null)
				{
					action(this, t);
				}
				return t;
			}
			T t2 = this.m_pool.Dequeue();
			this.m_contenidos.Remove(t2);
			this.count = this.m_pool.Count;
			return t2;
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x0001CD50 File Offset: 0x0001AF50
		public void ReturnItem(T item)
		{
			if (item == null)
			{
				return;
			}
			Action<SimplePool<T>, T> action = this.itemReturning;
			if (action != null)
			{
				action(this, item);
			}
			this.ReturningItem(item);
			Action<T> returningAction = this.m_ReturningAction;
			if (returningAction != null)
			{
				returningAction(item);
			}
			if (this.m_contenidos.Add(item))
			{
				this.m_pool.Enqueue(item);
			}
			this.count = this.m_pool.Count;
			this.ReturnedItem(item);
			Action<SimplePool<T>, T> action2 = this.itemReturned;
			if (action2 == null)
			{
				return;
			}
			action2(this, item);
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x0001CDD6 File Offset: 0x0001AFD6
		protected virtual void ReturningItem(T item)
		{
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x0001CDD8 File Offset: 0x0001AFD8
		protected virtual void ReturnedItem(T item)
		{
		}

		// Token: 0x04000238 RID: 568
		private static readonly Type m_poolType = typeof(T);

		// Token: 0x04000239 RID: 569
		private Action<T> m_ReturningAction;

		// Token: 0x0400023A RID: 570
		public int count;

		// Token: 0x0400023B RID: 571
		private Queue<T> m_pool = new Queue<T>();

		// Token: 0x0400023C RID: 572
		private HashSet<T> m_contenidos = new HashSet<T>();
	}
}
