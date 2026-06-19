using System;
using System.Collections.Generic;

namespace Assets
{
	// Token: 0x020000A4 RID: 164
	public interface ICharacterConversador
	{
		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060004F1 RID: 1265
		IReadOnlyList<ICharacterPuedeConversar> puedeConversarDelegados { get; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060004F2 RID: 1266
		bool puedeConversar { get; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060004F3 RID: 1267
		bool estaConversando { get; }

		// Token: 0x060004F4 RID: 1268
		bool TryConversarCon(string title, ICharacterUnico conversant);

		// Token: 0x060004F5 RID: 1269
		bool TrySerConversarzado(string title, ICharacterUnico actor);

		// Token: 0x060004F6 RID: 1270
		void UpdateDelegados();
	}
}
