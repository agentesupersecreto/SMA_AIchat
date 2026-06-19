using System;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets.TValle.Pro.Entrevista.Runtime.Modelaje.DialogueSystem
{
	// Token: 0x02000096 RID: 150
	public class AskToForEroIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060005E0 RID: 1504 RVA: 0x000222DC File Offset: 0x000204DC
		public bool isGreyOut
		{
			get
			{
				return !MemoriaDeSMAModelosFemeninas.HabloSobreTipoDeModelaje(GlobalSingletonV2<MemoriaJson>.instance, this.m_mem.owner.ID_UnicoString) || MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "BribableAny", false) || (!MemoriaDeSMAModelosFemeninas.AceptoLingerie(GlobalSingletonV2<MemoriaJson>.instance, this.m_mem.owner.ID_UnicoString) || MemoriaDeSMAModelosFemeninas.AceptoErotico(GlobalSingletonV2<MemoriaJson>.instance, this.m_mem.owner.ID_UnicoString));
			}
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0002235C File Offset: 0x0002055C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mem = this.GetComponentEnRoot(false);
			if (this.m_mem == null)
			{
				throw new ArgumentNullException("m_mem", "m_mem null reference.");
			}
		}

		// Token: 0x040003AF RID: 943
		private MemoriaDeCharacterGeneralTemporal m_mem;
	}
}
