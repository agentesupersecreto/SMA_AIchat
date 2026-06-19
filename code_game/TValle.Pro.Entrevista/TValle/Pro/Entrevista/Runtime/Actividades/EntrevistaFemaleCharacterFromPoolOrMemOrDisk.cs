using System;
using System.Linq;
using System.Text;
using Assets.Base.Genetica.Runtime.NPCs;
using Assets.Productos.Juegos.Reception;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Genetica;
using Assets.TValle.Pro.Entrevista.Tiempo.Runtime.Genetica;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Clases;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.Tiempo;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000117 RID: 279
	public abstract class EntrevistaFemaleCharacterFromPoolOrMemOrDisk : ActrividadConFemaleNpc
	{
		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060009D8 RID: 2520 RVA: 0x0003895B File Offset: 0x00036B5B
		protected override bool destruirNpcOnEndAvtivity
		{
			get
			{
				return this.m_femaleSelectedMode == 1;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060009D9 RID: 2521 RVA: 0x00038966 File Offset: 0x00036B66
		protected override bool deleteFromMemNpcOnEndAvtivity
		{
			get
			{
				return this.m_femaleSelectedMode == 1;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060009DA RID: 2522 RVA: 0x00038971 File Offset: 0x00036B71
		public bool femaleCharacterCanBeRated
		{
			get
			{
				return this.m_femaleSelectedMode == 0;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060009DB RID: 2523 RVA: 0x0003897C File Offset: 0x00036B7C
		public PiscinaDeNpcsManager currentPiscinaManager
		{
			get
			{
				return this.piscinaManager;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060009DC RID: 2524 RVA: 0x00038984 File Offset: 0x00036B84
		public EventoDiarioHorario currentEvento
		{
			get
			{
				return this.m_currentEvento;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060009DD RID: 2525 RVA: 0x0003898C File Offset: 0x00036B8C
		protected override bool generateFemaleRopa
		{
			get
			{
				return this.m_femaleSelectedMode == 0;
			}
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x00038997 File Offset: 0x00036B97
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_EntrevistaFemaleCharacterFromPoolConfigAndData = base.GetComponentInChildren<EntrevistaFemaleCharacterFromPoolConfigAndData>();
			if (this.m_EntrevistaFemaleCharacterFromPoolConfigAndData == null)
			{
				throw new ArgumentNullException("m_EntrevistaFemaleCharacterFromPoolConfigAndData", "m_EntrevistaFemaleCharacterFromPoolConfigAndData null reference.");
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060009DF RID: 2527 RVA: 0x000389C9 File Offset: 0x00036BC9
		protected override bool DoLoadNpc
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x000389CC File Offset: 0x00036BCC
		protected override void LoadingNPC(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter)
		{
			this.m_femaleSelectedMode = PlayerPrefs.GetInt("SelectedModelToInterviewMode");
			int femaleSelectedMode = this.m_femaleSelectedMode;
			if (femaleSelectedMode != 0)
			{
				if (femaleSelectedMode != 1)
				{
					throw new ArgumentOutOfRangeException(this.m_femaleSelectedMode.ToString());
				}
			}
			else
			{
				this.piscinaManager = Singleton<PiscinaDeCampaingActual>.instance.ObtenerPiscinaDeCurrentEvento(true, out this.m_currentEvento);
				if (this.piscinaManager == null)
				{
					throw new ArgumentNullException("piscinaManager", "piscinaManager null reference.");
				}
			}
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x00038A40 File Offset: 0x00036C40
		protected override ISujetoIdentificableNpc LoadNpc(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter)
		{
			string npcSlectedByPlayer = PlayerPrefs.GetString("SelectedModelToInterview");
			int femaleSelectedMode = this.m_femaleSelectedMode;
			ISujetoIdentificableNpc sujetoIdentificableNpc;
			if (femaleSelectedMode != 0)
			{
				if (femaleSelectedMode == 1)
				{
					Texture2D texture2D;
					byte[] array;
					SaveLoadCharacters.Cargar(npcSlectedByPlayer, out texture2D, out array);
					try
					{
						if (array == null || array.Length == 0)
						{
							ErrorDialog modal = Singleton<ModalWindow>.instance.MostrarErrorDialog();
							modal.pregunta.text = "Invalid Portrait File";
							modal.aceptar.onClick.AddListener(delegate
							{
								Singleton<ModalWindow>.instance.Clear(modal);
							});
							characterEnScena.gameObject.SetActive(false);
							sujetoIdentificableNpc = null;
							goto IL_020E;
						}
						string text;
						if (SaveLoadCharacters.CustomDataIsZipped(array))
						{
							text = Zipiry.Unzip(array);
						}
						else
						{
							text = Encoding.UTF8.GetString(array);
						}
						MemoriaJsonGenerica<SavingFemaleCharacterJsonMemoryNode> memoriaJsonGenerica = new MemoriaJsonGenerica<SavingFemaleCharacterJsonMemoryNode>();
						SavingFemaleCharacterJsonMemoryNode savingFemaleCharacterJsonMemoryNode = (SavingFemaleCharacterJsonMemoryNode)memoriaJsonGenerica.root;
						memoriaJsonGenerica.root.Load(text);
						sujetoIdentificableNpc = MemoriaDeSujetosNpcFemenina.LeerNpcEnMemoriaFirstOrDefault(memoriaJsonGenerica);
						LoaderDeNpcFemeninos.Load(characterEnScena, sujetoIdentificableNpc, true, memoriaJsonGenerica, false);
						if (savingFemaleCharacterJsonMemoryNode.ropa != null)
						{
							ConjuntoDeRopa ropa = savingFemaleCharacterJsonMemoryNode.ropa;
							IRopaDeCharacterAdmin componentInChildren = characterEnScena.self.GetComponentInChildren<IRopaDeCharacterAdmin>();
							if (componentInChildren != null)
							{
								componentInChildren.generar = false;
							}
							if (AsyncSingleton<RopaParaAvatarUnificado>.IsInScene && AsyncSingleton<MaterialesParaRopa>.IsInScene)
							{
								IRopaManager componentInChildren2 = characterEnScena.self.GetComponentInChildren<IRopaManager>();
								if (componentInChildren2 != null && ropa != null)
								{
									ConjuntoDeRopa.VerificarYCorregirIntegridadPiezasConMsg(ropa, null);
									ConjuntoDeRopa.VerificarYCorregirIntegridadMaterialesConMsg(ropa, null);
									((MonoBehaviour)componentInChildren2).StartCoroutine(componentInChildren2.LoadConjuntoAsset(ropa, true, null, true));
								}
							}
						}
						LoaderDeNpcFemeninos.SaveToMemory(GlobalSingletonV2<MemoriaJson>.instance, sujetoIdentificableNpc, characterEnScena, texture2D);
						goto IL_020E;
					}
					finally
					{
						Object.Destroy(texture2D);
					}
				}
				throw new ArgumentOutOfRangeException(this.m_femaleSelectedMode.ToString());
			}
			sujetoIdentificableNpc = (ISujetoIdentificableNpc)this.piscinaManager.NPCs.FirstOrDefault((Object n) => ((ISujetoIdentificableNpc)n).NpcID.ToString() == npcSlectedByPlayer);
			if (sujetoIdentificableNpc == null)
			{
				throw new ArgumentNullException("npc", "npc null reference.");
			}
			rootForManagerLogicInCharacter.GetComponentNotNull<PiscinaNpcDeSujetoComponent>().Bind(this.piscinaManager, sujetoIdentificableNpc as SujetoIdentificableNpcAlteradoresFemeninos);
			IL_020E:
			LoaderDeNpcFemeninos.Load(characterEnScena, sujetoIdentificableNpc, false, GlobalSingletonV2<MemoriaJson>.instance, false);
			GlobalUpdater.instancia.Invokar(delegate
			{
				FemaleChar characterEnScena2 = characterEnScena;
				if (characterEnScena2 == null)
				{
					return;
				}
				ICharacterAutoRateable componentInChildren3 = characterEnScena2.GetComponentInChildren<ICharacterAutoRateable>();
				if (componentInChildren3 == null)
				{
					return;
				}
				componentInChildren3.DoAutoRating();
			}, 1f);
			return sujetoIdentificableNpc;
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x00038CA8 File Offset: 0x00036EA8
		protected override void EscribirFemaleRopaToMemory(IConjuntoDeRopa loadedConjunto)
		{
			if (loadedConjunto == null || loadedConjunto.piezas.Count == 0)
			{
				Debug.LogError("cant save female outfit to memory, it was empty or null", base.currentFemaleCharacter);
				return;
			}
			LoaderDeNpcFemeninos.SaveFemaleRopaToMemory(GlobalSingletonV2<MemoriaJson>.instance, base.npc.NpcID.ToString(), loadedConjunto);
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x00038CFC File Offset: 0x00036EFC
		public void CalificarCurrentFemale()
		{
			if (!this.femaleCharacterCanBeRated)
			{
				throw new InvalidOperationException("verifiar antes de calificar female q esta pueda ser calificada");
			}
			if (!Singleton<PiscinaDeCampaingActual>.IsInScene)
			{
				Debug.LogError("No se pudo calificar Char: " + base.currentFemaleCharacter.ID_Unico.ToString() + ", por q piscina Campaing no existe", this);
				return;
			}
			Guid id_Unico = base.currentFemaleCharacter.ID_Unico;
			Singleton<PiscinaDeCampaingActual>.instance.SetFemaleRate(id_Unico);
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x00038D6C File Offset: 0x00036F6C
		public void CurrentFemaleWasInterviewed()
		{
			int femaleSelectedMode = this.m_femaleSelectedMode;
			if (femaleSelectedMode != 0)
			{
				if (femaleSelectedMode != 1)
				{
					throw new ArgumentOutOfRangeException(this.m_femaleSelectedMode.ToString());
				}
				ISujetoCalificable sujetoCalificable = base.npc as ISujetoCalificable;
				if (sujetoCalificable != null)
				{
					sujetoCalificable.interviewed = true;
					MemoriaDeSujetosNpcFemenina.Escribir_DATA_DeNpcAMemoria(GlobalSingletonV2<MemoriaJson>.instance, base.npc);
				}
				MemoriaDeSujetosNpcFemenina.EscribirNpcEnMemoria(GlobalSingletonV2<MemoriaJson>.instance, base.npc);
				return;
			}
			else
			{
				if (!Singleton<PiscinaDeCampaingActual>.IsInScene)
				{
					Debug.LogError("No se pudo entrevistar Char: " + base.currentFemaleCharacter.ID_Unico.ToString() + ", por q piscina Campaing no existe", this);
					return;
				}
				Guid id_Unico = base.currentFemaleCharacter.ID_Unico;
				Singleton<PiscinaDeCampaingActual>.instance.SetFemaleAsInterviewed(id_Unico);
				return;
			}
		}

		// Token: 0x0400054B RID: 1355
		[Header("-> Entrevista con Pool Female Characteres <-")]
		[ReadOnlyUI]
		[SerializeField]
		private int m_femaleSelectedMode;

		// Token: 0x0400054C RID: 1356
		[ReadOnlyUI]
		[SerializeField]
		private PiscinaDeNpcsManager piscinaManager;

		// Token: 0x0400054D RID: 1357
		[ReadOnlyUI]
		[SerializeField]
		private EventoDiarioHorario m_currentEvento;

		// Token: 0x0400054E RID: 1358
		[SerializeField]
		[ReadOnlyUI]
		private EntrevistaFemaleCharacterFromPoolConfigAndData m_EntrevistaFemaleCharacterFromPoolConfigAndData;

		// Token: 0x020002B0 RID: 688
		[Serializable]
		public class ConfigDePiscinas
		{
			// Token: 0x04000C69 RID: 3177
			[Obsolete("", true)]
			[Tooltip("obsolete")]
			public bool loadFromPool = true;
		}
	}
}
