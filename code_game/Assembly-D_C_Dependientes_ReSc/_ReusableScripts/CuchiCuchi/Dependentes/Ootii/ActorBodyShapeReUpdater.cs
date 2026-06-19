using System;
using Assets._ReusableScripts.Globales.Updater;
using com.ootii.Actors;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii
{
	// Token: 0x0200015D RID: 349
	public class ActorBodyShapeReUpdater : AplicableBehaviour
	{
		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x00026500 File Offset: 0x00024700
		public override int updateEvent1Index
		{
			get
			{
				return (int)this.updateEvent;
			}
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x00026508 File Offset: 0x00024708
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_actor = base.GetComponentInChildren<ActorController>();
			this.m_actor.stared += this.M_actor_stared;
			if (this.m_actor == null)
			{
				throw new ArgumentNullException("m_actor", "m_actor null reference.");
			}
			this.anim = this.GetComponentEnCharacter(false);
			this.suelo = this.anim.transform.CreateChild("TRansform_ActorBodyShapeReUpdater");
			this.head = this.anim.GetBoneTransform(HumanBodyBones.Head);
			this.hips = this.anim.GetBoneTransform(HumanBodyBones.Hips);
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x000265AC File Offset: 0x000247AC
		private void M_actor_stared(ActorController obj)
		{
			this.UpdatePosition();
			for (int i = 0; i < this.m_actor.BodyShapes.Count; i++)
			{
				BodyCapsule bodyCapsule = this.m_actor.BodyShapes[i] as BodyCapsule;
				if (bodyCapsule != null && bodyCapsule.Transform != this.suelo)
				{
					bodyCapsule.Transform = this.suelo;
				}
			}
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x00026613 File Offset: 0x00024813
		public void UpdateEventType()
		{
			base.ReSubscribeToGlobalUpdater();
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x0002661C File Offset: 0x0002481C
		private void UpdatePosition()
		{
			Vector3 vector = Math3d.ProjectPointOnPlane(this.anim.transform.up, this.anim.transform.position, this.hips.position);
			this.suelo.SetPositionAndRotation(vector, this.anim.transform.rotation);
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00026678 File Offset: 0x00024878
		public sealed override void OnUpdateEvent1()
		{
			if (!this.m_actor._IsEnabled)
			{
				return;
			}
			this.UpdatePosition();
			for (int i = 0; i < this.m_actor.BodyShapes.Count; i++)
			{
				this.m_actor.BodyShapes[i].LateUpdate();
			}
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x000266CA File Offset: 0x000248CA
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Reaccignar Evento de Update",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x000266E3 File Offset: 0x000248E3
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.UpdateEventType();
		}

		// Token: 0x040005BB RID: 1467
		public GlobalUpdater.UpdateType updateEvent = GlobalUpdater.UpdateType.lateUpdateAfterMalePupetMaster;

		// Token: 0x040005BC RID: 1468
		private ActorController m_actor;

		// Token: 0x040005BD RID: 1469
		private Transform suelo;

		// Token: 0x040005BE RID: 1470
		private Transform head;

		// Token: 0x040005BF RID: 1471
		private Transform hips;

		// Token: 0x040005C0 RID: 1472
		private Animator anim;
	}
}
