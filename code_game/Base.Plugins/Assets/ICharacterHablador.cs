using System;

namespace Assets
{
	// Token: 0x020000A7 RID: 167
	public interface ICharacterHablador
	{
		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060004FA RID: 1274
		[Obsolete("", true)]
		ICharacterPuedeHablar puedeHablarModificador { get; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060004FB RID: 1275
		bool puedeBalcusear { get; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060004FC RID: 1276
		bool puedeHablarConClaridad { get; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060004FD RID: 1277
		bool estaHablando { get; }

		// Token: 0x060004FE RID: 1278
		bool Hablar(string texto);
	}
}
