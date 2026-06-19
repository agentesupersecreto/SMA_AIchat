using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000020 RID: 32
	[RequireComponent(typeof(Selector))]
	public class SetSelectorActorOnAwake : MonoBehaviour
	{
		// Token: 0x0600011C RID: 284 RVA: 0x00006284 File Offset: 0x00004484
		private void Awake()
		{
			Selector component = base.GetComponent<Selector>();
			Animator componentInChildren = base.GetComponentInParent<Character>().GetComponentInChildren<Animator>();
			component.actorTransform = componentInChildren.transform;
		}
	}
}
