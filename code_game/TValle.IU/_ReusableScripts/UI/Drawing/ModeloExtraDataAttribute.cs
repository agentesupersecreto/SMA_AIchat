using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200003C RID: 60
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public sealed class ModeloExtraDataAttribute : Attribute
	{
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x000067A4 File Offset: 0x000049A4
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x000067AC File Offset: 0x000049AC
		public bool paraTodos { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x000067B5 File Offset: 0x000049B5
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x000067BD File Offset: 0x000049BD
		public string para { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x000067C6 File Offset: 0x000049C6
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x000067CE File Offset: 0x000049CE
		public string overridingModeloID { get; set; }
	}
}
