using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000012 RID: 18
	[Serializable]
	public class ShowAlertClip : PlayableAsset, ITimelineClipAsset
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002806 File Offset: 0x00000A06
		public ClipCaps clipCaps
		{
			get
			{
				return ClipCaps.None;
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002809 File Offset: 0x00000A09
		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			return ScriptPlayable<ShowAlertBehaviour>.Create(graph, this.template, 0);
		}

		// Token: 0x0400001A RID: 26
		public ShowAlertBehaviour template = new ShowAlertBehaviour();
	}
}
