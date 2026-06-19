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
	// Token: 0x02000323 RID: 803
	public sealed class ReactorConHeadEffectorAEstimulos : ReactorACalculoDeEstimulo<ICalculoDeEstimuloConEstado>
	{
		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x0600144C RID: 5196 RVA: 0x0005EEE0 File Offset: 0x0005D0E0
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

		// Token: 0x0600144D RID: 5197 RVA: 0x0005EF48 File Offset: 0x0005D148
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

		// Token: 0x0600144E RID: 5198 RVA: 0x0005EFB1 File Offset: 0x0005D1B1
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloConEstado calculo)
		{
			return this.propUsoBodyPorMimicas;
		}

		// Token: 0x0600144F RID: 5199 RVA: 0x0001D9D8 File Offset: 0x0001BBD8
		protected override bool CalculoEsValido(ICalculoDeEstimuloConEstado calculo)
		{
			return calculo != null;
		}

		// Token: 0x06001450 RID: 5200 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloConEstado calculo)
		{
			return 1f;
		}

		// Token: 0x06001451 RID: 5201 RVA: 0x0005EFBC File Offset: 0x0005D1BC
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloConEstado calculo)
		{
			float num = 1f;
			float num2 = 1f;
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			TipoDeGestoDeCabeza tipoDeGestoDeCabeza;
			if (reaccion <= ReaccionHumana.miedo)
			{
				if (reaccion <= ReaccionHumana.placer)
				{
					switch (reaccion)
					{
					case ReaccionHumana.None:
						return false;
					case ReaccionHumana.concentToHero:
						tipoDeGestoDeCabeza = TipoDeGestoDeCabeza.acentuarLado;
						goto IL_0135;
					case ReaccionHumana.asombro:
						tipoDeGestoDeCabeza = TipoDeGestoDeCabeza.sorpresa;
						goto IL_0135;
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro:
					case ReaccionHumana.concentToHero | ReaccionHumana.dolor:
					case ReaccionHumana.asombro | ReaccionHumana.dolor:
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro | ReaccionHumana.dolor:
						goto IL_0115;
					case ReaccionHumana.dolor:
						tipoDeGestoDeCabeza = TipoDeGestoDeCabeza.dolor;
						goto IL_0135;
					case ReaccionHumana.rabia:
						tipoDeGestoDeCabeza = TipoDeGestoDeCabeza.dolor;
						num = 0.5f;
						num2 = 1.5f;
						goto IL_0135;
					default:
						if (reaccion == ReaccionHumana.asco)
						{
							tipoDeGestoDeCabeza = TipoDeGestoDeCabeza.repulsion;
							goto IL_0135;
						}
						if (reaccion != ReaccionHumana.placer)
						{
							goto IL_0115;
						}
						tipoDeGestoDeCabeza = TipoDeGestoDeCabeza.placer;
						goto IL_0135;
					}
				}
				else
				{
					if (reaccion == ReaccionHumana.arousal)
					{
						tipoDeGestoDeCabeza = TipoDeGestoDeCabeza.placer;
						goto IL_0135;
					}
					if (reaccion == ReaccionHumana.tristeza)
					{
						tipoDeGestoDeCabeza = TipoDeGestoDeCabeza.verguenza;
						goto IL_0135;
					}
					if (reaccion != ReaccionHumana.miedo)
					{
						goto IL_0115;
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
				if (reaccion != ReaccionHumana.decepcion)
				{
					goto IL_0115;
				}
				tipoDeGestoDeCabeza = TipoDeGestoDeCabeza.no;
				goto IL_0135;
			}
			else
			{
				if (reaccion == ReaccionHumana.alivio)
				{
					tipoDeGestoDeCabeza = TipoDeGestoDeCabeza.sisisi;
					goto IL_0135;
				}
				if (reaccion == ReaccionHumana.aburrimiento)
				{
					return false;
				}
				if (reaccion != ReaccionHumana.desHielo)
				{
					goto IL_0115;
				}
			}
			tipoDeGestoDeCabeza = TipoDeGestoDeCabeza.sorpresa;
			goto IL_0135;
			IL_0115:
			throw new ArgumentOutOfRangeException(calculo.emocion.reaccion.ToString());
			IL_0135:
			if (this.m_CoolDownPorTipo.IsOn(tipoDeGestoDeCabeza, 1f))
			{
				return false;
			}
			UmbralBasico.Estado estado;
			ReactorSegundario.GetEstadoConMasEstimuloTotal(calculo, out estado);
			float severidadConPost = estado.severidadConPost;
			float num3 = severidadConPost * num;
			float num4 = Mathf.Lerp(1.15f, 0.95f, severidadConPost) * num2;
			bool flag = this.m_controllador.Gestuar(tipoDeGestoDeCabeza, num3, num4, ControllerPrioridadConfig.baja, false);
			if (flag)
			{
				this.m_CoolDownPorTipo.ApplyNext(tipoDeGestoDeCabeza, 15f.Random(0.25f));
			}
			return flag;
		}

		// Token: 0x04000E89 RID: 3721
		private Personalidad m_Personalidad;

		// Token: 0x04000E8A RID: 3722
		private ControladorDeGestosConCabeza m_controllador;

		// Token: 0x04000E8B RID: 3723
		private ReactorConHeadEffectorAEstimulos.CoolDownPorTipo m_CoolDownPorTipo = new ReactorConHeadEffectorAEstimulos.CoolDownPorTipo(() => 15f);

		// Token: 0x02000324 RID: 804
		public class CoolDownPorTipo : CoolDownPorID<TipoDeGestoDeCabeza>
		{
			// Token: 0x06001453 RID: 5203 RVA: 0x0005F1A1 File Offset: 0x0005D3A1
			public CoolDownPorTipo(Func<float> defaultCooldwonGetter)
				: base(defaultCooldwonGetter)
			{
			}

			// Token: 0x06001454 RID: 5204 RVA: 0x000118D7 File Offset: 0x0000FAD7
			protected override int ConvertirTipoAId(TipoDeGestoDeCabeza tipo)
			{
				return (int)tipo;
			}
		}
	}
}
