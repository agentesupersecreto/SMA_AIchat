using System;
using System.Runtime.CompilerServices;

namespace Assets.Base.Plugins.Runtime.UI
{
	// Token: 0x02000189 RID: 393
	public class OrderAttribute : Attribute
	{
		// Token: 0x06000B94 RID: 2964 RVA: 0x00025F2E File Offset: 0x0002412E
		public OrderAttribute([CallerLineNumber] int order = 0)
		{
			this.order_ = order;
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000B95 RID: 2965 RVA: 0x00025F3D File Offset: 0x0002413D
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

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000B96 RID: 2966 RVA: 0x00025F5E File Offset: 0x0002415E
		// (set) Token: 0x06000B97 RID: 2967 RVA: 0x00025F6B File Offset: 0x0002416B
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

		// Token: 0x040003C5 RID: 965
		private readonly int order_;

		// Token: 0x040003C6 RID: 966
		private int? m_orderOverriden;
	}
}
