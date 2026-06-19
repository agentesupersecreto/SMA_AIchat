using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000226 RID: 550
	public class BarkGroupManager : MonoBehaviour
	{
		// Token: 0x17000A32 RID: 2610
		// (get) Token: 0x060018D9 RID: 6361 RVA: 0x000243D4 File Offset: 0x000225D4
		public static BarkGroupManager instance
		{
			get
			{
				if (BarkGroupManager.s_applicationIsQuitting)
				{
					return null;
				}
				if (BarkGroupManager.s_instance == null)
				{
					BarkGroupManager.s_instance = Object.FindObjectOfType<BarkGroupManager>();
					if (BarkGroupManager.s_instance == null)
					{
						BarkGroupManager.s_instance = new GameObject("Bark Group Manager").AddComponent<BarkGroupManager>();
						Object.DontDestroyOnLoad(BarkGroupManager.s_instance.gameObject);
					}
				}
				return BarkGroupManager.s_instance;
			}
		}

		// Token: 0x060018DA RID: 6362 RVA: 0x00024440 File Offset: 0x00022640
		private void OnApplicationQuit()
		{
			BarkGroupManager.s_applicationIsQuitting = true;
		}

		// Token: 0x060018DB RID: 6363 RVA: 0x00024448 File Offset: 0x00022648
		public void AddToGroup(string groupId, BarkGroupMember member)
		{
			if (string.IsNullOrEmpty(groupId) || member == null)
			{
				return;
			}
			if (!this.groups.ContainsKey(groupId))
			{
				this.groups.Add(groupId, new HashSet<BarkGroupMember>());
			}
			this.groups[groupId].Add(member);
		}

		// Token: 0x060018DC RID: 6364 RVA: 0x000244A4 File Offset: 0x000226A4
		public void RemoveFromGroup(string groupId, BarkGroupMember member)
		{
			if (string.IsNullOrEmpty(groupId) || member == null)
			{
				return;
			}
			if (!this.groups.ContainsKey(groupId))
			{
				return;
			}
			if (!this.groups[groupId].Contains(member))
			{
				return;
			}
			this.groups[groupId].Remove(member);
			if (this.groups[groupId].Count == 0)
			{
				this.groups.Remove(groupId);
			}
		}

		// Token: 0x060018DD RID: 6365 RVA: 0x0002452C File Offset: 0x0002272C
		public void MutexBark(string groupId, BarkGroupMember member)
		{
			if (string.IsNullOrEmpty(groupId) || member == null)
			{
				return;
			}
			if (!this.groups.ContainsKey(groupId))
			{
				return;
			}
			foreach (BarkGroupMember barkGroupMember in this.groups[groupId])
			{
				if (!(barkGroupMember == member))
				{
					barkGroupMember.CancelBark();
				}
			}
		}

		// Token: 0x04000DDE RID: 3550
		private static bool s_applicationIsQuitting;

		// Token: 0x04000DDF RID: 3551
		private static BarkGroupManager s_instance;

		// Token: 0x04000DE0 RID: 3552
		public Dictionary<string, HashSet<BarkGroupMember>> groups = new Dictionary<string, HashSet<BarkGroupMember>>();
	}
}
