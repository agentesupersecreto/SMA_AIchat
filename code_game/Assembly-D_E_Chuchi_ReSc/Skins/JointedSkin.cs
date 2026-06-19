using System;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000038 RID: 56
	public abstract class JointedSkin<Tjoint> : JointedSkinBase where Tjoint : RecalculableJointBase
	{
		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060001B3 RID: 435
		public abstract Tjoint joint { get; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x0000756E File Offset: 0x0000576E
		public sealed override RecalculableJointBase recalculableJoint
		{
			get
			{
				return this.joint;
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0000757C File Offset: 0x0000577C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared)
			{
				if (!this.joint.gameObject.activeSelf)
				{
					this.joint.gameObject.SetActive(true);
				}
				if (!this.joint.enabled)
				{
					this.joint.enabled = true;
				}
			}
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x000075E8 File Offset: 0x000057E8
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (!quitting)
			{
				if (this.joint.gameObject.activeSelf)
				{
					this.joint.gameObject.SetActive(false);
				}
				if (this.joint.enabled)
				{
					this.joint.enabled = false;
				}
			}
		}
	}
}
