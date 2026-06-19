using System;

namespace Assets._ReusableScripts.UI.Interacciones.Donas.Abstracts
{
	// Token: 0x0200002B RID: 43
	[Obsolete("usar la version para THS")]
	[Serializable]
	public abstract class OpcionesDeDonaCurrentClicked<TEnum> where TEnum : struct
	{
		// Token: 0x0400009B RID: 155
		public string text;

		// Token: 0x0400009C RID: 156
		public int index;

		// Token: 0x0400009D RID: 157
		public TEnum enumerable;
	}
}
