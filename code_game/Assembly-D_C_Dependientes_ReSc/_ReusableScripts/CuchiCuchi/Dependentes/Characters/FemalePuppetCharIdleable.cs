using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.AutoSex;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x0200022C RID: 556
	public sealed class FemalePuppetCharIdleable : CustomUpdatedMonobehaviourBase, IFemaleCharacterIdleable, ICharacterIdleable
	{
		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06000E89 RID: 3721 RVA: 0x0000B284 File Offset: 0x00009484
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06000E8A RID: 3722 RVA: 0x00040A3B File Offset: 0x0003EC3B
		public bool idle
		{
			get
			{
				return this.m_idle;
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06000E8B RID: 3723 RVA: 0x00040A43 File Offset: 0x0003EC43
		public float desarrollandoActividadPor
		{
			get
			{
				return this.m_desarrollandoActividadPor;
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06000E8C RID: 3724 RVA: 0x00040A4B File Offset: 0x0003EC4B
		public float idlePor
		{
			get
			{
				return this.m_idlePor;
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06000E8D RID: 3725 RVA: 0x00040A53 File Offset: 0x0003EC53
		public bool headEsIdle
		{
			get
			{
				return !this.m_usaAutoSexController || !this.m_headAutoSex;
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06000E8E RID: 3726 RVA: 0x00040A68 File Offset: 0x0003EC68
		public bool pelvisEsIdle
		{
			get
			{
				return !this.m_usaAutoSexController || !this.m_pelvisAutoSex;
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06000E8F RID: 3727 RVA: 0x00040A7D File Offset: 0x0003EC7D
		public bool handsEsIdle
		{
			get
			{
				return !this.m_FemaleSimpleAi || (!this.m_handAutoSex && !this.m_handMassage);
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06000E90 RID: 3728 RVA: 0x00040AA1 File Offset: 0x0003ECA1
		public bool enAutoInteraccionCoital
		{
			get
			{
				return this.m_headAutoSex || this.m_pelvisAutoSex || this.m_handAutoSex;
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06000E91 RID: 3729 RVA: 0x00040ABB File Offset: 0x0003ECBB
		public bool enAutoInteraccionCoitalHead
		{
			get
			{
				return this.m_headAutoSex;
			}
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06000E92 RID: 3730 RVA: 0x00040AC3 File Offset: 0x0003ECC3
		public bool enAutoInteraccionCoitalHips
		{
			get
			{
				return this.m_pelvisAutoSex;
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06000E93 RID: 3731 RVA: 0x00040ACB File Offset: 0x0003ECCB
		public bool enAutoInteraccionCoitalHands
		{
			get
			{
				return this.m_handAutoSex;
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06000E94 RID: 3732 RVA: 0x00040AD3 File Offset: 0x0003ECD3
		public bool enAutoInteraccionMassage
		{
			get
			{
				return this.m_handMassage;
			}
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06000E95 RID: 3733 RVA: 0x00040ADB File Offset: 0x0003ECDB
		public bool enAutoInteraccion
		{
			get
			{
				return this.enAutoInteraccionCoital || this.enAutoInteraccionMassage;
			}
		}

		// Token: 0x06000E96 RID: 3734 RVA: 0x00040AF0 File Offset: 0x0003ECF0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_FemaleSimpleAi = this.GetComponentEnRoot(false);
			this.m_ControlladorDeAutoSexV2 = this.GetComponentEnRoot(false);
			this.m_ICharacterHablador = this.GetComponentEnRoot(false);
			this.m_ICharacterConversador = this.GetComponentEnRoot(false);
			this.m_usaAutoSexController = this.m_ControlladorDeAutoSexV2 != null;
			this.m_charEsHablador = this.m_ICharacterHablador != null;
			this.m_charEsConversador = this.m_ICharacterConversador != null;
		}

		// Token: 0x06000E97 RID: 3735 RVA: 0x00040B67 File Offset: 0x0003ED67
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.Clear();
		}

		// Token: 0x06000E98 RID: 3736 RVA: 0x00040B75 File Offset: 0x0003ED75
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.Clear();
		}

		// Token: 0x06000E99 RID: 3737 RVA: 0x00040B84 File Offset: 0x0003ED84
		private void Clear()
		{
			this.m_idlePor = 0f;
			this.m_desarrollandoActividadPor = 0f;
			this.m_desplazandose = (this.m_pelvisAutoSex = (this.m_headAutoSex = (this.m_handAutoSex = false)));
			this.m_lastIdle = (this.m_idle = true);
		}

		// Token: 0x06000E9A RID: 3738 RVA: 0x00040BDC File Offset: 0x0003EDDC
		public override void OnUpdateEvent1()
		{
			this.m_desplazandose = (this.m_pelvisAutoSex = (this.m_headAutoSex = (this.m_handAutoSex = false)));
			if (this.m_usaAutoSexController)
			{
				ControlladorDeAutoSexV2.Orden orden = this.m_ControlladorDeAutoSexV2.currentStado.FirstOrDefaultEjecutandose();
				if (orden == null)
				{
					orden = this.m_ControlladorDeAutoSexV2.currentStado.ObtenerLastOrdenesDeteniendose(0);
				}
				if (orden != null)
				{
					ParteDelCuerpoHumano estimulado = orden.estimulado;
					if (estimulado != ParteDelCuerpoHumano.bocaInterno)
					{
						if (estimulado - ParteDelCuerpoHumano.ano > 1)
						{
							throw new ArgumentOutOfRangeException(orden.estimulado.ToString());
						}
						this.m_pelvisAutoSex = true;
					}
					else
					{
						this.m_headAutoSex = true;
					}
				}
			}
			if (this.m_FemaleSimpleAi)
			{
				this.m_handMassage = this.m_FemaleSimpleAi.GetIsInteractingWithHerHandsMassage(Side.R) || this.m_FemaleSimpleAi.GetIsInteractingWithHerHandsMassage(Side.L);
				this.m_handAutoSex = this.m_FemaleSimpleAi.GetIsInteractingWithHerHandsSex(Side.R) || this.m_FemaleSimpleAi.GetIsInteractingWithHerHandsSex(Side.L);
			}
			if (this.m_pelvisAutoSex || this.m_headAutoSex || this.m_handAutoSex || this.m_handMassage)
			{
				this.m_idle = false;
			}
			else if (this.m_desplazandose)
			{
				this.m_idle = false;
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

		// Token: 0x040009EA RID: 2538
		[SerializeField]
		[ReadOnlyUI]
		private bool m_headAutoSex;

		// Token: 0x040009EB RID: 2539
		[SerializeField]
		[ReadOnlyUI]
		private bool m_pelvisAutoSex;

		// Token: 0x040009EC RID: 2540
		[SerializeField]
		[ReadOnlyUI]
		private bool m_handAutoSex;

		// Token: 0x040009ED RID: 2541
		[SerializeField]
		[ReadOnlyUI]
		private bool m_handMassage;

		// Token: 0x040009EE RID: 2542
		[SerializeField]
		[ReadOnlyUI]
		private bool m_desplazandose;

		// Token: 0x040009EF RID: 2543
		[SerializeField]
		[ReadOnlyUI]
		private bool m_idle = true;

		// Token: 0x040009F0 RID: 2544
		[SerializeField]
		[ReadOnlyUI]
		private bool m_lastIdle = true;

		// Token: 0x040009F1 RID: 2545
		[SerializeField]
		[ReadOnlyUI]
		private float m_desarrollandoActividadPor;

		// Token: 0x040009F2 RID: 2546
		[SerializeField]
		[ReadOnlyUI]
		private float m_idlePor;

		// Token: 0x040009F3 RID: 2547
		[SerializeField]
		[ReadOnlyUI]
		private bool m_usaAutoSexController;

		// Token: 0x040009F4 RID: 2548
		[SerializeField]
		[ReadOnlyUI]
		private bool m_charEsHablador;

		// Token: 0x040009F5 RID: 2549
		[SerializeField]
		[ReadOnlyUI]
		private bool m_charEsConversador;

		// Token: 0x040009F6 RID: 2550
		private FemaleSimpleAi m_FemaleSimpleAi;

		// Token: 0x040009F7 RID: 2551
		private ControlladorDeAutoSexV2 m_ControlladorDeAutoSexV2;

		// Token: 0x040009F8 RID: 2552
		private ICharacterHablador m_ICharacterHablador;

		// Token: 0x040009F9 RID: 2553
		private ICharacterConversador m_ICharacterConversador;
	}
}
