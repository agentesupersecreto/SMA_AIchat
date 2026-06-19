using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders.Abstracts;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000129 RID: 297
	public sealed class EntrevistaComenzarATrabajar_OfficeLvl1_Loader : TValleActividadEnNuevoHorarioLoader<EntrevistaComenzarATrabajar>
	{
		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000AA5 RID: 2725 RVA: 0x00039E55 File Offset: 0x00038055
		protected override int officeLvl
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000AA6 RID: 2726 RVA: 0x00039E58 File Offset: 0x00038058
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.office1InterviewVacia;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000AA7 RID: 2727 RVA: 0x00039E5B File Offset: 0x0003805B
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000AA8 RID: 2728 RVA: 0x00039E62 File Offset: 0x00038062
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}
	}
}
