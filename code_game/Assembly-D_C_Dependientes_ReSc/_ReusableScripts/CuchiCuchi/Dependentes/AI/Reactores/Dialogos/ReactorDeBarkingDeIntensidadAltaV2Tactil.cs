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
	// Token: 0x0200033D RID: 829
	public class ReactorDeBarkingDeIntensidadAltaV2Tactil : ReactorDeBarkingBasicoConHandlerDeInteraccionEstimulante
	{
		// Token: 0x060014CB RID: 5323 RVA: 0x00062D88 File Offset: 0x00060F88
		protected override bool EsCalculoEsValido(ICalculoDeInteracionEstimulante calculo)
		{
			if (this.m_ownerCharacterIdleable.enAutoInteraccionCoital)
			{
				return false;
			}
			ICalculadorDeSession calculadorDeSession = calculo.producidoPor as ICalculadorDeSession;
			if (calculadorDeSession == null)
			{
				if (this.debugLogConHandler)
				{
					Debug.Log("calculo No es valido: no es session", this);
				}
				return false;
			}
			if (!(calculo is ICalculoDeEstimuloTactil))
			{
				if (this.debugLogConHandler)
				{
					Debug.Log("calculo No es valido: calculo no es tactil", this);
				}
				return false;
			}
			if (calculo.emocion.reaccion != ReaccionHumana.dolor)
			{
				if (this.debugLogConHandler)
				{
					Debug.Log("calculo No es valido: no es dolor", this);
				}
				return false;
			}
			if (calculadorDeSession.duracion < this.tiempoMinimoDeSession)
			{
				if (this.debugLogConHandler)
				{
					Debug.Log("calculo No es valido: duracion muy corta", this);
				}
				return false;
			}
			if (calculo.tipo != TipoDeCalculoDeEstimulo.sesionEnCurso)
			{
				if (this.debugLogConHandler)
				{
					Debug.Log("calculo No es valido: no es session en curso", this);
				}
				return false;
			}
			if (calculo.estimuloBasico.tipo != DireccionDeEstimulo.recibida)
			{
				return false;
			}
			if (this.debugLogConHandler)
			{
				Debug.Log("calculo fue valido", this);
			}
			return true;
		}

		// Token: 0x060014CC RID: 5324 RVA: 0x00062BAA File Offset: 0x00060DAA
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

		// Token: 0x060014CD RID: 5325 RVA: 0x00062BEA File Offset: 0x00060DEA
		protected override int ObtenerIntensidad(ICalculoDeEstimuloConEstado calculoConEstado)
		{
			return Random.Range(1, 3);
		}

		// Token: 0x060014CE RID: 5326 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override int ObtenerDuracionMod(ICalculoDeInteracionEstimulante calculoConEstado)
		{
			return 1;
		}

		// Token: 0x060014CF RID: 5327 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnCalculoReaccionado(ICalculoDeInteracionEstimulante calculoReaccionado, bool reaccionadoResultado)
		{
		}

		// Token: 0x04000ED3 RID: 3795
		public float tiempoMinimoDeSession = 2f;
	}
}
