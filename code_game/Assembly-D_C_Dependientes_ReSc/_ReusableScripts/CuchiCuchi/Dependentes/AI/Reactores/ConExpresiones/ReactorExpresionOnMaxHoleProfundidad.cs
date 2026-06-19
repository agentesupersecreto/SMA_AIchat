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
	// Token: 0x02000351 RID: 849
	public sealed class ReactorExpresionOnMaxHoleProfundidad : ReactorExpresionBase<ICalculoDeEstimuloCoitalHole>
	{
		// Token: 0x0600154A RID: 5450 RVA: 0x00064917 File Offset: 0x00062B17
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_IBocaHole = this.GetComponentEnRoot(false);
			if (this.m_IBocaHole == null)
			{
				throw new ArgumentNullException("m_IBocaHole", "m_IBocaHole null reference.");
			}
		}

		// Token: 0x0600154B RID: 5451 RVA: 0x00064944 File Offset: 0x00062B44
		protected override bool CalculoEsValido(ICalculoDeEstimuloCoitalHole calculo)
		{
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			return (reaccion == ReaccionHumana.placer || reaccion == ReaccionHumana.dolor) && calculo.estimulo.holePenetrado.CercaDeHardPoints() && (calculo.emocion.value.total < 100f || reaccion != ReaccionHumana.placer);
		}

		// Token: 0x0600154C RID: 5452 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x0600154D RID: 5453 RVA: 0x000649A0 File Offset: 0x00062BA0
		protected override bool ReaccionarCalculoBlokeandoParaReactor(ICalculoDeEstimuloCoitalHole calculo, out float blokearTiempo)
		{
			TiposDeGestosDeBoca? tiposDeGestosDeBoca = null;
			TipoDeGestoDeCabeza? tipoDeGestoDeCabeza = null;
			TipoDeGestoDeHombro? tipoDeGestoDeHombro = null;
			ControlladorDeGestosFacialesEmocionales.TipoDeExpresion? tipoDeExpresion = null;
			float num = 1f;
			float num2 = 1f;
			float num3 = base.GetPropUsoBocaPorMuecas(1f).OutPow(3f);
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			OjosExpresionController.Tipo tipo2;
			float num4;
			float num5;
			float num6;
			float num7;
			int num8;
			if (reaccion != ReaccionHumana.dolor)
			{
				if (reaccion != ReaccionHumana.placer)
				{
					throw new ArgumentOutOfRangeException(reaccion.ToString());
				}
				Personalidad.Tipo tipo = this.m_Personalidad.ObtenerTipoMayorDeCurrentFrame(false, null, true, false);
				if (tipo == Personalidad.Tipo.pervertido || tipo == Personalidad.Tipo.exhibicionista)
				{
					tipo2 = OjosExpresionController.Tipo.achiquitar;
					tiposDeGestosDeBoca = new TiposDeGestosDeBoca?(TiposDeGestosDeBoca.sorprender);
					num2 = 0.333f;
					tipoDeExpresion = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
					num3 *= 0.9f;
				}
				else
				{
					tiposDeGestosDeBoca = new TiposDeGestosDeBoca?(TiposDeGestosDeBoca.morderLabio);
					tipo2 = OjosExpresionController.Tipo.agrandar;
					num = 0.6f;
					tipoDeExpresion = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor);
				}
				tipoDeGestoDeHombro = new TipoDeGestoDeHombro?(TipoDeGestoDeHombro.Nose);
				num4 = 0.333f;
				num5 = 2f;
				tipoDeGestoDeCabeza = new TipoDeGestoDeCabeza?(TipoDeGestoDeCabeza.sisi);
				num6 = 0.66f;
				num7 = 2.5f;
				num8 = this.prioridadParaController * 2;
			}
			else
			{
				tiposDeGestosDeBoca = new TiposDeGestosDeBoca?(TiposDeGestosDeBoca.aplanarApretando);
				tipo2 = OjosExpresionController.Tipo.cerrar;
				num = 1f;
				tipoDeGestoDeHombro = new TipoDeGestoDeHombro?(TipoDeGestoDeHombro.achiquitar);
				num4 = 0.2f;
				num5 = 1.25f;
				tipoDeGestoDeCabeza = new TipoDeGestoDeCabeza?(TipoDeGestoDeCabeza.no);
				num6 = 0.5f;
				num7 = 1.333f;
				tipoDeExpresion = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor);
				num8 = this.prioridadParaController;
			}
			tiposDeGestosDeBoca = ((!this.m_IBocaHole.isPenetrated && base.GetPropUsoBocaPorMuecas(1.25f) > Random.value) ? tiposDeGestosDeBoca : null);
			bool flag = base.GetPropUsoBodyPorMimicas(1f) > Random.value;
			float num9 = (blokearTiempo = this.duracion.Random(0.2f));
			float modPorExpresividad = base.GetModPorExpresividad(1f, 1f, 0.1f);
			bool flag2 = this.m_OjosExpresionController.Cambiar(tipo2, num8, num9, ControllerPrioridadConfig.prioridad, num * 100f * modPorExpresividad, this.ojosInTiempoMod, this.ojosOutTiempoMod);
			if (tiposDeGestosDeBoca != null)
			{
				flag2 = this.m_ControladorDeGestosDeBoca.Gestuar(tiposDeGestosDeBoca.Value, num2 * modPorExpresividad, num8, ControllerPrioridadConfig.prioridad, num9, false, this.NoEstaHalando, this.bocaInVelocityMod, this.bocaOutVelocityMod) || flag2;
			}
			if (flag)
			{
				if (tipoDeGestoDeHombro != null)
				{
					flag2 = this.m_ControladorDeGestosConHombros.Gestuar(tipoDeGestoDeHombro.Value, num4 * modPorExpresividad, num5, ControllerPrioridadConfig.prioridad, true) || flag2;
				}
				if (tipoDeGestoDeCabeza != null)
				{
					flag2 = this.m_ControladorDeGestosConCabeza.Gestuar(tipoDeGestoDeCabeza.Value, num6 * modPorExpresividad, num7, ControllerPrioridadConfig.prioridad, true) || flag2;
				}
			}
			if (tipoDeExpresion != null)
			{
				float num10 = num3 * 0.9f;
				if (tipoDeExpresion.Value == ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer)
				{
					this.m_ControlladorDeGestosFaciales.DejarDeSuprimirTipoDeExpresion(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
					this.m_ControlladorDeGestosFaciales.DejarDeExagerarTipoDeExpresion(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor);
					this.m_ControlladorDeGestosFaciales.ExagerarTipoDeExpresionPor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, num9, 1f, num3 * modPorExpresividad);
					this.m_ControlladorDeGestosFaciales.SuprimirTipoDeExpresionPor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, num9, num10);
				}
				else
				{
					if (tipoDeExpresion.Value != ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor)
					{
						throw new ArgumentOutOfRangeException();
					}
					this.m_ControlladorDeGestosFaciales.DejarDeSuprimirTipoDeExpresion(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor);
					this.m_ControlladorDeGestosFaciales.DejarDeExagerarTipoDeExpresion(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
					this.m_ControlladorDeGestosFaciales.ExagerarTipoDeExpresionPor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, num9, 1f, num3 * modPorExpresividad);
					this.m_ControlladorDeGestosFaciales.SuprimirTipoDeExpresionPor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, num9, num10);
				}
				this.m_ControlladorDeGestosFaciales.SuprimirTipoDeExpresionPor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, num9, num10);
				this.m_ControlladorDeGestosFaciales.SuprimirTipoDeExpresionPor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, num9, num10);
			}
			return flag2;
		}

		// Token: 0x04000F08 RID: 3848
		private IBocaHole m_IBocaHole;
	}
}
