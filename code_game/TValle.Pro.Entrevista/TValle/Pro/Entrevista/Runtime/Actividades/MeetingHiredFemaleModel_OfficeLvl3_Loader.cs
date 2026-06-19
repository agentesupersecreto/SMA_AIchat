using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000135 RID: 309
	public class MeetingHiredFemaleModel_OfficeLvl3_Loader : TValleActividadEnOfficeLoader<EntrevistaScoreFemaleFromPool>
	{
		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06000AE1 RID: 2785 RVA: 0x00039F7F File Offset: 0x0003817F
		protected override int officeLvl
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000AE2 RID: 2786 RVA: 0x00039F82 File Offset: 0x00038182
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.office3MeetingHeroina;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000AE3 RID: 2787 RVA: 0x00039F86 File Offset: 0x00038186
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000AE4 RID: 2788 RVA: 0x00039F8D File Offset: 0x0003818D
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}
	}
}
