using System;
using System.Collections;
using Assets.Productos.Juegos.Reception.Scripts.Genetica.Eventos;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts
{
	// Token: 0x02000096 RID: 150
	[Obsolete("", true)]
	public class EnableComponentsSiNivelAlcanzado : CustomMonobehaviour
	{
		// Token: 0x060002FF RID: 767 RVA: 0x00010CAD File Offset: 0x0000EEAD
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_checker = new CoroutineCapsule(this.CheckRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00010CDA File Offset: 0x0000EEDA
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_lastState = 0;
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00010CEC File Offset: 0x0000EEEC
		private void ChangeAll(bool enabled)
		{
			for (int i = 0; i < this.m_Components.Length; i++)
			{
				this.m_Components[i].enabled = enabled;
			}
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00010D1A File Offset: 0x0000EF1A
		private IEnumerator CheckRutine()
		{
			yield return new WaitForSeconds(Random.value * 3f);
			WaitForSeconds w = new WaitForSeconds(20f);
			for (;;)
			{
				if (!Singleton<PiscinasDeEventosDeEntrevista>.IsInScene)
				{
					if (this.m_lastState != 1)
					{
						this.ChangeAll(true);
						this.m_lastState = 1;
					}
				}
				else if ((float)Singleton<PiscinasDeEventosDeEntrevista>.instance.GetNivelIgnorandoInicial() >= this.nivelRequerido)
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

		// Token: 0x0400014B RID: 331
		public float nivelRequerido = 999f;

		// Token: 0x0400014C RID: 332
		[SerializeField]
		private Behaviour[] m_Components = new Behaviour[0];

		// Token: 0x0400014D RID: 333
		[SerializeField]
		[ReadOnlyUI]
		private int m_lastState;

		// Token: 0x0400014E RID: 334
		private CoroutineCapsule m_checker;
	}
}
