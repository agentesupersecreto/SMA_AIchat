using System;
using Assets.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.Globales.Updater;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Navigation
{
	// Token: 0x02000379 RID: 889
	public class LookAtNextCornerWhenClose : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x06001615 RID: 5653 RVA: 0x00033A4B File Offset: 0x00031C4B
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update2);
			}
		}

		// Token: 0x06001616 RID: 5654 RVA: 0x00069754 File Offset: 0x00067954
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_SimpleFemaleNavigation = this.GetComponentEnRoot(false);
			if (this.m_SimpleFemaleNavigation == null)
			{
				throw new ArgumentNullException("m_SimpleFemaleNavigation", "m_SimpleFemaleNavigation null reference.");
			}
			this.m_LookAtControllerV2 = this.GetComponentEnRoot(false);
			if (this.m_LookAtControllerV2 == null)
			{
				throw new ArgumentNullException("m_LookAtControllerV2", "m_LookAtControllerV2 null reference.");
			}
			this.m_character = this.GetComponentEnRoot(false);
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_nextCornerProxy = base.transform.CreateChild("nextCornerProxy", true);
			this.m_lastCornerProxy = base.transform.CreateChild("lastCornerProxy", true);
		}

		// Token: 0x06001617 RID: 5655 RVA: 0x00069810 File Offset: 0x00067A10
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_SimpleFemaleNavigation.onNavStarting += this.M_SimpleFemaleNavigation_onNavStarting;
			this.m_SimpleFemaleNavigation.onNavStoped += this.M_SimpleFemaleNavigation_onNavStoped;
		}

		// Token: 0x06001618 RID: 5656 RVA: 0x00069848 File Offset: 0x00067A48
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_SimpleFemaleNavigation != null)
			{
				this.m_SimpleFemaleNavigation.onNavStarting -= this.M_SimpleFemaleNavigation_onNavStarting;
				this.m_SimpleFemaleNavigation.onNavStoped -= this.M_SimpleFemaleNavigation_onNavStoped;
			}
		}

		// Token: 0x06001619 RID: 5657 RVA: 0x00069898 File Offset: 0x00067A98
		private void M_SimpleFemaleNavigation_onNavStarting(SimpleFemaleNavigation.InstanciaDeNavegacion Navigation)
		{
			if (!(Navigation is SimpleFemaleNavigation.ICornerNavegacion))
			{
				return;
			}
			this.m_canChangeMirarCornerCoolDown.Reset();
			LookAtControllerV2.Orden orden;
			if (this.m_LookAtControllerV2.currentStado.Ejecutandose(0, out orden))
			{
				LookAtTarget ojosTarget = orden.ojosTarget;
				Transform transform;
				if ((transform = ((ojosTarget != null) ? ojosTarget.transform : null)) == null)
				{
					LookAtTarget headTarget = orden.headTarget;
					transform = ((headTarget != null) ? headTarget.transform : null);
				}
				this.m_targetBeforeNav = transform;
				LookAtTarget lookAtTarget = orden.ojosTarget ?? orden.headTarget;
				this.m_targetOffsetBeforeNav = ((lookAtTarget != null) ? new Vector3?(lookAtTarget.vector) : null).GetValueOrDefault();
				if (this.m_targetBeforeNav == this.m_nextCornerProxy || this.m_targetBeforeNav == this.m_lastCornerProxy)
				{
					this.m_targetBeforeNav = null;
					this.m_targetOffsetBeforeNav = Vector3.zero;
				}
			}
		}

		// Token: 0x0600161A RID: 5658 RVA: 0x0006996E File Offset: 0x00067B6E
		private void M_SimpleFemaleNavigation_onNavStoped(SimpleFemaleNavigation.InstanciaDeNavegacion Navigation)
		{
			if (this.CanRestoreLookAt())
			{
				this.RestoreLookAt();
			}
		}

		// Token: 0x0600161B RID: 5659 RVA: 0x0006997F File Offset: 0x00067B7F
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_nextCornerProxy != null)
			{
				Object.Destroy(this.m_nextCornerProxy);
			}
			if (this.m_lastCornerProxy != null)
			{
				Object.Destroy(this.m_lastCornerProxy);
			}
		}

		// Token: 0x0600161C RID: 5660 RVA: 0x000699BC File Offset: 0x00067BBC
		private bool CanRestoreLookAt()
		{
			LookAtControllerV2.Orden orden;
			return this.m_targetBeforeNav != null && this.m_LookAtControllerV2.currentStado.Ejecutandose(0, out orden) && (orden.headTarget.transform == this.m_nextCornerProxy || orden.headTarget.transform == this.m_lastCornerProxy);
		}

		// Token: 0x0600161D RID: 5661 RVA: 0x00069A20 File Offset: 0x00067C20
		private bool RestoreLookAt()
		{
			this.m_LookAtControllerV2.TryDejarDeMirar(this.m_nextCornerProxy, true);
			this.m_LookAtControllerV2.TryDejarDeMirar(this.m_lastCornerProxy, true);
			bool flag = this.m_LookAtControllerV2.Mirar(0.9f, 0.9f, this.m_targetBeforeNav, LookAtControllerV2.LookAtType.fijamente, true, LookAtControllerV2.LookAtType.fijamente, true, 0.5f, int.MaxValue, 5f, ControllerPrioridadConfig.prioridad, this.m_targetOffsetBeforeNav, true, 2f);
			if (flag)
			{
				this.m_targetBeforeNav = null;
				this.m_targetOffsetBeforeNav = Vector3.zero;
			}
			return flag;
		}

		// Token: 0x0600161E RID: 5662 RVA: 0x00069AA4 File Offset: 0x00067CA4
		private bool ClearLookAt()
		{
			bool flag = this.m_LookAtControllerV2.TryDejarDeMirar(this.m_nextCornerProxy, true);
			bool flag2 = this.m_LookAtControllerV2.TryDejarDeMirar(this.m_lastCornerProxy, true);
			return flag || flag2;
		}

		// Token: 0x0600161F RID: 5663 RVA: 0x00069AD8 File Offset: 0x00067CD8
		public override void OnUpdateEvent1()
		{
			if (this.m_canChangeMirarCornerCoolDown.isOn)
			{
				return;
			}
			SimpleFemaleNavigation.ICornerNavegacion cornerNavegacion = this.m_SimpleFemaleNavigation.currentNavigation as SimpleFemaleNavigation.ICornerNavegacion;
			if (!this.IsValidNav(cornerNavegacion))
			{
				return;
			}
			bool flag = this.IsFirstCorner(cornerNavegacion);
			bool flag2 = this.IsLastCorner(cornerNavegacion);
			bool flag3 = (double)cornerNavegacion.distanceToEndCorner > (double)this.m_character.estatura * 0.2;
			bool flag4 = (double)cornerNavegacion.distanceToNextCorner > (double)this.m_character.estatura * 0.3;
			bool flag5 = !flag4;
			bool flag6 = flag && flag3;
			bool flag7 = cornerNavegacion.currentCornerIndex < cornerNavegacion.corners.Count;
			flag7 &= cornerNavegacion.angleToNextCorner > 45f || cornerNavegacion.angleToNextNextCorner > 45f;
			flag7 = flag7 && flag4;
			bool flag8 = this.CanRestoreLookAt();
			flag8 = flag8 && flag5;
			bool flag9 = flag2 || flag5;
			bool flag10;
			if (flag6)
			{
				Vector3 vector = cornerNavegacion.corners[cornerNavegacion.corners.Count - 1];
				this.m_lastCornerProxy.position = vector + Vector3.up * this.m_character.estatura * 0.55f;
				flag10 = this.m_LookAtControllerV2.Mirar(0.75f, 0.75f, this.m_lastCornerProxy, LookAtControllerV2.LookAtType.fijamente, true, LookAtControllerV2.LookAtType.fijamente, true, 1f, int.MaxValue, 3f, ControllerPrioridadConfig.prioridad, default(Vector3), true, 2f);
			}
			else if (flag7)
			{
				Vector3 vector2 = cornerNavegacion.corners[cornerNavegacion.currentCornerIndex];
				this.m_nextCornerProxy.position = vector2 + Vector3.up * this.m_character.estatura * 0.66f;
				flag10 = this.m_LookAtControllerV2.Mirar(0.75f, 0.75f, this.m_nextCornerProxy, LookAtControllerV2.LookAtType.fijamente, true, LookAtControllerV2.LookAtType.fijamente, true, 1f, int.MaxValue, 3f, ControllerPrioridadConfig.prioridad, default(Vector3), true, 2f);
			}
			else if (flag8)
			{
				flag10 = this.RestoreLookAt();
			}
			else
			{
				flag10 = flag9 && this.ClearLookAt();
			}
			if (flag10)
			{
				this.m_canChangeMirarCornerCoolDown.Apply();
			}
		}

		// Token: 0x06001620 RID: 5664 RVA: 0x00069D06 File Offset: 0x00067F06
		public bool IsValidNav(SimpleFemaleNavigation.ICornerNavegacion currentNav)
		{
			return currentNav != null && !currentNav.finished && currentNav.corners.Count != 0 && currentNav.corners.ContieneIndexReadOnly(currentNav.currentCornerIndex);
		}

		// Token: 0x06001621 RID: 5665 RVA: 0x00069D36 File Offset: 0x00067F36
		public bool IsFirstCorner(SimpleFemaleNavigation.ICornerNavegacion currentNav)
		{
			return currentNav.currentCornerIndex <= 0;
		}

		// Token: 0x06001622 RID: 5666 RVA: 0x00069D44 File Offset: 0x00067F44
		public bool IsLastCorner(SimpleFemaleNavigation.ICornerNavegacion currentNav)
		{
			if (currentNav.currentCornerIndex == currentNav.corners.Count - 1)
			{
				float num = this.m_character.estatura * this.config.statureToStartLookingAtPlayer;
				return (currentNav.corners[currentNav.corners.Count - 1] - this.m_character.bodyAnimator.transform.position).magnitude <= num;
			}
			return false;
		}

		// Token: 0x04000FF0 RID: 4080
		private SimpleFemaleNavigation m_SimpleFemaleNavigation;

		// Token: 0x04000FF1 RID: 4081
		private LookAtControllerV2 m_LookAtControllerV2;

		// Token: 0x04000FF2 RID: 4082
		private ICharacter m_character;

		// Token: 0x04000FF3 RID: 4083
		public LookAtNextCornerWhenClose.Config config = new LookAtNextCornerWhenClose.Config();

		// Token: 0x04000FF4 RID: 4084
		private Transform m_nextCornerProxy;

		// Token: 0x04000FF5 RID: 4085
		private Transform m_lastCornerProxy;

		// Token: 0x04000FF6 RID: 4086
		[NonSerialized]
		private CoolDown m_canChangeMirarCornerCoolDown = new CoolDown(0.25f);

		// Token: 0x04000FF7 RID: 4087
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_targetBeforeNav;

		// Token: 0x04000FF8 RID: 4088
		[SerializeField]
		[ReadOnlyUI]
		private Vector3 m_targetOffsetBeforeNav;

		// Token: 0x0200037A RID: 890
		[Serializable]
		public class Config
		{
			// Token: 0x04000FF9 RID: 4089
			public float statureToStartLookingAtPlayer = 0.333f;
		}
	}
}
