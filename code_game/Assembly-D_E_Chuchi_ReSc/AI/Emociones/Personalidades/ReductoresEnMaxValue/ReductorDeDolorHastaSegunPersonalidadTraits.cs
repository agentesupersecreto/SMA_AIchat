using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Personalidades.ReductoresEnMaxValue.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Personalidades.ReductoresEnMaxValue
{
	// Token: 0x0200042C RID: 1068
	public class ReductorDeDolorHastaSegunPersonalidadTraits : ReductorDeEmocionHastaSegunPersonalidadTraits
	{
		// Token: 0x1700061A RID: 1562
		// (get) Token: 0x060017CE RID: 6094 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float modificadorGeneral
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x1700061B RID: 1563
		// (get) Token: 0x060017CF RID: 6095 RVA: 0x0005D05A File Offset: 0x0005B25A
		protected override TraitHumano trait
		{
			get
			{
				return TraitHumano.maxPainValueEndurance;
			}
		}
	}
}
