using System;
using Assets.Base.BeachGirl.Mapas;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Males;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Males
{
	// Token: 0x02000047 RID: 71
	[RequireComponent(typeof(ICharacter))]
	public class CharacterPenisAdder : BaseCharacterPenisAdder<Penis>
	{
		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00002CA7 File Offset: 0x00000EA7
		protected sealed override IPenisBoneMap penisBoneMap
		{
			get
			{
				return Singleton<MapasDeHuesos>.instance.mapas.penisBoneMap;
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00002CB8 File Offset: 0x00000EB8
		protected sealed override PenisPoint.Configuracion GetConfig()
		{
			return this.puntosConfig;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00002CC0 File Offset: 0x00000EC0
		protected sealed override PenisPointColliderSizeGetterHandler SizeGetter()
		{
			return null;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00002CC3 File Offset: 0x00000EC3
		protected sealed override Transform GetPushingBone()
		{
			return this.m_Character.hips;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00002CD0 File Offset: 0x00000ED0
		protected sealed override Transform GetChainHolder()
		{
			return this.m_Character.bodyAnimator.transform.CreateChild(base.name + "_PenisPhysics");
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00002CF8 File Offset: 0x00000EF8
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

		// Token: 0x0600013E RID: 318 RVA: 0x00002D40 File Offset: 0x00000F40
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

		// Token: 0x0600013F RID: 319 RVA: 0x00002DCF File Offset: 0x00000FCF
		protected override void AfterReferencesSetted()
		{
			base.AfterReferencesSetted();
			this.m_PenisLinearChain.SetInitialConfig(true, 9, Vector3.zero);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00002DEA File Offset: 0x00000FEA
		protected override Transform GetConnstraintsRootBone()
		{
			return null;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00002DED File Offset: 0x00000FED
		protected override void BeforeStartPenis()
		{
			base.BeforeStartPenis();
			this.m_PenisLinearChain.addingFollowers += this.M_PenisLinearChain_addingFollowers;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00002E0C File Offset: 0x0000100C
		private void M_PenisLinearChain_addingFollowers(TrasnformCopier follower, int index, ref Vector3 poitionOffset, ref Quaternion rotationOffset, ref bool followScale, ref bool usarScaleMod, PenisLinearChain sender)
		{
			usarScaleMod = true;
			followScale = false;
		}

		// Token: 0x040000C6 RID: 198
		[SerializeField]
		private PenisPoint.Configuracion puntosConfig = new PenisPoint.PenisConfiguracion();
	}
}
