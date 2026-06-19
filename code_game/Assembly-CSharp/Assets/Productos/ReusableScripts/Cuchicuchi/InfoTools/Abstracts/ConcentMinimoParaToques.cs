using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts
{
	// Token: 0x0200007B RID: 123
	public abstract class ConcentMinimoParaToques : ConcentMinimoPara
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000238 RID: 568 RVA: 0x0000E385 File Offset: 0x0000C585
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.tactil;
			}
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000E388 File Offset: 0x0000C588
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
