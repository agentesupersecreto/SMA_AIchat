using System;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x0200011D RID: 285
	public abstract class TValleActividadSavedWihtinTheSceneLoader<T_Actividad> : TValleActividadLoader where T_Actividad : TValleActividadSavedWithinTheScene
	{
		// Token: 0x06000A09 RID: 2569 RVA: 0x00039033 File Offset: 0x00037233
		protected override Actividad GetActividadInstance()
		{
			return TValleActividadSavedWithinTheScene.lastAwaken;
		}
	}
}
