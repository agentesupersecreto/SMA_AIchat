using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000286 RID: 646
	[AddComponentMenu("Dialogue System/Trigger/On Dialogue Event/Send Message On Dialogue Event")]
	public class SendMessageOnDialogueEvent : ActOnDialogueEvent
	{
		// Token: 0x06001BAF RID: 7087 RVA: 0x00032310 File Offset: 0x00030510
		public override void TryStartActions(Transform actor)
		{
			this.TryActions(this.onStart, actor);
		}

		// Token: 0x06001BB0 RID: 7088 RVA: 0x00032320 File Offset: 0x00030520
		public override void TryEndActions(Transform actor)
		{
			this.TryActions(this.onEnd, actor);
		}

		// Token: 0x06001BB1 RID: 7089 RVA: 0x00032330 File Offset: 0x00030530
		private void TryActions(SendMessageOnDialogueEvent.SendMessageAction[] actions, Transform actor)
		{
			if (actions == null)
			{
				return;
			}
			foreach (SendMessageOnDialogueEvent.SendMessageAction sendMessageAction in actions)
			{
				if (sendMessageAction != null && sendMessageAction.condition != null && sendMessageAction.condition.IsTrue(actor))
				{
					this.DoAction(sendMessageAction, actor);
				}
			}
		}

		// Token: 0x06001BB2 RID: 7090 RVA: 0x00032388 File Offset: 0x00030588
		private void DoAction(SendMessageOnDialogueEvent.SendMessageAction action, Transform actor)
		{
			if (action != null)
			{
				Transform transform = Tools.Select(new Transform[] { action.target, base.transform });
				string text = ((!string.IsNullOrEmpty(action.parameter)) ? action.parameter : null);
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Sending message '{1}' to {2} (parameter={3}).", new object[] { "Dialogue System", action.methodName, transform, text }), this);
				}
				transform.BroadcastMessage(action.methodName, text, SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x04000F9D RID: 3997
		public SendMessageOnDialogueEvent.SendMessageAction[] onStart = new SendMessageOnDialogueEvent.SendMessageAction[0];

		// Token: 0x04000F9E RID: 3998
		public SendMessageOnDialogueEvent.SendMessageAction[] onEnd = new SendMessageOnDialogueEvent.SendMessageAction[0];

		// Token: 0x02000287 RID: 647
		[Serializable]
		public class SendMessageAction : ActOnDialogueEvent.Action
		{
			// Token: 0x04000F9F RID: 3999
			public Transform target;

			// Token: 0x04000FA0 RID: 4000
			public string methodName;

			// Token: 0x04000FA1 RID: 4001
			public string parameter;
		}
	}
}
