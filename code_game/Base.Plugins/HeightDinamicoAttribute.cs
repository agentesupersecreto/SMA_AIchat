using System;
using Assets.Base.Plugins.Runtime.UI;

// Token: 0x0200004B RID: 75
[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class HeightDinamicoAttribute : OrderAttribute
{
	// Token: 0x17000037 RID: 55
	// (get) Token: 0x06000270 RID: 624 RVA: 0x0000C8BA File Offset: 0x0000AABA
	// (set) Token: 0x06000271 RID: 625 RVA: 0x0000C8C2 File Offset: 0x0000AAC2
	public string dinamicoMethodTarget { get; set; }

	// Token: 0x06000272 RID: 626 RVA: 0x0000C8CB File Offset: 0x0000AACB
	public HeightDinamicoAttribute()
		: base(0)
	{
	}

	// Token: 0x020001AA RID: 426
	// (Invoke) Token: 0x06000C0D RID: 3085
	public delegate int HeightDinamicaHandler();
}
