using System;

namespace Assets.Base.Plugins.Runtime.UI
{
	// Token: 0x02000192 RID: 402
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
	public class AutoElementoUIAttribute : Attribute
	{
		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000BA8 RID: 2984 RVA: 0x0002600B File Offset: 0x0002420B
		// (set) Token: 0x06000BA9 RID: 2985 RVA: 0x00026013 File Offset: 0x00024213
		public TipoDeElementoUI tipo { get; set; }
	}
}
