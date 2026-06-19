using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000040 RID: 64
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/navigate_on_mouse_click.html")]
	[AddComponentMenu("Dialogue System/Actor/Player/Navigate On Mouse Click")]
	[RequireComponent(typeof(NavMeshAgent))]
	public class NavigateOnMouseClick : MonoBehaviour
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x0000A074 File Offset: 0x00008274
		private void Awake()
		{
			this.myTransform = base.transform;
			this.anim = base.GetComponent<Animation>();
			this.navMeshAgent = base.GetComponent<NavMeshAgent>();
			if (this.navMeshAgent == null)
			{
				Debug.LogWarning(string.Format("{0}: No NavMeshAgent found on {1}. Disabling {2}.", "Dialogue System", base.name, base.GetType().Name));
				base.enabled = false;
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0000A0E0 File Offset: 0x000082E0
		private void Update()
		{
			if (this.navMeshAgent.remainingDistance < this.stoppingDistance)
			{
				if (this.idle != null && this.anim != null)
				{
					this.anim.CrossFade(this.idle.name);
				}
			}
			else if (this.run != null && this.anim != null)
			{
				this.anim.CrossFade(this.run.name);
			}
			if (this.ignoreClicksOnUI && EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
			{
				return;
			}
			if (Input.GetMouseButtonDown((int)this.mouseButton) && GUIUtility.hotControl == 0)
			{
				Plane plane = new Plane(Vector3.up, this.myTransform.position);
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float num = 0f;
				if (plane.Raycast(ray, out num))
				{
					this.navMeshAgent.SetDestination(ray.GetPoint(num));
					return;
				}
			}
			else if (Input.GetMouseButton((int)this.mouseButton) && GUIUtility.hotControl == 0)
			{
				Plane plane2 = new Plane(Vector3.up, this.myTransform.position);
				Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
				float num2 = 0f;
				if (plane2.Raycast(ray2, out num2))
				{
					this.navMeshAgent.SetDestination(ray2.GetPoint(num2));
				}
			}
		}

		// Token: 0x04000164 RID: 356
		public AnimationClip idle;

		// Token: 0x04000165 RID: 357
		public AnimationClip run;

		// Token: 0x04000166 RID: 358
		public float stoppingDistance = 0.5f;

		// Token: 0x04000167 RID: 359
		public NavigateOnMouseClick.MouseButtonType mouseButton;

		// Token: 0x04000168 RID: 360
		public bool ignoreClicksOnUI = true;

		// Token: 0x04000169 RID: 361
		private Transform myTransform;

		// Token: 0x0400016A RID: 362
		private NavMeshAgent navMeshAgent;

		// Token: 0x0400016B RID: 363
		private Animation anim;

		// Token: 0x02000087 RID: 135
		public enum MouseButtonType
		{
			// Token: 0x040002BD RID: 701
			Left,
			// Token: 0x040002BE RID: 702
			Right,
			// Token: 0x040002BF RID: 703
			Middle
		}
	}
}
