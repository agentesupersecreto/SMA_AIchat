using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000006 RID: 6
	public static class __IConfiguracionParaTargetEXT
	{
		// Token: 0x0600000F RID: 15 RVA: 0x0000228C File Offset: 0x0000048C
		public static bool TryAplicarOnFemale<Ttarget>(this ConfiguracionParaTarget<Ttarget> @this, Ttarget target, FemaleAnimController controller)
		{
			bool flag;
			try
			{
				if (@this.Validar(target))
				{
					@this.AplicarOnFemale(target, controller);
					flag = true;
				}
				else
				{
					flag = false;
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Exepcion tratando de aplicar configuracion para " + typeof(Ttarget).Name);
				Debug.LogError(ex);
				flag = false;
			}
			return flag;
		}
	}
}
