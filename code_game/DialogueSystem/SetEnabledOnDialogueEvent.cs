using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000290 RID: 656
	[AddComponentMenu("")]
	public class SetEnabledOnDialogueEvent : ActOnDialogueEvent
	{
		// Token: 0x06001BCF RID: 7119 RVA: 0x00032994 File Offset: 0x00030B94
		public override void TryStartActions(Transform actor)
		{
			this.TryActions(this.onStart, actor, this.waitOneFrameOnStart);
		}

		// Token: 0x06001BD0 RID: 7120 RVA: 0x000329AC File Offset: 0x00030BAC
		public override void TryEndActions(Transform actor)
		{
			this.TryActions(this.onEnd, actor, this.waitOneFrameOnEnd);
		}

		// Token: 0x06001BD1 RID: 7121 RVA: 0x000329C4 File Offset: 0x00030BC4
		private void TryActions(SetEnabledOnDialogueEvent.SetEnabledAction[] actions, Transform actor, bool waitOneFrame)
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

		// Token: 0x06001BD2 RID: 7122 RVA: 0x000329F0 File Offset: 0x00030BF0
		private void TryActionsNow(SetEnabledOnDialogueEvent.SetEnabledAction[] actions, Transform actor)
		{
			foreach (SetEnabledOnDialogueEvent.SetEnabledAction setEnabledAction in actions)
			{
				if (setEnabledAction != null && setEnabledAction.condition != null && setEnabledAction.condition.IsTrue(actor))
				{
					this.DoAction(setEnabledAction, actor);
				}
			}
		}

		// Token: 0x06001BD3 RID: 7123 RVA: 0x00032A44 File Offset: 0x00030C44
		private IEnumerator TryActionsAfterOneFrameCoroutine(SetEnabledOnDialogueEvent.SetEnabledAction[] actions, Transform actor)
		{
			Debug.Log("Waiting 1 frame");
			yield return new WaitForEndOfFrame();
			yield return null;
			yield return new WaitForSeconds(2f);
			this.TryActionsNow(actions, actor);
			yield break;
		}

		// Token: 0x06001BD4 RID: 7124 RVA: 0x00032A7C File Offset: 0x00030C7C
		public void DoAction(SetEnabledOnDialogueEvent.SetEnabledAction action, Transform actor)
		{
			if (action != null)
			{
				MonoBehaviour monoBehaviour = Tools.Select(new MonoBehaviour[] { action.target, this });
				if (monoBehaviour == null)
				{
					return;
				}
				bool newValue = ToggleTools.GetNewValue(monoBehaviour.enabled, action.state);
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Trigger: {1}.{2}.enabled = {3}", new object[]
					{
						"Dialogue System",
						monoBehaviour.name,
						monoBehaviour.GetType().Name,
						newValue
					}));
				}
				monoBehaviour.enabled = newValue;
			}
		}

		// Token: 0x04000FB5 RID: 4021
		public SetEnabledOnDialogueEvent.SetEnabledAction[] onStart = new SetEnabledOnDialogueEvent.SetEnabledAction[0];

		// Token: 0x04000FB6 RID: 4022
		[Tooltip("When the dialogue event starts, wait one frame before processing the On Start list.")]
		public bool waitOneFrameOnStart;

		// Token: 0x04000FB7 RID: 4023
		public SetEnabledOnDialogueEvent.SetEnabledAction[] onEnd = new SetEnabledOnDialogueEvent.SetEnabledAction[0];

		// Token: 0x04000FB8 RID: 4024
		[Tooltip("When the dialogue event starts, wait one frame before processing the On End list.")]
		public bool waitOneFrameOnEnd;

		// Token: 0x02000291 RID: 657
		[Serializable]
		public class SetEnabledAction : ActOnDialogueEvent.Action
		{
			// Token: 0x04000FB9 RID: 4025
			public MonoBehaviour target;

			// Token: 0x04000FBA RID: 4026
			public Toggle state;
		}
	}
}
