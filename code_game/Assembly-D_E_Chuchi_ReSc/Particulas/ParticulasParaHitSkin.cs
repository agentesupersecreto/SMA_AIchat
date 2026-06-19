using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Particulas
{
	// Token: 0x02000151 RID: 337
	[RequireComponent(typeof(HitSkinBasica))]
	public abstract class ParticulasParaHitSkin : CustomUpdatedMonobehaviourBase, ParticulasParaHitSkin.IOnCollisionListiner
	{
		// Token: 0x1400002A RID: 42
		// (add) Token: 0x0600079C RID: 1948 RVA: 0x00023B20 File Offset: 0x00021D20
		// (remove) Token: 0x0600079D RID: 1949 RVA: 0x00023B58 File Offset: 0x00021D58
		public event ParticulasParaHitSkin.OnCollisionHandler collisioned;

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x0600079E RID: 1950 RVA: 0x00023B8D File Offset: 0x00021D8D
		public List<GameObject> targets
		{
			get
			{
				return this.m_targets;
			}
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x00023B98 File Offset: 0x00021D98
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_HitSkinBasica = base.GetComponent<HitSkinBasica>();
			if (this.m_HitSkinBasica == null)
			{
				throw new ArgumentNullException("m_HitSkinBasica", "m_HitSkinBasica null reference.");
			}
			if (this.m_HitSkinBasica.isStared)
			{
				this.Iniciar();
				return;
			}
			this.m_HitSkinBasica.stared += this.M_HitSkinBasica_stared;
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00023C00 File Offset: 0x00021E00
		private void M_HitSkinBasica_stared(object obj)
		{
			this.Iniciar();
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x00023C08 File Offset: 0x00021E08
		private void Iniciar()
		{
			if (this.m_targets.Count == 0)
			{
				Debug.LogError(base.name + " no contiene targets para obtener las collisiones");
			}
			this.m_ParticleSystem = this.ProducirParticleSystem();
			if (this.m_ParticleSystem == null)
			{
				throw new ArgumentNullException("m_ParticleSystem", "m_ParticleSystem null reference.");
			}
			if (this.m_HitSkinBasica.rigid != null)
			{
				this.m_HitSkinBasica.rigid.gameObject.AddComponent<ParticleCollisionBroadCaster>().Init(this);
				return;
			}
			HashSet<Rigidbody> hashSet = new HashSet<Rigidbody>();
			HashSet<Transform> hashSet2 = new HashSet<Transform>();
			foreach (Collider collider in this.m_HitSkinBasica.skinColliders)
			{
				if (collider.attachedRigidbody)
				{
					hashSet.Add(collider.attachedRigidbody);
				}
				else
				{
					hashSet2.Add(collider.transform);
				}
			}
			foreach (Transform transform in hashSet2)
			{
				transform.gameObject.AddComponent<ParticleCollisionBroadCaster>().Init(this);
			}
			foreach (Rigidbody rigidbody in hashSet)
			{
				rigidbody.gameObject.AddComponent<ParticleCollisionBroadCaster>().Init(this);
			}
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x00023D98 File Offset: 0x00021F98
		void ParticulasParaHitSkin.IOnCollisionListiner.OnCollision(GameObject particles, ParticleCollisionBroadCaster broadCaster)
		{
			if (this.breakOnCollision && Application.isEditor)
			{
				Debug.Break();
			}
			ParticleSystem component = particles.GetComponent<ParticleSystem>();
			if (component == null)
			{
				return;
			}
			if (broadCaster == null)
			{
				return;
			}
			this.OnParticulasCollisionandoConCollider(component, broadCaster);
			ParticulasParaHitSkin.OnCollisionHandler onCollisionHandler = this.collisioned;
			if (onCollisionHandler == null)
			{
				return;
			}
			onCollisionHandler(this, this.m_HitSkinBasica, component, broadCaster);
		}

		// Token: 0x060007A3 RID: 1955
		protected abstract ParticleSystem ProducirParticleSystem();

		// Token: 0x060007A4 RID: 1956
		protected abstract void OnParticulasCollisionandoConCollider(ParticleSystem particlesSysContraCollider, ParticleCollisionBroadCaster broadCaster);

		// Token: 0x04000607 RID: 1543
		public bool breakOnCollision;

		// Token: 0x04000608 RID: 1544
		protected HitSkinBasica m_HitSkinBasica;

		// Token: 0x04000609 RID: 1545
		protected ParticleSystem m_ParticleSystem;

		// Token: 0x0400060B RID: 1547
		[SerializeField]
		protected List<GameObject> m_targets = new List<GameObject>();

		// Token: 0x02000152 RID: 338
		// (Invoke) Token: 0x060007A7 RID: 1959
		public delegate void OnCollisionHandler(ParticulasParaHitSkin particlesParaSkin, HitSkinBasica skin, ParticleSystem collisionando, ParticleCollisionBroadCaster broadCaster);

		// Token: 0x02000153 RID: 339
		public interface IOnCollisionListiner
		{
			// Token: 0x060007AA RID: 1962
			void OnCollision(GameObject particles, ParticleCollisionBroadCaster broadCaster);
		}
	}
}
