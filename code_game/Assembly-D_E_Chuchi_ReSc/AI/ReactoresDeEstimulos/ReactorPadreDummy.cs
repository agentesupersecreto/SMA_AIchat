using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x020003AB RID: 939
	public class ReactorPadreDummy : ReactorPadreSinLogica
	{
		// Token: 0x0600149D RID: 5277 RVA: 0x00058C00 File Offset: 0x00056E00
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
		}

		// Token: 0x0600149E RID: 5278 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool ArgumentoEsValido(object arg)
		{
			return true;
		}
	}
}
