using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.ReductoresEnMaxValue.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Personalidades.ReductoresEnMaxValue.Abstracts
{
	// Token: 0x02000430 RID: 1072
	[RequireComponent(typeof(ReductorDeEmocionValueEnMaxEmocionValue))]
	public abstract class ReductorDeEmocionHastaSegunPersonalidadTraits : CustomMonobehaviour
	{
		// Token: 0x17000622 RID: 1570
		// (get) Token: 0x060017DA RID: 6106
		protected abstract TraitHumano trait { get; }

		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x060017DB RID: 6107
		protected abstract float modificadorGeneral { get; }

		// Token: 0x060017DC RID: 6108 RVA: 0x000602E8 File Offset: 0x0005E4E8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_reductor = base.GetComponent<ReductorDeEmocionValueEnMaxEmocionValue>();
			if (this.m_reductor == null)
			{
				throw new ArgumentNullException("m_reductor", "m_reductor null reference.");
			}
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
		}

		// Token: 0x060017DD RID: 6109 RVA: 0x00060350 File Offset: 0x0005E550
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_reductor.chekeandoSiPuedeReducir += this.M_reductor_checking;
			this.m_modificador = this.m_reductor.reducirHastaModificable.ObtenerModificadorNotNull(this);
		}

		// Token: 0x060017DE RID: 6110 RVA: 0x00060386 File Offset: 0x0005E586
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_reductor)
			{
				this.m_reductor.chekeandoSiPuedeReducir -= this.M_reductor_checking;
			}
			ModificadorDeFloat modificador = this.m_modificador;
			if (modificador == null)
			{
				return;
			}
			modificador.TryRemoverDeOwner(true);
		}

		// Token: 0x060017DF RID: 6111 RVA: 0x000603C8 File Offset: 0x0005E5C8
		private float ModSegunPersonalidad()
		{
			HumanTraitScore traitScore = this.m_personalidad.GetTraitScore(TraitHumano.maxEmocionValueEndurance);
			HumanTraitScore traitScore2 = this.m_personalidad.GetTraitScore(this.trait);
			float num = 1f;
			switch (traitScore)
			{
			case HumanTraitScore.normal:
				break;
			case HumanTraitScore.alto:
				num *= 1.16f;
				break;
			case HumanTraitScore.muyAlto:
				num *= 1.333f;
				break;
			case HumanTraitScore.bajo:
				num *= 0.86f;
				break;
			case HumanTraitScore.muyBajo:
				num *= 0.75f;
				break;
			default:
				throw new ArgumentOutOfRangeException(traitScore.ToString());
			}
			switch (traitScore2)
			{
			case HumanTraitScore.normal:
				break;
			case HumanTraitScore.alto:
				num *= 1.16f;
				break;
			case HumanTraitScore.muyAlto:
				num *= 1.333f;
				break;
			case HumanTraitScore.bajo:
				num *= 0.86f;
				break;
			case HumanTraitScore.muyBajo:
				num *= 0.75f;
				break;
			default:
				throw new ArgumentOutOfRangeException(traitScore2.ToString());
			}
			return num;
		}

		// Token: 0x060017E0 RID: 6112 RVA: 0x000604AA File Offset: 0x0005E6AA
		private void M_reductor_checking(object obj)
		{
			this.m_modificador.valor.valor = this.ModSegunPersonalidad() * this.modificadorGeneral;
		}

		// Token: 0x04001228 RID: 4648
		private ReductorDeEmocionValueEnMaxEmocionValue m_reductor;

		// Token: 0x04001229 RID: 4649
		private Personalidad m_personalidad;

		// Token: 0x0400122A RID: 4650
		private ModificadorDeFloat m_modificador;
	}
}
