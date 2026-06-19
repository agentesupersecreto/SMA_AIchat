using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas
{
	// Token: 0x020003B4 RID: 948
	public abstract class CondicionesConTrigger : ICheckeadorDeCalculo, IEditorCheckeadorDeCalculo
	{
		// Token: 0x060014BA RID: 5306
		protected abstract bool Check(ICalculoDeEstimulo calculo);

		// Token: 0x060014BB RID: 5307 RVA: 0x00058E3C File Offset: 0x0005703C
		void IEditorCheckeadorDeCalculo.BeforeChecking()
		{
			this.lastResult = 0;
			for (int i = 0; i < this.condiciones.Count; i++)
			{
				CondicionConTrigger condicionConTrigger = this.condiciones[i];
				if (condicionConTrigger != null)
				{
					((IEditorCheckeadorDeCalculo)condicionConTrigger).BeforeChecking();
				}
			}
		}

		// Token: 0x060014BC RID: 5308 RVA: 0x00058E80 File Offset: 0x00057080
		bool ICheckeadorDeCalculo.Check(ICalculoDeEstimulo calculo)
		{
			bool flag = this.Check(calculo);
			this.lastResult = (flag ? 1 : (-1));
			return flag;
		}

		// Token: 0x040010E7 RID: 4327
		public List<CondicionConTrigger> condiciones = new List<CondicionConTrigger>();

		// Token: 0x040010E8 RID: 4328
		public int lastResult;
	}
}
