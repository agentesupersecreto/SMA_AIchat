using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000014 RID: 20
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/timeline_trigger.html")]
	[AddComponentMenu("Dialogue System/Trigger/Timeline Trigger")]
	public class TimelineTrigger : DialogueEventStarter
	{
		// Token: 0x06000030 RID: 48 RVA: 0x0000298E File Offset: 0x00000B8E
		public void OnBarkEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnBarkEnd)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000029A8 File Offset: 0x00000BA8
		public void OnConversationEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnConversationEnd)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000029C2 File Offset: 0x00000BC2
		public void OnSequenceEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnSequenceEnd)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000029DC File Offset: 0x00000BDC
		public void OnUse(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000029F7 File Offset: 0x00000BF7
		public void OnUse(string message)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002A12 File Offset: 0x00000C12
		public void OnUse()
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002A2D File Offset: 0x00000C2D
		public void OnTriggerEnter(Collider other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002A4C File Offset: 0x00000C4C
		public void OnTriggerEnter2D(Collider2D other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002A6B File Offset: 0x00000C6B
		public void OnTriggerExit(Collider other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002A8E File Offset: 0x00000C8E
		public void OnTriggerExit2D(Collider2D other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002AB1 File Offset: 0x00000CB1
		public void OnCollisionEnter(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnCollisionEnter)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002AD9 File Offset: 0x00000CD9
		public void OnCollisionEnter2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002AFD File Offset: 0x00000CFD
		public void OnCollisionExit(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002B25 File Offset: 0x00000D25
		public void OnCollisionExit2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002B50 File Offset: 0x00000D50
		public void Awake()
		{
			if (this.playableDirector == null)
			{
				this.playableDirector = base.GetComponent<PlayableDirector>();
			}
			if (this.playableDirector == null && this.timelineAsset != null)
			{
				this.playableDirector = base.gameObject.AddComponent<PlayableDirector>();
			}
			if (this.playableDirector != null && this.playableDirector.playableAsset == null)
			{
				this.playableDirector.playableAsset = this.timelineAsset;
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002BD6 File Offset: 0x00000DD6
		public void Start()
		{
			if (this.trigger == DialogueTriggerEvent.OnStart)
			{
				base.StartCoroutine(this.StartAfterOneFrame());
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002BEF File Offset: 0x00000DEF
		public void OnEnable()
		{
			this.listenForOnDestroy = true;
			if (this.trigger == DialogueTriggerEvent.OnEnable)
			{
				base.StartCoroutine(this.StartAfterOneFrame());
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002C0F File Offset: 0x00000E0F
		public void OnDisable()
		{
			if (!this.listenForOnDestroy)
			{
				return;
			}
			if (this.trigger == DialogueTriggerEvent.OnDisable)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002C2E File Offset: 0x00000E2E
		public void OnLevelWillBeUnloaded()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002C37 File Offset: 0x00000E37
		public void OnApplicationQuit()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002C40 File Offset: 0x00000E40
		public void OnDestroy()
		{
			if (!this.listenForOnDestroy)
			{
				return;
			}
			if (this.trigger == DialogueTriggerEvent.OnDestroy)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002C5F File Offset: 0x00000E5F
		private IEnumerator StartAfterOneFrame()
		{
			yield return null;
			this.TryStart(null);
			yield break;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002C70 File Offset: 0x00000E70
		public void TryStart(Transform actor)
		{
			if (this.tryingToStart)
			{
				return;
			}
			this.tryingToStart = true;
			try
			{
				if (this.condition == null || this.condition.IsTrue(actor))
				{
					this.SetBindings();
					this.playableDirector.Play();
					base.DestroyIfOnce();
				}
			}
			finally
			{
				this.tryingToStart = false;
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002CD4 File Offset: 0x00000ED4
		private void SetBindings()
		{
			TimelineAsset timelineAsset = this.playableDirector.playableAsset as TimelineAsset;
			if (timelineAsset == null)
			{
				return;
			}
			for (int i = 0; i < this.bindings.Count; i++)
			{
				if (this.bindings[i] != null)
				{
					TrackAsset outputTrack = timelineAsset.GetOutputTrack(i);
					if (outputTrack != null)
					{
						this.playableDirector.SetGenericBinding(outputTrack, this.bindings[i]);
					}
				}
			}
		}

		// Token: 0x0400001B RID: 27
		[DialogueTriggerEvent]
		public DialogueTriggerEvent trigger = DialogueTriggerEvent.OnUse;

		// Token: 0x0400001C RID: 28
		[Tooltip("Playable Director through which to play the timeline. If a Timeline is assigned, play it when the trigger fires.")]
		public PlayableDirector playableDirector;

		// Token: 0x0400001D RID: 29
		[Tooltip("If Playable Director above is unassigned, or if no asset is assigned to the Playable Director, play this Timeline asset when the trigger fires.")]
		public TimelineAsset timelineAsset;

		// Token: 0x0400001E RID: 30
		public Condition condition;

		// Token: 0x0400001F RID: 31
		[Tooltip("(Optional) Bind these GameObjects to the Timeline's tracks.")]
		public List<GameObject> bindings = new List<GameObject>();

		// Token: 0x04000020 RID: 32
		private bool tryingToStart;

		// Token: 0x04000021 RID: 33
		private bool listenForOnDestroy;
	}
}
