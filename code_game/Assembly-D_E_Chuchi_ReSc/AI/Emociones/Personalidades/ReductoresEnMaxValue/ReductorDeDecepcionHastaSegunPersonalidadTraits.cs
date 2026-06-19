using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Personalidades.ReductoresEnMaxValue.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Personalidades.ReductoresEnMaxValue
{
	// Token: 0x0200042B RID: 1067
	public class ReductorDeDecepcionHastaSegunPersonalidadTraits : ReductorDeEmocionHastaSegunPersonalidadTraits
	{
		// Token: 0x17000618 RID: 1560
		// (get) Token: 0x060017CB RID: 6091 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float modificadorGeneral
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x17000619 RID: 1561
		// (get) Token: 0x060017CC RID: 6092 RVA: 0x000602D4 File Offset: 0x0005E4D4
		protected override TraitHumano trait
		{
			get
			{
				return TraitHumano.maxDeceptionValueEndurance;
			}
		}
	}
}
