using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using Assets._ReusableScripts.BoneColliders;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet;
using Assets._ReusableScripts.Globales;
using RootMotion.Dynamics;
using TValle.BeachGirl.Runtime.Colliders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes
{
	// Token: 0x02000055 RID: 85
	public class PuppetExtraColliders : AplicableBehaviour, ICreadorDeCollidersParaManosProducer, IComponentStartable
	{
		// Token: 0x170000EA RID: 234
		// (get) Token: 0x0600039A RID: 922 RVA: 0x00012138 File Offset: 0x00010338
		public CreadorDeCollidersParaManos CreadorDeCollidersParaManosR
		{
			get
			{
				return this.m_CreadorDeCollidersParaManosR;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00012140 File Offset: 0x00010340
		public CreadorDeCollidersParaManos CreadorDeCollidersParaManosL
		{
			get
			{
				return this.m_CreadorDeCollidersParaManosL;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00012148 File Offset: 0x00010348
		public PuppetMaster pupet
		{
			get
			{
				return this.m_pupet;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600039D RID: 925 RVA: 0x00012150 File Offset: 0x00010350
		public PuppetExtraColliders.Partes partes
		{
			get
			{
				return this.m_partes;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600039E RID: 926 RVA: 0x00012158 File Offset: 0x00010358
		CreadorDeCollidersParaManos ICreadorDeCollidersParaManosProducer.r
		{
			get
			{
				return this.m_CreadorDeCollidersParaManosR;
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600039F RID: 927 RVA: 0x00012160 File Offset: 0x00010360
		CreadorDeCollidersParaManos ICreadorDeCollidersParaManosProducer.l
		{
			get
			{
				return this.m_CreadorDeCollidersParaManosL;
			}
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x00012168 File Offset: 0x00010368
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Animator = base.GetComponentInChildren<Animator>();
			if (this.m_Animator == null)
			{
				throw new ArgumentNullException("m_Animator", "m_Animator null reference.");
			}
			this.m_HandFingerSizeModPorShapes = this.GetComponentEnRoot(false);
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x000121A8 File Offset: 0x000103A8
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_pupet = base.GetComponentInChildren<PuppetMaster>();
			this.m_character = base.GetComponent<ICharacter>();
			if (this.m_pupet == null)
			{
				throw new ArgumentNullException("m_pupet", "m_pupet null reference.");
			}
			this.AddHandColliders(this.m_pupet.GetMuscle(this.m_Animator, HumanBodyBones.LeftHand), this.m_partes.handL, ref this.m_CreadorDeCollidersParaManosL, new Func<List<Collider>>(this.PonerCollidersDeManosL));
			this.AddHandColliders(this.m_pupet.GetMuscle(this.m_Animator, HumanBodyBones.RightHand), this.m_partes.handR, ref this.m_CreadorDeCollidersParaManosR, new Func<List<Collider>>(this.PonerCollidersDeManosR));
			this.AddHeadCameraCollider();
			this.m_partes.Init();
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00012270 File Offset: 0x00010470
		private void AddHeadCameraCollider()
		{
			PuppetExtraColliders.Parte headCamera = this.m_partes.headCamera;
			if (!headCamera.usar)
			{
				return;
			}
			if (this.m_character == null)
			{
				this.m_character = base.GetComponent<ICharacter>();
			}
			Vector3 worldFirstPersonViewPoint = this.m_character.worldFirstPersonViewPoint;
			Muscle muscle = this.m_pupet.GetMuscle(this.m_Animator, HumanBodyBones.Head);
			Transform transform = muscle.rigidbody.transform.CreateChild("Cam Collider");
			transform.position = worldFirstPersonViewPoint;
			transform.rotation = Quaternion.LookRotation(this.m_Animator.transform.forward, this.m_Animator.transform.up);
			transform.gameObject.layer = muscle.rigidbody.gameObject.layer;
			CapsuleCollider capsuleCollider = transform.gameObject.AddComponent<CapsuleCollider>();
			capsuleCollider.direction = 2;
			capsuleCollider.radius = 0.05f;
			capsuleCollider.height = 0.35f;
			headCamera.colliders.Add(capsuleCollider);
			headCamera.collidersSet = new HashSet<Collider>(headCamera.colliders);
			if (!headCamera.startsEnabled)
			{
				headCamera.Enable(false);
			}
			IMuscleCollidersUpdater component = muscle.rigidbody.GetComponent<IMuscleCollidersUpdater>();
			if (component != null)
			{
				component.UpdateColliders();
			}
			else
			{
				muscle.UpdateColliders();
			}
			this.m_pupet.UpdateInternalCollisons();
			this.m_extraColliders.AddRange(headCamera.colliders);
			foreach (Collider collider in headCamera.colliders)
			{
				collider.contactOffset = this.m_contactOffset;
				collider.sharedMaterial = Singleton<ColecionDePhysicsMaterials>.instance.zeroFriccion;
			}
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00012414 File Offset: 0x00010614
		private void AddHandColliders(Muscle muscle, PuppetExtraColliders.ManoParte hand, ref CreadorDeCollidersParaManos creador, Func<List<Collider>> ponedor)
		{
			hand.colliders = ponedor();
			hand.collidersSet = new HashSet<Collider>(hand.colliders);
			hand.boneColliders = creador.manoBoneColliders;
			hand.boneCollidersIndice = new List<BoneCollider>
			{
				creador.colliders.indexProximal,
				creador.colliders.indexIntermediate,
				creador.colliders.indexDistal
			};
			hand.collidersIndice = new List<Collider>
			{
				creador.colliders.indexProximal.col,
				creador.colliders.indexIntermediate.col,
				creador.colliders.indexDistal.col
			};
			hand.collidersSetIndice = new HashSet<Collider>(hand.collidersIndice);
			hand.boneCollidersDedos = new List<BoneCollider>(creador.manoBoneColliders);
			hand.boneCollidersDedos.Remove(creador.colliders.handCenter);
			hand.boneCollidersDedos.Remove(creador.colliders.handCenter2);
			hand.collidersDedos = hand.boneCollidersDedos.Select((BoneCollider b) => (CapsuleCollider)b.col).ToList<CapsuleCollider>();
			hand.collidersSetDedos = new HashSet<CapsuleCollider>(hand.collidersDedos);
			if (!hand.startsEnabled)
			{
				hand.Enable(false);
			}
			IMuscleCollidersUpdater component = muscle.rigidbody.GetComponent<IMuscleCollidersUpdater>();
			if (component != null)
			{
				component.UpdateColliders();
			}
			else
			{
				muscle.UpdateColliders();
			}
			this.m_pupet.UpdateInternalCollisons();
			this.m_extraColliders.AddRange(hand.colliders);
			foreach (Collider collider in hand.colliders)
			{
				collider.contactOffset = this.m_contactOffset;
				collider.sharedMaterial = Singleton<ColecionDePhysicsMaterials>.instance.skin;
			}
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00012618 File Offset: 0x00010818
		private List<Collider> PonerCollidersDeManosL()
		{
			return new List<Collider>(this.PonerCollidersDeMano(ref this.m_CreadorDeCollidersParaManosL, CreadorDeCollidersParaManos.Side.l));
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x0001262C File Offset: 0x0001082C
		private List<Collider> PonerCollidersDeManosR()
		{
			return new List<Collider>(this.PonerCollidersDeMano(ref this.m_CreadorDeCollidersParaManosR, CreadorDeCollidersParaManos.Side.r));
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00012640 File Offset: 0x00010840
		private List<Collider> PonerCollidersDeMano(ref CreadorDeCollidersParaManos creador, CreadorDeCollidersParaManos.Side side)
		{
			Transform transform = null;
			Muscle hand = null;
			switch (side)
			{
			case CreadorDeCollidersParaManos.Side.l:
				transform = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftHand);
				hand = this.m_pupet.GetMuscle(this.m_Animator, HumanBodyBones.LeftHand);
				break;
			case CreadorDeCollidersParaManos.Side.r:
				transform = this.m_Animator.GetBoneTransform(HumanBodyBones.RightHand);
				hand = this.m_pupet.GetMuscle(this.m_Animator, HumanBodyBones.RightHand);
				break;
			}
			creador = new CreadorDeCollidersParaManos(side, this.m_Animator, this, transform, hand.rigidbody);
			creador.localForward = this.m_bonesLocalForward;
			creador.followScale = false;
			creador.sizeModDelegate = delegate
			{
				Vector3 one = Vector3.one;
				one.x = ((this.m_HandFingerSizeModPorShapes != null) ? this.m_HandFingerSizeModPorShapes.currentOverallMod : 1f);
				return one;
			};
			Transform transform2 = hand.rigidbody.transform.CreateChild(hand.name + "_ExtraColliders");
			creador.SetRoot(transform2);
			creador.Crear();
			creador.rootToColliders.ExecDeepChild(delegate(Transform t)
			{
				t.gameObject.layer = hand.rigidbody.gameObject.layer;
			}, true);
			List<Collider> list = new List<Collider>();
			creador.GetColliders(list);
			return list;
		}

		// Token: 0x0400027C RID: 636
		[NonSerialized]
		private CreadorDeCollidersParaManos m_CreadorDeCollidersParaManosR;

		// Token: 0x0400027D RID: 637
		[NonSerialized]
		private CreadorDeCollidersParaManos m_CreadorDeCollidersParaManosL;

		// Token: 0x0400027E RID: 638
		private Animator m_Animator;

		// Token: 0x0400027F RID: 639
		private PuppetMaster m_pupet;

		// Token: 0x04000280 RID: 640
		private ICharacter m_character;

		// Token: 0x04000281 RID: 641
		[SerializeField]
		private Vector3 m_bonesLocalForward = Vector3.forward;

		// Token: 0x04000282 RID: 642
		[SerializeField]
		private float m_contactOffset = 0.0066f;

		// Token: 0x04000283 RID: 643
		private List<Collider> m_extraColliders = new List<Collider>();

		// Token: 0x04000284 RID: 644
		[SerializeField]
		private PuppetExtraColliders.Partes m_partes = new PuppetExtraColliders.Partes();

		// Token: 0x04000285 RID: 645
		private IHandFingerSizeModPorShapes m_HandFingerSizeModPorShapes;

		// Token: 0x02000158 RID: 344
		[Serializable]
		public class ManoParte : PuppetExtraColliders.Parte
		{
			// Token: 0x06000B8C RID: 2956 RVA: 0x00034CF4 File Offset: 0x00032EF4
			public void EnableIndice(bool collidersEnabled, bool boneColliderEnabled)
			{
				for (int i = 0; i < this.collidersIndice.Count; i++)
				{
					this.collidersIndice[i].enabled = collidersEnabled;
				}
				for (int j = 0; j < this.boneCollidersIndice.Count; j++)
				{
					this.boneCollidersIndice[j].enabled = boneColliderEnabled;
				}
			}

			// Token: 0x06000B8D RID: 2957 RVA: 0x00034D54 File Offset: 0x00032F54
			public void SetRadiusModToFingers(float radiusMod, float largoMod)
			{
				for (int i = 0; i < this.boneCollidersDedos.Count; i++)
				{
					BoneCollider boneCollider = this.boneCollidersDedos[i];
					Vector3 sizeMod = boneCollider.sizeMod;
					sizeMod.x = radiusMod;
					sizeMod.y = largoMod;
					boneCollider.sizeMod = sizeMod;
				}
			}

			// Token: 0x040007D8 RID: 2008
			[ReadOnlyUI]
			public List<BoneCollider> boneCollidersDedos;

			// Token: 0x040007D9 RID: 2009
			[ReadOnlyUI]
			public List<CapsuleCollider> collidersDedos;

			// Token: 0x040007DA RID: 2010
			public HashSet<CapsuleCollider> collidersSetDedos;

			// Token: 0x040007DB RID: 2011
			[ReadOnlyUI]
			public List<BoneCollider> boneCollidersIndice;

			// Token: 0x040007DC RID: 2012
			[ReadOnlyUI]
			public List<Collider> collidersIndice;

			// Token: 0x040007DD RID: 2013
			public HashSet<Collider> collidersSetIndice;
		}

		// Token: 0x02000159 RID: 345
		[Serializable]
		public class Parte
		{
			// Token: 0x06000B8F RID: 2959 RVA: 0x00034DA8 File Offset: 0x00032FA8
			public virtual void Init()
			{
			}

			// Token: 0x06000B90 RID: 2960 RVA: 0x00034DAC File Offset: 0x00032FAC
			public void Enable(bool enable)
			{
				for (int i = 0; i < this.colliders.Count; i++)
				{
					this.colliders[i].enabled = enable;
				}
				for (int j = 0; j < this.boneColliders.Count; j++)
				{
					this.boneColliders[j].enabled = enable;
				}
			}

			// Token: 0x06000B91 RID: 2961 RVA: 0x00034E0C File Offset: 0x0003300C
			public void SetMaterial(PhysicMaterial material)
			{
				for (int i = 0; i < this.colliders.Count; i++)
				{
					this.colliders[i].sharedMaterial = material;
				}
			}

			// Token: 0x06000B92 RID: 2962 RVA: 0x00034E44 File Offset: 0x00033044
			public void SetDefaultMaterial()
			{
				if (!Singleton<ColecionDePhysicsMaterials>.IsInScene)
				{
					return;
				}
				for (int i = 0; i < this.colliders.Count; i++)
				{
					this.colliders[i].sharedMaterial = Singleton<ColecionDePhysicsMaterials>.instance.skin;
				}
			}

			// Token: 0x040007DE RID: 2014
			public bool usar = true;

			// Token: 0x040007DF RID: 2015
			public bool startsEnabled = true;

			// Token: 0x040007E0 RID: 2016
			[ReadOnlyUI]
			public List<BoneCollider> boneColliders;

			// Token: 0x040007E1 RID: 2017
			public HashSet<Collider> collidersSet;

			// Token: 0x040007E2 RID: 2018
			[ReadOnlyUI]
			public List<Collider> colliders;
		}

		// Token: 0x0200015A RID: 346
		[Serializable]
		public class Partes
		{
			// Token: 0x06000B94 RID: 2964 RVA: 0x00034EA0 File Offset: 0x000330A0
			public void Init()
			{
				this.headCamera.Init();
				this.handL.Init();
				this.handR.Init();
			}

			// Token: 0x040007E3 RID: 2019
			public PuppetExtraColliders.ManoParte handL = new PuppetExtraColliders.ManoParte();

			// Token: 0x040007E4 RID: 2020
			public PuppetExtraColliders.ManoParte handR = new PuppetExtraColliders.ManoParte();

			// Token: 0x040007E5 RID: 2021
			public PuppetExtraColliders.Parte headCamera = new PuppetExtraColliders.Parte();
		}
	}
}
