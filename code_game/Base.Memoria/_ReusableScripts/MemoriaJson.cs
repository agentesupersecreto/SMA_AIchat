using System;
using System.Linq;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.Memorias.JsonMemorias.Clases;
using UnityEngine;

namespace Assets._ReusableScripts
{
	// Token: 0x02000008 RID: 8
	public sealed class MemoriaJson : GlobalSingletonV2<MemoriaJson>, IMemoria
	{
		// Token: 0x06000011 RID: 17 RVA: 0x000022B9 File Offset: 0x000004B9
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnJuegoLanzado()
		{
			SingletonV2<MemoriaJson>.Iniciar();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000022C0 File Offset: 0x000004C0
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void BeforeJuegoLanzado()
		{
			SingletonV2<MemoriaJson>.Finalizar();
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000013 RID: 19 RVA: 0x000022C8 File Offset: 0x000004C8
		// (remove) Token: 0x06000014 RID: 20 RVA: 0x00002300 File Offset: 0x00000500
		public event Action<MemoriaJson> savingToDisk;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000015 RID: 21 RVA: 0x00002338 File Offset: 0x00000538
		// (remove) Token: 0x06000016 RID: 22 RVA: 0x00002370 File Offset: 0x00000570
		public event Action<MemoriaJson> justLoadedFromDisk;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000017 RID: 23 RVA: 0x000023A8 File Offset: 0x000005A8
		// (remove) Token: 0x06000018 RID: 24 RVA: 0x000023E0 File Offset: 0x000005E0
		public event Action<MemoriaJson> loadedFromDisk;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000019 RID: 25 RVA: 0x00002418 File Offset: 0x00000618
		// (remove) Token: 0x0600001A RID: 26 RVA: 0x00002450 File Offset: 0x00000650
		public event Action<MemoriaJson> onResetMemory;

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00002485 File Offset: 0x00000685
		public bool isLoadedFromDisk
		{
			get
			{
				return this.m_isLoadedFromDisk;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000248D File Offset: 0x0000068D
		public IJsonMemoryNode root
		{
			get
			{
				return this.m_memoria;
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002495 File Offset: 0x00000695
		protected override void BeforeInitData()
		{
			this.InitMemory();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000024A0 File Offset: 0x000006A0
		private void InitMemory()
		{
			if (this.m_rootInitialMemory == null)
			{
				this.m_rootInitialMemory = base.transform.GetComponentInChildren<NodeDeMemoriaBehaviour>();
				if (this.m_rootInitialMemory == null)
				{
					this.m_rootInitialMemory = base.transform.CreateChild("root").gameObject.AddComponent<NodeDeMemoriaBehaviour>();
				}
			}
			this.m_memoria = JsonMemoryNode.ProducirRoot("root", this);
			this.m_rootInitialMemory.Load(this.m_memoria);
			this.m_rootInitialMemory.SaveToNode(this.m_memoria);
			this.InyectJson(this.m_jsonInyect);
			this.m_jsonInyect = string.Empty;
			this.InyectJsonFile(this.m_InyectFile);
			this.m_InyectFile = string.Empty;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000255B File Offset: 0x0000075B
		private void InyectJson(string jsonInyect)
		{
			if (!string.IsNullOrWhiteSpace(jsonInyect))
			{
				((IMemoryNode<string, string>)this.m_memoria).Load(jsonInyect);
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002574 File Offset: 0x00000774
		private void InyectJsonFile(string InyectFile)
		{
			if (!string.IsNullOrWhiteSpace(InyectFile))
			{
				string text = SaveLoadJson.CargarDebugInyect(InyectFile);
				((IMemoryNode<string, string>)this.m_memoria).Load(text);
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000259C File Offset: 0x0000079C
		protected override void InitData(bool esEditorTime)
		{
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000025A0 File Offset: 0x000007A0
		public IJsonMemoryNode EscribirDeep(string nodeRuta)
		{
			return this.LeerDeep(nodeRuta, true);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000025AC File Offset: 0x000007AC
		public IJsonMemoryNode LeerDeep(string nodeRuta, bool crear = false)
		{
			string[] array = nodeRuta.Split('/', StringSplitOptions.None);
			IJsonMemoryNode memoria = this.m_memoria;
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				if ((i != 0 || !(text == "root") || !(memoria.nodeID == text)) && !string.IsNullOrEmpty(text))
				{
					this.Leer(text, ref memoria, crear);
					if (memoria == null)
					{
						return null;
					}
				}
			}
			return memoria;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002612 File Offset: 0x00000812
		public void Leer(string nodeId, ref IJsonMemoryNode node, bool crear = false)
		{
			if (nodeId == null || node == null)
			{
				throw new NotSupportedException();
			}
			if (string.Empty == nodeId)
			{
				return;
			}
			if (!crear)
			{
				node = (IJsonMemoryNode)node.FindChild(nodeId);
				return;
			}
			node = (IJsonMemoryNode)node.FindChildNotNull(nodeId);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002654 File Offset: 0x00000854
		public IJsonMemoryNode RemoverDeep(string nodeRuta)
		{
			string[] array = nodeRuta.Split('/', StringSplitOptions.None);
			if (array.Length <= 1)
			{
				Debug.LogWarning("Rota: " + nodeRuta + ", es muy corta. Remover directamente");
			}
			IJsonMemoryNode memoria = this.m_memoria;
			for (int i = 0; i < array.Length - 1; i++)
			{
				string text = array[i];
				if ((i != 0 || !(text == "root") || !(memoria.nodeID == text)) && !string.IsNullOrEmpty(text))
				{
					this.Leer(text, ref memoria, false);
					if (memoria == null)
					{
						return null;
					}
				}
			}
			if (memoria != null)
			{
				return this.Remover(array.Last<string>(), memoria);
			}
			return null;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000026E8 File Offset: 0x000008E8
		public IJsonMemoryNode Remover(string nodeId, IJsonMemoryNode parent)
		{
			if (nodeId == null)
			{
				throw new NotSupportedException();
			}
			if (string.Empty == nodeId)
			{
				return null;
			}
			if (parent == null)
			{
				parent = this.m_memoria;
			}
			IJsonMemoryNode jsonMemoryNode = (IJsonMemoryNode)parent.FindChild(nodeId);
			if (jsonMemoryNode != null)
			{
				parent.RemoverChild(jsonMemoryNode);
			}
			return jsonMemoryNode;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002731 File Offset: 0x00000931
		protected override void OnAwake()
		{
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002733 File Offset: 0x00000933
		protected override void OnGlobalizado()
		{
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002738 File Offset: 0x00000938
		public void LoadFromDiskMasReciente()
		{
			int num;
			if (SaveLoadJson.ExisteAny_VerisonDos(out num))
			{
				if (num != 2)
				{
					throw new InvalidOperationException();
				}
				string text = SaveLoadJson.CargarMasReciente(GameFolders.Tipo.saveV2);
				((IMemoryNode<string, string>)this.m_memoria).Load(text);
			}
			this.m_isLoadedFromDisk = true;
			Action<MemoriaJson> action = this.justLoadedFromDisk;
			if (action != null)
			{
				action(this);
			}
			Action<MemoriaJson> action2 = this.loadedFromDisk;
			if (action2 == null)
			{
				return;
			}
			action2(this);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002798 File Offset: 0x00000998
		public void LoadFromDisk(string archivo)
		{
			int num;
			if (SaveLoadJson.Existe_VerisonDos(archivo, out num))
			{
				if (num != 2)
				{
					throw new InvalidOperationException();
				}
				string text = SaveLoadJson.CargarV2(archivo);
				((IMemoryNode<string, string>)this.m_memoria).Load(text);
			}
			this.m_isLoadedFromDisk = true;
			Action<MemoriaJson> action = this.justLoadedFromDisk;
			if (action != null)
			{
				action(this);
			}
			Action<MemoriaJson> action2 = this.loadedFromDisk;
			if (action2 == null)
			{
				return;
			}
			action2(this);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000027F8 File Offset: 0x000009F8
		public void SaveToDisk(string archivo)
		{
			Action<MemoriaJson> action = this.savingToDisk;
			if (action != null)
			{
				action(this);
			}
			string text = this.m_memoria.Save();
			SaveLoadJson.Guardar2(archivo, text);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000282A File Offset: 0x00000A2A
		public void ResetLoadedMemoria()
		{
			this.m_memoria.ResetMemoria();
			this.m_isLoadedFromDisk = false;
			this.InitMemory();
			Action<MemoriaJson> action = this.onResetMemory;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002855 File Offset: 0x00000A55
		public void LoadFromDiskDefaultFile()
		{
			this.LoadFromDisk("Default");
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002862 File Offset: 0x00000A62
		public void SaveToDiskDefaultFile()
		{
			this.SaveToDisk("Default");
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000286F File Offset: 0x00000A6F
		public bool ExisteDefaultFile(out int version)
		{
			return SaveLoadJson.Existe_VerisonDos("Default", out version);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000287C File Offset: 0x00000A7C
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				confirmar = true,
				text = "Save To: Debug File",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000289C File Offset: 0x00000A9C
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.SaveToDisk("DEBUG");
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000028AF File Offset: 0x00000AAF
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				confirmar = true,
				text = "Load Desde Memoria",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000028CF File Offset: 0x00000ACF
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000028D7 File Offset: 0x00000AD7
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				confirmar = true,
				text = "Save a Memoria",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000028F7 File Offset: 0x00000AF7
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			this.SaveToDiskDefaultFile();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002905 File Offset: 0x00000B05
		protected override CustomMonobehaviourBotonConfig Boton4()
		{
			return new CustomMonobehaviourBotonConfig
			{
				confirmar = true,
				text = "Print Memoria",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002925 File Offset: 0x00000B25
		protected override void OnAplicar4()
		{
			base.OnAplicar4();
			HandleTextFile.WriteTextFile(this.pathDebug, JsonUtility.ToJson(this.m_memoria, true));
			MonoBehaviour.print("Memory Dumped");
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000294E File Offset: 0x00000B4E
		protected override CustomMonobehaviourBotonConfig Boton6()
		{
			return new CustomMonobehaviourBotonConfig
			{
				confirmar = true,
				text = "Inyect Json",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000296E File Offset: 0x00000B6E
		protected override void OnAplicar6()
		{
			base.OnAplicar6();
			this.InyectJson(this.m_jsonInyect);
			this.m_jsonInyect = string.Empty;
			this.InyectJsonFile(this.m_InyectFile);
			this.m_InyectFile = string.Empty;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000029A4 File Offset: 0x00000BA4
		protected override CustomMonobehaviourBotonConfig Boton5()
		{
			return new CustomMonobehaviourBotonConfig
			{
				confirmar = true,
				text = "Clear Inyect Json",
				playTimeVisible = false
			};
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000029C4 File Offset: 0x00000BC4
		protected override void OnAplicar5()
		{
			base.OnAplicar5();
			this.m_jsonInyect = string.Empty;
		}

		// Token: 0x04000020 RID: 32
		[ReadOnlyUI]
		[SerializeField]
		private bool m_isLoadedFromDisk;

		// Token: 0x04000021 RID: 33
		[SerializeField]
		private NodeDeMemoriaBehaviour m_rootInitialMemory;

		// Token: 0x04000022 RID: 34
		[NonSerialized]
		private JsonMemoryNode m_memoria;

		// Token: 0x04000023 RID: 35
		[TextArea]
		[SerializeField]
		private string m_jsonInyect;

		// Token: 0x04000024 RID: 36
		[SerializeField]
		private string m_InyectFile;

		// Token: 0x04000025 RID: 37
		public string pathDebug = "Assets/DEBUG_PRINT/MemoryDump.txt";
	}
}
