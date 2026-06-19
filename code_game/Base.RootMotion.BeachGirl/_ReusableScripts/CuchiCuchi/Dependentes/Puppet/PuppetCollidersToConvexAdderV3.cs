using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x02000105 RID: 261
	public sealed class PuppetCollidersToConvexAdderV3 : BehaviourAdder
	{
		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000A2B RID: 2603 RVA: 0x0002D9B2 File Offset: 0x0002BBB2
		public sealed override object addedResult
		{
			get
			{
				return this.m_added;
			}
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000A2C RID: 2604 RVA: 0x0002D9BA File Offset: 0x0002BBBA
		protected override BehaviourAdder.AddType addType
		{
			get
			{
				return BehaviourAdder.AddType.custom;
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000A2D RID: 2605 RVA: 0x0002D9BD File Offset: 0x0002BBBD
		public override bool removerDespuesDeAñadir
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000A2E RID: 2606 RVA: 0x0002D9C0 File Offset: 0x0002BBC0
		public List<Collider> toConvexColliders
		{
			get
			{
				return this.m_ToConvexColliders;
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000A2F RID: 2607 RVA: 0x0002D9C8 File Offset: 0x0002BBC8
		public HashSet<Collider> toConvexCollidersSet
		{
			get
			{
				return this.m_ToConvexCollidersSet;
			}
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x0002D9D0 File Offset: 0x0002BBD0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PuppetMaster = this.GetComponentEnRoot(false);
			if (this.m_PuppetMaster == null)
			{
				throw new ArgumentNullException("m_PuppetMaster", "m_PuppetMaster null reference.");
			}
			PuppetMaster puppetMaster = this.m_PuppetMaster;
			puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Combine(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(base.OnAddBehaviour));
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x0002DA38 File Offset: 0x0002BC38
		protected override void AddBehaviour()
		{
			PuppetMaster puppetMaster = this.m_PuppetMaster;
			puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Remove(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(base.OnAddBehaviour));
			this.m_added = new List<PuppetColliderToConvexV2>();
			Transform transform = base.transform.CreateChild("OwnToConvexPuppetColliders");
			foreach (PuppetCollidersToConvexAdderV3.HumanBody humanBody in this.m_humanBonesColliderToAddV2)
			{
				this.AddHumanBone(humanBody.humanBodyBones, transform, humanBody.widthMod);
			}
			transform.ExecDeepChild(delegate(Transform trans)
			{
				trans.gameObject.layer = Singleton<ConfiguracionGeneral>.instance.layers.toSkinConvexCollider;
			}, true);
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x0002DB00 File Offset: 0x0002BD00
		private void AddHumanBone(HumanBodyBones humanBone, Transform root, float widthMod)
		{
			Muscle muscle = this.m_PuppetMaster.GetMuscle(humanBone);
			if (muscle == null)
			{
				return;
			}
			PuppetColliderToConvexV2 puppetColliderToConvexV = root.CreateChild(muscle.name).gameObject.AddComponent<PuppetColliderToConvexV2>();
			puppetColliderToConvexV.alwaysEnabled = true;
			this.m_added.Add(puppetColliderToConvexV);
			puppetColliderToConvexV.Init(Singleton<ConfiguracionGeneral>.instance.layers.toSkinConvexCollider, this.m_PuppetMaster, muscle, this.toCopyFrom, widthMod, 5f, 2f, new float?(0.005f));
			this.m_ToConvexColliders.AddRange(puppetColliderToConvexV.colliders);
			this.m_ToConvexCollidersSet.UnionWith(puppetColliderToConvexV.colliders);
		}

		// Token: 0x04000633 RID: 1587
		private List<PuppetColliderToConvexV2> m_added;

		// Token: 0x04000634 RID: 1588
		[SerializeField]
		private PuppetColliderToConvexV2.ToCopyFrom toCopyFrom;

		// Token: 0x04000635 RID: 1589
		[CoolArrayItem]
		[SerializeField]
		private List<PuppetCollidersToConvexAdderV3.HumanBody> m_humanBonesColliderToAddV2 = new List<PuppetCollidersToConvexAdderV3.HumanBody>();

		// Token: 0x04000636 RID: 1590
		private PuppetMaster m_PuppetMaster;

		// Token: 0x04000637 RID: 1591
		private List<Collider> m_ToConvexColliders = new List<Collider>();

		// Token: 0x04000638 RID: 1592
		private HashSet<Collider> m_ToConvexCollidersSet = new HashSet<Collider>();

		// Token: 0x020001CD RID: 461
		[Serializable]
		public class HumanBody
		{
			// Token: 0x040009E0 RID: 2528
			public float widthMod = 1f;

			// Token: 0x040009E1 RID: 2529
			public HumanBodyBones humanBodyBones;
		}
	}
}
