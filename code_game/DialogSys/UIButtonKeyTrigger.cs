using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000036 RID: 54
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/unity_u_i_dialogue_u_i.html#unityUIDialogueUINavigation")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Effects/UI Button Key Trigger")]
	public class UIButtonKeyTrigger : MonoBehaviour
	{
		// Token: 0x0600017B RID: 379 RVA: 0x00008A3E File Offset: 0x00006C3E
		private void Awake()
		{
			this.button = base.GetComponent<Button>();
			if (this.button == null)
			{
				base.enabled = false;
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00008A64 File Offset: 0x00006C64
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
			if (Input.GetKeyDown(this.key) || (!string.IsNullOrEmpty(this.buttonName) && DialogueManager.GetInputButtonDown(this.buttonName)))
			{
				PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
				ExecuteEvents.Execute<ISubmitHandler>(this.button.gameObject, pointerEventData, ExecuteEvents.submitHandler);
			}
		}

		// Token: 0x04000131 RID: 305
		public KeyCode key;

		// Token: 0x04000132 RID: 306
		public string buttonName = string.Empty;

		// Token: 0x04000133 RID: 307
		private Button button;
	}
}
