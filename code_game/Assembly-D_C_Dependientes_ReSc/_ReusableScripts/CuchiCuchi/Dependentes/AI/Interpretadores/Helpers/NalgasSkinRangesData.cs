using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Helpers
{
	// Token: 0x020003A4 RID: 932
	[Serializable]
	public class NalgasSkinRangesData : SkinRangesDataBase, INalgasRangesParaInterpretadores, IRangesParaInterpretadores
	{
		// Token: 0x1700058E RID: 1422
		// (get) Token: 0x060017B8 RID: 6072 RVA: 0x0006FD0F File Offset: 0x0006DF0F
		protected override IReadOnlyList<ParteDelCuerpoHumano> partesDeInteraccion
		{
			get
			{
				return ParteDelCuerpoHumanoHelper.partesDeInteraccionNalgas;
			}
		}
	}
}
