using System;
using Assets.Base.BeachGirl.Mapas;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Penes;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Males
{
	// Token: 0x0200009E RID: 158
	[RequireComponent(typeof(ICharacter))]
	public class CharacterToyAdder : BaseCharacterPenisAdder<Toy>
	{
		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x0000FAC3 File Offset: 0x0000DCC3
		public int cantidadDePuntos
		{
			get
			{
				return this.m_cantidadDePuntos;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x0000FACB File Offset: 0x0000DCCB
		protected override IPenisBoneMap penisBoneMap
		{
			get
			{
				return Singleton<MapasDeHuesos>.instance.mapas.toyBoneMap;
			}
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x0000FADC File Offset: 0x0000DCDC
		protected sealed override PenisPoint.Configuracion GetConfig()
		{
			return this.puntosConfig;
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0000FAE4 File Offset: 0x0000DCE4
		protected sealed override PenisPointColliderSizeGetterHandler SizeGetter()
		{
			return null;
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0000FAE7 File Offset: 0x0000DCE7
		protected sealed override Transform GetPushingBone()
		{
			return this.m_Character.hips;
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0000FAF4 File Offset: 0x0000DCF4
		protected sealed override Transform GetChainHolder()
		{
			return this.m_Character.bodyAnimator.transform.CreateChild(base.name + "_PenisPhysics");
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0000FB1C File Offset: 0x0000DD1C
		protected override Transform GetSkeletonRoot()
		{
			if (this.m_Character.bodyAnimator.avatar != null)
			{
				Transform boneTransform = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.Hips);
				if (boneTransform != null)
				{
					return boneTransform;
				}
			}
			return base.transform;
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0000FB64 File Offset: 0x0000DD64
		protected sealed override void Awaking(Transform chainHolder)
		{
			Transform transform = this.m_Character.animatorRootMotionTransform.FindDeepChild(this.penisBoneMap.penisRoot, true);
			if (transform == null)
			{
				transform = this.m_Character.animatorRootMotionTransform.FindDeepChildEndsWith(this.penisBoneMap.penisRoot, true);
			}
			if (this.m_Character.bodyAnimator.avatar != null)
			{
				Transform boneTransform = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.Hips);
				if (boneTransform != null)
				{
					transform.parent.parent = boneTransform;
				}
			}
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x0000FBF3 File Offset: 0x0000DDF3
		protected override void AfterReferencesSetted()
		{
			base.AfterReferencesSetted();
			this.m_PenisLinearChain.OverrideMaxBoneZAxisRotation(this.m_maxBoneZAxisRotation);
			this.m_PenisLinearChain.SetInitialConfig(true, this.m_cantidadDePuntos - 1, Vector3.zero);
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x0000FC25 File Offset: 0x0000DE25
		protected override Transform GetConnstraintsRootBone()
		{
			return null;
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x0000FC28 File Offset: 0x0000DE28
		protected override void BeforeStartPenis()
		{
			base.BeforeStartPenis();
			this.m_Penis.timeTryingToOpenHoleModificador = this.m_timeTryingToOpenHoleModificador;
			this.m_PenisLinearChain.correctChainScaleOnScaleChange = false;
			this.m_PenisLinearChain.addingFollowers += this.M_PenisLinearChain_addingFollowers;
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0000FC64 File Offset: 0x0000DE64
		public override Func<float> PelvisMassGetter()
		{
			CharacterToyAdder.<>c__DisplayClass19_0 CS$<>8__locals1 = new CharacterToyAdder.<>c__DisplayClass19_0();
			CS$<>8__locals1.<>4__this = this;
			CharacterToyAdder.<>c__DisplayClass19_0 CS$<>8__locals2 = CS$<>8__locals1;
			IPertenecibleDeCharacter pertenecibleDeCharacter = this.m_Character as IPertenecibleDeCharacter;
			CS$<>8__locals2.charCached = ((pertenecibleDeCharacter != null) ? pertenecibleDeCharacter.inmediateOwner : null) as IPuppetCharacter;
			CS$<>8__locals1.cachedMass = this.m_pelvisMass;
			if (CS$<>8__locals1.charCached == null)
			{
				return () => CS$<>8__locals1.cachedMass;
			}
			return () => CS$<>8__locals1.charCached.TryGetMuscleMass(CS$<>8__locals1.<>4__this.m_toyIsGrabedBy, CS$<>8__locals1.cachedMass);
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0000FCCD File Offset: 0x0000DECD
		private void M_PenisLinearChain_addingFollowers(TrasnformCopier follower, int index, ref Vector3 poitionOffset, ref Quaternion rotationOffset, ref bool followScale, ref bool usarScaleMod, PenisLinearChain sender)
		{
			usarScaleMod = true;
			followScale = false;
		}

		// Token: 0x040002D9 RID: 729
		[Header("Toy Adding Config")]
		[SerializeField]
		private HumanBodyBones m_toyIsGrabedBy;

		// Token: 0x040002DA RID: 730
		[SerializeField]
		[Tooltip("solo si m_toyIsGrabedBy no existe")]
		private float m_pelvisMass = 0.3f;

		// Token: 0x040002DB RID: 731
		[SerializeField]
		private int m_cantidadDePuntos = -1;

		// Token: 0x040002DC RID: 732
		[SerializeField]
		private float m_maxBoneZAxisRotation = 25f;

		// Token: 0x040002DD RID: 733
		[SerializeField]
		private float m_timeTryingToOpenHoleModificador = 1f;

		// Token: 0x040002DE RID: 734
		[SerializeField]
		private PenisPoint.Configuracion puntosConfig = new PenisPoint.PenisConfiguracion();
	}
}
