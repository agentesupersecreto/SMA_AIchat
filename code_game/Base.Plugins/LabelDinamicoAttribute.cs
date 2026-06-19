using System;
using Assets.Base.Plugins.Runtime.UI;

// Token: 0x0200004A RID: 74
[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class LabelDinamicoAttribute : OrderAttribute
{
	// Token: 0x17000036 RID: 54
	// (get) Token: 0x0600026D RID: 621 RVA: 0x0000C8A0 File Offset: 0x0000AAA0
	// (set) Token: 0x0600026E RID: 622 RVA: 0x0000C8A8 File Offset: 0x0000AAA8
	public string dinamicoMethodTarget { get; set; }

	// Token: 0x0600026F RID: 623 RVA: 0x0000C8B1 File Offset: 0x0000AAB1
	public LabelDinamicoAttribute()
		: base(0)
	{
	}

	// Token: 0x020001A9 RID: 425
	// (Invoke) Token: 0x06000C09 RID: 3081
	public delegate string LabelDinamicaHandler();
}
