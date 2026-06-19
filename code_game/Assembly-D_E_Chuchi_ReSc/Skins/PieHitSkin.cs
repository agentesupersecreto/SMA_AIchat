using System;
using System.Collections.Generic;
using Assets._ReusableScripts.BoneColliders;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using Assets._ReusableScripts.CuchiCuchi.Skins.Colliders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000073 RID: 115
	public class PieHitSkin : NonSkinnedHitSkin<PieHitSkin.Colliders>
	{
		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000308 RID: 776 RVA: 0x0000B32C File Offset: 0x0000952C
		public override BodyPartEnum parte
		{
			get
			{
				switch (this.m_side)
				{
				case Side.none:
					throw new InvalidOperationException();
				case Side.L:
					return BodyPartEnum.pie_L;
				case Side.R:
					return BodyPartEnum.pie_R;
				case Side.F:
					throw new InvalidOperationException();
				case Side.B:
					throw new InvalidOperationException();
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000309 RID: 777 RVA: 0x0000B379 File Offset: 0x00009579
		public override Side side
		{
			get
			{
				return this.m_side;
			}
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000B384 File Offset: 0x00009584
		public virtual void Init(Side pieSide, Skin VisualSkin, FeetBoneMap feetBoneMap)
		{
			if (feetBoneMap == null)
			{
				throw new ArgumentNullException("feetBoneMap", "feetBoneMap null reference.");
			}
			Transform transform;
			HitPartEnum hitPartEnum;
			switch (pieSide)
			{
			case Side.none:
				throw new InvalidOperationException();
			case Side.L:
				transform = base.owner.animator.GetBoneTransform(HumanBodyBones.LeftFoot);
				hitPartEnum = HitPartEnum.pie_L;
				break;
			case Side.R:
				transform = base.owner.animator.GetBoneTransform(HumanBodyBones.RightFoot);
				hitPartEnum = HitPartEnum.pie_R;
				break;
			case Side.F:
				throw new InvalidOperationException();
			case Side.B:
				throw new InvalidOperationException();
			default:
				throw new ArgumentOutOfRangeException();
			}
			this.m_side = pieSide;
			this.m_FeetBonesMap = feetBoneMap;
			if (this.m_FeetBonesMap == null)
			{
				throw new ArgumentNullException("m_FeetBonesMap", "m_FeetBonesMap null reference.");
			}
			Transform boneTransform = base.owner.animator.GetBoneTransform(HumanBodyBones.Hips);
			this.bones.feet = transform;
			switch (this.m_side)
			{
			case Side.none:
				throw new InvalidOperationException();
			case Side.L:
				this.bones.fingersRoot = boneTransform.FindDeepChild(this.m_FeetBonesMap.root.l, true);
				this.bones.thumbProximal = boneTransform.FindDeepChild(this.m_FeetBonesMap.thumb.l, true);
				this.bones.indexProximal = boneTransform.FindDeepChild(this.m_FeetBonesMap.index.l, true);
				this.bones.middleProximal = boneTransform.FindDeepChild(this.m_FeetBonesMap.middle.l, true);
				this.bones.ringProximal = boneTransform.FindDeepChild(this.m_FeetBonesMap.ring.l, true);
				this.bones.littleProximal = boneTransform.FindDeepChild(this.m_FeetBonesMap.little.l, true);
				break;
			case Side.R:
				this.bones.fingersRoot = boneTransform.FindDeepChild(this.m_FeetBonesMap.root.r, true);
				this.bones.thumbProximal = boneTransform.FindDeepChild(this.m_FeetBonesMap.thumb.r, true);
				this.bones.indexProximal = boneTransform.FindDeepChild(this.m_FeetBonesMap.index.r, true);
				this.bones.middleProximal = boneTransform.FindDeepChild(this.m_FeetBonesMap.middle.r, true);
				this.bones.ringProximal = boneTransform.FindDeepChild(this.m_FeetBonesMap.ring.r, true);
				this.bones.littleProximal = boneTransform.FindDeepChild(this.m_FeetBonesMap.little.r, true);
				break;
			case Side.F:
				throw new InvalidOperationException();
			case Side.B:
				throw new InvalidOperationException();
			default:
				throw new ArgumentOutOfRangeException();
			}
			this.CrearCollidersDeMano();
			this.Init(hitPartEnum, transform, VisualSkin);
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0000B644 File Offset: 0x00009844
		protected virtual void CrearCollidersDeMano()
		{
			base.colliders.talon = this.CrearTalom(this.bones.feet, this.bones.fingersRoot, this.localMedidas.feetAlto * 1.8f);
			base.colliders.thumb = this.CrearDedo(this.bones.thumbProximal, this.localMedidas.thumbLargo, this.localMedidas.thumbAncho);
			base.colliders.index = this.CrearDedo(this.bones.indexProximal, this.localMedidas.indexLargo, this.localMedidas.indexAncho);
			base.colliders.middle = this.CrearDedo(this.bones.middleProximal, this.localMedidas.middleLargo, this.localMedidas.middleAncho);
			base.colliders.ring = this.CrearDedo(this.bones.ringProximal, this.localMedidas.ringLargo, this.localMedidas.ringAncho);
			base.colliders.little = this.CrearDedo(this.bones.littleProximal, this.localMedidas.littleLargo, this.localMedidas.littleAncho);
			base.colliders.piePlanta = this.CrearPlanta(this.bones.feet, base.colliders.talon, this.bones.thumbProximal, this.bones.littleProximal, this.localMedidas.feetAlto, this.localMedidas.feetAncho);
			base.colliders.tobillo = this.CrearTobillo(this.bones.feet, this.localMedidas.tobilloAncho);
			base.colliders.piePlantaSuperior = this.CrearPlanta(this.bones.feet, this.bones.thumbProximal, this.bones.littleProximal, this.localMedidas.feetAlto, this.localMedidas.feetAncho * 0.75f);
			base.colliders.piePlantaMedia = this.CrearMediaPlanta(this.bones.feet, base.colliders.talon, this.bones.thumbProximal, this.bones.littleProximal, this.localMedidas.feetAlto, this.localMedidas.feetAncho * 0.85f);
			base.colliders.plantaDedoToDedo = this.CrearPlantaDedoToDedo(this.bones.fingersRoot, this.bones.thumbProximal, this.bones.littleProximal, this.localMedidas.feetAlto);
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000B8E4 File Offset: 0x00009AE4
		protected virtual TalonPieCollider CrearTalom(Transform pieBaseBone, Transform dedosRoot, float ancho)
		{
			TalonPieCollider talonPieCollider = TalonPieCollider.Crear<TalonPieCollider>(this, pieBaseBone, ancho, dedosRoot, base.transform, BoneCollider.Mode.zAxis);
			this.m_pieColliders.Add(talonPieCollider);
			return talonPieCollider;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0000B910 File Offset: 0x00009B10
		protected virtual CapsuleParteCollider CrearDedo(Transform pieBaseBone, float largo, float ancho)
		{
			CapsuleParteCollider capsuleParteCollider = CapsuleParteCollider.Crear<CapsuleParteCollider>(this, pieBaseBone, largo, ancho, base.transform, BoneCollider.Mode.zAxis);
			this.m_pieColliders.Add(capsuleParteCollider);
			return capsuleParteCollider;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0000B93C File Offset: 0x00009B3C
		protected virtual PlantaPieCollider CrearPlanta(Transform pieBase, TalonPieCollider talon, Transform dedoGordo, Transform dedoPequeño, float alto, float ancho)
		{
			PlantaPieCollider plantaPieCollider = PlantaPieCollider.Crear<PlantaPieCollider>(this, pieBase, talon, dedoGordo, dedoPequeño, alto, ancho, base.transform, BoneCollider.Mode.zAxis);
			this.m_pieColliders.Add(plantaPieCollider);
			return plantaPieCollider;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000B970 File Offset: 0x00009B70
		protected virtual TobilloCollider CrearTobillo(Transform pieBase, float ancho)
		{
			TobilloCollider tobilloCollider = TobilloCollider.Crear<TobilloCollider>(this, pieBase, ancho, base.transform);
			this.m_pieColliders.Add(tobilloCollider);
			return tobilloCollider;
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0000B99C File Offset: 0x00009B9C
		protected virtual PlantaSuperiorPieCollider CrearPlanta(Transform pieBase, Transform dedoGordo, Transform dedoPequeño, float alto, float ancho)
		{
			PlantaSuperiorPieCollider plantaSuperiorPieCollider = PlantaSuperiorPieCollider.Crear<PlantaSuperiorPieCollider>(this, pieBase, dedoGordo, dedoPequeño, alto, ancho, base.transform, BoneCollider.Mode.zAxis);
			this.m_pieColliders.Add(plantaSuperiorPieCollider);
			return plantaSuperiorPieCollider;
		}

		// Token: 0x06000311 RID: 785 RVA: 0x0000B9CC File Offset: 0x00009BCC
		protected virtual PlantaMediaPieCollider CrearMediaPlanta(Transform pieBase, TalonPieCollider talon, Transform dedoGordo, Transform dedoPequeño, float alto, float ancho)
		{
			PlantaMediaPieCollider plantaMediaPieCollider = PlantaMediaPieCollider.Crear<PlantaMediaPieCollider>(this, pieBase, talon, dedoGordo, dedoPequeño, alto, ancho, base.transform, BoneCollider.Mode.zAxis);
			this.m_pieColliders.Add(plantaMediaPieCollider);
			return plantaMediaPieCollider;
		}

		// Token: 0x06000312 RID: 786 RVA: 0x0000BA00 File Offset: 0x00009C00
		protected virtual PlantaPieDedoGordoToDedoPequeno CrearPlantaDedoToDedo(Transform rootFiengers, Transform dedoGordo, Transform dedoPequeño, float ancho)
		{
			PlantaPieDedoGordoToDedoPequeno plantaPieDedoGordoToDedoPequeno = PlantaPieDedoGordoToDedoPequeno.Crear<PlantaPieDedoGordoToDedoPequeno>(this, rootFiengers, dedoGordo, dedoPequeño, ancho, base.transform);
			this.m_pieColliders.Add(plantaPieDedoGordoToDedoPequeno);
			return plantaPieDedoGordoToDedoPequeno;
		}

		// Token: 0x040001EC RID: 492
		[ReadOnlyUI]
		[SerializeField]
		private Side m_side;

		// Token: 0x040001ED RID: 493
		[SerializeField]
		private FeetBoneMap m_FeetBonesMap;

		// Token: 0x040001EE RID: 494
		public PieHitSkin.Bones bones = new PieHitSkin.Bones();

		// Token: 0x040001EF RID: 495
		public PieHitSkin.Medidas localMedidas = new PieHitSkin.Medidas();

		// Token: 0x040001F0 RID: 496
		private List<BoneCollider> m_pieColliders = new List<BoneCollider>();

		// Token: 0x02000074 RID: 116
		[Serializable]
		public class Colliders : NonSkinnedHitSkinBase.BaseColliders
		{
			// Token: 0x040001F1 RID: 497
			public TalonPieCollider talon;

			// Token: 0x040001F2 RID: 498
			public TobilloCollider tobillo;

			// Token: 0x040001F3 RID: 499
			public PlantaPieCollider piePlanta;

			// Token: 0x040001F4 RID: 500
			public PlantaSuperiorPieCollider piePlantaSuperior;

			// Token: 0x040001F5 RID: 501
			public PlantaMediaPieCollider piePlantaMedia;

			// Token: 0x040001F6 RID: 502
			public PlantaPieDedoGordoToDedoPequeno plantaDedoToDedo;

			// Token: 0x040001F7 RID: 503
			public CapsuleParteCollider thumb;

			// Token: 0x040001F8 RID: 504
			public CapsuleParteCollider index;

			// Token: 0x040001F9 RID: 505
			public CapsuleParteCollider middle;

			// Token: 0x040001FA RID: 506
			public CapsuleParteCollider ring;

			// Token: 0x040001FB RID: 507
			public CapsuleParteCollider little;
		}

		// Token: 0x02000075 RID: 117
		[Serializable]
		public class Bones
		{
			// Token: 0x040001FC RID: 508
			public Transform feet;

			// Token: 0x040001FD RID: 509
			public Transform fingersRoot;

			// Token: 0x040001FE RID: 510
			public Transform thumbProximal;

			// Token: 0x040001FF RID: 511
			public Transform indexProximal;

			// Token: 0x04000200 RID: 512
			public Transform middleProximal;

			// Token: 0x04000201 RID: 513
			public Transform ringProximal;

			// Token: 0x04000202 RID: 514
			public Transform littleProximal;
		}

		// Token: 0x02000076 RID: 118
		[Serializable]
		public class Medidas
		{
			// Token: 0x04000203 RID: 515
			public float feetAlto = 0.025f;

			// Token: 0x04000204 RID: 516
			public float feetAncho = 0.05f;

			// Token: 0x04000205 RID: 517
			public float tobilloAncho = 0.06f;

			// Token: 0x04000206 RID: 518
			public float thumbAncho = 0.02f;

			// Token: 0x04000207 RID: 519
			public float thumbLargo = 0.035f;

			// Token: 0x04000208 RID: 520
			public float indexAncho = 0.014f;

			// Token: 0x04000209 RID: 521
			public float indexLargo = 0.033f;

			// Token: 0x0400020A RID: 522
			public float middleAncho = 0.013f;

			// Token: 0x0400020B RID: 523
			public float middleLargo = 0.026f;

			// Token: 0x0400020C RID: 524
			public float ringAncho = 0.0125f;

			// Token: 0x0400020D RID: 525
			public float ringLargo = 0.023f;

			// Token: 0x0400020E RID: 526
			public float littleAncho = 0.012f;

			// Token: 0x0400020F RID: 527
			public float littleLargo = 0.02f;
		}
	}
}
