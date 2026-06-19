using System;
using System.Collections.Generic;
using Assets.TValle.MeshCalcules.BeachGirl.Runtime.ColliderBaker;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200006D RID: 109
	public class ManualDynamicMaleHitSkin : MaleHitSkin, IColliderBakerUserListiner
	{
		// Token: 0x060002DF RID: 735 RVA: 0x0000AD0F File Offset: 0x00008F0F
		public override bool PointIsInside(Vector3 worldPoint)
		{
			return this.m_dynamicCollider.IsPointInsideCollider(worldPoint, 0.0001f);
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x0000AD22 File Offset: 0x00008F22
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

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x0000AD57 File Offset: 0x00008F57
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

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x0000AD85 File Offset: 0x00008F85
		public MeshCollider dynamicCollider
		{
			get
			{
				return this.m_dynamicCollider;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x0000AD8D File Offset: 0x00008F8D
		public override Side side
		{
			get
			{
				return this.m_side;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x0000AD95 File Offset: 0x00008F95
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x0000AD9D File Offset: 0x00008F9D
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

		// Token: 0x060002E6 RID: 742 RVA: 0x0000ADA8 File Offset: 0x00008FA8
		public void Init(ParteQuePuedeEstimular parte, Transform boneTarget, Skin VisualSkin, Side side, ManualDynamicHitSkin.BakerType bakerType)
		{
			this.m_side = side;
			this.m_dynamicCollider = this.GetComponentNotNull<MeshCollider>();
			this.m_dynamicMesh = Object.Instantiate<Mesh>(base.skinnedMeshRenderer.sharedMesh);
			this.m_dynamicMesh.name = base.skinnedMeshRenderer.sharedMesh.name + "_Dynamic";
			this.m_dynamicMesh.MarkDynamic();
			this.m_dynamicMeshID = this.m_dynamicMesh.GetInstanceID();
			base.Init(parte, boneTarget, VisualSkin);
			switch (bakerType)
			{
			case ManualDynamicHitSkin.BakerType.Light:
				base.gameObject.AddComponent<ColliderBakerLightUser>();
				return;
			case ManualDynamicHitSkin.BakerType.Heavy:
				base.gameObject.AddComponent<ColliderBakerHeavyUser>();
				return;
			case ManualDynamicHitSkin.BakerType.AltaPresicion:
				base.gameObject.AddComponent<ColliderBakerAltaPresicionUser>();
				return;
			default:
				throw new ArgumentOutOfRangeException(bakerType.ToString());
			}
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void Scheduling()
		{
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0000AE78 File Offset: 0x00009078
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

		// Token: 0x060002E9 RID: 745 RVA: 0x0000AEF8 File Offset: 0x000090F8
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

		// Token: 0x060002EA RID: 746 RVA: 0x0000AF58 File Offset: 0x00009158
		public void FixCollider()
		{
			this.dynamicCollider.enabled = false;
			base.Invoke("disable", 0.1f);
			base.Invoke("reStart", 0.2f);
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000AC72 File Offset: 0x00008E72
		private void disable()
		{
			base.gameObject.SetActive(false);
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000AF86 File Offset: 0x00009186
		private void reStart()
		{
			this.m_failed = false;
			this.dynamicCollider.enabled = true;
			base.gameObject.SetActive(true);
			base.owner.ReIgnoreSkinSelfCollisions();
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000AFB2 File Offset: 0x000091B2
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (!quitting)
			{
				Object.DestroyImmediate(this.m_dynamicMesh);
			}
		}

		// Token: 0x040001DA RID: 474
		private List<Collider> m_collidersDeVirtalSkin;

		// Token: 0x040001DB RID: 475
		private HashSet<Collider> m_collidersDeVirtalSkinSet;

		// Token: 0x040001DC RID: 476
		private Side m_side;

		// Token: 0x040001DD RID: 477
		protected MeshCollider m_dynamicCollider;

		// Token: 0x040001DE RID: 478
		protected Mesh m_dynamicMesh;

		// Token: 0x040001DF RID: 479
		protected int m_dynamicMeshID;

		// Token: 0x040001E0 RID: 480
		public bool reportarColliderCookingAlProfiler;

		// Token: 0x040001E1 RID: 481
		private bool m_failed;

		// Token: 0x040001E2 RID: 482
		[SerializeField]
		protected bool m_flagCanBake;
	}
}
