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
	// Token: 0x0200009B RID: 155
	public class ForceChangeOutfitIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut, IOverriderDescription
	{
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x000226E4 File Offset: 0x000208E4
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
				return !flag && num < 3f;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x00022760 File Offset: 0x00020960
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
					return string.Empty;
				}
				return "<color=red><size=8>Req. Modeling lvl 3</size></color>";
			}
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x00022794 File Offset: 0x00020994
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

		// Token: 0x040003B6 RID: 950
		private MemoriaDeCharacterGeneralTemporal m_mem;

		// Token: 0x040003B7 RID: 951
		private Character m_Character;
	}
}
