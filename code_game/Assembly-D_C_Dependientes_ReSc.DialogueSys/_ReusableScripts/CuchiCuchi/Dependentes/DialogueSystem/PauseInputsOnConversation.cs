using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii;
using com.ootii.Actors.AnimationControllers;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x0200001B RID: 27
	public sealed class PauseInputsOnConversation : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x0000557D File Offset: 0x0000377D
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00005580 File Offset: 0x00003780
		public ModificableDeBool puedeMoverseEnConversacionModificable
		{
			get
			{
				return this.m_puedeMoverseEnConversacionModificable;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x00005588 File Offset: 0x00003788
		[Obsolete("", true)]
		public bool blockeando
		{
			get
			{
				return !this.ignorarEnConversacion && this.conversando;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x0000559C File Offset: 0x0000379C
		public bool conversando
		{
			get
			{
				if (DialogueManager.IsConversationActive)
				{
					Transform currentActor = DialogueManager.CurrentActor;
					Transform currentConversant = DialogueManager.CurrentConversant;
					if ((currentConversant != null && currentConversant.IsChildOf(this.m_character.transform)) || (currentActor != null && currentActor.IsChildOf(this.m_character.transform)))
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000055F8 File Offset: 0x000037F8
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

		// Token: 0x060000F9 RID: 249 RVA: 0x0000566E File Offset: 0x0000386E
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00005676 File Offset: 0x00003876
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.onConversationEnds();
			this.m_lastBlockeando = null;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00005691 File Offset: 0x00003891
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

		// Token: 0x060000FC RID: 252 RVA: 0x000056AC File Offset: 0x000038AC
		public override void OnUpdateEvent1()
		{
			this.m_Blockeando = !this.m_puedeMoverseEnConversacionModificable.Or(this.m_puedeMoverseEnConversacion) && this.conversando;
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
				this.onConversationStart();
				return;
			}
			this.onConversationEnds();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00005730 File Offset: 0x00003930
		private void onConversationStart()
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

		// Token: 0x060000FE RID: 254 RVA: 0x000057C4 File Offset: 0x000039C4
		private void onConversationEnds()
		{
			if (Singleton<PlayerInputProxy>.IsInScene)
			{
				Singleton<PlayerInputProxy>.instance.activoMovement = true;
				Singleton<PlayerInputProxy>.instance.activoAction = true;
			}
			this.m_MotionAndActorEstanDesactivos.valor.valor = false;
		}

		// Token: 0x0400006E RID: 110
		[SerializeField]
		private ModificableDeBool m_puedeMoverseEnConversacionModificable = new ModificableDeBool(false);

		// Token: 0x0400006F RID: 111
		[SerializeField]
		private bool m_puedeMoverseEnConversacion;

		// Token: 0x04000070 RID: 112
		[Obsolete("", true)]
		public bool ignorarEnConversacion;

		// Token: 0x04000071 RID: 113
		[ReadOnlyUI]
		[SerializeField]
		private bool m_Blockeando;

		// Token: 0x04000072 RID: 114
		private bool? m_lastBlockeando;

		// Token: 0x04000073 RID: 115
		private Character m_character;

		// Token: 0x04000074 RID: 116
		private MotionController motionController;

		// Token: 0x04000075 RID: 117
		private MotionAndActorControllerActivable m_controllerActivable;

		// Token: 0x04000076 RID: 118
		private ModificadorDeBool m_MotionAndActorEstanDesactivos;
	}
}
