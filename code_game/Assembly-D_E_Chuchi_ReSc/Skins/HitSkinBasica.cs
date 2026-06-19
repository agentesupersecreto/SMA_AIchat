using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000028 RID: 40
	public abstract class HitSkinBasica : Skin, ISideable, IBoneReferenceable, IEstimulablePorToques, IComponentStartable, IHitSkin, IPenetrable
	{
		// Token: 0x06000139 RID: 313 RVA: 0x00005EF8 File Offset: 0x000040F8
		public static HitSkinBasica ObtenerSkinDeCollider(Collider arg1)
		{
			ColliderDeEmulatedHitSkin colliderDeEmulatedHitSkin;
			if (arg1.TryGetComponent<ColliderDeEmulatedHitSkin>(out colliderDeEmulatedHitSkin))
			{
				return colliderDeEmulatedHitSkin.owner;
			}
			Rigidbody attachedRigidbody = arg1.attachedRigidbody;
			HitSkinBasica hitSkinBasica;
			if (attachedRigidbody != null && attachedRigidbody.TryGetComponent<HitSkinBasica>(out hitSkinBasica))
			{
				return hitSkinBasica;
			}
			return null;
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00005F33 File Offset: 0x00004133
		public sealed override int updateEvent6Index
		{
			get
			{
				if (!this.updateTouchedBy)
				{
					return -1;
				}
				return 69;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00005F41 File Offset: 0x00004141
		public Transform boneTarget
		{
			get
			{
				return this.m_boneTarget;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00005F49 File Offset: 0x00004149
		public Skin visualSkin
		{
			get
			{
				return this.m_visualSkin;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00005F51 File Offset: 0x00004151
		public override bool skinMeshIsHidden
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600013E RID: 318
		public abstract Side side { get; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600013F RID: 319
		public abstract List<Collider> skinColliders { get; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000140 RID: 320
		public abstract HashSet<Collider> skinCollidersSet { get; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000141 RID: 321
		public abstract Rigidbody rigid { get; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00005F54 File Offset: 0x00004154
		Transform IBoneReferenceable.bone
		{
			get
			{
				return this.boneTarget;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000143 RID: 323 RVA: 0x00005F5C File Offset: 0x0000415C
		public bool isHitSkinInit
		{
			get
			{
				return this.m_IsHitSkinInit;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000144 RID: 324
		public abstract EstimuledBy touchedBy { get; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000145 RID: 325 RVA: 0x00005F51 File Offset: 0x00004151
		protected virtual bool updateTouchedBy
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000146 RID: 326
		public abstract BodyPartEnum? requiereBodyPartEnumCalculo { get; }

		// Token: 0x06000147 RID: 327
		public abstract bool TryCalcularPartesImpactadasDeCollision(Vector3 collisionPunto, Vector3 collisionNormal, Collider ownCollider, out RaycastHit hit, IList<BodyPartEnum> result, bool debugDraw = false);

		// Token: 0x06000148 RID: 328
		public abstract bool TryCalcularPartesImpactadasDeCollision(Collision collision, Collider collider, out RaycastHit hit, IList<BodyPartEnum> result, Vector3? impactDirection = null, Vector3? impactPoint = null, bool debugDraw = false);

		// Token: 0x06000149 RID: 329 RVA: 0x00005F64 File Offset: 0x00004164
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00005F78 File Offset: 0x00004178
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (this.m_IsHitSkinInit && base.isStared)
			{
				((IFemaleSkins)base.owner).ReIgnoreSkinSelfCollisions();
			}
		}

		// Token: 0x0600014B RID: 331
		public abstract bool IsTouchedBy(ICharacter character, List<EstimuloTactil> toques);

		// Token: 0x0600014C RID: 332 RVA: 0x00005FA0 File Offset: 0x000041A0
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

		// Token: 0x0600014D RID: 333 RVA: 0x00005FED File Offset: 0x000041ED
		public sealed override void OnUpdateEvent6()
		{
			if (this.touchedBy != null)
			{
				this.touchedBy.Update_();
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00006002 File Offset: 0x00004202
		public void FollowTargetBone()
		{
			base.transform.position = this.m_boneTarget.position;
			base.transform.rotation = this.m_boneTarget.rotation;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00006030 File Offset: 0x00004230
		public void IgnorarCollisiones(Collider other, bool ignore)
		{
			ExtendedMonoBehaviour.IgnorarCollisiones(other, this.skinColliders, ignore);
		}

		// Token: 0x06000150 RID: 336
		public abstract bool PointIsInside(Vector3 worldPoint);

		// Token: 0x040000B6 RID: 182
		private bool m_IsHitSkinInit;

		// Token: 0x040000B7 RID: 183
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_boneTarget;

		// Token: 0x040000B8 RID: 184
		[SerializeField]
		[ReadOnlyUI]
		private Skin m_visualSkin;
	}
}
