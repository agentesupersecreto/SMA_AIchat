using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002E4 RID: 740
	public interface ICalculoDeEstimulo
	{
		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x06001074 RID: 4212
		// (set) Token: 0x06001075 RID: 4213
		ICalculadorDeEstimulo producidoPor { get; set; }

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x06001076 RID: 4214
		// (set) Token: 0x06001077 RID: 4215
		ICalculadorDeEstimulo producidoPorSegundario { get; set; }

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06001078 RID: 4216
		// (set) Token: 0x06001079 RID: 4217
		string tag { get; set; }

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x0600107A RID: 4218
		// (set) Token: 0x0600107B RID: 4219
		Emocion emocion { get; set; }

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x0600107C RID: 4220
		// (set) Token: 0x0600107D RID: 4221
		bool causoMaxValue { get; set; }

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x0600107E RID: 4222
		// (set) Token: 0x0600107F RID: 4223
		TipoDeCalculoDeEstimulo tipo { get; set; }

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06001080 RID: 4224
		double prioridad { get; }
	}
}
