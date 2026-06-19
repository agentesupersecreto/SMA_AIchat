using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000136 RID: 310
	public class MeetingHiredFemaleModel_OfficeLvl4_Loader : TValleActividadEnOfficeLoader<EntrevistaScoreFemaleFromPool>
	{
		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000AE6 RID: 2790 RVA: 0x00039F98 File Offset: 0x00038198
		protected override int officeLvl
		{
			get
			{
				return 4;
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000AE7 RID: 2791 RVA: 0x00039F9B File Offset: 0x0003819B
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.office4MeetingHeroina;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000AE8 RID: 2792 RVA: 0x00039F9F File Offset: 0x0003819F
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 750f;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000AE9 RID: 2793 RVA: 0x00039FA6 File Offset: 0x000381A6
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}
	}
}
