using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Estimulos
{
	// Token: 0x020001E4 RID: 484
	public sealed class SiendoGuiadoEnBonesPorCharacter : SiendoMovidoEnBoneGuiablePorCharacter
	{
		// Token: 0x06000B99 RID: 2969 RVA: 0x00038418 File Offset: 0x00036618
		public SiendoGuiadoEnBonesPorCharacter(BoneGuiable estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado)
			: base(estimulado, PrioridadesDeObjetoEstimulado)
		{
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06000B9A RID: 2970 RVA: 0x00038433 File Offset: 0x00036633
		protected override IReadOnlyList<ManipulacionDeBoneData> enFrameData
		{
			get
			{
				return base.estimulado.guiadosEnFrame;
			}
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x00038440 File Offset: 0x00036640
		protected override TipoDeEstimulo ObtenerEstimulo(Character estimulante)
		{
			return TipoDeEstimulo.guiandoBone;
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x00038057 File Offset: 0x00036257
		protected override Transform ObtenerTransformEstimulante(Character estimulante)
		{
			return estimulante.trasnformParaComunicarse;
		}
	}
}
