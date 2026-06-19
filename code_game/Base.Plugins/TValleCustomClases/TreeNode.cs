using System;
using System.Collections;
using System.Collections.Generic;

namespace TValleCustomClases
{
	// Token: 0x02000077 RID: 119
	public abstract class TreeNode<T> : IEnumerable<TreeNode<T>>, IEnumerable
	{
		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600037E RID: 894
		public abstract TreeNode<T> parent { get; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600037F RID: 895
		public abstract T value { get; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000380 RID: 896
		protected abstract List<TreeNode<T>> children { get; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000381 RID: 897 RVA: 0x0000F2A4 File Offset: 0x0000D4A4
		public virtual int count
		{
			get
			{
				return this.children.Count;
			}
		}

		// Token: 0x17000073 RID: 115
		public virtual TreeNode<T> this[int i]
		{
			get
			{
				return this.children[i];
			}
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0000F2BF File Offset: 0x0000D4BF
		public virtual bool isvalid()
		{
			return this.value != null && this.children != null && !this.children.Contains(null);
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0000F2E7 File Offset: 0x0000D4E7
		public IEnumerator<TreeNode<T>> GetEnumerator()
		{
			return this.children.GetEnumerator();
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0000F2F9 File Offset: 0x0000D4F9
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.children.GetEnumerator();
		}
	}
}
