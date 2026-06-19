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
	// Token: 0x0200033C RID: 828
	public class ReactorDeBarkingDeIntensidadAltaV2CoitalProfunda : ReactorDeBarkingBasicoConHandlerDeInteraccionEstimulante
	{
		// Token: 0x060014C5 RID: 5317 RVA: 0x00062CE8 File Offset: 0x00060EE8
		protected override bool EsCalculoEsValido(ICalculoDeInteracionEstimulante calculo)
		{
			if (this.m_ownerCharacterIdleable.enAutoInteraccionCoital)
			{
				return false;
			}
			if (calculo.emocion.reaccion != ReaccionHumana.dolor)
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

		// Token: 0x060014C6 RID: 5318 RVA: 0x00062BAA File Offset: 0x00060DAA
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

		// Token: 0x060014C7 RID: 5319 RVA: 0x00014CB2 File Offset: 0x00012EB2
		protected override int ObtenerIntensidad(ICalculoDeEstimuloConEstado calculoConEstado)
		{
			return 3;
		}

		// Token: 0x060014C8 RID: 5320 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override int ObtenerDuracionMod(ICalculoDeInteracionEstimulante calculoConEstado)
		{
			return 1;
		}

		// Token: 0x060014C9 RID: 5321 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnCalculoReaccionado(ICalculoDeInteracionEstimulante calculoReaccionado, bool reaccionadoResultado)
		{
		}

		// Token: 0x04000ED2 RID: 3794
		public float tiempoMinimoDeSession = 2f;
	}
}
