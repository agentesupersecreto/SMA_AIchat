using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000008 RID: 8
	[TrackColor(0.855f, 0.8623f, 0.87f)]
	[TrackClipType(typeof(StartConversationClip))]
	[TrackBindingType(typeof(GameObject))]
	public class ConversationTrack : TrackAsset
	{
		// Token: 0x06000012 RID: 18 RVA: 0x0000240F File Offset: 0x0000060F
		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			return ScriptPlayable<ConversationMixerBehaviour>.Create(graph, inputCount);
		}
	}
}
