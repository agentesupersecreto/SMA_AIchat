using System;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000A9 RID: 169
	[Obsolete("", true)]
	public interface IUIElementoConValorDeLectura : IUIElemento
	{
		// Token: 0x0600051B RID: 1307
		void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem);

		// Token: 0x0600051C RID: 1308
		object GetValor();
	}
}
