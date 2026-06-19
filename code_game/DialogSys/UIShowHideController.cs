using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000037 RID: 55
	public class UIShowHideController
	{
		// Token: 0x0600017E RID: 382 RVA: 0x00008AE8 File Offset: 0x00006CE8
		public UIShowHideController(GameObject go, Component panel, UIShowHideController.TransitionMode animationMode = UIShowHideController.TransitionMode.Trigger)
		{
			this.panel = panel;
			this.animator = ((go != null) ? go.GetComponent<Animator>() : null);
			if (this.animator == null && panel != null)
			{
				this.animator = panel.GetComponent<Animator>();
			}
			this.animCoroutine = null;
			this.transitionMode = animationMode;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00008B4C File Offset: 0x00006D4C
		public void Show(string showState, bool pauseAfterAnimation, Action callback, bool wait = true)
		{
			this.CancelCurrentAnim();
			UIShowHideController.TransitionMode transitionMode = this.transitionMode;
			if (transitionMode == UIShowHideController.TransitionMode.State)
			{
				this.animCoroutine = DialogueManager.Instance.StartCoroutine(this.WaitForAnimationState(showState, pauseAfterAnimation, true, wait, callback));
				return;
			}
			if (transitionMode != UIShowHideController.TransitionMode.Trigger)
			{
				return;
			}
			this.animCoroutine = DialogueManager.Instance.StartCoroutine(this.WaitForAnimationTrigger(showState, pauseAfterAnimation, true, wait, callback));
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00008BA8 File Offset: 0x00006DA8
		public void Hide(string hideState, Action callback)
		{
			this.CancelCurrentAnim();
			UIShowHideController.TransitionMode transitionMode = this.transitionMode;
			if (transitionMode == UIShowHideController.TransitionMode.State)
			{
				this.animCoroutine = DialogueManager.Instance.StartCoroutine(this.WaitForAnimationState(hideState, false, false, true, callback));
				return;
			}
			if (transitionMode != UIShowHideController.TransitionMode.Trigger)
			{
				return;
			}
			this.animCoroutine = DialogueManager.Instance.StartCoroutine(this.WaitForAnimationTrigger(hideState, false, false, true, callback));
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00008C01 File Offset: 0x00006E01
		private IEnumerator WaitForAnimationState(string stateName, bool pauseAfterAnimation, bool panelActive, bool wait, Action callback)
		{
			if (this.panel != null && !this.panel.gameObject.activeSelf)
			{
				this.panel.gameObject.SetActive(true);
				yield return null;
			}
			if (this.CanTriggerAnimation(stateName))
			{
				this.CheckAnimatorModeAndTimescale(stateName);
				this.animator.Play(stateName);
				if (wait)
				{
					yield return null;
					float length = this.animator.GetCurrentAnimatorStateInfo(0).length;
					if (Mathf.Approximately(0f, Time.timeScale))
					{
						float timeout = Time.realtimeSinceStartup + length;
						while (Time.realtimeSinceStartup < timeout)
						{
							yield return null;
						}
					}
					else
					{
						yield return new WaitForSeconds(length);
					}
				}
			}
			if (!panelActive)
			{
				Tools.SetGameObjectActive(this.panel, false);
			}
			if (pauseAfterAnimation)
			{
				Time.timeScale = 0f;
			}
			this.animCoroutine = null;
			if (callback != null)
			{
				callback();
			}
			yield break;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00008C35 File Offset: 0x00006E35
		private IEnumerator WaitForAnimationTrigger(string triggerName, bool pauseAfterAnimation, bool panelActive, bool wait, Action callback)
		{
			if (panelActive && this.panel != null && !this.panel.gameObject.activeSelf)
			{
				this.panel.gameObject.SetActive(true);
				yield return null;
			}
			if (this.CanTriggerAnimation(triggerName) && this.animator.gameObject.activeSelf)
			{
				this.CheckAnimatorModeAndTimescale(triggerName);
				float timeout = Time.realtimeSinceStartup + UIShowHideController.maxWaitDuration;
				int goalHashID = Animator.StringToHash(triggerName);
				int oldHashId = UITools.GetAnimatorNameHash(this.animator.GetCurrentAnimatorStateInfo(0));
				int currentHashID = oldHashId;
				this.animator.SetTrigger(triggerName);
				if (wait)
				{
					while (currentHashID != goalHashID && currentHashID == oldHashId && Time.realtimeSinceStartup < timeout)
					{
						yield return null;
						currentHashID = ((this.animator != null && this.animator.isActiveAndEnabled && this.animator.runtimeAnimatorController != null && this.animator.layerCount > 0) ? UITools.GetAnimatorNameHash(this.animator.GetCurrentAnimatorStateInfo(0)) : currentHashID);
					}
					if (currentHashID == goalHashID && Time.realtimeSinceStartup < timeout)
					{
						float length = this.animator.GetCurrentAnimatorStateInfo(0).length;
						if (Mathf.Approximately(0f, Time.timeScale))
						{
							timeout = Time.realtimeSinceStartup + length;
							while (Time.realtimeSinceStartup < timeout)
							{
								yield return null;
							}
						}
						else
						{
							yield return new WaitForSeconds(length);
						}
					}
				}
			}
			if (!panelActive)
			{
				Tools.SetGameObjectActive(this.panel, false);
			}
			if (pauseAfterAnimation)
			{
				Time.timeScale = 0f;
			}
			this.animCoroutine = null;
			if (callback != null)
			{
				callback();
			}
			yield break;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00008C6C File Offset: 0x00006E6C
		private void CheckAnimatorModeAndTimescale(string triggerName)
		{
			if (Mathf.Approximately(0f, Time.timeScale) && this.animator.updateMode != AnimatorUpdateMode.UnscaledTime && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning("Dialogue System: Time is paused but animator mode isn't set to Unscaled Time; the animation triggered by " + triggerName + " won't play.", this.animator);
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00008CBA File Offset: 0x00006EBA
		private void CancelCurrentAnim()
		{
			if (this.animCoroutine != null)
			{
				DialogueManager.Instance.StopCoroutine(this.animCoroutine);
				this.animCoroutine = null;
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00008CDB File Offset: 0x00006EDB
		public void ClearTrigger(string triggerName)
		{
			if (this.HasAnimator() && !string.IsNullOrEmpty(triggerName) && this.animator.isActiveAndEnabled)
			{
				this.animator.ResetTrigger(triggerName);
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00008D06 File Offset: 0x00006F06
		private bool CanTriggerAnimation(string stateName)
		{
			return this.HasAnimator() && !string.IsNullOrEmpty(stateName);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00008D1C File Offset: 0x00006F1C
		private bool HasAnimator()
		{
			if (this.animator == null && !this.lookedForAnimator)
			{
				this.lookedForAnimator = true;
				if (this.panel != null)
				{
					this.animator = this.panel.GetComponent<Animator>();
					if (this.animator == null)
					{
						this.animator = this.panel.GetComponentInChildren<Animator>();
					}
				}
			}
			return this.animator != null && this.animator.isInitialized && this.animator.gameObject.activeSelf;
		}

		// Token: 0x04000134 RID: 308
		public static float maxWaitDuration = 5f;

		// Token: 0x04000135 RID: 309
		public Component panel;

		// Token: 0x04000136 RID: 310
		private Animator animator;

		// Token: 0x04000137 RID: 311
		private bool lookedForAnimator;

		// Token: 0x04000138 RID: 312
		private UIShowHideController.TransitionMode transitionMode;

		// Token: 0x04000139 RID: 313
		private Coroutine animCoroutine;

		// Token: 0x02000076 RID: 118
		public enum TransitionMode
		{
			// Token: 0x04000280 RID: 640
			State,
			// Token: 0x04000281 RID: 641
			Trigger
		}
	}
}
