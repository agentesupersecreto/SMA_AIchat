using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200028A RID: 650
	[AddComponentMenu("Dialogue System/Trigger/On Dialogue Event/Set Animation On Dialogue Event")]
	public class SetAnimationOnDialogueEvent : ActOnDialogueEvent
	{
		// Token: 0x06001BBB RID: 7099 RVA: 0x00032578 File Offset: 0x00030778
		public override void TryStartActions(Transform actor)
		{
			this.TryActions(this.onStart, actor);
		}

		// Token: 0x06001BBC RID: 7100 RVA: 0x00032588 File Offset: 0x00030788
		public override void TryEndActions(Transform actor)
		{
			this.TryActions(this.onEnd, actor);
		}

		// Token: 0x06001BBD RID: 7101 RVA: 0x00032598 File Offset: 0x00030798
		private void TryActions(SetAnimationOnDialogueEvent.SetAnimationAction[] actions, Transform actor)
		{
			if (actions == null)
			{
				return;
			}
			foreach (SetAnimationOnDialogueEvent.SetAnimationAction setAnimationAction in actions)
			{
				if (setAnimationAction != null && setAnimationAction.condition != null && setAnimationAction.condition.IsTrue(actor))
				{
					this.DoAction(setAnimationAction, actor);
				}
			}
		}

		// Token: 0x06001BBE RID: 7102 RVA: 0x000325F0 File Offset: 0x000307F0
		public void DoAction(SetAnimationOnDialogueEvent.SetAnimationAction action, Transform actor)
		{
			if (action != null)
			{
				Transform transform = Tools.Select(new Transform[] { action.target, base.transform });
				Animation componentInChildren = transform.GetComponentInChildren<Animation>();
				if (componentInChildren == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.Log(string.Format("{0}: Trigger: {1}.SetAnimation() can't find Animation component", new object[] { "Dialogue System", transform.name }));
					}
				}
				else
				{
					if (DialogueDebug.LogInfo)
					{
						Debug.Log(string.Format("{0}: Trigger: {1}.SetAnimation({2})", new object[] { "Dialogue System", transform.name, action.animationClip }));
					}
					componentInChildren.CrossFade(action.animationClip.name);
				}
			}
		}

		// Token: 0x04000FA6 RID: 4006
		public SetAnimationOnDialogueEvent.SetAnimationAction[] onStart = new SetAnimationOnDialogueEvent.SetAnimationAction[0];

		// Token: 0x04000FA7 RID: 4007
		public SetAnimationOnDialogueEvent.SetAnimationAction[] onEnd = new SetAnimationOnDialogueEvent.SetAnimationAction[0];

		// Token: 0x0200028B RID: 651
		[Serializable]
		public class SetAnimationAction : ActOnDialogueEvent.Action
		{
			// Token: 0x04000FA8 RID: 4008
			public Transform target;

			// Token: 0x04000FA9 RID: 4009
			public AnimationClip animationClip;
		}
	}
}
