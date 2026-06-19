using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.GestosFaciales
{
	// Token: 0x02000322 RID: 802
	public sealed class ReactorGeneralDeGestosFaciales : ReactorGestosFacialesBase<ICalculoDeEstimulo>
	{
		// Token: 0x06001447 RID: 5191 RVA: 0x0005EC5C File Offset: 0x0005CE5C
		protected override bool CalculoEsValido(ICalculoDeEstimulo calculo)
		{
			ICalculoDeEstimuloVisual calculoDeEstimuloVisual = calculo as ICalculoDeEstimuloVisual;
			if (calculoDeEstimuloVisual != null)
			{
				if (calculoDeEstimuloVisual.estimulo.tipo == DireccionDeEstimulo.recibida && calculoDeEstimuloVisual.estimulo.angleDesdePuntoVisual > 45f)
				{
					return false;
				}
				if (calculoDeEstimuloVisual.estimulo.tipo == DireccionDeEstimulo.dada && !calculoDeEstimuloVisual.estimulanteParte.EsPenetrador() && calculoDeEstimuloVisual.estimulanteParte != ParteQuePuedeEstimular.semen)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06001448 RID: 5192 RVA: 0x0005ECBF File Offset: 0x0005CEBF
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			if (calculo.causoMaxValue)
			{
				return 0f;
			}
			return 1f;
		}

		// Token: 0x06001449 RID: 5193 RVA: 0x0005ECD4 File Offset: 0x0005CED4
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			if (calculo.causoMaxValue)
			{
				return 100000000f;
			}
			return 1f;
		}

		// Token: 0x0600144A RID: 5194 RVA: 0x0005ECEC File Offset: 0x0005CEEC
		protected override bool ReaccionarCalculoBlokeandoParaReactor(ICalculoDeEstimulo calculo, out float blokearTiempo)
		{
			bool flag4;
			try
			{
				bool flag = calculo is ICalculoDeEstimuloCoitalHole;
				float num = base.WeightPorEmocion(calculo);
				base.WeightPorPartes(calculo, ref num);
				bool flag2 = calculo is ICalculoDeEstimuloConEstado;
				float num2 = 0f;
				if (flag2)
				{
					UmbralBasico.Estado estado;
					ReactorSegundario.GetEstadoConMasEstimuloTotal(calculo, out estado);
					num2 = estado.severidadConPost.OutPow(1.25f);
					num = Mathf.Lerp(num * 0.75f, num, num2);
				}
				if (flag)
				{
					num = num.OutPow(Mathf.Lerp(1f, 1.5f, num2));
				}
				ICalculoDeEstimuloVisual calculoDeEstimuloVisual = calculo as ICalculoDeEstimuloVisual;
				if (calculoDeEstimuloVisual != null)
				{
					num *= Mathf.InverseLerp(90f, 0f, calculoDeEstimuloVisual.estimulo.angleDesdePuntoVisual).OutPow(3f);
				}
				if (calculo.causoMaxValue)
				{
					num = 1f;
				}
				if (this.config.durationRandom >= this.config.duration)
				{
					throw new InvalidOperationException();
				}
				float num3 = (blokearTiempo = this.config.duration + Random.Range(-this.config.durationRandom, this.config.durationRandom) * base.duracionModPorExpresividad);
				bool flag3 = false;
				base.Parcer(calculo, calculo.emocion.reaccion, this.m_tiposTemp, this.m_modsTemp);
				for (int i = 0; i < this.m_tiposTemp.Count; i++)
				{
					float num4 = this.m_modsTemp[i] * num;
					if (num4 > 0f)
					{
						flag3 = this.dependencias.controller.Cambiar(this.m_tiposTemp[i], num3, num4, true, null, null) || flag3;
					}
				}
				flag4 = flag3;
			}
			finally
			{
				this.m_tiposTemp.Clear();
				this.m_modsTemp.Clear();
			}
			return flag4;
		}

		// Token: 0x04000E87 RID: 3719
		private List<ControlladorDeGestosFacialesEmocionales.TipoDeExpresion> m_tiposTemp = new List<ControlladorDeGestosFacialesEmocionales.TipoDeExpresion>();

		// Token: 0x04000E88 RID: 3720
		private List<float> m_modsTemp = new List<float>();
	}
}
