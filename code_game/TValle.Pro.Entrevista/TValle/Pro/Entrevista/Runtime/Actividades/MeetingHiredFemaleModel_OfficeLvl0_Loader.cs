using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000132 RID: 306
	public class MeetingHiredFemaleModel_OfficeLvl0_Loader : TValleActividadEnOfficeLoader<EntrevistaScoreFemaleFromPool>
	{
		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x00039F34 File Offset: 0x00038134
		protected override int officeLvl
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000AD3 RID: 2771 RVA: 0x00039F37 File Offset: 0x00038137
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.office0MeetingHeroina;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000AD4 RID: 2772 RVA: 0x00039F3B File Offset: 0x0003813B
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 50f;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000AD5 RID: 2773 RVA: 0x00039F42 File Offset: 0x00038142
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}
	}
}
