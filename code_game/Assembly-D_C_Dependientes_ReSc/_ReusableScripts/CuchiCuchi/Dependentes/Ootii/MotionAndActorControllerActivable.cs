using System;
using Assets._ReusableScripts.Globales.Updater;
using com.ootii.Actors;
using com.ootii.Actors.AnimationControllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii
{
	// Token: 0x02000161 RID: 353
	public class MotionAndActorControllerActivable : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700017B RID: 379
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x0000B284 File Offset: 0x00009484
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x0600075E RID: 1886 RVA: 0x00026EC1 File Offset: 0x000250C1
		public ModificableDeBool estanForzadamenteActivosModificable
		{
			get
			{
				return this.m_estanForzadamenteActivosModificable;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x00026EC9 File Offset: 0x000250C9
		public ModificableDeBool estanDesactivadosModificable
		{
			get
			{
				return this.m_estanDesactivadosModificable;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000760 RID: 1888 RVA: 0x00026ED1 File Offset: 0x000250D1
		public MotionController motionController
		{
			get
			{
				return this.m_motionController;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x00026ED9 File Offset: 0x000250D9
		public ActorController actorController
		{
			get
			{
				return this.m_actorController;
			}
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x00026EE4 File Offset: 0x000250E4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_motionController = base.GetComponentInChildren<MotionController>();
			this.m_actorController = base.GetComponentInChildren<ActorController>();
			if (this.m_motionController == null)
			{
				Debug.LogWarning("No MotionController found on OotiiPuppet.cs GameObject. Please add OotiiPuppet.cs to the same Gameobject as the MotionController.", base.transform);
				return;
			}
			if (this.m_actorController == null)
			{
				Debug.LogWarning("No ActorController found on OotiiPuppet.cs GameObject. Please add OotiiPuppet.cs to the same Gameobject as the ActorController.", base.transform);
				return;
			}
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x00026F4D File Offset: 0x0002514D
		public override void OnUpdateEvent1()
		{
			this.Actualizar();
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x00026F58 File Offset: 0x00025158
		public void Actualizar()
		{
			bool flag = this.m_estanForzadamenteActivosModificable.Or(false) || !this.m_estanDesactivadosModificable.Or(false);
			this.m_motionController.enabled = (this.m_actorController.enabled = flag);
			if (!flag)
			{
				this.motionController.Animator.SetFloat("InputY", 0f);
				this.motionController.Animator.SetFloat("InputMagnitude", 0f);
				this.motionController.Animator.SetFloat("InputMagnitudeAvg", 0f);
			}
		}

		// Token: 0x040005D3 RID: 1491
		[SerializeField]
		private ModificableDeBool m_estanForzadamenteActivosModificable = new ModificableDeBool(false);

		// Token: 0x040005D4 RID: 1492
		[SerializeField]
		private ModificableDeBool m_estanDesactivadosModificable = new ModificableDeBool(false);

		// Token: 0x040005D5 RID: 1493
		private MotionController m_motionController;

		// Token: 0x040005D6 RID: 1494
		private ActorController m_actorController;
	}
}
