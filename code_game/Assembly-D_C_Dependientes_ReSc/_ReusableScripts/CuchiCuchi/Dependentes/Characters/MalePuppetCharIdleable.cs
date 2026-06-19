using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.Globales.Clases;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x02000230 RID: 560
	public sealed class MalePuppetCharIdleable : CustomUpdatedMonobehaviourBase, IMaleCharacterIdleable, ICharacterIdleable
	{
		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06000EE0 RID: 3808 RVA: 0x0000B284 File Offset: 0x00009484
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x06000EE1 RID: 3809 RVA: 0x00042236 File Offset: 0x00040436
		public bool idle
		{
			get
			{
				return this.m_idle;
			}
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x06000EE2 RID: 3810 RVA: 0x0004223E File Offset: 0x0004043E
		public float desarrollandoActividadPor
		{
			get
			{
				return this.m_desarrollandoActividadPor;
			}
		}

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x06000EE3 RID: 3811 RVA: 0x00042246 File Offset: 0x00040446
		public float idlePor
		{
			get
			{
				return this.m_idlePor;
			}
		}

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x06000EE4 RID: 3812 RVA: 0x0004224E File Offset: 0x0004044E
		public bool handEsIdle
		{
			get
			{
				return !this.m_usaHandController || this.m_handEsIdle;
			}
		}

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06000EE5 RID: 3813 RVA: 0x00042260 File Offset: 0x00040460
		public bool pelvisEsIdle
		{
			get
			{
				return !this.m_usaPelvisController || this.m_pelvisEsIdle;
			}
		}

		// Token: 0x06000EE6 RID: 3814 RVA: 0x00042274 File Offset: 0x00040474
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_HandController = this.GetComponentEnRoot(false);
			this.m_PelvisMovementController = this.GetComponentEnRoot(false);
			this.m_ICharacterHablador = this.GetComponentEnRoot(false);
			this.m_ICharacterConversador = this.GetComponentEnRoot(false);
			this.m_usaHandController = this.m_HandController != null;
			this.m_usaPelvisController = this.m_PelvisMovementController != null;
			this.m_charEsHablador = this.m_ICharacterHablador != null;
			this.m_charEsConversador = this.m_ICharacterConversador != null;
		}

		// Token: 0x06000EE7 RID: 3815 RVA: 0x000422FD File Offset: 0x000404FD
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.Clear();
		}

		// Token: 0x06000EE8 RID: 3816 RVA: 0x0004230B File Offset: 0x0004050B
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.Clear();
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x0004231C File Offset: 0x0004051C
		private void Clear()
		{
			this.m_idlePor = 0f;
			this.m_desarrollandoActividadPor = 0f;
			this.m_pelvisEsIdle = (this.m_handEsIdle = (this.m_lastIdle = (this.m_idle = true)));
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x00042364 File Offset: 0x00040564
		public override void OnUpdateEvent1()
		{
			InputProxyVirtuales characterMovement = Singleton<PlayerInputProxy>.instance.characterMovement;
			this.m_handEsIdle = (this.m_pelvisEsIdle = true);
			if (this.m_usaHandController && this.m_HandController.isMovingHand)
			{
				this.m_handEsIdle = false;
			}
			if (this.m_usaPelvisController && this.m_PelvisMovementController.isMovingPelvis)
			{
				this.m_pelvisEsIdle = false;
			}
			if (!this.m_handEsIdle || !this.m_pelvisEsIdle)
			{
				this.m_idle = false;
			}
			else if (characterMovement.isTraslating)
			{
				this.m_pelvisEsIdle = (this.m_idle = false);
			}
			else if (this.m_charEsHablador && this.m_ICharacterHablador.estaHablando)
			{
				this.m_idle = false;
			}
			else if (this.m_charEsConversador && this.m_ICharacterConversador.estaConversando)
			{
				this.m_idle = false;
			}
			else
			{
				this.m_idle = true;
			}
			if (this.m_idle != this.m_lastIdle)
			{
				if (this.m_idle)
				{
					this.m_desarrollandoActividadPor = 0f;
				}
				else
				{
					this.m_idlePor = 0f;
				}
				this.m_lastIdle = this.m_idle;
				return;
			}
			if (this.m_idle)
			{
				this.m_idlePor += Time.deltaTime;
				return;
			}
			this.m_desarrollandoActividadPor += Time.deltaTime;
		}

		// Token: 0x04000A0F RID: 2575
		[SerializeField]
		[ReadOnlyUI]
		private bool m_handEsIdle = true;

		// Token: 0x04000A10 RID: 2576
		[SerializeField]
		[ReadOnlyUI]
		private bool m_pelvisEsIdle = true;

		// Token: 0x04000A11 RID: 2577
		[SerializeField]
		[ReadOnlyUI]
		private bool m_idle = true;

		// Token: 0x04000A12 RID: 2578
		[SerializeField]
		[ReadOnlyUI]
		private bool m_lastIdle = true;

		// Token: 0x04000A13 RID: 2579
		[SerializeField]
		[ReadOnlyUI]
		private float m_desarrollandoActividadPor;

		// Token: 0x04000A14 RID: 2580
		[SerializeField]
		[ReadOnlyUI]
		private float m_idlePor;

		// Token: 0x04000A15 RID: 2581
		[SerializeField]
		[ReadOnlyUI]
		private bool m_usaHandController;

		// Token: 0x04000A16 RID: 2582
		[SerializeField]
		[ReadOnlyUI]
		private bool m_usaPelvisController;

		// Token: 0x04000A17 RID: 2583
		[SerializeField]
		[ReadOnlyUI]
		private bool m_charEsHablador;

		// Token: 0x04000A18 RID: 2584
		[SerializeField]
		[ReadOnlyUI]
		private bool m_charEsConversador;

		// Token: 0x04000A19 RID: 2585
		private HandControllerV2 m_HandController;

		// Token: 0x04000A1A RID: 2586
		private PelvisMovementController m_PelvisMovementController;

		// Token: 0x04000A1B RID: 2587
		private ICharacterHablador m_ICharacterHablador;

		// Token: 0x04000A1C RID: 2588
		private ICharacterConversador m_ICharacterConversador;
	}
}
