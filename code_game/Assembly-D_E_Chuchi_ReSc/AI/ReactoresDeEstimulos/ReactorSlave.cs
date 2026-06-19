using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x020003A0 RID: 928
	public abstract class ReactorSlave<TPadre> : ReactorPadre where TPadre : ReactorSegundario
	{
		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x06001455 RID: 5205 RVA: 0x000582C2 File Offset: 0x000564C2
		public TPadre padre
		{
			get
			{
				return this.m_padre;
			}
		}

		// Token: 0x06001456 RID: 5206 RVA: 0x000582CC File Offset: 0x000564CC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_padre = base.transform.parent.GetComponent<TPadre>();
			if (this.m_padre == null)
			{
				throw new ArgumentNullException("m_padre", "m_padre null reference.");
			}
		}

		// Token: 0x040010BD RID: 4285
		private TPadre m_padre;
	}
}
