using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos.Abstract;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos.Clases;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos
{
	// Token: 0x02000341 RID: 833
	public class ReactorDeBarkingDeIntensidadBajaV2CoitalProfunda : ReactorDeBarkingBasicoConHandlerDeInteraccionEstimulante
	{
		// Token: 0x060014DE RID: 5342 RVA: 0x00062FD4 File Offset: 0x000611D4
		protected override bool EsCalculoEsValido(ICalculoDeInteracionEstimulante calculo)
		{
			if (this.m_ownerCharacterIdleable.enAutoInteraccionCoital)
			{
				return false;
			}
			if (calculo.emocion.reaccion != ReaccionHumana.decepcion)
			{
				return false;
			}
			ICalculoDeEstimuloCoitalHoleProfundaV2 calculoDeEstimuloCoitalHoleProfundaV = calculo as ICalculoDeEstimuloCoitalHoleProfundaV2;
			ICalculadorDeSession calculadorDeSession = calculo.producidoPor as ICalculadorDeSession;
			if (calculoDeEstimuloCoitalHoleProfundaV == null || calculadorDeSession == null)
			{
				return false;
			}
			if (calculo.tipo != TipoDeCalculoDeEstimulo.sesionEnCurso)
			{
				return false;
			}
			if (calculo.estimuloBasico.tipo != DireccionDeEstimulo.recibida)
			{
				return false;
			}
			UmbralBasico.Estado estado;
			calculoDeEstimuloCoitalHoleProfundaV.GetEstadoProfundidadReference(out estado);
			return estado.estimulacionGeneradaTotal > 0f && calculadorDeSession.duracion >= this.tiempoMinimoDeSession;
		}

		// Token: 0x060014DF RID: 5343 RVA: 0x00062BAA File Offset: 0x00060DAA
		protected override void LoadDialogosHandler(out object productor, List<DialogoInfo> resultado, ICalculoDeEstimulo calculo, Localizacion cultura, object lastProductor, ReactorDeBarkingHandler handler)
		{
			productor = null;
			if (!Singleton<DialogosDePersonalidadDeIntesidad>.IsInScene)
			{
				return;
			}
			productor = Singleton<DialogosDePersonalidadDeIntesidad>.instance;
			Singleton<DialogosDePersonalidadDeIntesidad>.instance.Obtener(resultado, handler.personalidad.currentPersonalidad.personalidad.rasgos, cultura, calculo, handler.last, null);
		}

		// Token: 0x060014E0 RID: 5344 RVA: 0x00063062 File Offset: 0x00061262
		protected override int ObtenerIntensidad(ICalculoDeEstimuloConEstado calculoConEstado)
		{
			return -3;
		}

		// Token: 0x060014E1 RID: 5345 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override int ObtenerDuracionMod(ICalculoDeInteracionEstimulante calculoConEstado)
		{
			return 1;
		}

		// Token: 0x060014E2 RID: 5346 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnCalculoReaccionado(ICalculoDeInteracionEstimulante calculoReaccionado, bool reaccionadoResultado)
		{
		}

		// Token: 0x04000ED6 RID: 3798
		public float tiempoMinimoDeSession = 4f;
	}
}
