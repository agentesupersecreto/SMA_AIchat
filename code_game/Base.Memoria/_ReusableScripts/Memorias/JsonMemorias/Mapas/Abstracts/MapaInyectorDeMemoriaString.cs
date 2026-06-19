using System;

namespace Assets._ReusableScripts.Memorias.JsonMemorias.Mapas.Abstracts
{
	// Token: 0x02000012 RID: 18
	public abstract class MapaInyectorDeMemoriaString : AplicableScriptable
	{
		// Token: 0x06000098 RID: 152 RVA: 0x00003314 File Offset: 0x00001514
		public void OnLoad()
		{
			this.onLoading();
		}

		// Token: 0x06000099 RID: 153
		protected abstract void onLoading();

		// Token: 0x0400002F RID: 47
		public StringKeyStringValueDictionary data = new StringKeyStringValueDictionary();
	}
}
