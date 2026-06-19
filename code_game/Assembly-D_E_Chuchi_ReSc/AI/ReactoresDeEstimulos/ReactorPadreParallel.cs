using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x020003AC RID: 940
	public class ReactorPadreParallel : ReactorPadreDummy
	{
		// Token: 0x060014A0 RID: 5280 RVA: 0x00058C08 File Offset: 0x00056E08
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.padreConfig.dejarDeReaccionarHijosSiAlgunHijoReacciona = false;
		}

		// Token: 0x060014A1 RID: 5281 RVA: 0x00058C1C File Offset: 0x00056E1C
		protected override void OnValidateUnityEvent()
		{
			base.OnValidateUnityEvent();
			this.padreConfig.dejarDeReaccionarHijosSiAlgunHijoReacciona = false;
		}

		// Token: 0x060014A2 RID: 5282 RVA: 0x00058C30 File Offset: 0x00056E30
		protected override bool ArgumentoEsValido(object arg)
		{
			this.padreConfig.dejarDeReaccionarHijosSiAlgunHijoReacciona = false;
			return true;
		}
	}
}
