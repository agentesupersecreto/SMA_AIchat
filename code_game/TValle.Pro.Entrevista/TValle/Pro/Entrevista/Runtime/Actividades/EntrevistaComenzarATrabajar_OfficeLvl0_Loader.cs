using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders.Abstracts;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000128 RID: 296
	public sealed class EntrevistaComenzarATrabajar_OfficeLvl0_Loader : TValleActividadEnNuevoHorarioLoader<EntrevistaComenzarATrabajar>
	{
		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000AA0 RID: 2720 RVA: 0x00039E3C File Offset: 0x0003803C
		protected override int officeLvl
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000AA1 RID: 2721 RVA: 0x00039E3F File Offset: 0x0003803F
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.office0InterviewVacia;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000AA2 RID: 2722 RVA: 0x00039E43 File Offset: 0x00038043
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 50f;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000AA3 RID: 2723 RVA: 0x00039E4A File Offset: 0x0003804A
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}
	}
}
