using System;

namespace Assets
{
	// Token: 0x0200000F RID: 15
	public interface IAtadurasDePuppetAI
	{
		// Token: 0x06000057 RID: 87
		void Forzar(TipoDeAtaduraDePuppet tipo, float weigth);

		// Token: 0x06000058 RID: 88
		void DejarDeForzar(TipoDeAtaduraDePuppet tipo);

		// Token: 0x06000059 RID: 89
		void Ignorar(TipoDeAtaduraDePuppet tipo);

		// Token: 0x0600005A RID: 90
		void DejarDeIgnorar(TipoDeAtaduraDePuppet tipo);

		// Token: 0x0600005B RID: 91
		[Obsolete("hace conflicto con interacciones segundarias", true)]
		void Forzar(TipoDeMuscleAlQueSePuedeAtar from, TipoDeMuscleAlQueSePuedeAtar to);

		// Token: 0x0600005C RID: 92
		[Obsolete("hace conflicto con interacciones segundarias", true)]
		void DejarDeForzar(TipoDeMuscleAlQueSePuedeAtar tipo);
	}
}
