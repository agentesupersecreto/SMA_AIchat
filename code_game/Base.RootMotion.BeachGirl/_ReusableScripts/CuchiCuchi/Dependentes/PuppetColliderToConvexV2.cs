using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes
{
	// Token: 0x02000053 RID: 83
	public class PuppetColliderToConvexV2 : AplicableBehaviour
	{
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600037F RID: 895 RVA: 0x000115FF File Offset: 0x0000F7FF
		public Muscle muscle
		{
			get
			{
				return this.m_muscle;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000380 RID: 896 RVA: 0x00011607 File Offset: 0x0000F807
		public Rigidbody dynamic
		{
			get
			{
				return this.m_dynamic;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000381 RID: 897 RVA: 0x0001160F File Offset: 0x0000F80F
		public HashSet<Collider> collidersSet
		{
			get
			{
				return this.m_CollidersSet;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000382 RID: 898 RVA: 0x00011617 File Offset: 0x0000F817
		public IReadOnlyList<Collider> colliders
		{
			get
			{
				return this.m_Colliders;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000383 RID: 899 RVA: 0x0001161F File Offset: 0x0000F81F
		public ManualCollisionBody manualCollisionBody
		{
			get
			{
				return this.m_ManualCollisionBody;
			}
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00011627 File Offset: 0x0000F827
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
		}

		// Token: 0x06000385 RID: 901 RVA: 0x00011638 File Offset: 0x0000F838
		public void Init(int ownlayer, PuppetMaster puppet, Muscle muscle, PuppetColliderToConvexV2.ToCopyFrom toCopyFrom, float widthMod = 1f, float massMod = 1f, float AccMod = 1f, float? depenOverride = null)
		{
			this.Init(ownlayer, puppet, muscle, toCopyFrom, (GameObject g, Collider c) => ExtendedMonoBehaviour.CopyCollider<Collider>(g, c, widthMod), widthMod, massMod, AccMod, depenOverride);
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00011678 File Offset: 0x0000F878
		public void Init(int ownlayer, PuppetMaster puppet, Muscle muscle, PuppetColliderToConvexV2.ToCopyFrom toCopyFrom, Func<GameObject, Collider, Collider> colliderCopier, float widthMod = 1f, float massMod = 1f, float AccMod = 1f, float? depenOverride = null)
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
			Transform tDynamic = base.transform.CreateChild(base.transform.name + "_Dynamic");
			tDynamic.position = muscle.rigidbody.transform.position;
			tDynamic.rotation = muscle.rigidbody.transform.rotation;
			this.m_widthMod = widthMod;
			this.m_massMod = massMod;
			TrasnformCopier trasnformCopier = tDynamic.gameObject.AddComponent<TrasnformCopier>();
			if (toCopyFrom != PuppetColliderToConvexV2.ToCopyFrom.muscle)
			{
				if (toCopyFrom != PuppetColliderToConvexV2.ToCopyFrom.characterBone)
				{
					throw new ArgumentOutOfRangeException(toCopyFrom.ToString());
				}
				trasnformCopier.Init(false, trasnformCopier.transform, muscle.target, GlobalUpdater.UpdateType.afterAnimationConstraints, 0, false, null, null, null);
			}
			else
			{
				trasnformCopier.Init(false, trasnformCopier.transform, muscle.rigidbody.transform, GlobalUpdater.UpdateType.afterAnimationConstraints, 0, false, null, null, null);
			}
			CopyCharacterTransfromAtribute copyCharacterTransfromAtribute = tDynamic.gameObject.AddComponent<CopyCharacterTransfromAtribute>();
			copyCharacterTransfromAtribute.copyScale = true;
			copyCharacterTransfromAtribute.Init(trasnformCopier.target);
			this.m_dynamic = tDynamic.gameObject.AddComponent<Rigidbody>();
			this.m_ManualCollisionBody = tDynamic.gameObject.AddComponent<ManualCollisionBody>();
			this.m_ManualCollisionBody.configuracion.accMod *= AccMod;
			if (depenOverride != null)
			{
				this.m_ManualCollisionBody.configuracion.depenetrationVelocity = depenOverride.Value;
			}
			this.m_masMod = tDynamic.gameObject.AddComponent<MassModifier>();
			MassModifier masMod = this.m_masMod;
			MassModifier component = muscle.rigidbody.GetComponent<MassModifier>();
			masMod.defaultMod = ((component != null) ? new float?(component.defaultMod) : null).GetValueOrDefault(1f);
			this.m_dynamic.constraints = RigidbodyConstraints.FreezeAll;
			this.m_puppet = puppet;
			this.m_muscle = muscle;
			this.CoppyColliders(true);
			base.transform.ExecDeepChild(delegate(Transform tt)
			{
				tDynamic.gameObject.layer = ownlayer;
			}, true);
			this.CalculeMass();
			puppet.OnWrite = (PuppetMaster.UpdateDelegate)Delegate.Combine(puppet.OnWrite, new PuppetMaster.UpdateDelegate(this.OnPuppetMasterWrite));
			base.Initialize();
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00011924 File Offset: 0x0000FB24
		private void OnPuppetMasterWrite()
		{
			if (!ExtendedMonoBehaviour.AlmostEqual(this.m_lastMuscleMass, this.m_muscle.rigidbody.mass, 0.001f))
			{
				this.OnMassChanged();
			}
			bool flag = this.alwaysEnabled || this.m_puppet.mode != PuppetMaster.Mode.Disabled;
			for (int i = 0; i < this.m_Colliders.Count; i++)
			{
				Collider collider = this.m_Colliders[i];
				if (collider.enabled != flag)
				{
					collider.enabled = flag;
				}
			}
		}

		// Token: 0x06000388 RID: 904 RVA: 0x000119AC File Offset: 0x0000FBAC
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
					Collider collider3 = this.colGetter(this.m_dynamic.gameObject, collider2);
					this.m_Colliders.Add(collider3);
					this.m_CollidersSet.Add(collider3);
					this.m_MuscleColliders.Add(collider2);
					this.m_MuscleCollidersDeToConvexCollider.Add(collider3, collider2);
				}
				return;
			}
			foreach (KeyValuePair<Collider, Collider> keyValuePair in this.m_MuscleCollidersDeToConvexCollider)
			{
				ExtendedMonoBehaviour.CopyCollider(keyValuePair.Key, keyValuePair.Value, this.m_widthMod);
			}
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00011B24 File Offset: 0x0000FD24
		public void CalculeMass()
		{
			this.m_lastMuscleMass = this.m_muscle.rigidbody.mass;
			this.m_dynamic.mass = this.m_muscle.rigidbody.mass * this.m_massMod;
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00011B5E File Offset: 0x0000FD5E
		protected override void OnAplicar()
		{
			base.OnAplicar();
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00011B68 File Offset: 0x0000FD68
		protected virtual void OnMassChanged()
		{
			this.CoppyColliders(false);
			this.CalculeMass();
			MassModifier masMod = this.m_masMod;
			MassModifier component = this.muscle.rigidbody.GetComponent<MassModifier>();
			masMod.defaultMod = ((component != null) ? new float?(component.defaultMod) : null).GetValueOrDefault(1f);
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00011BC4 File Offset: 0x0000FDC4
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (!quitting && this.m_puppet != null)
			{
				PuppetMaster puppet = this.m_puppet;
				puppet.OnWrite = (PuppetMaster.UpdateDelegate)Delegate.Remove(puppet.OnWrite, new PuppetMaster.UpdateDelegate(this.OnPuppetMasterWrite));
			}
		}

		// Token: 0x04000264 RID: 612
		public bool alwaysEnabled;

		// Token: 0x04000265 RID: 613
		[SerializeField]
		private float m_widthMod;

		// Token: 0x04000266 RID: 614
		[SerializeField]
		private float m_massMod;

		// Token: 0x04000267 RID: 615
		[SerializeField]
		[ReadOnlyUI]
		private float m_lastMuscleMass;

		// Token: 0x04000268 RID: 616
		[SerializeField]
		[ReadOnlyUI]
		private PuppetMaster m_puppet;

		// Token: 0x04000269 RID: 617
		[SerializeField]
		[ReadOnlyUI]
		private Muscle m_muscle;

		// Token: 0x0400026A RID: 618
		[SerializeField]
		[ReadOnlyUI]
		private ManualCollisionBody m_ManualCollisionBody;

		// Token: 0x0400026B RID: 619
		[SerializeField]
		[ReadOnlyUI]
		private List<Collider> m_Colliders = new List<Collider>();

		// Token: 0x0400026C RID: 620
		private List<Collider> m_MuscleColliders = new List<Collider>();

		// Token: 0x0400026D RID: 621
		private Dictionary<Collider, Collider> m_MuscleCollidersDeToConvexCollider = new Dictionary<Collider, Collider>();

		// Token: 0x0400026E RID: 622
		private HashSet<Collider> m_CollidersSet = new HashSet<Collider>();

		// Token: 0x0400026F RID: 623
		private Rigidbody m_dynamic;

		// Token: 0x04000270 RID: 624
		private MassModifier m_masMod;

		// Token: 0x04000271 RID: 625
		private Func<GameObject, Collider, Collider> colGetter;

		// Token: 0x02000152 RID: 338
		public enum ToCopyFrom
		{
			// Token: 0x040007CD RID: 1997
			muscle,
			// Token: 0x040007CE RID: 1998
			characterBone
		}
	}
}
