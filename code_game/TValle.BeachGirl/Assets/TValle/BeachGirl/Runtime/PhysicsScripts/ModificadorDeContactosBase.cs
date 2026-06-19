using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Globales.Updater;
using Unity.Collections;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts
{
	// Token: 0x02000075 RID: 117
	public abstract class ModificadorDeContactosBase<TSystema, TUser, TData> : Singleton<TSystema> where TSystema : ModificadorDeContactosBase<TSystema, TUser, TData> where TUser : ModificadorDeContactosUserBase<TData> where TData : struct
	{
		// Token: 0x06000291 RID: 657 RVA: 0x00007EA4 File Offset: 0x000060A4
		public void Add(TUser user)
		{
			if (this.m_usuarios.Add(user))
			{
				int instanceID = user.GetInstanceID();
				this.m_dataDeUserID.Add(instanceID, default(TData));
				for (int i = 0; i < user.colliders.Count; i++)
				{
					Collider collider = user.colliders[i];
					collider.hasModifiableContacts = true;
					int instanceID2 = collider.GetInstanceID();
					if (this.m_collidersIds.Add(instanceID2))
					{
						this.m_colliderToUserID.Add(instanceID2, instanceID);
					}
				}
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00007F34 File Offset: 0x00006134
		public void Remove(TUser user)
		{
			this.m_usuarios.Remove(user);
			this.m_dataDeUserID.Remove(user.GetInstanceID());
			for (int i = 0; i < user.colliders.Count; i++)
			{
				int instanceID = user.colliders[i].GetInstanceID();
				this.m_collidersIds.Remove(instanceID);
				this.m_colliderToUserID.Remove(instanceID);
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00007FB4 File Offset: 0x000061B4
		protected override void Initiated()
		{
			base.Initiated();
			GlobalUpdater.instancia.beforePhysics -= this.Instancia_beforePhysics;
			GlobalUpdater.instancia.beforePhysics += this.Instancia_beforePhysics;
			Physics.ContactModifyEvent -= this.Physics_ContactModifyEvent;
			Physics.ContactModifyEvent += this.Physics_ContactModifyEvent;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00008017 File Offset: 0x00006217
		protected override void OnDestroyed(bool wasInitiated)
		{
			base.OnDestroyed(wasInitiated);
			if (GlobalUpdater.IsInScene)
			{
				GlobalUpdater.instancia.beforePhysics -= this.Instancia_beforePhysics;
			}
			Physics.ContactModifyEvent -= this.Physics_ContactModifyEvent;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00008050 File Offset: 0x00006250
		private void Instancia_beforePhysics()
		{
			foreach (TUser tuser in this.m_usuarios)
			{
				tuser.UpdateData();
				this.m_dataDeUserID[tuser.GetInstanceID()] = tuser.data;
			}
		}

		// Token: 0x06000296 RID: 662
		protected abstract void Physics_ContactModifyEvent(PhysicsScene arg1, NativeArray<ModifiableContactPair> arg2);

		// Token: 0x040001A1 RID: 417
		private HashSet<TUser> m_usuarios = new HashSet<TUser>();

		// Token: 0x040001A2 RID: 418
		protected HashSet<int> m_collidersIds = new HashSet<int>();

		// Token: 0x040001A3 RID: 419
		protected Dictionary<int, string> m_colliderToName = new Dictionary<int, string>();

		// Token: 0x040001A4 RID: 420
		protected Dictionary<int, int> m_colliderToUserID = new Dictionary<int, int>();

		// Token: 0x040001A5 RID: 421
		protected Dictionary<int, TData> m_dataDeUserID = new Dictionary<int, TData>();
	}
}
