using System;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x0200011C RID: 284
	public abstract class TValleActividadLoader : ActividadScenesLoader, IActividadLoader
	{
		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000A04 RID: 2564
		public abstract bool noReciclarScenas { get; }

		// Token: 0x06000A05 RID: 2565 RVA: 0x00038FFC File Offset: 0x000371FC
		public Actividad ProduceActividad()
		{
			Actividad actividadInstance = this.GetActividadInstance();
			if (actividadInstance == null)
			{
				throw new ArgumentNullException("actividad", "actividad null reference.");
			}
			actividadInstance.OnLoadedByLoader();
			return actividadInstance;
		}

		// Token: 0x06000A06 RID: 2566
		protected abstract Actividad GetActividadInstance();

		// Token: 0x06000A08 RID: 2568 RVA: 0x0003902B File Offset: 0x0003722B
		GameObject IActividadLoader.get_gameObject()
		{
			return base.gameObject;
		}
	}
}
