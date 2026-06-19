using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000130 RID: 304
	public sealed class EntrevistaScoreFemaleFromPool_OfficeLvl3_Loader : TValleActividadEnOfficeLoader<EntrevistaScoreFemaleFromPool>
	{
		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000AC8 RID: 2760 RVA: 0x00039F02 File Offset: 0x00038102
		protected override int officeLvl
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000AC9 RID: 2761 RVA: 0x00039F05 File Offset: 0x00038105
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.office3InterviewHeroina;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000ACA RID: 2762 RVA: 0x00039F09 File Offset: 0x00038109
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000ACB RID: 2763 RVA: 0x00039F10 File Offset: 0x00038110
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}
	}
}
