using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas
{
	// Token: 0x020003B3 RID: 947
	[Serializable]
	public class CondicionConTrigger : ICheckeadorDeCalculo, IEditorCheckeadorDeCalculo
	{
		// Token: 0x060014B7 RID: 5303 RVA: 0x00058DB0 File Offset: 0x00056FB0
		bool ICheckeadorDeCalculo.Check(ICalculoDeEstimulo calculo)
		{
			if (this.trigger.Check(calculo))
			{
				bool flag = this.condicion.Check(calculo);
				this.lastResult = (flag ? 1 : (-1));
				return flag;
			}
			throw new NotImplementedException("es el owner de esta condicion la q debe decidir cual es el resultado si el trigger falla");
		}

		// Token: 0x060014B8 RID: 5304 RVA: 0x00058DF1 File Offset: 0x00056FF1
		void IEditorCheckeadorDeCalculo.BeforeChecking()
		{
			this.lastResult = 0;
			Regla regla = this.trigger;
			if (regla != null)
			{
				((IEditorCheckeadorDeCalculo)regla).BeforeChecking();
			}
			Condicion condicion = this.condicion;
			if (condicion == null)
			{
				return;
			}
			((IEditorCheckeadorDeCalculo)condicion).BeforeChecking();
		}

		// Token: 0x040010E4 RID: 4324
		public Regla trigger = new Regla();

		// Token: 0x040010E5 RID: 4325
		public Condicion condicion = new Condicion();

		// Token: 0x040010E6 RID: 4326
		[HideInInspector]
		public int lastResult;
	}
}
