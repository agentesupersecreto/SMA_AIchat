using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x0200048D RID: 1165
	public abstract class CalculoDeEstimuloPorTactilesRecibidos : CalculoDeEstimuloPorTactilesRecibidos<CalculoDeEstimuloPorCariciasResultado>, ICalculadorDeEstimuloIgnoradorEnPartesHumanas, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x06001AFC RID: 6908 RVA: 0x0006C579 File Offset: 0x0006A779
		public void IgnorarParteHumana(ParteDelCuerpoHumano parte, bool ignorar)
		{
			if (ignorar)
			{
				if (!this.ignorarSiEstaTocandoEn.Contains(parte))
				{
					this.ignorarSiEstaTocandoEn.Add(parte);
					return;
				}
			}
			else
			{
				while (this.ignorarSiEstaTocandoEn.Contains(parte))
				{
					this.ignorarSiEstaTocandoEn.Remove(parte);
				}
			}
		}

		// Token: 0x06001AFD RID: 6909 RVA: 0x0006C5B4 File Offset: 0x0006A7B4
		protected override bool EstimuloEsValidoV2(ParteQuePuedeEstimular estimulanteParte, [TupleElementNames(new string[] { "original", null, "invertido", "estimulanteInvertido" })] ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> par)
		{
			return base.EstimuloEsValidoV2(estimulanteParte, par) && !this.ignorarSiEstaTocandoEn.Contains(par.Item1.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana));
		}

		// Token: 0x06001AFF RID: 6911 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001B00 RID: 6912 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001B01 RID: 6913 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001B02 RID: 6914 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001B03 RID: 6915 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001B04 RID: 6916 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x04001384 RID: 4996
		[SerializeField]
		private List<ParteDelCuerpoHumano> ignorarSiEstaTocandoEn = new List<ParteDelCuerpoHumano>();
	}
}
