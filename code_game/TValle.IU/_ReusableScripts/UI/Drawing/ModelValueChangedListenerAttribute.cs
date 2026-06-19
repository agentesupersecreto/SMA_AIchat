using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000044 RID: 68
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class ModelValueChangedListenerAttribute : Attribute
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001CB RID: 459 RVA: 0x0000687D File Offset: 0x00004A7D
		// (set) Token: 0x060001CC RID: 460 RVA: 0x00006885 File Offset: 0x00004A85
		public bool escucharTodosLosElementosAnteriores { get; set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001CD RID: 461 RVA: 0x0000688E File Offset: 0x00004A8E
		// (set) Token: 0x060001CE RID: 462 RVA: 0x00006896 File Offset: 0x00004A96
		public bool escucharSubElementosDeEsteModel { get; set; }
	}
}
