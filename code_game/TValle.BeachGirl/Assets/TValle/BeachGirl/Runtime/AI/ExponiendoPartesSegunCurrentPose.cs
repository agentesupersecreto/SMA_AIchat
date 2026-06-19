using System;
using Assets.SystemasConstraints._Abstract;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.AI
{
	// Token: 0x020000BD RID: 189
	public class ExponiendoPartesSegunCurrentPose : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700023E RID: 574
		// (get) Token: 0x060005D3 RID: 1491 RVA: 0x000125DF File Offset: 0x000107DF
		public ExponiendoPartesSegunCurrentPose.PosesIniciales posesIniciales
		{
			get
			{
				return this.m_PosesIniciales;
			}
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x000125E7 File Offset: 0x000107E7
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Character = this.GetComponentEnRoot(false);
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0001261C File Offset: 0x0001081C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			Transform rootBoneTransform = this.m_Character.rootBoneTransform;
			ConstrainedSkeleton constrainedSkeleton = ((rootBoneTransform != null) ? rootBoneTransform.GetComponent<ConstrainedSkeleton>() : null);
			if (constrainedSkeleton == null)
			{
				throw new ArgumentNullException("skeletonConst", "skeletonConst null reference.");
			}
			Transform boneTransform = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.Hips);
			Transform boneTransform2 = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.Spine);
			Transform boneTransform3 = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.Chest);
			Transform boneTransform4 = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.LeftShoulder);
			Transform boneTransform5 = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.RightShoulder);
			Transform boneTransform6 = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
			Transform boneTransform7 = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.RightUpperArm);
			Transform boneTransform8 = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
			Transform boneTransform9 = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.RightUpperLeg);
			this.m_PosesIniciales.hips = ExponiendoPartesSegunCurrentPose.CrearPoseDefault(boneTransform, boneTransform2, constrainedSkeleton);
			this.m_PosesIniciales.chest = ExponiendoPartesSegunCurrentPose.CrearPoseDefault(boneTransform3, boneTransform2, constrainedSkeleton);
			this.m_PosesIniciales.hombroL = ExponiendoPartesSegunCurrentPose.CrearPoseDefault(boneTransform4, boneTransform3, constrainedSkeleton);
			this.m_PosesIniciales.hombroR = ExponiendoPartesSegunCurrentPose.CrearPoseDefault(boneTransform5, boneTransform3, constrainedSkeleton);
			this.m_PosesIniciales.brazoL = ExponiendoPartesSegunCurrentPose.CrearPoseDefault(boneTransform6, boneTransform3, constrainedSkeleton);
			this.m_PosesIniciales.brazoR = ExponiendoPartesSegunCurrentPose.CrearPoseDefault(boneTransform7, boneTransform3, constrainedSkeleton);
			this.m_PosesIniciales.piernaL = ExponiendoPartesSegunCurrentPose.CrearPoseDefault(boneTransform8, boneTransform, constrainedSkeleton);
			this.m_PosesIniciales.piernaR = ExponiendoPartesSegunCurrentPose.CrearPoseDefault(boneTransform9, boneTransform, constrainedSkeleton);
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x000127AC File Offset: 0x000109AC
		private static ExponiendoPartesSegunCurrentPose.BonePoseInicial CrearPoseDefault(Transform bone, Transform medidoDesde, ConstrainedSkeleton skeletonConst)
		{
			Matrix4x4 matrix4x = PosesHelper.ProducirLocalPose(skeletonConst.boneToBindPose[bone], skeletonConst.boneToBindPose[medidoDesde]);
			ExponiendoPartesSegunCurrentPose.BonePoseInicial bonePoseInicial = new ExponiendoPartesSegunCurrentPose.BonePoseInicial();
			bonePoseInicial.bone = bone;
			bonePoseInicial.medidoDesde = medidoDesde;
			bonePoseInicial.localPosition = matrix4x.Posicion();
			bonePoseInicial.localRotation = matrix4x.Rotacion();
			Vector3 vector;
			if (!skeletonConst.TryObtenerBoneInitialForward(medidoDesde, out vector))
			{
				throw new InvalidOperationException();
			}
			Vector3 vector2;
			if (!skeletonConst.TryObtenerBoneInitialUp(medidoDesde, out vector2))
			{
				throw new InvalidOperationException();
			}
			Vector3 vector3;
			if (!skeletonConst.TryObtenerBoneInitialRight(medidoDesde, out vector3))
			{
				throw new InvalidOperationException();
			}
			bonePoseInicial.spaceForward = vector;
			bonePoseInicial.spaceUp = vector2;
			bonePoseInicial.spaceRight = vector3;
			bonePoseInicial.forwardNormal = Quaternion.LookRotation(bonePoseInicial.localRotation * Vector3.forward, vector) * Vector3.up;
			bonePoseInicial.upNormal = Quaternion.LookRotation(bonePoseInicial.localRotation * Vector3.forward, vector2) * Vector3.up;
			bonePoseInicial.rightNormal = Quaternion.LookRotation(bonePoseInicial.localRotation * Vector3.forward, vector3) * Vector3.up;
			return bonePoseInicial;
		}

		// Token: 0x040003C0 RID: 960
		private Character m_Character;

		// Token: 0x040003C1 RID: 961
		[SerializeField]
		private ExponiendoPartesSegunCurrentPose.PosesIniciales m_PosesIniciales = new ExponiendoPartesSegunCurrentPose.PosesIniciales();

		// Token: 0x0200019A RID: 410
		[Serializable]
		public class PosesIniciales
		{
			// Token: 0x04000938 RID: 2360
			public ExponiendoPartesSegunCurrentPose.BonePoseInicial hips;

			// Token: 0x04000939 RID: 2361
			public ExponiendoPartesSegunCurrentPose.BonePoseInicial chest;

			// Token: 0x0400093A RID: 2362
			public ExponiendoPartesSegunCurrentPose.BonePoseInicial hombroL;

			// Token: 0x0400093B RID: 2363
			public ExponiendoPartesSegunCurrentPose.BonePoseInicial hombroR;

			// Token: 0x0400093C RID: 2364
			public ExponiendoPartesSegunCurrentPose.BonePoseInicial brazoL;

			// Token: 0x0400093D RID: 2365
			public ExponiendoPartesSegunCurrentPose.BonePoseInicial brazoR;

			// Token: 0x0400093E RID: 2366
			public ExponiendoPartesSegunCurrentPose.BonePoseInicial piernaL;

			// Token: 0x0400093F RID: 2367
			public ExponiendoPartesSegunCurrentPose.BonePoseInicial piernaR;
		}

		// Token: 0x0200019B RID: 411
		[Serializable]
		public class BonePoseInicial
		{
			// Token: 0x04000940 RID: 2368
			public Transform bone;

			// Token: 0x04000941 RID: 2369
			public Transform medidoDesde;

			// Token: 0x04000942 RID: 2370
			public Vector3 localPosition;

			// Token: 0x04000943 RID: 2371
			public Quaternion localRotation;

			// Token: 0x04000944 RID: 2372
			public Vector3 spaceForward;

			// Token: 0x04000945 RID: 2373
			public Vector3 spaceUp;

			// Token: 0x04000946 RID: 2374
			public Vector3 spaceRight;

			// Token: 0x04000947 RID: 2375
			public Vector3 forwardNormal;

			// Token: 0x04000948 RID: 2376
			public Vector3 upNormal;

			// Token: 0x04000949 RID: 2377
			public Vector3 rightNormal;
		}

		// Token: 0x0200019C RID: 412
		[Serializable]
		public class BonePose
		{
			// Token: 0x06000EF0 RID: 3824 RVA: 0x00032A70 File Offset: 0x00030C70
			public void Update()
			{
				this.localPosition = this.medidoDesde.InverseTransformPoint(this.bone.position);
				this.localRotation = Quaternion.Inverse(this.medidoDesde.rotation) * this.bone.rotation;
			}

			// Token: 0x06000EF1 RID: 3825 RVA: 0x00032AC0 File Offset: 0x00030CC0
			public void UpdateFromPose(Matrix4x4 medidoDesde, Quaternion medidoDesdeWorldRotation, Vector3 boneWorldPosition, Quaternion boneWorldRotation)
			{
				this.localPosition = medidoDesde.inverse.MultiplyPoint3x4(boneWorldPosition);
				this.localRotation = Quaternion.Inverse(medidoDesdeWorldRotation) * boneWorldRotation;
			}

			// Token: 0x0400094A RID: 2378
			public Transform bone;

			// Token: 0x0400094B RID: 2379
			public Transform medidoDesde;

			// Token: 0x0400094C RID: 2380
			public Vector3 localPosition;

			// Token: 0x0400094D RID: 2381
			public Quaternion localRotation;
		}

		// Token: 0x0200019D RID: 413
		[Serializable]
		public class Poses
		{
			// Token: 0x0400094E RID: 2382
			public ExponiendoPartesSegunCurrentPose.BonePose hips;

			// Token: 0x0400094F RID: 2383
			public ExponiendoPartesSegunCurrentPose.BonePose chest;

			// Token: 0x04000950 RID: 2384
			public ExponiendoPartesSegunCurrentPose.BonePose head;

			// Token: 0x04000951 RID: 2385
			public ExponiendoPartesSegunCurrentPose.BonePose hombroL;

			// Token: 0x04000952 RID: 2386
			public ExponiendoPartesSegunCurrentPose.BonePose hombroR;

			// Token: 0x04000953 RID: 2387
			public ExponiendoPartesSegunCurrentPose.BonePose brazoL;

			// Token: 0x04000954 RID: 2388
			public ExponiendoPartesSegunCurrentPose.BonePose brazoR;

			// Token: 0x04000955 RID: 2389
			public ExponiendoPartesSegunCurrentPose.BonePose piernaL;

			// Token: 0x04000956 RID: 2390
			public ExponiendoPartesSegunCurrentPose.BonePose piernaR;
		}
	}
}
