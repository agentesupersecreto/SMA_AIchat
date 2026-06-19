using System;
using Assets.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.HandPoses;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x020000AD RID: 173
	public class ManoIzqTelefonoHaciaRostro : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x060006AC RID: 1708 RVA: 0x00020824 File Offset: 0x0001EA24
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.lookAtTarget)
			{
				this.m_lookAtTargetdeffLocalPosition = this.lookAtTarget.localPosition;
			}
			if (this.Prefab == null)
			{
				throw new ArgumentNullException("Prefab", "Prefab null reference.");
			}
			Animator componentInChildren = base.GetComponentInParent<ICharacter>().GetComponentInChildren<Animator>();
			this.m_IIKUpdater = base.GetComponentInParent<IIKUpdater>();
			if (this.m_IIKUpdater == null)
			{
				throw new ArgumentNullException("m_IKBeforePhysicsV2", "m_IKBeforePhysicsV2 null reference.");
			}
			HandPoserByName handPoserByName = FinalIKUtils.InitHandPoser(componentInChildren, Side.L);
			handPoserByName.weight = 0f;
			this.clone = Object.Instantiate<GameObject>(this.Prefab);
			this.clone.transform.parent = handPoserByName.transform;
			this.clone.transform.localPosition = this.m_PositionOffset;
			this.clone.transform.localRotation = Quaternion.identity;
			if (this.m_RotationOffset != Vector3.zero)
			{
				this.clone.transform.localRotation = Quaternion.Euler(this.m_RotationOffset);
			}
			this.clone.SetActive(false);
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x0002093F File Offset: 0x0001EB3F
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x00020947 File Offset: 0x0001EB47
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x00020950 File Offset: 0x0001EB50
		private void M_IKBeforePhysicsV2_lookAtIKsHeadUpdating(IIKUpdater obj)
		{
			if (this.lookAtTarget == null)
			{
				return;
			}
			if (!this.clone.activeInHierarchy)
			{
				this.lookAtTarget.localPosition = this.m_lookAtTargetdeffLocalPosition;
				return;
			}
			this.lookAtTarget.position = Vector3.MoveTowards(this.lookAtTarget.position, this.clone.transform.position, Time.deltaTime * 5f);
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x000209C1 File Offset: 0x0001EBC1
		private void OnDiezPorciento()
		{
			this.clone.SetActive(true);
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x000209CF File Offset: 0x0001EBCF
		private void OnNoventaPorciento()
		{
			this.clone.SetActive(false);
		}

		// Token: 0x04000483 RID: 1155
		public GameObject Prefab;

		// Token: 0x04000484 RID: 1156
		public Transform lookAtTarget;

		// Token: 0x04000485 RID: 1157
		private IIKUpdater m_IIKUpdater;

		// Token: 0x04000486 RID: 1158
		[SerializeField]
		private Vector3 m_RotationOffset;

		// Token: 0x04000487 RID: 1159
		[SerializeField]
		private Vector3 m_PositionOffset;

		// Token: 0x04000488 RID: 1160
		private Vector3 m_lookAtTargetdeffLocalPosition;

		// Token: 0x04000489 RID: 1161
		private GameObject clone;
	}
}
