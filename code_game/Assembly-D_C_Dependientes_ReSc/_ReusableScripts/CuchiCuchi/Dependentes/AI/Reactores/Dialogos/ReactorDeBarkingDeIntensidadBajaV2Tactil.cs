using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos.Abstract;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos.Clases;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos
{
	// Token: 0x02000342 RID: 834
	public class ReactorDeBarkingDeIntensidadBajaV2Tactil : ReactorDeBarkingBasicoConHandlerDeInteraccionEstimulante
	{
		// Token: 0x060014E4 RID: 5348 RVA: 0x0006307C File Offset: 0x0006127C
		protected override bool EsCalculoEsValido(ICalculoDeInteracionEstimulante calculo)
		{
			if (this.m_ownerCharacterIdleable.enAutoInteraccionCoital)
			{
				return false;
			}
			ICalculadorDeSession calculadorDeSession = calculo.producidoPor as ICalculadorDeSession;
			return calculo.estimuloBasico.tipo == DireccionDeEstimulo.recibida && (calculadorDeSession != null && calculo.emocion.reaccion == ReaccionHumana.decepcion && calculadorDeSession.duracion >= this.tiempoMinimoDeSession && calculo.tipo == TipoDeCalculoDeEstimulo.sesionEnCurso) && calculo is ICalculoDeEstimuloTactil;
		}

		// Token: 0x060014E5 RID: 5349 RVA: 0x00062BAA File Offset: 0x00060DAA
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

		// Token: 0x060014E6 RID: 5350 RVA: 0x00062F0E File Offset: 0x0006110E
		protected override int ObtenerIntensidad(ICalculoDeEstimuloConEstado calculoConEstado)
		{
			return Random.Range(1, 3) * -1;
		}

		// Token: 0x060014E7 RID: 5351 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override int ObtenerDuracionMod(ICalculoDeInteracionEstimulante calculoConEstado)
		{
			return 1;
		}

		// Token: 0x060014E8 RID: 5352 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnCalculoReaccionado(ICalculoDeInteracionEstimulante calculoReaccionado, bool reaccionadoResultado)
		{
		}

		// Token: 0x04000ED7 RID: 3799
		public float tiempoMinimoDeSession = 4f;
	}
}
