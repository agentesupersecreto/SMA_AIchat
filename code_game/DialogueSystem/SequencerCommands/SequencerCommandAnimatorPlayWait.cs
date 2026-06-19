using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200023B RID: 571
	[AddComponentMenu("")]
	public class SequencerCommandAnimatorPlayWait : SequencerCommand
	{
		// Token: 0x060019BC RID: 6588 RVA: 0x000298CC File Offset: 0x00027ACC
		public void Start()
		{
			string parameter = base.GetParameter(0, null);
			Transform subject = base.GetSubject(1, null);
			float parameterAsFloat = base.GetParameterAsFloat(2, 0f);
			int parameterAsInt = base.GetParameterAsInt(3, -1);
			Animator animator = ((!(subject != null)) ? null : subject.GetComponentInChildren<Animator>());
			if (animator == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.Log(string.Format("{0}: Sequencer: AnimatorPlayWait({1}, {2}, fade={3}, layer={4}): No Animator found on {2}", new object[]
					{
						"Dialogue System",
						parameter,
						(!(subject != null)) ? base.GetParameter(1, null) : subject.name,
						parameterAsFloat,
						parameterAsInt
					}));
				}
				base.Stop();
			}
			else
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Sequencer: AnimatorPlayWait({1}, {2}, {3})", new object[] { "Dialogue System", parameter, subject, parameterAsFloat }));
				}
				if (Tools.ApproximatelyZero(parameterAsFloat))
				{
					animator.Play(parameter, parameterAsInt);
				}
				else
				{
					animator.CrossFade(parameter, parameterAsFloat, parameterAsInt);
				}
				base.StartCoroutine(this.MonitorState(animator, parameter));
			}
		}

		// Token: 0x060019BD RID: 6589 RVA: 0x00029A00 File Offset: 0x00027C00
		private IEnumerator MonitorState(Animator animator, string stateName)
		{
			float maxStartTime = DialogueTime.time + 1f;
			AnimatorStateInfo animatorStateInfo;
			bool isInState = this.CheckIsInState(animator, stateName, out animatorStateInfo);
			while (!isInState && DialogueTime.time < maxStartTime)
			{
				yield return null;
				isInState = this.CheckIsInState(animator, stateName, out animatorStateInfo);
			}
			if (isInState)
			{
				yield return base.StartCoroutine(DialogueTime.WaitForSeconds(animatorStateInfo.length));
			}
			base.Stop();
			yield break;
		}

		// Token: 0x060019BE RID: 6590 RVA: 0x00029A38 File Offset: 0x00027C38
		private bool CheckIsInState(Animator animator, string stateName, out AnimatorStateInfo animatorStateInfo)
		{
			if (animator != null)
			{
				for (int i = 0; i < animator.layerCount; i++)
				{
					AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(i);
					if (currentAnimatorStateInfo.IsName(stateName))
					{
						animatorStateInfo = currentAnimatorStateInfo;
						return true;
					}
				}
			}
			animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
			return false;
		}

		// Token: 0x04000E3D RID: 3645
		private const float maxDurationToWaitForStateStart = 1f;
	}
}
