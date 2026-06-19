using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders.Abstracts;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x0200012B RID: 299
	public sealed class EntrevistaComenzarATrabajar_OfficeLvl3_Loader : TValleActividadEnNuevoHorarioLoader<EntrevistaComenzarATrabajar>
	{
		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000AAF RID: 2735 RVA: 0x00039E86 File Offset: 0x00038086
		protected override int officeLvl
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000AB0 RID: 2736 RVA: 0x00039E89 File Offset: 0x00038089
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.office3InterviewVacia;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000AB1 RID: 2737 RVA: 0x00039E8D File Offset: 0x0003808D
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000AB2 RID: 2738 RVA: 0x00039E94 File Offset: 0x00038094
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}
	}
}
