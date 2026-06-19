using System;
using System.Runtime.CompilerServices;

namespace Assets.TValle.Tools.Runtime.UI
{
	// Token: 0x0200000C RID: 12
	public abstract class TValleUIAttribute : Attribute
	{
		// Token: 0x06000025 RID: 37 RVA: 0x000026CD File Offset: 0x000008CD
		public TValleUIAttribute([CallerLineNumber] int order = 0)
		{
			this.order_ = order;
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000026 RID: 38 RVA: 0x000026DC File Offset: 0x000008DC
		public int Order
		{
			get
			{
				if (this.m_orderOverriden == null)
				{
					return this.order_;
				}
				return this.m_orderOverriden.Value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000026FD File Offset: 0x000008FD
		// (set) Token: 0x06000028 RID: 40 RVA: 0x0000270A File Offset: 0x0000090A
		public int orderOverriden
		{
			get
			{
				return this.m_orderOverriden.GetValueOrDefault();
			}
			set
			{
				this.m_orderOverriden = new int?(value);
			}
		}

		// Token: 0x04000017 RID: 23
		private readonly int order_;

		// Token: 0x04000018 RID: 24
		private int? m_orderOverriden;
	}
}
