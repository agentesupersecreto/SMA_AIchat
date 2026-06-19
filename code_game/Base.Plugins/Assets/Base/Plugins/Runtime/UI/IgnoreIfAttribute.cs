using System;

namespace Assets.Base.Plugins.Runtime.UI
{
	// Token: 0x0200018D RID: 397
	public sealed class IgnoreIfAttribute : Attribute
	{
		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000B9B RID: 2971 RVA: 0x00025F92 File Offset: 0x00024192
		// (set) Token: 0x06000B9C RID: 2972 RVA: 0x00025F9A File Offset: 0x0002419A
		public string method { get; set; }
	}
}
