using System;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets.TValle.Pro.Entrevista.Runtime.Modelaje.DialogueSystem
{
	// Token: 0x02000097 RID: 151
	public class AskToForPosingIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060005E3 RID: 1507 RVA: 0x00022398 File Offset: 0x00020598
		public bool isGreyOut
		{
			get
			{
				return !MemoriaDeSMAModelosFemeninas.HabloSobreTipoDeModelaje(GlobalSingletonV2<MemoriaJson>.instance, this.m_mem.owner.ID_UnicoString) || MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "BribableAny", false) || (!MemoriaDeSMAModelosFemeninas.AceptoFotografias(GlobalSingletonV2<MemoriaJson>.instance, this.m_mem.owner.ID_UnicoString) || MemoriaDeSMAModelosFemeninas.AceptoModelar(GlobalSingletonV2<MemoriaJson>.instance, this.m_mem.owner.ID_UnicoString));
			}
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00022418 File Offset: 0x00020618
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mem = this.GetComponentEnRoot(false);
			if (this.m_mem == null)
			{
				throw new ArgumentNullException("m_mem", "m_mem null reference.");
			}
		}

		// Token: 0x040003B0 RID: 944
		private MemoriaDeCharacterGeneralTemporal m_mem;
	}
}
