using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000227 RID: 551
	[AddComponentMenu("Dialogue System/Actor/Bark Group Member")]
	public class BarkGroupMember : MonoBehaviour
	{
		// Token: 0x17000A33 RID: 2611
		// (get) Token: 0x060018DF RID: 6367 RVA: 0x000245F0 File Offset: 0x000227F0
		private IBarkUI barkUI
		{
			get
			{
				if (this.m_barkUI == null)
				{
					this.m_barkUI = base.GetComponentInChildren(typeof(IBarkUI)) as IBarkUI;
				}
				return this.m_barkUI;
			}
		}

		// Token: 0x060018E0 RID: 6368 RVA: 0x0002462C File Offset: 0x0002282C
		private void OnDisable()
		{
			if (BarkGroupManager.instance == null)
			{
				return;
			}
			BarkGroupManager.instance.RemoveFromGroup(this.m_currentIdValue, this);
		}

		// Token: 0x060018E1 RID: 6369 RVA: 0x0002465C File Offset: 0x0002285C
		private void OnBarkStart(Transform listener)
		{
			if (string.IsNullOrEmpty(this.m_currentIdValue) || this.evaluateIdEveryBark)
			{
				this.UpdateMembership();
			}
			BarkGroupManager.instance.MutexBark(this.m_currentIdValue, this);
		}

		// Token: 0x060018E2 RID: 6370 RVA: 0x0002469C File Offset: 0x0002289C
		public void UpdateMembership()
		{
			string asString = Lua.Run("return " + this.groupId, DialogueDebug.LogInfo, false).AsString;
			if (string.Equals(asString, "nil"))
			{
				asString = this.groupId;
			}
			if (asString != this.m_currentIdValue)
			{
				BarkGroupManager.instance.RemoveFromGroup(this.m_currentIdValue, this);
				BarkGroupManager.instance.AddToGroup(asString, this);
				this.m_currentIdValue = asString;
			}
		}

		// Token: 0x060018E3 RID: 6371 RVA: 0x0002471C File Offset: 0x0002291C
		public void CancelBark()
		{
			if (this.barkUI == null || !this.barkUI.IsPlaying)
			{
				return;
			}
			base.CancelInvoke("HideBarkNow");
			base.Invoke("HideBarkNow", this.forcedHideDelay);
		}

		// Token: 0x060018E4 RID: 6372 RVA: 0x00024764 File Offset: 0x00022964
		private void HideBarkNow()
		{
			if (this.barkUI == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning("Dialogue System: Didn't find a bark UI on " + base.name, this);
				}
			}
			else if (this.barkUI.IsPlaying)
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log("Dialogue System: Hiding bark on " + base.name, this);
				}
				this.barkUI.Hide();
			}
		}

		// Token: 0x04000DE1 RID: 3553
		[Tooltip("Member of this group. Can be a Lua expression.")]
		public string groupId;

		// Token: 0x04000DE2 RID: 3554
		[Tooltip("Evaluate Group Id before every bark. Useful if Id is a Lua expression that can change value.")]
		public bool evaluateIdEveryBark = true;

		// Token: 0x04000DE3 RID: 3555
		[Tooltip("When another group member forces this member's bark to hide, delay this many seconds before hiding.")]
		public float forcedHideDelay;

		// Token: 0x04000DE4 RID: 3556
		private string m_currentIdValue = string.Empty;

		// Token: 0x04000DE5 RID: 3557
		private IBarkUI m_barkUI;
	}
}
