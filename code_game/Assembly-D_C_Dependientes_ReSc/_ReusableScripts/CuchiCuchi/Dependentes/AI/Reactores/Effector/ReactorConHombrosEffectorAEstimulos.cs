using System;
using Assets.Base.BeachGirl.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Effector
{
	// Token: 0x02000326 RID: 806
	public sealed class ReactorConHombrosEffectorAEstimulos : ReactorACalculoDeEstimulo<ICalculoDeEstimuloConEstado>
	{
		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06001458 RID: 5208 RVA: 0x0005F1C0 File Offset: 0x0005D3C0
		public float propUsoBodyPorMimicas
		{
			get
			{
				HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.mimicas);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 0.5f;
				case HumanTraitScore.alto:
					return 0.725f;
				case HumanTraitScore.muyAlto:
					return 0.95f;
				case HumanTraitScore.bajo:
					return 0.275f;
				case HumanTraitScore.muyBajo:
					return 0.05f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x06001459 RID: 5209 RVA: 0x0005F228 File Offset: 0x0005D428
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_controllador = this.GetComponentEnRoot(false);
			if (this.m_controllador == null)
			{
				throw new ArgumentNullException("m_controllador", "m_controllador null reference.");
			}
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
		}

		// Token: 0x0600145A RID: 5210 RVA: 0x0005F291 File Offset: 0x0005D491
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloConEstado calculo)
		{
			return this.propUsoBodyPorMimicas;
		}

		// Token: 0x0600145B RID: 5211 RVA: 0x0001D9D8 File Offset: 0x0001BBD8
		protected override bool CalculoEsValido(ICalculoDeEstimuloConEstado calculo)
		{
			return calculo != null;
		}

		// Token: 0x0600145C RID: 5212 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloConEstado calculo)
		{
			return 1f;
		}

		// Token: 0x0600145D RID: 5213 RVA: 0x0005F29C File Offset: 0x0005D49C
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloConEstado calculo)
		{
			float num = 1f;
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			TipoDeGestoDeHombro tipoDeGestoDeHombro;
			float num2;
			if (reaccion <= ReaccionHumana.miedo)
			{
				if (reaccion <= ReaccionHumana.placer)
				{
					switch (reaccion)
					{
					case ReaccionHumana.None:
						return false;
					case ReaccionHumana.concentToHero:
						return false;
					case ReaccionHumana.asombro:
						return false;
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro:
					case ReaccionHumana.concentToHero | ReaccionHumana.dolor:
					case ReaccionHumana.asombro | ReaccionHumana.dolor:
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro | ReaccionHumana.dolor:
						break;
					case ReaccionHumana.dolor:
						tipoDeGestoDeHombro = TipoDeGestoDeHombro.achiquitar;
						num2 = 0.5f;
						num = 0.5f;
						goto IL_017E;
					case ReaccionHumana.rabia:
						tipoDeGestoDeHombro = TipoDeGestoDeHombro.achiquitar;
						num2 = 0.2f;
						num = 1.5f;
						goto IL_017E;
					default:
						if (reaccion == ReaccionHumana.asco)
						{
							tipoDeGestoDeHombro = TipoDeGestoDeHombro.achiquitar;
							num2 = 0.33f;
							goto IL_017E;
						}
						if (reaccion == ReaccionHumana.placer)
						{
							tipoDeGestoDeHombro = TipoDeGestoDeHombro.sacarPecho;
							num2 = 0.33f;
							goto IL_017E;
						}
						break;
					}
				}
				else
				{
					if (reaccion == ReaccionHumana.arousal)
					{
						return false;
					}
					if (reaccion == ReaccionHumana.tristeza)
					{
						tipoDeGestoDeHombro = TipoDeGestoDeHombro.achiquitar;
						num2 = 0.5f;
						num = 1.5f;
						goto IL_017E;
					}
					if (reaccion == ReaccionHumana.miedo)
					{
						tipoDeGestoDeHombro = TipoDeGestoDeHombro.sacarPecho;
						num2 = 0.5f;
						num = 0.5f;
						goto IL_017E;
					}
				}
			}
			else if (reaccion <= ReaccionHumana.decepcion)
			{
				if (reaccion == ReaccionHumana.alegria)
				{
					return false;
				}
				if (reaccion == ReaccionHumana.felicidad)
				{
					return false;
				}
				if (reaccion == ReaccionHumana.decepcion)
				{
					return false;
				}
			}
			else
			{
				if (reaccion == ReaccionHumana.alivio)
				{
					return false;
				}
				if (reaccion == ReaccionHumana.aburrimiento)
				{
					return false;
				}
				if (reaccion == ReaccionHumana.desHielo)
				{
					tipoDeGestoDeHombro = TipoDeGestoDeHombro.achiquitar;
					num2 = 0.25f;
					num = 0.25f;
					goto IL_017E;
				}
			}
			throw new ArgumentOutOfRangeException(calculo.emocion.reaccion.ToString());
			IL_017E:
			if (this.m_CoolDownPorTipo.IsOn(tipoDeGestoDeHombro, 1f))
			{
				return false;
			}
			UmbralBasico.Estado estado;
			ReactorSegundario.GetEstadoConMasEstimuloTotal(calculo, out estado);
			float severidadConPost = estado.severidadConPost;
			float num3 = severidadConPost * num2;
			float num4 = Mathf.Lerp(1.15f, 0.95f, severidadConPost) * num;
			bool flag = this.m_controllador.Gestuar(tipoDeGestoDeHombro, num3, num4, ControllerPrioridadConfig.baja, false);
			if (flag)
			{
				this.m_CoolDownPorTipo.ApplyNext(tipoDeGestoDeHombro, 20f.Random(0.25f));
			}
			return flag;
		}

		// Token: 0x04000E8E RID: 3726
		private Personalidad m_Personalidad;

		// Token: 0x04000E8F RID: 3727
		private ControladorDeGestosConHombros m_controllador;

		// Token: 0x04000E90 RID: 3728
		private ReactorConHombrosEffectorAEstimulos.CoolDownPorTipo m_CoolDownPorTipo = new ReactorConHombrosEffectorAEstimulos.CoolDownPorTipo(() => 20f);

		// Token: 0x02000327 RID: 807
		public class CoolDownPorTipo : CoolDownPorID<TipoDeGestoDeHombro>
		{
			// Token: 0x0600145F RID: 5215 RVA: 0x0005F4CA File Offset: 0x0005D6CA
			public CoolDownPorTipo(Func<float> defaultCooldwonGetter)
				: base(defaultCooldwonGetter)
			{
			}

			// Token: 0x06001460 RID: 5216 RVA: 0x000118D7 File Offset: 0x0000FAD7
			protected override int ConvertirTipoAId(TipoDeGestoDeHombro tipo)
			{
				return (int)tipo;
			}
		}
	}
}
