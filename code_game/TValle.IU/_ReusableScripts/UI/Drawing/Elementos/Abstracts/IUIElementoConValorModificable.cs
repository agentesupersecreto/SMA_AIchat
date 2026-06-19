using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000A8 RID: 168
	public interface IUIElementoConValorModificable : IUIElemento
	{
		// Token: 0x06000519 RID: 1305
		float GetValorAsModZeroToOne();

		// Token: 0x0600051A RID: 1306
		void SetValorAsModZeroToOne(float valorZeroToOne, bool silenced);
	}
}
