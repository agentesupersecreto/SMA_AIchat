using System;
using System.Linq;
using Assets.TValle.BeachGirl.Runtime.Males;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands
{
	// Token: 0x02000251 RID: 593
	public sealed class FingerPhyscisController : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x06000FB1 RID: 4017 RVA: 0x00033A4B File Offset: 0x00031C4B
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update2);
			}
		}

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x06000FB2 RID: 4018 RVA: 0x00045DBB File Offset: 0x00043FBB
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.lateUpdateAfterCameraController);
			}
		}

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x06000FB3 RID: 4019 RVA: 0x00045DC4 File Offset: 0x00043FC4
		public Finger finger
		{
			get
			{
				return this.m_Finger;
			}
		}

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06000FB4 RID: 4020 RVA: 0x00045DCC File Offset: 0x00043FCC
		public Vector3 fingerPhysicsInitialLocalPosition
		{
			get
			{
				return this.m_fingerPhysicsInitialLocalPosition;
			}
		}

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06000FB5 RID: 4021 RVA: 0x00045DD4 File Offset: 0x00043FD4
		public Vector3 fingerBoneInitialLocalPosition
		{
			get
			{
				return this.m_fingerBoneInitialLocalPosition;
			}
		}

		// Token: 0x06000FB6 RID: 4022 RVA: 0x00045DDC File Offset: 0x00043FDC
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.handMuscle == null)
			{
				throw new ArgumentNullException("handMuscle", "handMuscle null reference.");
			}
			if (this.forearmMuscle == null)
			{
				throw new ArgumentNullException("forearmMuscle", "forearmMuscle null reference.");
			}
			if (this.armMuscle == null)
			{
				throw new ArgumentNullException("armMuscle", "armMuscle null reference.");
			}
			if (this.baseTransform == null)
			{
				throw new ArgumentNullException("baseTransform", "baseTransform null reference.");
			}
			if (this.rootTransform == null)
			{
				throw new ArgumentNullException("rootTransform", "rootTransform null reference.");
			}
			if (this.animator == null)
			{
				throw new ArgumentNullException("animator", "animator null reference.");
			}
			this.m_HandCameraController = this.GetComponentEnRoot(false);
			if (this.m_HandCameraController == null)
			{
				throw new ArgumentNullException("m_HandCameraController", "m_HandCameraController null reference.");
			}
			this.m_Finger = base.GetComponentInChildren<Finger>();
			if (this.m_Finger == null)
			{
				throw new ArgumentNullException("m_Finger", "m_Finger null reference.");
			}
			if (!this.m_Finger.isStared)
			{
				throw new InvalidOperationException("Finger debe estar inicializado");
			}
			this.m_MaleHandFingerSizeModPorShapes = this.GetComponentEnRoot(false);
			if (this.m_MaleHandFingerSizeModPorShapes == null)
			{
				throw new ArgumentNullException("m_MaleHandFingerSizeModPorShapes", "m_MaleHandFingerSizeModPorShapes null reference.");
			}
			this.m_children = (from t in base.GetComponentsInChildren<Transform>()
				where t != base.transform
				select t.gameObject).ToArray<GameObject>();
			this.m_modsDeAnchoDePartesDeDedo = new ModificadorDeFloat[6];
			for (int i = 0; i < this.m_Finger.partesEnOrden.Count; i++)
			{
				PenisPart penisPart = this.m_Finger.partesEnOrden[i];
				this.m_modsDeAnchoDePartesDeDedo[i * 2] = penisPart.mainCollider.modificableDeAncho.ObtenerModificadorNotNull(this);
				this.m_modsDeAnchoDePartesDeDedo[i * 2 + 1] = penisPart.complementoCollider.modificableDeAncho.ObtenerModificadorNotNull(this);
			}
			this.m_fingerPhysicsInitialLocalPosition = this.rootTransform.InverseTransformPoint(this.baseTransform.position);
			this.m_fingerBoneInitialLocalPosition = this.rootToHandFollower.target.InverseTransformPoint(this.baseTransform.position);
			this.rootToHandFollower.enabled = false;
			this.m_HandConstraintPositionOnFingerPenetration = this.GetComponentNotNull<HandConstraintPositionOnFingerPenetration>();
			if (!this.m_HandConstraintPositionOnFingerPenetration.isStared)
			{
				this.m_HandConstraintPositionOnFingerPenetration.ManualStart();
			}
			this.m_boneProximal = this.animator.GetBoneTransform(HumanBodyBones.RightIndexProximal);
			this.m_boneIntermediate = this.animator.GetBoneTransform(HumanBodyBones.RightIndexIntermediate);
			this.m_boneDistal = this.animator.GetBoneTransform(HumanBodyBones.RightIndexDistal);
			base.transform.ExecDeepChild(delegate(Transform t)
			{
				t.gameObject.tag = "Finger";
			}, true);
			this.GetComponentNotNull<HandDamperChangeOnFingerTouch>();
			for (int j = 0; j < this.m_Finger.partesEnOrden.Count; j++)
			{
				this.m_Finger.partesEnOrden[j].physicBone.GetComponentNotNull<RedirectorDeSkinOnCollisionStayListiner>();
			}
		}

		// Token: 0x06000FB7 RID: 4023 RVA: 0x000460F0 File Offset: 0x000442F0
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared && this.m_Finger != null)
			{
				if (!this.m_Finger.isStared)
				{
					throw new InvalidOperationException("Finger debe estar inicializado");
				}
				Transform transform = this.handMuscle.rigidbody.transform;
				base.transform.parent = transform;
				base.transform.localPosition = Vector3.zero;
				base.transform.localRotation = Quaternion.identity;
				base.transform.localScale = Vector3.one;
				this.rootTransform.localPosition = Vector3.zero;
				this.rootTransform.localRotation = Quaternion.identity;
				this.rootTransform.localScale = Vector3.one;
				this.rootTransform.rotation *= this.armatureRotationOffset;
				if (this.m_FixedJoint == null)
				{
					this.m_FixedJoint = this.m_Finger.penisLinearChain.rootPunto.jointRigidbody.gameObject.AddComponent<ForcedFixedJoint>();
					this.m_FixedJoint.connectedBody = this.handMuscle.rigidbody;
					this.m_FixedJoint.ManualStart();
					this.m_FixedJoint.connectedMassScale = 30f;
					this.m_FixedJoint.enabled = false;
				}
				this.m_FixedJoint.enabled = true;
				this.m_Finger.penisLinearChain.rootPunto.jointRigidbody.mass = this.handMuscle.rigidbody.mass;
				for (int i = 0; i < this.m_children.Length; i++)
				{
					this.m_children[i].SetActive(true);
				}
				this.rootTransform.SetPositionAndRotation(transform.position, transform.rotation * this.armatureRotationOffset);
				this.m_Finger.penisLinearChain.rootPunto.jointRigidbody.isKinematic = false;
				this.m_Finger.penisLinearChain.rootPunto.jointRigidbody.useGravity = false;
				this.m_Finger.penisLinearChain.RestoreBasePositionRotation();
				this.m_Finger.penisLinearChain.FixPointsEnOrdenAsc();
			}
		}

		// Token: 0x06000FB8 RID: 4024 RVA: 0x00046310 File Offset: 0x00044510
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (!base.isStared)
			{
				throw new InvalidOperationException("FingerPhyscisController debe estar inicializado");
			}
			Transform transform = this.animator.transform;
			base.transform.parent = transform;
			if (this.m_FixedJoint)
			{
				this.m_FixedJoint.enabled = false;
			}
			if (this.m_Finger != null)
			{
				if (!this.m_Finger.isStared)
				{
					throw new InvalidOperationException("Finger debe estar inicializado");
				}
				this.m_Finger.penisLinearChain.RestoreBasePositionRotation();
				this.m_Finger.penisLinearChain.rootPunto.jointRigidbody.isKinematic = true;
				for (int i = 0; i < this.m_children.Length; i++)
				{
					this.m_children[i].SetActive(false);
				}
			}
		}

		// Token: 0x06000FB9 RID: 4025 RVA: 0x000463DC File Offset: 0x000445DC
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			for (int i = 0; i < this.m_modsDeAnchoDePartesDeDedo.Length; i++)
			{
				ModificadorDeFloat modificadorDeFloat = this.m_modsDeAnchoDePartesDeDedo[i];
				if (modificadorDeFloat != null)
				{
					modificadorDeFloat.TryRemoverDeOwner(true);
				}
			}
		}

		// Token: 0x06000FBA RID: 4026 RVA: 0x00046418 File Offset: 0x00044618
		public override void OnUpdateEvent1()
		{
			this.m_Finger.penisLinearChain.rootPunto.jointRigidbody.mass = this.handMuscle.rigidbody.mass;
			for (int i = 0; i < this.m_modsDeAnchoDePartesDeDedo.Length; i++)
			{
				this.m_modsDeAnchoDePartesDeDedo[i].valor.valor = this.m_MaleHandFingerSizeModPorShapes.currentOverallMod;
			}
		}

		// Token: 0x06000FBB RID: 4027 RVA: 0x00046480 File Offset: 0x00044680
		public override void OnUpdateEvent2()
		{
			if (!this.fixFingerRotations)
			{
				return;
			}
			Vector3 position = this.m_boneProximal.position;
			Vector3 position2 = this.m_boneIntermediate.position;
			Vector3 position3 = this.m_boneDistal.position;
			Vector3 vector = this.m_boneProximal.rotation * -Vector3.right;
			Vector3 vector2 = this.m_boneIntermediate.rotation * -Vector3.right;
			Vector3 vector3 = this.m_boneDistal.rotation * -Vector3.right;
			Vector3 vector4 = this.m_boneDistal.rotation * Vector3.up;
			Quaternion quaternion = Quaternion.Inverse(this.armatureRotationOffset);
			this.m_boneProximal.SetPositionAndRotation(position, Quaternion.LookRotation(position2 - position, vector) * quaternion);
			this.m_boneIntermediate.SetPositionAndRotation(position2, Quaternion.LookRotation(position3 - position2, vector2) * quaternion);
			this.m_boneDistal.SetPositionAndRotation(position3, Quaternion.LookRotation(vector4, vector3) * quaternion);
		}

		// Token: 0x04000ADD RID: 2781
		public bool fixFingerRotations = true;

		// Token: 0x04000ADE RID: 2782
		public Side side;

		// Token: 0x04000ADF RID: 2783
		public Muscle handMuscle;

		// Token: 0x04000AE0 RID: 2784
		public Muscle forearmMuscle;

		// Token: 0x04000AE1 RID: 2785
		public Muscle armMuscle;

		// Token: 0x04000AE2 RID: 2786
		public BufferDeFuerzasConfig bufferDeFuerzasConfig = new BufferDeFuerzasConfig();

		// Token: 0x04000AE3 RID: 2787
		public TrasnformCopier rootToHandFollower;

		// Token: 0x04000AE4 RID: 2788
		public Transform rootTransform;

		// Token: 0x04000AE5 RID: 2789
		public Transform baseTransform;

		// Token: 0x04000AE6 RID: 2790
		public Quaternion armatureRotationOffset;

		// Token: 0x04000AE7 RID: 2791
		public Animator animator;

		// Token: 0x04000AE8 RID: 2792
		private Finger m_Finger;

		// Token: 0x04000AE9 RID: 2793
		private GameObject[] m_children;

		// Token: 0x04000AEA RID: 2794
		private HandCameraControllerV2 m_HandCameraController;

		// Token: 0x04000AEB RID: 2795
		private ModificadorDeFloat[] m_modsDeAnchoDePartesDeDedo;

		// Token: 0x04000AEC RID: 2796
		private MaleHandFingerSizeModPorShapes m_MaleHandFingerSizeModPorShapes;

		// Token: 0x04000AED RID: 2797
		private Vector3 m_fingerPhysicsInitialLocalPosition;

		// Token: 0x04000AEE RID: 2798
		private Vector3 m_fingerBoneInitialLocalPosition;

		// Token: 0x04000AEF RID: 2799
		private Transform m_boneProximal;

		// Token: 0x04000AF0 RID: 2800
		private Transform m_boneIntermediate;

		// Token: 0x04000AF1 RID: 2801
		private Transform m_boneDistal;

		// Token: 0x04000AF2 RID: 2802
		private HandConstraintPositionOnFingerPenetration m_HandConstraintPositionOnFingerPenetration;

		// Token: 0x04000AF3 RID: 2803
		private ForcedFixedJoint m_FixedJoint;
	}
}
