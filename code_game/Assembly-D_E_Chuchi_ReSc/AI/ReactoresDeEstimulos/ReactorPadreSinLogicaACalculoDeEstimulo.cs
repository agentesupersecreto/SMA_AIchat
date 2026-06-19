using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x0200039B RID: 923
	public abstract class ReactorPadreSinLogicaACalculoDeEstimulo<TCalculo> : ReactorACalculoDeEstimuloBase<TCalculo> where TCalculo : class, ICalculoDeEstimulo
	{
		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x0600142C RID: 5164 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool puedeReaccionarANullos
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600142D RID: 5165 RVA: 0x0005786F File Offset: 0x00055A6F
		public sealed override bool ReaccionarACalculo(TCalculo calculo)
		{
			return base.Reaccionar(calculo);
		}

		// Token: 0x0600142E RID: 5166 RVA: 0x0005787D File Offset: 0x00055A7D
		public sealed override bool ReaccionarACalculos(IReadOnlyList<TCalculo> calculos)
		{
			return base.Reaccionar(calculos);
		}

		// Token: 0x0600142F RID: 5167 RVA: 0x00057886 File Offset: 0x00055A86
		protected sealed override bool ReaccionarArgumento(object arg)
		{
			return this.ReaccionarCalculo(arg as TCalculo);
		}

		// Token: 0x06001430 RID: 5168 RVA: 0x0005789C File Offset: 0x00055A9C
		protected sealed override bool ArgumentoEsValido(object arg)
		{
			TCalculo tcalculo = arg as TCalculo;
			if (tcalculo == null)
			{
				return true;
			}
			ICalculoDeEstimuloReaccionable calculoDeEstimuloReaccionable = tcalculo as ICalculoDeEstimuloReaccionable;
			if (calculoDeEstimuloReaccionable != null && !calculoDeEstimuloReaccionable.reaccionable)
			{
				return false;
			}
			if (tcalculo.tipo == TipoDeCalculoDeEstimulo.None)
			{
				Debug.LogWarning("calcilo de estimulo des de tipo None", (Object)tcalculo.producidoPor);
			}
			return this.CalculoEsValido(tcalculo);
		}

		// Token: 0x06001431 RID: 5169 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float CoolDownModificadorParaCalculo(TCalculo calculo)
		{
			return 1f;
		}

		// Token: 0x06001432 RID: 5170 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(TCalculo calculo)
		{
			return 1f;
		}

		// Token: 0x06001433 RID: 5171 RVA: 0x00057906 File Offset: 0x00055B06
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.coolDownGeneral = 0f;
			this.baseConfig.probabilidadPorSegundo = 100f;
			this.padreConfig.dejarDeReaccionarHijosSiAlgunHijoReacciona = false;
			this.padreConfig.reaccionarPropioSiAlgunHijoReacciona = false;
		}

		// Token: 0x06001434 RID: 5172 RVA: 0x00004252 File Offset: 0x00002452
		protected sealed override bool ReaccionarCalculo(TCalculo calculo)
		{
			return false;
		}

		// Token: 0x06001435 RID: 5173 RVA: 0x00056BBC File Offset: 0x00054DBC
		protected sealed override bool PadrePuedeReaccionar(ReactorPadre padre, TCalculo calculo, object arg, out bool negarTodos)
		{
			negarTodos = false;
			return true;
		}
	}
}
