using System;
using System.Collections.Generic;
using Assets.Base.BeachGirl.Mapas;
using Assets.SystemasConstraints._Abstract;
using Assets._ReusableScripts.Bones.V2;
using Assets._ReusableScripts.Bones.V2.ConstraintsV2.Users;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises
{
	// Token: 0x02000105 RID: 261
	public sealed class PenisLinearChain : LinearChainTipo2<PenisPoint, PenisPoint.Configuracion>
	{
		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x06000B29 RID: 2857 RVA: 0x000251AB File Offset: 0x000233AB
		public bool puedeEstirar
		{
			get
			{
				return this.m_puedeEstirar;
			}
		}

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x06000B2A RID: 2858 RVA: 0x000251B3 File Offset: 0x000233B3
		public ModificableDeBool puedeEstirarModificable
		{
			get
			{
				return this.m_puedeEstirarModificable;
			}
		}

		// Token: 0x14000056 RID: 86
		// (add) Token: 0x06000B2B RID: 2859 RVA: 0x000251BC File Offset: 0x000233BC
		// (remove) Token: 0x06000B2C RID: 2860 RVA: 0x000251F4 File Offset: 0x000233F4
		public event PenisLinearChainAddingFollowersHandler addingFollowers;

		// Token: 0x14000057 RID: 87
		// (add) Token: 0x06000B2D RID: 2861 RVA: 0x0002522C File Offset: 0x0002342C
		// (remove) Token: 0x06000B2E RID: 2862 RVA: 0x00025264 File Offset: 0x00023464
		public event Action<PenisLinearChain> updatedTotalMass;

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06000B2F RID: 2863 RVA: 0x00025299 File Offset: 0x00023499
		public override int updateEvent2Index
		{
			get
			{
				return (int)this.m_event1;
			}
		}

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06000B30 RID: 2864 RVA: 0x000252A1 File Offset: 0x000234A1
		// (set) Token: 0x06000B31 RID: 2865 RVA: 0x000252A9 File Offset: 0x000234A9
		public float angleAgaintsGravity
		{
			get
			{
				return this.m_angleAgaintsGravity;
			}
			set
			{
				this.m_angleAgaintsGravity = value;
			}
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x06000B32 RID: 2866 RVA: 0x000252B2 File Offset: 0x000234B2
		public float totalMass
		{
			get
			{
				return this.m_totalMass;
			}
		}

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x06000B33 RID: 2867 RVA: 0x000252BA File Offset: 0x000234BA
		public override int cantidadDePuntos
		{
			get
			{
				return this.m_cantidadDePuntos;
			}
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x06000B34 RID: 2868 RVA: 0x000252C2 File Offset: 0x000234C2
		public Transform penisRoot
		{
			get
			{
				return this.m_PenisRoot;
			}
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06000B35 RID: 2869 RVA: 0x000252CA File Offset: 0x000234CA
		public override Transform puntoBaseTransform
		{
			get
			{
				return this.m_puntoBaseTransform;
			}
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x06000B36 RID: 2870 RVA: 0x000252D2 File Offset: 0x000234D2
		public Vector3 boneBaseWorldInitialUp
		{
			get
			{
				return this.puntoBaseTransform.TransformDirection(this.m_baseInitialUp);
			}
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x06000B37 RID: 2871 RVA: 0x000252E5 File Offset: 0x000234E5
		[Obsolete("", true)]
		public PenisPointCollider puntaCollider
		{
			get
			{
				return this.m_puntaCollider;
			}
		}

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06000B38 RID: 2872 RVA: 0x000252ED File Offset: 0x000234ED
		public PenisPointCollider puntaMainCollider
		{
			get
			{
				return this.m_puntaMainCollider;
			}
		}

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06000B39 RID: 2873 RVA: 0x000252F5 File Offset: 0x000234F5
		public PenisPointCollider puntaComplementoCollider
		{
			get
			{
				return this.m_puntaComplementoCollider;
			}
		}

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06000B3A RID: 2874 RVA: 0x000252FD File Offset: 0x000234FD
		public Rigidbody punta
		{
			get
			{
				return base.last.joint.connectedBody;
			}
		}

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x06000B3B RID: 2875 RVA: 0x0002530F File Offset: 0x0002350F
		public Vector3 tipBoneWorldPosition
		{
			get
			{
				if (this.m_tipBone != null)
				{
					return this.m_tipBone.position;
				}
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06000B3C RID: 2876 RVA: 0x00025330 File Offset: 0x00023530
		public Vector3 tipPhysicsWorldPosition
		{
			get
			{
				if (this.m_tipPhysicBone != null)
				{
					return this.m_tipPhysicBone.position;
				}
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06000B3D RID: 2877 RVA: 0x00025351 File Offset: 0x00023551
		public Transform tipPhysicBone
		{
			get
			{
				return this.m_tipPhysicBone;
			}
		}

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06000B3E RID: 2878 RVA: 0x00025359 File Offset: 0x00023559
		public Transform tipBone
		{
			get
			{
				return this.m_tipBone;
			}
		}

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06000B3F RID: 2879 RVA: 0x00025361 File Offset: 0x00023561
		public Vector3 currentDefaultWorldForwardDirection
		{
			get
			{
				return this.m_PenisRoot.rotation * this.m_defaultLocalRotationCorrectedAgainstGravity * Vector3.forward;
			}
		}

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x06000B40 RID: 2880 RVA: 0x00025383 File Offset: 0x00023583
		public PenisPoint.Configuracion rootConfiguracion
		{
			get
			{
				return this.rootConfig;
			}
		}

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x06000B41 RID: 2881 RVA: 0x0002538B File Offset: 0x0002358B
		public Transform skeletonRoot
		{
			get
			{
				return this.m_skeletonRoot;
			}
		}

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x06000B42 RID: 2882 RVA: 0x00025393 File Offset: 0x00023593
		public Transform pushBone
		{
			get
			{
				return this.m_pushBone;
			}
		}

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x06000B43 RID: 2883 RVA: 0x0002539B File Offset: 0x0002359B
		public PenisLinearChainRenderer penisLinearChainRenderer
		{
			get
			{
				return this.m_PenisLinearChainRenderer;
			}
		}

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06000B44 RID: 2884 RVA: 0x000253A3 File Offset: 0x000235A3
		public Vector3 defaultTipLocalPositionFromBase
		{
			get
			{
				return this.m_defaultTipLocalPositionFromBase;
			}
		}

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06000B45 RID: 2885 RVA: 0x000253AB File Offset: 0x000235AB
		public float anchoLocalDePunta
		{
			get
			{
				return Mathf.Max(this.m_puntaMainCollider.radius * 2f, this.m_puntaComplementoCollider.radius * 2f);
			}
		}

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06000B46 RID: 2886 RVA: 0x000253D4 File Offset: 0x000235D4
		public float largoLocalDePunta
		{
			get
			{
				return Mathf.Max(this.m_puntaMainCollider.height, this.m_puntaComplementoCollider.height);
			}
		}

		// Token: 0x14000058 RID: 88
		// (add) Token: 0x06000B47 RID: 2887 RVA: 0x000253F4 File Offset: 0x000235F4
		// (remove) Token: 0x06000B48 RID: 2888 RVA: 0x0002542C File Offset: 0x0002362C
		public event Action<PenisPoint.Configuracion, PenisLinearChain> onRootConfigCreated;

		// Token: 0x06000B49 RID: 2889 RVA: 0x00025461 File Offset: 0x00023661
		protected override void AwakeUnityEvent()
		{
			this.pointPorblemFixerHandler = new Action<PenisPoint>(this.PositionProblemFix);
			base.AwakeUnityEvent();
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x0002547B File Offset: 0x0002367B
		public void SetFollowerEvent(GlobalUpdater.UpdateType FollowerUpdateEvent)
		{
			if (base.isStared)
			{
				throw new NotSupportedException();
			}
			this.m_followerUpdateEvent = FollowerUpdateEvent;
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x00025492 File Offset: 0x00023692
		public void SetFollowerEventDelegate(PenisLinearChainAddingFollowerUpdateEvent FollowerUpdateEventDelegate)
		{
			if (base.isStared)
			{
				throw new NotSupportedException();
			}
			this.m_delegateGetFollowerUpdateEventOfIndex = FollowerUpdateEventDelegate;
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x000254AC File Offset: 0x000236AC
		public void SetRefereces(IPenisBoneMap penisBoneMap, Vector3 WorldUpwardsDirection, Transform SkeletonRoot, Transform PushBone, Transform ConstraintRootOverride, PenisPoint.Configuracion PuntosConfig, PenisPointColliderSizeGetterHandler ColliderSizeGetter = null)
		{
			if (base.isStared)
			{
				throw new NotSupportedException();
			}
			this.m_worldUpwardsDirection = WorldUpwardsDirection;
			this.m_skeletonRoot = SkeletonRoot;
			this.m_pushBone = PushBone;
			this.m_constraintRootOverride = ConstraintRootOverride;
			this.puntosConfig = PuntosConfig;
			if (penisBoneMap == null)
			{
				throw new ArgumentNullException("penisBoneMap", "penisBoneMap null reference.");
			}
			this.m_map = penisBoneMap;
			this.colliderSizeGetter = ColliderSizeGetter;
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x0002550F File Offset: 0x0002370F
		public void SetCustomTransforms(Transform RootBone, Transform BaseBone)
		{
			if (base.isStared)
			{
				throw new NotSupportedException();
			}
			this.m_PenisRoot = RootBone;
			this.m_puntoBaseTransform = BaseBone;
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x0002552D File Offset: 0x0002372D
		public void SetInitialConfig(bool FollowerInBones, int CantidadDePuntos, Vector3 RotationOffset)
		{
			if (base.isStared)
			{
				throw new NotSupportedException();
			}
			this.m_followersInBones = FollowerInBones;
			this.m_rotationOffset = RotationOffset;
			if (CantidadDePuntos <= 0)
			{
				throw new NotSupportedException();
			}
			this.m_cantidadDePuntos = CantidadDePuntos;
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x0002555C File Offset: 0x0002375C
		protected override void StartUnityEvent()
		{
			foreach (Rigidbody rigidbody in this.m_RigidBodiesParaIgnorar)
			{
				this.collidersParaIgnorar.AddRange(rigidbody.GetComponentsInChildren<Collider>());
			}
			this.rootConfig = (PenisPoint.Configuracion)this.puntosConfig.Clone();
			this.rootConfig.jointBodyAdmin = (JointBodyAdmin.Configuracion)this.rootConfig.jointBodyAdmin.Clone();
			this.rootConfig.jointBodyAdmin.ownRigidIsKinematic = this.rootPointEsKinematico;
			Action<PenisPoint.Configuracion, PenisLinearChain> action = this.onRootConfigCreated;
			if (action != null)
			{
				action(this.rootConfig, this);
			}
			this.onRootConfigCreated = null;
			if (this.m_pushBone == null && this.m_penisRoot == null)
			{
				throw new ArgumentNullException("animator/m_root", "animator/m_root null reference.");
			}
			if (this.m_pushBone != null)
			{
				if (this.m_PenisRoot == null)
				{
					this.m_PenisRoot = this.skeletonRoot.FindDeepChild(this.m_map.penisRoot, true);
				}
				if (this.m_PenisRoot == null)
				{
					this.m_PenisRoot = this.skeletonRoot.FindDeepChildEndsWith(this.m_map.penisRoot, true);
				}
				if (this.m_puntoBaseTransform == null)
				{
					this.m_puntoBaseTransform = this.m_PenisRoot.FindDeepChild(this.m_map.penisBase, true);
				}
				this.m_baseInitialUp = this.m_puntoBaseTransform.InverseTransformDirection(this.m_worldUpwardsDirection);
			}
			else
			{
				this.m_PenisRoot = this.m_penisRoot;
				this.m_puntoBaseTransform = this.m_PenisRoot;
				this.m_baseInitialUp = this.m_puntoBaseTransform.InverseTransformDirection(this.m_worldUpwardsDirection);
			}
			this.m_PenisLinearChainRenderer = this.m_PenisRoot.transform.parent.GetComponentInChildren<PenisLinearChainRenderer>();
			PenisLinearChainRenderer penisLinearChainRenderer = this.m_PenisLinearChainRenderer;
			SkinnedMeshRenderer skinnedMeshRenderer = ((penisLinearChainRenderer != null) ? penisLinearChainRenderer.skinnedMeshRenderer : null);
			if (skinnedMeshRenderer != null)
			{
				this.m_ConstrainedSkeleton = this.m_PenisRoot.GetComponentNotNull<ConstrainedSkeleton>();
				if (!this.m_ConstrainedSkeleton.initiated)
				{
					this.m_ConstrainedSkeleton.Init(skinnedMeshRenderer);
				}
				this.m_PenisRoot.GetComponentNotNull<RootBone>().Init(this.m_ConstrainedSkeleton, base.GetComponentInParent<Animator>(), Vector3.forward, Vector3.up);
			}
			else
			{
				Transform rootBoneTransform = base.GetComponentInParent<ICharacter>().rootBoneTransform;
				this.m_ConstrainedSkeleton = rootBoneTransform.GetComponentNotNull<ConstrainedSkeleton>();
				if (!this.m_ConstrainedSkeleton.initiated)
				{
					Debug.LogError("el chain de pene deberia comenzar despues de iniciar el ConstrainedSkeleton");
					throw new NotSupportedException("el chain de pene deberia comenzar despues de iniciar el ConstrainedSkeleton");
				}
				if (!rootBoneTransform.GetComponentNotNull<RootBone>().initiated)
				{
					throw new NotSupportedException("el chain de pene deberia comenzar despues de iniciar el RootBone");
				}
			}
			base.StartUnityEvent();
			this.m_defaultLocalPosition = this.m_puntoBaseTransform.localPosition;
			this.m_defaultLocalRotationCorrectedAgainstGravity = (this.m_defaultLocalRotation = Quaternion.Inverse(this.m_PenisRoot.rotation) * this.m_puntoBaseTransform.rotation);
			this.m_InitialGravityLocalToRoot = new Vector3?(this.m_puntoBaseTransform.InverseTransformDirection(Physics.gravity).normalized);
			this.SetAngleAgainsGravity(this.m_angleAgaintsGravity);
			base.CorrectChainTransform(this.correctChainScaleOnScaleChange);
			this.LoadPuntos();
			this.AddConstraintsToBone(base.rootPunto, -1);
			for (int i = 0; i < base.puntosExcluyendoRootList.Count; i++)
			{
				this.AddConstraintsToBone(base.puntosExcluyendoRootList[i], i);
			}
			this.addingFollowers = null;
			if (!string.IsNullOrEmpty(this.m_map.penisTip))
			{
				this.m_tipBone = this.m_pushBone.FindDeepChild(this.m_map.penisTip, true);
				if (this.m_tipBone == null)
				{
					Debug.LogWarning("no se encontro penis Tip");
				}
			}
			this.m_defaultTipLocalPositionFromBase = this.m_puntoBaseTransform.InverseTransformPoint(this.m_tipBone.position);
			base.StartPoints();
			this.ConfigPunta();
			base.LoadRootScaleChager();
			base.StartRootScaleChager();
			base.rootPunto.UpdateMass();
			base.FixPointsEnOrdenAsc();
			this.UpdateTotalMass();
			base.EjecutarEnOrdenAsc(new Action<PenisPoint>(this.SetDefaultLocalPositions));
			Transform transform = this.punta.transform;
			this.m_tipPhysicBone = transform.CreateChild(this.m_tipBone.name, true);
			this.m_tipPhysicBone.localPosition = transform.InverseTransformPoint(this.m_tipBone.position);
			this.m_tipPhysicBone.localRotation = Quaternion.identity;
			this.m_tipPhysicBone.localScale = this.m_tipBone.localScale;
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x000259E0 File Offset: 0x00023BE0
		protected override void FixingPointsEnOrdenAsc()
		{
			base.FixingPointsEnOrdenAsc();
			this.rootConfig.jointBodyAdmin.ownRigidIsKinematic = this.rootPointEsKinematico;
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x000259FE File Offset: 0x00023BFE
		public override void OnUpdateEvent2()
		{
			this.m_puedeEstirar = this.m_puedeEstirarModificable.Or(false);
			if (this.fixPositions)
			{
				this.ForceFirstPointToRoot(false);
				base.EjecutarEnOrdenAsc(this.pointPorblemFixerHandler);
			}
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x00025A2D File Offset: 0x00023C2D
		protected override void OnAplicar()
		{
			base.CorrectChainTransform(this.correctChainScaleOnScaleChange);
			base.rootPunto.UpdateMass();
			base.FixPointsEnOrdenAsc();
			this.UpdateTotalMass();
			base.ReSubscribeToGlobalUpdater();
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x00025A59 File Offset: 0x00023C59
		public void RestoreBasePositionRotation()
		{
			this.m_puntoBaseTransform.localPosition = this.m_defaultLocalPosition;
			this.m_puntoBaseTransform.rotation = this.m_PenisRoot.rotation * this.m_defaultLocalRotation;
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x00025A90 File Offset: 0x00023C90
		private void SetDefaultLocalPositions(PenisPoint current)
		{
			Rigidbody connectedBody = current.joint.connectedBody;
			current.connectedDefautLocalPosition = current.jointRigidbody.transform.InverseTransformPoint(connectedBody.transform.position);
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x00025ACC File Offset: 0x00023CCC
		private void ForceFirstPointToRoot(bool debug = false)
		{
			PenisPoint rootPunto = base.rootPunto;
			PenisPoint penisPoint = base[0];
			penisPoint.jointRigidbody.transform.position = rootPunto.jointRigidbody.transform.position;
			penisPoint.jointRigidbody.transform.rotation = rootPunto.jointRigidbody.transform.rotation;
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x00025B28 File Offset: 0x00023D28
		private void PositionProblemFix(PenisPoint current)
		{
			bool flag = false;
			bool flag2 = false;
			bool isRoot = current.isRoot;
			Rigidbody connectedBody = current.joint.connectedBody;
			Transform transform = connectedBody.transform;
			Transform transform2 = current.jointRigidbody.transform;
			Vector3 zero = Vector3.zero;
			Vector3 forward = Vector3.forward;
			Vector3 vector = transform2.InverseTransformPoint(transform.position);
			float num = Vector3.Dot(forward, vector.normalized);
			Vector3 vector2 = vector;
			if (!isRoot && num <= 0f)
			{
				vector2 = Math3d.ProjectPointOnPlane(forward, zero, vector);
				flag2 = (flag = true);
			}
			if (vector2.magnitude > this.m_maxLocalDistanceBetweenPoints)
			{
				flag2 = (flag = true);
				float num2 = this.m_fixerStepSpeed * Time.fixedDeltaTime;
				vector2 = Vector3.MoveTowards(vector2, vector2.normalized * this.m_maxLocalDistanceBetweenPoints, num2);
			}
			if (flag2)
			{
				Vector3 vector3 = transform2.TransformPoint(vector2);
				transform.position = vector3;
			}
			if (flag)
			{
				connectedBody.angularVelocity = (connectedBody.velocity = Vector3.zero);
				connectedBody.Sleep();
			}
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x00025C20 File Offset: 0x00023E20
		private void ConfigPunta()
		{
			int capsuleDirection = ExtendedMonoBehaviour.GetCapsuleDirection(this.puntosConfig.jointAxisAdmin.localUpAxis, this.puntosConfig.jointAxisAdmin.localRightAxis);
			PenisPoint last = base.last;
			PenisPointCollider mainCollider = last.mainCollider;
			Rigidbody connectedBody = last.joint.connectedBody;
			this.m_puntaMainCollider = connectedBody.GetComponentNotNull<PenisPointCollider>();
			this.m_puntaMainCollider.gameObject.layer = MapaSingleton<ConfiguracionGlobal>.instance.layers.penes;
			if (this.colliderSizeGetter != null)
			{
				if (this.m_tipBone == null)
				{
					throw new NotSupportedException();
				}
				float num;
				float num2;
				this.colliderSizeGetter(null, this.cantidadDePuntos, this.m_puntaMainCollider.transform, this.m_tipBone, out num, out num2);
				this.m_puntaMainCollider.Crear(this, num, num2, capsuleDirection);
			}
			else
			{
				this.m_puntaMainCollider.Crear(this, mainCollider, capsuleDirection);
			}
			Transform transform = connectedBody.transform.CreateChild(connectedBody.name + "_Complementario", false);
			transform.gameObject.layer = MapaSingleton<ConfiguracionGlobal>.instance.layers.penesComplemento;
			this.m_puntaComplementoCollider = transform.GetComponentNotNull<PenisPointCollider>();
			this.m_puntaComplementoCollider.CrearCopiando(this, this.m_puntaMainCollider);
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x00025D50 File Offset: 0x00023F50
		public void SetUserLocalRotation(Quaternion localRotation)
		{
			this.m_userLocalRotation = localRotation;
			Quaternion quaternion = this.m_defaultLocalRotation * this.m_userLocalRotation;
			this.puntoBaseTransform.rotation = this.m_PenisRoot.rotation * quaternion;
			this.m_defaultLocalRotationCorrectedAgainstGravity = quaternion;
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x00025D9C File Offset: 0x00023F9C
		public void FixUnderSkinPenetrationProyection(Transform skinSurface, float w)
		{
			Vector3 vector = (Vector3.LerpUnclamped(skinSurface.position, this.m_PenisRoot.position, w) - this.m_PenisRoot.position) * Mathf.Lerp(1f, this.m_PenisRoot.localScale.Escala(), 0.5f);
			Vector3 vector2 = this.m_PenisRoot.rotation * this.m_defaultLocalRotation * Vector3.forward;
			Vector3 vector3 = Vector3.Project(vector, vector2) + this.m_PenisRoot.position;
			this.puntoBaseTransform.position = vector3;
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x00025E38 File Offset: 0x00024038
		public void SetAngleAgainsGravity(float angle)
		{
			Vector3 normalized = Vector3.Cross(this.m_InitialGravityLocalToRoot.Value, Vector3.forward).normalized;
			Quaternion quaternion = this.m_defaultLocalRotation * this.m_userLocalRotation * Quaternion.AngleAxis(angle, normalized);
			this.puntoBaseTransform.rotation = this.m_PenisRoot.rotation * quaternion;
			this.m_defaultLocalRotationCorrectedAgainstGravity = quaternion;
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x00025EA4 File Offset: 0x000240A4
		protected override void OnRootScaleChanged(object target)
		{
			base.OnRootScaleChanged(target);
			if (this.correctChainTransformOnScaleChange)
			{
				base.CorrectChainTransform(this.correctChainScaleOnScaleChange);
			}
			else if (this.correctChainScaleOnScaleChange)
			{
				base.CorrectChainTransformScale();
			}
			base.rootPunto.UpdateMass();
			base.FixPointsEnOrdenAsc();
			this.UpdateTotalMass();
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x00025EF4 File Offset: 0x000240F4
		public void UpdateTotalMass()
		{
			this.m_totalMass = base.rootPunto.principal.mass;
			for (int i = 0; i < base.puntosExcluyendoRootList.Count; i++)
			{
				PenisPoint penisPoint = base.puntosExcluyendoRootList[i];
				this.m_totalMass += penisPoint.principal.mass;
			}
			Action<PenisLinearChain> action = this.updatedTotalMass;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x00025F63 File Offset: 0x00024163
		public PenisPoint Next(PenisPoint current)
		{
			if (current.isLast)
			{
				return null;
			}
			return base[current.index + 1];
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x00025F7D File Offset: 0x0002417D
		public PenisPoint previus(PenisPoint current)
		{
			if (current.isRoot)
			{
				return null;
			}
			return base[current.index - 1];
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x00025F98 File Offset: 0x00024198
		protected override Transform GetJointTransformOfPoint(int index)
		{
			string nameOfIndex = this.m_map.GetNameOfIndex(index);
			Transform transform = this.m_skeletonRoot.FindDeepChild(nameOfIndex, true);
			Transform copy = this.GetCopy(transform);
			copy.rotation *= Quaternion.Euler(this.m_rotationOffset);
			return copy;
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x00025FE4 File Offset: 0x000241E4
		protected override Transform GetTargetBodyTransformOfPoint(int index)
		{
			string nameOfIndex = this.m_map.GetNameOfIndex(index + 1);
			Transform transform = this.m_skeletonRoot.FindDeepChild(nameOfIndex, true);
			Transform copy = this.GetCopy(transform);
			copy.rotation *= Quaternion.Euler(this.m_rotationOffset);
			return copy;
		}

		// Token: 0x06000B61 RID: 2913 RVA: 0x00026034 File Offset: 0x00024234
		protected override Transform GetCharBoneTargetTransformOfPoint(int index)
		{
			string nameOfIndex = this.m_map.GetNameOfIndex(index);
			return this.m_skeletonRoot.FindDeepChild(nameOfIndex, true);
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x0002605B File Offset: 0x0002425B
		public Transform GetCharBoneTarget(int index)
		{
			return this.GetCharBoneTargetTransformOfPoint(index);
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x00026064 File Offset: 0x00024264
		private Transform GetCopy(Transform bone)
		{
			Transform transform = base.transform.FindChildNotNull(bone.name);
			transform.CopyPositionRotation(bone);
			if (!this.m_CharBonesDic.ContainsKey(transform))
			{
				this.m_CharBonesDic.Add(transform, bone);
			}
			return transform;
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x000260A6 File Offset: 0x000242A6
		protected override Transform GetTargetBodyTransformOfRootPoint()
		{
			return this.GetJointTransformOfPoint(0);
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x000260AF File Offset: 0x000242AF
		protected override void CustomizarPuntoRoot(PenisPoint punto)
		{
			base.CustomizarPuntoRoot(punto);
			punto.configuracion = this.rootConfig;
			this.AddComponentsToBone(punto, -1);
			this.AddPuntoParams(punto, -1);
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x000260D4 File Offset: 0x000242D4
		protected override void CustomizarPunto(PenisPoint punto, int index)
		{
			base.CustomizarPunto(punto, index);
			punto.colliderSizeGetter = this.colliderSizeGetter;
			this.AddComponentsToBone(punto, index);
			this.AddPuntoParams(punto, index);
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x000260FC File Offset: 0x000242FC
		protected override void AfterStartPoint(PenisPoint point)
		{
			base.AfterStartPoint(point);
			LimitarPolaridadDeAxis component = point.joint.GetComponent<LimitarPolaridadDeAxis>();
			if (component != null)
			{
				component.estaLimitando = (LimitarPolaridadDeAxis p) => !this.m_puedeEstirar;
			}
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x00026137 File Offset: 0x00024337
		private void AddPuntoParams(PenisPoint punto, int index = -1)
		{
			punto.chain = this;
			punto.index = index;
		}

		// Token: 0x06000B69 RID: 2921 RVA: 0x00026148 File Offset: 0x00024348
		private void AddComponentsToBone(PenisPoint punto, int index)
		{
			Transform targetBodyTransform = punto.targetBodyTransform;
			Transform transform = this.m_CharBonesDic[punto.targetBodyTransform];
			if (this.m_followersInBones)
			{
				punto.trasnformCopier = transform.gameObject.AddComponent<TrasnformCopier>();
			}
			else
			{
				punto.trasnformCopier = targetBodyTransform.gameObject.AddComponent<TrasnformCopier>();
			}
			GlobalUpdater.UpdateType followerUpdateEvent = this.m_followerUpdateEvent;
			int num = 0;
			if (this.m_delegateGetFollowerUpdateEventOfIndex != null)
			{
				this.m_delegateGetFollowerUpdateEventOfIndex(index, out num, out followerUpdateEvent);
			}
			Quaternion quaternion = Quaternion.Inverse(Quaternion.Euler(this.m_rotationOffset));
			Vector3 zero = Vector3.zero;
			bool flag = false;
			bool flag2 = false;
			PenisLinearChainAddingFollowersHandler penisLinearChainAddingFollowersHandler = this.addingFollowers;
			if (penisLinearChainAddingFollowersHandler != null)
			{
				penisLinearChainAddingFollowersHandler(punto.trasnformCopier, index, ref zero, ref quaternion, ref flag, ref flag2, this);
			}
			Vector3? vector;
			if (flag2)
			{
				vector = new Vector3?(Vector3.one);
			}
			else
			{
				vector = null;
			}
			punto.trasnformCopier.Init(flag, transform, targetBodyTransform, followerUpdateEvent, num, false, new Vector3?(quaternion.eulerAngles), new Vector3?(zero), vector);
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x0002623C File Offset: 0x0002443C
		public void OverrideMaxBoneZAxisRotation(float value)
		{
			if (base.isStared)
			{
				Debug.LogError("debe hacerse antes del start");
				return;
			}
			this.m_maxBoneZAxisRotation = value;
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x00026258 File Offset: 0x00024458
		private void AddConstraintsToBone(PenisPoint punto, int index)
		{
			Transform transform = this.m_CharBonesDic[punto.targetBodyTransform];
			if (this.m_ConstrainedSkeleton != null)
			{
				LimitAxisRotationPhysicsUserForSkeleton componentNotNull = transform.GetComponentNotNull<LimitAxisRotationPhysicsUserForSkeleton>();
				componentNotNull.limitAxisRotationConfig.maxAngle = this.m_maxBoneZAxisRotation;
				componentNotNull.limitAxisRotationConfig.rotationAxis = this.m_ConstrainedSkeleton.GetComponent<RootBone>().boneLocalForward;
				componentNotNull.Init(this.m_ConstrainedSkeleton, transform, this.m_constraintRootOverride);
				return;
			}
			Debug.LogWarning(punto.name + " no tendra contraints.", punto);
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x000262E5 File Offset: 0x000244E5
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Fix Penis Puntos",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x000262FE File Offset: 0x000244FE
		protected override void OnAplicar2()
		{
			base.FixPointsEnOrdenAsc();
		}

		// Token: 0x040005F2 RID: 1522
		[Header("IPeneEstirable")]
		[ReadOnlyUI]
		[SerializeField]
		private bool m_puedeEstirar;

		// Token: 0x040005F3 RID: 1523
		[SerializeField]
		private ModificableDeBool m_puedeEstirarModificable = new ModificableDeBool(false);

		// Token: 0x040005F4 RID: 1524
		public PenisPointColliderSizeGetterHandler colliderSizeGetter;

		// Token: 0x040005F7 RID: 1527
		[Header("PenisLinearChain")]
		[SerializeField]
		private GlobalUpdater.UpdateType m_event1 = GlobalUpdater.UpdateType.lateUpdateAfterMalePupetMaster;

		// Token: 0x040005F8 RID: 1528
		private PenisLinearChainAddingFollowerUpdateEvent m_delegateGetFollowerUpdateEventOfIndex;

		// Token: 0x040005F9 RID: 1529
		[ReadOnlyUI]
		[SerializeField]
		private GlobalUpdater.UpdateType m_followerUpdateEvent = GlobalUpdater.UpdateType.afterFixedUpdates1;

		// Token: 0x040005FA RID: 1530
		public bool redistribuirMasa = true;

		// Token: 0x040005FB RID: 1531
		[SerializeField]
		private float m_angleAgaintsGravity;

		// Token: 0x040005FC RID: 1532
		[SerializeField]
		private float m_maxLocalDistanceBetweenPoints = 0.04f;

		// Token: 0x040005FD RID: 1533
		[SerializeField]
		private float m_fixerStepSpeed = 20f;

		// Token: 0x040005FE RID: 1534
		[ReadOnlyUI]
		[SerializeField]
		private float m_totalMass;

		// Token: 0x040005FF RID: 1535
		[ReadOnlyUI]
		[SerializeField]
		private int m_cantidadDePuntos = -1;

		// Token: 0x04000600 RID: 1536
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_rotationOffset = Vector3.zero;

		// Token: 0x04000601 RID: 1537
		[ReadOnlyUI]
		[SerializeField]
		private bool m_followersInBones;

		// Token: 0x04000602 RID: 1538
		[Tooltip("puede generar glitches")]
		public bool correctChainTransformOnScaleChange;

		// Token: 0x04000603 RID: 1539
		[Tooltip("puede generar glitches")]
		public bool correctChainScaleOnScaleChange = true;

		// Token: 0x04000604 RID: 1540
		public bool ignorarCollsiionesEntrePuntos = true;

		// Token: 0x04000605 RID: 1541
		public bool ignorarCollsiionesConPadres;

		// Token: 0x04000606 RID: 1542
		private IPenisBoneMap m_map;

		// Token: 0x04000607 RID: 1543
		[ReadOnlyUI]
		[SerializeField]
		private ConstrainedSkeleton m_ConstrainedSkeleton;

		// Token: 0x04000608 RID: 1544
		[SerializeField]
		private List<Rigidbody> m_RigidBodiesParaIgnorar = new List<Rigidbody>();

		// Token: 0x04000609 RID: 1545
		public List<Collider> collidersParaIgnorar = new List<Collider>();

		// Token: 0x0400060A RID: 1546
		[Obsolete("", true)]
		private PenisPointCollider m_puntaCollider;

		// Token: 0x0400060B RID: 1547
		public bool rootPointEsKinematico = true;

		// Token: 0x0400060C RID: 1548
		private PenisPointCollider m_puntaMainCollider;

		// Token: 0x0400060D RID: 1549
		private PenisPointCollider m_puntaComplementoCollider;

		// Token: 0x0400060E RID: 1550
		public bool fixPositions = true;

		// Token: 0x0400060F RID: 1551
		[Header("Usar si no hay animator")]
		[SerializeField]
		private Transform m_penisRoot;

		// Token: 0x04000610 RID: 1552
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_PenisRoot;

		// Token: 0x04000611 RID: 1553
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_puntoBaseTransform;

		// Token: 0x04000612 RID: 1554
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_tipPhysicBone;

		// Token: 0x04000613 RID: 1555
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_tipBone;

		// Token: 0x04000614 RID: 1556
		private PenisPoint.Configuracion rootConfig;

		// Token: 0x04000615 RID: 1557
		private Dictionary<Transform, Transform> m_CharBonesDic = new Dictionary<Transform, Transform>();

		// Token: 0x04000616 RID: 1558
		[SerializeField]
		[ReadOnlyUI]
		private float m_maxBoneZAxisRotation = 25f;

		// Token: 0x04000617 RID: 1559
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_skeletonRoot;

		// Token: 0x04000618 RID: 1560
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_pushBone;

		// Token: 0x04000619 RID: 1561
		private Vector3 m_worldUpwardsDirection;

		// Token: 0x0400061A RID: 1562
		private Action<PenisPoint> pointPorblemFixerHandler;

		// Token: 0x0400061B RID: 1563
		private Vector3? m_InitialGravityLocalToRoot;

		// Token: 0x0400061C RID: 1564
		private Vector3 m_baseInitialUp;

		// Token: 0x0400061D RID: 1565
		private Vector3 m_defaultLocalPosition;

		// Token: 0x0400061E RID: 1566
		private Quaternion m_defaultLocalRotation;

		// Token: 0x0400061F RID: 1567
		private Quaternion m_userLocalRotation = Quaternion.identity;

		// Token: 0x04000620 RID: 1568
		private Quaternion m_defaultLocalRotationCorrectedAgainstGravity;

		// Token: 0x04000621 RID: 1569
		private Transform m_constraintRootOverride;

		// Token: 0x04000622 RID: 1570
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_defaultTipLocalPositionFromBase;

		// Token: 0x04000623 RID: 1571
		private PenisLinearChainRenderer m_PenisLinearChainRenderer;
	}
}
