using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Estimulos
{
	// Token: 0x020001E3 RID: 483
	public sealed class SiendoManipuladoEnBonesPorCharacter : SiendoMovidoEnBoneGuiablePorCharacter
	{
		// Token: 0x06000B95 RID: 2965 RVA: 0x00038418 File Offset: 0x00036618
		public SiendoManipuladoEnBonesPorCharacter(BoneGuiable estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado)
			: base(estimulado, PrioridadesDeObjetoEstimulado)
		{
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x06000B96 RID: 2966 RVA: 0x00038422 File Offset: 0x00036622
		protected override IReadOnlyList<ManipulacionDeBoneData> enFrameData
		{
			get
			{
				return base.estimulado.manipuladosEnFrame;
			}
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x0003842F File Offset: 0x0003662F
		protected override TipoDeEstimulo ObtenerEstimulo(Character estimulante)
		{
			return TipoDeEstimulo.manipulandoBone;
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x00038074 File Offset: 0x00036274
		protected override Transform ObtenerTransformEstimulante(Character estimulante)
		{
			return estimulante.trasnformParaManipular;
		}
	}
}
