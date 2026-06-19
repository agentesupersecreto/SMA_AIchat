using System;
using Assets.Productos.Juegos.Reception.Scripts.Genetica.Globales;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Dependientes
{
	// Token: 0x020000B8 RID: 184
	[Obsolete("", true)]
	[RequireComponent(typeof(NPCsFinalesEsperandoPiscina))]
	public class NPCsFinalesCanLevelUpSegunCheatsConfig : CustomMonobehaviour
	{
		// Token: 0x0600041E RID: 1054 RVA: 0x00014BAC File Offset: 0x00012DAC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_NPCsFinalesEsperandoPiscina = base.GetComponent<NPCsFinalesEsperandoPiscina>();
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00014BC0 File Offset: 0x00012DC0
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_NPCsFinalesEsperandoPiscina.canDoALevelUp += this.M_NPCsFinalesEsperandoPiscina_canDoALevelUp;
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00014BDF File Offset: 0x00012DDF
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_NPCsFinalesEsperandoPiscina)
			{
				this.m_NPCsFinalesEsperandoPiscina.canDoALevelUp -= this.M_NPCsFinalesEsperandoPiscina_canDoALevelUp;
			}
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00014C0C File Offset: 0x00012E0C
		private void M_NPCsFinalesEsperandoPiscina_canDoALevelUp(ref bool canlevelUp, NPCsFinalesEsperandoPiscina sender)
		{
		}

		// Token: 0x040001CD RID: 461
		private NPCsFinalesEsperandoPiscina m_NPCsFinalesEsperandoPiscina;
	}
}
