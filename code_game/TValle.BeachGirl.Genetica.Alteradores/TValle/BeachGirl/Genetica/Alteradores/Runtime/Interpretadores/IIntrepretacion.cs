using System;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000050 RID: 80
	public interface IIntrepretacion
	{
		// Token: 0x060003AD RID: 941
		int GetValor(string field);

		// Token: 0x060003AE RID: 942
		void SetValor(string field, int valor);

		// Token: 0x060003AF RID: 943
		int GetValor(string subInterpretacion, string field);

		// Token: 0x060003B0 RID: 944
		void SetValor(string subInterpretacion, string field, int valor);
	}
}
