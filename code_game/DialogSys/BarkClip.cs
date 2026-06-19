using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000004 RID: 4
	[Serializable]
	public class BarkClip : PlayableAsset, ITimelineClipAsset
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020F5 File Offset: 0x000002F5
		public ClipCaps clipCaps
		{
			get
			{
				return ClipCaps.None;
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020F8 File Offset: 0x000002F8
		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			ScriptPlayable<BarkBehaviour> scriptPlayable = ScriptPlayable<BarkBehaviour>.Create(graph, this.template, 0);
			scriptPlayable.GetBehaviour().listener = this.listener.Resolve(graph.GetResolver());
			return scriptPlayable;
		}

		// Token: 0x04000005 RID: 5
		public BarkBehaviour template = new BarkBehaviour();

		// Token: 0x04000006 RID: 6
		public ExposedReference<Transform> listener;
	}
}
