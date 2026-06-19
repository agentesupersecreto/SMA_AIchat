using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Clases
{
	// Token: 0x02000060 RID: 96
	[Serializable]
	public class PuppetMuscleConfigPar
	{
		// Token: 0x06000409 RID: 1033 RVA: 0x00013E3B File Offset: 0x0001203B
		public void CopiarDesde(PuppetMuscleConfigPar other)
		{
			this.l.CopiarDesde(other.l);
			this.r.CopiarDesde(other.r);
		}

		// Token: 0x040002C9 RID: 713
		public PuppetMuscleConfig l = new PuppetMuscleConfig();

		// Token: 0x040002CA RID: 714
		public PuppetMuscleConfig r = new PuppetMuscleConfig();
	}
}
