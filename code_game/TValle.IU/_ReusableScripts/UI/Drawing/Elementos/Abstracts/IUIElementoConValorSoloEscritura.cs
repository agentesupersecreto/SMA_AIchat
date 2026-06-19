using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000AB RID: 171
	public interface IUIElementoConValorSoloEscritura : IUIElemento
	{
		// Token: 0x0600051E RID: 1310
		void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem);

		// Token: 0x0600051F RID: 1311
		void SetValor(object valor, bool silenced);
	}
}
