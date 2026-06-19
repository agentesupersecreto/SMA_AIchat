using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Assets.Base.Plugins.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Clases;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.Genetica;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Genetica;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Clases;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics.Mapas;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.NPCs;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using RootMotion;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception
{
	// Token: 0x02000003 RID: 3
	public static class LoaderDeNpcFemeninos
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020C6 File Offset: 0x000002C6
		public static void DestroyCharacter(string npcID)
		{
			Object.Destroy(Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales.Singleton<NPC_to_Character>.instance.TryGet(npcID).GetComponentInParent<ICharacterRoot>().transform.gameObject);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020E7 File Offset: 0x000002E7
		public static void DestroyNPC(string npcID)
		{
			NPCCharacter componentEnRoot = Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales.Singleton<NPC_to_Character>.instance.TryGet(npcID).GetComponentEnRoot<NPCCharacter>();
			if (componentEnRoot == null)
			{
				return;
			}
			ISujetoNpc npcMap = componentEnRoot.npcMap;
			if (npcMap == null)
			{
				return;
			}
			npcMap.Destruir();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000210D File Offset: 0x0000030D
		public static void EraseNPCFromGameMemory(string npcID)
		{
			MemoriaDeSujetosNpcFemenina.BorrarNpcEnMemoria(GlobalSingletonV2<MemoriaJson>.instance, npcID, false);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000211C File Offset: 0x0000031C
		public static void SaveFemaleRopaToMemory(IMemoria memory, string npcID, IConjuntoDeRopa conjunto)
		{
			if (conjunto == null || conjunto.piezas.Count == 0)
			{
				Debug.LogError("cant save female outfit to memory, it was empty or null");
				return;
			}
			ConjuntoDeRopa conjuntoDeRopa = new ConjuntoDeRopa();
			conjuntoDeRopa.piezas = new List<Pieza>(conjunto.piezas);
			conjuntoDeRopa.name = "Outfit";
			conjuntoDeRopa.serialVersionPiezas = (conjuntoDeRopa.serialVersionMateriales = 2);
			string text = "root/NPC/" + npcID;
			memory.EscribirDeep(text).AddDataObject("Outfit", conjuntoDeRopa, true);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002198 File Offset: 0x00000398
		public static IConjuntoDeRopa LoadFemaleRopaFromMemory(IMemoria memory, string npcID)
		{
			string text = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode = memory.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				return null;
			}
			ConjuntoDeRopa conjuntoDeRopa;
			jsonMemoryNode.TryFindDataObject("Outfit", out conjuntoDeRopa, null);
			if (conjuntoDeRopa == null || conjuntoDeRopa.piezas.Count == 0)
			{
				Debug.LogWarning("cant load female outfit from memory, it was empty or null");
				return null;
			}
			if (AsyncSingleton<RopaParaAvatarUnificado>.IsInScene && AsyncSingleton<MaterialesParaRopa>.IsInScene)
			{
				ConjuntoDeRopa.VerificarYCorregirIntegridadPiezasConMsg(conjuntoDeRopa, null);
				ConjuntoDeRopa.VerificarYCorregirIntegridadMaterialesConMsg(conjuntoDeRopa, null);
				return conjuntoDeRopa;
			}
			return null;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000220B File Offset: 0x0000040B
		public static void SaveToMemory(IMemoria memory, ICharacter character)
		{
			LoaderDeNpc.SaveToMemory(memory, character);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002214 File Offset: 0x00000414
		public static void SaveToMemory(IMemoria memory, ISujetoIdentificableNpc npc, ICharacter character = null, Texture2D portrait = null)
		{
			MemoriaDeSujetosNpcFemenina.EscribirNpcAMemoriaCompleto(memory, npc, portrait);
			ICharacter character2 = character ?? Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales.Singleton<NPC_to_Character>.instance.TryGet(npc);
			LoaderDeNpcFemeninos.SaveToMemory(memory, character2);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002244 File Offset: 0x00000444
		public static void LoadFromMemory(IMemoria memory, ICharacter character)
		{
			ICharacterGuardableToMemory characterGuardableToMemory = character as ICharacterGuardableToMemory;
			if (characterGuardableToMemory != null)
			{
				characterGuardableToMemory.DoLoadFromMemory(memory);
				return;
			}
			Debug.LogError("cant load memory to brain, no character was found");
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000226D File Offset: 0x0000046D
		public static ISujetoIdentificableNpc ReadFromMemoryNPC(string npcID, IMemoria fromMemory)
		{
			if (!MemoriaDeSujetosNpcFemenina.Contiene(fromMemory, npcID))
			{
				throw new InvalidOperationException(npcID + " NPC is not in memory");
			}
			return MemoriaDeSujetosNpcFemenina.LeerNpcEnMemoria(fromMemory, npcID);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002290 File Offset: 0x00000490
		public static void ReadFromGameMemoryNPC_Character(string npcID, Vector3 position, Quaternion rotation, out ISujetoIdentificableNpc asNPC, out ICharacterIdentificable asCharacter)
		{
			if (!MemoriaDeSujetosNpcFemenina.Contiene(GlobalSingletonV2<MemoriaJson>.instance, npcID))
			{
				throw new InvalidOperationException(npcID + " NPC is not in memory");
			}
			asNPC = MemoriaDeSujetosNpcFemenina.LeerNpcEnMemoria(GlobalSingletonV2<MemoriaJson>.instance, npcID);
			asCharacter = LoaderDeNpcFemeninos.GetDefault(position, rotation);
			if (asCharacter == null)
			{
				asNPC.Destruir();
				throw new ArgumentNullException("asCharacter", "asCharacter null reference.");
			}
			LoaderDeNpcFemeninos.Load(asCharacter, asNPC, true, null, false);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000022FC File Offset: 0x000004FC
		public static void ReadFromGameMemoryNPC_Character(string npcID, ICharacterIdentificable characterExisting, out ISujetoIdentificableNpc asNPC)
		{
			if (characterExisting.isBinded && npcID != characterExisting.ID_Unico.ToString())
			{
				throw new InvalidOperationException();
			}
			if (!MemoriaDeSujetosNpcFemenina.Contiene(GlobalSingletonV2<MemoriaJson>.instance, npcID))
			{
				throw new InvalidOperationException(npcID + " NPC is not in memory");
			}
			asNPC = MemoriaDeSujetosNpcFemenina.LeerNpcEnMemoria(GlobalSingletonV2<MemoriaJson>.instance, npcID);
			LoaderDeNpcFemeninos.Load(characterExisting, asNPC, true, null, false);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000236C File Offset: 0x0000056C
		public static ICharacterIdentificable GetDefault(Vector3 position, Quaternion rotation)
		{
			Quaternion rotation2 = MapaSingleton<CharactersPrefabsGetter>.instance.femaleCharacterDefault.transform.rotation;
			GameObject gameObject = Object.Instantiate<GameObject>(MapaSingleton<CharactersPrefabsGetter>.instance.femaleCharacterDefault, position, rotation2);
			ICharacterIdentificable componentInChildren = gameObject.GetComponentInChildren<ICharacterIdentificable>();
			if (componentInChildren == null)
			{
				Object.Destroy(gameObject);
			}
			GlobalUpdater.instancia.StartCoroutine(LoaderDeNpcFemeninos.SetRotationToNewInstance(componentInChildren, position, rotation));
			return componentInChildren;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000023C4 File Offset: 0x000005C4
		private static IEnumerator SetRotationToNewInstance(ICharacterIdentificable newInstance, Vector3 position, Quaternion rotation)
		{
			while (((newInstance != null) ? newInstance.transform : null) != null && !newInstance.isStared)
			{
				yield return null;
			}
			if (((newInstance != null) ? newInstance.transform : null) == null)
			{
				yield break;
			}
			SolverManager[] solvers = newInstance.GetComponentsInChildren<SolverManager>(false);
			bool allStared = false;
			while (((newInstance != null) ? newInstance.transform : null) != null && !allStared)
			{
				foreach (SolverManager solverManager in solvers)
				{
					allStared = ((solverManager != null) ? new bool?(solverManager.esSolverIniciado) : null).GetValueOrDefault(true);
					if (!allStared)
					{
						break;
					}
				}
				yield return null;
			}
			yield return new WaitForSeconds(0.1f);
			if (((newInstance != null) ? newInstance.transform : null) == null)
			{
				yield break;
			}
			newInstance.SetPositionAndRotation(position, rotation);
			yield break;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000023E4 File Offset: 0x000005E4
		public static void GenerateRandomNPC_Character(Vector3 position, Quaternion rotation, out ISujetoIdentificableNpc asNPC, out ICharacterIdentificable asCharacter)
		{
			SujetoIdentificableNpcAlteradoresFemeninos @default = MapaSingleton<SujetoMapasFemeninosDefectoGetter>.instance.@default;
			asNPC = ProductorDeSujetosNpcFemenina.ProducirSujetoNpc(TipoDeRandomizadoParaSujeto.guiada, TipoDeRandomizadoParaSujeto.guiada, @default, LoaderDeNpcFemeninos.m_randomGen, false, null);
			asCharacter = LoaderDeNpcFemeninos.GetDefault(position, rotation);
			if (asCharacter == null)
			{
				asNPC.Destruir();
				throw new ArgumentNullException("asCharacter", "asCharacter null reference.");
			}
			LoaderDeNpcFemeninos.Load(asCharacter, asNPC, true, null, false);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002440 File Offset: 0x00000640
		public static ISujetoIdentificableNpc GetNewNPCAssetFromCharacter(ICharacterIdentificable character, bool generateNewNpcID)
		{
			MapaDeAlteracionesAparienciaFemeninaIndependiente mapaDeAlteracionesAparienciaFemeninaIndependiente = ScriptableObject.CreateInstance<MapaDeAlteracionesAparienciaFemeninaIndependiente>();
			MapaDeAlteracionesPersonalidadFemeninaIndependiente mapaDeAlteracionesPersonalidadFemeninaIndependiente = ScriptableObject.CreateInstance<MapaDeAlteracionesPersonalidadFemeninaIndependiente>();
			SujetoIdentificableAlteradoresAparienciaFemeninos sujetoIdentificableAlteradoresAparienciaFemeninos = ScriptableObject.CreateInstance<SujetoIdentificableAlteradoresAparienciaFemeninos>();
			SujetoIdentificableAlteradoresPersonalidadFemeninos sujetoIdentificableAlteradoresPersonalidadFemeninos = ScriptableObject.CreateInstance<SujetoIdentificableAlteradoresPersonalidadFemeninos>();
			sujetoIdentificableAlteradoresAparienciaFemeninos.@base = mapaDeAlteracionesAparienciaFemeninaIndependiente;
			sujetoIdentificableAlteradoresAparienciaFemeninos.sujetoID = Guid.NewGuid();
			sujetoIdentificableAlteradoresAparienciaFemeninos.name = sujetoIdentificableAlteradoresAparienciaFemeninos.sujetoID.ToString();
			sujetoIdentificableAlteradoresPersonalidadFemeninos.@base = mapaDeAlteracionesPersonalidadFemeninaIndependiente;
			sujetoIdentificableAlteradoresPersonalidadFemeninos.sujetoID = Guid.NewGuid();
			sujetoIdentificableAlteradoresPersonalidadFemeninos.name = sujetoIdentificableAlteradoresPersonalidadFemeninos.sujetoID.ToString();
			SujetoIdentificableNpcAlteradoresFemeninos sujetoIdentificableNpcAlteradoresFemeninos = ScriptableObject.CreateInstance<SujetoIdentificableNpcAlteradoresFemeninos>();
			sujetoIdentificableNpcAlteradoresFemeninos.NpcID = character.ID_Unico;
			sujetoIdentificableNpcAlteradoresFemeninos.name = sujetoIdentificableNpcAlteradoresFemeninos.NpcID.ToString();
			sujetoIdentificableNpcAlteradoresFemeninos.aparienciaFisicaMapa = sujetoIdentificableAlteradoresAparienciaFemeninos;
			sujetoIdentificableNpcAlteradoresFemeninos.personalidadMapa = sujetoIdentificableAlteradoresPersonalidadFemeninos;
			LoaderDeNpcFemeninos.LoadToMapApariencia(character, sujetoIdentificableNpcAlteradoresFemeninos.aparienciaFisica, !generateNewNpcID);
			LoaderDeNpcFemeninos.LoadToMapPersonalidad(character, sujetoIdentificableNpcAlteradoresFemeninos.personalidad, !generateNewNpcID);
			if (!character.isBinded)
			{
				ProductorDeSujetosNpcFemenina.SetRandomName(sujetoIdentificableNpcAlteradoresFemeninos, LoaderDeNpcFemeninos.m_randomGen);
				ProductorDeSujetosNpcFemenina.SetRandomID(sujetoIdentificableNpcAlteradoresFemeninos);
				LoaderDeNpcFemeninos.LoadNombresAndBind(character, sujetoIdentificableNpcAlteradoresFemeninos, true, false);
			}
			else
			{
				ProductorDeSujetosNpcFemenina.SetName(sujetoIdentificableNpcAlteradoresFemeninos, character.nombre, character.apellido);
				if (generateNewNpcID)
				{
					ProductorDeSujetosNpcFemenina.SetRandomID(sujetoIdentificableNpcAlteradoresFemeninos);
				}
				else
				{
					ProductorDeSujetosNpcFemenina.SetID(sujetoIdentificableNpcAlteradoresFemeninos, character.ID_Unico);
				}
			}
			return sujetoIdentificableNpcAlteradoresFemeninos;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002577 File Offset: 0x00000777
		public static void GetNombresFromGameMemory(string npcID, out string nombre, out string apellido, out string nombreCompleto)
		{
			MemoriaDeSMAModelosFemeninas.GetNombres(GlobalSingletonV2<MemoriaJson>.instance, npcID, out nombre, out apellido, out nombreCompleto);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002588 File Offset: 0x00000788
		public static void GetNombres(ISujetoIdentificableNpc npc, out string nombre, out string apellido, out string nombreCompleto)
		{
			string text = npc.dataContainer.FindData("Nombre");
			nombre = ((text != null) ? text.ToString() : null);
			string text2 = npc.dataContainer.FindData("Apellido");
			apellido = ((text2 != null) ? text2.ToString() : null);
			nombre = nombre ?? string.Empty;
			apellido = apellido ?? string.Empty;
			nombreCompleto = nombre.FirstLetterOrDefaultToUpperCaseOthersToLower() + " " + apellido.FirstLetterOrDefaultToUpperCaseOthersToLower();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002605 File Offset: 0x00000805
		public static void Load(ICharacterIdentificable character, ISujetoIdentificableNpc npc, bool updateNombrables, IMemoria fromMemory = null, bool ignoreBindError = false)
		{
			LoaderDeNpcFemeninos.LoadToCharacterApariencia(character, npc.aparienciaFisica);
			LoaderDeNpcFemeninos.LoadToCharacterPersonalidad(character, npc.personalidad);
			LoaderDeNpcFemeninos.LoadNombresAndBind(character, npc, updateNombrables, ignoreBindError);
			if (fromMemory != null)
			{
				LoaderDeNpcFemeninos.LoadFromMemory(fromMemory, character);
			}
			character.GetComponentNotNull<NPCCharacter>().Init(npc);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002640 File Offset: 0x00000840
		public static void LoadNombresAndBind(ICharacterIdentificable character, ISujetoIdentificableNpc npc, bool updateNombrables, bool ignoreBindError = false)
		{
			string text;
			string text2;
			string text3;
			LoaderDeNpcFemeninos.GetNombres(npc, out text, out text2, out text3);
			LoaderDeNpcFemeninos.BindCharacter(npc.NpcID, text, text2, text3, character, ignoreBindError);
			if (updateNombrables)
			{
				List<INombrable> list = new List<INombrable>();
				character.GetComponentsInChildren<INombrable>(list);
				list.ForEach(delegate(INombrable item)
				{
					item.UpdateName();
				});
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000026A0 File Offset: 0x000008A0
		private static void BindCharacter(Guid ID, string nombre, string apellido, string nombreCompleto, ICharacterIdentificable character, bool ignoreBindError)
		{
			if (character.isBinded)
			{
				if (!ignoreBindError && character.ID_Unico != ID)
				{
					Debug.LogError(string.Concat(new string[]
					{
						"Character: ",
						nombreCompleto,
						"/",
						ID.ToString(),
						" ya ha sido Atado a un id, solo se actualizara su nombre"
					}), (Object)character);
				}
				character.UpdateName(nombreCompleto, nombre, apellido);
				return;
			}
			character.Bind(nombreCompleto, nombre, apellido, ID);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002724 File Offset: 0x00000924
		private static void LoadToCharacterApariencia(ICharacterIdentificable character, ISujetoIdentificable apariencia)
		{
			if (apariencia == null)
			{
				return;
			}
			SujetoIdentificableAlteradoresAparienciaFemeninos sujetoIdentificableAlteradoresAparienciaFemeninos = apariencia as SujetoIdentificableAlteradoresAparienciaFemeninos;
			LoaderDeNpcFemeninos.LoadToCharacterAparienciaFisica(character, (sujetoIdentificableAlteradoresAparienciaFemeninos != null) ? sujetoIdentificableAlteradoresAparienciaFemeninos.@base : null);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002750 File Offset: 0x00000950
		private static void LoadToCharacterPersonalidad(ICharacterIdentificable character, ISujetoIdentificable personalidad)
		{
			if (personalidad == null)
			{
				return;
			}
			SujetoIdentificableAlteradoresPersonalidadFemeninos sujetoIdentificableAlteradoresPersonalidadFemeninos = personalidad as SujetoIdentificableAlteradoresPersonalidadFemeninos;
			LoaderDeNpcFemeninos.LoadToCharacterPersonalidad(character, (sujetoIdentificableAlteradoresPersonalidadFemeninos != null) ? sujetoIdentificableAlteradoresPersonalidadFemeninos.@base : null);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000277C File Offset: 0x0000097C
		private static void LoadToCharacterAparienciaFisica(ICharacterIdentificable character, MapaDeAlteracionesAparienciaFemeninaBase mapa)
		{
			if (mapa == null)
			{
				return;
			}
			AlteradoresDeAparienciaFemenina componentEnRoot = character.GetComponentEnRoot<AlteradoresDeAparienciaFemenina>();
			if (componentEnRoot == null)
			{
				Debug.LogError("character no tiene alteradores", (Object)character);
				return;
			}
			componentEnRoot.mapaDeValores = mapa;
			componentEnRoot.flagToForceUpdateValores = true;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000027C4 File Offset: 0x000009C4
		private static void LoadToCharacterPersonalidad(ICharacterIdentificable character, MapaDeAlteracionesPersonalidadFemeninaBase mapa)
		{
			if (mapa == null)
			{
				return;
			}
			AlteradoresDePersonalidadFemenina componentEnRoot = character.GetComponentEnRoot<AlteradoresDePersonalidadFemenina>();
			if (componentEnRoot == null)
			{
				Debug.LogError("character no tiene alteradores", (Object)character);
				return;
			}
			componentEnRoot.mapaDeValores = mapa;
			componentEnRoot.flagToForceUpdateValores = true;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000280C File Offset: 0x00000A0C
		private static void LoadToMapApariencia(ICharacterIdentificable character, ISujetoIdentificable apariencia, bool saveCurrentMapFirst)
		{
			if (apariencia == null)
			{
				return;
			}
			SujetoIdentificableAlteradoresAparienciaFemeninos sujetoIdentificableAlteradoresAparienciaFemeninos = apariencia as SujetoIdentificableAlteradoresAparienciaFemeninos;
			LoaderDeNpcFemeninos.LoadToMapAparienciaFisica(character, (sujetoIdentificableAlteradoresAparienciaFemeninos != null) ? sujetoIdentificableAlteradoresAparienciaFemeninos.@base : null, saveCurrentMapFirst);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002838 File Offset: 0x00000A38
		private static void LoadToMapPersonalidad(ICharacterIdentificable character, ISujetoIdentificable personalidad, bool saveCurrentMapFirst)
		{
			if (personalidad == null)
			{
				return;
			}
			SujetoIdentificableAlteradoresPersonalidadFemeninos sujetoIdentificableAlteradoresPersonalidadFemeninos = personalidad as SujetoIdentificableAlteradoresPersonalidadFemeninos;
			LoaderDeNpcFemeninos.LoadToMapPersonalidad(character, (sujetoIdentificableAlteradoresPersonalidadFemeninos != null) ? sujetoIdentificableAlteradoresPersonalidadFemeninos.@base : null, saveCurrentMapFirst);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002864 File Offset: 0x00000A64
		private static void LoadToMapAparienciaFisica(ICharacterIdentificable character, MapaDeAlteracionesAparienciaFemeninaBase mapa, bool saveCurrentMapFirst)
		{
			if (mapa == null)
			{
				return;
			}
			AlteradoresDeAparienciaFemenina componentEnRoot = character.GetComponentEnRoot<AlteradoresDeAparienciaFemenina>();
			if (componentEnRoot == null)
			{
				Debug.LogError("character no tiene alteradores", (Object)character);
				return;
			}
			MapaDeAlteracionesAparienciaFemeninaBase mapaDeValores = componentEnRoot.mapaDeValores;
			if (saveCurrentMapFirst && mapaDeValores != null)
			{
				componentEnRoot.Save();
			}
			componentEnRoot.mapaDeValores = mapa;
			componentEnRoot.Save();
			if (mapaDeValores != null)
			{
				componentEnRoot.mapaDeValores = mapaDeValores;
			}
			componentEnRoot.flagToForceUpdateValores = true;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000028DC File Offset: 0x00000ADC
		private static void LoadToMapPersonalidad(ICharacterIdentificable character, MapaDeAlteracionesPersonalidadFemeninaBase mapa, bool saveCurrentMapFirst)
		{
			if (mapa == null)
			{
				return;
			}
			AlteradoresDePersonalidadFemenina componentEnRoot = character.GetComponentEnRoot<AlteradoresDePersonalidadFemenina>();
			if (componentEnRoot == null)
			{
				Debug.LogError("character no tiene alteradores", (Object)character);
				return;
			}
			MapaDeAlteracionesPersonalidadFemeninaBase mapaDeValores = componentEnRoot.mapaDeValores;
			if (saveCurrentMapFirst && mapaDeValores != null)
			{
				componentEnRoot.Save();
			}
			componentEnRoot.mapaDeValores = mapa;
			componentEnRoot.Save();
			if (mapaDeValores != null)
			{
				componentEnRoot.mapaDeValores = mapaDeValores;
			}
			componentEnRoot.flagToForceUpdateValores = true;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002954 File Offset: 0x00000B54
		public static ISujetoIdentificableNpc ReadFromDisk(string archivoNombre, FemaleChar characterEnScena)
		{
			Texture2D texture2D;
			byte[] array;
			SaveLoadCharacters.Cargar(archivoNombre, out texture2D, out array);
			ISujetoIdentificableNpc sujetoIdentificableNpc2;
			try
			{
				ISujetoIdentificableNpc sujetoIdentificableNpc;
				if (array == null || array.Length == 0)
				{
					ErrorDialog modal = Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales.Singleton<ModalWindow>.instance.MostrarErrorDialog();
					modal.pregunta.text = "Invalid Portrait File";
					modal.aceptar.onClick.AddListener(delegate
					{
						Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales.Singleton<ModalWindow>.instance.Clear(modal);
					});
					characterEnScena.gameObject.SetActive(false);
					sujetoIdentificableNpc = null;
				}
				else
				{
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
				}
				sujetoIdentificableNpc2 = sujetoIdentificableNpc;
			}
			finally
			{
				Object.Destroy(texture2D);
			}
			return sujetoIdentificableNpc2;
		}

		// Token: 0x04000001 RID: 1
		private static Random m_randomGen = new Random(Guid.NewGuid().GetHashCode());
	}
}
