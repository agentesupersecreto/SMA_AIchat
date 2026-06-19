using System;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.Miscellaneous.Checkers;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones
{
	// Token: 0x0200003B RID: 59
	[RequireComponent(typeof(EmulatedSphereTrigger))]
	public class RecostarseInteraccionAdderOnRange : InteraccionAdderOnRangeBase<FemaleAnimController>
	{
		// Token: 0x0600028C RID: 652 RVA: 0x0000D915 File Offset: 0x0000BB15
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_recostable = base.GetComponentInParent<IRecostable>();
			if (this.m_recostable == null)
			{
				throw new ArgumentNullException("m_recostable", "m_recostable null reference.");
			}
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000D944 File Offset: 0x0000BB44
		public override void DoUpdate()
		{
			Vector3 gotoWorldPositon = this.m_recostable.gotoWorldPositon;
			base.transform.SetPositionAndRotation(gotoWorldPositon, this.m_recostable.worldRotation);
			for (int i = 0; i < this.m_TriggerRanges.Length; i++)
			{
				TriggerRanges triggerRanges = this.m_TriggerRanges[i];
				if (triggerRanges != null)
				{
					triggerRanges.transform.SetPositionAndRotation(gotoWorldPositon, this.m_recostable.worldRotation);
				}
			}
			base.DoUpdate();
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000D9B1 File Offset: 0x0000BBB1
		protected override void Add(FemaleAnimController interactable)
		{
			interactable.SetOnRecostableRange(this.m_recostable);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000D9BF File Offset: 0x0000BBBF
		protected override void Remove(FemaleAnimController interactable)
		{
			interactable.SetOffRecostableRange(this.m_recostable);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000D9CD File Offset: 0x0000BBCD
		protected override ICharacter GetCharacter(FemaleAnimController interactable)
		{
			if (interactable == null)
			{
				return null;
			}
			return interactable.character;
		}

		// Token: 0x040001C5 RID: 453
		private IRecostable m_recostable;
	}
}
