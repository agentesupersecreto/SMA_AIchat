using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000134 RID: 308
	public class SimplePoolDeComponentesHijos<T> : SimplePool where T : Behaviour
	{
		// Token: 0x060008B8 RID: 2232 RVA: 0x0001CDEB File Offset: 0x0001AFEB
		public SimplePoolDeComponentesHijos(Transform Parent)
		{
			this.m_parent = Parent;
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x0001CE10 File Offset: 0x0001B010
		public SimplePoolDeComponentesHijos(Transform Parent, Action<T> InstantiatedAction, Action<T> ClearingAction)
			: this(Parent)
		{
			this.m_InstantiatedAction = InstantiatedAction;
			this.m_ClearingAction = ClearingAction;
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060008BA RID: 2234 RVA: 0x0001CE27 File Offset: 0x0001B027
		protected sealed override Type type
		{
			get
			{
				return SimplePoolDeComponentesHijos<T>.m_poolType;
			}
		}

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x060008BB RID: 2235 RVA: 0x0001CE30 File Offset: 0x0001B030
		// (remove) Token: 0x060008BC RID: 2236 RVA: 0x0001CE68 File Offset: 0x0001B068
		public event Action<SimplePoolDeComponentesHijos<T>, T> itemCreated;

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x060008BD RID: 2237 RVA: 0x0001CEA0 File Offset: 0x0001B0A0
		// (remove) Token: 0x060008BE RID: 2238 RVA: 0x0001CED8 File Offset: 0x0001B0D8
		public event Action<SimplePoolDeComponentesHijos<T>, T> itemReturning;

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x060008BF RID: 2239 RVA: 0x0001CF10 File Offset: 0x0001B110
		// (remove) Token: 0x060008C0 RID: 2240 RVA: 0x0001CF48 File Offset: 0x0001B148
		public event Action<SimplePoolDeComponentesHijos<T>, T> itemReturned;

		// Token: 0x060008C1 RID: 2241 RVA: 0x0001CF80 File Offset: 0x0001B180
		public virtual T GetItem()
		{
			if (this.m_pool.Count == 0)
			{
				this.m_total++;
				T t = this.m_parent.CreateChild(this.m_parent.parent.name + " " + this.m_total.ToString()).gameObject.AddComponent<T>();
				Action<SimplePoolDeComponentesHijos<T>, T> action = this.itemCreated;
				if (action != null)
				{
					action(this, t);
				}
				Action<T> instantiatedAction = this.m_InstantiatedAction;
				if (instantiatedAction != null)
				{
					instantiatedAction(t);
				}
				return t;
			}
			T t2 = this.m_pool.Dequeue();
			this.m_contenidos.Remove(t2);
			this.count = this.m_pool.Count;
			return t2;
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x0001D038 File Offset: 0x0001B238
		public void ReturnItem(T item)
		{
			if (item == null)
			{
				return;
			}
			Action<SimplePoolDeComponentesHijos<T>, T> action = this.itemReturning;
			if (action != null)
			{
				action(this, item);
			}
			this.ReturningItem(item);
			Action<T> clearingAction = this.m_ClearingAction;
			if (clearingAction != null)
			{
				clearingAction(item);
			}
			if (this.m_contenidos.Add(item))
			{
				this.m_pool.Enqueue(item);
			}
			this.count = this.m_pool.Count;
			this.ReturnedItem(item);
			Action<SimplePoolDeComponentesHijos<T>, T> action2 = this.itemReturned;
			if (action2 == null)
			{
				return;
			}
			action2(this, item);
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x0001D0C4 File Offset: 0x0001B2C4
		protected virtual void ReturningItem(T item)
		{
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x0001D0C6 File Offset: 0x0001B2C6
		protected virtual void ReturnedItem(T item)
		{
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x0001D0C8 File Offset: 0x0001B2C8
		public void Destroy()
		{
			foreach (T t in this.m_contenidos)
			{
				Object.Destroy(t.gameObject);
			}
		}

		// Token: 0x04000240 RID: 576
		private static readonly Type m_poolType = typeof(T);

		// Token: 0x04000241 RID: 577
		private Transform m_parent;

		// Token: 0x04000242 RID: 578
		private Action<T> m_InstantiatedAction;

		// Token: 0x04000243 RID: 579
		private Action<T> m_ClearingAction;

		// Token: 0x04000244 RID: 580
		public int count;

		// Token: 0x04000245 RID: 581
		private Queue<T> m_pool = new Queue<T>();

		// Token: 0x04000246 RID: 582
		private HashSet<T> m_contenidos = new HashSet<T>();

		// Token: 0x0400024A RID: 586
		private int m_total;
	}
}
