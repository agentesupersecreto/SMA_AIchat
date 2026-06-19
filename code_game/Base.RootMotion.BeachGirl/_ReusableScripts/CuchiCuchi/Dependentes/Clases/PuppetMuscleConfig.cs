using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using RootMotion.Dynamics;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Clases
{
	// Token: 0x0200005E RID: 94
	[Serializable]
	public class PuppetMuscleConfig : ConfiguracionParaTarget<Muscle>
	{
		// Token: 0x060003FF RID: 1023 RVA: 0x0001379A File Offset: 0x0001199A
		protected override void OnAplicarOnFemale(Muscle target, FemaleAnimController controller)
		{
			this.props.AplicarOnFemale(target.props, controller);
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x000137AE File Offset: 0x000119AE
		public void CopiarDesde(PuppetMuscleConfig other)
		{
			this.props.CopiarDesde(other.props);
		}

		// Token: 0x040002BC RID: 700
		public MusclePropsConfig props = new MusclePropsConfig();
	}
}
