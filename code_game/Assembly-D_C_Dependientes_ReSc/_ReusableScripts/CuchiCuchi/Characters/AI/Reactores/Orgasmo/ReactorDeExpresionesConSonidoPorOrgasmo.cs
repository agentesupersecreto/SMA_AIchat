using System;
using Assets.TValle.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Runtime.Sonidos.Characters.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Characters.Controladores.ControlladoresDeColoDePrioridad;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Sonido.Expresiones;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Respiracion;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.AI.Reactores.Orgasmo
{
	// Token: 0x0200002F RID: 47
	public class ReactorDeExpresionesConSonidoPorOrgasmo : ReactorACalculoDeEstimulo<ICalculoDeEstimulo>
	{
		// Token: 0x060000DA RID: 218 RVA: 0x00006B84 File Offset: 0x00004D84
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_DuracionDeOrgasmo = this.GetComponentEnRoot(false);
			if (this.m_DuracionDeOrgasmo == null)
			{
				throw new ArgumentNullException("m_DuracionDeOrgasmo", "m_DuracionDeOrgasmo null reference.");
			}
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			this.m_emos = this.GetComponentEnRoot(false);
			if (this.m_emos == null)
			{
				throw new ArgumentNullException("m_emos", "m_emos null reference.");
			}
			this.m_RespiracionEngine = this.GetComponentEnRoot(false);
			if (this.m_RespiracionEngine == null)
			{
				throw new ArgumentNullException("m_RespiracionEngine", "m_RespiracionEngine null reference.");
			}
			this.m_ControladorDeGestosDeBoca = this.GetComponentEnRoot(false);
			if (this.m_ControladorDeGestosDeBoca == null)
			{
				throw new ArgumentNullException("m_ControladorDeGestosDeBoca", "m_ControladorDeGestosDeBoca null reference.");
			}
			this.m_ControlladorDeExpresionesVerbalesConSonido = this.GetComponentEnRoot(false);
			if (this.m_ControlladorDeExpresionesVerbalesConSonido == null)
			{
				throw new ArgumentNullException("m_ControlladorDeExpresionesVerbalesConSonido", "m_ControlladorDeExpresionesVerbalesConSonido null reference.");
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00006C93 File Offset: 0x00004E93
		protected override bool CalculoEsValido(ICalculoDeEstimulo calculo)
		{
			return calculo.EsOrgasmo();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00006C9C File Offset: 0x00004E9C
		protected override bool ReaccionarCalculo(ICalculoDeEstimulo calculo)
		{
			if (this.m_DuracionDeOrgasmo.nextOrgasmApretaraBoca)
			{
				this.m_RespiracionEngine.modoManualActivado = true;
				this.m_RespiracionEngine.modoManualConfig = new RespiracionEngine.ModoManualConfig
				{
					duracionDeTipoDeRespiracion = this.m_DuracionDeOrgasmo.currentDuracionTotalDeOrgasmo,
					modo = ModoDeRespiracion.nasal,
					tipo = TipoDeRespiracion.reposo,
					frequenciaDeRespiracion = 1f
				};
				GlobalUpdater.instancia.Invokar(delegate
				{
					this.m_RespiracionEngine.modoManualActivado = false;
				}, this.m_DuracionDeOrgasmo.currentDuracionTotalDeOrgasmo);
				this.m_ControladorDeGestosDeBoca.Gestuar(TiposDeGestosDeBoca.aplanarApretando, 1f, int.MaxValue, ControllerPrioridadConfig.prioridad, this.m_DuracionDeOrgasmo.currentDuracionTotalDeOrgasmo, false, null, 1f, 1f);
			}
			else
			{
				float total = this.m_emos.arousal.value.total;
				ExpresionVerbalData nextOrgasmSound = this.m_DuracionDeOrgasmo.nextOrgasmSound;
				if (this.m_ControlladorDeExpresionesVerbalesConSonido.Expresar(nextOrgasmSound, 2147483647, ControllerPrioridadConfig.prioridad, total > 66.66f))
				{
					this.m_lastOrgasmSound = nextOrgasmSound;
				}
			}
			return true;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00006DA3 File Offset: 0x00004FA3
		protected override void Reaccionado(bool resultado)
		{
			base.Reaccionado(resultado);
			if (resultado)
			{
				this.m_DuracionDeOrgasmo.FlagSonidoDeOrgasmoUsado(this.m_DuracionDeOrgasmo.nextOrgasmSound);
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return 1f;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return 1f;
		}

		// Token: 0x040000BD RID: 189
		private ControladorDeGestosDeBoca m_ControladorDeGestosDeBoca;

		// Token: 0x040000BE RID: 190
		private ControlladorDeExpresionesVerbalesConSonido m_ControlladorDeExpresionesVerbalesConSonido;

		// Token: 0x040000BF RID: 191
		private IDuracionDeOrgasmo m_DuracionDeOrgasmo;

		// Token: 0x040000C0 RID: 192
		private Personalidad m_Personalidad;

		// Token: 0x040000C1 RID: 193
		private EmocionesFemeninas m_emos;

		// Token: 0x040000C2 RID: 194
		private RespiracionEngine m_RespiracionEngine;

		// Token: 0x040000C3 RID: 195
		[ReadOnlyUI]
		[SerializeField]
		private ExpresionVerbalData m_lastOrgasmSound;
	}
}
