using System;

namespace Assets.Base.Plugins.Runtime.UI
{
	// Token: 0x02000186 RID: 390
	public abstract class DynamicUIElementAttribute : OrderAttribute
	{
		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000B8F RID: 2959 RVA: 0x00025F05 File Offset: 0x00024105
		// (set) Token: 0x06000B90 RID: 2960 RVA: 0x00025F0D File Offset: 0x0002410D
		public bool enabled { get; set; } = true;

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000B91 RID: 2961
		public abstract UIElementoDinamico tipo { get; }

		// Token: 0x06000B92 RID: 2962 RVA: 0x00025F16 File Offset: 0x00024116
		protected DynamicUIElementAttribute()
			: base(0)
		{
		}
	}
}
