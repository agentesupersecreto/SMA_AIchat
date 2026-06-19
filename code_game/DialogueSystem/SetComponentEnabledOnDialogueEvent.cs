using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200028E RID: 654
	[AddComponentMenu("Dialogue System/Trigger/On Dialogue Event/Set Component Enabled On Dialogue Event")]
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/set_component_enabled_on_dialogue_event.html")]
	public class SetComponentEnabledOnDialogueEvent : ActOnDialogueEvent
	{
		// Token: 0x06001BC7 RID: 7111 RVA: 0x0003284C File Offset: 0x00030A4C
		public override void TryStartActions(Transform actor)
		{
			this.TryActions(this.onStart, actor, this.waitOneFrameOnStart);
		}

		// Token: 0x06001BC8 RID: 7112 RVA: 0x00032864 File Offset: 0x00030A64
		public override void TryEndActions(Transform actor)
		{
			this.TryActions(this.onEnd, actor, this.waitOneFrameOnEnd);
		}

		// Token: 0x06001BC9 RID: 7113 RVA: 0x0003287C File Offset: 0x00030A7C
		private void TryActions(SetComponentEnabledOnDialogueEvent.SetComponentEnabledAction[] actions, Transform actor, bool waitOneFrame)
		{
			if (actions == null)
			{
				return;
			}
			if (waitOneFrame)
			{
				base.StartCoroutine(this.TryActionsAfterOneFrameCoroutine(actions, actor));
			}
			else
			{
				this.TryActionsNow(actions, actor);
			}
		}

		// Token: 0x06001BCA RID: 7114 RVA: 0x000328A8 File Offset: 0x00030AA8
		private void TryActionsNow(SetComponentEnabledOnDialogueEvent.SetComponentEnabledAction[] actions, Transform actor)
		{
			foreach (SetComponentEnabledOnDialogueEvent.SetComponentEnabledAction setComponentEnabledAction in actions)
			{
				if (setComponentEnabledAction != null && setComponentEnabledAction.condition != null && setComponentEnabledAction.condition.IsTrue(actor))
				{
					this.DoAction(setComponentEnabledAction, actor);
				}
			}
		}

		// Token: 0x06001BCB RID: 7115 RVA: 0x000328FC File Offset: 0x00030AFC
		private IEnumerator TryActionsAfterOneFrameCoroutine(SetComponentEnabledOnDialogueEvent.SetComponentEnabledAction[] actions, Transform actor)
		{
			yield return new WaitForEndOfFrame();
			yield return null;
			this.TryActionsNow(actions, actor);
			yield break;
		}

		// Token: 0x06001BCC RID: 7116 RVA: 0x00032934 File Offset: 0x00030B34
		public void DoAction(SetComponentEnabledOnDialogueEvent.SetComponentEnabledAction action, Transform actor)
		{
			if (action != null && action.target != null)
			{
				Tools.SetComponentEnabled(action.target, action.state);
			}
		}

		// Token: 0x04000FAF RID: 4015
		public SetComponentEnabledOnDialogueEvent.SetComponentEnabledAction[] onStart = new SetComponentEnabledOnDialogueEvent.SetComponentEnabledAction[0];

		// Token: 0x04000FB0 RID: 4016
		[Tooltip("When the dialogue event starts, wait one frame before processing the On Start list.")]
		public bool waitOneFrameOnStart;

		// Token: 0x04000FB1 RID: 4017
		public SetComponentEnabledOnDialogueEvent.SetComponentEnabledAction[] onEnd = new SetComponentEnabledOnDialogueEvent.SetComponentEnabledAction[0];

		// Token: 0x04000FB2 RID: 4018
		[Tooltip("When the dialogue event starts, wait one frame before processing the On End list.")]
		public bool waitOneFrameOnEnd;

		// Token: 0x0200028F RID: 655
		[Serializable]
		public class SetComponentEnabledAction : ActOnDialogueEvent.Action
		{
			// Token: 0x04000FB3 RID: 4019
			public Component target;

			// Token: 0x04000FB4 RID: 4020
			public Toggle state;
		}
	}
}
