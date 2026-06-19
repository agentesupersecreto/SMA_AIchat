using System;
using System.Collections.Generic;
using Assets._ReusableScripts.BoneColliders;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using Assets._ReusableScripts.CuchiCuchi.Skins.Colliders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000077 RID: 119
	public class PieMaleHitSkin : NonSkinnedMaleHitSkin<PieMaleHitSkin.Colliders>
	{
		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000317 RID: 791 RVA: 0x0000BAFA File Offset: 0x00009CFA
		public override Side side
		{
			get
			{
				return this.m_side;
			}
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0000BB04 File Offset: 0x00009D04
		public virtual void Init(Side pieSide, Skin VisualSkin, FeetBoneMap feetBoneMap)
		{
			if (feetBoneMap == null)
			{
				throw new ArgumentNullException("feetBoneMap", "feetBoneMap null reference.");
			}
			ParteQuePuedeEstimular parteQuePuedeEstimular = ParteQuePuedeEstimular.piernas;
			Transform transform;
			switch (pieSide)
			{
			case Side.none:
				throw new InvalidOperationException();
			case Side.L:
				transform = base.owner.animator.GetBoneTransform(HumanBodyBones.LeftFoot);
				break;
			case Side.R:
				transform = base.owner.animator.GetBoneTransform(HumanBodyBones.RightFoot);
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
			this.Init(parteQuePuedeEstimular, transform, VisualSkin);
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0000BDC0 File Offset: 0x00009FC0
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

		// Token: 0x0600031A RID: 794 RVA: 0x0000C060 File Offset: 0x0000A260
		protected virtual TalonPieCollider CrearTalom(Transform pieBaseBone, Transform dedosRoot, float ancho)
		{
			TalonPieCollider talonPieCollider = TalonPieCollider.Crear<TalonPieCollider>(this, pieBaseBone, ancho, dedosRoot, base.transform, BoneCollider.Mode.yAxis);
			this.m_pieColliders.Add(talonPieCollider);
			return talonPieCollider;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x0000C08C File Offset: 0x0000A28C
		protected virtual CapsuleParteCollider CrearDedo(Transform pieBaseBone, float largo, float ancho)
		{
			CapsuleParteCollider capsuleParteCollider = CapsuleParteCollider.Crear<CapsuleParteCollider>(this, pieBaseBone, largo, ancho, base.transform, BoneCollider.Mode.yAxis);
			this.m_pieColliders.Add(capsuleParteCollider);
			return capsuleParteCollider;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0000C0B8 File Offset: 0x0000A2B8
		protected virtual PlantaPieCollider CrearPlanta(Transform pieBase, TalonPieCollider talon, Transform dedoGordo, Transform dedoPequeño, float alto, float ancho)
		{
			PlantaPieCollider plantaPieCollider = PlantaPieCollider.Crear<PlantaPieCollider>(this, pieBase, talon, dedoGordo, dedoPequeño, alto, ancho, base.transform, BoneCollider.Mode.yAxis);
			this.m_pieColliders.Add(plantaPieCollider);
			return plantaPieCollider;
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0000C0EC File Offset: 0x0000A2EC
		protected virtual TobilloCollider CrearTobillo(Transform pieBase, float ancho)
		{
			TobilloCollider tobilloCollider = TobilloCollider.Crear<TobilloCollider>(this, pieBase, ancho, base.transform);
			this.m_pieColliders.Add(tobilloCollider);
			return tobilloCollider;
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0000C118 File Offset: 0x0000A318
		protected virtual PlantaSuperiorPieCollider CrearPlanta(Transform pieBase, Transform dedoGordo, Transform dedoPequeño, float alto, float ancho)
		{
			PlantaSuperiorPieCollider plantaSuperiorPieCollider = PlantaSuperiorPieCollider.Crear<PlantaSuperiorPieCollider>(this, pieBase, dedoGordo, dedoPequeño, alto, ancho, base.transform, BoneCollider.Mode.yAxis);
			this.m_pieColliders.Add(plantaSuperiorPieCollider);
			return plantaSuperiorPieCollider;
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000C148 File Offset: 0x0000A348
		protected virtual PlantaMediaPieCollider CrearMediaPlanta(Transform pieBase, TalonPieCollider talon, Transform dedoGordo, Transform dedoPequeño, float alto, float ancho)
		{
			PlantaMediaPieCollider plantaMediaPieCollider = PlantaMediaPieCollider.Crear<PlantaMediaPieCollider>(this, pieBase, talon, dedoGordo, dedoPequeño, alto, ancho, base.transform, BoneCollider.Mode.yAxis);
			this.m_pieColliders.Add(plantaMediaPieCollider);
			return plantaMediaPieCollider;
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0000C17C File Offset: 0x0000A37C
		protected virtual PlantaPieDedoGordoToDedoPequeno CrearPlantaDedoToDedo(Transform rootFiengers, Transform dedoGordo, Transform dedoPequeño, float ancho)
		{
			PlantaPieDedoGordoToDedoPequeno plantaPieDedoGordoToDedoPequeno = PlantaPieDedoGordoToDedoPequeno.Crear<PlantaPieDedoGordoToDedoPequeno>(this, rootFiengers, dedoGordo, dedoPequeño, ancho, base.transform);
			this.m_pieColliders.Add(plantaPieDedoGordoToDedoPequeno);
			return plantaPieDedoGordoToDedoPequeno;
		}

		// Token: 0x04000210 RID: 528
		[ReadOnlyUI]
		[SerializeField]
		private Side m_side;

		// Token: 0x04000211 RID: 529
		[SerializeField]
		private FeetBoneMap m_FeetBonesMap;

		// Token: 0x04000212 RID: 530
		public PieMaleHitSkin.Bones bones = new PieMaleHitSkin.Bones();

		// Token: 0x04000213 RID: 531
		public PieMaleHitSkin.Medidas localMedidas = new PieMaleHitSkin.Medidas();

		// Token: 0x04000214 RID: 532
		private List<BoneCollider> m_pieColliders = new List<BoneCollider>();

		// Token: 0x02000078 RID: 120
		[Serializable]
		public class Colliders : NonSkinnedMaleHitSkinBase.BaseColliders
		{
			// Token: 0x04000215 RID: 533
			public TalonPieCollider talon;

			// Token: 0x04000216 RID: 534
			public TobilloCollider tobillo;

			// Token: 0x04000217 RID: 535
			public PlantaPieCollider piePlanta;

			// Token: 0x04000218 RID: 536
			public PlantaSuperiorPieCollider piePlantaSuperior;

			// Token: 0x04000219 RID: 537
			public PlantaMediaPieCollider piePlantaMedia;

			// Token: 0x0400021A RID: 538
			public PlantaPieDedoGordoToDedoPequeno plantaDedoToDedo;

			// Token: 0x0400021B RID: 539
			public CapsuleParteCollider thumb;

			// Token: 0x0400021C RID: 540
			public CapsuleParteCollider index;

			// Token: 0x0400021D RID: 541
			public CapsuleParteCollider middle;

			// Token: 0x0400021E RID: 542
			public CapsuleParteCollider ring;

			// Token: 0x0400021F RID: 543
			public CapsuleParteCollider little;
		}

		// Token: 0x02000079 RID: 121
		[Serializable]
		public class Bones
		{
			// Token: 0x04000220 RID: 544
			public Transform feet;

			// Token: 0x04000221 RID: 545
			public Transform fingersRoot;

			// Token: 0x04000222 RID: 546
			public Transform thumbProximal;

			// Token: 0x04000223 RID: 547
			public Transform indexProximal;

			// Token: 0x04000224 RID: 548
			public Transform middleProximal;

			// Token: 0x04000225 RID: 549
			public Transform ringProximal;

			// Token: 0x04000226 RID: 550
			public Transform littleProximal;
		}

		// Token: 0x0200007A RID: 122
		[Serializable]
		public class Medidas
		{
			// Token: 0x04000227 RID: 551
			public float feetAlto = 0.03f;

			// Token: 0x04000228 RID: 552
			public float feetAncho = 0.07f;

			// Token: 0x04000229 RID: 553
			public float tobilloAncho = 0.07f;

			// Token: 0x0400022A RID: 554
			public float thumbAncho = 0.028f;

			// Token: 0x0400022B RID: 555
			public float thumbLargo = 0.045f;

			// Token: 0x0400022C RID: 556
			public float indexAncho = 0.016f;

			// Token: 0x0400022D RID: 557
			public float indexLargo = 0.04f;

			// Token: 0x0400022E RID: 558
			public float middleAncho = 0.015f;

			// Token: 0x0400022F RID: 559
			public float middleLargo = 0.03f;

			// Token: 0x04000230 RID: 560
			public float ringAncho = 0.014f;

			// Token: 0x04000231 RID: 561
			public float ringLargo = 0.028f;

			// Token: 0x04000232 RID: 562
			public float littleAncho = 0.014f;

			// Token: 0x04000233 RID: 563
			public float littleLargo = 0.024f;
		}
	}
}
