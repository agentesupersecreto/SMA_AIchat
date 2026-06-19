using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000485 RID: 1157
	public abstract class CalculoDeEstimuloPorPenetracionRecibida : CalculoDeEstimuloPorPenetracionRecibidaBase<CalculoDeEstimuloPorPenetracionHoleResultado, CalculoDeEstimuloPorPenetracionResultado>, ICalculadorDeEstimuloIgnoradorEnPartesHumanas, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x06001A48 RID: 6728 RVA: 0x00069D59 File Offset: 0x00067F59
		public void IgnorarParteHumana(ParteDelCuerpoHumano parte, bool ignorar)
		{
			if (ignorar)
			{
				if (!this.ignorarSiEstaPenetrandoEn.Contains(parte))
				{
					this.ignorarSiEstaPenetrandoEn.Add(parte);
					return;
				}
			}
			else
			{
				while (this.ignorarSiEstaPenetrandoEn.Contains(parte))
				{
					this.ignorarSiEstaPenetrandoEn.Remove(parte);
				}
			}
		}

		// Token: 0x06001A49 RID: 6729 RVA: 0x00069D94 File Offset: 0x00067F94
		protected override bool ItemEsValido(PenetracionesByMainInFrame.Penetracion item, int index)
		{
			return !this.ignorarSiEstaPenetrandoEn.Contains(item.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana));
		}

		// Token: 0x06001A4B RID: 6731 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001A4C RID: 6732 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001A4D RID: 6733 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001A4E RID: 6734 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001A4F RID: 6735 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001A50 RID: 6736 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x0400135F RID: 4959
		[SerializeField]
		private List<ParteDelCuerpoHumano> ignorarSiEstaPenetrandoEn = new List<ParteDelCuerpoHumano>();
	}
}
