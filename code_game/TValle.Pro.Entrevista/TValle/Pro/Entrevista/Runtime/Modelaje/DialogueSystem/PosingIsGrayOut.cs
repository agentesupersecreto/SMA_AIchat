using System;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets.TValle.Pro.Entrevista.Runtime.Modelaje.DialogueSystem
{
	// Token: 0x0200009F RID: 159
	public class PosingIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060005FE RID: 1534 RVA: 0x00022A74 File Offset: 0x00020C74
		public bool isGreyOut
		{
			get
			{
				return !MemoriaDeSMAModelosFemeninas.AceptoModelar(GlobalSingletonV2<MemoriaJson>.instance, this.m_mem.owner.ID_UnicoString) && !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "AnalBribed", false) && !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "VaginalBribed", false) && !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_mem, null, "OralBribed", false);
			}
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x00022ADE File Offset: 0x00020CDE
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mem = this.GetComponentEnRoot(false);
			if (this.m_mem == null)
			{
				throw new ArgumentNullException("m_mem", "m_mem null reference.");
			}
		}

		// Token: 0x040003C0 RID: 960
		private MemoriaDeCharacterGeneralTemporal m_mem;
	}
}
