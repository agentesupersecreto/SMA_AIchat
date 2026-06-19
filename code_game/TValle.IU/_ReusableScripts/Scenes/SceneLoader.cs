using System;
using System.Collections;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

namespace Assets._ReusableScripts.Scenes
{
	// Token: 0x02000006 RID: 6
	public class SceneLoader : Singleton<SceneLoader>, IComponentEnabable, IComponentStartable
	{
		// Token: 0x06000015 RID: 21 RVA: 0x0000234B File Offset: 0x0000054B
		public IEnumerator PreloadScene(AssetReference sceneAsset)
		{
			AsyncOperationHandle asyncOperationHandle;
			if (this.m_preloadedScenes.TryGetValue(sceneAsset, out asyncOperationHandle) && asyncOperationHandle.IsValid())
			{
				yield break;
			}
			AsyncOperationHandle handle = Addressables.DownloadDependenciesAsync(sceneAsset, false);
			yield return handle;
			this.m_preloadedScenes[sceneAsset] = handle;
			yield break;
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002361 File Offset: 0x00000561
		public bool initialLoadsDisabled
		{
			get
			{
				return this.m_disableIniitalLoads;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002369 File Offset: 0x00000569
		public bool isLoading
		{
			get
			{
				return this.m_waitingDefaultScena || this.m_waitingPedido || this.m_colaDePedidos.Count > 0;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000018 RID: 24 RVA: 0x0000238B File Offset: 0x0000058B
		public bool isStared
		{
			get
			{
				return this.m_isStared;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000019 RID: 25 RVA: 0x00002394 File Offset: 0x00000594
		// (remove) Token: 0x0600001A RID: 26 RVA: 0x000023CC File Offset: 0x000005CC
		public event Action<object> onEnabled;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600001B RID: 27 RVA: 0x00002404 File Offset: 0x00000604
		// (remove) Token: 0x0600001C RID: 28 RVA: 0x0000243C File Offset: 0x0000063C
		public event Action<object> onDisabled;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600001D RID: 29 RVA: 0x00002474 File Offset: 0x00000674
		// (remove) Token: 0x0600001E RID: 30 RVA: 0x000024AC File Offset: 0x000006AC
		public event CustomMonobehaviourEventHandler staring;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600001F RID: 31 RVA: 0x000024E4 File Offset: 0x000006E4
		// (remove) Token: 0x06000020 RID: 32 RVA: 0x0000251C File Offset: 0x0000071C
		public event CustomMonobehaviourEventHandler justStared;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000021 RID: 33 RVA: 0x00002554 File Offset: 0x00000754
		// (remove) Token: 0x06000022 RID: 34 RVA: 0x0000258C File Offset: 0x0000078C
		public event CustomMonobehaviourEventHandler stared;

		// Token: 0x06000023 RID: 35 RVA: 0x000025C1 File Offset: 0x000007C1
		private void OnEnable()
		{
			Action<object> action = this.onEnabled;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000025D4 File Offset: 0x000007D4
		private void OnDisable()
		{
			if (this.destroyingCopy)
			{
				return;
			}
			Action<object> action = this.onDisabled;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000025F0 File Offset: 0x000007F0
		private void Start()
		{
			CustomMonobehaviourEventHandler customMonobehaviourEventHandler = this.staring;
			if (customMonobehaviourEventHandler != null)
			{
				customMonobehaviourEventHandler(this);
			}
			if (!this.m_disableIniitalLoads && this.m_defaultScenaBuildIndex > 0)
			{
				this.LoadDefault();
			}
			this.m_isStared = true;
			CustomMonobehaviourEventHandler customMonobehaviourEventHandler2 = this.justStared;
			if (customMonobehaviourEventHandler2 != null)
			{
				customMonobehaviourEventHandler2(this);
			}
			this.justStared = null;
			CustomMonobehaviourEventHandler customMonobehaviourEventHandler3 = this.stared;
			if (customMonobehaviourEventHandler3 != null)
			{
				customMonobehaviourEventHandler3(this);
			}
			this.stared = null;
			if (this.m_coroutine == null)
			{
				throw new ArgumentNullException("m_coroutine", "m_coroutine null reference.");
			}
			this.m_coroutine.Start(this.UpdateSceneLoader(), null, null);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002693 File Offset: 0x00000893
		public void ManualStart()
		{
			this.Start();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000269B File Offset: 0x0000089B
		public void AddPedido(SceneLoader.Pedido pedido)
		{
			this.m_colaDePedidos.Enqueue(pedido);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000026A9 File Offset: 0x000008A9
		protected override void InitData(bool esEditorTime)
		{
			if (!esEditorTime)
			{
				this.m_coroutine = new CoroutineCapsuleGeneric<SceneLoader>(this, new CoroutineCapsuleConfig
				{
					autoRestart = true
				});
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000026C6 File Offset: 0x000008C6
		protected override void DoAwake()
		{
			base.DoAwake();
			this.m_hidingLoadingUI = Singleton<LoadingPanel>.instance.hidingModificable.ObtenerModificadorNotNull(this);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000026E4 File Offset: 0x000008E4
		protected override void OnDestroyed(bool wasInitiated)
		{
			base.OnDestroyed(wasInitiated);
			ModificadorDeBool hidingLoadingUI = this.m_hidingLoadingUI;
			if (hidingLoadingUI == null)
			{
				return;
			}
			hidingLoadingUI.TryRemoverDeOwner(true);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002700 File Offset: 0x00000900
		public static bool EscenaYaEstaCargada(int buildIndex)
		{
			return SceneLoader.EscenaYaEstaCargada(new SceneLoader.Scena
			{
				index = buildIndex
			});
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002724 File Offset: 0x00000924
		public static bool EscenaYaEstaCargada(SceneLoader.Scena scena)
		{
			if (scena.index >= 0)
			{
				for (int i = 0; i < SceneManager.sceneCount; i++)
				{
					if (scena.index == SceneManager.GetSceneAt(i).buildIndex)
					{
						return true;
					}
				}
			}
			else if (!string.IsNullOrWhiteSpace(scena.path))
			{
				for (int j = 0; j < SceneManager.sceneCount; j++)
				{
					if (scena.path == SceneManager.GetSceneAt(j).path)
					{
						return true;
					}
				}
			}
			else
			{
				AssetReference address = scena.address;
				if (!string.IsNullOrWhiteSpace((address != null) ? address.AssetGUID : null))
				{
					return scena.address.IsDone;
				}
				if (scena.scene.IsValid())
				{
					return scena.scene.isLoaded;
				}
			}
			return false;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000027E4 File Offset: 0x000009E4
		public static bool EscenaYaEstaCerrada(int buildIndex)
		{
			return SceneLoader.EscenaYaEstaCerrada(new SceneLoader.Scena
			{
				index = buildIndex
			});
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002808 File Offset: 0x00000A08
		public static bool EscenaYaEstaCerrada(SceneLoader.Scena scena)
		{
			if (scena.index >= 0)
			{
				for (int i = 0; i < SceneManager.sceneCount; i++)
				{
					if (scena.index == SceneManager.GetSceneAt(i).buildIndex)
					{
						return false;
					}
				}
			}
			else if (!string.IsNullOrWhiteSpace(scena.path))
			{
				for (int j = 0; j < SceneManager.sceneCount; j++)
				{
					if (scena.path == SceneManager.GetSceneAt(j).path)
					{
						return false;
					}
				}
			}
			else
			{
				AssetReference address = scena.address;
				if (!string.IsNullOrWhiteSpace((address != null) ? address.AssetGUID : null))
				{
					return !scena.address.IsDone;
				}
				if (scena.scene.IsValid())
				{
					return !scena.scene.isLoaded;
				}
			}
			return true;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000028D0 File Offset: 0x00000AD0
		private void LoadDefault()
		{
			this.m_waitingDefaultScena = true;
			this.m_hidingLoadingUI.valor.valor = false;
			Singleton<LoadingPanel>.instance.Update();
			if (SceneLoader.EscenaYaEstaCargada(new SceneLoader.Scena
			{
				index = this.m_defaultScenaBuildIndex
			}))
			{
				return;
			}
			this.m_defaultScenaOperation = SceneManager.LoadSceneAsync(this.m_defaultScenaBuildIndex, LoadSceneMode.Additive);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000292F File Offset: 0x00000B2F
		private IEnumerator UpdateSceneLoader()
		{
			for (;;)
			{
				if (this.m_waitingDefaultScena)
				{
					if (this.m_defaultScenaOperation == null || this.m_defaultScenaOperation.isDone)
					{
						this.m_waitingDefaultScena = false;
						this.m_defaultScenaOperation = null;
						this.m_hidingLoadingUI.valor.valor = true;
						foreach (int num in this.m_extraDefaultScenes)
						{
							if (!this.m_disableIniitalLoads)
							{
								SceneLoader.Pedido @default = SceneLoader.Pedido.@default;
								@default.scene.index = num;
								this.AddPedido(@default);
							}
						}
						this.m_extraDefaultScenes.Clear();
					}
					yield return null;
				}
				else
				{
					if (this.m_colaDePedidos.Count == 0 && !this.m_waitingPedido)
					{
						this.m_hidingLoadingUI.valor.valor = true;
					}
					if (this.m_waitingPedido)
					{
						if (this.m_pedidoScenaOperation == null || this.m_pedidoScenaOperation.isDone)
						{
							this.m_waitingPedido = false;
							this.m_pedidoScenaOperation = null;
							SceneLoader.Pedido finalizado = this.m_currentPedido;
							this.m_currentPedido = null;
							if (!finalizado.doLoadOrDoUnload)
							{
								yield return Resources.UnloadUnusedAssets();
							}
							finalizado.PedidoFinalizado();
							finalizado = null;
						}
						yield return null;
					}
					else
					{
						if (this.m_colaDePedidos.Count > 0)
						{
							SceneLoader.Pedido finalizado = this.m_colaDePedidos.Dequeue();
							if (finalizado.doLoadOrDoUnload)
							{
								if (!SceneLoader.EscenaYaEstaCargada(finalizado.scene))
								{
									this.m_currentPedido = finalizado;
									this.m_waitingPedido = true;
									this.m_hidingLoadingUI.valor.valor = false;
									if (Singleton<LoadingPanel>.IsInScene)
									{
										Singleton<LoadingPanel>.instance.Update();
									}
									yield return null;
									if (finalizado.scene.index == 0)
									{
										yield return null;
										yield return SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
										this.m_hidingLoadingUI = Singleton<LoadingPanel>.instance.hidingModificable.ObtenerModificadorNotNull(this);
										yield return SceneManager.UnloadSceneAsync(8);
										yield return null;
										yield return Resources.UnloadUnusedAssets();
										this.m_pedidoScenaOperation = null;
									}
									else
									{
										this.m_pedidoScenaOperation = finalizado.scene.Load(LoadSceneMode.Additive);
									}
								}
								else
								{
									finalizado.PedidoFinalizado();
								}
							}
							else if (!finalizado.doLoadOrDoUnload)
							{
								if (!SceneLoader.EscenaYaEstaCerrada(finalizado.scene))
								{
									this.m_currentPedido = finalizado;
									this.m_waitingPedido = true;
									this.m_hidingLoadingUI.valor.valor = false;
									if (Singleton<LoadingPanel>.IsInScene)
									{
										Singleton<LoadingPanel>.instance.Update();
									}
									yield return null;
									if (finalizado.scene.index == 0)
									{
										yield return null;
										yield return SceneManager.LoadSceneAsync(8, LoadSceneMode.Additive);
										ModificadorDeBool hidingLoadingUI = this.m_hidingLoadingUI;
										if (hidingLoadingUI != null)
										{
											hidingLoadingUI.TryRemoverDeOwner(true);
										}
										yield return SceneManager.UnloadSceneAsync(0);
										yield return null;
										yield return Resources.UnloadUnusedAssets();
										this.m_pedidoScenaOperation = null;
									}
									else
									{
										this.m_pedidoScenaOperation = finalizado.scene.Unload();
									}
								}
								else
								{
									finalizado.PedidoFinalizado();
								}
							}
							finalizado = null;
						}
						yield return null;
					}
				}
			}
			yield break;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002940 File Offset: 0x00000B40
		public override void Aplicar2()
		{
			this.AddPedido(new SceneLoader.Pedido
			{
				doLoadOrDoUnload = this.m_debugDoLoad,
				scene = new SceneLoader.Scena
				{
					index = this.m_debugSceneIndex
				}
			});
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002980 File Offset: 0x00000B80
		public override SingletonEditorBotones Boton2()
		{
			return new SingletonEditorBotones
			{
				editorTimeVisible = false,
				text = "Do Debug Load/Unload"
			};
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000029C2 File Offset: 0x00000BC2
		bool IComponentEnabable.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x0400000C RID: 12
		private Dictionary<AssetReference, AsyncOperationHandle> m_preloadedScenes = new Dictionary<AssetReference, AsyncOperationHandle>();

		// Token: 0x0400000D RID: 13
		public const int dummySceneIndex = 8;

		// Token: 0x0400000E RID: 14
		[SerializeField]
		private bool m_disableIniitalLoads;

		// Token: 0x0400000F RID: 15
		[SerializeField]
		private int m_defaultScenaBuildIndex;

		// Token: 0x04000010 RID: 16
		[SerializeField]
		private List<int> m_extraDefaultScenes = new List<int>();

		// Token: 0x04000011 RID: 17
		[NonSerialized]
		private AsyncOperation m_defaultScenaOperation;

		// Token: 0x04000012 RID: 18
		[NonSerialized]
		private bool m_waitingDefaultScena;

		// Token: 0x04000013 RID: 19
		private Queue<SceneLoader.Pedido> m_colaDePedidos = new Queue<SceneLoader.Pedido>();

		// Token: 0x04000014 RID: 20
		[NonSerialized]
		private AsyncOperation m_pedidoScenaOperation;

		// Token: 0x04000015 RID: 21
		[NonSerialized]
		private bool m_waitingPedido;

		// Token: 0x04000016 RID: 22
		[NonSerialized]
		private SceneLoader.Pedido m_currentPedido;

		// Token: 0x04000017 RID: 23
		[SerializeField]
		private ModificadorDeBool m_hidingLoadingUI;

		// Token: 0x04000018 RID: 24
		[NonSerialized]
		private bool m_isStared;

		// Token: 0x0400001E RID: 30
		private CoroutineCapsuleGeneric<SceneLoader> m_coroutine;

		// Token: 0x0400001F RID: 31
		[Header("-> DEBUG <-")]
		[SerializeField]
		private bool m_debugDoLoad;

		// Token: 0x04000020 RID: 32
		[SerializeField]
		private int m_debugSceneIndex;

		// Token: 0x0200015D RID: 349
		public struct Scena
		{
			// Token: 0x170002CE RID: 718
			// (get) Token: 0x06000A50 RID: 2640 RVA: 0x00022114 File Offset: 0x00020314
			public static SceneLoader.Scena @default
			{
				get
				{
					return new SceneLoader.Scena
					{
						index = -1,
						path = null,
						address = null,
						scene = default(Scene)
					};
				}
			}

			// Token: 0x170002CF RID: 719
			// (get) Token: 0x06000A51 RID: 2641 RVA: 0x0002214F File Offset: 0x0002034F
			public bool isValid
			{
				get
				{
					if (this.index < 0 && string.IsNullOrWhiteSpace(this.path))
					{
						AssetReference assetReference = this.address;
						if (string.IsNullOrWhiteSpace((assetReference != null) ? assetReference.AssetGUID : null))
						{
							return this.scene.IsValid();
						}
					}
					return true;
				}
			}

			// Token: 0x06000A52 RID: 2642 RVA: 0x00022190 File Offset: 0x00020390
			public AsyncOperation Load(LoadSceneMode mode)
			{
				if (!this.isValid)
				{
					throw new InvalidOperationException();
				}
				if (this.index >= 0)
				{
					return SceneManager.LoadSceneAsync(this.index, mode);
				}
				if (!string.IsNullOrWhiteSpace(this.path))
				{
					return SceneManager.LoadSceneAsync(this.path, mode);
				}
				AssetReference assetReference = this.address;
				if (!string.IsNullOrWhiteSpace((assetReference != null) ? assetReference.AssetGUID : null))
				{
					throw new NotImplementedException();
				}
				if (this.scene.IsValid())
				{
					return SceneManager.LoadSceneAsync(this.scene.path, mode);
				}
				throw new ArgumentOutOfRangeException();
			}

			// Token: 0x06000A53 RID: 2643 RVA: 0x00022220 File Offset: 0x00020420
			public AsyncOperation Unload()
			{
				if (!this.isValid)
				{
					throw new InvalidOperationException();
				}
				if (this.index >= 0)
				{
					return SceneManager.UnloadSceneAsync(this.index, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
				}
				if (this.scene.IsValid())
				{
					return SceneManager.UnloadSceneAsync(this.scene, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
				}
				if (!string.IsNullOrWhiteSpace(this.path))
				{
					return SceneManager.UnloadSceneAsync(this.path, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
				}
				AssetReference assetReference = this.address;
				if (!string.IsNullOrWhiteSpace((assetReference != null) ? assetReference.AssetGUID : null))
				{
					throw new NotImplementedException();
				}
				throw new ArgumentOutOfRangeException();
			}

			// Token: 0x04000445 RID: 1093
			public int index;

			// Token: 0x04000446 RID: 1094
			public string path;

			// Token: 0x04000447 RID: 1095
			public Scene scene;

			// Token: 0x04000448 RID: 1096
			public AssetReference address;
		}

		// Token: 0x0200015E RID: 350
		public class Pedido
		{
			// Token: 0x170002D0 RID: 720
			// (get) Token: 0x06000A54 RID: 2644 RVA: 0x000222A9 File Offset: 0x000204A9
			public static SceneLoader.Pedido @default
			{
				get
				{
					return new SceneLoader.Pedido
					{
						doLoadOrDoUnload = true,
						scene = SceneLoader.Scena.@default
					};
				}
			}

			// Token: 0x170002D1 RID: 721
			// (get) Token: 0x06000A55 RID: 2645 RVA: 0x000222C2 File Offset: 0x000204C2
			[Obsolete("usar scene")]
			public int scenaIndex
			{
				get
				{
					return this.scene.index;
				}
			}

			// Token: 0x1400005E RID: 94
			// (add) Token: 0x06000A56 RID: 2646 RVA: 0x000222D0 File Offset: 0x000204D0
			// (remove) Token: 0x06000A57 RID: 2647 RVA: 0x00022308 File Offset: 0x00020508
			public event Action<SceneLoader.Pedido> onPedidoFinalizado;

			// Token: 0x170002D2 RID: 722
			// (get) Token: 0x06000A58 RID: 2648 RVA: 0x0002233D File Offset: 0x0002053D
			public bool finalizado
			{
				get
				{
					return this.m_finalizado;
				}
			}

			// Token: 0x06000A59 RID: 2649 RVA: 0x00022345 File Offset: 0x00020545
			internal void PedidoFinalizado()
			{
				this.m_finalizado = true;
				Action<SceneLoader.Pedido> action = this.onPedidoFinalizado;
				if (action == null)
				{
					return;
				}
				action(this);
			}

			// Token: 0x170002D3 RID: 723
			// (get) Token: 0x06000A5A RID: 2650 RVA: 0x0002235F File Offset: 0x0002055F
			// (set) Token: 0x06000A5B RID: 2651 RVA: 0x00022367 File Offset: 0x00020567
			[Obsolete("Use doLoadOrDoUnload: true to load , false to unload scene")]
			public bool load
			{
				get
				{
					return this.doLoadOrDoUnload;
				}
				set
				{
					this.doLoadOrDoUnload = value;
				}
			}

			// Token: 0x04000449 RID: 1097
			public SceneLoader.Scena scene;

			// Token: 0x0400044A RID: 1098
			public bool doLoadOrDoUnload;

			// Token: 0x0400044C RID: 1100
			private bool m_finalizado;

			// Token: 0x0400044D RID: 1101
			[Obsolete]
			public bool puedeMostrarLoadingPanel;

			// Token: 0x0400044E RID: 1102
			[Obsolete]
			public bool puedeOcultarLoadingPanel;
		}
	}
}
