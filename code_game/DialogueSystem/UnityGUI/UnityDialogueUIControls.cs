using System;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002D7 RID: 727
	[Serializable]
	public static class UnityDialogueUIControls
	{
		// Token: 0x06001DC9 RID: 7625 RVA: 0x0003AC20 File Offset: 0x00038E20
		public static void SetControlActive(GUIControl control, bool value)
		{
			if (control != null)
			{
				if (value && !control.gameObject.activeSelf)
				{
					control.gameObject.SetActive(true);
					UnityDialogueUIControls.CheckSlideEffect(control);
				}
				else if (!value && control.gameObject.activeSelf)
				{
					control.gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x06001DCA RID: 7626 RVA: 0x0003AC88 File Offset: 0x00038E88
		private static void CheckSlideEffect(GUIControl control)
		{
			SlideEffect component = control.GetComponent<SlideEffect>();
			if (component != null && component.trigger == GUIEffectTrigger.OnEnable)
			{
				control.visible = false;
			}
		}
	}
}
