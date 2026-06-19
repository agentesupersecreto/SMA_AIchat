using System;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Penes.Historiales
{
	// Token: 0x0200008F RID: 143
	public class PuntaDeJeringaColisionable : CustomMonobehaviour, IEmualtedColisionable
	{
		// Token: 0x1400003C RID: 60
		// (add) Token: 0x060005B4 RID: 1460 RVA: 0x00021830 File Offset: 0x0001FA30
		// (remove) Token: 0x060005B5 RID: 1461 RVA: 0x00021868 File Offset: 0x0001FA68
		public event Action<IColisionEmuladaData> onContact;

		// Token: 0x060005B6 RID: 1462 RVA: 0x0002189D File Offset: 0x0001FA9D
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x000218B4 File Offset: 0x0001FAB4
		public void Init(IStepVelocitySaverEmulated ownSaver, CapsuleCollider agujaCollider)
		{
			if (agujaCollider == null)
			{
				throw new ArgumentNullException("agujaCollider", "agujaCollider null reference.");
			}
			if (ownSaver == null)
			{
				throw new ArgumentNullException("ownSaver", "ownSaver null reference.");
			}
			this.m_ownSaver = ownSaver;
			this.m_agujaCollider = agujaCollider;
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x00021907 File Offset: 0x0001FB07
		private void OnTriggerEnter(Collider other)
		{
			this.OnTrigger(other);
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x00021910 File Offset: 0x0001FB10
		private void OnTriggerStay(Collider other)
		{
			this.OnTrigger(other);
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x0002191C File Offset: 0x0001FB1C
		private void OnTrigger(Collider other)
		{
			try
			{
				Transform transform = this.m_agujaCollider.transform;
				float height = this.m_agujaCollider.height;
				Vector3 forward = transform.forward;
				Vector3 position = transform.position;
				Vector3 vector = position - forward * height;
				RaycastHit raycastHit;
				if (other.Raycast(new Ray(vector, forward), out raycastHit, height * 1.01f) || other.Raycast(new Ray(position, -forward), out raycastHit, height * 1.01f))
				{
					this.m_eventArgs.otherCollider = other;
					this.m_eventArgs.ownCollider = this.m_agujaCollider;
					this.m_eventArgs.ownSaver = this.m_ownSaver;
					this.m_eventArgs.point = raycastHit.point;
					this.m_eventArgs.normal = raycastHit.normal;
					Action<IColisionEmuladaData> action = this.onContact;
					if (action != null)
					{
						action(this.m_eventArgs);
					}
				}
			}
			finally
			{
				this.m_eventArgs.Clear();
			}
		}

		// Token: 0x04000393 RID: 915
		private IStepVelocitySaverEmulated m_ownSaver;

		// Token: 0x04000394 RID: 916
		private CapsuleCollider m_agujaCollider;

		// Token: 0x04000396 RID: 918
		private PuntaDeJeringaColisionable.ColisionEmuladaData m_eventArgs = new PuntaDeJeringaColisionable.ColisionEmuladaData();

		// Token: 0x02000215 RID: 533
		public class ColisionEmuladaData : IColisionEmuladaPreQueryData, IColisionEmuladaData
		{
			// Token: 0x17000287 RID: 647
			// (get) Token: 0x06000FCE RID: 4046 RVA: 0x0004D73B File Offset: 0x0004B93B
			// (set) Token: 0x06000FCF RID: 4047 RVA: 0x0004D743 File Offset: 0x0004B943
			public IStepVelocitySaverEmulated ownSaver { get; set; }

			// Token: 0x17000288 RID: 648
			// (get) Token: 0x06000FD0 RID: 4048 RVA: 0x0004D74C File Offset: 0x0004B94C
			// (set) Token: 0x06000FD1 RID: 4049 RVA: 0x0004D754 File Offset: 0x0004B954
			public Collider ownCollider { get; set; }

			// Token: 0x17000289 RID: 649
			// (get) Token: 0x06000FD2 RID: 4050 RVA: 0x0004D75D File Offset: 0x0004B95D
			// (set) Token: 0x06000FD3 RID: 4051 RVA: 0x0004D765 File Offset: 0x0004B965
			public Collider otherCollider { get; set; }

			// Token: 0x1700028A RID: 650
			// (get) Token: 0x06000FD4 RID: 4052 RVA: 0x0004D76E File Offset: 0x0004B96E
			// (set) Token: 0x06000FD5 RID: 4053 RVA: 0x0004D776 File Offset: 0x0004B976
			public Vector3 point { get; set; }

			// Token: 0x1700028B RID: 651
			// (get) Token: 0x06000FD6 RID: 4054 RVA: 0x0004D77F File Offset: 0x0004B97F
			// (set) Token: 0x06000FD7 RID: 4055 RVA: 0x0004D787 File Offset: 0x0004B987
			public Vector3 normal { get; set; }

			// Token: 0x06000FD8 RID: 4056 RVA: 0x0004D790 File Offset: 0x0004B990
			public void Clear()
			{
				this.ownSaver = null;
				this.ownCollider = null;
				this.otherCollider = null;
			}
		}
	}
}
