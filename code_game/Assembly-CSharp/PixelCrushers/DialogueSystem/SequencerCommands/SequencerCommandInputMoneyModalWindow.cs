using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000022 RID: 34
	public class SequencerCommandInputMoneyModalWindow : SequencerCommand
	{
		// Token: 0x060000AD RID: 173 RVA: 0x00007A8C File Offset: 0x00005C8C
		public void Start()
		{
			string currentTextModified = Singleton<DialogueSystemCurrentLine>.instance.currentTextModified;
			this.m_unityUIDialogueUI = Singleton<MainDialogueSystemEvents>.instance.GetComponentInChildren<UnityUIDialogueUI>();
			string parameter = base.GetParameter(0, null);
			this.m_modal = Singleton<ModalWindow>.instance.MostrarNumberInputDialog();
			if (!string.IsNullOrWhiteSpace(currentTextModified))
			{
				this.m_modal.pregunta.text = currentTextModified;
			}
			this.m_modal.minValue = base.GetParameterAsFloat(2, 10f);
			this.m_modal.maxValue = base.GetParameterAsFloat(3, 1000000f);
			this.m_modal.incremento = base.GetParameterAsFloat(4, 5f);
			this.m_modal.decimalCount = base.GetParameterAsInt(5, 0);
			this.m_modal.maxCoolDown = 0.666f;
			this.m_modal.minCoolDown = 0.05f;
			this.m_modal.coolDownChange = 0.2f;
			float num = this.m_modal.minValue;
			if (!string.IsNullOrWhiteSpace(parameter))
			{
				Lua.Result variable = DialogueLua.GetVariable(parameter);
				if (variable.HasReturnValue)
				{
					num = variable.AsFloat;
				}
				if (num < this.m_modal.minValue)
				{
					num = this.m_modal.minValue;
				}
			}
			if (num != 0f && num >= this.m_modal.minValue)
			{
				this.m_modal.SetValor(num);
			}
			SequencerCommandSetContinueModeTavo.SetContinueMode(false);
			this.m_moneyWasInput = false;
			if (this.m_unityUIDialogueUI != null)
			{
				this.m_unityUIDialogueUI.allowStealFocus = false;
			}
			this.m_modal.aceptar.onClick.AddListener(delegate
			{
				Singleton<ModalWindow>.instance.Clear(this.m_modal);
				float num2 = this.m_modal.ObtenerValor();
				string parameter2 = base.GetParameter(1, null);
				if (string.IsNullOrWhiteSpace(parameter2))
				{
					Debug.LogError("No variable for input money was set");
				}
				else
				{
					DialogueLua.SetVariable(parameter2, num2);
				}
				this.m_moneyWasInput = true;
			});
			this.m_modal.cancelar.interactable = false;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00007C30 File Offset: 0x00005E30
		public void Update()
		{
			if (this.m_moneyWasInput)
			{
				if (this.m_modal != null)
				{
					Singleton<ModalWindow>.instance.Clear(this.m_modal);
				}
				this.m_modal = null;
				SequencerCommandSetContinueModeTavo.SetContinueMode(true);
				if (this.m_unityUIDialogueUI != null)
				{
					this.m_unityUIDialogueUI.allowStealFocus = true;
				}
				base.Stop();
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00007C90 File Offset: 0x00005E90
		public void OnDestroy()
		{
			if (this.m_modal != null)
			{
				Singleton<ModalWindow>.instance.Clear(this.m_modal);
			}
			if (!SequencerCommandSetContinueModeTavo.GetContinueMode())
			{
				SequencerCommandSetContinueModeTavo.SetContinueMode(true);
			}
			if (this.m_unityUIDialogueUI != null)
			{
				this.m_unityUIDialogueUI.allowStealFocus = true;
			}
		}

		// Token: 0x04000087 RID: 135
		private NumberInputDialog m_modal;

		// Token: 0x04000088 RID: 136
		private bool m_moneyWasInput;

		// Token: 0x04000089 RID: 137
		private UnityUIDialogueUI m_unityUIDialogueUI;
	}
}
