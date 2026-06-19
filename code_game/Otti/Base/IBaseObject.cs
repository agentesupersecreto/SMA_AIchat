using System;

namespace com.ootii.Base
{
	// Token: 0x0200006E RID: 110
	public interface IBaseObject
	{
		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060004DC RID: 1244
		// (set) Token: 0x060004DD RID: 1245
		string GUID { get; set; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060004DE RID: 1246
		// (set) Token: 0x060004DF RID: 1247
		string Name { get; set; }

		// Token: 0x060004E0 RID: 1248
		string GenerateGUID();
	}
}
