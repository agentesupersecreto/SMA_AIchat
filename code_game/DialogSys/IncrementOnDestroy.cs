using System;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200003E RID: 62
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/increment_on_destroy.html")]
	[AddComponentMenu("Dialogue System/Actor/Increment On Destroy")]
	public class IncrementOnDestroy : MonoBehaviour
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x00009CCE File Offset: 0x00007ECE
		protected string ActualVariableName
		{
			get
			{
				if (!string.IsNullOrEmpty(this.variable))
				{
					return this.variable;
				}
				return OverrideActorName.GetInternalName(base.transform);
			}
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00009CEF File Offset: 0x00007EEF
		public void OnEnable()
		{
			this.listenForOnDestroy = true;
			PersistentDataManager.RegisterPersistentData(base.gameObject);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00009D03 File Offset: 0x00007F03
		public void OnLevelWillBeUnloaded()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00009D0C File Offset: 0x00007F0C
		public void OnApplicationQuit()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00009D15 File Offset: 0x00007F15
		public void OnDestroy()
		{
			if (this.incrementOn == IncrementOnDestroy.IncrementOn.Destroy)
			{
				this.TryIncrement();
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00009D25 File Offset: 0x00007F25
		public void OnDisable()
		{
			PersistentDataManager.UnregisterPersistentData(base.gameObject);
			if (this.incrementOn == IncrementOnDestroy.IncrementOn.Disable)
			{
				this.TryIncrement();
			}
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00009D44 File Offset: 0x00007F44
		public void TryIncrement()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (DialogueManager.Instance == null || DialogueManager.DatabaseManager == null || DialogueManager.MasterDatabase == null)
			{
				return;
			}
			if (!this.listenForOnDestroy || !this.condition.IsTrue(null))
			{
				return;
			}
			int num = Mathf.Clamp(DialogueLua.GetVariable(this.ActualVariableName).AsInt + this.increment, this.min, this.max);
			DialogueLua.SetVariable(this.ActualVariableName, num);
			DialogueManager.SendUpdateTracker();
			if (!string.IsNullOrEmpty(this.alertMessage) && !(DialogueManager.Instance == null))
			{
				if (Mathf.Approximately(0f, this.alertDuration))
				{
					DialogueManager.ShowAlert(this.alertMessage);
				}
				else
				{
					DialogueManager.ShowAlert(this.alertMessage, this.alertDuration);
				}
			}
			this.onIncrement.Invoke();
		}

		// Token: 0x04000159 RID: 345
		[Tooltip("Increment on Destroy or Disable.")]
		public IncrementOnDestroy.IncrementOn incrementOn;

		// Token: 0x0400015A RID: 346
		[Tooltip("Increment this Dialogue System variable.")]
		public string variable = string.Empty;

		// Token: 0x0400015B RID: 347
		[Tooltip("Increment the variable by this amount. Use a negative value to decrement.")]
		public int increment = 1;

		// Token: 0x0400015C RID: 348
		[Tooltip("After incrementing, ensure that the variable is at least this value.")]
		public int min;

		// Token: 0x0400015D RID: 349
		[Tooltip("After incrementing, ensure that the variable is no more than this value.")]
		public int max = 100;

		// Token: 0x0400015E RID: 350
		[Tooltip("Optional alert message to show when incrementing.")]
		public string alertMessage = string.Empty;

		// Token: 0x0400015F RID: 351
		[Tooltip("Duration to show alert, or 0 to use default duration.")]
		public float alertDuration;

		// Token: 0x04000160 RID: 352
		[Tooltip("If set, only increment if the conditions are true.")]
		public Condition condition = new Condition();

		// Token: 0x04000161 RID: 353
		public UnityEvent onIncrement = new UnityEvent();

		// Token: 0x04000162 RID: 354
		private bool listenForOnDestroy;

		// Token: 0x02000086 RID: 134
		public enum IncrementOn
		{
			// Token: 0x040002BA RID: 698
			Destroy,
			// Token: 0x040002BB RID: 699
			Disable
		}
	}
}
