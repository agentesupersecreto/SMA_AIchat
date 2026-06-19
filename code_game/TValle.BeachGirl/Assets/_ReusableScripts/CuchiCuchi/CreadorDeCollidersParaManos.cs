using System;
using System.Collections.Generic;
using Assets._ReusableScripts.BoneColliders;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using Assets._ReusableScripts.CuchiCuchi.Skins.Colliders;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000CE RID: 206
	[Serializable]
	public class CreadorDeCollidersParaManos
	{
		// Token: 0x06000736 RID: 1846 RVA: 0x00015336 File Offset: 0x00013536
		public CreadorDeCollidersParaManos(CreadorDeCollidersParaManos.Side side, IHandBoneMap handBonesMap, Vector3 localForward, Animator animator, CustomMonobehaviourBase owner, Transform boneTarget)
			: this(side, handBonesMap, animator, owner, boneTarget)
		{
			this.m_localForward = localForward;
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x0001534D File Offset: 0x0001354D
		public CreadorDeCollidersParaManos(CreadorDeCollidersParaManos.Side side, Vector3 localForward, Animator animator, CustomMonobehaviourBase owner, Transform boneTarget)
			: this(side, animator, owner, boneTarget, null)
		{
			this.m_localForward = localForward;
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x00015363 File Offset: 0x00013563
		public CreadorDeCollidersParaManos(CreadorDeCollidersParaManos.Side side, IHandBoneMap handBonesMap, Animator animator, CustomMonobehaviourBase owner, Transform boneTarget)
			: this(side, animator, owner, boneTarget, null)
		{
			if (handBonesMap == null)
			{
				throw new ArgumentNullException("handBonesMap", "handBonesMap null reference.");
			}
			this.handBonesMap = handBonesMap;
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x0001538C File Offset: 0x0001358C
		public CreadorDeCollidersParaManos(CreadorDeCollidersParaManos.Side side, Animator animator, CustomMonobehaviourBase owner, Transform boneTarget, Rigidbody Rigid = null)
		{
			this.m_side = side;
			if (boneTarget == null)
			{
				throw new ArgumentNullException("boneTarget", "boneTarget null reference.");
			}
			if (owner == null)
			{
				throw new ArgumentNullException("owner", "owner null reference.");
			}
			if (animator == null)
			{
				throw new ArgumentNullException("animator", "animator null reference.");
			}
			this.m_Animator = animator;
			this.m_boneTarget = boneTarget;
			this.m_owner = owner;
			this.m_rigid = Rigid;
		}

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x0600073A RID: 1850 RVA: 0x00015459 File Offset: 0x00013659
		// (set) Token: 0x0600073B RID: 1851 RVA: 0x00015461 File Offset: 0x00013661
		public IHandBoneMap handBonesMap { get; set; }

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x0600073C RID: 1852 RVA: 0x0001546A File Offset: 0x0001366A
		public Rigidbody rigid
		{
			get
			{
				return this.m_rigid;
			}
		}

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x0600073D RID: 1853 RVA: 0x00015472 File Offset: 0x00013672
		// (set) Token: 0x0600073E RID: 1854 RVA: 0x0001547A File Offset: 0x0001367A
		public Vector3 localForward
		{
			get
			{
				return this.m_localForward;
			}
			set
			{
				this.m_localForward = value;
			}
		}

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x0600073F RID: 1855 RVA: 0x00015483 File Offset: 0x00013683
		public List<BoneCollider> manoBoneColliders
		{
			get
			{
				return this.m_manoColliders;
			}
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x0001548C File Offset: 0x0001368C
		public void GetColliders(List<Collider> result)
		{
			foreach (BoneCollider boneCollider in this.m_manoColliders)
			{
				result.Add(boneCollider.col);
			}
		}

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x06000741 RID: 1857 RVA: 0x000154E4 File Offset: 0x000136E4
		public Transform rootToColliders
		{
			get
			{
				if (this.m_root != null)
				{
					return this.m_root;
				}
				return this.m_owner.transform;
			}
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00015506 File Offset: 0x00013706
		public void SetRoot(Transform trans)
		{
			this.m_root = trans;
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x00015510 File Offset: 0x00013710
		public void Follow()
		{
			for (int i = 0; i < this.m_manoColliders.Count; i++)
			{
				this.m_manoColliders[i].FollowTarget(false);
			}
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x00015548 File Offset: 0x00013748
		public void Crear()
		{
			Transform boneTransform = this.m_Animator.GetBoneTransform(HumanBodyBones.Hips);
			this.bones.hand = this.m_boneTarget;
			switch (this.m_side)
			{
			case CreadorDeCollidersParaManos.Side.error:
				throw new InvalidOperationException();
			case CreadorDeCollidersParaManos.Side.l:
				this.bones.thumbProximal = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftThumbProximal);
				this.bones.thumbIntermediate = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftThumbIntermediate);
				this.bones.thumbDistal = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftThumbDistal);
				this.bones.indexProximal = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftIndexProximal);
				this.bones.indexIntermediate = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftIndexIntermediate);
				this.bones.indexDistal = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftIndexDistal);
				this.bones.middleProximal = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftMiddleProximal);
				this.bones.middleIntermediate = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftMiddleIntermediate);
				this.bones.middleDistal = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftMiddleDistal);
				this.bones.ringProximal = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftRingProximal);
				this.bones.ringIntermediate = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftRingIntermediate);
				this.bones.ringDistal = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftRingDistal);
				this.bones.littleProximal = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftLittleProximal);
				this.bones.littleIntermediate = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftLittleIntermediate);
				this.bones.littleDistal = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftLittleDistal);
				this.humanBones = UnityHandHumanBones.l;
				if (this.handBonesMap != null)
				{
					if (!string.IsNullOrEmpty(this.handBonesMap.LeftThumbNub))
					{
						this.bones.thumbNub = boneTransform.FindDeepChild(this.handBonesMap.LeftThumbNub, true);
					}
					if (!string.IsNullOrEmpty(this.handBonesMap.LeftIndexNub))
					{
						this.bones.indexNub = boneTransform.FindDeepChild(this.handBonesMap.LeftIndexNub, true);
					}
					if (!string.IsNullOrEmpty(this.handBonesMap.LeftMiddleNub))
					{
						this.bones.middleNub = boneTransform.FindDeepChild(this.handBonesMap.LeftMiddleNub, true);
					}
					if (!string.IsNullOrEmpty(this.handBonesMap.LeftRingNub))
					{
						this.bones.ringNub = boneTransform.FindDeepChild(this.handBonesMap.LeftRingNub, true);
					}
					if (!string.IsNullOrEmpty(this.handBonesMap.LeftLittleNub))
					{
						this.bones.littleNub = boneTransform.FindDeepChild(this.handBonesMap.LeftLittleNub, true);
					}
				}
				break;
			case CreadorDeCollidersParaManos.Side.r:
				this.bones.thumbProximal = this.m_Animator.GetBoneTransform(HumanBodyBones.RightThumbProximal);
				this.bones.thumbIntermediate = this.m_Animator.GetBoneTransform(HumanBodyBones.RightThumbIntermediate);
				this.bones.thumbDistal = this.m_Animator.GetBoneTransform(HumanBodyBones.RightThumbDistal);
				this.bones.indexProximal = this.m_Animator.GetBoneTransform(HumanBodyBones.RightIndexProximal);
				this.bones.indexIntermediate = this.m_Animator.GetBoneTransform(HumanBodyBones.RightIndexIntermediate);
				this.bones.indexDistal = this.m_Animator.GetBoneTransform(HumanBodyBones.RightIndexDistal);
				this.bones.middleProximal = this.m_Animator.GetBoneTransform(HumanBodyBones.RightMiddleProximal);
				this.bones.middleIntermediate = this.m_Animator.GetBoneTransform(HumanBodyBones.RightMiddleIntermediate);
				this.bones.middleDistal = this.m_Animator.GetBoneTransform(HumanBodyBones.RightMiddleDistal);
				this.bones.ringProximal = this.m_Animator.GetBoneTransform(HumanBodyBones.RightRingProximal);
				this.bones.ringIntermediate = this.m_Animator.GetBoneTransform(HumanBodyBones.RightRingIntermediate);
				this.bones.ringDistal = this.m_Animator.GetBoneTransform(HumanBodyBones.RightRingDistal);
				this.bones.littleProximal = this.m_Animator.GetBoneTransform(HumanBodyBones.RightLittleProximal);
				this.bones.littleIntermediate = this.m_Animator.GetBoneTransform(HumanBodyBones.RightLittleIntermediate);
				this.bones.littleDistal = this.m_Animator.GetBoneTransform(HumanBodyBones.RightLittleDistal);
				this.humanBones = UnityHandHumanBones.r;
				if (this.handBonesMap != null)
				{
					if (!string.IsNullOrEmpty(this.handBonesMap.RightThumbNub))
					{
						this.bones.thumbNub = boneTransform.FindDeepChild(this.handBonesMap.RightThumbNub, true);
					}
					if (!string.IsNullOrEmpty(this.handBonesMap.RightIndexNub))
					{
						this.bones.indexNub = boneTransform.FindDeepChild(this.handBonesMap.RightIndexNub, true);
					}
					if (!string.IsNullOrEmpty(this.handBonesMap.RightMiddleNub))
					{
						this.bones.middleNub = boneTransform.FindDeepChild(this.handBonesMap.RightMiddleNub, true);
					}
					if (!string.IsNullOrEmpty(this.handBonesMap.RightRingNub))
					{
						this.bones.ringNub = boneTransform.FindDeepChild(this.handBonesMap.RightRingNub, true);
					}
					if (!string.IsNullOrEmpty(this.handBonesMap.RightLittleNub))
					{
						this.bones.littleNub = boneTransform.FindDeepChild(this.handBonesMap.RightLittleNub, true);
					}
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			this.CrearCollidersDeMano();
			if (this.overrideUpdateEvent != null)
			{
				foreach (BoneCollider boneCollider in this.m_manoColliders)
				{
					boneCollider.updateEvent = this.overrideUpdateEvent.Value;
					boneCollider.ActualizarEvento();
				}
			}
			foreach (BoneCollider boneCollider2 in this.m_manoColliders)
			{
				boneCollider2.followScale = this.followScale;
			}
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x00015B28 File Offset: 0x00013D28
		protected virtual void CrearCollidersDeMano()
		{
			this.localMedidas.MultiplicarDedosPor(1.25f);
			this.colliders.thumbProximal = this.CrearColliderDedo(this.humanBones.thumbProximal, this.bones.thumbProximal, this.bones.thumbIntermediate, this.localMedidas.thumbProximal, false);
			this.colliders.thumbIntermediate = this.CrearColliderDedo(this.humanBones.thumbIntermediate, this.bones.thumbIntermediate, this.bones.thumbDistal, this.localMedidas.thumbIntermediate, false);
			if (this.bones.thumbNub)
			{
				this.colliders.thumbDistal = this.CrearColliderDedo(this.humanBones.thumbDistal, this.bones.thumbDistal, this.bones.thumbNub, this.localMedidas.thumbDistal, true);
			}
			else
			{
				this.colliders.thumbDistal = this.CrearColliderDedo(this.humanBones.thumbDistal, this.bones.thumbDistal, this.bones.thumbIntermediate, this.localMedidas.thumbDistal, this.nubLargoMod);
			}
			this.colliders.indexProximal = this.CrearColliderDedo(this.humanBones.indexProximal, this.bones.indexProximal, this.bones.indexIntermediate, this.localMedidas.indexProximal, false);
			this.colliders.indexIntermediate = this.CrearColliderDedo(this.humanBones.indexIntermediate, this.bones.indexIntermediate, this.bones.indexDistal, this.localMedidas.indexIntermediate, false);
			if (this.bones.indexNub)
			{
				this.colliders.indexDistal = this.CrearColliderDedo(this.humanBones.indexDistal, this.bones.indexDistal, this.bones.indexNub, this.localMedidas.indexDistal, true);
			}
			else
			{
				this.colliders.indexDistal = this.CrearColliderDedo(this.humanBones.indexDistal, this.bones.indexDistal, this.bones.indexIntermediate, this.localMedidas.indexDistal, this.nubLargoMod);
			}
			this.colliders.middleProximal = this.CrearColliderDedo(this.humanBones.middleProximal, this.bones.middleProximal, this.bones.middleIntermediate, this.localMedidas.middleProximal, false);
			this.colliders.middleIntermediate = this.CrearColliderDedo(this.humanBones.middleIntermediate, this.bones.middleIntermediate, this.bones.middleDistal, this.localMedidas.middleIntermediate, false);
			if (this.bones.middleNub)
			{
				this.colliders.middleDistal = this.CrearColliderDedo(this.humanBones.middleDistal, this.bones.middleDistal, this.bones.middleNub, this.localMedidas.middleDistal, true);
			}
			else
			{
				this.colliders.middleDistal = this.CrearColliderDedo(this.humanBones.middleDistal, this.bones.middleDistal, this.bones.middleIntermediate, this.localMedidas.middleDistal, this.nubLargoMod);
			}
			this.colliders.ringProximal = this.CrearColliderDedo(this.humanBones.ringProximal, this.bones.ringProximal, this.bones.ringIntermediate, this.localMedidas.ringProximal, false);
			this.colliders.ringIntermediate = this.CrearColliderDedo(this.humanBones.ringIntermediate, this.bones.ringIntermediate, this.bones.ringDistal, this.localMedidas.ringIntermediate, false);
			if (this.bones.ringNub)
			{
				this.colliders.ringDistal = this.CrearColliderDedo(this.humanBones.ringDistal, this.bones.ringDistal, this.bones.ringNub, this.localMedidas.ringDistal, true);
			}
			else
			{
				this.colliders.ringDistal = this.CrearColliderDedo(this.humanBones.ringDistal, this.bones.ringDistal, this.bones.ringIntermediate, this.localMedidas.ringDistal, this.nubLargoMod);
			}
			this.colliders.littleProximal = this.CrearColliderDedo(this.humanBones.littleProximal, this.bones.littleProximal, this.bones.littleIntermediate, this.localMedidas.littleProximal, false);
			this.colliders.littleIntermediate = this.CrearColliderDedo(this.humanBones.littleIntermediate, this.bones.littleIntermediate, this.bones.littleDistal, this.localMedidas.littleIntermediate, false);
			if (this.bones.littleNub)
			{
				this.colliders.littleDistal = this.CrearColliderDedo(this.humanBones.littleDistal, this.bones.littleDistal, this.bones.littleNub, this.localMedidas.littleDistal, true);
			}
			else
			{
				this.colliders.littleDistal = this.CrearColliderDedo(this.humanBones.littleDistal, this.bones.littleDistal, this.bones.littleIntermediate, this.localMedidas.littleDistal, this.nubLargoMod);
			}
			this.colliders.handCenter = this.CrearCentroMano(this.bones.hand, this.localMedidas.handAncho, this.bones.indexProximal, this.bones.littleProximal);
			this.colliders.handCenter2 = this.CrearCentroMano2(this.bones.hand, this.bones.indexProximal, this.localMedidas.handAncho2, this.localMedidas.handAncho2Offset);
			this.colliders.handTothumb = this.CrearColliderManoToDedo(this.bones.hand, this.bones.thumbProximal, this.localMedidas.thumbProximal, false);
			this.colliders.handToindex = this.CrearColliderManoToDedo(this.bones.hand, this.bones.indexProximal, this.localMedidas.indexProximal, false);
			this.colliders.handTomiddle = this.CrearColliderManoToDedo(this.bones.hand, this.bones.middleProximal, this.localMedidas.middleProximal, false);
			this.colliders.handToring = this.CrearColliderManoToDedo(this.bones.hand, this.bones.ringProximal, this.localMedidas.ringProximal, false);
			this.colliders.handTolittle = this.CrearColliderManoToDedo(this.bones.hand, this.bones.littleProximal, this.localMedidas.littleProximal, false);
			this.colliders.Init(this);
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x00016220 File Offset: 0x00014420
		protected virtual HandCenterCollider CrearCentroMano(Transform targetBone, float altura, Transform middleProximalBone, Transform littleProximal)
		{
			HandCenterCollider handCenterCollider = HandCenterCollider.Crear<HandCenterCollider>(this.m_owner, targetBone, altura, this.m_localForward, this.rootToColliders, middleProximalBone, littleProximal);
			this.m_manoColliders.Add(handCenterCollider);
			handCenterCollider.sizeModDelegate = this.sizeModDelegate;
			return handCenterCollider;
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x00016264 File Offset: 0x00014464
		protected virtual SphereParteCollider CrearCentroMano2(Transform targetBone, Transform middleProximalBone, float radius, float toTargetOffset)
		{
			SphereParteCollider sphereParteCollider = SphereParteCollider.Crear<SphereParteCollider>(this.m_owner, this.rootToColliders, targetBone, middleProximalBone, radius, toTargetOffset);
			this.m_manoColliders.Add(sphereParteCollider);
			sphereParteCollider.sizeModDelegate = this.sizeModDelegate;
			return sphereParteCollider;
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x000162A4 File Offset: 0x000144A4
		protected virtual AnimatorDedoParteCollider CrearColliderDedo(HumanBodyBones humanbone, Transform start, Transform last, float ancho, float largoMod = 1f)
		{
			float num = Vector3.Distance(start.position, last.position);
			AnimatorDedoParteCollider animatorDedoParteCollider = AnimatorDedoParteCollider.Crear(humanbone, this.m_owner, start, num / 1.618f * largoMod * 1.666f, ancho, this.rootToColliders, this.m_localForward);
			this.m_manoColliders.Add(animatorDedoParteCollider);
			animatorDedoParteCollider.sizeModDelegate = this.sizeModDelegate;
			return animatorDedoParteCollider;
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x00016308 File Offset: 0x00014508
		protected virtual AnimatorDedoParteCollider CrearColliderDedo(HumanBodyBones humanbone, Transform start, Transform end, float ancho, bool isNub)
		{
			AnimatorDedoParteCollider animatorDedoParteCollider = AnimatorDedoParteCollider.Crear(humanbone, this.m_owner, start, end, ancho, this.rootToColliders, this.m_localForward, isNub);
			this.m_manoColliders.Add(animatorDedoParteCollider);
			animatorDedoParteCollider.sizeModDelegate = this.sizeModDelegate;
			return animatorDedoParteCollider;
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x00016350 File Offset: 0x00014550
		protected virtual CapsuleParteCollider CrearColliderManoToDedo(Transform hand, Transform baseDedo, float ancho, bool debugDraw = false)
		{
			CapsuleParteCollider capsuleParteCollider = CapsuleParteCollider.CrearConColliderHijo<CapsuleParteCollider>(this.m_owner, hand, baseDedo, ancho, this.rootToColliders);
			this.m_manoColliders.Add(capsuleParteCollider);
			capsuleParteCollider.sizeModDelegate = this.sizeModDelegate;
			return capsuleParteCollider;
		}

		// Token: 0x04000405 RID: 1029
		public bool followScale = true;

		// Token: 0x04000406 RID: 1030
		[ReadOnlyUI]
		[SerializeField]
		private CreadorDeCollidersParaManos.Side m_side;

		// Token: 0x04000407 RID: 1031
		[ReadOnlyUI]
		[SerializeField]
		private Rigidbody m_rigid;

		// Token: 0x04000408 RID: 1032
		public GlobalUpdater.UpdateType? overrideUpdateEvent;

		// Token: 0x0400040A RID: 1034
		public CreadorDeCollidersParaManos.Bones bones = new CreadorDeCollidersParaManos.Bones();

		// Token: 0x0400040B RID: 1035
		public UnityHandHumanBones humanBones;

		// Token: 0x0400040C RID: 1036
		public CreadorDeCollidersParaManos.Medidas localMedidas = new CreadorDeCollidersParaManos.Medidas();

		// Token: 0x0400040D RID: 1037
		public CreadorDeCollidersParaManos.Colliders colliders = new CreadorDeCollidersParaManos.Colliders();

		// Token: 0x0400040E RID: 1038
		[Tooltip("solo funciona si no se definen los huesos nub")]
		public float nubLargoMod = 0.9f;

		// Token: 0x0400040F RID: 1039
		private List<BoneCollider> m_manoColliders = new List<BoneCollider>();

		// Token: 0x04000410 RID: 1040
		[Tooltip("direction to next finger bone")]
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_localForward = Vector3.forward;

		// Token: 0x04000411 RID: 1041
		public Func<Vector3> sizeModDelegate;

		// Token: 0x04000412 RID: 1042
		private Animator m_Animator;

		// Token: 0x04000413 RID: 1043
		private Transform m_boneTarget;

		// Token: 0x04000414 RID: 1044
		private CustomMonobehaviourBase m_owner;

		// Token: 0x04000415 RID: 1045
		private Transform m_root;

		// Token: 0x020001A3 RID: 419
		[Serializable]
		public class Medidas
		{
			// Token: 0x06000F09 RID: 3849 RVA: 0x00032C80 File Offset: 0x00030E80
			public void MultiplicarManoPor(float mult)
			{
				this.handAncho *= mult;
			}

			// Token: 0x06000F0A RID: 3850 RVA: 0x00032C90 File Offset: 0x00030E90
			public void MultiplicarThumpPor(float mult)
			{
				this.thumbProximal *= mult;
				this.thumbIntermediate *= mult;
				this.thumbDistal *= mult;
			}

			// Token: 0x06000F0B RID: 3851 RVA: 0x00032CBC File Offset: 0x00030EBC
			public void MultiplicarDedosPorIgnorandoThump(float mult)
			{
				this.indexProximal *= mult;
				this.indexIntermediate *= mult;
				this.indexDistal *= mult;
				this.middleProximal *= mult;
				this.middleIntermediate *= mult;
				this.middleDistal *= mult;
				this.ringProximal *= mult;
				this.ringIntermediate *= mult;
				this.ringDistal *= mult;
				this.littleProximal *= mult;
				this.littleIntermediate *= mult;
				this.littleDistal *= mult;
			}

			// Token: 0x06000F0C RID: 3852 RVA: 0x00032D74 File Offset: 0x00030F74
			public void MultiplicarDedosPor(float mult)
			{
				this.thumbProximal *= mult;
				this.thumbIntermediate *= mult;
				this.thumbDistal *= mult;
				this.indexProximal *= mult;
				this.indexIntermediate *= mult;
				this.indexDistal *= mult;
				this.middleProximal *= mult;
				this.middleIntermediate *= mult;
				this.middleDistal *= mult;
				this.ringProximal *= mult;
				this.ringIntermediate *= mult;
				this.ringDistal *= mult;
				this.littleProximal *= mult;
				this.littleIntermediate *= mult;
				this.littleDistal *= mult;
			}

			// Token: 0x06000F0D RID: 3853 RVA: 0x00032E54 File Offset: 0x00031054
			public void MultiplicarTodoPor(float mult)
			{
				this.handAncho *= mult;
				this.thumbProximal *= mult;
				this.thumbIntermediate *= mult;
				this.thumbDistal *= mult;
				this.indexProximal *= mult;
				this.indexIntermediate *= mult;
				this.indexDistal *= mult;
				this.middleProximal *= mult;
				this.middleIntermediate *= mult;
				this.middleDistal *= mult;
				this.ringProximal *= mult;
				this.ringIntermediate *= mult;
				this.ringDistal *= mult;
				this.littleProximal *= mult;
				this.littleIntermediate *= mult;
				this.littleDistal *= mult;
			}

			// Token: 0x04000964 RID: 2404
			public float handAncho = 0.022f;

			// Token: 0x04000965 RID: 2405
			public float handAncho2 = 0.0225f;

			// Token: 0x04000966 RID: 2406
			public float handAncho2Offset = 0.333f;

			// Token: 0x04000967 RID: 2407
			public float thumbProximal = 0.022f;

			// Token: 0x04000968 RID: 2408
			public float thumbIntermediate = 0.019f;

			// Token: 0x04000969 RID: 2409
			public float thumbDistal = 0.015f;

			// Token: 0x0400096A RID: 2410
			public float indexProximal = 0.019f;

			// Token: 0x0400096B RID: 2411
			public float indexIntermediate = 0.0165f;

			// Token: 0x0400096C RID: 2412
			public float indexDistal = 0.0145f;

			// Token: 0x0400096D RID: 2413
			public float middleProximal = 0.02f;

			// Token: 0x0400096E RID: 2414
			public float middleIntermediate = 0.017f;

			// Token: 0x0400096F RID: 2415
			public float middleDistal = 0.015f;

			// Token: 0x04000970 RID: 2416
			public float ringProximal = 0.018f;

			// Token: 0x04000971 RID: 2417
			public float ringIntermediate = 0.0155f;

			// Token: 0x04000972 RID: 2418
			public float ringDistal = 0.0135f;

			// Token: 0x04000973 RID: 2419
			public float littleProximal = 0.013f;

			// Token: 0x04000974 RID: 2420
			public float littleIntermediate = 0.0115f;

			// Token: 0x04000975 RID: 2421
			public float littleDistal = 0.0105f;
		}

		// Token: 0x020001A4 RID: 420
		[Serializable]
		public class Colliders
		{
			// Token: 0x06000F0F RID: 3855 RVA: 0x0003301D File Offset: 0x0003121D
			public void Init(CreadorDeCollidersParaManos parent)
			{
				if (parent == null)
				{
					throw new ArgumentNullException("parent", "parent null reference.");
				}
				this.m_parent = parent;
			}

			// Token: 0x06000F10 RID: 3856 RVA: 0x0003303C File Offset: 0x0003123C
			public AnimatorDedoParteCollider GetAnimatorCollider(HumanBodyBones bone)
			{
				switch (bone)
				{
				case HumanBodyBones.LeftThumbProximal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.l)
					{
						throw new InvalidOperationException();
					}
					return this.thumbProximal;
				case HumanBodyBones.LeftThumbIntermediate:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.l)
					{
						throw new InvalidOperationException();
					}
					return this.thumbIntermediate;
				case HumanBodyBones.LeftThumbDistal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.l)
					{
						throw new InvalidOperationException();
					}
					return this.thumbDistal;
				case HumanBodyBones.LeftIndexProximal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.l)
					{
						throw new InvalidOperationException();
					}
					return this.indexProximal;
				case HumanBodyBones.LeftIndexIntermediate:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.l)
					{
						throw new InvalidOperationException();
					}
					return this.indexIntermediate;
				case HumanBodyBones.LeftIndexDistal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.l)
					{
						throw new InvalidOperationException();
					}
					return this.indexDistal;
				case HumanBodyBones.LeftMiddleProximal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.l)
					{
						throw new InvalidOperationException();
					}
					return this.middleProximal;
				case HumanBodyBones.LeftMiddleIntermediate:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.l)
					{
						throw new InvalidOperationException();
					}
					return this.middleIntermediate;
				case HumanBodyBones.LeftMiddleDistal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.l)
					{
						throw new InvalidOperationException();
					}
					return this.middleDistal;
				case HumanBodyBones.LeftRingProximal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.l)
					{
						throw new InvalidOperationException();
					}
					return this.ringProximal;
				case HumanBodyBones.LeftRingIntermediate:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.l)
					{
						throw new InvalidOperationException();
					}
					return this.ringIntermediate;
				case HumanBodyBones.LeftRingDistal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.l)
					{
						throw new InvalidOperationException();
					}
					return this.ringDistal;
				case HumanBodyBones.LeftLittleProximal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.l)
					{
						throw new InvalidOperationException();
					}
					return this.littleProximal;
				case HumanBodyBones.LeftLittleIntermediate:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.l)
					{
						throw new InvalidOperationException();
					}
					return this.littleIntermediate;
				case HumanBodyBones.LeftLittleDistal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.l)
					{
						throw new InvalidOperationException();
					}
					return this.littleDistal;
				case HumanBodyBones.RightThumbProximal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.r)
					{
						throw new InvalidOperationException();
					}
					return this.thumbProximal;
				case HumanBodyBones.RightThumbIntermediate:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.r)
					{
						throw new InvalidOperationException();
					}
					return this.thumbIntermediate;
				case HumanBodyBones.RightThumbDistal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.r)
					{
						throw new InvalidOperationException();
					}
					return this.thumbDistal;
				case HumanBodyBones.RightIndexProximal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.r)
					{
						throw new InvalidOperationException();
					}
					return this.indexProximal;
				case HumanBodyBones.RightIndexIntermediate:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.r)
					{
						throw new InvalidOperationException();
					}
					return this.indexIntermediate;
				case HumanBodyBones.RightIndexDistal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.r)
					{
						throw new InvalidOperationException();
					}
					return this.indexDistal;
				case HumanBodyBones.RightMiddleProximal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.r)
					{
						throw new InvalidOperationException();
					}
					return this.middleProximal;
				case HumanBodyBones.RightMiddleIntermediate:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.r)
					{
						throw new InvalidOperationException();
					}
					return this.middleIntermediate;
				case HumanBodyBones.RightMiddleDistal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.r)
					{
						throw new InvalidOperationException();
					}
					return this.middleDistal;
				case HumanBodyBones.RightRingProximal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.r)
					{
						throw new InvalidOperationException();
					}
					return this.ringProximal;
				case HumanBodyBones.RightRingIntermediate:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.r)
					{
						throw new InvalidOperationException();
					}
					return this.ringIntermediate;
				case HumanBodyBones.RightRingDistal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.r)
					{
						throw new InvalidOperationException();
					}
					return this.ringDistal;
				case HumanBodyBones.RightLittleProximal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.r)
					{
						throw new InvalidOperationException();
					}
					return this.littleProximal;
				case HumanBodyBones.RightLittleIntermediate:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.r)
					{
						throw new InvalidOperationException();
					}
					return this.littleIntermediate;
				case HumanBodyBones.RightLittleDistal:
					if (this.m_parent.m_side != CreadorDeCollidersParaManos.Side.r)
					{
						throw new InvalidOperationException();
					}
					return this.littleDistal;
				default:
					throw new ArgumentOutOfRangeException(bone.ToString());
				}
			}

			// Token: 0x04000976 RID: 2422
			[SerializeField]
			[ReadOnlyUI]
			private CreadorDeCollidersParaManos m_parent;

			// Token: 0x04000977 RID: 2423
			public HandCenterCollider handCenter;

			// Token: 0x04000978 RID: 2424
			public SphereParteCollider handCenter2;

			// Token: 0x04000979 RID: 2425
			public CapsuleParteCollider handTothumb;

			// Token: 0x0400097A RID: 2426
			public CapsuleParteCollider handToindex;

			// Token: 0x0400097B RID: 2427
			public CapsuleParteCollider handTomiddle;

			// Token: 0x0400097C RID: 2428
			public CapsuleParteCollider handToring;

			// Token: 0x0400097D RID: 2429
			public CapsuleParteCollider handTolittle;

			// Token: 0x0400097E RID: 2430
			public AnimatorDedoParteCollider thumbProximal;

			// Token: 0x0400097F RID: 2431
			public AnimatorDedoParteCollider thumbIntermediate;

			// Token: 0x04000980 RID: 2432
			public AnimatorDedoParteCollider thumbDistal;

			// Token: 0x04000981 RID: 2433
			public AnimatorDedoParteCollider indexProximal;

			// Token: 0x04000982 RID: 2434
			public AnimatorDedoParteCollider indexIntermediate;

			// Token: 0x04000983 RID: 2435
			public AnimatorDedoParteCollider indexDistal;

			// Token: 0x04000984 RID: 2436
			public AnimatorDedoParteCollider middleProximal;

			// Token: 0x04000985 RID: 2437
			public AnimatorDedoParteCollider middleIntermediate;

			// Token: 0x04000986 RID: 2438
			public AnimatorDedoParteCollider middleDistal;

			// Token: 0x04000987 RID: 2439
			public AnimatorDedoParteCollider ringProximal;

			// Token: 0x04000988 RID: 2440
			public AnimatorDedoParteCollider ringIntermediate;

			// Token: 0x04000989 RID: 2441
			public AnimatorDedoParteCollider ringDistal;

			// Token: 0x0400098A RID: 2442
			public AnimatorDedoParteCollider littleProximal;

			// Token: 0x0400098B RID: 2443
			public AnimatorDedoParteCollider littleIntermediate;

			// Token: 0x0400098C RID: 2444
			public AnimatorDedoParteCollider littleDistal;
		}

		// Token: 0x020001A5 RID: 421
		[Serializable]
		public class Bones : HumanHandBonesConTips<Transform>
		{
		}

		// Token: 0x020001A6 RID: 422
		public enum Side
		{
			// Token: 0x0400098E RID: 2446
			error,
			// Token: 0x0400098F RID: 2447
			l,
			// Token: 0x04000990 RID: 2448
			r
		}
	}
}
