using System;
using System.Collections;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000C5 RID: 197
	public abstract class AnimatorCharacter : Character, IAnimatorCharacter, ICharacter, ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable
	{
		// Token: 0x17000244 RID: 580
		// (get) Token: 0x060005E5 RID: 1509
		protected abstract GlobalUpdater.UpdateType postProcesadoDeAnimacionresEvento { get; }

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x00012A50 File Offset: 0x00010C50
		public override int updateEvent1Index
		{
			get
			{
				return (int)this.postProcesadoDeAnimacionresEvento;
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x060005E7 RID: 1511 RVA: 0x00012A58 File Offset: 0x00010C58
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.lateUpdate1);
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x060005E8 RID: 1512 RVA: 0x00012A60 File Offset: 0x00010C60
		public BonesTransforms bones
		{
			get
			{
				return this.m_Bones;
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x060005E9 RID: 1513 RVA: 0x00012A68 File Offset: 0x00010C68
		public Animator animator
		{
			get
			{
				if (!base.isAwaken && this.m_Animator == null)
				{
					this.m_Animator = base.GetComponentInChildren<Animator>();
				}
				return this.m_Animator;
			}
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x060005EA RID: 1514 RVA: 0x00012A92 File Offset: 0x00010C92
		public bool areLimbsFixed
		{
			get
			{
				return this.m_areLimbsFixed;
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x060005EB RID: 1515 RVA: 0x00012A9C File Offset: 0x00010C9C
		public sealed override Vector3 worldFirstPersonViewPoint
		{
			get
			{
				if (this.m_Bones.eyeL.transform == null || this.m_Bones.eyeR.transform == null)
				{
					return this.m_Bones.head.transform.TransformPoint(this.localFPSOffset);
				}
				Vector3 vector = this.m_Bones.eyeL.transform.position + this.m_Bones.eyeR.transform.position;
				vector /= 2f;
				Vector3 vector2 = this.m_Bones.head.transform.InverseTransformPoint(vector) + this.localFPSOffset;
				return this.m_Bones.head.transform.TransformPoint(vector2);
			}
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x00012B69 File Offset: 0x00010D69
		public override Vector3 worldHeadPosition
		{
			get
			{
				return this.m_Bones.head.transform.position;
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x00012B80 File Offset: 0x00010D80
		public override Quaternion centerOfMassRotation
		{
			get
			{
				return this.m_currentBodyRotation;
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x00012B88 File Offset: 0x00010D88
		public override Vector3 centerOfMassPosition
		{
			get
			{
				return this.m_currentBodyPosition;
			}
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x00012B90 File Offset: 0x00010D90
		public override Vector3 centerOfMassVelocity
		{
			get
			{
				return this.m_currentBodyVelocity;
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x00012B98 File Offset: 0x00010D98
		public override Vector3 centerOfMassUpDirection
		{
			get
			{
				return this.m_currentBodyRotation * Vector3.up;
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x00012BAA File Offset: 0x00010DAA
		public override Vector3 centerOfMassForwardDirection
		{
			get
			{
				return this.m_currentBodyRotation * Vector3.forward;
			}
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x00012BBC File Offset: 0x00010DBC
		public override Vector3 centerOfMassRightDirection
		{
			get
			{
				return this.m_currentBodyRotation * Vector3.right;
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x060005F3 RID: 1523 RVA: 0x00012BCE File Offset: 0x00010DCE
		public override Vector3 localFPSOffset
		{
			get
			{
				return this.m_localFromHeadFPSOffset;
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x00012BD8 File Offset: 0x00010DD8
		public override Vector3 worldHeadUp
		{
			get
			{
				return (this.m_Bones.neck.transform.position - this.m_Bones.head.transform.position).normalized;
			}
		}

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x00012C1C File Offset: 0x00010E1C
		public sealed override Transform trasnformParaObservar
		{
			get
			{
				return this.m_Bones.eyeL.transform;
			}
		}

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x00012C2E File Offset: 0x00010E2E
		public override Quaternion rotacion
		{
			get
			{
				return this.bodyAnimator.transform.rotation;
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x00012C40 File Offset: 0x00010E40
		public override Vector3 posicion
		{
			get
			{
				return this.bodyAnimator.transform.position;
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x060005F8 RID: 1528
		public abstract IMapaDeHuesosDeCharacter mapaDeHuesos { get; }

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x060005F9 RID: 1529 RVA: 0x00012C52 File Offset: 0x00010E52
		public Transform interactedBodyAnimatorRootMotionTransform
		{
			get
			{
				return this.m_InteractedBodyRootMotionTransform.rootMotionTransform;
			}
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00012C60 File Offset: 0x00010E60
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_InteractedBodyRootMotionTransform = base.GetComponentNotNull<InteractedBodyRootMotionTransform>();
			this.m_Animator = base.GetComponentInChildren<Animator>();
			if (this.m_Animator == null)
			{
				throw new ArgumentNullException("m_Animator", "m_Animator null reference.");
			}
			this.m_AnimatorCallbacks = this.m_Animator.GetComponentNotNull<AnimatorCallbacks>();
			this.m_AnimatorCallbacks.onAnimatorMove += this.OnAnimatorMove;
			this.m_AnimatorCallbacks.onAnimatorIK += this.OnAnimatorIK;
			this.m_Bones.Init(this.m_Animator, this);
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x060005FB RID: 1531 RVA: 0x00012CFC File Offset: 0x00010EFC
		public override Transform trasnformParaManipular
		{
			get
			{
				return this.bodyAnimator.GetBoneTransform(HumanBodyBones.RightHand);
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x060005FC RID: 1532 RVA: 0x00012D0B File Offset: 0x00010F0B
		public override Transform trasnformParaComunicarse
		{
			get
			{
				return this.bodyAnimator.GetBoneTransform(HumanBodyBones.Jaw);
			}
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00012D1A File Offset: 0x00010F1A
		public override bool ObjetoEsMiPierna(Collider col)
		{
			return this.ObjetoEsMiPierna(col.transform);
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00012D28 File Offset: 0x00010F28
		public override bool ObjetoEsMiPierna(Rigidbody obj)
		{
			return this.ObjetoEsMiPierna(obj.transform);
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x00012D36 File Offset: 0x00010F36
		public override bool ObjetoEsMiPierna(Transform obj)
		{
			return obj.IsChildOf(this.m_Bones.legR.transform) || obj.IsChildOf(this.m_Bones.legR.transform);
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x00012D68 File Offset: 0x00010F68
		public override bool ObjetoEsMiTorzo(Collider col)
		{
			return this.ObjetoEsMiTorzo(col.transform);
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x00012D76 File Offset: 0x00010F76
		public override bool ObjetoEsMiTorzo(Rigidbody obj)
		{
			return this.ObjetoEsMiTorzo(obj.transform);
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00012D84 File Offset: 0x00010F84
		public override bool ObjetoEsMiTorzo(Transform obj)
		{
			return (obj.IsChildOf(this.m_Bones.hips.transform) || obj.IsChildOf(this.m_Bones.spine.transform) || obj.IsChildOf(this.m_Bones.chest.transform)) && !obj.IsChildOf(this.m_Bones.armsL.transform) && !obj.IsChildOf(this.m_Bones.armsR.transform) && !obj.IsChildOf(this.m_Bones.legL.transform) && !obj.IsChildOf(this.m_Bones.legR.transform) && !obj.IsChildOf(this.m_Bones.head.transform);
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x00012E54 File Offset: 0x00011054
		public override bool ObjetoEsMiMano(Collider col)
		{
			return col.transform.IsChildOf(this.m_Bones.handL.transform) || col.transform.IsChildOf(this.m_Bones.handR.transform);
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x00012E90 File Offset: 0x00011090
		public override bool ObjetoEsMiMano(Rigidbody rigid)
		{
			return rigid.transform.IsChildOf(this.m_Bones.handL.transform) || rigid.transform.IsChildOf(this.m_Bones.handR.transform);
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x00012ECC File Offset: 0x000110CC
		public override bool ObjetoEsMiMano(Transform obj)
		{
			return obj.IsChildOf(this.m_Bones.handL.transform) || obj.IsChildOf(this.m_Bones.handR.transform);
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x00012EFE File Offset: 0x000110FE
		public override bool ObjetoEsMiAnteBrazo(Transform obj)
		{
			return obj.IsChildOf(this.m_Bones.foreArmsL.transform) || obj.IsChildOf(this.m_Bones.foreArmsR.transform);
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x00012F30 File Offset: 0x00011130
		public override bool ObjetoEsMiDedo(Collider obj)
		{
			return false;
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x00012F33 File Offset: 0x00011133
		public override bool ObjetoEsMiDedo(Rigidbody obj)
		{
			return false;
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00012F36 File Offset: 0x00011136
		public override bool ObjetoEsMiDedo(Transform obj)
		{
			return false;
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x00012F3C File Offset: 0x0001113C
		[Obsolete("la pose se tiene q arreglar antes de importar el char")]
		public void FixLimbRotations()
		{
			if (this.m_Animator == null)
			{
				this.m_Animator = base.GetComponent<Animator>();
			}
			if (this.m_Animator == null)
			{
				Debug.LogError(base.gameObject, base.gameObject);
				return;
			}
			Transform boneTransform = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
			Transform boneTransform2 = this.m_Animator.GetBoneTransform(HumanBodyBones.RightLowerArm);
			Transform boneTransform3 = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
			Transform boneTransform4 = this.m_Animator.GetBoneTransform(HumanBodyBones.RightLowerLeg);
			this.m_DefaultLimbsRotations = new AnimatorCharacter.DefaultLimbsRotations();
			this.m_DefaultLimbsRotations.forearm_l = boneTransform.localRotation;
			this.m_DefaultLimbsRotations.forearm_r = boneTransform2.localRotation;
			this.m_DefaultLimbsRotations.calf_l = boneTransform3.localRotation;
			this.m_DefaultLimbsRotations.calf_r = boneTransform4.localRotation;
			this.FixLocalRot(boneTransform, (Vector3 v) => new Vector3(v.x, v.y + 7f, v.z));
			this.FixLocalRot(boneTransform2, (Vector3 v) => new Vector3(v.x, v.y - 7f, v.z));
			this.FixLocalRot(boneTransform3, (Vector3 v) => new Vector3(v.x - 7f, v.y, v.z));
			this.FixLocalRot(boneTransform4, (Vector3 v) => new Vector3(v.x - 7f, v.y, v.z));
			this.m_areLimbsFixed = true;
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x000130A7 File Offset: 0x000112A7
		protected virtual void OnAnimatorMove()
		{
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x000130A9 File Offset: 0x000112A9
		protected virtual void OnAnimatorIK(int layer)
		{
			this.m_currentBodyRotation = this.m_Animator.bodyRotation;
			this.m_currentBodyPosition = this.m_Animator.bodyPosition;
			this.m_currentBodyVelocity = this.m_Animator.velocity;
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x000130E0 File Offset: 0x000112E0
		[Obsolete("la pose se tiene q arreglar antes de importar el char")]
		public void RevertLimbRotations()
		{
			if (!this.m_areLimbsFixed)
			{
				return;
			}
			if (this.m_Animator == null)
			{
				this.m_Animator = base.GetComponent<Animator>();
			}
			if (this.m_Animator == null)
			{
				Debug.LogError(base.gameObject, base.gameObject);
				return;
			}
			Transform boneTransform = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
			Transform boneTransform2 = this.m_Animator.GetBoneTransform(HumanBodyBones.RightLowerArm);
			Transform boneTransform3 = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
			Transform boneTransform4 = this.m_Animator.GetBoneTransform(HumanBodyBones.RightLowerLeg);
			boneTransform.localRotation = this.m_DefaultLimbsRotations.forearm_l;
			boneTransform2.localRotation = this.m_DefaultLimbsRotations.forearm_r;
			boneTransform3.localRotation = this.m_DefaultLimbsRotations.calf_l;
			boneTransform4.localRotation = this.m_DefaultLimbsRotations.calf_r;
			this.m_areLimbsFixed = false;
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x000131B0 File Offset: 0x000113B0
		private void FixLocalRot(Transform target, Func<Vector3, Vector3> Getter)
		{
			Vector3 eulerAngles = target.localRotation.eulerAngles;
			target.localEulerAngles = Getter(eulerAngles);
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x000131D9 File Offset: 0x000113D9
		public sealed override void OnUpdateEvent2()
		{
			this.m_Bones.OnPostAnimaciones();
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x000131E6 File Offset: 0x000113E6
		public sealed override void OnUpdateEvent1()
		{
			this.m_Bones.OnPostProcesadoDeAnimaciones();
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x00013220 File Offset: 0x00011420
		Transform ICharacterRoot.get_transform()
		{
			return base.transform;
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x00013228 File Offset: 0x00011428
		T ICharacterRoot.GetComponentInChildren<T>()
		{
			return base.GetComponentInChildren<T>();
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x00013230 File Offset: 0x00011430
		T ICharacterRoot.GetComponentInParent<T>()
		{
			return base.GetComponentInParent<T>();
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x00013238 File Offset: 0x00011438
		T ICharacterRoot.GetComponentInParent<T>(bool includeInactive)
		{
			return base.GetComponentInParent<T>(includeInactive);
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x00013241 File Offset: 0x00011441
		T ICharacterRoot.GetComponentInChildren<T>(bool includeInactive)
		{
			return base.GetComponentInChildren<T>(includeInactive);
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x0001324A File Offset: 0x0001144A
		T ICharacterRoot.GetComponent<T>()
		{
			return base.GetComponent<T>();
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x00013252 File Offset: 0x00011452
		void ICharacterRoot.GetComponentsInChildren<T>(List<T> results)
		{
			base.GetComponentsInChildren<T>(results);
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0001325B File Offset: 0x0001145B
		void ICharacterRoot.GetComponentsInChildren<T>(bool includeInactive, List<T> result)
		{
			base.GetComponentsInChildren<T>(includeInactive, result);
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x00013265 File Offset: 0x00011465
		T[] ICharacterRoot.GetComponentsInChildren<T>(bool includeInactive)
		{
			return base.GetComponentsInChildren<T>(includeInactive);
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x0001326E File Offset: 0x0001146E
		Coroutine ICharacterRoot.StartCoroutine(IEnumerator routine)
		{
			return base.StartCoroutine(routine);
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x00013277 File Offset: 0x00011477
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0001327F File Offset: 0x0001147F
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x040003CA RID: 970
		[HideInInspector]
		[SerializeField]
		protected Animator m_Animator;

		// Token: 0x040003CB RID: 971
		protected AnimatorCallbacks m_AnimatorCallbacks;

		// Token: 0x040003CC RID: 972
		[SerializeField]
		protected Vector3 m_localFromHeadFPSOffset = new Vector3(0f, 0f, 0.1f);

		// Token: 0x040003CD RID: 973
		[HideInInspector]
		[SerializeField]
		private AnimatorCharacter.DefaultLimbsRotations m_DefaultLimbsRotations;

		// Token: 0x040003CE RID: 974
		[HideInInspector]
		[SerializeField]
		private bool m_areLimbsFixed;

		// Token: 0x040003CF RID: 975
		private Quaternion m_currentBodyRotation;

		// Token: 0x040003D0 RID: 976
		private Vector3 m_currentBodyPosition;

		// Token: 0x040003D1 RID: 977
		private Vector3 m_currentBodyVelocity;

		// Token: 0x040003D2 RID: 978
		private BonesTransforms m_Bones = new BonesTransforms();

		// Token: 0x040003D3 RID: 979
		private InteractedBodyRootMotionTransform m_InteractedBodyRootMotionTransform;

		// Token: 0x0200019F RID: 415
		[Serializable]
		private class DefaultLimbsRotations
		{
			// Token: 0x0400095B RID: 2395
			public Quaternion forearm_l;

			// Token: 0x0400095C RID: 2396
			public Quaternion forearm_r;

			// Token: 0x0400095D RID: 2397
			public Quaternion calf_l;

			// Token: 0x0400095E RID: 2398
			public Quaternion calf_r;
		}
	}
}
