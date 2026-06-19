using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.Holes;
using Assets._ReusableScripts.CuchiCuchi.Penes;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000F0 RID: 240
	public class Penetraciones
	{
		// Token: 0x06000A0A RID: 2570 RVA: 0x0002060C File Offset: 0x0001E80C
		public Penetraciones(Penetraciones.Config config, BoneStretchedChain hole, CalculadorDePenetracion calculadorDePenetracion, Func<float> aperturaMinGetter)
		{
			if (hole == null)
			{
				throw new ArgumentNullException("hole", "hole null reference.");
			}
			if (config == null)
			{
				throw new ArgumentNullException("config", "config null reference.");
			}
			this.config = config;
			this.m_CalculadorDePenetracion = calculadorDePenetracion;
			this.m_hole = hole;
			this.m_dataCollector = this.m_hole.GetComponentNotNull<HolePointsDataCollector>();
			this.m_aperturaMinGetter = aperturaMinGetter;
			this.m_hole.onDisabled += this.M_hole_onDisabled;
		}

		// Token: 0x14000048 RID: 72
		// (add) Token: 0x06000A0B RID: 2571 RVA: 0x000206E8 File Offset: 0x0001E8E8
		// (remove) Token: 0x06000A0C RID: 2572 RVA: 0x00020720 File Offset: 0x0001E920
		public event Penetraciones.Check chekingPenetraciones;

		// Token: 0x14000049 RID: 73
		// (add) Token: 0x06000A0D RID: 2573 RVA: 0x00020758 File Offset: 0x0001E958
		// (remove) Token: 0x06000A0E RID: 2574 RVA: 0x00020790 File Offset: 0x0001E990
		public event Penetraciones.Check checkedPenetraciones;

		// Token: 0x1400004A RID: 74
		// (add) Token: 0x06000A0F RID: 2575 RVA: 0x000207C8 File Offset: 0x0001E9C8
		// (remove) Token: 0x06000A10 RID: 2576 RVA: 0x00020800 File Offset: 0x0001EA00
		public event Penetraciones.PenisTryingPenetrationHandler peneTryingPenetration;

		// Token: 0x1400004B RID: 75
		// (add) Token: 0x06000A11 RID: 2577 RVA: 0x00020838 File Offset: 0x0001EA38
		// (remove) Token: 0x06000A12 RID: 2578 RVA: 0x00020870 File Offset: 0x0001EA70
		public event Penetraciones.PenisPenetrationHandler peneEnter;

		// Token: 0x1400004C RID: 76
		// (add) Token: 0x06000A13 RID: 2579 RVA: 0x000208A8 File Offset: 0x0001EAA8
		// (remove) Token: 0x06000A14 RID: 2580 RVA: 0x000208E0 File Offset: 0x0001EAE0
		public event Penetraciones.PenisPenetrationHandler peneStay;

		// Token: 0x1400004D RID: 77
		// (add) Token: 0x06000A15 RID: 2581 RVA: 0x00020918 File Offset: 0x0001EB18
		// (remove) Token: 0x06000A16 RID: 2582 RVA: 0x00020950 File Offset: 0x0001EB50
		public event Penetraciones.PenisPenetrationHandler peneOut;

		// Token: 0x1400004E RID: 78
		// (add) Token: 0x06000A17 RID: 2583 RVA: 0x00020988 File Offset: 0x0001EB88
		// (remove) Token: 0x06000A18 RID: 2584 RVA: 0x000209C0 File Offset: 0x0001EBC0
		public event Penetraciones.PartTryingPenetrationHandler tryingPenetration;

		// Token: 0x1400004F RID: 79
		// (add) Token: 0x06000A19 RID: 2585 RVA: 0x000209F8 File Offset: 0x0001EBF8
		// (remove) Token: 0x06000A1A RID: 2586 RVA: 0x00020A30 File Offset: 0x0001EC30
		public event Penetraciones.PartPenetrationHandler onPenetrationEnter;

		// Token: 0x14000050 RID: 80
		// (add) Token: 0x06000A1B RID: 2587 RVA: 0x00020A68 File Offset: 0x0001EC68
		// (remove) Token: 0x06000A1C RID: 2588 RVA: 0x00020AA0 File Offset: 0x0001ECA0
		public event Penetraciones.PartPenetrationHandler onPenetrationStay;

		// Token: 0x14000051 RID: 81
		// (add) Token: 0x06000A1D RID: 2589 RVA: 0x00020AD8 File Offset: 0x0001ECD8
		// (remove) Token: 0x06000A1E RID: 2590 RVA: 0x00020B10 File Offset: 0x0001ED10
		public event Penetraciones.PartPenetrationHandler onPenetrationOut;

		// Token: 0x14000052 RID: 82
		// (add) Token: 0x06000A1F RID: 2591 RVA: 0x00020B48 File Offset: 0x0001ED48
		// (remove) Token: 0x06000A20 RID: 2592 RVA: 0x00020B80 File Offset: 0x0001ED80
		public event Action<PenetradorHits, BoneStretchedChain> onPenetrationUpdate;

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06000A21 RID: 2593 RVA: 0x00020BB5 File Offset: 0x0001EDB5
		// (set) Token: 0x06000A22 RID: 2594 RVA: 0x00020BBD File Offset: 0x0001EDBD
		public bool isDebug { get; set; }

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06000A23 RID: 2595 RVA: 0x00020BC6 File Offset: 0x0001EDC6
		public bool isPenetratedByAny
		{
			get
			{
				return this.m_currentHits.hayHits;
			}
		}

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06000A24 RID: 2596 RVA: 0x00020BD3 File Offset: 0x0001EDD3
		private CalculadorDePenetracion calculadorDePenetracion
		{
			get
			{
				return this.m_CalculadorDePenetracion;
			}
		}

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06000A25 RID: 2597 RVA: 0x00020BDB File Offset: 0x0001EDDB
		public BoneStretchedChain hole
		{
			get
			{
				return this.m_hole;
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06000A26 RID: 2598 RVA: 0x00020BE3 File Offset: 0x0001EDE3
		public HolePointsDataCollector dataCollector
		{
			get
			{
				return this.m_dataCollector;
			}
		}

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x06000A27 RID: 2599 RVA: 0x00020BEB File Offset: 0x0001EDEB
		public PenetradorHits currentHits
		{
			get
			{
				return this.m_currentHits;
			}
		}

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x06000A28 RID: 2600 RVA: 0x00020BF3 File Offset: 0x0001EDF3
		// (set) Token: 0x06000A29 RID: 2601 RVA: 0x00020BFB File Offset: 0x0001EDFB
		public bool flagedToCleanPenetrations { get; set; }

		// Token: 0x06000A2A RID: 2602 RVA: 0x00020C04 File Offset: 0x0001EE04
		private void M_hole_onDisabled(object obj)
		{
			this.flagedToCleanPenetrations = true;
			this.CheckPenetraciones(false);
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00020C14 File Offset: 0x0001EE14
		public IPene PeneCercano()
		{
			PenetradorHits currentHits = this.currentHits;
			Penetrador penetrador;
			if (currentHits == null)
			{
				penetrador = null;
			}
			else
			{
				PenisPartHit primero = currentHits.primero;
				penetrador = ((primero != null) ? primero.penis : null);
			}
			Penetrador penetrador2 = penetrador;
			if (penetrador2 != null)
			{
				return penetrador2;
			}
			IPene pene;
			if (this.m_CalculadorDePenetracion.TryEncontrarCercano(out pene))
			{
				return pene;
			}
			return null;
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x00020C60 File Offset: 0x0001EE60
		public void UpdatePenetrationState()
		{
			if (this.m_FixedUpdateId.IsCurrent())
			{
				return;
			}
			this.m_FixedUpdateId = ForcedFixedUpdateId.current;
			this.m_CalculadorDePenetracion.rayConfig.ancho = this.m_aperturaMinGetter();
			this.OnPenetrationUpdate();
			bool flag;
			if (this.m_OverridingTrayectos == null)
			{
				flag = this.m_CalculadorDePenetracion.TryCast(this.m_currentHits);
			}
			else
			{
				if (this.m_OverridingTrayectosId != this.m_FixedUpdateId)
				{
					Debug.LogError("trayectos son viejos y no fueron actualizados");
				}
				flag = this.m_CalculadorDePenetracion.TryCastMultipleTrayecto(this.m_OverridingTrayectos, this.m_currentHits);
			}
			this.CheckPenetraciones(flag);
			this.HelpPenetraciones();
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x00020D05 File Offset: 0x0001EF05
		public void SetMultipleTrayectoCalculadorDePenetracion([TupleElementNames(new string[] { "start", "end", "radius" })] IReadOnlyList<ValueTuple<Vector3, Vector3, float>> overridingTrayectos)
		{
			this.m_OverridingTrayectosId = ForcedFixedUpdateId.current;
			this.m_OverridingTrayectos = overridingTrayectos;
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x00020D1C File Offset: 0x0001EF1C
		private void HelpPenetraciones()
		{
			if (!this.config.activarHelpler)
			{
				return;
			}
			if (!this.config.puedeActivarHelplerSiMaxProfVirtualAlcanzada && this.hole.maximaProfundidadPhysicsAlcanzada)
			{
				return;
			}
			try
			{
				float num;
				this.m_CalculadorDePenetracion.TryCastHelper(this.m_ayudandoPartes, this.m_ayudandoPartesHits, this.config.holeProfundidadParaHelper, out num);
				for (int i = 0; i < this.m_ayudandoPartes.Count; i++)
				{
					this.OnParteDetectadaPorHelper(this.m_ayudandoPartes[i], this.m_ayudandoPartesHits[i], num);
				}
			}
			finally
			{
				this.m_ayudandoPartesHits.Clear();
				this.m_ayudandoPartes.Clear();
			}
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x00020DD8 File Offset: 0x0001EFD8
		private static bool PeneAcabaDeEntrar(IPeneConPartes pene, List<IPeneConPartes> lastPenes)
		{
			return !lastPenes.Contains(pene);
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00020DE4 File Offset: 0x0001EFE4
		private bool AceptaPenetracion(IPeneConPartes item, PenetradorHits currentParts)
		{
			Penetraciones.TryPenetrationArgs args = this.m_args;
			args.cantidadDePartesIntentando = currentParts.cantidadRealDeHitsContraPartes;
			bool flag;
			try
			{
				PenisPart puntaParte = item.puntaParte;
				if (!currentParts.ContainsKey(puntaParte))
				{
					args.DenyPenetration();
					flag = false;
				}
				else
				{
					IPeneIntentadorDePenetracion peneIntentadorDePenetracion = item as IPeneIntentadorDePenetracion;
					if (peneIntentadorDePenetracion != null)
					{
						int id = UpdateAutoId.current.id;
						peneIntentadorDePenetracion.DeclararIntentando(this.m_hole, id);
						if (!peneIntentadorDePenetracion.Closest(this.m_hole))
						{
							args.DenyPenetration();
							return false;
						}
					}
					this.OnPenisTryingPenetration(item, args);
					flag = args.aceptPenetration;
				}
			}
			finally
			{
				args.Reset();
			}
			return flag;
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00020E88 File Offset: 0x0001F088
		private void CheckPenetraciones(bool hayPenes)
		{
			Penetraciones.Check check = this.chekingPenetraciones;
			if (check != null)
			{
				check(this, hayPenes);
			}
			PenetradorHits currentHits = this.m_currentHits;
			currentHits.ObtenerPenes(this.m_currentPenes);
			try
			{
				if (this.flagedToCleanPenetrations)
				{
					hayPenes = false;
					currentHits.Clear();
					for (int i = 0; i < this.m_currentPenes.Count; i++)
					{
						this.m_currentPenes[i].ShrinkToRoot();
					}
					this.m_currentPenes.Clear();
				}
				if (hayPenes)
				{
					for (int j = this.m_currentPenes.Count - 1; j >= 0; j--)
					{
						IPeneConPartes peneConPartes = this.m_currentPenes[j];
						if (Penetraciones.PeneAcabaDeEntrar(peneConPartes, this.m_lastPenes))
						{
							if (!this.AceptaPenetracion(peneConPartes, currentHits))
							{
								currentHits.Remove(peneConPartes);
								this.m_currentPenes.RemoveAt(j);
							}
							else
							{
								this.OnPenisEnter(peneConPartes);
							}
						}
						else
						{
							this.OnPenisStay(peneConPartes);
						}
					}
					foreach (KeyValuePair<PenisPart, PenisPartHit> keyValuePair in currentHits.diccEnumerable)
					{
						PenisPart key = keyValuePair.Key;
						Penetraciones.TryPenetrationArgs args = this.m_args;
						if (!this.m_lastPartes.Contains(key))
						{
							this.OnPartTryingPenetration(keyValuePair.Value, this.m_args);
							if (!args.aceptPenetration)
							{
								this.m_failingPartes.Add(key);
							}
						}
						args.Reset();
					}
					if (this.m_failingPartes.Count > 0)
					{
						foreach (PenisPart penisPart in this.m_failingPartes)
						{
							currentHits.Remove(penisPart);
						}
					}
					foreach (KeyValuePair<PenisPart, PenisPartHit> keyValuePair2 in currentHits.diccEnumerable)
					{
						PenisPart key2 = keyValuePair2.Key;
						if (!this.m_lastPartes.Contains(key2))
						{
							this.OnPenetrationEnter(keyValuePair2.Value);
						}
						else
						{
							this.OnPenetrationStay(keyValuePair2.Value);
						}
					}
				}
				for (int k = 0; k < this.m_lastPenes.Count; k++)
				{
					IPeneConPartes peneConPartes2 = this.m_lastPenes[k];
					if (!peneConPartes2.isDestroyed && !this.m_currentPenes.Contains(peneConPartes2))
					{
						this.OnPenisExit(peneConPartes2);
					}
				}
				foreach (PenisPart penisPart2 in this.m_lastPartes)
				{
					if (!penisPart2.isDestroyed && !currentHits.ContainsKey(penisPart2))
					{
						this.OnPenetrationOutCallBacks(penisPart2);
					}
				}
				foreach (PenisPart penisPart3 in this.m_lastPartes)
				{
					if (!penisPart3.isDestroyed && !currentHits.ContainsKey(penisPart3))
					{
						this.OnPenetrationOutEvent(penisPart3);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogError(ex);
				throw ex;
			}
			finally
			{
				this.flagedToCleanPenetrations = false;
				this.m_failingPartes.Clear();
				this.m_lastPartes.Clear();
				if (currentHits.count > 0)
				{
					foreach (KeyValuePair<PenisPart, PenisPartHit> keyValuePair3 in currentHits.diccEnumerable)
					{
						this.m_lastPartes.Add(keyValuePair3.Key);
					}
				}
				this.m_lastPenes.Clear();
				this.m_lastPenes.AddRange(this.m_currentPenes);
				Penetraciones.Check check2 = this.checkedPenetraciones;
				if (check2 != null)
				{
					check2(this, hayPenes);
				}
			}
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x000212DC File Offset: 0x0001F4DC
		protected void OnPenetrationUpdate()
		{
			Action<PenetradorHits, BoneStretchedChain> action = this.onPenetrationUpdate;
			if (action == null)
			{
				return;
			}
			action(this.m_currentHits, this.m_hole);
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x000212FA File Offset: 0x0001F4FA
		protected void OnPenisTryingPenetration(IPeneConPartes penis, Penetraciones.TryPenetrationArgs result)
		{
			if (this.isDebug)
			{
				Debug.Log("OnPenisTryingPenetration " + penis.name);
			}
			Penetraciones.PenisTryingPenetrationHandler penisTryingPenetrationHandler = this.peneTryingPenetration;
			if (penisTryingPenetrationHandler != null)
			{
				penisTryingPenetrationHandler(result, penis, this);
			}
			((IPenisPenetratiosCallbacks)penis).TryingEnter(result, this);
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x0002133A File Offset: 0x0001F53A
		protected void OnPenisEnter(IPeneConPartes penis)
		{
			if (this.isDebug)
			{
				Debug.Log("OnPenisEnter " + penis.name);
			}
			if (this.peneEnter != null)
			{
				this.peneEnter(penis, this);
			}
			((IPenisPenetratiosCallbacks)penis).OnEnter(this);
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x0002137A File Offset: 0x0001F57A
		protected void OnPenisStay(IPeneConPartes penis)
		{
			if (this.isDebug)
			{
				Debug.Log("OnPenisStay " + penis.name);
			}
			if (this.peneStay != null)
			{
				this.peneStay(penis, this);
			}
			((IPenisPenetratiosCallbacks)penis).OnStay(this);
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x000213BA File Offset: 0x0001F5BA
		protected void OnPenisExit(IPeneConPartes penis)
		{
			if (this.isDebug)
			{
				Debug.Log("OnPenisExit " + penis.name);
			}
			Penetraciones.PenisPenetrationHandler penisPenetrationHandler = this.peneOut;
			if (penisPenetrationHandler != null)
			{
				penisPenetrationHandler(penis, this);
			}
			((IPenisPenetratiosCallbacks)penis).OnExit(this);
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x000213F8 File Offset: 0x0001F5F8
		protected void OnParteDetectadaPorHelper(PenisPart parte, RaycastHit hit, float largoDeRayo)
		{
			if (this.isDebug)
			{
				Debug.Log("OnPuntaDetectadaPorHelper " + parte.name);
			}
			((IPenisPartPenetratiosCallbacks)parte).OnHelperHit(hit, this.m_hole, largoDeRayo);
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x00021428 File Offset: 0x0001F628
		protected void OnPartTryingPenetration(PenisPartHit hit, Penetraciones.TryPenetrationArgs result)
		{
			PenisPart penisPart = hit.penisPart;
			if (this.isDebug)
			{
				Debug.Log("TryingPenetration " + penisPart.physicBone.name);
			}
			if (!this.config.puedePenetrarSiMaxProfVirtualAlcanzada && !hit.penisPart.inside && this.hole.maximaProfundidadPhysicsAlcanzada)
			{
				result.DenyPenetration();
			}
			Penetraciones.PartTryingPenetrationHandler partTryingPenetrationHandler = this.tryingPenetration;
			if (partTryingPenetrationHandler != null)
			{
				partTryingPenetrationHandler(result, penisPart, hit, this);
			}
			((IPenisPartPenetratiosCallbacks)penisPart).TryingEnter(result, hit, this);
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x000214AC File Offset: 0x0001F6AC
		protected void OnPenetrationEnter(PenisPartHit hit)
		{
			PenisPart penisPart = hit.penisPart;
			if (this.isDebug)
			{
				Debug.Log("OnPenetrationEnter " + penisPart.physicBone.name);
			}
			Penetraciones.PartPenetrationHandler partPenetrationHandler = this.onPenetrationEnter;
			if (partPenetrationHandler != null)
			{
				partPenetrationHandler(penisPart, hit, this);
			}
			((IPenisPartPenetratiosCallbacks)penisPart).OnEnter(hit, this);
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x00021500 File Offset: 0x0001F700
		protected void OnPenetrationStay(PenisPartHit hit)
		{
			PenisPart penisPart = hit.penisPart;
			if (this.isDebug)
			{
				Debug.Log("OnPenetrationStay " + penisPart.physicBone.name);
			}
			Penetraciones.PartPenetrationHandler partPenetrationHandler = this.onPenetrationStay;
			if (partPenetrationHandler != null)
			{
				partPenetrationHandler(penisPart, hit, this);
			}
			((IPenisPartPenetratiosCallbacks)penisPart).OnStay(hit, this);
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00021552 File Offset: 0x0001F752
		protected void OnPenetrationOutCallBacks(PenisPart parte)
		{
			if (this.isDebug)
			{
				Debug.Log("OnPenetrationOutCallBacks " + parte.physicBone.name);
			}
			((IPenisPartPenetratiosCallbacks)parte).OnExit(this);
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x0002157D File Offset: 0x0001F77D
		protected void OnPenetrationOutEvent(PenisPart parte)
		{
			if (this.isDebug)
			{
				Debug.Log("OnPenetrationOutEvent " + parte.physicBone.name);
			}
			Penetraciones.PartPenetrationHandler partPenetrationHandler = this.onPenetrationOut;
			if (partPenetrationHandler == null)
			{
				return;
			}
			partPenetrationHandler(parte, null, this);
		}

		// Token: 0x04000567 RID: 1383
		private Penetraciones.TryPenetrationArgs m_args = new Penetraciones.TryPenetrationArgs();

		// Token: 0x04000569 RID: 1385
		public readonly Penetraciones.Config config;

		// Token: 0x0400056A RID: 1386
		private Func<float> m_aperturaMinGetter;

		// Token: 0x0400056B RID: 1387
		private ForcedFixedUpdateId m_OverridingTrayectosId;

		// Token: 0x0400056C RID: 1388
		[TupleElementNames(new string[] { "start", "end", "radius" })]
		private IReadOnlyList<ValueTuple<Vector3, Vector3, float>> m_OverridingTrayectos;

		// Token: 0x0400056D RID: 1389
		private PenetradorHits m_currentHits = new PenetradorHits();

		// Token: 0x0400056E RID: 1390
		private ForcedFixedUpdateId m_FixedUpdateId;

		// Token: 0x0400056F RID: 1391
		private CalculadorDePenetracion m_CalculadorDePenetracion;

		// Token: 0x04000570 RID: 1392
		private BoneStretchedChain m_hole;

		// Token: 0x04000571 RID: 1393
		private HolePointsDataCollector m_dataCollector;

		// Token: 0x04000572 RID: 1394
		private List<PenisPart> m_ayudandoPartes = new List<PenisPart>();

		// Token: 0x04000573 RID: 1395
		private List<RaycastHit> m_ayudandoPartesHits = new List<RaycastHit>();

		// Token: 0x04000574 RID: 1396
		private List<IPeneConPartes> m_currentPenes = new List<IPeneConPartes>();

		// Token: 0x04000575 RID: 1397
		private List<IPeneConPartes> m_lastPenes = new List<IPeneConPartes>();

		// Token: 0x04000576 RID: 1398
		private HashSet<PenisPart> m_lastPartes = new HashSet<PenisPart>();

		// Token: 0x04000577 RID: 1399
		private HashSet<PenisPart> m_failingPartes = new HashSet<PenisPart>();

		// Token: 0x020001C7 RID: 455
		// (Invoke) Token: 0x06000F5C RID: 3932
		public delegate void PartPenetrationHandler(PenisPart parte, PenisPartHit hit, Penetraciones penetracionesChecker);

		// Token: 0x020001C8 RID: 456
		// (Invoke) Token: 0x06000F60 RID: 3936
		public delegate void PartTryingPenetrationHandler(Penetraciones.TryPenetrationArgs args, PenisPart parte, PenisPartHit hit, Penetraciones penetracionesChecker);

		// Token: 0x020001C9 RID: 457
		// (Invoke) Token: 0x06000F64 RID: 3940
		public delegate void Check(Penetraciones penetracionesChecker, bool penesDetectados);

		// Token: 0x020001CA RID: 458
		// (Invoke) Token: 0x06000F68 RID: 3944
		public delegate void PenisPenetrationHandler(IPeneConPartes pene, Penetraciones penetracionesChecker);

		// Token: 0x020001CB RID: 459
		// (Invoke) Token: 0x06000F6C RID: 3948
		public delegate void PenisTryingPenetrationHandler(Penetraciones.TryPenetrationArgs args, IPeneConPartes pene, Penetraciones penetracionesChecker);

		// Token: 0x020001CC RID: 460
		public class TryPenetrationArgs
		{
			// Token: 0x17000520 RID: 1312
			// (get) Token: 0x06000F6F RID: 3951 RVA: 0x000345A2 File Offset: 0x000327A2
			public bool aceptPenetration
			{
				get
				{
					return this.m_aceptPenetration;
				}
			}

			// Token: 0x17000521 RID: 1313
			// (get) Token: 0x06000F70 RID: 3952 RVA: 0x000345AA File Offset: 0x000327AA
			// (set) Token: 0x06000F71 RID: 3953 RVA: 0x000345B2 File Offset: 0x000327B2
			public int cantidadDePartesIntentando { get; set; }

			// Token: 0x06000F72 RID: 3954 RVA: 0x000345BB File Offset: 0x000327BB
			public void DenyPenetration()
			{
				this.m_aceptPenetration = false;
			}

			// Token: 0x06000F73 RID: 3955 RVA: 0x000345C4 File Offset: 0x000327C4
			public void Reset()
			{
				this.cantidadDePartesIntentando = 0;
				this.m_aceptPenetration = true;
			}

			// Token: 0x04000A24 RID: 2596
			private bool m_aceptPenetration = true;
		}

		// Token: 0x020001CD RID: 461
		[Serializable]
		public class Config
		{
			// Token: 0x04000A25 RID: 2597
			public bool activarHelpler = true;

			// Token: 0x04000A26 RID: 2598
			public bool puedeActivarHelplerSiMaxProfVirtualAlcanzada = true;

			// Token: 0x04000A27 RID: 2599
			public bool puedePenetrarSiMaxProfVirtualAlcanzada;

			// Token: 0x04000A28 RID: 2600
			[Range(0f, 1f)]
			public float holeProfundidadParaHelper = 0.333f;
		}
	}
}
