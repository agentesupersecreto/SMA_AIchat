using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200000C RID: 12
	[TrackColor(0.855f, 0.8623f, 0.87f)]
	[TrackClipType(typeof(SetQuestStateClip))]
	public class QuestStateTrack : TrackAsset
	{
		// Token: 0x0600001C RID: 28 RVA: 0x000026A0 File Offset: 0x000008A0
		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			return ScriptPlayable<QuestStateMixerBehaviour>.Create(graph, inputCount);
		}
	}
}
