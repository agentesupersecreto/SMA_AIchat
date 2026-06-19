using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets.TValle.Pro.Entrevista.Runtime.Modelaje.DialogueSystem
{
	// Token: 0x020000A1 RID: 161
	public class ServicingGrayOut : CustomMonobehaviour, ICheckerIsGreyOut, IOverriderDescription
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000604 RID: 1540 RVA: 0x00022B88 File Offset: 0x00020D88
		public bool isGreyOut
		{
			get
			{
				if (!MemoriaDeSMAModelosFemeninas.AceptoModelar(GlobalSingletonV2<MemoriaJson>.instance, this.m_mem.owner.ID_UnicoString))
				{
					return true;
				}
				Actividad running = Actividad.running;
				bool flag = ((running != null) ? running.ID : null) == "tvalle.jobs.photoshoot";
				float num = AsyncSingleton<JobsManager>.instance.GetCharacterInMemory("tvalle.jobs.photoshoot", this.m_Character.ID_UnicoString).FindDataFloat("Exp", 0f);
				float num2 = AsyncSingleton<JobsManager>.instance.GetCharacterInMemory("tvalle.jobs.spa", this.m_Character.ID_UnicoString).FindDataFloat("Exp", 0f);
				if (flag)
				{
					return num < 3f || num2 < 1f;
				}
				return num < 4f || num2 < 3f;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000605 RID: 1541 RVA: 0x00022C49 File Offset: 0x00020E49
		public string descriptionOverriding
		{
			get
			{
				if (!this.isGreyOut)
				{
					return null;
				}
				Actividad running = Actividad.running;
				if (((running != null) ? running.ID : null) == "tvalle.jobs.photoshoot")
				{
					return "<color=red><size=8>Req. Modeling lvl 3 And Spa lvl 1</size></color>";
				}
				return "<color=red><size=8>Req. Modeling lvl 4 And Spa lvl 3</size></color>";
			}
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x00022C80 File Offset: 0x00020E80
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Character = this.GetComponentEnRoot(false);
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
			this.m_mem = this.GetComponentEnRoot(false);
			if (this.m_mem == null)
			{
				throw new ArgumentNullException("m_mem", "m_mem null reference.");
			}
		}

		// Token: 0x040003C2 RID: 962
		public const string modelingJobID = "tvalle.jobs.photoshoot";

		// Token: 0x040003C3 RID: 963
		public const string spaJobID = "tvalle.jobs.spa";

		// Token: 0x040003C4 RID: 964
		private MemoriaDeCharacterGeneralTemporal m_mem;

		// Token: 0x040003C5 RID: 965
		private Character m_Character;
	}
}
