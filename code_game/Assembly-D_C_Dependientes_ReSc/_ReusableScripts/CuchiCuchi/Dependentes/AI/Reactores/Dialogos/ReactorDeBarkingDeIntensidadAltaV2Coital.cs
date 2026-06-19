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
	// Token: 0x0200033A RID: 826
	public class ReactorDeBarkingDeIntensidadAltaV2Coital : ReactorDeBarkingBasicoConHandlerDeInteraccionEstimulante
	{
		// Token: 0x060014B9 RID: 5305 RVA: 0x00062B20 File Offset: 0x00060D20
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

		// Token: 0x060014BA RID: 5306 RVA: 0x00062BAA File Offset: 0x00060DAA
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

		// Token: 0x060014BB RID: 5307 RVA: 0x00062BEA File Offset: 0x00060DEA
		protected override int ObtenerIntensidad(ICalculoDeEstimuloConEstado calculoConEstado)
		{
			return Random.Range(1, 3);
		}

		// Token: 0x060014BC RID: 5308 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override int ObtenerDuracionMod(ICalculoDeInteracionEstimulante calculoConEstado)
		{
			return 1;
		}

		// Token: 0x060014BD RID: 5309 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnCalculoReaccionado(ICalculoDeInteracionEstimulante calculoReaccionado, bool reaccionadoResultado)
		{
		}

		// Token: 0x04000ED0 RID: 3792
		public float tiempoMinimoDeSession = 2f;
	}
}
