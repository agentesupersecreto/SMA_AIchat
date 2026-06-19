using System;
using System.Collections;
using System.Collections.Generic;

namespace TValleCustomClases
{
	// Token: 0x02000076 RID: 118
	public abstract class Leaf<T> : TreeNode<T>, IEnumerable<TreeNode<T>>, IEnumerable
	{
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000379 RID: 889 RVA: 0x0000F27F File Offset: 0x0000D47F
		protected override List<TreeNode<T>> children
		{
			get
			{
				return new List<TreeNode<T>>();
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600037A RID: 890 RVA: 0x0000F286 File Offset: 0x0000D486
		public override int count
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x1700006E RID: 110
		public override TreeNode<T> this[int i]
		{
			get
			{
				return null;
			}
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0000F28C File Offset: 0x0000D48C
		public override bool isvalid()
		{
			return this.value != null;
		}
	}
}
