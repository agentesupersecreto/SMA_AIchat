using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.MeshCalcules.BeachGirl.Runtime.ColliderBaker;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200006B RID: 107
	public class ManualDynamicHitSkin : HitSkin, IColliderBakerUserListiner
	{
		// Token: 0x060002C8 RID: 712 RVA: 0x0000A80C File Offset: 0x00008A0C
		public override bool PointIsInside(Vector3 worldPoint)
		{
			return this.m_dynamicCollider.IsPointInsideCollider(worldPoint, 0.0001f);
		}

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060002C9 RID: 713 RVA: 0x0000A820 File Offset: 0x00008A20
		// (remove) Token: 0x060002CA RID: 714 RVA: 0x0000A858 File Offset: 0x00008A58
		public event Action onMeshColliderUpdated;

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060002CB RID: 715 RVA: 0x0000A88D File Offset: 0x00008A8D
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

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060002CC RID: 716 RVA: 0x0000A8C2 File Offset: 0x00008AC2
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

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060002CD RID: 717 RVA: 0x0000A8F0 File Offset: 0x00008AF0
		public MeshCollider dynamicCollider
		{
			get
			{
				return this.m_dynamicCollider;
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060002CE RID: 718 RVA: 0x0000A8F8 File Offset: 0x00008AF8
		public override Side side
		{
			get
			{
				return this.m_side;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060002CF RID: 719 RVA: 0x0000A900 File Offset: 0x00008B00
		// (set) Token: 0x060002D0 RID: 720 RVA: 0x0000A908 File Offset: 0x00008B08
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

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x0000A914 File Offset: 0x00008B14
		public override BodyPartEnum? requiereBodyPartEnumCalculo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000A92C File Offset: 0x00008B2C
		public void Init(HitPartEnum hitParte, Transform boneTarget, Skin VisualSkin, Side side, ManualDynamicHitSkin.BakerType bakerType)
		{
			this.m_side = side;
			this.m_dynamicCollider = this.GetComponentNotNull<MeshCollider>();
			this.m_dynamicMesh = Object.Instantiate<Mesh>(base.skinnedMeshRenderer.sharedMesh);
			this.m_dynamicMesh.name = base.skinnedMeshRenderer.sharedMesh.name + "_Dynamic";
			this.m_dynamicMesh.MarkDynamic();
			this.m_dynamicMeshID = this.m_dynamicMesh.GetInstanceID();
			base.Init(hitParte, boneTarget, VisualSkin);
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

		// Token: 0x060002D3 RID: 723 RVA: 0x0000A9FC File Offset: 0x00008BFC
		private void SetFlags()
		{
			int bakingOptions = (int)Singleton<ConfiguracionGeneral>.instance.physics.bakingOptions;
			int cookingOptions = (int)this.m_dynamicCollider.cookingOptions;
			if (bakingOptions != cookingOptions)
			{
				this.m_dynamicCollider.cookingOptions = (MeshColliderCookingOptions)bakingOptions;
			}
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void Scheduling()
		{
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000AA38 File Offset: 0x00008C38
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

		// Token: 0x060002D6 RID: 726 RVA: 0x0000AAB8 File Offset: 0x00008CB8
		void IColliderBakerUserListiner.Completed(bool didBake)
		{
			if (didBake)
			{
				this.m_dynamicCollider.sharedMesh = this.m_dynamicMesh;
				this.m_dynamicCollider.hasModifiableContacts = false;
				this.m_dynamicCollider.hasModifiableContacts = true;
				if (this.m_dynamicCollider.bounds.extents == Vector3.zero && this.m_dynamicCollider.attachedRigidbody == null)
				{
					this.m_failed = true;
					this.FixCollider();
					return;
				}
				Action action = this.onMeshColliderUpdated;
				if (action == null)
				{
					return;
				}
				action();
			}
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000AB44 File Offset: 0x00008D44
		[Obsolete("", true)]
		public virtual void UpdateCollider()
		{
			if (!Singleton<ConfiguracionGeneral>.instance.bakeColliders)
			{
				return;
			}
			try
			{
				if (!this.m_failed)
				{
					if (!(base.skinnedMeshRenderer == null))
					{
						if (this.m_dynamicCollider.enabled)
						{
							this.BeforeUpdateCollider();
							bool flag = this.reportarColliderCookingAlProfiler;
							base.skinnedMeshRenderer.BakeMesh(this.m_dynamicMesh);
							bool flag2 = this.reportarColliderCookingAlProfiler;
							bool flag3 = this.reportarColliderCookingAlProfiler;
							this.m_dynamicCollider.sharedMesh = this.m_dynamicMesh;
							if (this.m_dynamicCollider.bounds.extents == Vector3.zero && this.m_dynamicCollider.attachedRigidbody == null)
							{
								this.m_failed = true;
								this.FixCollider();
							}
							bool flag4 = this.reportarColliderCookingAlProfiler;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Exception ahead, " + base.name, base.gameObject);
				throw ex;
			}
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0000AC44 File Offset: 0x00008E44
		public void FixCollider()
		{
			this.dynamicCollider.enabled = false;
			base.Invoke("disable", 0.1f);
			base.Invoke("reStart", 0.2f);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000AC72 File Offset: 0x00008E72
		private void disable()
		{
			base.gameObject.SetActive(false);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000AC80 File Offset: 0x00008E80
		private void reStart()
		{
			this.m_failed = false;
			this.dynamicCollider.enabled = true;
			base.gameObject.SetActive(true);
			base.owner.ReIgnoreSkinSelfCollisions();
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000ACAC File Offset: 0x00008EAC
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (!quitting)
			{
				Object.DestroyImmediate(this.m_dynamicMesh);
			}
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000ACC4 File Offset: 0x00008EC4
		protected sealed override bool CalcularPartesImpactadas(RaycastHit hit, IList<BodyPartEnum> result)
		{
			if (this.requiereBodyPartEnumCalculo != null)
			{
				result.Add(this.requiereBodyPartEnumCalculo.Value);
				return true;
			}
			return Singleton<FemaleHeroBodyPartHitCalculador>.instance.CalcularPartesImpactadas(base.hitParte, this.m_dynamicCollider, hit, result);
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00003B39 File Offset: 0x00001D39
		[Obsolete("", true)]
		protected virtual void BeforeUpdateCollider()
		{
		}

		// Token: 0x040001CD RID: 461
		private List<Collider> m_collidersDeVirtalSkin;

		// Token: 0x040001CE RID: 462
		private HashSet<Collider> m_collidersDeVirtalSkinSet;

		// Token: 0x040001CF RID: 463
		private Side m_side;

		// Token: 0x040001D0 RID: 464
		protected MeshCollider m_dynamicCollider;

		// Token: 0x040001D1 RID: 465
		protected Mesh m_dynamicMesh;

		// Token: 0x040001D2 RID: 466
		protected int m_dynamicMeshID;

		// Token: 0x040001D3 RID: 467
		public bool reportarColliderCookingAlProfiler;

		// Token: 0x040001D4 RID: 468
		private bool m_failed;

		// Token: 0x040001D5 RID: 469
		[SerializeField]
		protected bool m_flagCanBake;

		// Token: 0x0200006C RID: 108
		public enum BakerType
		{
			// Token: 0x040001D7 RID: 471
			Light,
			// Token: 0x040001D8 RID: 472
			Heavy,
			// Token: 0x040001D9 RID: 473
			AltaPresicion
		}
	}
}
