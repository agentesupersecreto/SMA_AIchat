using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x02000221 RID: 545
	public class BodyCollidersContraCharacter : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000DE2 RID: 3554 RVA: 0x0003DAC2 File Offset: 0x0003BCC2
		public override int updateEvent1Index
		{
			get
			{
				return 53;
			}
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x0003DAC8 File Offset: 0x0003BCC8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			Animator componentInChildren = base.GetComponentInParent<Character>().GetComponentInChildren<Animator>();
			int characterController = Singleton<ConfiguracionGeneral>.instance.layers.characterController;
			BodyCollidersContraCharacter.Instanciar(base.transform, componentInChildren, HumanBodyBones.Hips, this.m_pares, characterController, this.m_hipsRadius);
			BodyCollidersContraCharacter.Instanciar(base.transform, componentInChildren, HumanBodyBones.LeftLowerLeg, this.m_pares, characterController, this.m_rodillasRadius);
			BodyCollidersContraCharacter.Instanciar(base.transform, componentInChildren, HumanBodyBones.RightLowerLeg, this.m_pares, characterController, this.m_rodillasRadius);
			BodyCollidersContraCharacter.Instanciar(base.transform, componentInChildren, HumanBodyBones.Head, this.m_pares, characterController, this.m_headRadius);
			BodyCollidersContraCharacter.Instanciar(base.transform, componentInChildren, HumanBodyBones.Spine, this.m_pares, characterController, this.m_spine1Radius);
			BodyCollidersContraCharacter.Instanciar(base.transform, componentInChildren, HumanBodyBones.Chest, this.m_pares, characterController, this.m_spine2Radius);
			this.SyncColliders();
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x0003DB9C File Offset: 0x0003BD9C
		private static void Instanciar(Transform transform, Animator anim, HumanBodyBones boneEnum, List<BodyCollidersContraCharacter.Par> result, int layer, float radius)
		{
			Transform transform2 = null;
			SphereCollider sphereCollider = null;
			BodyCollidersContraCharacter.Instanciar<SphereCollider>(transform, ref sphereCollider, ref transform2, anim, boneEnum, result, layer);
			sphereCollider.radius = radius;
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x0003DBC4 File Offset: 0x0003BDC4
		private static void Instanciar<TCollider>(Transform transform, ref TCollider collider, ref Transform bone, Animator anim, HumanBodyBones boneEnum, List<BodyCollidersContraCharacter.Par> result, int layer) where TCollider : Collider
		{
			bone = anim.GetBoneTransform(boneEnum);
			collider = transform.CreateChild(boneEnum.ToString()).gameObject.AddComponent<TCollider>();
			collider.gameObject.layer = layer;
			result.Add(new BodyCollidersContraCharacter.Par
			{
				bone = bone,
				collider = collider
			});
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x0003DC38 File Offset: 0x0003BE38
		public void SyncColliders()
		{
			for (int i = 0; i < this.m_pares.Count; i++)
			{
				this.m_pares[i].Sync();
			}
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x0003DC6C File Offset: 0x0003BE6C
		public override void OnUpdateEvent1()
		{
			base.OnUpdateEvent1();
			this.SyncColliders();
		}

		// Token: 0x04000974 RID: 2420
		[SerializeField]
		private float m_headRadius = 0.075f;

		// Token: 0x04000975 RID: 2421
		[SerializeField]
		private float m_hipsRadius = 0.1f;

		// Token: 0x04000976 RID: 2422
		[SerializeField]
		private float m_rodillasRadius = 0.055f;

		// Token: 0x04000977 RID: 2423
		[SerializeField]
		private float m_spine1Radius = 0.1f;

		// Token: 0x04000978 RID: 2424
		[SerializeField]
		private float m_spine2Radius = 0.1f;

		// Token: 0x04000979 RID: 2425
		private List<BodyCollidersContraCharacter.Par> m_pares = new List<BodyCollidersContraCharacter.Par>();

		// Token: 0x02000222 RID: 546
		private class Par
		{
			// Token: 0x06000DE9 RID: 3561 RVA: 0x0003DCD4 File Offset: 0x0003BED4
			public void Sync()
			{
				this.collider.transform.SetPositionAndRotation(this.bone.position, this.bone.rotation);
				this.collider.transform.localScale = this.bone.lossyScale;
			}

			// Token: 0x0400097A RID: 2426
			public Transform bone;

			// Token: 0x0400097B RID: 2427
			public Collider collider;
		}
	}
}
