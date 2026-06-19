using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x02000393 RID: 915
	public abstract class ReactorACalculoDeEstimuloBase : ReactorPadre
	{
		// Token: 0x06001408 RID: 5128 RVA: 0x00004252 File Offset: 0x00002452
		protected virtual int OnLoadCondiciones(List<ICheckeadorDeCalculo> result)
		{
			return 0;
		}

		// Token: 0x06001409 RID: 5129 RVA: 0x00056BCC File Offset: 0x00054DCC
		protected bool CondicionesSeCumplen(ICalculoDeEstimulo calculo)
		{
			bool flag;
			try
			{
				int num = 0;
				if (this.condicionesGenerales.reglas.Count > 0)
				{
					this.m_condicionesTEMP.Add(this.condicionesGenerales);
					num += this.condicionesGenerales.reglas.Count;
				}
				if (this.condicionesParallelas.condiciones.Count > 0)
				{
					this.m_condicionesTEMP.Add(this.condicionesParallelas);
					num += this.condicionesParallelas.condiciones.Count;
				}
				num += this.OnLoadCondiciones(this.m_condicionesTEMP);
				if (num <= 0)
				{
					flag = true;
				}
				else
				{
					for (int i = 0; i < this.m_condicionesTEMP.Count; i++)
					{
						ICheckeadorDeCalculo checkeadorDeCalculo = this.m_condicionesTEMP[i];
						if (!((checkeadorDeCalculo != null) ? new bool?(checkeadorDeCalculo.Check(calculo)) : null).GetValueOrDefault(true))
						{
							return false;
						}
					}
					flag = true;
				}
			}
			finally
			{
				this.m_condicionesTEMP.Clear();
			}
			return flag;
		}

		// Token: 0x04001081 RID: 4225
		[Header("Condiciones: Todas Deben Ser Verdaderas")]
		public bool debugBreakCondiciones;

		// Token: 0x04001082 RID: 4226
		public Condicion condicionesGenerales = new Condicion();

		// Token: 0x04001083 RID: 4227
		[Tooltip("Si un trigger se cumple se aplican las condiciones del trigger, si no se ignoran. Solo puede entrar a un trigger")]
		public CondicionesConTriggerParallel condicionesParallelas = new CondicionesConTriggerParallel();

		// Token: 0x04001084 RID: 4228
		private List<ICheckeadorDeCalculo> m_condicionesTEMP = new List<ICheckeadorDeCalculo>();
	}
}
