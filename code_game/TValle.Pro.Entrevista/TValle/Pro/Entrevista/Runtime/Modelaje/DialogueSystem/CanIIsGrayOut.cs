using System;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets.TValle.Pro.Entrevista.Runtime.Modelaje.DialogueSystem
{
	// Token: 0x02000099 RID: 153
	public class CanIIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060005E9 RID: 1513 RVA: 0x00022510 File Offset: 0x00020710
		public bool isGreyOut
		{
			get
			{
				return !MemoriaDeSMAModelosFemeninas.AceptoErotico(GlobalSingletonV2<MemoriaJson>.instance, this.m_mem.owner.ID_UnicoString) && !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "AnalBribed", false) && !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "VaginalBribed", false) && !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "OralBribed", false);
			}
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0002257A File Offset: 0x0002077A
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mem = this.GetComponentEnRoot(false);
			if (this.m_mem == null)
			{
				throw new ArgumentNullException("m_mem", "m_mem null reference.");
			}
		}

		// Token: 0x040003B2 RID: 946
		private MemoriaDeCharacterGeneralTemporal m_mem;
	}
}
