using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200028C RID: 652
	[AddComponentMenu("Dialogue System/Trigger/On Dialogue Event/Set Animator State On Dialogue Event")]
	public class SetAnimatorStateOnDialogueEvent : ActOnDialogueEvent
	{
		// Token: 0x06001BC1 RID: 7105 RVA: 0x000326DC File Offset: 0x000308DC
		public override void TryStartActions(Transform actor)
		{
			this.TryActions(this.onStart, actor);
		}

		// Token: 0x06001BC2 RID: 7106 RVA: 0x000326EC File Offset: 0x000308EC
		public override void TryEndActions(Transform actor)
		{
			this.TryActions(this.onEnd, actor);
		}

		// Token: 0x06001BC3 RID: 7107 RVA: 0x000326FC File Offset: 0x000308FC
		private void TryActions(SetAnimatorStateOnDialogueEvent.SetAnimatorStateAction[] actions, Transform actor)
		{
			if (actions == null)
			{
				return;
			}
			foreach (SetAnimatorStateOnDialogueEvent.SetAnimatorStateAction setAnimatorStateAction in actions)
			{
				if (setAnimatorStateAction != null && setAnimatorStateAction.condition != null && setAnimatorStateAction.condition.IsTrue(actor))
				{
					this.DoAction(setAnimatorStateAction, actor);
				}
			}
		}

		// Token: 0x06001BC4 RID: 7108 RVA: 0x00032754 File Offset: 0x00030954
		public void DoAction(SetAnimatorStateOnDialogueEvent.SetAnimatorStateAction action, Transform actor)
		{
			if (action != null)
			{
				Transform transform = Tools.Select(new Transform[] { action.target, base.transform });
				Animator componentInChildren = transform.GetComponentInChildren<Animator>();
				if (componentInChildren == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.Log(string.Format("{0}: Trigger: {1}.SetAnimatorState() can't find Animator", new object[] { "Dialogue System", transform.name }));
					}
				}
				else
				{
					if (DialogueDebug.LogInfo)
					{
						Debug.Log(string.Format("{0}: Trigger: {1}.SetAnimatorState({2})", new object[] { "Dialogue System", transform.name, action.stateName }));
					}
					componentInChildren.CrossFade(action.stateName, action.crossFadeDuration);
				}
			}
		}

		// Token: 0x04000FAA RID: 4010
		public SetAnimatorStateOnDialogueEvent.SetAnimatorStateAction[] onStart = new SetAnimatorStateOnDialogueEvent.SetAnimatorStateAction[0];

		// Token: 0x04000FAB RID: 4011
		public SetAnimatorStateOnDialogueEvent.SetAnimatorStateAction[] onEnd = new SetAnimatorStateOnDialogueEvent.SetAnimatorStateAction[0];

		// Token: 0x0200028D RID: 653
		[Serializable]
		public class SetAnimatorStateAction : ActOnDialogueEvent.Action
		{
			// Token: 0x04000FAC RID: 4012
			public Transform target;

			// Token: 0x04000FAD RID: 4013
			public string stateName;

			// Token: 0x04000FAE RID: 4014
			public float crossFadeDuration = 0.3f;
		}
	}
}
