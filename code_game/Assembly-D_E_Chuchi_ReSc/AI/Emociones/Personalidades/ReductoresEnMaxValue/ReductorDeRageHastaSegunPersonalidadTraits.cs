using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Personalidades.ReductoresEnMaxValue.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Personalidades.ReductoresEnMaxValue
{
	// Token: 0x0200042F RID: 1071
	public class ReductorDeRageHastaSegunPersonalidadTraits : ReductorDeEmocionHastaSegunPersonalidadTraits
	{
		// Token: 0x17000620 RID: 1568
		// (get) Token: 0x060017D7 RID: 6103 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float modificadorGeneral
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x060017D8 RID: 6104 RVA: 0x000602E4 File Offset: 0x0005E4E4
		protected override TraitHumano trait
		{
			get
			{
				return TraitHumano.maxRageValueEndurance;
			}
		}
	}
}
