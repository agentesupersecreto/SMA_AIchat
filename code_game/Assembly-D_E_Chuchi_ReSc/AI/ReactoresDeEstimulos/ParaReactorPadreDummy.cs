using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x020003A5 RID: 933
	public class ParaReactorPadreDummy : ReactorPadreDummy
	{
		// Token: 0x0600148B RID: 5259 RVA: 0x0005883B File Offset: 0x00056A3B
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.prioridad = ReactorSegundario.Prioridad.muyBaja;
			this.baseConfig.prioridadEspecifica = int.MinValue;
		}
	}
}
