using System;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x0200011E RID: 286
	public abstract class TValleActividadSavedWithinTheScene : TValleActividad
	{
		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000A0B RID: 2571 RVA: 0x00039042 File Offset: 0x00037242
		public static TValleActividadSavedWithinTheScene lastAwaken
		{
			get
			{
				return TValleActividadSavedWithinTheScene.m_lastAwaken;
			}
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x00039049 File Offset: 0x00037249
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			TValleActividadSavedWithinTheScene.m_lastAwaken = this;
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x00039057 File Offset: 0x00037257
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (TValleActividadSavedWithinTheScene.m_lastAwaken == this)
			{
				TValleActividadSavedWithinTheScene.m_lastAwaken = null;
			}
		}

		// Token: 0x0400054F RID: 1359
		private static TValleActividadSavedWithinTheScene m_lastAwaken;
	}
}
