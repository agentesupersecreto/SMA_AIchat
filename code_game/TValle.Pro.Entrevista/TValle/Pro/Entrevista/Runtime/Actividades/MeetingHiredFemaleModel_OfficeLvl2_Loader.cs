using System;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000134 RID: 308
	public class MeetingHiredFemaleModel_OfficeLvl2_Loader : TValleActividadEnOfficeLoader<EntrevistaScoreFemaleFromPool>
	{
		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000ADC RID: 2780 RVA: 0x00039F66 File Offset: 0x00038166
		protected override int officeLvl
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000ADD RID: 2781 RVA: 0x00039F69 File Offset: 0x00038169
		protected override EscenaDeRecepcionJuego mainSceneDeRecepcionJuego
		{
			get
			{
				return EscenaDeRecepcionJuego.office2MeetingHeroina;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000ADE RID: 2782 RVA: 0x00039F6D File Offset: 0x0003816D
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 120f;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000ADF RID: 2783 RVA: 0x00039F74 File Offset: 0x00038174
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return false;
			}
		}
	}
}
