using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Globales.Updater;
using PixelCrushers.DialogueSystem;
using TValleCustomClases;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000022 RID: 34
	public class UIButtonKeyTriggerTValle : MonoBehaviour
	{
		// Token: 0x06000124 RID: 292 RVA: 0x0000631B File Offset: 0x0000451B
		private void Awake()
		{
			this.m_ActivateDelayedHandler = new Action(this.ActivateDelayed);
			this.button = base.GetComponent<Button>();
			if (this.button == null)
			{
				base.enabled = false;
			}
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00006350 File Offset: 0x00004550
		private void OnEnable()
		{
			if (!GlobalUpdater.IsInScene)
			{
				return;
			}
			GlobalUpdater instancia = GlobalUpdater.instancia;
			instancia.CancelarInvocacionPorDelegado(this.m_ActivateDelayedHandler);
			if (this.button == null)
			{
				return;
			}
			this.button.interactable = false;
			instancia.Invokar(this.m_ActivateDelayedHandler, this.activateDelay);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000063A6 File Offset: 0x000045A6
		private void OnDisable()
		{
			if (!GlobalUpdater.IsInScene)
			{
				return;
			}
			GlobalUpdater.instancia.CancelarInvocacionPorDelegado(this.m_ActivateDelayedHandler);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000063C1 File Offset: 0x000045C1
		private void ActivateDelayed()
		{
			if (this.button == null)
			{
				return;
			}
			this.button.interactable = true;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000063E0 File Offset: 0x000045E0
		private void Update()
		{
			if (DialogueManager.IsDialogueSystemInputDisabled())
			{
				return;
			}
			if (EventSystem.current == null)
			{
				return;
			}
			if (this.m_coolDown.isOn || !this.button.isActiveAndEnabled || !this.button.interactable)
			{
				return;
			}
			if (Singleton<GeneralInputProxy>.instance.keysUI.Sostenida(this.key))
			{
				this.m_coolDown.ApplyNext(this.coolDown);
				PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
				ExecuteEvents.Execute<ISubmitHandler>(this.button.gameObject, pointerEventData, ExecuteEvents.submitHandler);
				return;
			}
			if (!string.IsNullOrEmpty(this.buttonName))
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x0400009A RID: 154
		public KeyCode key;

		// Token: 0x0400009B RID: 155
		public string buttonName = string.Empty;

		// Token: 0x0400009C RID: 156
		public float coolDown = 0.125f;

		// Token: 0x0400009D RID: 157
		public float activateDelay = 0.125f;

		// Token: 0x0400009E RID: 158
		private Button button;

		// Token: 0x0400009F RID: 159
		private CoolDown m_coolDown = new CoolDown();

		// Token: 0x040000A0 RID: 160
		private Action m_ActivateDelayedHandler;
	}
}
