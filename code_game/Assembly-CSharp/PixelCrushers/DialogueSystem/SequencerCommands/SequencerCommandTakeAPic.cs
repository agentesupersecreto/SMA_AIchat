using System;
using Assets;
using Assets.Productos.Juegos.Reception.Scripts.Dependientes.Controlladores;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Controllers;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using Assets._ReusableScripts.Globales.Clases;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000025 RID: 37
	public class SequencerCommandTakeAPic : SequencerCommand
	{
		// Token: 0x060000BB RID: 187 RVA: 0x000083D4 File Offset: 0x000065D4
		public void Start()
		{
			this.m_maleHand = base.Sequencer.Speaker.GetComponentEnRoot(true);
			if (this.m_maleHand == null)
			{
				throw new ArgumentNullException("m_maleHand", "m_maleHand null reference.");
			}
			this.m_SelfPortraitCamera = base.Sequencer.Listener.GetComponentEnRoot(true);
			if (this.m_SelfPortraitCamera == null)
			{
				throw new ArgumentNullException("m_SelfPortraitCamera", "m_SelfPortraitCamera null reference.");
			}
			PlayerInputProxy instance = Singleton<PlayerInputProxy>.instance;
			this.m_movementActivatedMod = instance.activoModificableMovementOR.ObtenerModificadorNotNull(this);
			this.m_pregunta = Singleton<DialogueSystemCurrentLine>.instance.currentTextModified;
			SequencerCommandSetContinueModeTavo.SetContinueMode(false);
			this.m_unityUIDialogueUI = Singleton<MainDialogueSystemEvents>.instance.GetComponentInChildren<UnityUIDialogueUI>();
			if (this.m_unityUIDialogueUI != null)
			{
				this.m_unityUIDialogueUI.allowStealFocus = false;
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000084A4 File Offset: 0x000066A4
		public void Update()
		{
			if (this.m_stopNextFrames)
			{
				if (!this.m_maleHand.isActiveAndEnabled)
				{
					this.Clean();
					base.Stop();
				}
				return;
			}
			this.m_movementActivatedMod.valor.valor = true;
			InputProxyVirtuales toolActions = Singleton<PlayerInputProxy>.instance.toolActions;
			if (this.m_maleHand.tipoDePose != HandTipoDePose.phoneCam || !this.m_maleHand.isActiveAndEnabled)
			{
				this.m_setConfigToPhone = true;
				toolActions.emulatedTooled3 = true;
			}
			else
			{
				toolActions.emulatedTooled3 = false;
			}
			if (this.m_phone == null)
			{
				this.m_setConfigToPhone = true;
				this.m_phone = base.Sequencer.Speaker.GetComponentEnRoot(true);
			}
			if (this.m_phone != null && this.m_setConfigToPhone)
			{
				this.m_phone.onPortraitAcepted -= this.M_phone_onPortraitAcepted;
				this.m_phone.onPortraitCanceled -= this.M_phone_onPortraitCanceled;
				this.m_phone.PrepareForFemalePortrait();
				this.m_phone.onPortraitAcepted += this.M_phone_onPortraitAcepted;
				this.m_phone.onPortraitCanceled += this.M_phone_onPortraitCanceled;
				this.m_setConfigToPhone = false;
				this.m_canTakePic = true;
			}
			if (this.m_phone != null && this.m_canTakePic && Singleton<GeneralInputProxy>.instance.fire1.clickedUp && this.m_phone.TryTakeGenericPortrait(this.m_pregunta, true))
			{
				this.m_canTakePic = false;
			}
			if (this.m_canTakePicNextFrame)
			{
				this.m_canTakePicNextFrame = false;
				this.m_canTakePic = true;
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00008630 File Offset: 0x00006830
		private void M_phone_onPortraitCanceled(MalePhoneUserController obj)
		{
			this.m_canTakePicNextFrame = true;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00008639 File Offset: 0x00006839
		private void M_phone_onPortraitAcepted(Texture2D arg1, MalePhoneUserController arg2)
		{
			this.m_SelfPortraitCamera.OverrideNextPortrait(arg1);
			Singleton<PlayerInputProxy>.instance.toolActions.emulatedTooled3 = true;
			this.m_stopNextFrames = true;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00008660 File Offset: 0x00006860
		private void Clean()
		{
			Singleton<PlayerInputProxy>.instance.toolActions.emulatedTooled3 = false;
			SequencerCommandSetContinueModeTavo.SetContinueMode(true);
			if (this.m_unityUIDialogueUI != null)
			{
				this.m_unityUIDialogueUI.allowStealFocus = true;
			}
			this.m_movementActivatedMod.valor.valor = false;
			ModificadorDeBool movementActivatedMod = this.m_movementActivatedMod;
			if (movementActivatedMod != null)
			{
				movementActivatedMod.TryRemoverDeOwner(true);
			}
			this.m_phone.onPortraitAcepted -= this.M_phone_onPortraitAcepted;
			this.m_phone.onPortraitCanceled -= this.M_phone_onPortraitCanceled;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000086EF File Offset: 0x000068EF
		public void OnDestroy()
		{
			this.Clean();
		}

		// Token: 0x04000093 RID: 147
		private UnityUIDialogueUI m_unityUIDialogueUI;

		// Token: 0x04000094 RID: 148
		private HandControllerV2 m_maleHand;

		// Token: 0x04000095 RID: 149
		private ModificadorDeBool m_movementActivatedMod;

		// Token: 0x04000096 RID: 150
		private MalePhoneUserController m_phone;

		// Token: 0x04000097 RID: 151
		private bool m_setConfigToPhone;

		// Token: 0x04000098 RID: 152
		private bool m_canTakePic;

		// Token: 0x04000099 RID: 153
		private bool m_canTakePicNextFrame;

		// Token: 0x0400009A RID: 154
		private SelfPortraitCamera m_SelfPortraitCamera;

		// Token: 0x0400009B RID: 155
		private string m_pregunta;

		// Token: 0x0400009C RID: 156
		private bool m_stopNextFrames;
	}
}
