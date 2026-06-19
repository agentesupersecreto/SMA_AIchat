using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Personalidades.ReductoresEnMaxValue.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Personalidades.ReductoresEnMaxValue
{
	// Token: 0x0200042E RID: 1070
	public class ReductorDePlacerHastaSegunPersonalidadTraits : ReductorDeEmocionHastaSegunPersonalidadTraits
	{
		// Token: 0x1700061E RID: 1566
		// (get) Token: 0x060017D4 RID: 6100 RVA: 0x0005F8C5 File Offset: 0x0005DAC5
		protected override float modificadorGeneral
		{
			get
			{
				return 0.5f;
			}
		}

		// Token: 0x1700061F RID: 1567
		// (get) Token: 0x060017D5 RID: 6101 RVA: 0x00004F18 File Offset: 0x00003118
		protected override TraitHumano trait
		{
			get
			{
				return TraitHumano.maxPlacerValueEndurance;
			}
		}
	}
}
