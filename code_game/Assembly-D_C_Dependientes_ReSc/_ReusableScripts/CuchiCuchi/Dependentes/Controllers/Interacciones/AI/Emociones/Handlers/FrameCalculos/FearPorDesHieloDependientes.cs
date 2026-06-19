using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x02000200 RID: 512
	public class FearPorDesHieloDependientes : FearPorDesHielo
	{
		// Token: 0x06000C9A RID: 3226 RVA: 0x0003AB98 File Offset: 0x00038D98
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_DesHieloPorCambioDeEmocionesDependientes = this.m_deshielo.GetComponentInChildren<DesHieloPorCambioDeEmocionesDependientes>();
			if (this.m_DesHieloPorCambioDeEmocionesDependientes == null)
			{
				throw new ArgumentNullException("m_DesHieloPorCambioDeEmocionesDependientes", "m_DesHieloPorCambioDeEmocionesDependientes null reference.");
			}
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x0003ABD0 File Offset: 0x00038DD0
		protected override void ProcesarCalculosDeDeshielo(ref float generadoNoLimitadoNested, ref float generadoLimitadoNested)
		{
			base.ProcesarCalculosDeDeshielo(ref generadoNoLimitadoNested, ref generadoLimitadoNested);
			FearPorDesHielo.CalculateFear(this, this.m_DesHieloPorCambioDeEmocionesDependientes, this.m_Fear, this.m_modificablesDeInteraccio, this.m_resultadosSegunCalculadores, this.m_calculosEnFrameMasFuerteADebil, this.m_deshielo, this.m_ConsentNecesario, this.m_ConsentCorrupted, this.config, ref generadoNoLimitadoNested, ref generadoLimitadoNested);
		}

		// Token: 0x040008E9 RID: 2281
		private DesHieloPorCambioDeEmocionesDependientes m_DesHieloPorCambioDeEmocionesDependientes;
	}
}
