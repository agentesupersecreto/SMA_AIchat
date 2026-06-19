using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Interacciones
{
	// Token: 0x0200030E RID: 782
	public abstract class ReacctorDeInteracciones<TCalculo> : ReactorACalculoDeEstimulo<TCalculo> where TCalculo : class, ICalculoDeInteracionEstimulante
	{
		// Token: 0x060013B9 RID: 5049 RVA: 0x0005C620 File Offset: 0x0005A820
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_InteractionEffectorController = this.GetComponentEnCharacter(false);
			this.m_InteraccionesBasicasDeFemale = this.GetComponentEnCharacter(false);
			if (this.m_InteractionEffectorController == null)
			{
				throw new ArgumentNullException("m_InteractionEffectorController", "m_InteractionEffectorController null reference.");
			}
			if (this.m_InteraccionesBasicasDeFemale == null)
			{
				throw new ArgumentNullException("m_InteraccionesBasicasDeFemale", "m_InteraccionesBasicasDeFemale null reference.");
			}
			this.m_manipulable = this.GetComponentEnRoot(false);
			if (this.m_manipulable == null)
			{
				throw new ArgumentNullException("m_manipulable", "m_manipulable null reference.");
			}
		}

		// Token: 0x060013BA RID: 5050 RVA: 0x0005C6A8 File Offset: 0x0005A8A8
		protected override bool CalculoEsValido(TCalculo calculo)
		{
			return !this.m_manipulable.siendoManipulado;
		}

		// Token: 0x04000E42 RID: 3650
		[Obsolete("Quitar de aca", true)]
		[NonSerialized]
		public ReacctorDeInteraccionesConfig interaccionesConfig = new ReacctorDeInteraccionesConfig();

		// Token: 0x04000E43 RID: 3651
		protected IInteractionController m_InteractionEffectorController;

		// Token: 0x04000E44 RID: 3652
		protected IPuppetManipulable m_manipulable;

		// Token: 0x04000E45 RID: 3653
		protected InteraccionesBasicasDeFemale m_InteraccionesBasicasDeFemale;
	}
}
