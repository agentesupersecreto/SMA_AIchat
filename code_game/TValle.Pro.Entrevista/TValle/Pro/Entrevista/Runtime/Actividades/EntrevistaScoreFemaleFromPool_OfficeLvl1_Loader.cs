using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x0200012E RID: 302
	public sealed class EntrevistaScoreFemaleFromPool_OfficeLvl1_Loader : TValleActividadEnOfficeLoader<EntrevistaScoreFemaleFromPool>
	{
		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000ABE RID: 2750 RVA: 0x00039ED1 File Offset: 0x000380D1
		protected override int officeLvl
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000ABF RID: 2751 RVA: 0x00039ED4 File Offset: 0x000380D4
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.office1InterviewHeroina;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000AC0 RID: 2752 RVA: 0x00039ED7 File Offset: 0x000380D7
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000AC1 RID: 2753 RVA: 0x00039EDE File Offset: 0x000380DE
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}
	}
}
