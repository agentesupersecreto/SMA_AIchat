using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas
{
	// Token: 0x020003B2 RID: 946
	[Serializable]
	public class Condicion : ICheckeadorDeCalculo, IEditorCheckeadorDeCalculo
	{
		// Token: 0x060014B4 RID: 5300 RVA: 0x00058D28 File Offset: 0x00056F28
		public bool Check(ICalculoDeEstimulo calculo)
		{
			bool flag = Regla.Check(this.invertida, this.tipo, this.reglas, calculo);
			this.lastResult = (flag ? 1 : (-1));
			return flag;
		}

		// Token: 0x060014B5 RID: 5301 RVA: 0x00058D5C File Offset: 0x00056F5C
		void IEditorCheckeadorDeCalculo.BeforeChecking()
		{
			this.lastResult = 0;
			for (int i = 0; i < this.reglas.Count; i++)
			{
				Regla regla = this.reglas[i];
				if (regla != null)
				{
					((IEditorCheckeadorDeCalculo)regla).BeforeChecking();
				}
			}
		}

		// Token: 0x040010E0 RID: 4320
		public bool invertida;

		// Token: 0x040010E1 RID: 4321
		public Regla.Tipo tipo;

		// Token: 0x040010E2 RID: 4322
		public List<Regla> reglas = new List<Regla>();

		// Token: 0x040010E3 RID: 4323
		public int lastResult;
	}
}
