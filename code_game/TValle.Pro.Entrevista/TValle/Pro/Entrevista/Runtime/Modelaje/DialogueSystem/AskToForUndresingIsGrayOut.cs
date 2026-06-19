using System;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets.TValle.Pro.Entrevista.Runtime.Modelaje.DialogueSystem
{
	// Token: 0x02000098 RID: 152
	public class AskToForUndresingIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x00022454 File Offset: 0x00020654
		public bool isGreyOut
		{
			get
			{
				return !MemoriaDeSMAModelosFemeninas.HabloSobreTipoDeModelaje(GlobalSingletonV2<MemoriaJson>.instance, this.m_mem.owner.ID_UnicoString) || MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "BribableAny", false) || (!MemoriaDeSMAModelosFemeninas.AceptoModelar(GlobalSingletonV2<MemoriaJson>.instance, this.m_mem.owner.ID_UnicoString) || MemoriaDeSMAModelosFemeninas.AceptoLingerie(GlobalSingletonV2<MemoriaJson>.instance, this.m_mem.owner.ID_UnicoString));
			}
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x000224D4 File Offset: 0x000206D4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mem = this.GetComponentEnRoot(false);
			if (this.m_mem == null)
			{
				throw new ArgumentNullException("m_mem", "m_mem null reference.");
			}
		}

		// Token: 0x040003B1 RID: 945
		private MemoriaDeCharacterGeneralTemporal m_mem;
	}
}
