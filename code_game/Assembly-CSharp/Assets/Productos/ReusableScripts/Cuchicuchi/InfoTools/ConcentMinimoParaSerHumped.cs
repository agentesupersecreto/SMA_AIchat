using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000051 RID: 81
	public class ConcentMinimoParaSerHumped : ConcentMinimoParaToques
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x0000DC0A File Offset: 0x0000BE0A
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x0000DC0D File Offset: 0x0000BE0D
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[]
				{
					ParteQuePuedeEstimular.piernas,
					ParteQuePuedeEstimular.torzo
				};
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060001AA RID: 426 RVA: 0x0000DC1E File Offset: 0x0000BE1E
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060001AB RID: 427 RVA: 0x0000DC21 File Offset: 0x0000BE21
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.tactil;
			}
		}
	}
}
