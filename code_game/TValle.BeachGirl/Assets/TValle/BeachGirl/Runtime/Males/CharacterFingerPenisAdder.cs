using System;
using Assets.Base.BeachGirl.Mapas;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Males
{
	// Token: 0x0200009D RID: 157
	[RequireComponent(typeof(ICharacter))]
	public class CharacterFingerPenisAdder : BaseCharacterPenisAdder<Finger>
	{
		// Token: 0x060004C4 RID: 1220 RVA: 0x0000F29C File Offset: 0x0000D49C
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.m_initailSize = 1f;
			this.m_initailErection = 100f;
			this.m_angleAgaintsGravity = 0f;
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x0000F2C5 File Offset: 0x0000D4C5
		protected sealed override IPenisBoneMap penisBoneMap
		{
			get
			{
				return Singleton<MapasDeHuesos>.instance.mapas.fingerBoneMap;
			}
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0000F2D6 File Offset: 0x0000D4D6
		protected sealed override PenisPoint.Configuracion GetConfig()
		{
			return this.puntosConfig;
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0000F2DE File Offset: 0x0000D4DE
		protected sealed override PenisPointColliderSizeGetterHandler SizeGetter()
		{
			return new PenisPointColliderSizeGetterHandler(this.PenisPointColliderSizeGetterHandler);
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0000F2EC File Offset: 0x0000D4EC
		protected sealed override Transform GetChainHolder()
		{
			Transform boneTransform = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.RightHand);
			this.m_holderForPhyscis = boneTransform.transform.CreateChild("Finger Physics");
			this.m_holderForPhyscis.parent = this.m_Character.bodyAnimator.transform;
			return this.m_holderForPhyscis.CreateChild("Chain");
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0000F350 File Offset: 0x0000D550
		protected sealed override void Awaking(Transform chainHolder)
		{
			this.m_rotationOffset = Quaternion.LookRotation(Vector3.Cross(this.localRightAxis.normalized, this.localUpAxis.normalized).normalized, this.localUpAxis.normalized);
			Transform boneTransform = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.RightIndexProximal);
			this.m_overrideSkinSurfaceTransform = boneTransform;
			if (this.m_baseDelDedoParaPhyscis == null)
			{
				Transform boneTransform2 = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.RightHand);
				this.m_RootDelDedoParaPhyscis = boneTransform2.CreateChild(boneTransform2.name);
				this.m_RootDelDedoParaPhyscis.rotation *= this.m_rotationOffset;
				this.m_RootDelDedoParaPhyscis.parent = this.m_holderForPhyscis;
				this.m_RootToHandFollower = this.m_RootDelDedoParaPhyscis.GetComponentNotNull<TrasnformCopier>();
				this.m_RootToHandFollower.Init(true, this.m_RootToHandFollower.transform, boneTransform2, GlobalUpdater.UpdateType.beforeFixedUpdates1, 0, false, new Vector3?(this.m_rotationOffset.eulerAngles), null, null);
				this.m_baseDelDedoParaPhyscis = boneTransform.CreateChild(this.penisBoneMap.penisBase);
				this.m_baseDelDedoParaPhyscis.parent = this.m_holderForPhyscis;
			}
			this.m_baseDelDedoParaPhyscis.rotation *= this.m_rotationOffset;
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0000F4A6 File Offset: 0x0000D6A6
		protected override Transform GetConnstraintsRootBone()
		{
			return this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.RightHand);
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0000F4BC File Offset: 0x0000D6BC
		protected override void OnRootConfigCreated(PenisPoint.Configuracion arg1, PenisLinearChain arg2)
		{
			base.OnRootConfigCreated(arg1, arg2);
			arg1.jointAnglesAdmin = (JointAnglesAdmin.Configuracion)arg1.jointAnglesAdmin.Clone();
			arg1.jointDrivesAdminV2 = (JointDrivesAdminV2.Configuracion)arg1.jointDrivesAdminV2.Clone();
			arg1.jointMotionsAdmin = (JointMotionsAdmin.Configuracion)arg1.jointMotionsAdmin.Clone();
			CharacterFingerPenisAdder.FixRootPoint(arg1, arg2);
			arg2.jointsFixing += delegate(LinearChainTipo2<PenisPoint, PenisPoint.Configuracion> c)
			{
				CharacterFingerPenisAdder.FixRootPoint(c.rootPunto.configuracion, (PenisLinearChain)c);
			};
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x0000F540 File Offset: 0x0000D740
		private static void FixRootPoint(PenisPoint.Configuracion arg1, PenisLinearChain arg2)
		{
			arg1.jointMotionsAdmin.angularXMotion = ConfigurableJointMotion.Free;
			arg1.jointMotionsAdmin.angularYMotion = ConfigurableJointMotion.Free;
			arg1.jointMotionsAdmin.angularZMotion = ConfigurableJointMotion.Free;
			arg1.jointAnglesAdmin.lowAngularXLimit = -55f;
			arg1.jointAnglesAdmin.angularYLimit = 55f;
			arg1.jointAnglesAdmin.angularZLimit = 45f;
			arg1.jointDrivesAdminV2.xAngularDrive.CopyFrom(arg2.puntosConfig.jointDrivesAdminV2.xAngularDrive);
			arg1.jointDrivesAdminV2.yzAngularDrive.CopyFrom(arg2.puntosConfig.jointDrivesAdminV2.yzAngularDrive);
			arg1.jointDrivesAdminV2.xAngularDrive.Modificar(0.75f);
			arg1.jointDrivesAdminV2.yzAngularDrive.Modificar(0.75f);
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0000F60C File Offset: 0x0000D80C
		protected override void OnSettingConfigToPoint(PenisPoint point, int index, ref PenisPoint.Configuracion config, LinearChainTipo2<PenisPoint, PenisPoint.Configuracion> sender)
		{
			base.OnSettingConfigToPoint(point, index, ref config, sender);
			if (!index.IsLastIndex(2))
			{
				return;
			}
			config = (PenisPoint.Configuracion)config.Clone();
			config.jointAnglesAdmin = (JointAnglesAdmin.Configuracion)config.jointAnglesAdmin.Clone();
			config.jointDrivesAdminV2 = (JointDrivesAdminV2.Configuracion)config.jointDrivesAdminV2.Clone();
			CharacterFingerPenisAdder.FixTipPoint(config, (PenisLinearChain)sender);
			sender.jointsFixing += delegate(LinearChainTipo2<PenisPoint, PenisPoint.Configuracion> c)
			{
				CharacterFingerPenisAdder.FixTipPoint(sender.last.configuracion, (PenisLinearChain)c);
			};
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0000F6A8 File Offset: 0x0000D8A8
		private static void FixTipPoint(PenisPoint.Configuracion arg1, PenisLinearChain arg2)
		{
			arg1.jointAnglesAdmin.lowAngularXLimit = arg2.puntosConfig.jointAnglesAdmin.lowAngularXLimit * 3f;
			arg1.jointDrivesAdminV2.xAngularDrive.CopyFrom(arg2.puntosConfig.jointDrivesAdminV2.xAngularDrive);
			arg1.jointDrivesAdminV2.xAngularDrive.Modificar(0.75f);
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0000F70C File Offset: 0x0000D90C
		protected override void AfterReferencesSetted()
		{
			base.AfterReferencesSetted();
			this.m_Penis.partesConfig.freeAngularMotionsOnPenetracion = true;
			this.m_Penis.partesConfig.colRadiusInfluenceOnCollision = 0.2f;
			this.m_Penis.partesConfig.colRadiusInfluenceOnHelperVag = 0.2f;
			this.m_Penis.partesConfig.colRadiusInfluenceOnHelperAnus = 0.666f;
			this.m_Penis.partesConfig.colRadiusInfluenceOnHelperFace = 0f;
			this.m_Penis.partesConfig.maxColRadiusWhenCloseToHoleVag = 0.666f;
			this.m_Penis.partesConfig.maxColRadiusWhenCloseToHoleAnus = 0.333f;
			this.m_Penis.partesConfig.maxColRadiusWhenCloseToHoleFace = 1f;
			this.m_Penis.apuntarVelocidadAlEntrar *= 100f;
			this.m_Penis.apuntarVelocidadAlSalir *= 100f;
			this.m_PenisLinearChain.SetInitialConfig(false, 2, this.m_rotationOffset.eulerAngles);
			this.m_PenisLinearChain.SetCustomTransforms(this.m_RootDelDedoParaPhyscis, this.m_baseDelDedoParaPhyscis);
			this.m_PenisLinearChain.SetFollowerEventDelegate(new PenisLinearChainAddingFollowerUpdateEvent(CharacterFingerPenisAdder.FolowerEventGetter));
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0000F837 File Offset: 0x0000DA37
		private static void FolowerEventGetter(int index, out int updateIndex, out GlobalUpdater.UpdateType updateEvent)
		{
			updateIndex = index + 1;
			updateEvent = GlobalUpdater.UpdateType.lateUpdateAfterMalePupetMaster;
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x0000F842 File Offset: 0x0000DA42
		protected sealed override Transform GetPushingBone()
		{
			if (this.pushingBone != null)
			{
				return this.pushingBone;
			}
			return this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.RightHand);
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x0000F86B File Offset: 0x0000DA6B
		protected override Transform GetSkeletonRoot()
		{
			return this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.RightHand);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0000F880 File Offset: 0x0000DA80
		private void PenisPointColliderSizeGetterHandler(PenisPoint punto, int index, Transform current, Transform next, out float localLargo, out float localRadius)
		{
			switch (index)
			{
			case 0:
				localLargo = current.InverseTransformPoint(next.position).magnitude;
				localRadius = this.localRadiusProximal;
				return;
			case 1:
				localLargo = current.InverseTransformPoint(next.position).magnitude;
				localRadius = this.localRadiusMiddle;
				return;
			case 2:
				localLargo = current.InverseTransformPoint(next.position).magnitude;
				localRadius = this.localRadiusDistal;
				localLargo -= localRadius;
				return;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0000F920 File Offset: 0x0000DB20
		protected override void BeforeStartPenis()
		{
			base.BeforeStartPenis();
			this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.RightHand).GetComponentNotNull<FingerPenisDedosParentFix>();
			this.m_Penis.SetPhysicMaterial(Singleton<ColecionDePhysicsMaterials>.instance.dedo);
			this.m_PenisLinearChain.redistribuirMasa = false;
			this.m_PenisLinearChain.addingFollowers += this.M_PenisLinearChain_addingFollowers;
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x0000F984 File Offset: 0x0000DB84
		private void M_PenisLinearChain_addingFollowers(TrasnformCopier follower, int index, ref Vector3 poitionOffset, ref Quaternion rotationOffset, ref bool followScale, ref bool usarScaleMod, PenisLinearChain sender)
		{
			usarScaleMod = false;
			followScale = true;
			switch (index)
			{
			case -1:
				return;
			case 0:
				poitionOffset += new Vector3(0f, 0.002f, 0f);
				rotationOffset *= Quaternion.Euler(new Vector3(0f, 0f, -10f));
				return;
			case 1:
				poitionOffset += new Vector3(0f, -0.001f, 0f);
				rotationOffset *= Quaternion.Euler(new Vector3(0f, 0f, 5f));
				return;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x040002CB RID: 715
		public const int cantidadDePuntos = 2;

		// Token: 0x040002CC RID: 716
		[SerializeField]
		private PenisPoint.Configuracion puntosConfig = new PenisPoint.FingerPenisConfiguracion();

		// Token: 0x040002CD RID: 717
		[SerializeField]
		[Tooltip("Si es null se usara el animator para buscarlo")]
		private Transform pushingBone;

		// Token: 0x040002CE RID: 718
		public float localRadiusProximal = 0.0095f;

		// Token: 0x040002CF RID: 719
		public float localRadiusMiddle = 0.0082f;

		// Token: 0x040002D0 RID: 720
		public float localRadiusDistal = 0.007f;

		// Token: 0x040002D1 RID: 721
		public Vector3 localUpAxis = -Vector3.right;

		// Token: 0x040002D2 RID: 722
		public Vector3 localRightAxis = -Vector3.forward;

		// Token: 0x040002D3 RID: 723
		[ReadOnlyUI]
		[SerializeField]
		protected Quaternion m_rotationOffset;

		// Token: 0x040002D4 RID: 724
		[SerializeField]
		[Tooltip("Si es null se usara el animator para crear uno")]
		protected Transform m_baseDelDedoParaPhyscis;

		// Token: 0x040002D5 RID: 725
		protected Transform m_RootDelDedoParaPhyscis;

		// Token: 0x040002D6 RID: 726
		[Obsolete("", true)]
		protected Transform m_baseDelDedoBone;

		// Token: 0x040002D7 RID: 727
		protected Transform m_holderForPhyscis;

		// Token: 0x040002D8 RID: 728
		protected TrasnformCopier m_RootToHandFollower;
	}
}
