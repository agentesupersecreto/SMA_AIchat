using System;
using System.Collections.Generic;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x02000104 RID: 260
	public class MuscleCollidersCopier : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000A24 RID: 2596 RVA: 0x0002D637 File Offset: 0x0002B837
		public override int updateEvent1Index
		{
			get
			{
				return 53;
			}
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x0002D63C File Offset: 0x0002B83C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PuppetMaster = this.GetComponentEnRoot(false);
			if (this.m_PuppetMaster == null)
			{
				throw new ArgumentNullException("m_PuppetMaster", "m_PuppetMaster null reference.");
			}
			PuppetMaster puppetMaster = this.m_PuppetMaster;
			puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Combine(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(this.OnPostInitiate_m_PuppetMaster));
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x0002D6A1 File Offset: 0x0002B8A1
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_bonesForward = this.bonesForward.normalized;
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x0002D6BC File Offset: 0x0002B8BC
		private void OnPostInitiate_m_PuppetMaster()
		{
			PuppetMaster puppetMaster = this.m_PuppetMaster;
			puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Remove(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(this.OnPostInitiate_m_PuppetMaster));
			Muscle muscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightLowerLeg);
			Muscle muscle2 = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftLowerLeg);
			foreach (Muscle muscle3 in this.m_PuppetMaster.muscles)
			{
				MuscleCollidersCopier.SizeMods sizeMods = this.m_generalMods;
				MuscleCollidersCopier.ParConfig parConfig = this.m_generalConfig;
				if (muscle3.props.group != Muscle.Group.Hand && muscle3.props.group != Muscle.Group.Foot && (this.m_copieArms || muscle3.props.group != Muscle.Group.Arm))
				{
					if (muscle3.props.group == Muscle.Group.Leg)
					{
						if (!this.m_copieLegs)
						{
							goto IL_01F8;
						}
						sizeMods = this.m_piernasMods;
						parConfig = this.m_piernasConfig;
					}
					if (muscle3 != muscle && muscle3 != muscle2)
					{
						Collider collider = muscle3.colliders[0];
						MuscleCollidersCopier.Par par = null;
						if (collider is SphereCollider)
						{
							par = new MuscleCollidersCopier.ParSphere(sizeMods, parConfig);
							SphereCollider sphereCollider = base.transform.CreateChild(muscle3.name).gameObject.AddComponent<SphereCollider>();
							((MuscleCollidersCopier.ParSphere)par).collider = sphereCollider;
						}
						if (collider is CapsuleCollider)
						{
							par = new MuscleCollidersCopier.ParCapsule(sizeMods, parConfig);
							CapsuleCollider capsuleCollider = base.transform.CreateChild(muscle3.name).gameObject.AddComponent<CapsuleCollider>();
							((MuscleCollidersCopier.ParCapsule)par).collider = capsuleCollider;
						}
						if (collider is BoxCollider)
						{
							par = new MuscleCollidersCopier.ParBox(sizeMods, parConfig);
							BoxCollider boxCollider = base.transform.CreateChild(muscle3.name).gameObject.AddComponent<BoxCollider>();
							((MuscleCollidersCopier.ParBox)par).collider = boxCollider;
						}
						if (par != null)
						{
							par.muscle = muscle3;
							par.baseCollider.gameObject.layer = base.gameObject.layer;
							ExtendedMonoBehaviour.CopyCollider(par.baseCollider, collider, 1f);
							this.m_pares.Add(par);
						}
					}
				}
				IL_01F8:;
			}
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x0002D8D0 File Offset: 0x0002BAD0
		public void SyncColliders()
		{
			if (!this.m_PuppetMaster.initiated || !this.m_PuppetMaster.enabled || this.m_PuppetMaster.mode == PuppetMaster.Mode.Disabled)
			{
				return;
			}
			for (int i = 0; i < this.m_pares.Count; i++)
			{
				this.m_pares[i].Sync(this, 1f, 1f);
			}
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x0002D938 File Offset: 0x0002BB38
		public override void OnUpdateEvent1()
		{
			this.SyncColliders();
		}

		// Token: 0x04000629 RID: 1577
		public Vector3 bonesForward = Vector3.forward;

		// Token: 0x0400062A RID: 1578
		private PuppetMaster m_PuppetMaster;

		// Token: 0x0400062B RID: 1579
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_bonesForward;

		// Token: 0x0400062C RID: 1580
		[SerializeField]
		private MuscleCollidersCopier.SizeMods m_generalMods = new MuscleCollidersCopier.SizeMods();

		// Token: 0x0400062D RID: 1581
		[SerializeField]
		private MuscleCollidersCopier.SizeMods m_piernasMods = new MuscleCollidersCopier.SizeMods
		{
			ancho = 0.9f,
			largo = 0.6f
		};

		// Token: 0x0400062E RID: 1582
		[SerializeField]
		private MuscleCollidersCopier.ParConfig m_generalConfig = new MuscleCollidersCopier.ParConfig();

		// Token: 0x0400062F RID: 1583
		[SerializeField]
		private MuscleCollidersCopier.ParConfig m_piernasConfig = new MuscleCollidersCopier.ParConfig
		{
			recalculeCenter = true
		};

		// Token: 0x04000630 RID: 1584
		private List<MuscleCollidersCopier.Par> m_pares = new List<MuscleCollidersCopier.Par>();

		// Token: 0x04000631 RID: 1585
		[SerializeField]
		private bool m_copieArms;

		// Token: 0x04000632 RID: 1586
		[SerializeField]
		private bool m_copieLegs;

		// Token: 0x020001C6 RID: 454
		private abstract class Par
		{
			// Token: 0x06000D1D RID: 3357 RVA: 0x00039D0A File Offset: 0x00037F0A
			public Par(MuscleCollidersCopier.SizeMods Mods, MuscleCollidersCopier.ParConfig Config)
			{
				if (Mods == null)
				{
					throw new ArgumentNullException("Mods", "Mods null reference.");
				}
				if (Config == null)
				{
					throw new ArgumentNullException("Config", "Config null reference.");
				}
				this.mods = Mods;
				this.config = Config;
			}

			// Token: 0x17000286 RID: 646
			// (get) Token: 0x06000D1E RID: 3358
			public abstract Collider baseCollider { get; }

			// Token: 0x06000D1F RID: 3359
			public abstract void Sync(MuscleCollidersCopier parent, float anchoMod, float largoMod);

			// Token: 0x040009D9 RID: 2521
			public MuscleCollidersCopier.ParConfig config;

			// Token: 0x040009DA RID: 2522
			public MuscleCollidersCopier.SizeMods mods;

			// Token: 0x040009DB RID: 2523
			public Muscle muscle;
		}

		// Token: 0x020001C7 RID: 455
		private abstract class Par<TCollider> : MuscleCollidersCopier.Par where TCollider : Collider
		{
			// Token: 0x06000D20 RID: 3360 RVA: 0x00039D46 File Offset: 0x00037F46
			public Par(MuscleCollidersCopier.SizeMods Mods, MuscleCollidersCopier.ParConfig Config)
				: base(Mods, Config)
			{
			}

			// Token: 0x17000287 RID: 647
			// (get) Token: 0x06000D21 RID: 3361 RVA: 0x00039D50 File Offset: 0x00037F50
			public sealed override Collider baseCollider
			{
				get
				{
					return this.collider;
				}
			}

			// Token: 0x06000D22 RID: 3362 RVA: 0x00039D60 File Offset: 0x00037F60
			public override void Sync(MuscleCollidersCopier parent, float anchoMod, float largoMod)
			{
				this.collider.transform.SetPositionAndRotation(this.muscle.rigidbody.transform.position, this.muscle.rigidbody.transform.rotation);
				this.collider.transform.localScale = this.muscle.rigidbody.transform.lossyScale;
			}

			// Token: 0x040009DC RID: 2524
			public TCollider collider;
		}

		// Token: 0x020001C8 RID: 456
		private class ParSphere : MuscleCollidersCopier.Par<SphereCollider>
		{
			// Token: 0x06000D23 RID: 3363 RVA: 0x00039DD6 File Offset: 0x00037FD6
			public ParSphere(MuscleCollidersCopier.SizeMods Mods, MuscleCollidersCopier.ParConfig Config)
				: base(Mods, Config)
			{
			}

			// Token: 0x06000D24 RID: 3364 RVA: 0x00039DE0 File Offset: 0x00037FE0
			public sealed override void Sync(MuscleCollidersCopier parent, float anchoMod, float largoMod)
			{
				base.Sync(parent, anchoMod, largoMod);
				SphereCollider sphereCollider = (SphereCollider)this.muscle.colliders[0];
				ExtendedMonoBehaviour.CopyCollider(this.collider, sphereCollider, 1f);
				this.collider.radius = sphereCollider.radius * anchoMod * this.mods.ancho;
			}
		}

		// Token: 0x020001C9 RID: 457
		private class ParCapsule : MuscleCollidersCopier.Par<CapsuleCollider>
		{
			// Token: 0x06000D25 RID: 3365 RVA: 0x00039E39 File Offset: 0x00038039
			public ParCapsule(MuscleCollidersCopier.SizeMods Mods, MuscleCollidersCopier.ParConfig Config)
				: base(Mods, Config)
			{
			}

			// Token: 0x06000D26 RID: 3366 RVA: 0x00039E44 File Offset: 0x00038044
			public sealed override void Sync(MuscleCollidersCopier parent, float anchoMod, float largoMod)
			{
				base.Sync(parent, anchoMod, largoMod);
				CapsuleCollider capsuleCollider = (CapsuleCollider)this.muscle.colliders[0];
				ExtendedMonoBehaviour.CopyCollider(this.collider, capsuleCollider, 1f);
				this.collider.radius = capsuleCollider.radius * anchoMod * this.mods.ancho;
				this.collider.height = capsuleCollider.height * largoMod * this.mods.largo;
				if (this.config.recalculeCenter)
				{
					this.collider.center = Vector3.zero + Vector3.forward * (this.collider.height * 0.5f - this.collider.radius * 0.5f);
				}
			}
		}

		// Token: 0x020001CA RID: 458
		private class ParBox : MuscleCollidersCopier.Par<BoxCollider>
		{
			// Token: 0x06000D27 RID: 3367 RVA: 0x00039F0B File Offset: 0x0003810B
			public ParBox(MuscleCollidersCopier.SizeMods Mods, MuscleCollidersCopier.ParConfig Config)
				: base(Mods, Config)
			{
			}

			// Token: 0x06000D28 RID: 3368 RVA: 0x00039F18 File Offset: 0x00038118
			public sealed override void Sync(MuscleCollidersCopier parent, float anchoMod, float largoMod)
			{
				base.Sync(parent, anchoMod, largoMod);
				BoxCollider boxCollider = (BoxCollider)this.muscle.colliders[0];
				ExtendedMonoBehaviour.CopyCollider(this.collider, boxCollider, 1f);
				anchoMod *= this.mods.ancho;
				largoMod *= this.mods.largo;
				Vector3 vector = new Vector3(Mathf.Lerp(anchoMod, 1f, parent.m_bonesForward.x), Mathf.Lerp(anchoMod, 1f, parent.m_bonesForward.y), Mathf.Lerp(anchoMod, 1f, parent.m_bonesForward.z));
				Vector3 vector2 = new Vector3(Mathf.Lerp(1f, largoMod, parent.m_bonesForward.x), Mathf.Lerp(1f, largoMod, parent.m_bonesForward.y), Mathf.Lerp(1f, largoMod, parent.m_bonesForward.z));
				Vector3 size = boxCollider.size;
				this.collider.size = new Vector3(vector.x * size.x * vector2.x, vector.y * size.y * vector2.y, vector.z * size.z * vector2.z);
			}
		}

		// Token: 0x020001CB RID: 459
		[Serializable]
		public class SizeMods
		{
			// Token: 0x040009DD RID: 2525
			public float ancho = 0.9f;

			// Token: 0x040009DE RID: 2526
			public float largo = 0.9f;
		}

		// Token: 0x020001CC RID: 460
		[Serializable]
		public class ParConfig
		{
			// Token: 0x040009DF RID: 2527
			public bool recalculeCenter;
		}
	}
}
