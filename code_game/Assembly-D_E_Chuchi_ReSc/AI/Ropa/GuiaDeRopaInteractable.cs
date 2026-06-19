using System;
using System.Collections;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes;
using Assets._ReusableScripts.CuchiCuchi.Interactables;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Ropa
{
	// Token: 0x02000382 RID: 898
	public sealed class GuiaDeRopaInteractable : GuiaVisualInteractable
	{
		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06001385 RID: 4997 RVA: 0x00055460 File Offset: 0x00053660
		protected override float recorridoWeigthToInteract
		{
			get
			{
				return 0.95f;
			}
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06001386 RID: 4998 RVA: 0x00055460 File Offset: 0x00053660
		protected override float agarradoWeigthToInteract
		{
			get
			{
				return 0.95f;
			}
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06001387 RID: 4999 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool agarrarObjetoPhysicoToInteract
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06001388 RID: 5000 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool interactuarDespuesDeSoltar
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06001389 RID: 5001 RVA: 0x00055467 File Offset: 0x00053667
		public override bool interactable
		{
			get
			{
				return this.m_interactableCon != null;
			}
		}

		// Token: 0x1400005B RID: 91
		// (add) Token: 0x0600138A RID: 5002 RVA: 0x00055478 File Offset: 0x00053678
		// (remove) Token: 0x0600138B RID: 5003 RVA: 0x000554B0 File Offset: 0x000536B0
		public event GuiaDeRopaInteractable.OnPiezaChangingWaitForHandler piezaChangingWaitFor;

		// Token: 0x1400005C RID: 92
		// (add) Token: 0x0600138C RID: 5004 RVA: 0x000554E8 File Offset: 0x000536E8
		// (remove) Token: 0x0600138D RID: 5005 RVA: 0x00055520 File Offset: 0x00053720
		public event GuiaDeRopaInteractable.OnPiezaChangingHandler piezaChanging;

		// Token: 0x1400005D RID: 93
		// (add) Token: 0x0600138E RID: 5006 RVA: 0x00055558 File Offset: 0x00053758
		// (remove) Token: 0x0600138F RID: 5007 RVA: 0x00055590 File Offset: 0x00053790
		public event GuiaDeRopaInteractable.OnPiezaChangedHandler piezaChanged;

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06001390 RID: 5008 RVA: 0x000555C5 File Offset: 0x000537C5
		public MapaDeRopa.Interaciones interaccion
		{
			get
			{
				return this.m_interaccion;
			}
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06001391 RID: 5009 RVA: 0x000555CD File Offset: 0x000537CD
		public PiezaDeRopaBase interactableCon
		{
			get
			{
				return this.m_interactableCon;
			}
		}

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06001392 RID: 5010 RVA: 0x000555D5 File Offset: 0x000537D5
		public MapaDeRopa.RopaData.Interacciones currentInteraccion
		{
			get
			{
				return this.m_currentInteraccion;
			}
		}

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06001393 RID: 5011 RVA: 0x000555DD File Offset: 0x000537DD
		public IReadOnlyList<RopaCubre> currentInteraccionExponiendo
		{
			get
			{
				return this.m_currentInteraccionExponiendo;
			}
		}

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06001394 RID: 5012 RVA: 0x000555E5 File Offset: 0x000537E5
		public RopaCubre currentInteraccionExponiendoFlags
		{
			get
			{
				return this.m_currentInteraccionExponiendoFlags;
			}
		}

		// Token: 0x06001395 RID: 5013 RVA: 0x000555ED File Offset: 0x000537ED
		public void Init(MapaDeRopa.Interaciones Interaccion, Renderer guiaVisualPrefab, GuiaVisualInteractable.Config Config, ModificadorDeBool drawGuiaVisualOnTop, params Transform[] ExtraPuntos)
		{
			if (Interaccion == MapaDeRopa.Interaciones.None)
			{
				throw new InvalidOperationException();
			}
			this.m_interaccion = Interaccion;
			base.Init(guiaVisualPrefab, Config, drawGuiaVisualOnTop, Vector3.zero, ExtraPuntos);
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x00055610 File Offset: 0x00053810
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_IRopaManager = this.GetComponentEnRoot(false);
			if (this.m_IRopaManager == null)
			{
				throw new ArgumentNullException("m_IRopaManager", "m_IRopaManager null reference.");
			}
			this.m_PiezasDeRopaLoader = this.GetComponentEnRoot(false);
			if (this.m_PiezasDeRopaLoader == null)
			{
				throw new ArgumentNullException("m_PiezasDeRopaLoader", "m_PiezasDeRopaLoader null reference.");
			}
			this.Subscribe();
		}

		// Token: 0x06001397 RID: 5015 RVA: 0x00055679 File Offset: 0x00053879
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared)
			{
				this.Subscribe();
			}
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x0005568F File Offset: 0x0005388F
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_PiezasDeRopaLoader != null)
			{
				this.m_PiezasDeRopaLoader.changed -= this.M_PiezasDeRopaLoader_changed;
			}
		}

		// Token: 0x06001399 RID: 5017 RVA: 0x000556BD File Offset: 0x000538BD
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x0600139A RID: 5018 RVA: 0x000556C6 File Offset: 0x000538C6
		private void Subscribe()
		{
			this.m_PiezasDeRopaLoader.changed += this.M_PiezasDeRopaLoader_changed;
		}

		// Token: 0x0600139B RID: 5019 RVA: 0x000556DF File Offset: 0x000538DF
		protected override void ClearAgarrando()
		{
			base.ClearAgarrando();
			this.m_flagNoActualizarAnimacion = false;
		}

		// Token: 0x0600139C RID: 5020 RVA: 0x000556F0 File Offset: 0x000538F0
		private void M_PiezasDeRopaLoader_changed(RopaCubre last, RopaCubre @new, PiezasDeRopaLoader sender)
		{
			if (base.applicationQuit)
			{
				return;
			}
			this.ClearCurrentInterracion();
			base.UpdateTrigger();
			for (int i = 0; i < sender.piezasPuestas.Count; i++)
			{
				PiezaDeRopaBase piezaDeRopaBase = sender.piezasPuestas[i];
				if (piezaDeRopaBase.isActiveAndEnabled)
				{
					for (int j = 0; j < piezaDeRopaBase.dataDeRopa.interacciones.Count; j++)
					{
						MapaDeRopa.RopaData.Interacciones interacciones = piezaDeRopaBase.dataDeRopa.interacciones[j];
						if (GuiaDeRopaInteractable.InteraccionDePiezaEsValidaParaGuia(this.m_IRopaManager, sender, piezaDeRopaBase, this, interacciones, this.m_currentInteraccionExponiendo))
						{
							this.m_currentInteraccionExponiendoFlags = this.m_currentInteraccionExponiendo.ListToFlags();
							this.m_interactableCon = piezaDeRopaBase;
							this.m_currentInteraccion = interacciones;
							this.m_currentInteraccionShape = new ShapeKey(interacciones.shapeName);
							this.m_currentInteraccionShapeFix = new List<ValueTuple<ShapeKey, AnimationCurve>>(this.m_currentInteraccion.fixes.Count);
							for (int k = 0; k < this.m_currentInteraccion.fixes.Count; k++)
							{
								MapaDeRopa.RopaData.Interacciones.FixShapes fixShapes = this.m_currentInteraccion.fixes[k];
								if (string.IsNullOrWhiteSpace(fixShapes.shapeName))
								{
									Debug.LogError("fix de shape no tiene un nombre valido", this);
								}
								else
								{
									this.m_currentInteraccionShapeFix.Add(new ValueTuple<ShapeKey, AnimationCurve>(new ShapeKey(fixShapes.shapeName), fixShapes.inOut1x1Curve));
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600139D RID: 5021 RVA: 0x00055850 File Offset: 0x00053A50
		private void ClearCurrentInterracion()
		{
			if (this.m_interactableCon != null)
			{
				if (this.m_currentInteraccionShape != null)
				{
					this.m_currentInteraccionShape.TrySetValor(this.m_interactableCon.skinnedMeshRenderer, 0f);
				}
				for (int i = 0; i < this.m_currentInteraccionShapeFix.Count; i++)
				{
					this.m_currentInteraccionShapeFix[i].Item1.TrySetValor(this.m_interactableCon.skinnedMeshRenderer, 0f);
				}
			}
			this.m_interactableCon = null;
			this.m_currentInteraccion = null;
			this.m_currentInteraccionShape = null;
			this.m_currentInteraccionShapeFix = null;
			this.m_currentInteraccionExponiendo.Clear();
			this.m_currentInteraccionExponiendoFlags = RopaCubre.None;
		}

		// Token: 0x0600139E RID: 5022 RVA: 0x000558FA File Offset: 0x00053AFA
		private static bool InteraccionDePiezaEsValidaParaGuia(IRopaManager ropaManager, PiezasDeRopaLoader loader, PiezaDeRopaBase pieza, GuiaDeRopaInteractable guia, MapaDeRopa.RopaData.Interacciones interaccion, IList<RopaCubre> cambioDesvestidasResultado)
		{
			if (guia.m_interaccion != interaccion.id)
			{
				return false;
			}
			GuiaDeRopaInteractable.LoadExposingPartesDeInteraccion(ropaManager, pieza, interaccion.subPrendaIDString, cambioDesvestidasResultado);
			return GuiaDeRopaInteractable.EsInteractable(ropaManager, loader, interaccion.subPrendaIDString, cambioDesvestidasResultado);
		}

		// Token: 0x0600139F RID: 5023 RVA: 0x00055930 File Offset: 0x00053B30
		private static void LoadExposingPartesDeInteraccion(IRopaManager ropaManager, PiezaDeRopaBase @base, string subPrendaID, IList<RopaCubre> cambioDesvestidasResultado)
		{
			RopaParaAvatarUnificado instance = AsyncSingleton<RopaParaAvatarUnificado>.instance;
			MapaDeRopa.RopaData ropaData = ((instance != null) ? instance.ObtenerData(subPrendaID) : null);
			if (ropaData == null)
			{
				throw new ArgumentNullException("subData", "No Se Encontro Sub data para prenda de id " + subPrendaID);
			}
			RopaCubre cubreFlag = ropaData.cubreFlag;
			RopaCubre cubreFlag2 = @base.dataDeRopa.cubreFlag;
			IReadOnlyList<int> enumValoresInt = typeof(RopaCubre).GetEnumValoresInt();
			for (int i = 0; i < enumValoresInt.Count; i++)
			{
				int num = enumValoresInt[i];
				if (num != 0 && ((int)cubreFlag2).HasFlag(num) && !((int)cubreFlag).HasFlag(num))
				{
					cambioDesvestidasResultado.Add((RopaCubre)num);
				}
			}
		}

		// Token: 0x060013A0 RID: 5024 RVA: 0x000559C4 File Offset: 0x00053BC4
		private static bool EsInteractable(IRopaManager ropaManager, PiezasDeRopaLoader loader, string subPrendaID, IList<RopaCubre> cambioDesvestidasResultado)
		{
			if (cambioDesvestidasResultado.Count == 0)
			{
				throw new NotSupportedException("para esto toca ver las partes que cubre la pieza subPrenda y ver si hay otra pieza de ropa de mayor layer tapando esas partes");
			}
			RopaLayer layer = AsyncSingleton<RopaParaAvatarUnificado>.instance.ObtenerData(subPrendaID).layer;
			for (int i = 0; i < loader.piezasPuestas.Count; i++)
			{
				PiezaDeRopaBase piezaDeRopaBase = loader.piezasPuestas[i];
				if (piezaDeRopaBase.isActiveAndEnabled)
				{
					RopaCubre cubreFlag = piezaDeRopaBase.dataDeRopa.cubreFlag;
					for (int j = 0; j < cambioDesvestidasResultado.Count; j++)
					{
						if (((int)cubreFlag).HasFlag((int)cambioDesvestidasResultado[j]) && piezaDeRopaBase.dataDeRopa.layer > layer)
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x060013A1 RID: 5025 RVA: 0x00055A62 File Offset: 0x00053C62
		protected override IEnumerator EfectuarInteraccion(AgarranteObjeto agarrante)
		{
			MapaDeRopa.RopaData.Interacciones Inter = this.m_currentInteraccion;
			PiezaDeRopaBase currentPieza = this.m_interactableCon;
			this.ClearAgarrando();
			if (currentPieza != null)
			{
				if (Inter != null && currentPieza.materialesData != null)
				{
					this.m_flagNoActualizarAnimacion = true;
					ModificableDeBool Or = new ModificableDeBool(false);
					GuiaDeRopaInteractable.OnPiezaChangingWaitForHandler onPiezaChangingWaitForHandler = this.piezaChangingWaitFor;
					if (onPiezaChangingWaitForHandler != null)
					{
						onPiezaChangingWaitForHandler(currentPieza, Or, this);
					}
					while (Or.Or(false))
					{
						yield return null;
					}
					yield return this.m_PiezasDeRopaLoader.AddPiezaAsync<PiezaDeRopaBase>(Inter.subPrendaIDString, currentPieza.materialesData, delegate(PiezaDeRopaBase subPieza)
					{
						try
						{
							GuiaDeRopaInteractable.OnPiezaChangingHandler onPiezaChangingHandler = this.piezaChanging;
							if (onPiezaChangingHandler != null)
							{
								onPiezaChangingHandler(currentPieza, subPieza, this);
							}
						}
						catch (Exception)
						{
							throw;
						}
						this.m_flagNoActualizarAnimacion = false;
						PiezaDeRopaBase piezaDeRopaBase;
						this.m_PiezasDeRopaLoader.RemovePieza(currentPieza.dataDeRopa.stringId, true, out piezaDeRopaBase);
					}, false);
					Or = null;
				}
				this.OnCambioDePieza(agarrante, Inter, currentPieza);
			}
			yield break;
		}

		// Token: 0x060013A2 RID: 5026 RVA: 0x00055A78 File Offset: 0x00053C78
		private void OnCambioDePieza(AgarranteObjeto agarradoPor, MapaDeRopa.RopaData.Interacciones interaccion, PiezaDeRopaBase siendoRemovida)
		{
			GuiaDeRopaInteractable.OnPiezaChangedHandler onPiezaChangedHandler = this.piezaChanged;
			if (onPiezaChangedHandler == null)
			{
				return;
			}
			onPiezaChangedHandler(agarradoPor, interaccion, siendoRemovida, this);
		}

		// Token: 0x060013A3 RID: 5027 RVA: 0x00055A90 File Offset: 0x00053C90
		public override void UpdateInteraction()
		{
			if (this.m_flagNoActualizarAnimacion)
			{
				return;
			}
			if (base.siendoAgarrada && this.m_interactableCon != null)
			{
				if (this.m_currentInteraccionShape != null && !this.m_currentInteraccionShape.TrySetValor(this.m_interactableCon.skinnedMeshRenderer, base.currentRecorridoWeigth * 100f))
				{
					Debug.LogError("Shape de nombre: " + this.m_currentInteraccionShape.nombre + " no esta en skin: " + this.m_interactableCon.skinnedMeshRenderer.name, this.m_interactableCon.skinnedMeshRenderer);
				}
				for (int i = 0; i < this.m_currentInteraccionShapeFix.Count; i++)
				{
					ValueTuple<ShapeKey, AnimationCurve> valueTuple = this.m_currentInteraccionShapeFix[i];
					float num = valueTuple.Item2.Evaluate(base.currentRecorridoWeigth);
					if (!valueTuple.Item1.TrySetValor(this.m_interactableCon.skinnedMeshRenderer, num * 100f))
					{
						Debug.LogError("Shape de nombre: " + valueTuple.Item1.nombre + " no esta en skin: " + this.m_interactableCon.skinnedMeshRenderer.name, this.m_interactableCon.skinnedMeshRenderer);
					}
				}
			}
		}

		// Token: 0x0400105C RID: 4188
		[ReadOnlyUI]
		[SerializeField]
		private MapaDeRopa.Interaciones m_interaccion;

		// Token: 0x0400105D RID: 4189
		[ReadOnlyUI]
		[SerializeField]
		[SerializeReference]
		private MapaDeRopa.RopaData.Interacciones m_currentInteraccion;

		// Token: 0x0400105E RID: 4190
		[ReadOnlyUI]
		[SerializeField]
		[SerializeReference]
		private ShapeKey m_currentInteraccionShape;

		// Token: 0x0400105F RID: 4191
		[ReadOnlyUI]
		[SerializeField]
		[SerializeReference]
		private List<ValueTuple<ShapeKey, AnimationCurve>> m_currentInteraccionShapeFix;

		// Token: 0x04001060 RID: 4192
		[ReadOnlyUI]
		[SerializeField]
		private PiezaDeRopaBase m_interactableCon;

		// Token: 0x04001061 RID: 4193
		private PiezasDeRopaLoader m_PiezasDeRopaLoader;

		// Token: 0x04001062 RID: 4194
		private IRopaManager m_IRopaManager;

		// Token: 0x04001063 RID: 4195
		[ReadOnlyUI]
		[SerializeField]
		private List<RopaCubre> m_currentInteraccionExponiendo = new List<RopaCubre>();

		// Token: 0x04001064 RID: 4196
		[ReadOnlyUI]
		[SerializeField]
		private RopaCubre m_currentInteraccionExponiendoFlags;

		// Token: 0x04001065 RID: 4197
		private bool m_flagNoActualizarAnimacion;

		// Token: 0x02000383 RID: 899
		// (Invoke) Token: 0x060013A6 RID: 5030
		public delegate void OnPiezaChangingWaitForHandler(PiezaDeRopaBase siendoRemovida, ModificableDeBool Or, GuiaDeRopaInteractable sender);

		// Token: 0x02000384 RID: 900
		// (Invoke) Token: 0x060013AA RID: 5034
		public delegate void OnPiezaChangingHandler(PiezaDeRopaBase siendoRemovida, PiezaDeRopaBase siendoAdded, GuiaDeRopaInteractable sender);

		// Token: 0x02000385 RID: 901
		// (Invoke) Token: 0x060013AE RID: 5038
		public delegate void OnPiezaChangedHandler(AgarranteObjeto agarradoPor, MapaDeRopa.RopaData.Interacciones interaccion, PiezaDeRopaBase siendoRemovida, GuiaDeRopaInteractable sender);
	}
}
