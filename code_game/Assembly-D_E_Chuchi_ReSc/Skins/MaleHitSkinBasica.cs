using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200003B RID: 59
	public abstract class MaleHitSkinBasica : Skin, ISideable, IBoneReferenceable, IHitSkin
	{
		// Token: 0x060001DB RID: 475 RVA: 0x00007A08 File Offset: 0x00005C08
		public static MaleHitSkinBasica ObtenerSkinDeCollider(Collider arg1)
		{
			ColliderDeEmulatedMaleHitSkin colliderDeEmulatedMaleHitSkin;
			if (arg1.TryGetComponent<ColliderDeEmulatedMaleHitSkin>(out colliderDeEmulatedMaleHitSkin))
			{
				return colliderDeEmulatedMaleHitSkin.owner;
			}
			Rigidbody attachedRigidbody = arg1.attachedRigidbody;
			MaleHitSkinBasica maleHitSkinBasica;
			if (attachedRigidbody != null && attachedRigidbody.TryGetComponent<MaleHitSkinBasica>(out maleHitSkinBasica))
			{
				return maleHitSkinBasica;
			}
			return null;
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00007A43 File Offset: 0x00005C43
		Transform IBoneReferenceable.bone
		{
			get
			{
				return this.boneTarget;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00005F51 File Offset: 0x00004151
		public override bool skinMeshIsHidden
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060001DE RID: 478 RVA: 0x00007A4B File Offset: 0x00005C4B
		public Transform boneTarget
		{
			get
			{
				return this.m_boneTarget;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00007A53 File Offset: 0x00005C53
		public Skin visualSkin
		{
			get
			{
				return this.m_visualSkin;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x00007A5B File Offset: 0x00005C5B
		public bool isHitSkinInit
		{
			get
			{
				return this.m_IsHitSkinInit;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060001E1 RID: 481
		public abstract Rigidbody rigid { get; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060001E2 RID: 482
		public abstract Side side { get; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060001E3 RID: 483
		public abstract ParteQuePuedeEstimular parteQuePuedeEstimular { get; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060001E4 RID: 484
		public abstract List<Collider> skinColliders { get; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060001E5 RID: 485
		public abstract HashSet<Collider> skinCollidersSet { get; }

		// Token: 0x060001E6 RID: 486 RVA: 0x00005F64 File Offset: 0x00004164
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00007A64 File Offset: 0x00005C64
		protected void InitBasica(Transform boneTarget, Skin VisualSkin)
		{
			if (boneTarget == null)
			{
				throw new ArgumentNullException("boneTarget", "boneTarget null reference.");
			}
			this.m_IsHitSkinInit = true;
			this.m_boneTarget = boneTarget;
			this.m_visualSkin = VisualSkin;
			base.Initialize();
			this.FollowTargetBone();
			base.ManualStart();
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00007AB1 File Offset: 0x00005CB1
		public void FollowTargetBone()
		{
			base.transform.position = this.m_boneTarget.position;
			base.transform.rotation = this.m_boneTarget.rotation;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00007ADF File Offset: 0x00005CDF
		public void IgnorarCollisiones(Collider other, bool ignore)
		{
			ExtendedMonoBehaviour.IgnorarCollisiones(other, this.skinColliders, ignore);
		}

		// Token: 0x060001EA RID: 490
		public abstract bool PointIsInside(Vector3 worldPoint);

		// Token: 0x040000F6 RID: 246
		private bool m_IsHitSkinInit;

		// Token: 0x040000F7 RID: 247
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_boneTarget;

		// Token: 0x040000F8 RID: 248
		[SerializeField]
		[ReadOnlyUI]
		private Skin m_visualSkin;
	}
}
