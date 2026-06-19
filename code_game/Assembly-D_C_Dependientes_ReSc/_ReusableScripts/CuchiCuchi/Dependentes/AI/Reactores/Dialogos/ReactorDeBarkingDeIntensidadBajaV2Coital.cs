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
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos
{
	// Token: 0x0200033F RID: 831
	public class ReactorDeBarkingDeIntensidadBajaV2Coital : ReactorDeBarkingBasicoConHandlerDeInteraccionEstimulante
	{
		// Token: 0x060014D2 RID: 5330 RVA: 0x00062E80 File Offset: 0x00061080
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
			ICalculoDeEstimuloCoitalHoleVeloz calculoDeEstimuloCoitalHoleVeloz = calculo as ICalculoDeEstimuloCoitalHoleVeloz;
			ICalculadorDeSession calculadorDeSession = calculo.producidoPor as ICalculadorDeSession;
			if (calculoDeEstimuloCoitalHoleVeloz == null || calculadorDeSession == null)
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
			calculoDeEstimuloCoitalHoleVeloz.GetEstadoVelocidadReference(out estado);
			return estado.estimulacionGeneradaTotal > 0f && calculadorDeSession.duracion >= this.tiempoMinimoDeSession;
		}

		// Token: 0x060014D3 RID: 5331 RVA: 0x00062BAA File Offset: 0x00060DAA
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

		// Token: 0x060014D4 RID: 5332 RVA: 0x00062F0E File Offset: 0x0006110E
		protected override int ObtenerIntensidad(ICalculoDeEstimuloConEstado calculoConEstado)
		{
			return Random.Range(1, 3) * -1;
		}

		// Token: 0x060014D5 RID: 5333 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override int ObtenerDuracionMod(ICalculoDeInteracionEstimulante calculoConEstado)
		{
			return 1;
		}

		// Token: 0x060014D6 RID: 5334 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnCalculoReaccionado(ICalculoDeInteracionEstimulante calculoReaccionado, bool reaccionadoResultado)
		{
		}

		// Token: 0x04000ED4 RID: 3796
		public float tiempoMinimoDeSession = 4f;
	}
}
