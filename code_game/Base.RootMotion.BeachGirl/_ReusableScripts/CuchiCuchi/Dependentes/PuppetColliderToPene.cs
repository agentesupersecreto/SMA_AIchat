using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes
{
	// Token: 0x02000054 RID: 84
	public class PuppetColliderToPene : AplicableBehaviour
	{
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600038E RID: 910 RVA: 0x00011C44 File Offset: 0x0000FE44
		public Muscle muscle
		{
			get
			{
				return this.m_muscle;
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x0600038F RID: 911 RVA: 0x00011C4C File Offset: 0x0000FE4C
		public HashSet<Collider> collidersSet
		{
			get
			{
				return this.m_CollidersSet;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000390 RID: 912 RVA: 0x00011C54 File Offset: 0x0000FE54
		public IReadOnlyList<Collider> colliders
		{
			get
			{
				return this.m_Colliders;
			}
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00011C5C File Offset: 0x0000FE5C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00011C6C File Offset: 0x0000FE6C
		public void Init(int ownlayer, PuppetMaster puppet, Muscle muscle, PuppetColliderToPene.ToCopyFrom toCopyFrom, float widthMod = 1f)
		{
			this.Init(ownlayer, puppet, muscle, toCopyFrom, (GameObject g, Collider c) => ExtendedMonoBehaviour.CopyCollider<Collider>(g, c, widthMod), widthMod);
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00011CA4 File Offset: 0x0000FEA4
		public void Init(int ownlayer, PuppetMaster puppet, Muscle muscle, PuppetColliderToPene.ToCopyFrom toCopyFrom, Func<GameObject, Collider, Collider> colliderCopier, float widthMod = 1f)
		{
			if (colliderCopier == null)
			{
				throw new ArgumentNullException("colliderCopier", "colliderCopier null reference.");
			}
			if (puppet == null)
			{
				throw new ArgumentNullException("puppet", "puppet null reference.");
			}
			if (muscle == null)
			{
				throw new ArgumentNullException("muscle", "muscle null reference.");
			}
			this.colGetter = colliderCopier;
			this.m_root = base.transform.CreateChild(base.transform.name + "_Root");
			this.m_root.position = muscle.rigidbody.transform.position;
			this.m_root.rotation = muscle.rigidbody.transform.rotation;
			this.m_widthMod = widthMod;
			TrasnformCopier trasnformCopier = this.m_root.gameObject.AddComponent<TrasnformCopier>();
			if (toCopyFrom != PuppetColliderToPene.ToCopyFrom.muscle)
			{
				if (toCopyFrom != PuppetColliderToPene.ToCopyFrom.characterBone)
				{
					throw new ArgumentOutOfRangeException(toCopyFrom.ToString());
				}
				trasnformCopier.Init(false, trasnformCopier.transform, muscle.target, GlobalUpdater.UpdateType.afterAnimationConstraints, 0, false, null, null, null);
			}
			else
			{
				trasnformCopier.Init(false, trasnformCopier.transform, muscle.rigidbody.transform, GlobalUpdater.UpdateType.afterAnimationConstraints, 0, false, null, null, null);
			}
			CopyCharacterTransfromAtribute copyCharacterTransfromAtribute = this.m_root.gameObject.AddComponent<CopyCharacterTransfromAtribute>();
			copyCharacterTransfromAtribute.copyScale = true;
			copyCharacterTransfromAtribute.Init(trasnformCopier.target);
			this.m_puppet = puppet;
			this.m_muscle = muscle;
			this.CoppyColliders(true);
			base.transform.ExecDeepChild(delegate(Transform tt)
			{
				this.m_root.gameObject.layer = ownlayer;
			}, true);
			puppet.OnWrite = (PuppetMaster.UpdateDelegate)Delegate.Combine(puppet.OnWrite, new PuppetMaster.UpdateDelegate(this.OnPuppetMasterWrite));
			base.Initialize();
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00011E84 File Offset: 0x00010084
		private void OnPuppetMasterWrite()
		{
			if (!ExtendedMonoBehaviour.AlmostEqual(this.m_lastMuscleMass, this.m_muscle.rigidbody.mass, 0.001f))
			{
				this.OnMassChanged();
			}
			bool flag = this.m_puppet.mode != PuppetMaster.Mode.Disabled;
			for (int i = 0; i < this.m_Colliders.Count; i++)
			{
				Collider collider = this.m_Colliders[i];
				if (collider.enabled != flag)
				{
					collider.enabled = flag;
				}
			}
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00011F00 File Offset: 0x00010100
		private void CoppyColliders(bool firstTime)
		{
			if (firstTime || this.m_muscle.colliders.Length != this.m_MuscleColliders.Count || !this.m_muscle.colliders.ContainsAllItems(this.m_MuscleColliders))
			{
				foreach (Collider collider in this.m_Colliders)
				{
					Object.Destroy(collider);
				}
				this.m_Colliders.Clear();
				this.m_CollidersSet.Clear();
				this.m_MuscleColliders.Clear();
				this.m_MuscleCollidersDeToConvexCollider.Clear();
				foreach (Collider collider2 in this.m_muscle.colliders)
				{
					Collider collider3 = this.colGetter(this.m_root.gameObject, collider2);
					this.m_Colliders.Add(collider3);
					this.m_CollidersSet.Add(collider3);
					this.m_MuscleColliders.Add(collider2);
					collider3.layerOverridePriority = 1;
					collider3.includeLayers = Singleton<ConfiguracionGeneral>.instance.layers.penes.ToLayerMask();
					this.m_MuscleCollidersDeToConvexCollider.Add(collider3, collider2);
				}
				return;
			}
			foreach (KeyValuePair<Collider, Collider> keyValuePair in this.m_MuscleCollidersDeToConvexCollider)
			{
				ExtendedMonoBehaviour.CopyCollider(keyValuePair.Key, keyValuePair.Value, this.m_widthMod);
			}
		}

		// Token: 0x06000396 RID: 918 RVA: 0x000120A4 File Offset: 0x000102A4
		protected override void OnAplicar()
		{
			base.OnAplicar();
		}

		// Token: 0x06000397 RID: 919 RVA: 0x000120AC File Offset: 0x000102AC
		protected virtual void OnMassChanged()
		{
			this.CoppyColliders(false);
		}

		// Token: 0x06000398 RID: 920 RVA: 0x000120B8 File Offset: 0x000102B8
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (!quitting && this.m_puppet != null)
			{
				PuppetMaster puppet = this.m_puppet;
				puppet.OnWrite = (PuppetMaster.UpdateDelegate)Delegate.Remove(puppet.OnWrite, new PuppetMaster.UpdateDelegate(this.OnPuppetMasterWrite));
			}
		}

		// Token: 0x04000272 RID: 626
		[SerializeField]
		private float m_widthMod;

		// Token: 0x04000273 RID: 627
		[SerializeField]
		[ReadOnlyUI]
		private float m_lastMuscleMass;

		// Token: 0x04000274 RID: 628
		[SerializeField]
		[ReadOnlyUI]
		private PuppetMaster m_puppet;

		// Token: 0x04000275 RID: 629
		[SerializeField]
		[ReadOnlyUI]
		private Muscle m_muscle;

		// Token: 0x04000276 RID: 630
		[SerializeField]
		[ReadOnlyUI]
		private List<Collider> m_Colliders = new List<Collider>();

		// Token: 0x04000277 RID: 631
		private List<Collider> m_MuscleColliders = new List<Collider>();

		// Token: 0x04000278 RID: 632
		private Dictionary<Collider, Collider> m_MuscleCollidersDeToConvexCollider = new Dictionary<Collider, Collider>();

		// Token: 0x04000279 RID: 633
		private HashSet<Collider> m_CollidersSet = new HashSet<Collider>();

		// Token: 0x0400027A RID: 634
		private Transform m_root;

		// Token: 0x0400027B RID: 635
		private Func<GameObject, Collider, Collider> colGetter;

		// Token: 0x02000155 RID: 341
		public enum ToCopyFrom
		{
			// Token: 0x040007D3 RID: 2003
			muscle,
			// Token: 0x040007D4 RID: 2004
			characterBone
		}
	}
}
