using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas
{
	// Token: 0x020003B5 RID: 949
	[Serializable]
	public class CondicionesConTriggerParallel : CondicionesConTrigger
	{
		// Token: 0x060014BE RID: 5310 RVA: 0x00058EB8 File Offset: 0x000570B8
		protected override bool Check(ICalculoDeEstimulo calculo)
		{
			bool flag = true;
			for (int i = 0; i < this.condiciones.Count; i++)
			{
				CondicionConTrigger condicionConTrigger = this.condiciones[i];
				Regla trigger = condicionConTrigger.trigger;
				if (((trigger != null) ? new bool?(trigger.Check(calculo)) : null).GetValueOrDefault())
				{
					Condicion condicion = condicionConTrigger.condicion;
					flag = ((condicion != null) ? new bool?(condicion.Check(calculo)) : null).GetValueOrDefault(true);
					break;
				}
			}
			return flag;
		}
	}
}
