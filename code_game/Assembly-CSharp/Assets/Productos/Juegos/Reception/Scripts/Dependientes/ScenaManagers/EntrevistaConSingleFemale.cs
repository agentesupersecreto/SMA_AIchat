using System;
using System.Collections;
using System.Text;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Clases;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using InterfaceFields;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Productos.Juegos.Reception.Scripts.Dependientes.ScenaManagers
{
	// Token: 0x020000BD RID: 189
	public class EntrevistaConSingleFemale : EntrevistaConFemale
	{
		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x00015345 File Offset: 0x00013545
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x00015352 File Offset: 0x00013552
		public ISujetoIdentificableNpc currentNpc
		{
			get
			{
				return this.m_currentNpc as ISujetoIdentificableNpc;
			}
			private set
			{
				this.m_currentNpc = value as Object;
			}
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00015360 File Offset: 0x00013560
		protected override void OnAwake()
		{
			base.OnAwake();
			base.SetYieldStart();
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0001536E File Offset: 0x0001356E
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (!base.scenaLoaded)
			{
				yield return null;
			}
			if (this.m_emptyCharacter != null)
			{
				while (!this.m_emptyCharacter.isAILoaded)
				{
					yield return null;
				}
				while (!this.m_emptyCharacter.apareienciaFisicaLoaded)
				{
					yield return null;
				}
				this.ProducircurrentNpcFromCurrentCharacter(this.m_emptyCharacter);
				this.m_emptyCharacter = null;
			}
			if (this.m_conjuntoToLoad != null)
			{
				yield return AsyncSingleton<RopaParaAvatarUnificado>.TryIniciar();
				yield return AsyncSingleton<MaterialesParaRopa>.TryIniciar();
				IRopaManager componentInChildren = base.currentFemaleCharacter.self.GetComponentInChildren<IRopaManager>();
				if (componentInChildren != null && this.m_conjuntoToLoad != null && !string.IsNullOrWhiteSpace(this.m_conjuntoToLoad.name))
				{
					ConjuntoDeRopa.VerificarYCorregirIntegridadPiezasConMsg(this.m_conjuntoToLoad, null);
					ConjuntoDeRopa.VerificarYCorregirIntegridadMaterialesConMsg(this.m_conjuntoToLoad, null);
					yield return componentInChildren.LoadConjuntoAsset(this.m_conjuntoToLoad, true, null, true);
					this.m_conjuntoToLoad = null;
				}
			}
			yield break;
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00015380 File Offset: 0x00013580
		protected override void OnScenaAndFemaleCharacterLoaded(LoadSceneMode loadSceneMode, FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter)
		{
			base.OnScenaAndFemaleCharacterLoaded(loadSceneMode, characterEnScena, rootForManagerLogicInCharacter);
			string @string = PlayerPrefs.GetString("SingleModelSelected");
			if (!string.IsNullOrWhiteSpace(@string))
			{
				Texture2D texture2D;
				byte[] array;
				SaveLoadCharacters.Cargar(@string, out texture2D, out array);
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
						this.currentNpc = MemoriaDeSujetosNpcFemenina.LeerNpcEnMemoriaFirstOrDefault(memoriaJsonGenerica);
						LoaderDeNpcFemeninos.Load(characterEnScena, this.currentNpc, true, memoriaJsonGenerica, false);
						if (savingFemaleCharacterJsonMemoryNode.ropa != null && !string.IsNullOrWhiteSpace(savingFemaleCharacterJsonMemoryNode.ropa.name))
						{
							this.m_conjuntoToLoad = savingFemaleCharacterJsonMemoryNode.ropa;
							IRopaDeCharacterAdmin componentInChildren = characterEnScena.self.GetComponentInChildren<IRopaDeCharacterAdmin>();
							if (componentInChildren != null)
							{
								componentInChildren.generar = false;
							}
						}
					}
				}
				finally
				{
					Object.Destroy(texture2D);
				}
				return;
			}
			if (characterEnScena.apareienciaFisicaLoaded && characterEnScena.isAILoaded)
			{
				this.ProducircurrentNpcFromCurrentCharacter(characterEnScena);
				return;
			}
			this.m_emptyCharacter = characterEnScena;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00015500 File Offset: 0x00013700
		private void ProducircurrentNpcFromCurrentCharacter(FemaleChar characterEnScena)
		{
			this.currentNpc = LoaderDeNpcFemeninos.GetNewNPCAssetFromCharacter(characterEnScena, true);
			if (this.currentNpc == null)
			{
				Debug.LogError("No se pudo producir npc", this);
			}
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00015522 File Offset: 0x00013722
		protected override void OnDestroyed()
		{
			base.OnDestroyed();
			ISujetoIdentificableNpc currentNpc = this.currentNpc;
			if (currentNpc != null)
			{
				currentNpc.Destruir();
			}
			this.currentNpc = null;
		}

		// Token: 0x040001E6 RID: 486
		[ConstraintType(typeof(ISujetoIdentificableNpc), true)]
		[SerializeField]
		private Object m_currentNpc;

		// Token: 0x040001E7 RID: 487
		private FemaleChar m_emptyCharacter;

		// Token: 0x040001E8 RID: 488
		private ConjuntoDeRopa m_conjuntoToLoad;
	}
}
