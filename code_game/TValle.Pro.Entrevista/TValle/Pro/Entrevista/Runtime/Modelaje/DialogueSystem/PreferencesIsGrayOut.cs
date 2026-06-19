using System;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets.TValle.Pro.Entrevista.Runtime.Modelaje.DialogueSystem
{
	// Token: 0x020000A0 RID: 160
	public class PreferencesIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000601 RID: 1537 RVA: 0x00022B19 File Offset: 0x00020D19
		public bool isGreyOut
		{
			get
			{
				return MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "BribableAny", false) || MemoriaDeSMAModelosFemeninas.HabloSobreTipoDeModelaje(GlobalSingletonV2<MemoriaJson>.instance, this.m_mem.owner.ID_UnicoString);
			}
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00022B4B File Offset: 0x00020D4B
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mem = this.GetComponentEnRoot(false);
			if (this.m_mem == null)
			{
				throw new ArgumentNullException("m_mem", "m_mem null reference.");
			}
		}

		// Token: 0x040003C1 RID: 961
		private MemoriaDeCharacterGeneralTemporal m_mem;
	}
}
