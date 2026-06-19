using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x02000391 RID: 913
	public abstract class ReactorACalculoDeEstimulo<TCalculo> : ReactorACalculoDeEstimuloBase<TCalculo> where TCalculo : class, ICalculoDeEstimulo
	{
		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x060013F7 RID: 5111 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool puedeReaccionarANullos
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060013F8 RID: 5112 RVA: 0x0005679E File Offset: 0x0005499E
		public sealed override bool ReaccionarACalculo(TCalculo calculo)
		{
			return calculo != null && base.Reaccionar(calculo);
		}

		// Token: 0x060013F9 RID: 5113 RVA: 0x000567B6 File Offset: 0x000549B6
		public sealed override bool ReaccionarACalculos(IReadOnlyList<TCalculo> calculos)
		{
			return calculos != null && calculos.Count != 0 && base.Reaccionar(calculos);
		}

		// Token: 0x060013FA RID: 5114 RVA: 0x000567CC File Offset: 0x000549CC
		protected sealed override bool ReaccionarArgumento(object arg)
		{
			return this.ReaccionarCalculo((TCalculo)((object)arg));
		}

		// Token: 0x060013FB RID: 5115 RVA: 0x000567DC File Offset: 0x000549DC
		protected sealed override bool ArgumentoEsValido(object arg)
		{
			TCalculo tcalculo = arg as TCalculo;
			if (tcalculo == null)
			{
				return false;
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
			bool flag = base.CondicionesSeCumplen(tcalculo);
			bool flag2 = this.CalculoEsValido(tcalculo);
			return flag && flag2;
		}
	}
}
