using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x0200012F RID: 303
	public sealed class EntrevistaScoreFemaleFromPool_OfficeLvl2_Loader : TValleActividadEnOfficeLoader<EntrevistaScoreFemaleFromPool>
	{
		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000AC3 RID: 2755 RVA: 0x00039EE9 File Offset: 0x000380E9
		protected override int officeLvl
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000AC4 RID: 2756 RVA: 0x00039EEC File Offset: 0x000380EC
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.office2InterviewHeroina;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000AC5 RID: 2757 RVA: 0x00039EF0 File Offset: 0x000380F0
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 120f;
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000AC6 RID: 2758 RVA: 0x00039EF7 File Offset: 0x000380F7
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}
	}
}
