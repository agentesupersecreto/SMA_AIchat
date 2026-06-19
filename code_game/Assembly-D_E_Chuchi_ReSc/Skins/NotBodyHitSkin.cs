using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000044 RID: 68
	public abstract class NotBodyHitSkin : HitSkinBasica
	{
		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000212 RID: 530 RVA: 0x00007E94 File Offset: 0x00006094
		public sealed override int updateEvent1Index
		{
			get
			{
				if (!this.autoFollowTarget)
				{
					return -1;
				}
				return 66;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000213 RID: 531 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool updateTouchedBy
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000214 RID: 532 RVA: 0x00004252 File Offset: 0x00002452
		public override Side side
		{
			get
			{
				return Side.none;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000215 RID: 533 RVA: 0x00007EA4 File Offset: 0x000060A4
		public override BodyPartEnum? requiereBodyPartEnumCalculo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000216 RID: 534 RVA: 0x00006060 File Offset: 0x00004260
		public override EstimuledBy touchedBy
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00004252 File Offset: 0x00002452
		public override bool IsTouchedBy(ICharacter character, List<EstimuloTactil> toques)
		{
			return false;
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00007EBA File Offset: 0x000060BA
		public override bool TryCalcularPartesImpactadasDeCollision(Collision collision, Collider collider, out RaycastHit hit, IList<BodyPartEnum> result, Vector3? impactDirection = null, Vector3? impactPoint = null, bool debugDraw = false)
		{
			return this.CalcularPuntoYNormal(collision, collider, out hit, impactDirection, impactPoint, debugDraw);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00007ED0 File Offset: 0x000060D0
		public sealed override bool TryCalcularPartesImpactadasDeCollision(Vector3 collisionPunto, Vector3 collisionNormal, Collider ownCollider, out RaycastHit hit, IList<BodyPartEnum> result, bool debugDraw = false)
		{
			return this.CalcularPuntoYNormal(collisionPunto, collisionNormal, ownCollider, out hit, debugDraw);
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00007EE4 File Offset: 0x000060E4
		protected bool CalcularPuntoYNormal(Collision collision, Collider collider, out RaycastHit hit, Vector3? impactDirection = null, Vector3? impactPoint = null, bool debugDraw = false)
		{
			return collision.TryCastCollision(true, true, out hit, collider, impactDirection, impactPoint, debugDraw);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00007EF8 File Offset: 0x000060F8
		protected bool CalcularPuntoYNormal(Vector3 collisionPunto, Vector3 collisionNormal, Collider ownCollider, out RaycastHit hit, bool debugDraw = false)
		{
			return ExtendedMonoBehaviour.TryGetHitFormCollider(ownCollider, collisionPunto, collisionNormal, true, out hit, ownCollider.contactOffset, 1f, debugDraw, 1f);
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600021C RID: 540 RVA: 0x00007F22 File Offset: 0x00006122
		public PhysicMaterial ownPhysicMaterial
		{
			get
			{
				return this.m_OwnPhysicMaterial;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600021D RID: 541 RVA: 0x00007F2A File Offset: 0x0000612A
		public override Rigidbody rigid
		{
			get
			{
				return this.m_rigid;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600021E RID: 542 RVA: 0x00005F51 File Offset: 0x00004151
		protected virtual bool isKinematic
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x0600021F RID: 543 RVA: 0x00005F51 File Offset: 0x00004151
		protected virtual bool autoFollowTarget
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00007F32 File Offset: 0x00006132
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_rigid = this.GetComponentNotNull<Rigidbody>();
			this.m_rigid.isKinematic = this.isKinematic;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00007F57 File Offset: 0x00006157
		public virtual void Init(PhysicMaterial physicMaterial, Transform boneTarget, Skin VisualSkin)
		{
			this.m_OwnPhysicMaterial = Object.Instantiate<PhysicMaterial>(physicMaterial);
			this.m_defaultStaticFricc = this.m_OwnPhysicMaterial.staticFriction;
			this.m_defaultDynamicFricc = this.m_OwnPhysicMaterial.dynamicFriction;
			base.InitBasica(boneTarget, VisualSkin);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00007F90 File Offset: 0x00006190
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (!base.isHitSkinInit)
			{
				Debug.LogWarning("Skin: " + base.GetType().Name + " no fue iniciada.", base.gameObject);
				throw new InvalidOperationException();
			}
			foreach (Collider collider in this.skinColliders)
			{
				collider.sharedMaterial = this.ownPhysicMaterial;
			}
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00008020 File Offset: 0x00006220
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_OwnPhysicMaterial != null)
			{
				Object.Destroy(this.m_OwnPhysicMaterial);
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00008042 File Offset: 0x00006242
		public sealed override void OnUpdateEvent1()
		{
			if (this.autoFollowTarget)
			{
				base.FollowTargetBone();
			}
		}

		// Token: 0x04000109 RID: 265
		private float m_defaultStaticFricc;

		// Token: 0x0400010A RID: 266
		private float m_defaultDynamicFricc;

		// Token: 0x0400010B RID: 267
		private PhysicMaterial m_OwnPhysicMaterial;

		// Token: 0x0400010C RID: 268
		[SerializeField]
		[ReadOnlyUI]
		private Rigidbody m_rigid;
	}
}
