using System;
using Assets.Base.BeachGirl.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Runtime.Sonidos.Characters;
using Assets.TValle.BeachGirl.Runtime.Sonidos.Characters.Globales;
using Assets.TValle.BeachGirl.Runtime.Sonidos.Characters.Mapas;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Sonido.Expresiones;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.ConExpresiones
{
	// Token: 0x02000352 RID: 850
	public sealed class ReactorExpresionOnSpot : ReactorExpresionBase<ICalculoDeEstimuloConEstado>
	{
		// Token: 0x0600154F RID: 5455 RVA: 0x00064D24 File Offset: 0x00062F24
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_IBocaHole = this.GetComponentEnRoot(false);
			if (this.m_IBocaHole == null)
			{
				throw new ArgumentNullException("m_IBocaHole", "m_IBocaHole null reference.");
			}
			this.m_CharacterPitchDeExpulsiones = this.GetComponentEnRoot(false);
			if (this.m_CharacterPitchDeExpulsiones == null)
			{
				throw new ArgumentNullException("m_CharacterPitchDeExpulsiones", "m_CharacterPitchDeExpulsiones null reference.");
			}
			this.m_ControlladorDeExpresionesVerbalesConSonido = this.GetComponentEnRoot(false);
			if (this.m_ControlladorDeExpresionesVerbalesConSonido == null)
			{
				throw new ArgumentNullException("m_ControlladorDeExpresionesVerbalesConSonido", "m_ControlladorDeExpresionesVerbalesConSonido null reference.");
			}
			this.m_emos = this.GetComponentEnRoot(false);
			if (this.m_emos == null)
			{
				throw new ArgumentNullException("m_emos", "m_emos null reference.");
			}
		}

		// Token: 0x06001550 RID: 5456 RVA: 0x00064DE0 File Offset: 0x00062FE0
		protected override bool CalculoEsValido(ICalculoDeEstimuloConEstado calculo)
		{
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			if (reaccion != ReaccionHumana.placer && reaccion != ReaccionHumana.dolor)
			{
				return false;
			}
			ICalculoDeInteracionEstimulanteConEstado calculoDeInteracionEstimulanteConEstado = calculo as ICalculoDeInteracionEstimulanteConEstado;
			if (calculoDeInteracionEstimulanteConEstado != null)
			{
				TipoDeEstimulo tipoDeEstimulo = calculoDeInteracionEstimulanteConEstado.estimuloBasico.tipoDeEstimulo;
				if (tipoDeEstimulo != TipoDeEstimulo.tactil && tipoDeEstimulo != TipoDeEstimulo.coital)
				{
					return false;
				}
				if (reaccion == ReaccionHumana.dolor && calculoDeInteracionEstimulanteConEstado.estimuloBasico.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor).EsBrazos() && this.m_FemaleCharacterIdleable.enAutoInteraccionCoitalHands)
				{
					return false;
				}
			}
			float total = calculo.emocion.value.total;
			if (total >= 100f && reaccion == ReaccionHumana.placer)
			{
				return false;
			}
			UmbralBasico.Estado estado;
			ReactorSegundario.GetEstadoConMasEstimuloTotal(calculo, out estado);
			if (reaccion != ReaccionHumana.placer)
			{
				return reaccion != ReaccionHumana.dolor || (estado.estimulacionGeneradaTotal > 0f && estado.severidadConPost >= this.severidadEnDolorParaSerValido);
			}
			if (estado.estimulacionGeneradaTotal <= 0f)
			{
				return false;
			}
			float num = total;
			if (num > this.placerParaValidoFuera)
			{
				return true;
			}
			if (num > this.placerParaValidoCercano)
			{
				return estado.spotScore == SpotScore.enSpot || estado.spotScore == SpotScore.casiEnSpot || estado.spotScore == SpotScore.cercano || estado.severidadConPost >= 0.666f;
			}
			if (num > this.placerParaValidoCasiEnSpot)
			{
				return estado.spotScore == SpotScore.enSpot || estado.spotScore == SpotScore.casiEnSpot || estado.severidadConPost >= 1f;
			}
			return num >= this.placerParaValidoEnSpot && estado.spotScore == SpotScore.enSpot;
		}

		// Token: 0x06001551 RID: 5457 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloConEstado calculo)
		{
			return 1f;
		}

		// Token: 0x06001552 RID: 5458 RVA: 0x00064F4C File Offset: 0x0006314C
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloConEstado calculo)
		{
			float num = base.ProbabilidadPorSegundoModificadorParaCalculo(calculo) * ((calculo.emocion.reaccion == ReaccionHumana.dolor) ? 1.5f : 1f);
			ICalculoDeInteracionEstimulanteConEstado calculoDeInteracionEstimulanteConEstado = calculo as ICalculoDeInteracionEstimulanteConEstado;
			if (calculoDeInteracionEstimulanteConEstado != null)
			{
				return num * ((calculoDeInteracionEstimulanteConEstado.estimuloBasico.tipoDeEstimulo == TipoDeEstimulo.coital) ? 1.5f : 1f);
			}
			return num;
		}

		// Token: 0x06001553 RID: 5459 RVA: 0x00064FA4 File Offset: 0x000631A4
		protected override bool ReaccionarCalculoBlokeandoParaReactor(ICalculoDeEstimuloConEstado calculo, out float blokearTiempo)
		{
			bool flag = false;
			float total = calculo.emocion.value.total;
			float mod = this.m_emos.arousal.value.mod;
			OjosExpresionController.Tipo? tipo = null;
			TiposDeGestosDeBoca? tiposDeGestosDeBoca = null;
			TipoDeGestoDeCabeza? tipoDeGestoDeCabeza = null;
			TipoDeGestoDeHombro? tipoDeGestoDeHombro = null;
			ControlladorDeGestosFacialesEmocionales.TipoDeExpresion? tipoDeExpresion = null;
			float num = 1f;
			float num2 = 1f;
			float num3 = base.GetPropUsoBocaPorMuecas(1f).OutPow(3f);
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			bool flag2;
			OjosExpresionController.Tipo tipo3;
			float num4;
			float num5;
			float num6;
			float num7;
			float num8;
			bool flag5;
			if (reaccion != ReaccionHumana.dolor)
			{
				if (reaccion != ReaccionHumana.placer)
				{
					throw new ArgumentOutOfRangeException(reaccion.ToString());
				}
				flag2 = false;
				Personalidad.Tipo tipo2 = this.m_Personalidad.ObtenerTipoMayorDeCurrentFrame(false, null, true, false);
				bool flag3;
				bool flag4;
				if (tipo2 <= Personalidad.Tipo.sumiso)
				{
					if (tipo2 != Personalidad.Tipo.timido && tipo2 != Personalidad.Tipo.sumiso)
					{
						goto IL_0212;
					}
				}
				else
				{
					if (tipo2 == Personalidad.Tipo.pervertido || tipo2 == Personalidad.Tipo.exhibicionista)
					{
						flag3 = false;
						flag4 = true;
						tipo3 = OjosExpresionController.Tipo.achiquitar;
						tiposDeGestosDeBoca = new TiposDeGestosDeBoca?(TiposDeGestosDeBoca.morderLabio);
						num4 = 1f;
						goto IL_0231;
					}
					if (tipo2 != Personalidad.Tipo.respetuoso)
					{
						goto IL_0212;
					}
				}
				flag3 = true;
				flag4 = false;
				tipo3 = OjosExpresionController.Tipo.agrandar;
				num = 0.5f;
				tiposDeGestosDeBoca = new TiposDeGestosDeBoca?(TiposDeGestosDeBoca.aplanarApretando);
				num4 = 0.9f;
				goto IL_0231;
				IL_0212:
				flag3 = false;
				flag4 = false;
				tipo3 = OjosExpresionController.Tipo.agrandar;
				num = 0.5f;
				tiposDeGestosDeBoca = new TiposDeGestosDeBoca?(TiposDeGestosDeBoca.sorprender);
				num4 = 0.1666f;
				IL_0231:
				tipoDeExpresion = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
				tipoDeGestoDeHombro = new TipoDeGestoDeHombro?(TipoDeGestoDeHombro.Nose);
				num5 = 0.333f;
				num6 = 2f;
				tipoDeGestoDeCabeza = new TipoDeGestoDeCabeza?(TipoDeGestoDeCabeza.sisi);
				num7 = 0.66f;
				num8 = 2.5f;
				float num9 = (flag4 ? 0.75f : 1f) * this.coolDownDeExpresionesConSonidoPlacer * base.GetModPorExpresividad(1f, 1f, 0.1f) * this.coolDownModPlacerVsCantidadDePlacerV2.Evaluate(total);
				flag5 = (!flag3 || Mathf.Lerp(this.probabilidadDeExpresionConSonidoSiEsRespetuosa, 100f, mod.OutPow(3f)).ProcPorcentaje(1f)) && Time.time - this.m_lastExpresionesConSonidoPlacerTime >= num9;
			}
			else
			{
				flag2 = true;
				Personalidad.Tipo tipo2 = this.m_Personalidad.ObtenerTipoMayorDeCurrentFrame(false, null, true, false);
				if (tipo2 == Personalidad.Tipo.pervertido || tipo2 == Personalidad.Tipo.exhibicionista)
				{
					tipo3 = OjosExpresionController.Tipo.guiñarL;
					tipo = new OjosExpresionController.Tipo?(OjosExpresionController.Tipo.guiñarR);
					num2 = (num * 0.2f).Random(0.2f);
					tiposDeGestosDeBoca = new TiposDeGestosDeBoca?(TiposDeGestosDeBoca.sorprender);
					num4 = 0.1666f;
				}
				else
				{
					tipo3 = OjosExpresionController.Tipo.cerrar;
					tiposDeGestosDeBoca = new TiposDeGestosDeBoca?(TiposDeGestosDeBoca.aplanarApretando);
					num4 = 0.75f;
				}
				tipoDeExpresion = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor);
				tipoDeGestoDeHombro = new TipoDeGestoDeHombro?(TipoDeGestoDeHombro.achiquitar);
				num5 = 0.2f;
				num6 = 1.25f;
				tipoDeGestoDeCabeza = new TipoDeGestoDeCabeza?(TipoDeGestoDeCabeza.no);
				num7 = 0.5f;
				num8 = 1.333f;
				float num9 = this.coolDownDeExpresionesConSonidoDolor * base.GetModPorExpresividad(1f, 1f, 0.1f) * this.coolDownModDolorVsCantidadDeDolorV2.Evaluate(total);
				flag5 = Time.time - this.m_lastExpresionesConSonidoDolorTime >= num9;
			}
			tiposDeGestosDeBoca = ((!this.m_IBocaHole.isPenetrated && base.GetPropUsoBocaPorMuecas(1f) > Random.value) ? tiposDeGestosDeBoca : null);
			bool flag6 = base.GetPropUsoBodyPorMimicas(0.666f) > Random.value;
			flag5 = flag5 && !this.m_ControlladorDeExpresionesVerbalesConSonido.estaExpresando;
			UmbralBasico.Estado estado;
			ReactorSegundario.GetEstadoConMasEstimuloTotal(calculo, out estado);
			bool flag7 = estado.postModificador > 0f && estado.estimulacionGeneradaTotal > 0f;
			bool flag8 = calculo is ICalculoDeEstimuloCoitalHole;
			flag5 = flag5 && (flag2 || flag7 || flag8);
			ExpresionVerbalData expresionVerbalData = null;
			float num10 = (blokearTiempo = this.duracion.Random(0.2f));
			if (flag5)
			{
				if (reaccion != ReaccionHumana.dolor)
				{
					if (reaccion != ReaccionHumana.placer)
					{
						throw new ArgumentOutOfRangeException(reaccion.ToString());
					}
					expresionVerbalData = Singleton<MapasDeSonidosDeExpresionesVerbalesSexuales>.instance.TryObtenerMapaPlacer(this.m_CharacterPitchDeExpulsiones.expresionesSonidosIndex, total, this.m_ultimoPlacer, this.m_penultimoPlacer);
				}
				else
				{
					expresionVerbalData = Singleton<MapasDeSonidosDeExpresionesVerbalesSexuales>.instance.TryObtenerMapaDolor(this.m_CharacterPitchDeExpulsiones.expresionesSonidosIndex, total, this.m_ultimoDolor);
				}
				flag5 = expresionVerbalData != null;
				if (flag5)
				{
					num10 = expresionVerbalData.Length(this.m_CharacterPitchDeExpulsiones.pitchDeVocal);
				}
			}
			float modPorExpresividad = base.GetModPorExpresividad(1f, 1f, 0.1f);
			if (flag5)
			{
				flag = this.m_ControlladorDeExpresionesVerbalesConSonido.Expresar(expresionVerbalData, 1, ControllerPrioridadConfig.prioridad, false);
			}
			bool flag9 = this.m_OjosExpresionController.Cambiar(tipo3, this.prioridadParaController, num10, ControllerPrioridadConfig.prioridad, num * 100f * modPorExpresividad, this.ojosInTiempoMod, this.ojosOutTiempoMod);
			if (tipo != null)
			{
				flag9 = this.m_OjosExpresionController.Cambiar(tipo.Value, this.prioridadParaController, num10, ControllerPrioridadConfig.prioridad, num2 * 100f * modPorExpresividad, this.ojosInTiempoMod, this.ojosOutTiempoMod) || flag9;
			}
			if (tiposDeGestosDeBoca != null && !flag)
			{
				flag9 = this.m_ControladorDeGestosDeBoca.Gestuar(tiposDeGestosDeBoca.Value, num4 * modPorExpresividad, this.prioridadParaController, ControllerPrioridadConfig.prioridad, num10, false, this.NoEstaHalando, this.bocaInVelocityMod, this.bocaOutVelocityMod) || flag9;
			}
			if (flag6)
			{
				if (tipoDeGestoDeHombro != null)
				{
					flag9 = this.m_ControladorDeGestosConHombros.Gestuar(tipoDeGestoDeHombro.Value, num5 * modPorExpresividad, num6, ControllerPrioridadConfig.baja, false) || flag9;
				}
				if (tipoDeGestoDeCabeza != null)
				{
					flag9 = this.m_ControladorDeGestosConCabeza.Gestuar(tipoDeGestoDeCabeza.Value, num7 * modPorExpresividad, num8, ControllerPrioridadConfig.baja, false) || flag9;
				}
			}
			if (tipoDeExpresion != null)
			{
				float num11 = num3 * 0.9f;
				if (tipoDeExpresion.Value == ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer)
				{
					this.m_ControlladorDeGestosFaciales.DejarDeSuprimirTipoDeExpresion(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
					this.m_ControlladorDeGestosFaciales.DejarDeExagerarTipoDeExpresion(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor);
					this.m_ControlladorDeGestosFaciales.ExagerarTipoDeExpresionPor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, num10, 1f, num3 * modPorExpresividad);
					this.m_ControlladorDeGestosFaciales.SuprimirTipoDeExpresionPor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, num10, num11);
				}
				else
				{
					if (tipoDeExpresion.Value != ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor)
					{
						throw new ArgumentOutOfRangeException();
					}
					this.m_ControlladorDeGestosFaciales.DejarDeSuprimirTipoDeExpresion(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor);
					this.m_ControlladorDeGestosFaciales.DejarDeExagerarTipoDeExpresion(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
					this.m_ControlladorDeGestosFaciales.ExagerarTipoDeExpresionPor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, num10, 1f, num3 * modPorExpresividad);
					this.m_ControlladorDeGestosFaciales.SuprimirTipoDeExpresionPor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, num10, num11);
				}
				this.m_ControlladorDeGestosFaciales.SuprimirTipoDeExpresionPor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, num10, num11);
				this.m_ControlladorDeGestosFaciales.SuprimirTipoDeExpresionPor(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, num10, num11);
			}
			if (flag)
			{
				if (reaccion != ReaccionHumana.dolor)
				{
					if (reaccion != ReaccionHumana.placer)
					{
						throw new ArgumentOutOfRangeException(reaccion.ToString());
					}
					this.m_lastExpresionesConSonidoPlacerTime = Time.time;
					this.m_penultimoPlacer = this.m_ultimoPlacer;
					this.m_ultimoPlacer = expresionVerbalData;
				}
				else
				{
					this.m_lastExpresionesConSonidoDolorTime = Time.time;
					this.m_ultimoDolor = expresionVerbalData;
				}
			}
			return flag9;
		}

		// Token: 0x04000F09 RID: 3849
		[Header("On Spot Config")]
		public float coolDownDeExpresionesConSonidoPlacer = 4f;

		// Token: 0x04000F0A RID: 3850
		public float coolDownDeExpresionesConSonidoDolor = 4f;

		// Token: 0x04000F0B RID: 3851
		public AnimationCurve coolDownModPlacerVsCantidadDePlacerV2 = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 1f),
			new Keyframe(100f, 0f)
		});

		// Token: 0x04000F0C RID: 3852
		public AnimationCurve coolDownModDolorVsCantidadDeDolorV2 = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 1f),
			new Keyframe(100f, 0.2f)
		});

		// Token: 0x04000F0D RID: 3853
		[Range(0f, 100f)]
		public float probabilidadDeExpresionConSonidoSiEsRespetuosa = 50f;

		// Token: 0x04000F0E RID: 3854
		public float placerParaValidoEnSpot;

		// Token: 0x04000F0F RID: 3855
		public float placerParaValidoCasiEnSpot = 50f;

		// Token: 0x04000F10 RID: 3856
		public float placerParaValidoCercano = 75f;

		// Token: 0x04000F11 RID: 3857
		public float placerParaValidoFuera = 95f;

		// Token: 0x04000F12 RID: 3858
		public float severidadEnDolorParaSerValido = 0.9f;

		// Token: 0x04000F13 RID: 3859
		private float m_lastExpresionesConSonidoPlacerTime = float.MinValue;

		// Token: 0x04000F14 RID: 3860
		private float m_lastExpresionesConSonidoDolorTime = float.MinValue;

		// Token: 0x04000F15 RID: 3861
		private IBocaHole m_IBocaHole;

		// Token: 0x04000F16 RID: 3862
		private EmocionesFemeninas m_emos;

		// Token: 0x04000F17 RID: 3863
		private CharacterPitchDeExpulsiones m_CharacterPitchDeExpulsiones;

		// Token: 0x04000F18 RID: 3864
		private ControlladorDeExpresionesVerbalesConSonido m_ControlladorDeExpresionesVerbalesConSonido;

		// Token: 0x04000F19 RID: 3865
		[SerializeField]
		[ReadOnlyUI]
		private ExpresionVerbalData m_ultimoPlacer;

		// Token: 0x04000F1A RID: 3866
		[SerializeField]
		[ReadOnlyUI]
		private ExpresionVerbalData m_penultimoPlacer;

		// Token: 0x04000F1B RID: 3867
		[SerializeField]
		[ReadOnlyUI]
		private ExpresionVerbalData m_ultimoDolor;
	}
}
