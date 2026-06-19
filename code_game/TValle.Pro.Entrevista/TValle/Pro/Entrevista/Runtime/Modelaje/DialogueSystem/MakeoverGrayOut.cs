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
	// Token: 0x0200009E RID: 158
	public class MakeoverGrayOut : CustomMonobehaviour, ICheckerIsGreyOut, IOverriderDescription
	{
		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060005FA RID: 1530 RVA: 0x00022948 File Offset: 0x00020B48
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
				if (flag)
				{
					return num < 2f;
				}
				return num < 3f;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060005FB RID: 1531 RVA: 0x000229CB File Offset: 0x00020BCB
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
					return "<color=red><size=8>Req. Modeling lvl 2</size></color>";
				}
				return "<color=red><size=8>Req. Modeling lvl 3</size></color>";
			}
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00022A00 File Offset: 0x00020C00
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

		// Token: 0x040003BD RID: 957
		public const string modelingJobID = "tvalle.jobs.photoshoot";

		// Token: 0x040003BE RID: 958
		private MemoriaDeCharacterGeneralTemporal m_mem;

		// Token: 0x040003BF RID: 959
		private Character m_Character;
	}
}
