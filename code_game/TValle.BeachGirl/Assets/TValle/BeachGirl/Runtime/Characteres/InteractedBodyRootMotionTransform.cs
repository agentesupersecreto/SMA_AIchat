using System;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Characteres
{
	// Token: 0x020000B6 RID: 182
	public class InteractedBodyRootMotionTransform : CustomMonobehaviour
	{
		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000552 RID: 1362 RVA: 0x00011C41 File Offset: 0x0000FE41
		public Transform rootMotionTransform
		{
			get
			{
				return this.m_RootMotionTransform;
			}
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x00011C4C File Offset: 0x0000FE4C
		protected override void AwakeUnityEvent()
		{
			this.m_character = this.GetComponentEnRoot(false);
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_IIKUpdater = this.GetComponentEnRoot(false);
			if (this.m_IIKUpdater == null)
			{
				return;
			}
			this.m_RootMotionTransform = this.m_character.animatorRootMotionTransform.CreateChild(this.m_character.animatorRootMotionTransform.name + "_Interacted");
			this.m_RootMotionTransform.localRotation = Quaternion.identity;
			this.m_RootMotionTransform.localPosition = Vector3.zero;
			this.m_RootMotionTransform.localScale = Vector3.one;
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x00011CFA File Offset: 0x0000FEFA
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (this.m_IIKUpdater != null)
			{
				this.m_IIKUpdater.onSingleIKUpdatedPass1 += this.M_IIKUpdater_passed;
			}
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x00011D21 File Offset: 0x0000FF21
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_IIKUpdater != null)
			{
				this.m_IIKUpdater.onSingleIKUpdatedPass1 -= this.M_IIKUpdater_passed;
			}
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x00011D4C File Offset: 0x0000FF4C
		private void M_IIKUpdater_passed(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (IKEventData.layer != this.m_targetLayer || !IKEventData.esUltimoDeLayer)
			{
				return;
			}
			if (PassEventData.esUltimo)
			{
				this.m_RootMotionTransform.SetPositionAndRotation(this.m_character.animatorRootMotionTransform.position, this.m_character.bones.chest.transform.rotation * this.m_character.bones.chest.offSetToForward);
			}
		}

		// Token: 0x04000396 RID: 918
		private IIKUpdater m_IIKUpdater;

		// Token: 0x04000397 RID: 919
		[SerializeField]
		private int m_targetLayer;

		// Token: 0x04000398 RID: 920
		[SerializeField]
		private int m_cameraPitchOffsetAngle = 15;

		// Token: 0x04000399 RID: 921
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_RootMotionTransform;

		// Token: 0x0400039A RID: 922
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_CameraMotionTransform;

		// Token: 0x0400039B RID: 923
		private AnimatorCharacter m_character;
	}
}
