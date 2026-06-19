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
	// Token: 0x0200009A RID: 154
	public class ExpresionsIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut, IOverriderDescription
	{
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x000225B8 File Offset: 0x000207B8
		public bool isGreyOut
		{
			get
			{
				if (!MemoriaDeSMAModelosFemeninas.AceptoFotografias(GlobalSingletonV2<MemoriaJson>.instance, this.m_mem.owner.ID_UnicoString))
				{
					return true;
				}
				Actividad running = Actividad.running;
				bool flag = ((running != null) ? running.ID : null) == "tvalle.jobs.photoshoot";
				float num = AsyncSingleton<JobsManager>.instance.GetCharacterInMemory("tvalle.jobs.photoshoot", this.m_Character.ID_UnicoString).FindDataFloat("Exp", 0f);
				if (flag)
				{
					return num < 1f;
				}
				return num < 2f;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x0002263B File Offset: 0x0002083B
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
					return "<color=red><size=8>Req. Modeling lvl 1</size></color>";
				}
				return "<color=red><size=8>Req. Modeling lvl 2</size></color>";
			}
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x00022670 File Offset: 0x00020870
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

		// Token: 0x040003B3 RID: 947
		private const string modelingJobID = "tvalle.jobs.photoshoot";

		// Token: 0x040003B4 RID: 948
		private MemoriaDeCharacterGeneralTemporal m_mem;

		// Token: 0x040003B5 RID: 949
		private Character m_Character;
	}
}
