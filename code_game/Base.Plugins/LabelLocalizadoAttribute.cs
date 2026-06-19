using System;

// Token: 0x0200004C RID: 76
[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class LabelLocalizadoAttribute : TextoLocalizadoAttribute
{
	// Token: 0x06000273 RID: 627 RVA: 0x0000C8D4 File Offset: 0x0000AAD4
	public LabelLocalizadoAttribute()
	{
	}

	// Token: 0x06000274 RID: 628 RVA: 0x0000C8DC File Offset: 0x0000AADC
	public LabelLocalizadoAttribute(string text)
		: base(text)
	{
	}

	// Token: 0x06000275 RID: 629 RVA: 0x0000C8E5 File Offset: 0x0000AAE5
	public LabelLocalizadoAttribute(string text, string localizationID)
		: base(text, localizationID)
	{
	}
}
