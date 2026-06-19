using System;
using Assets.FinalIk;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x0200006C RID: 108
	[Obsolete("TODO: tiene q ser compatible con varios Full IKs", true)]
	public class CharacterInteractionSystem : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000442 RID: 1090 RVA: 0x0001431F File Offset: 0x0001251F
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			Animator componentInChildren = base.GetComponentInParent<ICharacter>().GetComponentInChildren<Animator>();
			FinalIKUtils.InitHandPoser(componentInChildren, Side.L);
			FinalIKUtils.InitHandPoser(componentInChildren, Side.R);
		}
	}
}
