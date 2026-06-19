using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000133 RID: 307
	public class MeetingHiredFemaleModel_OfficeLvl1_Loader : TValleActividadEnOfficeLoader<EntrevistaScoreFemaleFromPool>
	{
		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000AD7 RID: 2775 RVA: 0x00039F4D File Offset: 0x0003814D
		protected override int officeLvl
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000AD8 RID: 2776 RVA: 0x00039F50 File Offset: 0x00038150
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.office1MeetingHeroina;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000AD9 RID: 2777 RVA: 0x00039F54 File Offset: 0x00038154
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000ADA RID: 2778 RVA: 0x00039F5B File Offset: 0x0003815B
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}
	}
}
