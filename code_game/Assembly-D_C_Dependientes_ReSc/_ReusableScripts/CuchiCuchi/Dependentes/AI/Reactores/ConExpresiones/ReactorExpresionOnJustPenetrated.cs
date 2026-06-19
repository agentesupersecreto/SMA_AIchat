using System;
using Assets.Base.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.ConExpresiones
{
	// Token: 0x02000350 RID: 848
	public sealed class ReactorExpresionOnJustPenetrated : ReactorExpresionBase<ICalculoDeEstimuloCoitalHole>
	{
		// Token: 0x06001545 RID: 5445 RVA: 0x00064475 File Offset: 0x00062675
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_IBocaHole = this.GetComponentEnRoot(false);
			if (this.m_IBocaHole == null)
			{
				throw new ArgumentNullException("m_IBocaHole", "m_IBocaHole null reference.");
			}
		}

		// Token: 0x06001546 RID: 5446 RVA: 0x000644A4 File Offset: 0x000626A4
		protected override bool CalculoEsValido(ICalculoDeEstimuloCoitalHole calculo)
		{
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			return (reaccion == ReaccionHumana.placer || reaccion == ReaccionHumana.dolor) && calculo.estimulo.justPenetrated && (calculo.emocion.value.total < 100f || reaccion != ReaccionHumana.placer);
		}

		// Token: 0x06001547 RID: 5447 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x06001548 RID: 5448 RVA: 0x000644FC File Offset: 0x000626FC
		protected override bool ReaccionarCalculoBlokeandoParaReactor(ICalculoDeEstimuloCoitalHole calculo, out float blokearTiempo)
		{
			OjosExpresionController.Tipo? tipo = null;
			TiposDeGestosDeBoca? tiposDeGestosDeBoca = null;
			TipoDeGestoDeCabeza? tipoDeGestoDeCabeza = null;
			TipoDeGestoDeHombro? tipoDeGestoDeHombro = null;
			ControlladorDeGestosFacialesEmocionales.TipoDeExpresion? tipoDeExpresion = null;
			ControlladorDeGestosFacialesEmocionales.TipoDeExpresion? tipoDeExpresion2 = null;
			float num = 1f;
			float num2 = 1f;
			float num3 = 1f;
			float num4 = base.GetPropUsoBocaPorMuecas(1f).OutPow(3f);
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			OjosExpresionController.Tipo tipo3;
			float num6;
			float num7;
			float num8;
			float num9;
			int num10;
			if (reaccion != ReaccionHumana.dolor)
			{
				if (reaccion != ReaccionHumana.placer)
				{
					throw new ArgumentOutOfRangeException(reaccion.ToString());
				}
				Personalidad.Tipo tipo2 = this.m_Personalidad.ObtenerTipoMayorDeCurrentFrame(false, null, true, false);
				if (tipo2 == Personalidad.Tipo.pervertido || tipo2 == Personalidad.Tipo.exhibicionista)
				{
					if (Random.value > 0.333f)
					{
						tiposDeGestosDeBoca = new TiposDeGestosDeBoca?(TiposDeGestosDeBoca.morderLabio);
						num3 = 0.666f;
					}
					else
					{
						tiposDeGestosDeBoca = new TiposDeGestosDeBoca?(TiposDeGestosDeBoca.sorprender);
						num3 = 0.333f;
					}
					tipoDeExpresion = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
					num4 *= 1.5f;
				}
				else
				{
					tiposDeGestosDeBoca = new TiposDeGestosDeBoca?(TiposDeGestosDeBoca.sorprender);
					num3 = 0.333f;
					tipoDeExpresion = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor);
				}
				int num5 = Random.Range(0, 4);
				switch (num5)
				{
				case 0:
					tipo3 = OjosExpresionController.Tipo.guiñarL;
					tipo = new OjosExpresionController.Tipo?(OjosExpresionController.Tipo.guiñarR);
					num = (num * 0.75f).Random(0.5f);
					break;
				case 1:
					tipo3 = OjosExpresionController.Tipo.guiñarR;
					tipo = new OjosExpresionController.Tipo?(OjosExpresionController.Tipo.guiñarL);
					num = (num * 0.75f).Random(0.5f);
					break;
				case 2:
					tipo3 = OjosExpresionController.Tipo.achiquitar;
					break;
				case 3:
					tipo3 = OjosExpresionController.Tipo.agrandar;
					num = 0.75f;
					break;
				default:
					throw new ArgumentOutOfRangeException(num5.ToString());
				}
				tipoDeGestoDeHombro = new TipoDeGestoDeHombro?(TipoDeGestoDeHombro.Nose);
				num6 = 0.333f;
				num7 = 2f;
				tipoDeGestoDeCabeza = new TipoDeGestoDeCabeza?(TipoDeGestoDeCabeza.sisi);
				num8 = 0.66f;
				num9 = 2.5f;
				num10 = this.prioridadParaController * 2;
			}
			else
			{
				tiposDeGestosDeBoca = new TiposDeGestosDeBoca?(TiposDeGestosDeBoca.aplanarApretando);
				tipo3 = OjosExpresionController.Tipo.cerrar;
				num = 1f;
				tipoDeGestoDeHombro = new TipoDeGestoDeHombro?(TipoDeGestoDeHombro.achiquitar);
				num6 = 0.2f;
				num7 = 1.25f;
				tipoDeGestoDeCabeza = new TipoDeGestoDeCabeza?(TipoDeGestoDeCabeza.no);
				num8 = 0.5f;
				num9 = 1.333f;
				tipoDeExpresion = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor);
				num10 = this.prioridadParaController;
			}
			tiposDeGestosDeBoca = ((!this.m_IBocaHole.isPenetrated && base.GetPropUsoBocaPorMuecas(1.75f) > Random.value) ? tiposDeGestosDeBoca : null);
			bool flag = base.GetPropUsoBodyPorMimicas(1.75f) > Random.value;
			float num11 = (blokearTiempo = this.duracion.Random(0.2f));
			float modPorExpresividad = base.GetModPorExpresividad(0.9f, 1f, 0.1f);
			bool flag2 = this.m_OjosExpresionController.Cambiar(tipo3, num10, num11, ControllerPrioridadConfig.prioridad, num * 100f * modPorExpresividad, this.ojosInTiempoMod, this.ojosOutTiempoMod);
			if (tipo != null)
			{
				flag2 = this.m_OjosExpresionController.Cambiar(tipo.Value, num10, num11, ControllerPrioridadConfig.prioridad, num2 * 100f * modPorExpresividad, this.ojosInTiempoMod, this.ojosOutTiempoMod) || flag2;
			}
			if (tiposDeGestosDeBoca != null)
			{
				flag2 = this.m_ControladorDeGestosDeBoca.Gestuar(tiposDeGestosDeBoca.Value, num3 * modPorExpresividad, num10, ControllerPrioridadConfig.prioridad, num11, false, this.NoEstaHalando, this.bocaInVelocityMod, this.bocaOutVelocityMod) || flag2;
			}
			if (flag)
			{
				if (tipoDeGestoDeHombro != null)
				{
					flag2 = this.m_ControladorDeGestosConHombros.Gestuar(tipoDeGestoDeHombro.Value, num6 * modPorExpresividad, num7, ControllerPrioridadConfig.prioridad, true) || flag2;
				}
				if (tipoDeGestoDeCabeza != null)
				{
					flag2 = this.m_ControladorDeGestosConCabeza.Gestuar(tipoDeGestoDeCabeza.Value, num8 * modPorExpresividad, num9, ControllerPrioridadConfig.prioridad, true) || flag2;
				}
			}
			if (tipoDeExpresion != null)
			{
				float num12 = num4 * 0.9f;
				if (tipoDeExpresion2 == null)
				{
					this.m_ControlladorDeGestosFaciales.ExagerarYSuprimirOtros(tipoDeExpresion.Value, num11, 1f, num12, num4 * modPorExpresividad, new float?((float)10));
				}
				else
				{
					this.m_ControlladorDeGestosFaciales.ExagerarYSuprimirOtros(tipoDeExpresion.Value, tipoDeExpresion2.Value, num11, 1f, 1f, num12, num4 * modPorExpresividad, new float?((float)10));
				}
			}
			return flag2;
		}

		// Token: 0x04000F07 RID: 3847
		private IBocaHole m_IBocaHole;
	}
}
