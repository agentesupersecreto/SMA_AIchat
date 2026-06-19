using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x020003AD RID: 941
	public class ReactorPadreSelector : ReactorPadreDummy
	{
		// Token: 0x060014A4 RID: 5284 RVA: 0x00058C3F File Offset: 0x00056E3F
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.padreConfig.dejarDeReaccionarHijosSiAlgunHijoReacciona = true;
		}

		// Token: 0x060014A5 RID: 5285 RVA: 0x00058C53 File Offset: 0x00056E53
		protected override void OnValidateUnityEvent()
		{
			base.OnValidateUnityEvent();
			this.padreConfig.dejarDeReaccionarHijosSiAlgunHijoReacciona = true;
		}

		// Token: 0x060014A6 RID: 5286 RVA: 0x00058C67 File Offset: 0x00056E67
		protected override bool ArgumentoEsValido(object arg)
		{
			this.padreConfig.dejarDeReaccionarHijosSiAlgunHijoReacciona = true;
			return true;
		}
	}
}
