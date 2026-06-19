using System;

// Token: 0x0200000E RID: 14
public interface IActivableInput : IActivable
{
	// Token: 0x17000005 RID: 5
	// (get) Token: 0x0600004A RID: 74
	// (set) Token: 0x0600004B RID: 75
	bool movementActivado { get; set; }

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x0600004C RID: 76
	// (set) Token: 0x0600004D RID: 77
	bool viewActivado { get; set; }

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x0600004E RID: 78
	// (set) Token: 0x0600004F RID: 79
	bool actionActivado { get; set; }

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x06000050 RID: 80
	// (set) Token: 0x06000051 RID: 81
	bool UIActivado { get; set; }
}
