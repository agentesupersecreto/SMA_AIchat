using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Informers
{
	// Token: 0x020001DD RID: 477
	public class CharCambiosDePoseInformer : CustomUpdatedMonobehaviourBase, ICharPeticionDeCambioDePoseInformer, ICharCambioDePoseInformer
	{
		// Token: 0x06000B64 RID: 2916 RVA: 0x00037CE4 File Offset: 0x00035EE4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Peticiones = this.GetComponentEnRoot(false);
			if (this.m_Peticiones == null)
			{
				throw new ArgumentNullException("m_Peticiones", "m_Peticiones null reference.");
			}
			this.m_Cambios = this.GetComponentEnRoot(false);
			if (this.m_Cambios == null)
			{
				throw new ArgumentNullException("m_Cambios", "m_Cambios null reference.");
			}
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x00037D50 File Offset: 0x00035F50
		void ICharCambioDePoseInformer.EstimulosRecibidosDe(Character productor, ICharCambioDePoseInformerInstanceGetter<EstimuloPorCambiarPose> instanciasGetter, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose> result)
		{
			if (productor == null)
			{
				return;
			}
			if (result == null)
			{
				throw new ArgumentNullException("result", "result null reference.");
			}
			if (instanciasGetter == null)
			{
				throw new ArgumentNullException("instanciasGetter", "instanciasGetter null reference.");
			}
			if (this.m_Cambios == null || !this.m_Cambios.isActiveAndEnabled)
			{
				return;
			}
			CharCambiosDePoseInformer.LoadEstimulosDe(this.m_Cambios.siendoCambiadoEjecutarPosePorCharacterConManos, productor, instanciasGetter, result);
			CharCambiosDePoseInformer.LoadEstimulosDe(this.m_Cambios.siendoCambiadoEjecutarPosePorCharacterConVoz, productor, instanciasGetter, result);
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x00037DD0 File Offset: 0x00035FD0
		private static void LoadEstimulosDe(SiendoCambiadoDePosePorCharacter<CambiarEstadoDeInteraccionesConAI> estimuladoPor, Character productor, ICharCambioDePoseInformerInstanceGetter<EstimuloPorCambiarPose> instanciasGetter, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose> result)
		{
			EstimuloPorCambiarPose estimuloPorCambiarPose;
			if (estimuladoPor == null || !estimuladoPor.ContieneEstimuloV3<EstimuloPorCambiarPose>(productor, out estimuloPorCambiarPose))
			{
				return;
			}
			ParteQuePuedeEstimular parteQuePuedeEstimular = productor.ParteQuePuedeEstimularDeTransform(estimuloPorCambiarPose.transformEstimulante);
			EstimuloPorCambiarPose estimuloPorCambiarPose2;
			if (result.TryGetValue(parteQuePuedeEstimular, out estimuloPorCambiarPose2))
			{
				estimuloPorCambiarPose2.AddPartesEstimuladas(estimuloPorCambiarPose.partesDelCuerpoHumanoEstimuladas);
				return;
			}
			EstimuloPorCambiarPose estimuloPorCambiarPose3 = instanciasGetter();
			estimuloPorCambiarPose.CopiarA(estimuloPorCambiarPose3, false);
			result.Add(parteQuePuedeEstimular, estimuloPorCambiarPose3);
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x00037E28 File Offset: 0x00036028
		void ICharPeticionDeCambioDePoseInformer.EstimulosRecibidosDe(Character productor, ICharCambioDePoseInformerInstanceGetter<EstimuloPorCambiarPose> instanciasGetter, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose> result)
		{
			if (productor == null)
			{
				return;
			}
			if (result == null)
			{
				throw new ArgumentNullException("result", "result null reference.");
			}
			if (instanciasGetter == null)
			{
				throw new ArgumentNullException("instanciasGetter", "instanciasGetter null reference.");
			}
			if (this.m_Peticiones == null || !this.m_Peticiones.isActiveAndEnabled)
			{
				return;
			}
			EstimuloPorCambiarPose estimuloPorCambiarPose;
			if (this.m_Peticiones.siendoPedidoEjecutarPosePorCharacter == null || !this.m_Peticiones.siendoPedidoEjecutarPosePorCharacter.ContieneEstimuloV3<EstimuloPorCambiarPose>(productor, out estimuloPorCambiarPose))
			{
				return;
			}
			ParteQuePuedeEstimular parteQuePuedeEstimular = ParteQuePuedeEstimular.boca;
			EstimuloPorCambiarPose estimuloPorCambiarPose2;
			if (result.TryGetValue(parteQuePuedeEstimular, out estimuloPorCambiarPose2))
			{
				estimuloPorCambiarPose2.AddPartesEstimuladas(estimuloPorCambiarPose.partesDelCuerpoHumanoEstimuladas);
				return;
			}
			EstimuloPorCambiarPose estimuloPorCambiarPose3 = instanciasGetter();
			estimuloPorCambiarPose.CopiarA(estimuloPorCambiarPose3, false);
			result.Add(parteQuePuedeEstimular, estimuloPorCambiarPose3);
		}

		// Token: 0x0400088A RID: 2186
		private PeticionEstadoDeInteraccionesConAI m_Peticiones;

		// Token: 0x0400088B RID: 2187
		private CambiarEstadoDeInteraccionesConAI m_Cambios;
	}
}
