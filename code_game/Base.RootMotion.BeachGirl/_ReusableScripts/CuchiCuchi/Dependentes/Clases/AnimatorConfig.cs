using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Clases
{
	// Token: 0x0200005B RID: 91
	[Serializable]
	public class AnimatorConfig : ConfiguracionParaTarget<Animator>
	{
		// Token: 0x060003F6 RID: 1014 RVA: 0x0001329D File Offset: 0x0001149D
		protected override void OnAplicarOnFemale(Animator target, FemaleAnimController controller)
		{
			target.applyRootMotion = this.applyRootMotion;
			target.cullingMode = this.cullingMode;
		}

		// Token: 0x0400029F RID: 671
		public bool applyRootMotion = true;

		// Token: 0x040002A0 RID: 672
		public AnimatorCullingMode cullingMode;
	}
}
