using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000023 RID: 35
	public class SequencerCommandInputPercentageModalWindow : SequencerCommand
	{
		// Token: 0x060000B2 RID: 178 RVA: 0x00007D48 File Offset: 0x00005F48
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
			this.m_modal.minValue = base.GetParameterAsFloat(2, 1f);
			this.m_modal.maxValue = base.GetParameterAsFloat(3, 100f);
			this.m_modal.incremento = base.GetParameterAsFloat(4, 1f);
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
					Debug.LogError("No variable for input percentage was set");
				}
				else
				{
					DialogueLua.SetVariable(parameter2, num2);
				}
				this.m_moneyWasInput = true;
			});
			this.m_modal.cancelar.interactable = false;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00007EEC File Offset: 0x000060EC
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

		// Token: 0x060000B4 RID: 180 RVA: 0x00007F4C File Offset: 0x0000614C
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

		// Token: 0x0400008A RID: 138
		private NumberInputDialog m_modal;

		// Token: 0x0400008B RID: 139
		private bool m_moneyWasInput;

		// Token: 0x0400008C RID: 140
		private UnityUIDialogueUI m_unityUIDialogueUI;
	}
}
