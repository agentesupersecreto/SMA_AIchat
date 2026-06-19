using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.UI.Interacciones.Donas;

namespace Assets.TValle.Pro.Entrevista.Runtime.Modelaje.DialogueSystem
{
	// Token: 0x0200009C RID: 156
	public class GetNakedGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x00022808 File Offset: 0x00020A08
		public bool isGreyOut
		{
			get
			{
				Actividad running = Actividad.running;
				bool flag = ((running != null) ? running.ID : null) == "tvalle.jobs.photoshoot";
				float num = AsyncSingleton<JobsManager>.instance.GetCharacterInMemory("tvalle.jobs.photoshoot", this.m_Character.ID_UnicoString).FindDataFloat("Exp", 0f);
				return !flag || num < 2f;
			}
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x00022868 File Offset: 0x00020A68
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

		// Token: 0x040003B8 RID: 952
		public const string modelingJobID = "tvalle.jobs.photoshoot";

		// Token: 0x040003B9 RID: 953
		private MemoriaDeCharacterGeneralTemporal m_mem;

		// Token: 0x040003BA RID: 954
		private Character m_Character;
	}
}
