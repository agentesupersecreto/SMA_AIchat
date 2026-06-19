using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Checkers
{
	// Token: 0x020000F8 RID: 248
	public class UserInteraccionPuedeEjecutarse : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000940 RID: 2368 RVA: 0x0002A262 File Offset: 0x00028462
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			Interaccion componentInParent = base.GetComponentInParent<Interaccion>();
			if (componentInParent == null)
			{
				throw new ArgumentNullException("inter", "inter null reference.");
			}
			componentInParent.onPuedeEjecutarse += this.Inter_onPuedeEjecutarse;
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x0002A29C File Offset: 0x0002849C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			Interaccion componentInParent = base.GetComponentInParent<Interaccion>();
			if (componentInParent == null)
			{
				return;
			}
			componentInParent.onPuedeEjecutarse -= this.Inter_onPuedeEjecutarse;
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x0002A2D3 File Offset: 0x000284D3
		private void Inter_onPuedeEjecutarse(Interaccion.AbortingArgs args, object sender)
		{
			if (!this.puedeEjecutarse)
			{
				args.Abort();
			}
		}

		// Token: 0x040005C8 RID: 1480
		public bool puedeEjecutarse = true;
	}
}
