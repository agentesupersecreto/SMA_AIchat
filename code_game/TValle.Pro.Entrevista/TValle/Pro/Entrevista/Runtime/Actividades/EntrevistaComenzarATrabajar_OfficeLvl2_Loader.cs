using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders.Abstracts;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x0200012A RID: 298
	public sealed class EntrevistaComenzarATrabajar_OfficeLvl2_Loader : TValleActividadEnNuevoHorarioLoader<EntrevistaComenzarATrabajar>
	{
		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000AAA RID: 2730 RVA: 0x00039E6D File Offset: 0x0003806D
		protected override int officeLvl
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000AAB RID: 2731 RVA: 0x00039E70 File Offset: 0x00038070
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.office2InterviewVacia;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000AAC RID: 2732 RVA: 0x00039E74 File Offset: 0x00038074
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 120f;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000AAD RID: 2733 RVA: 0x00039E7B File Offset: 0x0003807B
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}
	}
}
