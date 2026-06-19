using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000288 RID: 648
	[AddComponentMenu("Dialogue System/Trigger/On Dialogue Event/Set Active On Dialogue Event")]
	public class SetActiveOnDialogueEvent : ActOnDialogueEvent
	{
		// Token: 0x06001BB5 RID: 7093 RVA: 0x00032448 File Offset: 0x00030648
		public override void TryStartActions(Transform actor)
		{
			this.TryActions(this.onStart, actor);
		}

		// Token: 0x06001BB6 RID: 7094 RVA: 0x00032458 File Offset: 0x00030658
		public override void TryEndActions(Transform actor)
		{
			this.TryActions(this.onEnd, actor);
		}

		// Token: 0x06001BB7 RID: 7095 RVA: 0x00032468 File Offset: 0x00030668
		private void TryActions(SetActiveOnDialogueEvent.SetActiveAction[] actions, Transform actor)
		{
			if (actions == null)
			{
				return;
			}
			foreach (SetActiveOnDialogueEvent.SetActiveAction setActiveAction in actions)
			{
				if (setActiveAction != null && setActiveAction.condition != null && setActiveAction.condition.IsTrue(actor))
				{
					this.DoAction(setActiveAction, actor);
				}
			}
		}

		// Token: 0x06001BB8 RID: 7096 RVA: 0x000324C0 File Offset: 0x000306C0
		public void DoAction(SetActiveOnDialogueEvent.SetActiveAction action, Transform actor)
		{
			if (action != null)
			{
				Transform transform = Tools.Select(new Transform[] { action.target, base.transform });
				bool newValue = ToggleTools.GetNewValue(transform.gameObject.activeSelf, action.state);
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Trigger: {1}.SetActive({2})", new object[] { "Dialogue System", transform.name, newValue }));
				}
				transform.gameObject.SetActive(newValue);
			}
		}

		// Token: 0x04000FA2 RID: 4002
		public SetActiveOnDialogueEvent.SetActiveAction[] onStart = new SetActiveOnDialogueEvent.SetActiveAction[0];

		// Token: 0x04000FA3 RID: 4003
		public SetActiveOnDialogueEvent.SetActiveAction[] onEnd = new SetActiveOnDialogueEvent.SetActiveAction[0];

		// Token: 0x02000289 RID: 649
		[Serializable]
		public class SetActiveAction : ActOnDialogueEvent.Action
		{
			// Token: 0x04000FA4 RID: 4004
			public Transform target;

			// Token: 0x04000FA5 RID: 4005
			public Toggle state;
		}
	}
}
