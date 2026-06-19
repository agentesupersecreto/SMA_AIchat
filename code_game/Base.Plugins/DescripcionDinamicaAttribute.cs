using System;
using Assets.Base.Plugins.Runtime.UI;

// Token: 0x02000049 RID: 73
[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class DescripcionDinamicaAttribute : OrderAttribute
{
	// Token: 0x17000035 RID: 53
	// (get) Token: 0x0600026A RID: 618 RVA: 0x0000C886 File Offset: 0x0000AA86
	// (set) Token: 0x0600026B RID: 619 RVA: 0x0000C88E File Offset: 0x0000AA8E
	public string dinamicoMethodTarget { get; set; }

	// Token: 0x0600026C RID: 620 RVA: 0x0000C897 File Offset: 0x0000AA97
	public DescripcionDinamicaAttribute()
		: base(0)
	{
	}

	// Token: 0x020001A8 RID: 424
	// (Invoke) Token: 0x06000C05 RID: 3077
	public delegate string DescripcionDinamicaHandler(out float widthMod, int index);
}
