using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000470 RID: 1136
	[RequireComponent(typeof(EmocionesHumanasBase))]
	public class EmocionAuraProducer : CustomMonobehaviour
	{
		// Token: 0x06001907 RID: 6407 RVA: 0x00066758 File Offset: 0x00064958
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_emos = base.GetComponent<EmocionesHumanasBase>();
			this.m_Character = this.GetComponentEnRoot(false);
		}

		// Token: 0x06001908 RID: 6408 RVA: 0x0006677C File Offset: 0x0006497C
		public EmocionAuraProducer.Aura GetAura(ReaccionHumana reacc)
		{
			EmocionAuraProducer.Aura aura;
			if (!this.m_auras.TryGetValue(reacc, out aura))
			{
				return null;
			}
			return aura;
		}

		// Token: 0x06001909 RID: 6409 RVA: 0x0006679C File Offset: 0x0006499C
		public EmocionAuraProducer.Aura GetAuraNotNull(ReaccionHumana reacc)
		{
			EmocionAuraProducer.Aura aura;
			if (!this.m_auras.TryGetValue(reacc, out aura))
			{
				aura = new EmocionAuraProducer.Aura();
				aura.reaccion = reacc;
				this.m_auras.Add(reacc, aura);
			}
			return aura;
		}

		// Token: 0x040012EF RID: 4847
		private EmocionesHumanasBase m_emos;

		// Token: 0x040012F0 RID: 4848
		private Character m_Character;

		// Token: 0x040012F1 RID: 4849
		private DiccionaryEnum<ReaccionHumana, EmocionAuraProducer.Aura> m_auras = new DiccionaryEnum<ReaccionHumana, EmocionAuraProducer.Aura>((ReaccionHumana x) => (int)x);

		// Token: 0x040012F2 RID: 4850
		[SerializeField]
		private List<EmocionAuraProducer.Aura> m_aurasDEBUG = new List<EmocionAuraProducer.Aura>();

		// Token: 0x02000471 RID: 1137
		[Serializable]
		public class Aura
		{
			// Token: 0x17000646 RID: 1606
			// (get) Token: 0x0600190B RID: 6411 RVA: 0x00066811 File Offset: 0x00064A11
			public ModificableDeFloat sumadorDeValor
			{
				get
				{
					return this.m_sumadorDeValor;
				}
			}

			// Token: 0x17000647 RID: 1607
			// (get) Token: 0x0600190C RID: 6412 RVA: 0x00066819 File Offset: 0x00064A19
			public ModificableDeFloat multiplicadorDeValor
			{
				get
				{
					return this.m_multiplicadorDeValor;
				}
			}

			// Token: 0x17000648 RID: 1608
			// (get) Token: 0x0600190D RID: 6413 RVA: 0x00066821 File Offset: 0x00064A21
			public ModificableDeFloat sumadorDeAumento
			{
				get
				{
					return this.m_sumadorDeAumento;
				}
			}

			// Token: 0x17000649 RID: 1609
			// (get) Token: 0x0600190E RID: 6414 RVA: 0x00066829 File Offset: 0x00064A29
			public ModificableDeFloat multiplicadorDeAumento
			{
				get
				{
					return this.m_multiplicadorDeAumento;
				}
			}

			// Token: 0x040012F3 RID: 4851
			public ReaccionHumana reaccion;

			// Token: 0x040012F4 RID: 4852
			[SerializeField]
			private ModificableDeFloat m_sumadorDeValor = new ModificableDeFloat(0f);

			// Token: 0x040012F5 RID: 4853
			[SerializeField]
			private ModificableDeFloat m_multiplicadorDeValor = new ModificableDeFloat(1f);

			// Token: 0x040012F6 RID: 4854
			[SerializeField]
			private ModificableDeFloat m_sumadorDeAumento = new ModificableDeFloat(0f);

			// Token: 0x040012F7 RID: 4855
			[SerializeField]
			private ModificableDeFloat m_multiplicadorDeAumento = new ModificableDeFloat(1f);
		}
	}
}
