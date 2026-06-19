using System;

// Token: 0x02000048 RID: 72
[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class DescripcionLocalizadoAttribute : TextoLocalizadoAttribute
{
	// Token: 0x06000267 RID: 615 RVA: 0x0000C86B File Offset: 0x0000AA6B
	public DescripcionLocalizadoAttribute()
	{
	}

	// Token: 0x06000268 RID: 616 RVA: 0x0000C873 File Offset: 0x0000AA73
	public DescripcionLocalizadoAttribute(string text)
		: base(text)
	{
	}

	// Token: 0x06000269 RID: 617 RVA: 0x0000C87C File Offset: 0x0000AA7C
	public DescripcionLocalizadoAttribute(string text, string localizationID)
		: base(text, localizationID)
	{
	}
}
