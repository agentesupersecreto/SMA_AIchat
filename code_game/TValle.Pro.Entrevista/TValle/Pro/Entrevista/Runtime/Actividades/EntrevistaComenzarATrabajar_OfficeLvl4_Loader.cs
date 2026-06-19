using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders.Abstracts;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x0200012C RID: 300
	public sealed class EntrevistaComenzarATrabajar_OfficeLvl4_Loader : TValleActividadEnNuevoHorarioLoader<EntrevistaComenzarATrabajar>
	{
		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000AB4 RID: 2740 RVA: 0x00039E9F File Offset: 0x0003809F
		protected override int officeLvl
		{
			get
			{
				return 4;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000AB5 RID: 2741 RVA: 0x00039EA2 File Offset: 0x000380A2
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.office4InterviewVacia;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000AB6 RID: 2742 RVA: 0x00039EA6 File Offset: 0x000380A6
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 750f;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000AB7 RID: 2743 RVA: 0x00039EAD File Offset: 0x000380AD
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}
	}
}
