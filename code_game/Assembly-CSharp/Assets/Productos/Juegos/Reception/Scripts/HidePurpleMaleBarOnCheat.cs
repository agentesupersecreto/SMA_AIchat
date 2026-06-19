using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts
{
	// Token: 0x02000097 RID: 151
	public class HidePurpleMaleBarOnCheat : CustomMonobehaviour
	{
		// Token: 0x06000304 RID: 772 RVA: 0x00010D48 File Offset: 0x0000EF48
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_checker = new CoroutineCapsule(this.CheckRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00010D75 File Offset: 0x0000EF75
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_lastState = 0;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00010D88 File Offset: 0x0000EF88
		private void ChangeAll(bool enabled)
		{
			for (int i = 0; i < this.m_Components.Length; i++)
			{
				this.m_Components[i].enabled = enabled;
			}
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00010DB6 File Offset: 0x0000EFB6
		private IEnumerator CheckRutine()
		{
			yield return new WaitForSeconds(Random.value * 3f);
			WaitForSeconds w = new WaitForSeconds(10f);
			for (;;)
			{
				if (!Singleton<ConfiguracionGeneralDeCheats>.IsInScene)
				{
					if (this.m_lastState != 1)
					{
						this.ChangeAll(true);
						this.m_lastState = 1;
					}
				}
				else if (!Singleton<ConfiguracionGeneralDeCheats>.instance.heroResisteEyaculaciones)
				{
					if (this.m_lastState != 1)
					{
						this.ChangeAll(true);
						this.m_lastState = 1;
					}
				}
				else if (this.m_lastState != -1)
				{
					this.ChangeAll(false);
					this.m_lastState = -1;
				}
				yield return w;
			}
			yield break;
		}

		// Token: 0x0400014F RID: 335
		[SerializeField]
		private Behaviour[] m_Components = new Behaviour[0];

		// Token: 0x04000150 RID: 336
		[SerializeField]
		[ReadOnlyUI]
		private int m_lastState;

		// Token: 0x04000151 RID: 337
		private CoroutineCapsule m_checker;
	}
}
