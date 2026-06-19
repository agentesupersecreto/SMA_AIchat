using System;
using System.Linq;
using Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Genetica;
using Assets.TValle.Pro.Entrevista.Tiempo.Runtime.Genetica;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Productos.Juegos.Reception.Scripts.Dependientes.ScenaManagers
{
	// Token: 0x020000BF RID: 191
	[Obsolete("", true)]
	public class ScenaConFemaleCharFromPoolDelDia : EntrevistaConFemale
	{
		// Token: 0x06000465 RID: 1125 RVA: 0x00015DED File Offset: 0x00013FED
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void BeforeJuegoLanzado()
		{
			SceneSingletonV2.Finalizar();
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000466 RID: 1126 RVA: 0x00015DF4 File Offset: 0x00013FF4
		public int currentFemaleCharacterLvl
		{
			get
			{
				return this.femaleCharacterEnScenaLvl;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000467 RID: 1127 RVA: 0x00015DFC File Offset: 0x00013FFC
		public PiscinaDeNpcsManager currentPiscinaManager
		{
			get
			{
				return this.piscinaManager;
			}
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00015E04 File Offset: 0x00014004
		protected override void OnScenaAndFemaleCharacterLoaded(LoadSceneMode loadSceneMode, FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter)
		{
			base.OnScenaAndFemaleCharacterLoaded(loadSceneMode, characterEnScena, rootForManagerLogicInCharacter);
			if (this.configDePiscinas.loadFromPool)
			{
				this.LoadSujetoFromPool(characterEnScena, rootForManagerLogicInCharacter);
			}
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00015E24 File Offset: 0x00014024
		public virtual void LoadSujetoFromPool(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter)
		{
			this.piscinaManager = Singleton<PiscinaDeCampaingActual>.instance.ObtenerPiscinaDeCurrentEvento(true, out this.m_currentEvento);
			if (this.piscinaManager == null)
			{
				throw new ArgumentNullException("piscinaManager", "piscinaManager null reference.");
			}
			string npcSlectedByPlayer = PlayerPrefs.GetString("SelectedNPCFromCampaing");
			ISujetoIdentificableNpc sujetoIdentificableNpc = (ISujetoIdentificableNpc)this.piscinaManager.NPCs.FirstOrDefault((Object n) => ((ISujetoIdentificableNpc)n).NpcID.ToString() == npcSlectedByPlayer);
			if (sujetoIdentificableNpc == null)
			{
				sujetoIdentificableNpc = this.piscinaManager.ObtenerSujetoAleatorioAgrupadoNonInterviewedHigherRated();
				if (sujetoIdentificableNpc == null)
				{
					sujetoIdentificableNpc = this.piscinaManager.ObtenerSujetoNonInterviewed();
				}
			}
			if (sujetoIdentificableNpc == null)
			{
				throw new ArgumentNullException("npc", "npc null reference.");
			}
			ISujetoNivel sujetoNivel = sujetoIdentificableNpc as ISujetoNivel;
			this.femaleCharacterEnScenaLvl = ((sujetoNivel != null) ? new int?(sujetoNivel.nivel) : null).GetValueOrDefault();
			LoaderDeNpcFemeninos.Load(characterEnScena, sujetoIdentificableNpc, false, GlobalSingletonV2<MemoriaJson>.instance, false);
			rootForManagerLogicInCharacter.GetComponentNotNull<PiscinaNpcDeSujetoComponent>().Bind(this.piscinaManager, sujetoIdentificableNpc as SujetoIdentificableNpcAlteradoresFemeninos);
			GlobalUpdater.instancia.Invokar(delegate
			{
				FemaleChar characterEnScena2 = characterEnScena;
				if (characterEnScena2 == null)
				{
					return;
				}
				AutoRatingFemaleLogic componentInChildren = characterEnScena2.GetComponentInChildren<AutoRatingFemaleLogic>();
				if (componentInChildren == null)
				{
					return;
				}
				componentInChildren.DoAutoRating();
			}, 1f);
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00015F49 File Offset: 0x00014149
		protected sealed override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Re Add Conversaciones",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00015F62 File Offset: 0x00014162
		protected sealed override void OnAplicar3()
		{
			base.OnAplicar3();
			base.AddConversaciones();
		}

		// Token: 0x040001FC RID: 508
		[Header("-> Entrevista con Pool Female Characteres <-")]
		public ScenaConFemaleCharFromPoolDelDia.ConfigDePiscinas configDePiscinas = new ScenaConFemaleCharFromPoolDelDia.ConfigDePiscinas();

		// Token: 0x040001FD RID: 509
		[SerializeField]
		private int femaleCharacterEnScenaLvl;

		// Token: 0x040001FE RID: 510
		[ReadOnlyUI]
		[SerializeField]
		private PiscinaDeNpcsManager piscinaManager;

		// Token: 0x040001FF RID: 511
		[ReadOnlyUI]
		[SerializeField]
		private EventoDiarioHorario m_currentEvento;

		// Token: 0x02000125 RID: 293
		[Serializable]
		public class ConfigDePiscinas
		{
			// Token: 0x040003C6 RID: 966
			public bool loadFromPool;
		}
	}
}
