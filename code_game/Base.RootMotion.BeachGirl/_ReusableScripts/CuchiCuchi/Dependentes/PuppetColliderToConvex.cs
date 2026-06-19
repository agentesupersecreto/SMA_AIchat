using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes
{
	// Token: 0x02000052 RID: 82
	public class PuppetColliderToConvex : AplicableBehaviour
	{
		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000375 RID: 885 RVA: 0x000112B2 File Offset: 0x0000F4B2
		public Rigidbody dynamic
		{
			get
			{
				return this.m_dynamic;
			}
		}

		// Token: 0x06000376 RID: 886 RVA: 0x000112BA File Offset: 0x0000F4BA
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
		}

		// Token: 0x06000377 RID: 887 RVA: 0x000112C8 File Offset: 0x0000F4C8
		public void Init(int ownlayer, PuppetMaster puppet, Muscle muscle, GenericReconfigurableJoint.Configuracion config)
		{
			this.Init(ownlayer, puppet, muscle, config, (GameObject g, Collider c) => ExtendedMonoBehaviour.CopyCollider<Collider>(g, c, 1f));
		}

		// Token: 0x06000378 RID: 888 RVA: 0x000112F4 File Offset: 0x0000F4F4
		public void Init(int ownlayer, PuppetMaster puppet, Muscle muscle, GenericReconfigurableJoint.Configuracion config, Func<GameObject, Collider, Collider> colliderCopier)
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
			Transform tDynamic = base.transform.CreateChild(base.transform.name + "_Dynamic");
			Transform transform = base.transform.CreateChild(base.transform.name + "_Kinematic");
			transform.position = (tDynamic.position = muscle.rigidbody.transform.position);
			transform.rotation = (tDynamic.rotation = muscle.rigidbody.transform.rotation);
			TrasnformCopier trasnformCopier = transform.gameObject.AddComponent<TrasnformCopier>();
			trasnformCopier.Init(false, trasnformCopier.transform, muscle.rigidbody.transform, null, null, null);
			transform.gameObject.AddComponent<Rigidbody>().isKinematic = true;
			this.m_dynamic = tDynamic.gameObject.AddComponent<Rigidbody>();
			this.m_puppet = puppet;
			this.m_muscle = muscle;
			foreach (Collider collider in muscle.colliders)
			{
				this.m_Colliders.Add(colliderCopier(tDynamic.gameObject, collider));
			}
			this.m_joint = transform.gameObject.AddComponent<GenericReconfigurableJoint>();
			this.m_joint.SetManualStart();
			this.m_joint.Init(transform, tDynamic, config, false, true);
			this.m_joint.ManualStart();
			base.transform.ExecDeepChild(delegate(Transform tt)
			{
				tDynamic.gameObject.layer = ownlayer;
			}, true);
			this.CalculeMass();
			this.m_joint.FixAdmins();
			puppet.OnWrite = (PuppetMaster.UpdateDelegate)Delegate.Combine(puppet.OnWrite, new PuppetMaster.UpdateDelegate(this.OnPuppetMasterWrite));
			base.Initialize();
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00011525 File Offset: 0x0000F725
		private void OnPuppetMasterWrite()
		{
			if (this.m_lastMuscleMass != this.m_muscle.rigidbody.mass)
			{
				this.OnMassChanged();
			}
		}

		// Token: 0x0600037A RID: 890 RVA: 0x00011545 File Offset: 0x0000F745
		public void CalculeMass()
		{
			this.m_lastMuscleMass = this.m_muscle.rigidbody.mass;
			this.m_joint.bodyAdmin.massAmountMod = this.m_lastMuscleMass / 2f;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00011579 File Offset: 0x0000F779
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.m_joint.FixAdmins();
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0001158C File Offset: 0x0000F78C
		protected virtual void OnMassChanged()
		{
			this.CalculeMass();
			this.m_joint.FixAdmins();
		}

		// Token: 0x0600037D RID: 893 RVA: 0x000115A0 File Offset: 0x0000F7A0
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (!quitting && this.m_puppet != null)
			{
				PuppetMaster puppet = this.m_puppet;
				puppet.OnWrite = (PuppetMaster.UpdateDelegate)Delegate.Remove(puppet.OnWrite, new PuppetMaster.UpdateDelegate(this.OnPuppetMasterWrite));
			}
		}

		// Token: 0x0400025E RID: 606
		private GenericReconfigurableJoint m_joint;

		// Token: 0x0400025F RID: 607
		[SerializeField]
		[ReadOnlyUI]
		private float m_lastMuscleMass;

		// Token: 0x04000260 RID: 608
		[SerializeField]
		[ReadOnlyUI]
		private PuppetMaster m_puppet;

		// Token: 0x04000261 RID: 609
		[SerializeField]
		[ReadOnlyUI]
		private Muscle m_muscle;

		// Token: 0x04000262 RID: 610
		[SerializeField]
		[ReadOnlyUI]
		private List<Collider> m_Colliders = new List<Collider>();

		// Token: 0x04000263 RID: 611
		private Rigidbody m_dynamic;
	}
}
