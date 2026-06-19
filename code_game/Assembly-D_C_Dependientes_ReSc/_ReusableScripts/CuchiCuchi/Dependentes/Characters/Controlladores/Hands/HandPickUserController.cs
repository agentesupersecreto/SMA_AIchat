using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Globales.Clases;
using Assets._ReusableScripts.Globales.Updater;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands
{
	// Token: 0x0200026B RID: 619
	[RequireComponent(typeof(HandControllerV2))]
	[RequireComponent(typeof(HandPickController))]
	public sealed class HandPickUserController : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x0600105A RID: 4186 RVA: 0x0000B284 File Offset: 0x00009484
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x0004BC76 File Offset: 0x00049E76
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_HandPickController = base.GetComponent<HandPickController>();
			this.m_HandControllerV2 = base.GetComponent<HandControllerV2>();
			base.SetYieldStart();
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x0004BC9C File Offset: 0x00049E9C
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (!this.m_HandPickController.isStared)
			{
				yield return null;
			}
			this.m_cerrandoMano = this.m_HandPickController.r.cerrandoManoOR.ObtenerModificadorNotNull(this);
			yield break;
		}

		// Token: 0x0600105D RID: 4189 RVA: 0x0004BCAB File Offset: 0x00049EAB
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_HandPickController != null)
			{
				this.m_HandPickController.velocidadMod = 1f;
			}
			if (this.m_cerrandoMano != null)
			{
				this.m_cerrandoMano.valor.valor = false;
			}
		}

		// Token: 0x0600105E RID: 4190 RVA: 0x0004BCEC File Offset: 0x00049EEC
		public sealed override void OnUpdateEvent1()
		{
			if (this.m_HandControllerV2.tipoDePose != HandTipoDePose.massage || !this.m_HandControllerV2.enabled)
			{
				this.m_HandPickController.velocidadMod = 1f;
				return;
			}
			InputProxyFiring fire = Singleton<PlayerInputProxy>.instance.fire1;
			this.m_cerrandoMano.valor.valor = fire.heldDown;
			if (Singleton<ConfiguracionGeneralDeInputs>.instance.isCursorOverUIElement)
			{
				return;
			}
			InputProxyVirtuales toolMovement = Singleton<PlayerInputProxy>.instance.toolMovement;
			float num = 1f;
			if (toolMovement.goingFaster)
			{
				num *= 3f;
			}
			if (toolMovement.goingSlower)
			{
				num /= 3f;
			}
			this.m_HandPickController.velocidadMod = num;
			float num2;
			if (fire.heldDown)
			{
				if (this.m_HandPickController.r.tomandoObjetoPhysico)
				{
					this.m_suavizarSiToco.ApplyNext(0.333f);
					num2 = this.m_HandPickController.r.w;
				}
				else
				{
					num2 = 1f;
				}
			}
			else
			{
				num2 = 0f;
			}
			if (this.m_suavizarSiToco.isOn && num2 > 0f)
			{
				num *= 0.05f;
				this.m_HandPickController.velocidadMod *= 0.05f;
			}
			this.m_HandPickController.r.w = Mathf.MoveTowards(this.m_HandPickController.r.w, num2, Time.deltaTime * this.config.velocidad * num);
		}

		// Token: 0x04000BCE RID: 3022
		public HandPickUserController.Config config = new HandPickUserController.Config();

		// Token: 0x04000BCF RID: 3023
		private HandControllerV2 m_HandControllerV2;

		// Token: 0x04000BD0 RID: 3024
		private HandPickController m_HandPickController;

		// Token: 0x04000BD1 RID: 3025
		private CoolDown m_suavizarSiToco = new CoolDown();

		// Token: 0x04000BD2 RID: 3026
		[SerializeField]
		private ModificadorDeBool m_cerrandoMano;

		// Token: 0x0200026C RID: 620
		[Serializable]
		public class Config
		{
			// Token: 0x04000BD3 RID: 3027
			public float velocidad = 2f;
		}
	}
}
