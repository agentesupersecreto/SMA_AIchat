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
	// Token: 0x02000340 RID: 832
	public class ReactorDeBarkingDeIntensidadBajaV2CoitalAnchura : ReactorDeBarkingBasicoConHandlerDeInteraccionEstimulante
	{
		// Token: 0x060014D8 RID: 5336 RVA: 0x00062F2C File Offset: 0x0006112C
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
			ICalculoDeEstimuloCoitalHoleAncha calculoDeEstimuloCoitalHoleAncha = calculo as ICalculoDeEstimuloCoitalHoleAncha;
			ICalculadorDeSession calculadorDeSession = calculo.producidoPor as ICalculadorDeSession;
			if (calculoDeEstimuloCoitalHoleAncha == null || calculadorDeSession == null)
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
			calculoDeEstimuloCoitalHoleAncha.GetEstadoAnchuraReference(out estado);
			return estado.estimulacionGeneradaTotal > 0f && calculadorDeSession.duracion >= this.tiempoMinimoDeSession;
		}

		// Token: 0x060014D9 RID: 5337 RVA: 0x00062C92 File Offset: 0x00060E92
		protected override void LoadDialogosHandler(out object productor, List<DialogoInfo> resultado, ICalculoDeEstimulo calculo, Localizacion cultura, object lastProductor, ReactorDeBarkingHandler handler)
		{
			productor = null;
			if (!Singleton<DialogosDePersonalidadDeIntesidadAnchura>.IsInScene)
			{
				return;
			}
			productor = Singleton<DialogosDePersonalidadDeIntesidadAnchura>.instance;
			Singleton<DialogosDePersonalidadDeIntesidadAnchura>.instance.Obtener(resultado, handler.personalidad.currentPersonalidad.personalidad.rasgos, cultura, calculo, handler.last, null);
		}

		// Token: 0x060014DA RID: 5338 RVA: 0x00062FBA File Offset: 0x000611BA
		protected override int ObtenerIntensidad(ICalculoDeEstimuloConEstado calculoConEstado)
		{
			return -4;
		}

		// Token: 0x060014DB RID: 5339 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override int ObtenerDuracionMod(ICalculoDeInteracionEstimulante calculoConEstado)
		{
			return 1;
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnCalculoReaccionado(ICalculoDeInteracionEstimulante calculoReaccionado, bool reaccionadoResultado)
		{
		}

		// Token: 0x04000ED5 RID: 3797
		public float tiempoMinimoDeSession = 4f;
	}
}
