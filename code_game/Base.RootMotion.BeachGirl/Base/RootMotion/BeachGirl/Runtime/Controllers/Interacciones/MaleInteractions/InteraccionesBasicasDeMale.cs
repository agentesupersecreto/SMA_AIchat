using System;
using System.Collections.Generic;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones.MaleInteractions
{
	// Token: 0x02000042 RID: 66
	public class InteraccionesBasicasDeMale : CustomMonobehaviour, IInteraccionesDeCharacterMale, IInteraccionesDeCharacter<InteraccionDeCharacter>, IInteraccionesDeCharacter, IComponentAwakeable
	{
		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060002BE RID: 702 RVA: 0x0000E63F File Offset: 0x0000C83F
		public IReadOnlyList<InteraccionDeCharacter> interacciones
		{
			get
			{
				return this.m_interacciones;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060002BF RID: 703 RVA: 0x0000E647 File Offset: 0x0000C847
		public IReadOnlyList<InteraccionDeCharacter> interaccionesBases
		{
			get
			{
				return this.interacciones;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x0000E64F File Offset: 0x0000C84F
		public IReadOnlyList<InteraccionDeCharacter> interaccionesPrimarias
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x0000E652 File Offset: 0x0000C852
		public IReadOnlyList<InteraccionDeCharacter> interaccionesPrimariasBases
		{
			get
			{
				return this.interaccionesPrimarias;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x0000E65A File Offset: 0x0000C85A
		public IReadOnlyList<InteraccionDeCharacter> interaccionesSegundarias
		{
			get
			{
				return this.m_ListaDeSegundarias;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x0000E662 File Offset: 0x0000C862
		public IReadOnlyList<InteraccionDeCharacter> interaccionesSegundariasBases
		{
			get
			{
				return this.interaccionesSegundarias;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x0000E66A File Offset: 0x0000C86A
		public IReadOnlyDictionary<int, List<InteraccionDeCharacter>> interaccionesDeLayer
		{
			get
			{
				return this.m_interaccionesDeLayer;
			}
		}

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x060002C5 RID: 709 RVA: 0x0000E674 File Offset: 0x0000C874
		// (remove) Token: 0x060002C6 RID: 710 RVA: 0x0000E6AC File Offset: 0x0000C8AC
		public event Action<InteraccionDeCharacter> comenzada;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x060002C7 RID: 711 RVA: 0x0000E6E4 File Offset: 0x0000C8E4
		// (remove) Token: 0x060002C8 RID: 712 RVA: 0x0000E71C File Offset: 0x0000C91C
		public event Action<InteraccionDeCharacter> terminada;

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x0000E751 File Offset: 0x0000C951
		public ICharacter character
		{
			get
			{
				if (this.m_character == null)
				{
					this.m_character = base.GetComponentInParent<ICharacter>();
				}
				return this.m_character;
			}
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0000E770 File Offset: 0x0000C970
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			ICharacter character = this.character;
			this.m_updater = this.GetComponentEnRoot(false);
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
			}
			this.UpdateListas();
			foreach (InteraccionesBasicasDeMale.InteraccionesParSegundaria interaccionesParSegundaria in this.m_ListaDeSegundarias)
			{
				InteraccionAddingEvents instancia = interaccionesParSegundaria.instancia;
				if (instancia != null)
				{
					instancia.AddedTo(this);
				}
			}
			if (this.m_rootsDeInteracionesPorLayer.Count == 0)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000E818 File Offset: 0x0000CA18
		public void UpdateListas()
		{
			this.m_interacciones = new List<InteraccionDeCharacter>();
			this.m_InteraccionParEnID = new Dictionary<int, InteraccionDeCharacter>();
			this.m_InteraccionDecharacterDeInteraccion = new Dictionary<Interaccion, InteraccionDeCharacter>();
			this.m_interaccionesDeLayer = new Dictionary<int, List<InteraccionDeCharacter>>();
			this.m_interaccionesDiccDeLayer = new Dictionary<int, Dictionary<int, InteraccionDeCharacter>>();
			for (int i = this.m_AddedSegundarias.Count - 1; i >= 0; i--)
			{
				if (this.m_AddedSegundarias[i] == null || this.m_AddedSegundarias[i].instancia == null || this.m_AddedSegundarias[i] is InteraccionesBasicasDeMale.InteraccionesParPrimaria || this.m_AddedSegundarias[i] is InteraccionesBasicasDeMale.InteraccionesParSegundaria)
				{
					this.m_AddedSegundarias.RemoveAt(i);
				}
			}
			foreach (InteraccionesBasicasDeMale.InteraccionesParSegundaria interaccionesParSegundaria in this.m_ListaDeSegundarias)
			{
				if (interaccionesParSegundaria.instancia == null)
				{
					throw new ArgumentNullException("item.instancia", "item.instancia null reference.");
				}
				try
				{
					this.m_AddedSegundarias.Add(interaccionesParSegundaria);
				}
				catch (Exception)
				{
					throw;
				}
			}
			this.m_interaccionesDeLayer.Add(1, this.m_AddedSegundarias);
			this.m_interaccionesDiccDeLayer.Add(0, new Dictionary<int, InteraccionDeCharacter>());
			this.m_interaccionesDiccDeLayer.Add(1, new Dictionary<int, InteraccionDeCharacter>());
			foreach (InteraccionDeCharacter interaccionDeCharacter in this.m_AddedSegundarias)
			{
				this.m_interacciones.Add(interaccionDeCharacter);
				if (this.m_InteraccionParEnID.ContainsKey(interaccionDeCharacter.id))
				{
					Debug.LogWarning(string.Concat(new string[]
					{
						"interaccion: ",
						interaccionDeCharacter.instancia.name,
						" con id: ",
						interaccionDeCharacter.id.ToString(),
						", repetida."
					}), interaccionDeCharacter.instancia);
				}
				else
				{
					this.m_InteraccionParEnID.Add(interaccionDeCharacter.id, interaccionDeCharacter);
					this.m_InteraccionDecharacterDeInteraccion.Add(interaccionDeCharacter.instancia, interaccionDeCharacter);
					interaccionDeCharacter.instancia.comenzada += this.Interaccion_comenzada;
					interaccionDeCharacter.instancia.terminada += this.Interaccion_terminada;
					this.m_interaccionesDiccDeLayer[1].Add(interaccionDeCharacter.id, interaccionDeCharacter);
				}
			}
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000EAC8 File Offset: 0x0000CCC8
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			foreach (InteraccionDeCharacter interaccionDeCharacter in this.m_interacciones)
			{
				InteraccionDeCharacter par = interaccionDeCharacter;
				if (par != null && par.setInitial)
				{
					GlobalUpdater.instancia.Invokar(delegate
					{
						par.instancia.Ejecutar(1, -1f, ControllerPrioridadConfig.prioridad, 1f, 1f, false);
					}, 2f);
				}
			}
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000EB58 File Offset: 0x0000CD58
		public Transform GetRootDeLayer(int layer)
		{
			Transform transform;
			try
			{
				transform = this.m_rootsDeInteracionesPorLayer[layer];
			}
			catch (Exception ex)
			{
				throw new IndexOutOfRangeException("Layer: " + layer.ToString() + " no existe en interacciones de: " + this.m_character.nombreCompleto, ex);
			}
			return transform;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000EBB0 File Offset: 0x0000CDB0
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			foreach (InteraccionDeCharacter interaccionDeCharacter in this.m_interacciones)
			{
				Interaccion instancia = interaccionDeCharacter.instancia;
				if (!(instancia == null))
				{
					instancia.comenzada -= this.Interaccion_comenzada;
					instancia.terminada -= this.Interaccion_terminada;
				}
			}
			foreach (InteraccionesBasicasDeMale.InteraccionesParSegundaria interaccionesParSegundaria in this.m_ListaDeSegundarias)
			{
				InteraccionAddingEvents instancia2 = interaccionesParSegundaria.instancia;
				if (instancia2 != null)
				{
					instancia2.RemovingFrom(this);
					instancia2.RemovedFrom(this);
				}
			}
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000EC88 File Offset: 0x0000CE88
		public bool TryAddInteraction(int id, Interaccion interaccion)
		{
			bool flag;
			try
			{
				if (interaccion == null)
				{
					if (Application.isEditor || Debug.isDebugBuild)
					{
						Debug.LogWarning("Tratando de añadir una interaccion nulla a: " + this.m_character.nombreCompleto, this);
					}
					flag = false;
				}
				else
				{
					int interactionLayer = interaccion.interactionLayer;
					if (this.m_InteraccionParEnID.ContainsKey(id))
					{
						if (Application.isEditor || Debug.isDebugBuild)
						{
							Debug.LogWarning(string.Concat(new string[]
							{
								"Tratando de añadir interaccion: ",
								interaccion.name,
								" con id: ",
								id.ToString(),
								", repetida."
							}), interaccion);
						}
						flag = false;
					}
					else
					{
						List<InteraccionDeCharacter> list;
						if (this.m_interaccionesDeLayer.ContainsKey(interactionLayer))
						{
							list = this.m_interaccionesDeLayer[interactionLayer];
						}
						else
						{
							list = new List<InteraccionDeCharacter>();
							this.m_interaccionesDeLayer.Add(interactionLayer, list);
						}
						InteraccionesBasicasDeMale.InteraccionesParGenerica interaccionesParGenerica = new InteraccionesBasicasDeMale.InteraccionesParGenerica();
						interaccionesParGenerica.id = id;
						interaccionesParGenerica.layer = interactionLayer;
						interaccionesParGenerica.instancia = interaccion;
						interaccionesParGenerica.setInitial = false;
						list.Add(interaccionesParGenerica);
						this.m_InteraccionParEnID.Add(id, interaccionesParGenerica);
						this.m_InteraccionDecharacterDeInteraccion.Add(interaccion, interaccionesParGenerica);
						this.m_interacciones.Add(interaccionesParGenerica);
						if (this.m_interaccionesDiccDeLayer.ContainsKey(interactionLayer))
						{
							this.m_interaccionesDiccDeLayer[interactionLayer].Add(id, interaccionesParGenerica);
						}
						else
						{
							this.m_interaccionesDiccDeLayer.Add(interactionLayer, new Dictionary<int, InteraccionDeCharacter> { { id, interaccionesParGenerica } });
						}
						((InteraccionAddingEvents)interaccion).AddedTo(this);
						interaccion.comenzada += this.Interaccion_comenzada;
						interaccion.terminada += this.Interaccion_terminada;
						flag = true;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				throw ex;
			}
			return flag;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000EE44 File Offset: 0x0000D044
		private void Interaccion_comenzada(Interaccion obj)
		{
			InteraccionDeCharacter interaccionDeCharacter;
			if (!this.m_InteraccionDecharacterDeInteraccion.TryGetValue(obj, out interaccionDeCharacter))
			{
				Debug.LogError("Inter No Existia en Character: " + this.character.nombreCompleto + " inter name: " + obj.name, obj);
				return;
			}
			Action<InteraccionDeCharacter> action = this.comenzada;
			if (action == null)
			{
				return;
			}
			action(interaccionDeCharacter);
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000EE9C File Offset: 0x0000D09C
		private void Interaccion_terminada(Interaccion obj)
		{
			InteraccionDeCharacter interaccionDeCharacter;
			if (!this.m_InteraccionDecharacterDeInteraccion.TryGetValue(obj, out interaccionDeCharacter))
			{
				Debug.LogError("Inter No Existia en Character: " + this.character.nombreCompleto + " inter name: " + obj.name, obj);
				return;
			}
			Action<InteraccionDeCharacter> action = this.terminada;
			if (action == null)
			{
				return;
			}
			action(interaccionDeCharacter);
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000EEF4 File Offset: 0x0000D0F4
		public bool TryRemoveInteraction(int id)
		{
			bool flag2;
			try
			{
				if ((Application.isEditor || Debug.isDebugBuild) && this.m_InteraccionParEnID.ContainsKey(id) && this.EstaEjecutandose(id))
				{
					Debug.LogWarning("Se esta intando remover una interaccion primaria de id: " + id.ToString() + ", al esta estarse ejecutando , talvez se generen problemas.");
				}
				InteraccionDeCharacter interaccionDeCharacter;
				bool flag;
				if (this.m_InteraccionParEnID.TryGetValue(id, out interaccionDeCharacter))
				{
					flag = true;
					this.m_InteraccionParEnID.Remove(id);
				}
				else
				{
					flag = false;
				}
				if (flag)
				{
					List<InteraccionDeCharacter> list = this.m_interaccionesDeLayer[interaccionDeCharacter.layer];
					for (int i = list.Count - 1; i >= 0; i--)
					{
						InteraccionDeCharacter interaccionDeCharacter2 = list[i];
						if (interaccionDeCharacter2.id == id)
						{
							Interaccion instancia = interaccionDeCharacter2.instancia;
							if (instancia != null)
							{
								((InteraccionAddingEvents)instancia).RemovingFrom(this);
							}
						}
					}
				}
				Dictionary<int, InteraccionDeCharacter> dictionary;
				if (this.m_interaccionesDiccDeLayer.TryGetValue(interaccionDeCharacter.layer, out dictionary))
				{
					flag = true;
					dictionary.Remove(id);
				}
				else
				{
					flag = flag;
				}
				if (((interaccionDeCharacter != null) ? interaccionDeCharacter.instancia : null) != null)
				{
					this.m_InteraccionDecharacterDeInteraccion.Remove(interaccionDeCharacter.instancia);
				}
				for (int j = this.m_interacciones.Count - 1; j >= 0; j--)
				{
					if (this.m_interacciones[j].id == id)
					{
						this.m_interacciones.RemoveAt(j);
					}
				}
				if (flag)
				{
					List<InteraccionDeCharacter> list2 = this.m_interaccionesDeLayer[interaccionDeCharacter.layer];
					this.m_interaccionesDiccDeLayer[interaccionDeCharacter.layer].Remove(id);
					for (int k = list2.Count - 1; k >= 0; k--)
					{
						InteraccionDeCharacter interaccionDeCharacter3 = list2[k];
						if (interaccionDeCharacter3.id == id)
						{
							list2.RemoveAt(k);
							Interaccion instancia2 = interaccionDeCharacter3.instancia;
							if (instancia2 != null)
							{
								((InteraccionAddingEvents)instancia2).RemovedFrom(this);
							}
							interaccionDeCharacter3.instancia.comenzada -= this.Interaccion_comenzada;
							interaccionDeCharacter3.instancia.terminada -= this.Interaccion_terminada;
						}
					}
				}
				flag2 = flag;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				throw ex;
			}
			return flag2;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000F110 File Offset: 0x0000D310
		public void GetEjecutandose(int layer, IList<InteraccionDeCharacter> ejecutandose)
		{
			List<InteraccionDeCharacter> list;
			if (!this.m_interaccionesDeLayer.TryGetValue(layer, out list))
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				InteraccionDeCharacter interaccionDeCharacter = list[i];
				if (this.EstaEjecutandose(interaccionDeCharacter.id))
				{
					ejecutandose.Add(interaccionDeCharacter);
				}
			}
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000F15C File Offset: 0x0000D35C
		public bool Ejecutandose(InteraccionesBasicasDeMale.InteraccionPrimariaName @enum, out Interaccion ejecutandose)
		{
			return this.EstaEjecutandose(@enum.GetInteractionID(), out ejecutandose);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000F16B File Offset: 0x0000D36B
		public bool Ejecutandose(InteraccionesBasicasDeMale.InteraccionSegundariaName @enum, out Interaccion ejecutandose)
		{
			return this.EstaEjecutandose(@enum.GetInteractionID(), out ejecutandose);
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000F17C File Offset: 0x0000D37C
		public bool EstaEjecutandose(InteraccionesBasicasDeMale.InteraccionPrimariaName @enum)
		{
			Interaccion interaccion;
			return this.Ejecutandose(@enum, out interaccion);
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000F194 File Offset: 0x0000D394
		public bool EstaEjecutandose(InteraccionesBasicasDeMale.InteraccionSegundariaName @enum)
		{
			Interaccion interaccion;
			return this.Ejecutandose(@enum, out interaccion);
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0000F1AC File Offset: 0x0000D3AC
		public bool EstaEjecutandose(int id)
		{
			Interaccion interaccion;
			return this.EstaEjecutandose(id, out interaccion);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000F1C4 File Offset: 0x0000D3C4
		public bool EstaEjecutandose(int id, out Interaccion ejecutandose)
		{
			bool flag;
			try
			{
				ejecutandose = null;
				InteraccionDeCharacter interaccionDeCharacter;
				if (!this.m_InteraccionParEnID.TryGetValue(id, out interaccionDeCharacter))
				{
					flag = false;
				}
				else
				{
					ejecutandose = interaccionDeCharacter.instancia;
					flag = ejecutandose.algunaEstaEjecutandose;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				throw ex;
			}
			return flag;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000F214 File Offset: 0x0000D414
		[Obsolete("Ya es compatible con varias primarias ejecutandose al tiempo", true)]
		public InteraccionDeCharacter ObtenerEjecutandosePrimaria()
		{
			InteraccionDeCharacter interaccionDeCharacter;
			try
			{
				if (!this.m_interaccionesDeLayer.ContainsKey(0))
				{
					interaccionDeCharacter = null;
				}
				else
				{
					List<InteraccionDeCharacter> list = this.m_interaccionesDeLayer[0];
					for (int i = 0; i < list.Count; i++)
					{
						InteraccionDeCharacter interaccionDeCharacter2 = list[i];
						if (interaccionDeCharacter2.instancia.ejecutandose)
						{
							return interaccionDeCharacter2;
						}
					}
					interaccionDeCharacter = null;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				throw ex;
			}
			return interaccionDeCharacter;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000F288 File Offset: 0x0000D488
		public void ObtenerEjecutandosePrimaria(IList<InteraccionDeCharacter> result)
		{
			try
			{
				if (this.m_interaccionesDeLayer.ContainsKey(0))
				{
					IReadOnlyList<Component> readOnlyList = this.m_updater.SortedIKsDeLayer(0);
					List<InteraccionDeCharacter> list = this.m_interaccionesDeLayer[0];
					for (int i = 0; i < readOnlyList.Count; i++)
					{
						int num = this.m_updater.IDDeIK(readOnlyList[i]);
						for (int j = 0; j < list.Count; j++)
						{
							InteraccionDeCharacter interaccionDeCharacter = list[j];
							if (interaccionDeCharacter.instancia.ejecutandose && interaccionDeCharacter.instancia.lastInteractionSystemID == num)
							{
								result.Add(interaccionDeCharacter);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				throw ex;
			}
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000F344 File Offset: 0x0000D544
		public InteraccionDeCharacter ObtenerFirstEjecutandosePrimaria()
		{
			InteraccionDeCharacter interaccionDeCharacter;
			try
			{
				if (!this.m_interaccionesDeLayer.ContainsKey(0))
				{
					interaccionDeCharacter = null;
				}
				else
				{
					IReadOnlyList<Component> readOnlyList = this.m_updater.SortedIKsDeLayer(0);
					List<InteraccionDeCharacter> list = this.m_interaccionesDeLayer[0];
					for (int i = 0; i < readOnlyList.Count; i++)
					{
						int num = this.m_updater.IDDeIK(readOnlyList[i]);
						for (int j = 0; j < list.Count; j++)
						{
							InteraccionDeCharacter interaccionDeCharacter2 = list[j];
							if (interaccionDeCharacter2.instancia.ejecutandose && interaccionDeCharacter2.instancia.lastInteractionSystemID == num)
							{
								return interaccionDeCharacter2;
							}
						}
					}
					interaccionDeCharacter = null;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				throw ex;
			}
			return interaccionDeCharacter;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000F404 File Offset: 0x0000D604
		public bool EsValidaParaCurrentAnimControllerBase(InteraccionDeCharacter interaccionPar)
		{
			return true;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000F407 File Offset: 0x0000D607
		public bool EsValidaParaCurrentAnimController(InteraccionDeCharacter interaccionPar)
		{
			return true;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000F40A File Offset: 0x0000D60A
		public bool TryObtenerSiEsValida(InteraccionesBasicasDeMale.InteraccionPrimariaName @enum, out Interaccion interaccion)
		{
			return this.TryObtenerSiEsValida(@enum.GetInteractionID(), out interaccion);
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000F419 File Offset: 0x0000D619
		public bool TryObtenerSiEsValida(InteraccionesBasicasDeMale.InteraccionSegundariaName @enum, out Interaccion interaccion)
		{
			return this.TryObtenerSiEsValida(@enum.GetInteractionID(), out interaccion);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000F428 File Offset: 0x0000D628
		public bool TryObtenerSiEsValida(int id, out Interaccion interaccion)
		{
			interaccion = null;
			InteraccionDeCharacter interaccionDeCharacter;
			bool flag = this.TryObtenerSiEsValida(id, out interaccionDeCharacter);
			if (interaccionDeCharacter != null)
			{
				interaccion = interaccionDeCharacter.instancia;
			}
			return flag;
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000F44C File Offset: 0x0000D64C
		public bool TryObtenerSiEsValida(int id, out InteraccionDeCharacter interaccionDeCharacter)
		{
			bool flag;
			try
			{
				interaccionDeCharacter = null;
				InteraccionDeCharacter interaccionDeCharacter2;
				if (!this.m_InteraccionParEnID.TryGetValue(id, out interaccionDeCharacter2))
				{
					flag = false;
				}
				else
				{
					interaccionDeCharacter = interaccionDeCharacter2;
					flag = this.EsValidaParaCurrentAnimController(interaccionDeCharacter2);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				throw ex;
			}
			return flag;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000F498 File Offset: 0x0000D698
		public bool ContieneAndIsValido(int id)
		{
			InteraccionDeCharacter interaccionDeCharacter;
			return this.m_InteraccionParEnID.TryGetValue(id, out interaccionDeCharacter) && this.EsValidaParaCurrentAnimController(interaccionDeCharacter);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000F4BE File Offset: 0x0000D6BE
		public InteraccionDeCharacter ObtenerBase(int id)
		{
			return this.Obtener(id);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000F4C7 File Offset: 0x0000D6C7
		public InteraccionDeCharacter Obtener(InteraccionesBasicasDeMale.InteraccionSegundariaName @enum)
		{
			return this.Obtener(@enum.GetInteractionID());
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000F4D8 File Offset: 0x0000D6D8
		public InteraccionDeCharacter Obtener(int id)
		{
			InteraccionDeCharacter interaccionDeCharacter;
			if (!this.m_InteraccionParEnID.TryGetValue(id, out interaccionDeCharacter))
			{
				return null;
			}
			return interaccionDeCharacter;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0000F4F8 File Offset: 0x0000D6F8
		public bool Contiene(int id)
		{
			InteraccionDeCharacter interaccionDeCharacter;
			if (!this.m_InteraccionParEnID.TryGetValue(id, out interaccionDeCharacter))
			{
				return false;
			}
			if (interaccionDeCharacter.instancia.owner != this)
			{
				Object @object = interaccionDeCharacter.instancia.owner as Object;
				Debug.LogError(string.Concat(new string[]
				{
					"Interaccion de id: ",
					id.ToString(),
					" estaba añadida pero el owner no era ",
					base.name,
					" si no ",
					new ValueTuple<string, InteraccionesBasicasDeMale>(@object ? @object.name : "NULL", this).ToString()
				}));
				this.TryRemoveInteraction(id);
				return false;
			}
			return true;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000F5D4 File Offset: 0x0000D7D4
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000F5DC File Offset: 0x0000D7DC
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x040001ED RID: 493
		[SerializeField]
		[CoolArrayItem]
		private List<Transform> m_rootsDeInteracionesPorLayer = new List<Transform>();

		// Token: 0x040001EE RID: 494
		[Header("Interacciones Estaticas")]
		[SerializeField]
		private List<InteraccionesBasicasDeMale.InteraccionesParSegundaria> m_ListaDeSegundarias = new List<InteraccionesBasicasDeMale.InteraccionesParSegundaria>();

		// Token: 0x040001EF RID: 495
		[Header("Read Only")]
		[ReadOnlyUI]
		[CoolArrayItem(removable = false, reorderable = false)]
		[SerializeField]
		private List<InteraccionDeCharacter> m_AddedSegundarias = new List<InteraccionDeCharacter>();

		// Token: 0x040001F0 RID: 496
		private List<InteraccionDeCharacter> m_interacciones;

		// Token: 0x040001F1 RID: 497
		private Dictionary<int, InteraccionDeCharacter> m_InteraccionParEnID;

		// Token: 0x040001F2 RID: 498
		private Dictionary<Interaccion, InteraccionDeCharacter> m_InteraccionDecharacterDeInteraccion;

		// Token: 0x040001F3 RID: 499
		private Dictionary<int, List<InteraccionDeCharacter>> m_interaccionesDeLayer;

		// Token: 0x040001F4 RID: 500
		private Dictionary<int, Dictionary<int, InteraccionDeCharacter>> m_interaccionesDiccDeLayer;

		// Token: 0x040001F5 RID: 501
		private ICharacter m_character;

		// Token: 0x040001F6 RID: 502
		private IIKUpdater m_updater;

		// Token: 0x02000135 RID: 309
		[Serializable]
		public sealed class InteraccionesParGenerica : InteraccionDeCharacter
		{
			// Token: 0x17000229 RID: 553
			// (get) Token: 0x06000B09 RID: 2825 RVA: 0x00030F1D File Offset: 0x0002F11D
			// (set) Token: 0x06000B0A RID: 2826 RVA: 0x00030F25 File Offset: 0x0002F125
			public override int id
			{
				get
				{
					return this.m_id;
				}
				set
				{
					this.m_id = value;
				}
			}

			// Token: 0x1700022A RID: 554
			// (get) Token: 0x06000B0B RID: 2827 RVA: 0x00030F2E File Offset: 0x0002F12E
			// (set) Token: 0x06000B0C RID: 2828 RVA: 0x00030F36 File Offset: 0x0002F136
			public override int layer
			{
				get
				{
					return this.m_layer;
				}
				set
				{
					this.m_layer = value;
				}
			}

			// Token: 0x04000715 RID: 1813
			[SerializeField]
			private int m_id;

			// Token: 0x04000716 RID: 1814
			[SerializeField]
			private int m_layer;
		}

		// Token: 0x02000136 RID: 310
		[Serializable]
		public sealed class InteraccionesParSegundaria : InteraccionDeCharacter
		{
			// Token: 0x1700022B RID: 555
			// (get) Token: 0x06000B0E RID: 2830 RVA: 0x00030F47 File Offset: 0x0002F147
			// (set) Token: 0x06000B0F RID: 2831 RVA: 0x00030F54 File Offset: 0x0002F154
			public override int id
			{
				get
				{
					return ((InteraccionesBasicasDeMale.InteraccionSegundariaName)this.@enum).GetInteractionID();
				}
				set
				{
					throw new NotSupportedException();
				}
			}

			// Token: 0x1700022C RID: 556
			// (get) Token: 0x06000B10 RID: 2832 RVA: 0x00030F5B File Offset: 0x0002F15B
			// (set) Token: 0x06000B11 RID: 2833 RVA: 0x00030F5E File Offset: 0x0002F15E
			public override int layer
			{
				get
				{
					return 1;
				}
				set
				{
					throw new NotSupportedException();
				}
			}

			// Token: 0x04000717 RID: 1815
			[Tooltip("ID")]
			[SerializeField]
			[EnumID(typeof(InteraccionesBasicasDeMale.InteraccionSegundariaName))]
			private int @enum;
		}

		// Token: 0x02000137 RID: 311
		[Serializable]
		public sealed class InteraccionesParPrimaria : InteraccionDeCharacter
		{
			// Token: 0x1700022D RID: 557
			// (get) Token: 0x06000B13 RID: 2835 RVA: 0x00030F6D File Offset: 0x0002F16D
			// (set) Token: 0x06000B14 RID: 2836 RVA: 0x00030F7A File Offset: 0x0002F17A
			public override int id
			{
				get
				{
					return ((InteraccionesBasicasDeMale.InteraccionPrimariaName)this.@enum).GetInteractionID();
				}
				set
				{
					throw new NotSupportedException();
				}
			}

			// Token: 0x1700022E RID: 558
			// (get) Token: 0x06000B15 RID: 2837 RVA: 0x00030F81 File Offset: 0x0002F181
			// (set) Token: 0x06000B16 RID: 2838 RVA: 0x00030F84 File Offset: 0x0002F184
			public override int layer
			{
				get
				{
					return 0;
				}
				set
				{
					throw new NotSupportedException();
				}
			}

			// Token: 0x04000718 RID: 1816
			[Tooltip("ID")]
			[SerializeField]
			[EnumID(typeof(InteraccionesBasicasDeMale.InteraccionPrimariaName))]
			private int @enum;
		}

		// Token: 0x02000138 RID: 312
		public enum InteraccionPrimariaName
		{
			// Token: 0x0400071A RID: 1818
			None
		}

		// Token: 0x02000139 RID: 313
		public enum InteraccionSegundariaName
		{
			// Token: 0x0400071C RID: 1820
			None,
			// Token: 0x0400071D RID: 1821
			massage_R,
			// Token: 0x0400071E RID: 1822
			finger_R,
			// Token: 0x0400071F RID: 1823
			phone_Cam,
			// Token: 0x04000720 RID: 1824
			camera,
			// Token: 0x04000721 RID: 1825
			[Obsolete("", true)]
			pick_R,
			// Token: 0x04000722 RID: 1826
			grab_R,
			// Token: 0x04000723 RID: 1827
			LockShouldersAndBody
		}
	}
}
