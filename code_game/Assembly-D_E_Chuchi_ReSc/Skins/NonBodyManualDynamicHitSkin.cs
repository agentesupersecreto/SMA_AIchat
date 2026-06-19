using System;
using System.Collections.Generic;
using Assets.TValle.MeshCalcules.BeachGirl.Runtime.ColliderBaker;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000072 RID: 114
	public class NonBodyManualDynamicHitSkin : NotBodyHitSkin, IColliderBakerUserListiner
	{
		// Token: 0x060002F8 RID: 760 RVA: 0x0000B00C File Offset: 0x0000920C
		public override bool PointIsInside(Vector3 worldPoint)
		{
			return this.m_dynamicCollider.IsPointInsideCollider(worldPoint, 0.0001f);
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x0000B01F File Offset: 0x0000921F
		public sealed override List<Collider> skinColliders
		{
			get
			{
				if (this.m_collidersDeVirtalSkin == null)
				{
					this.m_collidersDeVirtalSkin = new List<Collider>();
				}
				if (this.m_collidersDeVirtalSkin.Count == 0)
				{
					base.GetComponentsInChildren<Collider>(true, this.m_collidersDeVirtalSkin);
				}
				return this.m_collidersDeVirtalSkin;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060002FA RID: 762 RVA: 0x0000B054 File Offset: 0x00009254
		public sealed override HashSet<Collider> skinCollidersSet
		{
			get
			{
				if (this.m_collidersDeVirtalSkinSet == null || this.m_collidersDeVirtalSkinSet.Count == 0)
				{
					this.m_collidersDeVirtalSkinSet = new HashSet<Collider>(this.skinColliders);
				}
				return this.m_collidersDeVirtalSkinSet;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060002FB RID: 763 RVA: 0x0000B082 File Offset: 0x00009282
		public MeshCollider dynamicCollider
		{
			get
			{
				return this.m_dynamicCollider;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060002FC RID: 764 RVA: 0x0000B08A File Offset: 0x0000928A
		// (set) Token: 0x060002FD RID: 765 RVA: 0x0000B092 File Offset: 0x00009292
		public bool flagCanBake
		{
			get
			{
				return this.m_flagCanBake;
			}
			set
			{
				this.m_flagCanBake = value;
			}
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0000B09C File Offset: 0x0000929C
		public void Init(PhysicMaterial physicMaterial, Transform boneTarget, Skin VisualSkin, ManualDynamicHitSkin.BakerType bakerType)
		{
			this.m_dynamicCollider = this.GetComponentNotNull<MeshCollider>();
			this.m_dynamicMesh = Object.Instantiate<Mesh>(base.skinnedMeshRenderer.sharedMesh);
			this.m_dynamicMesh.name = base.skinnedMeshRenderer.sharedMesh.name + "_Dynamic";
			this.m_dynamicMesh.MarkDynamic();
			this.m_dynamicMeshID = this.m_dynamicMesh.GetInstanceID();
			base.Init(physicMaterial, boneTarget, VisualSkin);
			switch (bakerType)
			{
			case ManualDynamicHitSkin.BakerType.Light:
				base.gameObject.AddComponent<ColliderBakerLightUser>();
				break;
			case ManualDynamicHitSkin.BakerType.Heavy:
				base.gameObject.AddComponent<ColliderBakerHeavyUser>();
				break;
			case ManualDynamicHitSkin.BakerType.AltaPresicion:
				base.gameObject.AddComponent<ColliderBakerAltaPresicionUser>();
				break;
			default:
				throw new ArgumentOutOfRangeException(bakerType.ToString());
			}
			base.owner.IgnoreSkinCollisionsVersus(this.dynamicCollider, true);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0000B17C File Offset: 0x0000937C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared && base.isInitiated)
			{
				if (!this.m_dynamicCollider.enabled)
				{
					this.m_dynamicCollider.enabled = true;
				}
				base.owner.IgnoreSkinCollisionsVersus(this.dynamicCollider, true);
			}
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void Scheduling()
		{
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0000B1CC File Offset: 0x000093CC
		void IColliderBakerUserListiner.Scheduling(bool firstSchedulingForUser, out int meshID, out bool convex, out bool doBake)
		{
			this.Scheduling();
			bool flag = base.isHitSkinInit && !this.m_failed && this.m_dynamicCollider.enabled && (firstSchedulingForUser || this.m_flagCanBake);
			this.m_flagCanBake = false;
			doBake = flag;
			meshID = this.m_dynamicMeshID;
			convex = base.isHitSkinInit && this.m_dynamicCollider.convex;
			if (flag)
			{
				base.skinnedMeshRenderer.BakeMesh(this.m_dynamicMesh);
			}
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000B24C File Offset: 0x0000944C
		void IColliderBakerUserListiner.Completed(bool didBake)
		{
			if (didBake)
			{
				this.m_dynamicCollider.sharedMesh = this.m_dynamicMesh;
				if (this.m_dynamicCollider.bounds.extents == Vector3.zero && this.m_dynamicCollider.attachedRigidbody == null)
				{
					this.m_failed = true;
					this.FixCollider();
				}
			}
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000B2AC File Offset: 0x000094AC
		public void FixCollider()
		{
			this.dynamicCollider.enabled = false;
			base.Invoke("disable", 0.1f);
			base.Invoke("reStart", 0.2f);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0000AC72 File Offset: 0x00008E72
		private void disable()
		{
			base.gameObject.SetActive(false);
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0000B2DA File Offset: 0x000094DA
		private void reStart()
		{
			this.m_failed = false;
			this.dynamicCollider.enabled = true;
			base.gameObject.SetActive(true);
			base.owner.IgnoreSkinCollisionsVersus(this.dynamicCollider, true);
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0000B30D File Offset: 0x0000950D
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (!quitting)
			{
				Object.Destroy(this.m_dynamicMesh);
			}
		}

		// Token: 0x040001E4 RID: 484
		private List<Collider> m_collidersDeVirtalSkin;

		// Token: 0x040001E5 RID: 485
		private HashSet<Collider> m_collidersDeVirtalSkinSet;

		// Token: 0x040001E6 RID: 486
		protected MeshCollider m_dynamicCollider;

		// Token: 0x040001E7 RID: 487
		protected Mesh m_dynamicMesh;

		// Token: 0x040001E8 RID: 488
		protected int m_dynamicMeshID;

		// Token: 0x040001E9 RID: 489
		public bool reportarColliderCookingAlProfiler;

		// Token: 0x040001EA RID: 490
		private bool m_failed;

		// Token: 0x040001EB RID: 491
		[SerializeField]
		protected bool m_flagCanBake;
	}
}
