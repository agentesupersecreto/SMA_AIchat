using System;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.Interacciones.InteractionObjects.InteraccionObjectCallBacksComponents
{
	// Token: 0x0200002C RID: 44
	public class InterObjInstanciadorInHand : InterObjInstanciador
	{
		// Token: 0x06000196 RID: 406 RVA: 0x00009541 File Offset: 0x00007741
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_character = this.GetComponentEnRoot(false);
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00009570 File Offset: 0x00007770
		protected override Transform GetParent()
		{
			Side side = this.hand;
			Transform transform;
			if (side != Side.L)
			{
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(this.hand.ToString());
				}
				transform = this.m_character.bodyAnimator.GetBoneTransform(HumanBodyBones.RightHand);
			}
			else
			{
				transform = this.m_character.bodyAnimator.GetBoneTransform(HumanBodyBones.LeftHand);
			}
			return transform;
		}

		// Token: 0x04000114 RID: 276
		public Side hand;

		// Token: 0x04000115 RID: 277
		private ICharacter m_character;
	}
}
