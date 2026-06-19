using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000004 RID: 4
	public abstract class ConfiguracionParaTarget<Ttarget>
	{
		// Token: 0x06000008 RID: 8 RVA: 0x0000220C File Offset: 0x0000040C
		public bool TryAplicarOnFemale(Ttarget target, FemaleAnimController controller)
		{
			bool flag;
			try
			{
				if (this.Validar(target))
				{
					this.OnAplicarOnFemale(target, controller);
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

		// Token: 0x06000009 RID: 9 RVA: 0x0000226C File Offset: 0x0000046C
		public void AplicarOnFemale(Ttarget target, FemaleAnimController controller)
		{
			this.TryAplicarOnFemale(target, controller);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002277 File Offset: 0x00000477
		public virtual bool Validar(Ttarget target)
		{
			return target != null;
		}

		// Token: 0x0600000B RID: 11
		protected abstract void OnAplicarOnFemale(Ttarget target, FemaleAnimController controller);
	}
}
