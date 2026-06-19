using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200000E RID: 14
	[Serializable]
	public class SetQuestStateClip : PlayableAsset, ITimelineClipAsset
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000026BE File Offset: 0x000008BE
		public ClipCaps clipCaps
		{
			get
			{
				return ClipCaps.None;
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000026C1 File Offset: 0x000008C1
		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			return ScriptPlayable<SetQuestStateBehaviour>.Create(graph, this.template, 0);
		}

		// Token: 0x04000016 RID: 22
		public SetQuestStateBehaviour template = new SetQuestStateBehaviour();
	}
}
