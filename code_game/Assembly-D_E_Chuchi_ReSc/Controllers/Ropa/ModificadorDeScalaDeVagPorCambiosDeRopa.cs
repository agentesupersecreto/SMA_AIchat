using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Bones.V2;
using Assets._ReusableScripts.Bones.V2.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Ropa
{
	// Token: 0x0200024D RID: 589
	public sealed class ModificadorDeScalaDeVagPorCambiosDeRopa : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000D28 RID: 3368 RVA: 0x0003C68C File Offset: 0x0003A88C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			Transform boneTransform = this.GetRoot().bodyAnimator.GetBoneTransform(Singleton<MapasDeHuesos>.instance.mapas.vagLabiaBonesMap.vagLabiaRoot);
			if (boneTransform == null)
			{
				throw new ArgumentNullException("vagLabiaRootBone", "vagLabiaRootBone null reference.");
			}
			this.m_ArmatureSkins = this.GetComponentEnRoot(false);
			if (this.m_ArmatureSkins == null)
			{
				throw new ArgumentNullException("m_ArmatureSkins", "m_ArmatureSkins null reference.");
			}
			this.m_bone = boneTransform.GetComponentNotNull<BaseBone, BoneHijo>();
			this.m_bone.controlaScalaLocal = true;
			this.m_ArmatureSkins.skinAdded += this.M_ArmatureSkins_skinAdded;
			this.m_ArmatureSkins.skinShowed += this.M_ArmatureSkins_skinAdded;
			this.m_ArmatureSkins.skinRemoved += this.M_ArmatureSkins_skinRemoved;
			this.m_ArmatureSkins.skinHidden += this.M_ArmatureSkins_skinRemoved;
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x0003C77C File Offset: 0x0003A97C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_ArmatureSkins)
			{
				this.m_ArmatureSkins.skinAdded -= this.M_ArmatureSkins_skinAdded;
				this.m_ArmatureSkins.skinShowed -= this.M_ArmatureSkins_skinAdded;
				this.m_ArmatureSkins.skinRemoved -= this.M_ArmatureSkins_skinRemoved;
				this.m_ArmatureSkins.skinHidden -= this.M_ArmatureSkins_skinRemoved;
			}
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x0003C7FC File Offset: 0x0003A9FC
		private void M_ArmatureSkins_skinAdded(ArmatureSkins arg1, Skin arg2)
		{
			PiezaDeRopaBase piezaDeRopaBase = arg2 as PiezaDeRopaBase;
			if (piezaDeRopaBase == null)
			{
				return;
			}
			float num = Mathf.Lerp(1f, this.maxEstrechuraVertical, piezaDeRopaBase.dataDeRopa.vagConfig.estrechuraVertical);
			float num2 = Mathf.Lerp(1f, this.maxEstrechuraHorizontal, piezaDeRopaBase.dataDeRopa.vagConfig.estrechuraHorizontal);
			ModificadorDeFloat modificadorDeFloat = this.m_bone.modificableDeScalaLocal.x.modificable.ObtenerModificadorNotNull(arg2);
			ModificadorDeFloatBase modificadorDeFloatBase = this.m_bone.modificableDeScalaLocal.z.modificable.ObtenerModificadorNotNull(arg2);
			modificadorDeFloat.valor.valor = num2;
			modificadorDeFloatBase.valor.valor = num;
		}

		// Token: 0x06000D2B RID: 3371 RVA: 0x0003C8AC File Offset: 0x0003AAAC
		private void M_ArmatureSkins_skinRemoved(ArmatureSkins arg1, Skin arg2)
		{
			if (arg2 as PiezaDeRopaBase == null)
			{
				return;
			}
			this.m_bone.modificableDeScalaLocal.x.modificable.RemoverModificador(arg2);
			this.m_bone.modificableDeScalaLocal.z.modificable.RemoverModificador(arg2);
		}

		// Token: 0x04000B09 RID: 2825
		public float maxEstrechuraHorizontal = 0.85f;

		// Token: 0x04000B0A RID: 2826
		public float maxEstrechuraVertical = 0.95f;

		// Token: 0x04000B0B RID: 2827
		private BaseBone m_bone;

		// Token: 0x04000B0C RID: 2828
		private ArmatureSkins m_ArmatureSkins;
	}
}
