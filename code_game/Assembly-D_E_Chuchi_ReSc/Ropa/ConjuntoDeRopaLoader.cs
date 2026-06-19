using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Clases;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Globales;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000E8 RID: 232
	[RequireComponent(typeof(PiezasDeRopaLoader))]
	public sealed class ConjuntoDeRopaLoader : AplicableBehaviour, IAnusBlocker, IVagBlocker, IBocaBlocker, IPenisBlocker, IRopaManager, IComponentStartable, IRopaLoaderFrameData
	{
		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06000596 RID: 1430 RVA: 0x0001A8D4 File Offset: 0x00018AD4
		// (remove) Token: 0x06000597 RID: 1431 RVA: 0x0001A90C File Offset: 0x00018B0C
		public event OnRopaManagerChangedHandler changed;

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x06000598 RID: 1432 RVA: 0x0001A944 File Offset: 0x00018B44
		// (remove) Token: 0x06000599 RID: 1433 RVA: 0x0001A97C File Offset: 0x00018B7C
		public event Action<IRopaManager> conjuntoLoaded;

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x0001A9B1 File Offset: 0x00018BB1
		public bool isLoadingConjunto
		{
			get
			{
				return this.m_isLoadingConjunto;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x0600059B RID: 1435 RVA: 0x0001A9B9 File Offset: 0x00018BB9
		public IRopaManager manager
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x0001A9BC File Offset: 0x00018BBC
		public override int updateEvent1Index
		{
			get
			{
				return 69;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600059D RID: 1437 RVA: 0x0001A9C0 File Offset: 0x00018BC0
		// (set) Token: 0x0600059E RID: 1438 RVA: 0x0001A9C8 File Offset: 0x00018BC8
		public string FlagPiezaID
		{
			get
			{
				return this.flagPiezaId;
			}
			set
			{
				this.flagPiezaId = value;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600059F RID: 1439 RVA: 0x0001A9D1 File Offset: 0x00018BD1
		[Obsolete("Se unificaron los mapas", true)]
		public RopaTipoDeSingleton ropaTipoDeSingleton
		{
			get
			{
				return this.m_piezasLoader.ropaTipoDeSingleton;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060005A0 RID: 1440 RVA: 0x0001A9DE File Offset: 0x00018BDE
		// (set) Token: 0x060005A1 RID: 1441 RVA: 0x0001A9EB File Offset: 0x00018BEB
		public IConjuntoDeRopa conjuntoToLoad
		{
			get
			{
				return this.m_conjuntosToLoad.FirstOrDefault<IConjuntoDeRopa>();
			}
			set
			{
				this.m_conjuntosToLoad.Add(value);
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060005A2 RID: 1442 RVA: 0x0001A9F9 File Offset: 0x00018BF9
		public IConjuntoDeRopa loadedConjunto
		{
			get
			{
				return this.m_current;
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060005A3 RID: 1443 RVA: 0x0001AA01 File Offset: 0x00018C01
		public Character character
		{
			get
			{
				if (this.m_character == null)
				{
					this.m_character = base.GetComponentInParent<Character>();
				}
				return this.m_character;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060005A4 RID: 1444 RVA: 0x0001AA23 File Offset: 0x00018C23
		public IReadOnlyList<PiezaDeRopaBase> piezasPuestas
		{
			get
			{
				return this.m_piezasLoader.piezasPuestas;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060005A5 RID: 1445 RVA: 0x0001AA30 File Offset: 0x00018C30
		public IReadOnlyDictionary<string, PiezaDeRopaBase> piezasPuestasPorId
		{
			get
			{
				return this.m_piezasLoader.piezasPuestasPorId;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060005A6 RID: 1446 RVA: 0x0001AA3D File Offset: 0x00018C3D
		public RopaCubre cubriendoFlags
		{
			get
			{
				return this.m_piezasLoader.cubriendoFlags;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060005A7 RID: 1447 RVA: 0x0001AA4A File Offset: 0x00018C4A
		public IReadOnlyList<SiendoDesvestidoFrameData> enRemoverFrame
		{
			get
			{
				return this.m_removidosEnFrame;
			}
		}

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x060005A8 RID: 1448 RVA: 0x0001AA54 File Offset: 0x00018C54
		// (remove) Token: 0x060005A9 RID: 1449 RVA: 0x0001AA8C File Offset: 0x00018C8C
		public event Action<ConjuntoDeRopaLoader> cleaningFrameData;

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060005AA RID: 1450 RVA: 0x0001AAC1 File Offset: 0x00018CC1
		public PiezasDeRopaLoader piezasLoader
		{
			get
			{
				return this.m_piezasLoader;
			}
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x0001AACC File Offset: 0x00018CCC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_piezasLoader = base.GetComponent<PiezasDeRopaLoader>();
			if (this.m_piezasLoader == null)
			{
				throw new ArgumentNullException("m_piezasLoader", "m_piezasLoader null reference.");
			}
			if (this.character == null)
			{
				throw new ArgumentNullException("character", "character null reference.");
			}
			base.SetYieldStart();
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x0001AB2D File Offset: 0x00018D2D
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_piezasLoader.changed += this.M_piezasLoader_changed;
			this.m_isLoaded = this.character.isLoadedAND.ObtenerModificadorNotNull(this);
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0001AB64 File Offset: 0x00018D64
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_piezasLoader != null)
			{
				this.m_piezasLoader.changed -= this.M_piezasLoader_changed;
			}
			ModificadorDeBool isLoaded = this.m_isLoaded;
			if (isLoaded != null)
			{
				isLoaded.TryRemoverDeOwner(true);
			}
			this.m_isLoaded = null;
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0001ABB7 File Offset: 0x00018DB7
		protected override IEnumerator YieldStartUnityEvent()
		{
			this.m_isLoaded.valor.valor = false;
			yield return AsyncSingleton<RopaParaAvatarUnificado>.TryIniciar();
			yield return AsyncSingleton<MaterialesParaRopa>.TryIniciar();
			yield return base.StartCoroutine(this.LoadConjunto(null, true));
			Singleton<ConfiguracionGeneralDeGamePlay>.instance.changed += this.Instance_changed;
			yield break;
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x0001ABC6 File Offset: 0x00018DC6
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (Singleton<ConfiguracionGeneralDeGamePlay>.IsInScene)
			{
				Singleton<ConfiguracionGeneralDeGamePlay>.instance.changed += this.Instance_changed;
			}
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x0001ABEC File Offset: 0x00018DEC
		private void Instance_changed(ConfiguracionGeneralDeGamePlay obj)
		{
			IConjuntoDeRopa conjuntoToLoad = this.conjuntoToLoad;
			if (conjuntoToLoad == null || conjuntoToLoad.piezas.Count == 0)
			{
				return;
			}
			List<Material> list = new List<Material>();
			foreach (Pieza pieza in conjuntoToLoad.piezas)
			{
				PiezaDeRopaBase piezaDeRopaBase = this.m_piezasLoader.ObtenerPieza(pieza.ropaIDString);
				if (!(piezaDeRopaBase == null))
				{
					try
					{
						piezaDeRopaBase.skinnedMeshRenderer.GetSharedMaterials(list);
						foreach (SlotDeMaterialDeRopa slotDeMaterialDeRopa in pieza.materiales)
						{
							MaterialParaRopaData materialParaRopaData = AsyncSingleton<MaterialesParaRopa>.instance.ObtenerData(slotDeMaterialDeRopa.materialIDString);
							if (materialParaRopaData != null && materialParaRopaData.puedeTenerCustomColor && list.ContieneIndex(slotDeMaterialDeRopa.materialSlot))
							{
								Material material = list[slotDeMaterialDeRopa.materialSlot];
								Color color = material.GetColor(PiezasDeRopaLoader._BaseColorID);
								switch (piezaDeRopaBase.dataDeRopa.layer)
								{
								case RopaLayer.debajoDeRopaInterior:
								case RopaLayer.ropaInterior:
									color = Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.underwearHueConstraint.Apply(color);
									break;
								case RopaLayer.debajoDeRopa:
								case RopaLayer.ropa:
								case RopaLayer.debajoDeAccesorios:
								case RopaLayer.debajoDeAbrigo:
								case RopaLayer.abrigo:
									color = Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.clothingHueConstraint.Apply(color);
									break;
								case RopaLayer.accesorios:
									break;
								default:
									throw new ArgumentOutOfRangeException(piezaDeRopaBase.dataDeRopa.layer.ToString());
								}
								material.SetColor(PiezasDeRopaLoader._BaseColorID, color);
							}
						}
					}
					finally
					{
						list.Clear();
					}
				}
			}
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x0001ADEC File Offset: 0x00018FEC
		public override void OnUpdateEvent1()
		{
			Action<ConjuntoDeRopaLoader> action = this.cleaningFrameData;
			if (action != null)
			{
				action(this);
			}
			this.m_removidosEnFrame.Clear();
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x0001AE0C File Offset: 0x0001900C
		public T GenerarConjuntoDePiezasConEstadoActual<T>() where T : IConjuntoDeRopaMutable, new()
		{
			T t = new T();
			if (t.piezas == null)
			{
				t.piezas = new List<Pieza>();
			}
			PiezasDeRopaLoader piezasLoader = this.m_piezasLoader;
			if (((piezasLoader != null) ? piezasLoader.piezasPuestas : null) == null)
			{
				return t;
			}
			foreach (PiezaDeRopaBase piezaDeRopaBase in this.m_piezasLoader.piezasPuestas)
			{
				string text;
				if (piezaDeRopaBase == null)
				{
					text = null;
				}
				else
				{
					MapaDeRopa.RopaData dataDeRopa = piezaDeRopaBase.dataDeRopa;
					text = ((dataDeRopa != null) ? dataDeRopa.stringId : null);
				}
				if (!string.IsNullOrWhiteSpace(text))
				{
					string stringId = piezaDeRopaBase.dataDeRopa.stringId;
					if (this.m_piezasLoader.Usando(stringId, true))
					{
						Pieza pieza = new Pieza();
						pieza.ropaIDString = stringId;
						pieza.materiales = piezaDeRopaBase.materialesData.Select((SlotDeMaterialDeRopa d) => d.Clone()).ToList<SlotDeMaterialDeRopa>();
						t.piezas.Add(pieza);
					}
				}
			}
			return t;
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0001AF30 File Offset: 0x00019130
		public void ObtenerPiezasIDs(ICollection<string> resultado, bool ignorarOcultas)
		{
			this.m_piezasLoader.ObtenerPiezasIDs(resultado, ignorarOcultas);
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0001AF3F File Offset: 0x0001913F
		public bool Usando(string PiezaID, bool ignorarOcultas)
		{
			return this.m_piezasLoader.Usando(PiezaID, ignorarOcultas);
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x0001AF4E File Offset: 0x0001914E
		public int CantidadPiezasCubriendo(RopaCubre flags, bool ignorarOcultas, IList<string> IDsResultado = null)
		{
			return this.m_piezasLoader.CantidadPiezasCubriendo(flags, ignorarOcultas, IDsResultado);
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0001AF5E File Offset: 0x0001915E
		public int CantidadPiezas(RopaLayer layer, bool ignorarOcultas, IList<string> IDsResultado = null)
		{
			return this.m_piezasLoader.CantidadPiezas(layer, ignorarOcultas, IDsResultado);
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x0001AF6E File Offset: 0x0001916E
		public int CantidadPiezas(RopaPosicion posicion, bool ignorarOcultas, IList<string> IDsResultado = null)
		{
			return this.m_piezasLoader.CantidadPiezas(posicion, ignorarOcultas, IDsResultado);
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x0001AF7E File Offset: 0x0001917E
		public RopaCubre CurrentPiezaCubreFlags(string ignorandoPiezaID, bool ignorarOcultas)
		{
			return this.m_piezasLoader.CurrentCubriendoFlagsIgnorandoOMenorPrioridad(ignorandoPiezaID, ignorarOcultas);
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x0001AF8D File Offset: 0x0001918D
		public RopaCubre PiezaCubreFlags(string piezaID, bool ignorarSiEstaOculta)
		{
			return this.m_piezasLoader.PiezaCubreFlags(piezaID, ignorarSiEstaOculta);
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x0001AF9C File Offset: 0x0001919C
		[Obsolete("", true)]
		public IRopaParaAvatar ObtenerMapa()
		{
			return this.m_piezasLoader.ObtenerMapa();
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x0001AFA9 File Offset: 0x000191A9
		public IEnumerator UpdateMaterialAsync(string pendaID, string newMaterialID, int materialSlot, Color color, Action<bool> output)
		{
			return this.m_piezasLoader.UpdateMaterialRutine(pendaID, newMaterialID, materialSlot, color, output);
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0001AFBD File Offset: 0x000191BD
		public IEnumerator AddPiezaAsync<T_PiezaDeRopaAbstract>(Pieza piezaPrefab, Action<T_PiezaDeRopaAbstract> output, bool showLoadingScreen) where T_PiezaDeRopaAbstract : PiezaDeRopaBase
		{
			return this.m_piezasLoader.AddPiezaAsync<T_PiezaDeRopaAbstract>(piezaPrefab, output, showLoadingScreen);
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0001AFCD File Offset: 0x000191CD
		public IEnumerator AddPiezaAsync<T_PiezaDeRopaAbstract>(string ropaId, IReadOnlyList<SlotDeMaterialDeRopa> materiales, Action<T_PiezaDeRopaAbstract> output, bool showLoadingScreen) where T_PiezaDeRopaAbstract : PiezaDeRopaBase
		{
			return this.m_piezasLoader.AddPiezaAsync<T_PiezaDeRopaAbstract>(ropaId, materiales, output, showLoadingScreen);
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0001AFDF File Offset: 0x000191DF
		private IEnumerator AddPieza<T_PiezaDeRopaAbstract, T_PiezaDeRopa>(Action<T_PiezaDeRopaAbstract> output) where T_PiezaDeRopaAbstract : PiezaDeRopaBase
		{
			try
			{
				if (string.IsNullOrWhiteSpace(this.flagPiezaId))
				{
					Debug.LogWarning("no se puede añadir pieza de ropa con id zero");
					output(default(T_PiezaDeRopaAbstract));
				}
				yield return this.m_piezasLoader.AddPiezaAsync<T_PiezaDeRopaAbstract>(this.flagPiezaId, null, output, true);
			}
			finally
			{
				this.flagPiezaId = string.Empty;
			}
			yield break;
			yield break;
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0001AFF5 File Offset: 0x000191F5
		public bool RemovePieza(string ropaId, bool destroy, Object by)
		{
			this.flagPiezaId = ropaId;
			return this.RemovePieza(destroy, by);
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0001B006 File Offset: 0x00019206
		public bool OcultarPieza(string ropaId, bool ocultar, Object by)
		{
			this.flagPiezaId = ropaId;
			return this.OcultarPieza(ocultar, by);
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0001B018 File Offset: 0x00019218
		public bool OcultarPiezasCubriendo(RopaCubre flags, bool ocultar, Object by = null)
		{
			bool flag = false;
			for (int i = 0; i < this.piezasPuestas.Count; i++)
			{
				PiezaDeRopaBase piezaDeRopaBase = this.piezasPuestas[i];
				if (((int)piezaDeRopaBase.cubreFlags).IsAnyFlagSet((int)flags))
				{
					this.flagPiezaId = piezaDeRopaBase.dataDeRopa.stringId;
					if (this.OcultarPieza(ocultar, by))
					{
						flag = true;
					}
				}
			}
			return flag;
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x0001B078 File Offset: 0x00019278
		public bool OcultarPieza(bool ocultar, Object by)
		{
			bool flag;
			try
			{
				if (string.IsNullOrWhiteSpace(this.flagPiezaId))
				{
					flag = false;
				}
				else
				{
					PiezaDeRopaBase piezaDeRopaBase;
					bool flag2 = this.m_piezasLoader.OcultarPieza(this.flagPiezaId, ocultar, out piezaDeRopaBase);
					Character character;
					if (flag2 && ocultar && by != null && SiendoDesvestidoFrameData.TryObtenerCharacter(by, out character))
					{
						this.m_removidosEnFrame.Add(new SiendoDesvestidoFrameData(character, this.flagPiezaId, this.character, piezaDeRopaBase, false, true));
					}
					flag = flag2;
				}
			}
			finally
			{
				this.flagPiezaId = string.Empty;
			}
			return flag;
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x0001B104 File Offset: 0x00019304
		private bool RemovePieza(bool destroy, Object by)
		{
			bool flag;
			try
			{
				PiezaDeRopaBase piezaDeRopaBase;
				if (string.IsNullOrWhiteSpace(this.flagPiezaId))
				{
					flag = false;
				}
				else if (this.m_piezasLoader.RemovePieza(this.flagPiezaId, destroy, out piezaDeRopaBase))
				{
					Character character;
					if (by != null && SiendoDesvestidoFrameData.TryObtenerCharacter(by, out character))
					{
						this.m_removidosEnFrame.Add(new SiendoDesvestidoFrameData(character, this.flagPiezaId, this.character, piezaDeRopaBase, false, true));
					}
					flag = true;
				}
				else
				{
					flag = false;
				}
			}
			finally
			{
				this.flagPiezaId = string.Empty;
			}
			return flag;
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0001B190 File Offset: 0x00019390
		public void InyectData(ref SiendoDesvestidoFrameData data)
		{
			this.m_removidosEnFrame.Add(data);
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x0001B1A3 File Offset: 0x000193A3
		public PiezaDeRopaBase ObtenerPieza(string id)
		{
			return this.m_piezasLoader.ObtenerPieza(id);
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x0001B1B1 File Offset: 0x000193B1
		public IEnumerator LoadConjunto(Action onEnd = null, bool showLoadingScreen = true)
		{
			onEnd = (Action)Delegate.Remove(onEnd, new Action(this.OnLoadConjuntoEnd));
			onEnd = (Action)Delegate.Combine(onEnd, new Action(this.OnLoadConjuntoEnd));
			if (this.m_isLoadingConjunto)
			{
				yield return new WaitUntil(() => !this.m_isLoadingConjunto);
			}
			IConjuntoDeRopa conjuntoToLoad = this.conjuntoToLoad;
			if (this.m_conjuntosToLoad.Count > 0)
			{
				this.m_conjuntosToLoad.RemoveAt(0);
			}
			if (conjuntoToLoad == this.m_current)
			{
				Action action = onEnd;
				if (action != null)
				{
					action();
				}
				this.m_isLoaded.valor.valor = true;
				yield break;
			}
			if (conjuntoToLoad == null)
			{
				this.RemoverConjunto(null);
				Action action2 = onEnd;
				if (action2 != null)
				{
					action2();
				}
				this.m_isLoaded.valor.valor = true;
				yield break;
			}
			this.m_isLoaded.valor.valor = false;
			this.m_isLoadingConjunto = true;
			if (this.m_current != null)
			{
				this.RemoverConjunto(null);
			}
			List<string> aInstanciar = new List<string>(conjuntoToLoad.piezas.Count);
			Queue<ManualCorrutina> aEsperar = new Queue<ManualCorrutina>(conjuntoToLoad.piezas.Count);
			HashSet<string> aInstanciadas = new HashSet<string>();
			using (IEnumerator<Pieza> enumerator = conjuntoToLoad.piezas.GetEnumerator())
			{
				Action<PiezaDeRopaBase> <>9__1;
				while (enumerator.MoveNext())
				{
					Pieza pieza = enumerator.Current;
					aInstanciar.Add(pieza.ropaIDString);
					GlobalUpdater instancia = GlobalUpdater.instancia;
					GlobalUpdater.UpdateType updateType = GlobalUpdater.UpdateType.onAI4;
					PiezasDeRopaLoader piezasLoader = this.m_piezasLoader;
					Pieza pieza2 = pieza;
					Action<PiezaDeRopaBase> action3;
					if ((action3 = <>9__1) == null)
					{
						action3 = (<>9__1 = delegate(PiezaDeRopaBase r)
						{
							if (r)
							{
								aInstanciadas.Add(r.dataDeRopa.stringId);
							}
						});
					}
					GlobalUpdater.Corrutina corrutina = instancia.StartCorrutinaOnEvent(updateType, this, piezasLoader.AddPiezaAsync<PiezaDeRopaBase>(pieza2, action3, showLoadingScreen), null);
					aEsperar.Enqueue(corrutina);
				}
				goto IL_028D;
			}
			IL_0253:
			ManualCorrutina manualCorrutina = aEsperar.Dequeue();
			if (!manualCorrutina.finalizada)
			{
				aEsperar.Enqueue(manualCorrutina);
				yield return null;
			}
			IL_028D:
			if (aEsperar.Count <= 0)
			{
				if (aInstanciadas.Count != aInstanciar.Count)
				{
					for (int i = 0; i < aInstanciar.Count; i++)
					{
						string text = aInstanciar[i];
						if (!aInstanciadas.Contains(text))
						{
							Debug.LogError("Pieza con id: " + text + ". NO se instancio", this);
						}
					}
				}
				this.m_current = conjuntoToLoad;
				if (this.m_isLoaded != null)
				{
					this.m_isLoaded.valor.valor = true;
				}
				this.m_isLoadingConjunto = false;
				Action action4 = onEnd;
				if (action4 != null)
				{
					action4();
				}
				yield break;
			}
			goto IL_0253;
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0001B1CE File Offset: 0x000193CE
		public IEnumerator LoadConjuntoAsset(IConjuntoDeRopa conjuntoAsset, bool removerExistentes, Action onEnd = null, bool showLoadingScreen = true)
		{
			onEnd = (Action)Delegate.Remove(onEnd, new Action(this.OnLoadConjuntoEnd));
			onEnd = (Action)Delegate.Combine(onEnd, new Action(this.OnLoadConjuntoEnd));
			while (!base.isStared)
			{
				yield return null;
			}
			this.conjuntoToLoad = conjuntoAsset;
			List<Pieza> copiaDePiezas = conjuntoAsset.piezas.Select((Pieza p) => p.Clone()).ToList<Pieza>();
			if (this.m_isLoadingConjunto || this.conjuntoToLoad != conjuntoAsset)
			{
				yield return new WaitUntil(() => !this.m_isLoadingConjunto);
			}
			if (base.isDestroyed)
			{
				yield break;
			}
			this.RemoverConjunto(null);
			if (removerExistentes)
			{
				this.piezasLoader.RemoverTodo();
			}
			this.GetComponentInChildrenNotNull<MapaLocalConjuntoDeRopa>().piezas = copiaDePiezas;
			yield return this.LoadConjunto(onEnd, showLoadingScreen);
			yield break;
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0001B1FA File Offset: 0x000193FA
		private void OnLoadConjuntoEnd()
		{
			Action<IRopaManager> action = this.conjuntoLoaded;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x0001B20D File Offset: 0x0001940D
		private void M_piezasLoader_changed(RopaCubre last, RopaCubre @new, PiezasDeRopaLoader sender)
		{
			OnRopaManagerChangedHandler onRopaManagerChangedHandler = this.changed;
			if (onRopaManagerChangedHandler == null)
			{
				return;
			}
			onRopaManagerChangedHandler(last, @new, this);
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0001B224 File Offset: 0x00019424
		public void RemoverConjunto(Object by)
		{
			if (this.m_current == null || this.m_current.piezas == null)
			{
				this.m_current = null;
				return;
			}
			foreach (Pieza pieza in this.m_current.piezas)
			{
				try
				{
					this.flagPiezaId = pieza.ropaIDString;
					this.RemovePieza(true, by);
				}
				catch (Exception ex)
				{
					Debug.LogException(ex, this);
				}
			}
			this.m_current = null;
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0001B2C0 File Offset: 0x000194C0
		public void RemoverTodo()
		{
			this.piezasLoader.RemoverTodo();
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0001B2CD File Offset: 0x000194CD
		public void ToggleTodo(bool ocultar)
		{
			this.piezasLoader.ToggleTodo(ocultar);
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x0001B2DB File Offset: 0x000194DB
		bool IAnusBlocker.blocked
		{
			get
			{
				return ((int)this.m_piezasLoader.cubriendoFlags).HasFlag(32);
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060005CE RID: 1486 RVA: 0x0001B2EF File Offset: 0x000194EF
		bool IVagBlocker.blocked
		{
			get
			{
				return ((int)this.m_piezasLoader.cubriendoFlags).HasFlag(8);
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060005CF RID: 1487 RVA: 0x0001B302 File Offset: 0x00019502
		bool IBocaBlocker.blocked
		{
			get
			{
				return ((int)this.m_piezasLoader.cubriendoFlags).HasFlag(1024);
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060005D0 RID: 1488 RVA: 0x0001B319 File Offset: 0x00019519
		bool IPenisBlocker.blocked
		{
			get
			{
				return ((int)this.m_piezasLoader.cubriendoFlags).HasFlag(2048);
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060005D1 RID: 1489 RVA: 0x0001B330 File Offset: 0x00019530
		public sealed override string aplicarButtonString
		{
			get
			{
				return "Cargar Conjunto";
			}
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0001B338 File Offset: 0x00019538
		protected sealed override void OnAplicar()
		{
			base.OnAplicar();
			if (!string.IsNullOrWhiteSpace(this.flagPiezaId) && AsyncSingleton<ConjuntosDeRopa>.IsInScene)
			{
				MapaConjuntoDeRopa conjunto = AsyncSingleton<ConjuntosDeRopa>.instance.GetConjunto(this.flagPiezaId);
				if (conjunto != null)
				{
					this.conjuntoToLoad = conjunto;
				}
			}
			base.StartCoroutine(this.LoadConjunto(null, true));
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x0001B38F File Offset: 0x0001958F
		protected sealed override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				editorTimeVisible = false,
				text = "Remover Conjunto"
			};
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x0001B3AF File Offset: 0x000195AF
		protected sealed override void OnAplicar2()
		{
			base.OnAplicar2();
			this.RemoverConjunto(null);
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0001B3BE File Offset: 0x000195BE
		protected sealed override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				editorTimeVisible = false,
				text = "Add Pieza en flag"
			};
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0001B3E0 File Offset: 0x000195E0
		protected sealed override void OnAplicar3()
		{
			base.OnAplicar3();
			PiezaDeRopaBase r = null;
			this.AddPieza<PiezaDeRopaBase, PiezaDeRopa>(delegate(PiezaDeRopaBase p)
			{
				r = p;
			});
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0001B413 File Offset: 0x00019613
		protected sealed override CustomMonobehaviourBotonConfig Boton4()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				editorTimeVisible = false,
				text = "Remove Pieza en flag"
			};
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0001B433 File Offset: 0x00019633
		protected sealed override void OnAplicar4()
		{
			base.OnAplicar4();
			this.RemovePieza(true, MainChar.current);
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0001B448 File Offset: 0x00019648
		protected sealed override CustomMonobehaviourBotonConfig Boton5()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				editorTimeVisible = false,
				text = "Mostrar Pieza en flag"
			};
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0001B468 File Offset: 0x00019668
		protected sealed override void OnAplicar5()
		{
			base.OnAplicar5();
			this.OcultarPieza(false, MainChar.current);
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0001B47D File Offset: 0x0001967D
		protected sealed override CustomMonobehaviourBotonConfig Boton6()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				editorTimeVisible = false,
				text = "Ocultar Pieza en flag"
			};
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0001B49D File Offset: 0x0001969D
		protected sealed override void OnAplicar6()
		{
			base.OnAplicar6();
			this.OcultarPieza(true, MainChar.current);
		}

		// Token: 0x040003C3 RID: 963
		[ReadOnlyUI]
		[SerializeField]
		private bool m_isLoadingConjunto;

		// Token: 0x040003C4 RID: 964
		[SerializeReference]
		private List<IConjuntoDeRopa> m_conjuntosToLoad;

		// Token: 0x040003C5 RID: 965
		[NonSerialized]
		private IConjuntoDeRopa m_current;

		// Token: 0x040003C6 RID: 966
		[SerializeReference]
		private ModificadorDeBool m_isLoaded;

		// Token: 0x040003C7 RID: 967
		private Character m_character;

		// Token: 0x040003C8 RID: 968
		[Header("pieza id o conjunto id")]
		public string flagPiezaId;

		// Token: 0x040003C9 RID: 969
		[ReadOnlyUI]
		[SerializeField]
		private List<SiendoDesvestidoFrameData> m_removidosEnFrame = new List<SiendoDesvestidoFrameData>();

		// Token: 0x040003CB RID: 971
		private PiezasDeRopaLoader m_piezasLoader;
	}
}
