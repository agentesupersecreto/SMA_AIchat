using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000010 RID: 16
	[TrackColor(0.855f, 0.8623f, 0.87f)]
	[TrackClipType(typeof(ShowAlertClip))]
	public class AlertTrack : TrackAsset
	{
		// Token: 0x06000026 RID: 38 RVA: 0x000027E8 File Offset: 0x000009E8
		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			return ScriptPlayable<AlertMixerBehaviour>.Create(graph, inputCount);
		}
	}
}
