using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000127 RID: 295
	public class DesignerFemaleModel_OfficeLvl1_Loader : TValleActividadEnOfficeJustGeometryLoader<FemaleDesignerActivity>
	{
		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000A99 RID: 2713 RVA: 0x00039E0C File Offset: 0x0003800C
		protected override int officeLvl
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000A9A RID: 2714 RVA: 0x00039E0F File Offset: 0x0003800F
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.entrevistaSingle;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000A9B RID: 2715 RVA: 0x00039E12 File Offset: 0x00038012
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000A9C RID: 2716 RVA: 0x00039E19 File Offset: 0x00038019
		protected override EscenaDeRecepcionJuego[] postExtraScenes
		{
			get
			{
				return DesignerFemaleModel_OfficeLvl1_Loader.PostExtraScenes;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000A9D RID: 2717 RVA: 0x00039E20 File Offset: 0x00038020
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0400056B RID: 1387
		private static readonly EscenaDeRecepcionJuego[] PostExtraScenes = new EscenaDeRecepcionJuego[] { EscenaDeRecepcionJuego.designerGamePlayLogic };
	}
}
