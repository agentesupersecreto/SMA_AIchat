using System;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chains
{
	// Token: 0x02000295 RID: 661
	[RequireComponent(typeof(Linear7BoneChainBase))]
	public class ChainPointsDataCollector : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000E7C RID: 3708 RVA: 0x00029858 File Offset: 0x00027A58
		public sealed override int updateEvent1Index
		{
			get
			{
				return 48;
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000E7D RID: 3709 RVA: 0x000447C2 File Offset: 0x000429C2
		public Side side
		{
			get
			{
				return this.m_side;
			}
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000E7E RID: 3710 RVA: 0x000447CA File Offset: 0x000429CA
		public Linear7BoneChainBase chain
		{
			get
			{
				return this.m_chain;
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000E7F RID: 3711 RVA: 0x000447D2 File Offset: 0x000429D2
		public Linear7BoneChainBase.EstadoDePuntos estadoActual
		{
			get
			{
				return this.chain.estadoDePuntos;
			}
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000E80 RID: 3712 RVA: 0x000447DF File Offset: 0x000429DF
		public ChainPointsDataCollector.StepData stepData
		{
			get
			{
				return this.m_StepData;
			}
		}

		// Token: 0x06000E81 RID: 3713 RVA: 0x000447E7 File Offset: 0x000429E7
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
			this.m_StepData = new ChainPointsDataCollector.StepData(this);
		}

		// Token: 0x06000E82 RID: 3714 RVA: 0x00044808 File Offset: 0x00042A08
		public void Init(Linear7BoneChainBase chain, Side side)
		{
			if (chain == null)
			{
				throw new ArgumentNullException("chain", "chain null reference.");
			}
			this.m_chain = chain;
			this.m_side = side;
			this.m_estadoPasado = new Linear7BoneChainBase.EstadoDePuntos(chain);
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x06000E83 RID: 3715 RVA: 0x00044854 File Offset: 0x00042A54
		public override void OnUpdateEvent1()
		{
			try
			{
				if (this.m_isFirst)
				{
					this.m_isFirst = false;
					this.m_chain.estadoDePuntos.CopiarA(this.m_estadoPasado);
				}
				this.m_StepData.OnUpdate();
			}
			finally
			{
				this.m_chain.estadoDePuntos.CopiarA(this.m_estadoPasado);
			}
		}

		// Token: 0x04000C88 RID: 3208
		[ReadOnlyUI]
		[SerializeField]
		private Side m_side;

		// Token: 0x04000C89 RID: 3209
		[SerializeField]
		private Linear7BoneChainBase m_chain;

		// Token: 0x04000C8A RID: 3210
		[SerializeField]
		private Linear7BoneChainBase.EstadoDePuntos m_estadoPasado;

		// Token: 0x04000C8B RID: 3211
		[SerializeField]
		private ChainPointsDataCollector.StepData m_StepData;

		// Token: 0x04000C8C RID: 3212
		private bool m_isFirst = true;

		// Token: 0x02000296 RID: 662
		[Serializable]
		public class StepData
		{
			// Token: 0x06000E85 RID: 3717 RVA: 0x000448CB File Offset: 0x00042ACB
			public StepData(ChainPointsDataCollector collector)
			{
				if (collector == null)
				{
					throw new ArgumentNullException("collector", "collector null reference.");
				}
				this.m_collector = collector;
			}

			// Token: 0x06000E86 RID: 3718 RVA: 0x000448F3 File Offset: 0x00042AF3
			public void OnUpdate()
			{
				this.UpdateCenterMovement();
			}

			// Token: 0x06000E87 RID: 3719 RVA: 0x000448FC File Offset: 0x00042AFC
			private void UpdateCenterMovement()
			{
				float num = Vector3.Distance(this.m_collector.chain.estadoDePuntos.posicionesLocales.centroDePuntos, this.m_collector.m_estadoPasado.posicionesLocales.centroDePuntos);
				this.localCenterMovement = num;
			}

			// Token: 0x04000C8D RID: 3213
			private ChainPointsDataCollector m_collector;

			// Token: 0x04000C8E RID: 3214
			public float localCenterMovement;
		}
	}
}
