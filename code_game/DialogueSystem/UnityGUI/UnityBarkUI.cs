using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002D1 RID: 721
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Bark/Unity Bark UI (Legacy Unity GUI)")]
	public class UnityBarkUI : MonoBehaviour, IBarkUI
	{
		// Token: 0x17000A8F RID: 2703
		// (get) Token: 0x06001D92 RID: 7570 RVA: 0x00039C64 File Offset: 0x00037E64
		public bool showText
		{
			get
			{
				return this.textDisplaySetting == BarkSubtitleSetting.Show || (this.textDisplaySetting == BarkSubtitleSetting.SameAsDialogueManager && DialogueManager.DisplaySettings.subtitleSettings.showNPCSubtitlesDuringLine);
			}
		}

		// Token: 0x06001D93 RID: 7571 RVA: 0x00039CA0 File Offset: 0x00037EA0
		public virtual void Awake()
		{
			this.CheckUnityBarkUIOnGUI();
		}

		// Token: 0x06001D94 RID: 7572 RVA: 0x00039CA8 File Offset: 0x00037EA8
		public virtual void OnDestroy()
		{
			Object.Destroy(this.unityBarkUIOnGUI);
			this.unityBarkUIOnGUI = null;
		}

		// Token: 0x06001D95 RID: 7573 RVA: 0x00039CBC File Offset: 0x00037EBC
		protected void CheckUnityBarkUIOnGUI()
		{
			if (this.unityBarkUIOnGUI == null)
			{
				this.unityBarkUIOnGUI = base.GetComponent<UnityBarkUIOnGUI>();
				if (this.unityBarkUIOnGUI == null)
				{
					this.unityBarkUIOnGUI = base.gameObject.AddComponent<UnityBarkUIOnGUI>();
				}
			}
		}

		// Token: 0x17000A90 RID: 2704
		// (get) Token: 0x06001D96 RID: 7574 RVA: 0x00039D08 File Offset: 0x00037F08
		public virtual bool IsPlaying
		{
			get
			{
				return this.secondsLeft > 0f;
			}
		}

		// Token: 0x06001D97 RID: 7575 RVA: 0x00039D18 File Offset: 0x00037F18
		public virtual void Bark(Subtitle subtitle)
		{
			if (this.showText && subtitle != null && !string.IsNullOrEmpty(subtitle.formattedText.text))
			{
				if (Camera.main == null && DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: There is no camera in the scene marked MainCamera, but UnityBarkUI requires one.", "Dialogue System"));
				}
				this.CheckUnityBarkUIOnGUI();
				this.unityBarkUIOnGUI.Show(subtitle, this.duration, this.guiSkin, this.guiStyleName, this.textStyle, this.textStyleColor, this.includeName, this.textPosition);
				this.CheckPlayerCameraTransform();
				base.StopAllCoroutines();
				this.secondsLeft = ((!Mathf.Approximately(0f, this.duration)) ? this.duration : DialogueManager.GetBarkDuration(subtitle.formattedText.text));
			}
		}

		// Token: 0x06001D98 RID: 7576 RVA: 0x00039DF8 File Offset: 0x00037FF8
		public virtual void Update()
		{
			if (this.secondsLeft > 0f)
			{
				this.secondsLeft -= Time.deltaTime;
				if (this.checkIfPlayerVisible)
				{
					this.CheckPlayerVisibility();
				}
				if (this.secondsLeft <= 0f && !this.waitUntilSequenceEnds)
				{
					this.Hide();
				}
			}
		}

		// Token: 0x06001D99 RID: 7577 RVA: 0x00039E5C File Offset: 0x0003805C
		public void OnBarkEnd(Transform actor)
		{
			if (this.waitUntilSequenceEnds)
			{
				this.Hide();
			}
		}

		// Token: 0x06001D9A RID: 7578 RVA: 0x00039E70 File Offset: 0x00038070
		public void Hide()
		{
			if (this.unityBarkUIOnGUI.enabled)
			{
				base.StartCoroutine(this.unityBarkUIOnGUI.FadeOut(this.fadeDuration));
			}
			this.secondsLeft = 0f;
		}

		// Token: 0x06001D9B RID: 7579 RVA: 0x00039EA8 File Offset: 0x000380A8
		protected void CheckPlayerVisibility()
		{
			this.CheckPlayerCameraTransform();
			bool flag = true;
			RaycastHit raycastHit;
			if (this.playerCameraTransform != null && Physics.Linecast(this.unityBarkUIOnGUI.BarkPosition, this.playerCameraTransform.position, out raycastHit, this.visibilityLayerMask))
			{
				flag = raycastHit.collider == this.playerCameraCollider;
			}
			if (this.unityBarkUIOnGUI != null)
			{
				if (this.unityBarkUIOnGUI.enabled && !flag)
				{
					this.unityBarkUIOnGUI.enabled = false;
				}
				else if (!this.unityBarkUIOnGUI.enabled && flag)
				{
					this.unityBarkUIOnGUI.enabled = true;
				}
			}
		}

		// Token: 0x06001D9C RID: 7580 RVA: 0x00039F68 File Offset: 0x00038168
		protected void CheckPlayerCameraTransform()
		{
			if (this.playerCameraTransform == null && Camera.main != null)
			{
				this.playerCameraTransform = Camera.main.transform;
				this.playerCameraCollider = ((!(this.playerCameraTransform != null)) ? null : this.playerCameraTransform.GetComponent<Collider>());
			}
		}

		// Token: 0x04001119 RID: 4377
		public Transform textPosition;

		// Token: 0x0400111A RID: 4378
		public GUISkin guiSkin;

		// Token: 0x0400111B RID: 4379
		public string guiStyleName;

		// Token: 0x0400111C RID: 4380
		public bool includeName;

		// Token: 0x0400111D RID: 4381
		public float duration = 4f;

		// Token: 0x0400111E RID: 4382
		public float fadeDuration = 0.5f;

		// Token: 0x0400111F RID: 4383
		public TextStyle textStyle = TextStyle.Shadow;

		// Token: 0x04001120 RID: 4384
		public Color textStyleColor = Color.black;

		// Token: 0x04001121 RID: 4385
		public BarkSubtitleSetting textDisplaySetting;

		// Token: 0x04001122 RID: 4386
		public bool waitUntilSequenceEnds;

		// Token: 0x04001123 RID: 4387
		public bool checkIfPlayerVisible = true;

		// Token: 0x04001124 RID: 4388
		public LayerMask visibilityLayerMask = 1;

		// Token: 0x04001125 RID: 4389
		protected UnityBarkUIOnGUI unityBarkUIOnGUI;

		// Token: 0x04001126 RID: 4390
		protected Transform playerCameraTransform;

		// Token: 0x04001127 RID: 4391
		protected Collider playerCameraCollider;

		// Token: 0x04001128 RID: 4392
		protected float secondsLeft;
	}
}
