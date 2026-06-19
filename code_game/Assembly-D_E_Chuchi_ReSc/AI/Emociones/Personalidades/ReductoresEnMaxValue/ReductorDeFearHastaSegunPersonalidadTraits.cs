using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Personalidades.ReductoresEnMaxValue.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Personalidades.ReductoresEnMaxValue
{
	// Token: 0x0200042D RID: 1069
	public class ReductorDeFearHastaSegunPersonalidadTraits : ReductorDeEmocionHastaSegunPersonalidadTraits
	{
		// Token: 0x1700061C RID: 1564
		// (get) Token: 0x060017D1 RID: 6097 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float modificadorGeneral
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x1700061D RID: 1565
		// (get) Token: 0x060017D2 RID: 6098 RVA: 0x000602E0 File Offset: 0x0005E4E0
		protected override TraitHumano trait
		{
			get
			{
				return TraitHumano.maxFearValueEndurance;
			}
		}
	}
}
