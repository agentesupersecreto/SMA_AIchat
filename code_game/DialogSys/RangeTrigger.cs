using System;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000049 RID: 73
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/range_trigger.html")]
	[AddComponentMenu("Dialogue System/Actor/Range Trigger")]
	public class RangeTrigger : MonoBehaviour
	{
		// Token: 0x06000229 RID: 553 RVA: 0x0000B422 File Offset: 0x00009622
		public void OnTriggerEnter(Collider other)
		{
			if (this.condition.IsTrue(other.transform))
			{
				this.SetTargets(true);
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000B43E File Offset: 0x0000963E
		public void OnTriggerExit(Collider other)
		{
			if (this.condition.IsTrue(other.transform))
			{
				this.SetTargets(false);
			}
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000B45A File Offset: 0x0000965A
		public void OnTriggerEnter2D(Collider2D other)
		{
			if (this.condition.IsTrue(other.transform))
			{
				this.SetTargets(true);
			}
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000B476 File Offset: 0x00009676
		public void OnTriggerExit2D(Collider2D other)
		{
			if (this.condition.IsTrue(other.transform))
			{
				this.SetTargets(false);
			}
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000B494 File Offset: 0x00009694
		private void SetTargets(bool value)
		{
			GameObject[] array = this.gameObjects;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value);
			}
			foreach (Component component in this.components)
			{
				if (component is Collider)
				{
					(component as Collider).enabled = value;
				}
				else if (component is Renderer)
				{
					(component as Renderer).enabled = value;
				}
				else if (component is Animation)
				{
					(component as Animation).enabled = value;
				}
				else if (component is Animator)
				{
					(component as Animator).enabled = value;
				}
				else if (component is Behaviour)
				{
					(component as Behaviour).enabled = value;
				}
				else if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Internal error - Range Trigger doesn't know how to handle {1} of type {2}", new object[]
					{
						"Dialogue System",
						component,
						component.GetType().Name
					}));
				}
			}
			if (value)
			{
				this.onEnter.Invoke();
				return;
			}
			this.onExit.Invoke();
		}

		// Token: 0x040001A6 RID: 422
		[Tooltip("These conditions must be true for the Range Trigger to affect GameObjects and components and invoke events")]
		public Condition condition;

		// Token: 0x040001A7 RID: 423
		[Tooltip("Activate these GameObjects on trigger enter, deactivate them on trigger exit")]
		public GameObject[] gameObjects;

		// Token: 0x040001A8 RID: 424
		[Tooltip("Enable these components on trigger enter, disable them on trigger exit")]
		public Component[] components;

		// Token: 0x040001A9 RID: 425
		public UnityEvent onEnter = new UnityEvent();

		// Token: 0x040001AA RID: 426
		public UnityEvent onExit = new UnityEvent();
	}
}
