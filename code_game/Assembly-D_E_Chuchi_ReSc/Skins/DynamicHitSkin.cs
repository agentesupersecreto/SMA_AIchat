using System;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200004A RID: 74
	public class DynamicHitSkin : ManualDynamicHitSkin
	{
		// Token: 0x06000245 RID: 581 RVA: 0x00008341 File Offset: 0x00006541
		protected override void Scheduling()
		{
			base.Scheduling();
			if (this.updateCollider)
			{
				base.flagCanBake = true;
			}
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00008358 File Offset: 0x00006558
		protected override CustomMonobehaviourBotonConfig Boton6()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Actualizar UpdateCollidersEvent",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00008371 File Offset: 0x00006571
		protected sealed override void OnAplicar6()
		{
			base.OnAplicar6();
			base.ReSubscribeToGlobalUpdater();
		}

		// Token: 0x04000117 RID: 279
		public bool updateCollider = true;
	}
}
