using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000034 RID: 52
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/usable_unity_u_i.html")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Selection/Usable Unity UI")]
	public class UsableUnityUI : MonoBehaviour
	{
		// Token: 0x0600016F RID: 367 RVA: 0x000086D0 File Offset: 0x000068D0
		public void Awake()
		{
			this.canvas = base.GetComponent<Canvas>();
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000086EC File Offset: 0x000068EC
		public void Start()
		{
			Usable componentAnywhere = Tools.GetComponentAnywhere<Usable>(base.gameObject);
			if (componentAnywhere != null && this.nameText != null)
			{
				this.nameText.text = componentAnywhere.GetName();
			}
			if (this.canvas != null)
			{
				this.canvas.enabled = false;
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00008748 File Offset: 0x00006948
		public void Show(string useMessage)
		{
			if (this.canvas != null)
			{
				this.canvas.enabled = true;
			}
			if (this.useMessageText != null)
			{
				this.useMessageText.text = useMessage;
			}
			if (this.CanTriggerAnimations() && !string.IsNullOrEmpty(this.animationTransitions.showTrigger))
			{
				this.animator.SetTrigger(this.animationTransitions.showTrigger);
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x000087BC File Offset: 0x000069BC
		public void Hide()
		{
			if (this.CanTriggerAnimations() && !string.IsNullOrEmpty(this.animationTransitions.hideTrigger))
			{
				this.animator.SetTrigger(this.animationTransitions.hideTrigger);
				return;
			}
			if (this.canvas != null)
			{
				this.canvas.enabled = false;
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00008814 File Offset: 0x00006A14
		public void OnBarkStart(Transform actor)
		{
			this.Hide();
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000881C File Offset: 0x00006A1C
		public void UpdateDisplay(bool inRange)
		{
			Color color = (inRange ? this.inRangeColor : this.outOfRangeColor);
			if (this.nameText != null)
			{
				this.nameText.color = color;
			}
			if (this.useMessageText != null)
			{
				this.useMessageText.color = color;
			}
			Tools.SetGameObjectActive(this.reticleInRange, inRange);
			Tools.SetGameObjectActive(this.reticleOutOfRange, !inRange);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000888A File Offset: 0x00006A8A
		private bool CanTriggerAnimations()
		{
			return this.animator != null && this.animationTransitions != null;
		}

		// Token: 0x04000125 RID: 293
		public Text nameText;

		// Token: 0x04000126 RID: 294
		public Text useMessageText;

		// Token: 0x04000127 RID: 295
		public Color inRangeColor = Color.yellow;

		// Token: 0x04000128 RID: 296
		public Color outOfRangeColor = Color.gray;

		// Token: 0x04000129 RID: 297
		public Graphic reticleInRange;

		// Token: 0x0400012A RID: 298
		public Graphic reticleOutOfRange;

		// Token: 0x0400012B RID: 299
		public UsableUnityUI.AnimationTransitions animationTransitions = new UsableUnityUI.AnimationTransitions();

		// Token: 0x0400012C RID: 300
		private Canvas canvas;

		// Token: 0x0400012D RID: 301
		private Animator animator;

		// Token: 0x02000075 RID: 117
		[Serializable]
		public class AnimationTransitions
		{
			// Token: 0x0400027D RID: 637
			public string showTrigger = "Show";

			// Token: 0x0400027E RID: 638
			public string hideTrigger = "Hide";
		}
	}
}
