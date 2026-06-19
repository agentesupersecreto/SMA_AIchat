using System;

namespace Assets
{
	// Token: 0x02000005 RID: 5
	public interface IConfiguracionParaTarget<Ttarget>
	{
		// Token: 0x0600000D RID: 13
		void Aplicar(ref Ttarget target);

		// Token: 0x0600000E RID: 14
		bool Validar();
	}
}
