using System;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets.TValle.Pro.Entrevista.Runtime.Modelaje.DialogueSystem
{
	// Token: 0x020000A2 RID: 162
	public class UndresingIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000608 RID: 1544 RVA: 0x00022CF4 File Offset: 0x00020EF4
		public bool isGreyOut
		{
			get
			{
				return !MemoriaDeSMAModelosFemeninas.AceptoLingerie(GlobalSingletonV2<MemoriaJson>.instance, this.m_mem.owner.ID_UnicoString) && !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "AnalBribed", false) && !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "VaginalBribed", false) && !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "OralBribed", false);
			}
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00022D5E File Offset: 0x00020F5E
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mem = this.GetComponentEnRoot(false);
			if (this.m_mem == null)
			{
				throw new ArgumentNullException("m_mem", "m_mem null reference.");
			}
		}

		// Token: 0x040003C6 RID: 966
		private MemoriaDeCharacterGeneralTemporal m_mem;
	}
}
