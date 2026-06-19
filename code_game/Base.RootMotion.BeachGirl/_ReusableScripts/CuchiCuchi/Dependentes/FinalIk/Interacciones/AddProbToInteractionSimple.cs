using System;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Miscellaneous;
using Assets._ReusableScripts.Miscellaneous.Transforms;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.Animations;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x02000098 RID: 152
	public sealed class AddProbToInteractionSimple : InteraccionObjectComienzaTerminaCallBacks
	{
		// Token: 0x06000601 RID: 1537 RVA: 0x0001DAC8 File Offset: 0x0001BCC8
		protected override void OnStaring(InteractionSystem interactionSystem)
		{
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000602 RID: 1538 RVA: 0x0001DACA File Offset: 0x0001BCCA
		public MatrixFollower follower
		{
			get
			{
				return this.m_follower;
			}
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x0001DAD4 File Offset: 0x0001BCD4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_prefab == null)
			{
				throw new ArgumentNullException("m_prefab", "m_prefab null reference.");
			}
			if (this.m_instanciarPrefab)
			{
				if (this.m_changeParent)
				{
					this.m_clone = Object.Instantiate<GameObject>(this.m_prefab, base.transform, false);
				}
				else
				{
					this.m_clone = Object.Instantiate<GameObject>(this.m_prefab);
				}
			}
			else
			{
				this.m_clone = this.m_prefab;
				if (this.m_changeParent)
				{
					this.m_clone.transform.parent = base.transform;
				}
			}
			this.m_clone.SetActive(true);
			this.m_clone.SetActive(false);
			if (this.m_initialTransform == null)
			{
				throw new ArgumentNullException("m_initialTransform", "m_initialTransform null reference.");
			}
			this.m_defOffset = this.m_initialTransform.InverseTransformPoint(this.m_clone.transform.position);
			this.m_defOffsetRot = Quaternion.Inverse(this.m_initialTransform.rotation) * this.m_clone.transform.rotation;
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x0001DBF0 File Offset: 0x0001BDF0
		protected override void OnComienza()
		{
			if (this.m_follower)
			{
				Object.Destroy(this.m_follower);
			}
			if (this.m_LookAtConstraint)
			{
				Object.Destroy(this.m_LookAtConstraint);
			}
			this.m_clone.SetActive(true);
			this.m_follower = this.m_clone.AddComponent<MatrixFollower>();
			this.m_follower.initType = MatrixFollowerBase.InitType.custom;
			this.m_follower.followOnEnable = true;
			if (!this.m_followHunanBone)
			{
				this.m_follower.target = this.m_toFollow;
			}
			else
			{
				ICharacter componentInParent = base.GetComponentInParent<ICharacter>();
				if (componentInParent == null)
				{
					throw new ArgumentNullException("charr", "charr null reference.");
				}
				Transform boneTransform = componentInParent.bodyAnimator.GetBoneTransform(this.m_humnaBone);
				this.m_follower.target = boneTransform;
			}
			this.m_clone.transform.position = this.m_follower.target.TransformPoint(this.m_defOffset);
			this.m_clone.transform.rotation = this.m_follower.target.rotation * this.m_defOffsetRot;
			this.m_follower.updateEvent = GlobalUpdater.UpdateType.lateUpdateCameraController;
			this.m_follower.localOffset = this.m_positionOffSet;
			this.m_follower.localRotOffset = Quaternion.Euler(this.m_rotationOffSet);
			this.m_follower.followScale = false;
			this.m_follower.Init();
			this.m_follower.Follow();
			if (this.m_PointAtTarget != null)
			{
				this.m_LookAtConstraint = this.m_clone.transform.GetComponentNotNull<LookAtConstraint>();
				this.m_LookAtConstraint.AddSource(new ConstraintSource
				{
					weight = 1f,
					sourceTransform = this.m_PointAtTarget
				});
			}
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0001DDAC File Offset: 0x0001BFAC
		protected override void OnTermina()
		{
			if (this.m_LookAtConstraint)
			{
				Object.Destroy(this.m_LookAtConstraint);
			}
			if (this.m_follower)
			{
				Object.Destroy(this.m_follower);
			}
			this.m_clone.SetActive(false);
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0001DDEC File Offset: 0x0001BFEC
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_LookAtConstraint)
			{
				Object.Destroy(this.m_LookAtConstraint);
			}
			if (this.m_follower)
			{
				Object.Destroy(this.m_follower);
			}
			if (this.m_clone)
			{
				Object.Destroy(this.m_clone);
			}
		}

		// Token: 0x04000425 RID: 1061
		[SerializeField]
		private bool m_changeParent = true;

		// Token: 0x04000426 RID: 1062
		[SerializeField]
		private bool m_instanciarPrefab;

		// Token: 0x04000427 RID: 1063
		[SerializeField]
		private GameObject m_prefab;

		// Token: 0x04000428 RID: 1064
		[Header("es el bone o transfrom de la interaccion, se seguira la representacion de este transform, pero del character")]
		[SerializeField]
		private Transform m_initialTransform;

		// Token: 0x04000429 RID: 1065
		[Space]
		[Space]
		[SerializeField]
		private Vector3 m_positionOffSet;

		// Token: 0x0400042A RID: 1066
		[SerializeField]
		private Vector3 m_rotationOffSet;

		// Token: 0x0400042B RID: 1067
		[SerializeField]
		private bool m_followHunanBone;

		// Token: 0x0400042C RID: 1068
		[SerializeField]
		private HumanBodyBones m_humnaBone;

		// Token: 0x0400042D RID: 1069
		[Header("si no es HumanBodyBones")]
		[SerializeField]
		private Transform m_toFollow;

		// Token: 0x0400042E RID: 1070
		[Header("Opcional")]
		[SerializeField]
		private Transform m_PointAtTarget;

		// Token: 0x0400042F RID: 1071
		private MatrixFollower m_follower;

		// Token: 0x04000430 RID: 1072
		private LookAtConstraint m_LookAtConstraint;

		// Token: 0x04000431 RID: 1073
		private GameObject m_clone;

		// Token: 0x04000432 RID: 1074
		private Vector3 m_defOffset;

		// Token: 0x04000433 RID: 1075
		private Quaternion m_defOffsetRot;
	}
}
