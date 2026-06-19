using System;
using Assets._ReusableScripts.Succion;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Succion
{
	// Token: 0x0200036E RID: 878
	[RequireComponent(typeof(SuccionEngine))]
	public abstract class ModSuccPresionLiberadaSegunHumanTrait : CustomMonobehaviour
	{
		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x0600131A RID: 4890
		protected abstract TraitHumano trait { get; }

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x0600131B RID: 4891 RVA: 0x00052F34 File Offset: 0x00051134
		public float mod
		{
			get
			{
				HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(this.trait);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 1f;
				case HumanTraitScore.alto:
					return 1.25f;
				case HumanTraitScore.muyAlto:
					return 1.5f;
				case HumanTraitScore.bajo:
					return 0.6666667f;
				case HumanTraitScore.muyBajo:
					return 0.8f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x0600131C RID: 4892 RVA: 0x00052F9F File Offset: 0x0005119F
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_SuccionEngine = base.GetComponent<SuccionEngine>();
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
		}

		// Token: 0x0600131D RID: 4893 RVA: 0x00052FDE File Offset: 0x000511DE
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_SuccionEngine.presionLiberandose += this.M_SuccionEngine_presionLiberandose;
		}

		// Token: 0x0600131E RID: 4894 RVA: 0x00052FFD File Offset: 0x000511FD
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_SuccionEngine != null)
			{
				this.m_SuccionEngine.presionLiberandose -= this.M_SuccionEngine_presionLiberandose;
			}
		}

		// Token: 0x0600131F RID: 4895 RVA: 0x0005302B File Offset: 0x0005122B
		private void M_SuccionEngine_presionLiberandose(ref float presionLiberada, bool haySello, bool hayPiston, SuccionEngine sender)
		{
			this.m_currentMod = this.mod;
			presionLiberada *= this.m_currentMod;
		}

		// Token: 0x04001002 RID: 4098
		private SuccionEngine m_SuccionEngine;

		// Token: 0x04001003 RID: 4099
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentMod = 1f;

		// Token: 0x04001004 RID: 4100
		private Personalidad m_Personalidad;
	}
}
