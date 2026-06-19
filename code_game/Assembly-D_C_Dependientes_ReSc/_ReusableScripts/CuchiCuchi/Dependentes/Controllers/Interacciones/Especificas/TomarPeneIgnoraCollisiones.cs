using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using RootMotion.Dynamics;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Especificas
{
	// Token: 0x020001C4 RID: 452
	[RequireComponent(typeof(InteractionObjectV2))]
	public class TomarPeneIgnoraCollisiones : InteraccionObjectCallBacksPauseOnHalfTime
	{
		// Token: 0x06000AD8 RID: 2776 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnStaring(InteractionSystem interactionSystem)
		{
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x000361C4 File Offset: 0x000343C4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_InteractionObjectV2 = base.GetComponent<InteractionObjectV2>();
			this.m_InteractionObjectV2.stared += this.M_InteractionObjectV2_stared;
			this.m_InteractionObjectV2.stoped += this.M_InteractionObjectV2_stoped;
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x00036211 File Offset: 0x00034411
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_InteractionObjectV2.stared -= this.M_InteractionObjectV2_stared;
			this.m_InteractionObjectV2.stoped -= this.M_InteractionObjectV2_stoped;
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x00036248 File Offset: 0x00034448
		private void M_InteractionObjectV2_stared(InteractionObjectV2Base obj, InteractionSystem arg2)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (MainChar.current == null)
			{
				throw new ArgumentNullException("MainChar.current", "MainChar.current null reference.");
			}
			MaleChar maleChar = MainChar.current as MaleChar;
			if (maleChar == null)
			{
				throw new ArgumentNullException("maleCharacter", "maleCharacter null reference.");
			}
			Penis pene = maleChar.pene;
			if (pene == null)
			{
				throw new ArgumentNullException("pene", "pene null reference.");
			}
			List<Collider> currentChildColliders = pene.penisLinearChain.currentChildColliders;
			Character componentInParent = base.GetComponentInParent<Character>();
			if (componentInParent == null)
			{
				throw new ArgumentNullException("character", "character null reference.");
			}
			switch (this.side)
			{
			default:
				throw new ArgumentOutOfRangeException(this.side.ToString());
			case Side.L:
			case Side.R:
				componentInParent.IgnorarCollosionesConMano(currentChildColliders, this.side, true);
				if (this.ignorarOtherHips || this.ignorarOtherLegs)
				{
					MalePuppetChar malePuppetChar = maleChar as MalePuppetChar;
					if (malePuppetChar != null)
					{
						PuppetMaster puppetMaster = malePuppetChar.puppetMaster;
						if (this.ignorarOtherHips)
						{
							Muscle muscle = puppetMaster.GetMuscle(puppetMaster.targetAnimator, HumanBodyBones.Hips);
							if (muscle != null)
							{
								componentInParent.IgnorarCollosionesConMano(muscle.colliders, this.side, true);
							}
						}
						if (this.ignorarOtherLegs)
						{
							Muscle muscle2 = puppetMaster.GetMuscle(puppetMaster.targetAnimator, HumanBodyBones.RightUpperLeg);
							Muscle muscle3 = puppetMaster.GetMuscle(puppetMaster.targetAnimator, HumanBodyBones.LeftUpperLeg);
							if (muscle2 != null)
							{
								componentInParent.IgnorarCollosionesConMano(muscle2.colliders, this.side, true);
							}
							if (muscle3 != null)
							{
								componentInParent.IgnorarCollosionesConMano(muscle3.colliders, this.side, true);
							}
						}
					}
				}
				return;
			}
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x000363EC File Offset: 0x000345EC
		private void M_InteractionObjectV2_stoped(InteractionObjectV2Base obj, InteractionSystem arg2)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (MainChar.current == null)
			{
				return;
			}
			MaleChar maleChar = MainChar.current as MaleChar;
			if (maleChar == null)
			{
				return;
			}
			Penis pene = maleChar.pene;
			if (pene == null)
			{
				return;
			}
			List<Collider> currentChildColliders = pene.penisLinearChain.currentChildColliders;
			Character componentInParent = base.GetComponentInParent<Character>();
			if (componentInParent == null)
			{
				return;
			}
			switch (this.side)
			{
			default:
				throw new ArgumentOutOfRangeException(this.side.ToString());
			case Side.L:
			case Side.R:
			{
				componentInParent.IgnorarCollosionesConMano(currentChildColliders, this.side, false);
				MalePuppetChar malePuppetChar = maleChar as MalePuppetChar;
				if (malePuppetChar != null)
				{
					PuppetMaster puppetMaster = malePuppetChar.puppetMaster;
					Muscle muscle = puppetMaster.GetMuscle(puppetMaster.targetAnimator, HumanBodyBones.Hips);
					if (muscle != null)
					{
						componentInParent.IgnorarCollosionesConMano(muscle.colliders, this.side, false);
					}
					Muscle muscle2 = puppetMaster.GetMuscle(puppetMaster.targetAnimator, HumanBodyBones.RightUpperLeg);
					Muscle muscle3 = puppetMaster.GetMuscle(puppetMaster.targetAnimator, HumanBodyBones.LeftUpperLeg);
					if (muscle2 != null)
					{
						componentInParent.IgnorarCollosionesConMano(muscle2.colliders, this.side, false);
					}
					if (muscle3 != null)
					{
						componentInParent.IgnorarCollosionesConMano(muscle3.colliders, this.side, false);
					}
				}
				return;
			}
			}
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x00002BEA File Offset: 0x00000DEA
		public override void OnPause()
		{
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x00002BEA File Offset: 0x00000DEA
		public override void OnResume()
		{
		}

		// Token: 0x04000842 RID: 2114
		public Side side;

		// Token: 0x04000843 RID: 2115
		private InteractionObjectV2 m_InteractionObjectV2;

		// Token: 0x04000844 RID: 2116
		public bool ignorarOtherHips;

		// Token: 0x04000845 RID: 2117
		public bool ignorarOtherLegs;
	}
}
