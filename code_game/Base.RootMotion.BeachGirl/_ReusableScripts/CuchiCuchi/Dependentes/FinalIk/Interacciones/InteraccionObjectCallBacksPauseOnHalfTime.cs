using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x020000A3 RID: 163
	public abstract class InteraccionObjectCallBacksPauseOnHalfTime : InteraccionObjectCallBacks
	{
		// Token: 0x06000651 RID: 1617
		public abstract void OnPause();

		// Token: 0x06000652 RID: 1618
		public abstract void OnResume();

		// Token: 0x06000653 RID: 1619 RVA: 0x0001EF6C File Offset: 0x0001D16C
		protected override void SetCallBacks()
		{
			float num = base.CurrentInteractionObjectDuracion() * 0.5f;
			base.SetCallBack(new Action(this.OnPause), num).pause = true;
			base.SetCallBack(new Action(this.OnResume), num * 1.01f).pause = false;
		}
	}
}
