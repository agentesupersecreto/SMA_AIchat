using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using com.ootii.Actors.AnimationControllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii.Inputs
{
	// Token: 0x02000165 RID: 357
	public class PausePlayerInputs : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700019D RID: 413
		// (get) Token: 0x060007BE RID: 1982 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x060007BF RID: 1983 RVA: 0x00028599 File Offset: 0x00026799
		public ModificableDeBool puedeMoverseModificable
		{
			get
			{
				return this.m_puedeMoverseModificable;
			}
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x000285A4 File Offset: 0x000267A4
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_character = base.GetComponentInParent<Character>();
			this.motionController = this.m_character.GetComponentInChildren<MotionController>();
			this.m_controllerActivable = this.m_character.GetComponentInChildren<MotionAndActorControllerActivable>();
			if (this.m_controllerActivable == null)
			{
				throw new ArgumentNullException("m_controllerActivable", "m_controllerActivable null reference.");
			}
			this.m_MotionAndActorEstanDesactivos = this.m_controllerActivable.estanDesactivadosModificable.ObtenerModificadorNotNull(this);
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x00006E52 File Offset: 0x00005052
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x00006E5A File Offset: 0x0000505A
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x0002861A File Offset: 0x0002681A
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeBool motionAndActorEstanDesactivos = this.m_MotionAndActorEstanDesactivos;
			if (motionAndActorEstanDesactivos == null)
			{
				return;
			}
			motionAndActorEstanDesactivos.TryRemoverDeOwner(true);
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x00028638 File Offset: 0x00026838
		public override void OnUpdateEvent1()
		{
			bool flag = this.m_puedeMoverseModificable.And(this.m_puedeMoverse);
			this.m_Blockeando = !flag;
			if (this.m_lastBlockeando != null)
			{
				bool blockeando = this.m_Blockeando;
				bool? lastBlockeando = this.m_lastBlockeando;
				if ((blockeando == lastBlockeando.GetValueOrDefault()) & (lastBlockeando != null))
				{
					return;
				}
			}
			this.m_lastBlockeando = new bool?(this.m_Blockeando);
			if (this.m_Blockeando)
			{
				this.onBlockeandoStart();
				return;
			}
			this.onBlockeandoEnds();
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x000286B4 File Offset: 0x000268B4
		private void onBlockeandoStart()
		{
			if (Singleton<PlayerInputProxy>.IsInScene)
			{
				Singleton<PlayerInputProxy>.instance.activoMovement = false;
				Singleton<PlayerInputProxy>.instance.activoAction = false;
			}
			this.m_MotionAndActorEstanDesactivos.valor.valor = true;
			this.m_controllerActivable.Actualizar();
			this.motionController.Animator.SetFloat("InputY", 0f);
			this.motionController.Animator.SetFloat("InputMagnitude", 0f);
			this.motionController.Animator.SetFloat("InputMagnitudeAvg", 0f);
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x00028748 File Offset: 0x00026948
		private void onBlockeandoEnds()
		{
			if (Singleton<PlayerInputProxy>.IsInScene)
			{
				Singleton<PlayerInputProxy>.instance.activoMovement = true;
				Singleton<PlayerInputProxy>.instance.activoAction = true;
			}
			this.m_MotionAndActorEstanDesactivos.valor.valor = false;
		}

		// Token: 0x0400060D RID: 1549
		[SerializeField]
		private ModificableDeBool m_puedeMoverseModificable = new ModificableDeBool(true);

		// Token: 0x0400060E RID: 1550
		[SerializeField]
		private bool m_puedeMoverse = true;

		// Token: 0x0400060F RID: 1551
		[ReadOnlyUI]
		[SerializeField]
		private bool m_Blockeando;

		// Token: 0x04000610 RID: 1552
		private bool? m_lastBlockeando;

		// Token: 0x04000611 RID: 1553
		private Character m_character;

		// Token: 0x04000612 RID: 1554
		private MotionController motionController;

		// Token: 0x04000613 RID: 1555
		private MotionAndActorControllerActivable m_controllerActivable;

		// Token: 0x04000614 RID: 1556
		private ModificadorDeBool m_MotionAndActorEstanDesactivos;
	}
}
