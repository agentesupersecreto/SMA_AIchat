using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200000A RID: 10
	[Serializable]
	public class StartConversationClip : PlayableAsset, ITimelineClipAsset
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000015 RID: 21 RVA: 0x0000242D File Offset: 0x0000062D
		public ClipCaps clipCaps
		{
			get
			{
				return ClipCaps.None;
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002430 File Offset: 0x00000630
		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			ScriptPlayable<StartConversationBehaviour> scriptPlayable = ScriptPlayable<StartConversationBehaviour>.Create(graph, this.template, 0);
			scriptPlayable.GetBehaviour().conversant = this.conversant.Resolve(graph.GetResolver());
			return scriptPlayable;
		}

		// Token: 0x0400000D RID: 13
		public StartConversationBehaviour template = new StartConversationBehaviour();

		// Token: 0x0400000E RID: 14
		public ExposedReference<Transform> conversant;
	}
}
