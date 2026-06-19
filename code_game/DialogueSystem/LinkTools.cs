using System;
using System.Collections.Generic;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000216 RID: 534
	public static class LinkTools
	{
		// Token: 0x060017FF RID: 6143 RVA: 0x00020218 File Offset: 0x0001E418
		public static void SortOutgoingLinks(DialogueDatabase database, Conversation conversation)
		{
			if (conversation != null)
			{
				foreach (DialogueEntry dialogueEntry in conversation.dialogueEntries)
				{
					LinkTools.SortOutgoingLinks(database, dialogueEntry);
				}
			}
		}

		// Token: 0x06001800 RID: 6144 RVA: 0x00020284 File Offset: 0x0001E484
		public static void SortOutgoingLinks(DialogueDatabase database, DialogueEntry dialogueEntry)
		{
			if (database != null && dialogueEntry != null)
			{
				foreach (Link link in dialogueEntry.outgoingLinks)
				{
					DialogueEntry dialogueEntry2 = database.GetDialogueEntry(link);
					if (dialogueEntry2 != null)
					{
						link.priority = dialogueEntry2.conditionPriority;
					}
				}
				dialogueEntry.outgoingLinks.Sort(new LinkTools.PrioritySorter());
			}
		}

		// Token: 0x06001801 RID: 6145 RVA: 0x00020320 File Offset: 0x0001E520
		public static bool IsPassthroughOnFalse(DialogueEntry entry)
		{
			return string.Equals(entry.falseConditionAction, "Passthrough");
		}

		// Token: 0x02000217 RID: 535
		public class PrioritySorter : IComparer<Link>
		{
			// Token: 0x06001803 RID: 6147 RVA: 0x0002033C File Offset: 0x0001E53C
			public int Compare(Link link1, Link link2)
			{
				return (link1 == null || link2 == null) ? 0 : link2.priority.CompareTo(link1.priority);
			}
		}
	}
}
