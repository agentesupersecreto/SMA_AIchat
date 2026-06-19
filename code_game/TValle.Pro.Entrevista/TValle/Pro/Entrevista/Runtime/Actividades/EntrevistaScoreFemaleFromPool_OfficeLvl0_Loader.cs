using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x0200012D RID: 301
	public sealed class EntrevistaScoreFemaleFromPool_OfficeLvl0_Loader : TValleActividadEnOfficeLoader<EntrevistaScoreFemaleFromPool>
	{
		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000AB9 RID: 2745 RVA: 0x00039EB8 File Offset: 0x000380B8
		protected override int officeLvl
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000ABA RID: 2746 RVA: 0x00039EBB File Offset: 0x000380BB
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.office0InterviewHeroina;
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000ABB RID: 2747 RVA: 0x00039EBF File Offset: 0x000380BF
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 50f;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000ABC RID: 2748 RVA: 0x00039EC6 File Offset: 0x000380C6
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}
	}
}
