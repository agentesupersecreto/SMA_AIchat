using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000006 RID: 6
	[TrackColor(0.855f, 0.8623f, 0.87f)]
	[TrackClipType(typeof(BarkClip))]
	[TrackBindingType(typeof(GameObject))]
	public class BarkTrack : TrackAsset
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002298 File Offset: 0x00000498
		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			return ScriptPlayable<BarkMixerBehaviour>.Create(graph, inputCount);
		}
	}
}
