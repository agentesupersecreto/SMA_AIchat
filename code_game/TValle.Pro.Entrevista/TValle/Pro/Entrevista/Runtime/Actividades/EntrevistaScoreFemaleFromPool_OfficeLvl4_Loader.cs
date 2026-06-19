using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000131 RID: 305
	public sealed class EntrevistaScoreFemaleFromPool_OfficeLvl4_Loader : TValleActividadEnOfficeLoader<EntrevistaScoreFemaleFromPool>
	{
		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000ACD RID: 2765 RVA: 0x00039F1B File Offset: 0x0003811B
		protected override int officeLvl
		{
			get
			{
				return 4;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000ACE RID: 2766 RVA: 0x00039F1E File Offset: 0x0003811E
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.office4InterviewHeroina;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000ACF RID: 2767 RVA: 0x00039F22 File Offset: 0x00038122
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 750f;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000AD0 RID: 2768 RVA: 0x00039F29 File Offset: 0x00038129
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}
	}
}
