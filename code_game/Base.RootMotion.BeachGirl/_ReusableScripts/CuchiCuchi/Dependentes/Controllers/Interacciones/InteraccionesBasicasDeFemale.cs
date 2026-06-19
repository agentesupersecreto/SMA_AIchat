using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000EB RID: 235
	public sealed class InteraccionesBasicasDeFemale : CustomUpdatedMonobehaviourBase, IInteraccionesDeCharacterFemenino, IInteraccionesDeCharacter<InteraccionDeCharacterFemenino>, IInteraccionesDeCharacter, IComponentAwakeable
	{
		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000890 RID: 2192 RVA: 0x00026E80 File Offset: 0x00025080
		public IReadOnlyList<InteraccionDeCharacter> interaccionesBases
		{
			get
			{
				return this.interacciones;
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000891 RID: 2193 RVA: 0x00026E88 File Offset: 0x00025088
		public IReadOnlyList<InteraccionDeCharacterFemenino> interacciones
		{
			get
			{
				return this.m_interaccionesDeFemale;
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000892 RID: 2194 RVA: 0x00026E90 File Offset: 0x00025090
		public IReadOnlyList<InteraccionDeCharacterFemenino> interaccionesPrimarias
		{
			get
			{
				return this.m_AddedPrimarias;
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000893 RID: 2195 RVA: 0x00026E98 File Offset: 0x00025098
		public IReadOnlyList<InteraccionDeCharacterFemenino> interaccionesSegundarias
		{
			get
			{
				return this.m_AddedSegundarias;
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000894 RID: 2196 RVA: 0x00026EA0 File Offset: 0x000250A0
		public IReadOnlyList<InteraccionDeCharacter> interaccionesPrimariasBases
		{
			get
			{
				return this.interaccionesPrimarias;
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000895 RID: 2197 RVA: 0x00026EA8 File Offset: 0x000250A8
		public IReadOnlyList<InteraccionDeCharacter> interaccionesSegundariasBases
		{
			get
			{
				return this.interaccionesSegundarias;
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000896 RID: 2198 RVA: 0x00026EB0 File Offset: 0x000250B0
		public IReadOnlyDictionary<int, InteraccionDeCharacterFemenino> interaccionPrimariaDeID
		{
			get
			{
				return this.m_interaccionesDiccDeLayer[0];
			}
		}

		// Token: 0x14000074 RID: 116
		// (add) Token: 0x06000897 RID: 2199 RVA: 0x00026EC0 File Offset: 0x000250C0
		// (remove) Token: 0x06000898 RID: 2200 RVA: 0x00026EF8 File Offset: 0x000250F8
		public event Action<InteraccionDeCharacter> comenzada;

		// Token: 0x14000075 RID: 117
		// (add) Token: 0x06000899 RID: 2201 RVA: 0x00026F30 File Offset: 0x00025130
		// (remove) Token: 0x0600089A RID: 2202 RVA: 0x00026F68 File Offset: 0x00025168
		public event Action<InteraccionDeCharacter> terminada;

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x0600089B RID: 2203 RVA: 0x00026F9D File Offset: 0x0002519D
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

		// Token: 0x0600089C RID: 2204 RVA: 0x00026FBC File Offset: 0x000251BC
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			ICharacter character = this.character;
			this.m_poseController = this.GetComponentEnRoot(false);
			this.m_updater = this.GetComponentEnRoot(false);
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
			}
			this.UpdateListas();
			foreach (InteraccionesBasicasDeFemale.InteraccionesParPrimaria interaccionesParPrimaria in this.m_ListaDePrimarias)
			{
				InteraccionAddingEvents instancia = interaccionesParPrimaria.instancia;
				if (instancia != null)
				{
					instancia.AddedTo(this);
				}
			}
			foreach (InteraccionesBasicasDeFemale.InteraccionesParSegundaria interaccionesParSegundaria in this.m_ListaDeSegundarias)
			{
				InteraccionAddingEvents instancia2 = interaccionesParSegundaria.instancia;
				if (instancia2 != null)
				{
					instancia2.AddedTo(this);
				}
			}
			if (this.m_rootsDeInteracionesPorLayer.Count == 0)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x000270BC File Offset: 0x000252BC
		public void UpdateListas()
		{
			this.m_interaccionesDeFemale = new List<InteraccionDeCharacterFemenino>();
			this.m_InteraccionEnID = new Dictionary<int, InteraccionDeCharacterFemenino>();
			this.m_InteraccionDecharacterDeInteraccion = new Dictionary<Interaccion, InteraccionDeCharacter>();
			this.m_interaccionesDeLayer = new Dictionary<int, List<InteraccionDeCharacterFemenino>>();
			this.m_interaccionesDiccDeLayer = new Dictionary<int, Dictionary<int, InteraccionDeCharacterFemenino>>();
			for (int i = this.m_AddedPrimarias.Count - 1; i >= 0; i--)
			{
				if (this.m_AddedPrimarias[i] == null || this.m_AddedPrimarias[i].instancia == null || this.m_AddedPrimarias[i] is InteraccionesBasicasDeFemale.InteraccionesParPrimaria || this.m_AddedPrimarias[i] is InteraccionesBasicasDeFemale.InteraccionesParSegundaria)
				{
					this.m_AddedPrimarias.RemoveAt(i);
				}
			}
			for (int j = this.m_AddedSegundarias.Count - 1; j >= 0; j--)
			{
				if (this.m_AddedSegundarias[j] == null || this.m_AddedSegundarias[j].instancia == null || this.m_AddedSegundarias[j] is InteraccionesBasicasDeFemale.InteraccionesParPrimaria || this.m_AddedSegundarias[j] is InteraccionesBasicasDeFemale.InteraccionesParSegundaria)
				{
					this.m_AddedSegundarias.RemoveAt(j);
				}
			}
			foreach (InteraccionesBasicasDeFemale.InteraccionesParPrimaria interaccionesParPrimaria in this.m_ListaDePrimarias)
			{
				if (interaccionesParPrimaria.instancia == null)
				{
					throw new ArgumentNullException("item.instancia", "item.instancia null reference.");
				}
				try
				{
					this.m_AddedPrimarias.Add(interaccionesParPrimaria);
				}
				catch (Exception)
				{
					throw;
				}
			}
			foreach (InteraccionesBasicasDeFemale.InteraccionesParSegundaria interaccionesParSegundaria in this.m_ListaDeSegundarias)
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
			this.m_interaccionesDeLayer.Add(0, this.m_AddedPrimarias);
			this.m_interaccionesDeLayer.Add(1, this.m_AddedSegundarias);
			this.m_interaccionesDeLayer.Add(2, this.m_AddedTerciarias);
			this.m_interaccionesDeLayer.Add(3, this.m_AddedCuaternarias);
			this.m_interaccionesDiccDeLayer.Add(0, new Dictionary<int, InteraccionDeCharacterFemenino>());
			this.m_interaccionesDiccDeLayer.Add(1, new Dictionary<int, InteraccionDeCharacterFemenino>());
			this.m_interaccionesDiccDeLayer.Add(2, new Dictionary<int, InteraccionDeCharacterFemenino>());
			this.m_interaccionesDiccDeLayer.Add(3, new Dictionary<int, InteraccionDeCharacterFemenino>());
			foreach (InteraccionDeCharacterFemenino interaccionDeCharacterFemenino in this.m_AddedPrimarias)
			{
				this.m_interaccionesDeFemale.Add(interaccionDeCharacterFemenino);
				if (this.m_InteraccionEnID.ContainsKey(interaccionDeCharacterFemenino.id))
				{
					Debug.LogWarning(string.Concat(new string[]
					{
						"interaccion: ",
						interaccionDeCharacterFemenino.instancia.name,
						" con id: ",
						interaccionDeCharacterFemenino.id.ToString(),
						", repetida."
					}), interaccionDeCharacterFemenino.instancia);
				}
				else
				{
					this.m_InteraccionEnID.Add(interaccionDeCharacterFemenino.id, interaccionDeCharacterFemenino);
					this.m_InteraccionDecharacterDeInteraccion.Add(interaccionDeCharacterFemenino.instancia, interaccionDeCharacterFemenino);
					interaccionDeCharacterFemenino.instancia.comenzada += this.Interaccion_comenzada;
					interaccionDeCharacterFemenino.instancia.terminada += this.Interaccion_terminada;
					this.m_interaccionesDiccDeLayer[0].Add(interaccionDeCharacterFemenino.id, interaccionDeCharacterFemenino);
				}
			}
			foreach (InteraccionDeCharacterFemenino interaccionDeCharacterFemenino2 in this.m_AddedSegundarias)
			{
				this.m_interaccionesDeFemale.Add(interaccionDeCharacterFemenino2);
				if (this.m_InteraccionEnID.ContainsKey(interaccionDeCharacterFemenino2.id))
				{
					Debug.LogWarning(string.Concat(new string[]
					{
						"interaccion: ",
						interaccionDeCharacterFemenino2.instancia.name,
						" con id: ",
						interaccionDeCharacterFemenino2.id.ToString(),
						", repetida."
					}), interaccionDeCharacterFemenino2.instancia);
				}
				else
				{
					this.m_InteraccionEnID.Add(interaccionDeCharacterFemenino2.id, interaccionDeCharacterFemenino2);
					this.m_InteraccionDecharacterDeInteraccion.Add(interaccionDeCharacterFemenino2.instancia, interaccionDeCharacterFemenino2);
					interaccionDeCharacterFemenino2.instancia.comenzada += this.Interaccion_comenzada;
					interaccionDeCharacterFemenino2.instancia.terminada += this.Interaccion_terminada;
					this.m_interaccionesDiccDeLayer[1].Add(interaccionDeCharacterFemenino2.id, interaccionDeCharacterFemenino2);
				}
			}
			foreach (InteraccionDeCharacterFemenino interaccionDeCharacterFemenino3 in this.m_AddedTerciarias)
			{
				this.m_interaccionesDeFemale.Add(interaccionDeCharacterFemenino3);
				if (this.m_InteraccionEnID.ContainsKey(interaccionDeCharacterFemenino3.id))
				{
					Debug.LogWarning(string.Concat(new string[]
					{
						"interaccion: ",
						interaccionDeCharacterFemenino3.instancia.name,
						" con id: ",
						interaccionDeCharacterFemenino3.id.ToString(),
						", repetida."
					}), interaccionDeCharacterFemenino3.instancia);
				}
				else
				{
					this.m_InteraccionEnID.Add(interaccionDeCharacterFemenino3.id, interaccionDeCharacterFemenino3);
					this.m_InteraccionDecharacterDeInteraccion.Add(interaccionDeCharacterFemenino3.instancia, interaccionDeCharacterFemenino3);
					interaccionDeCharacterFemenino3.instancia.comenzada += this.Interaccion_comenzada;
					interaccionDeCharacterFemenino3.instancia.terminada += this.Interaccion_terminada;
					this.m_interaccionesDiccDeLayer[2].Add(interaccionDeCharacterFemenino3.id, interaccionDeCharacterFemenino3);
				}
			}
			foreach (InteraccionDeCharacterFemenino interaccionDeCharacterFemenino4 in this.m_AddedCuaternarias)
			{
				this.m_interaccionesDeFemale.Add(interaccionDeCharacterFemenino4);
				if (this.m_InteraccionEnID.ContainsKey(interaccionDeCharacterFemenino4.id))
				{
					Debug.LogWarning(string.Concat(new string[]
					{
						"interaccion: ",
						interaccionDeCharacterFemenino4.instancia.name,
						" con id: ",
						interaccionDeCharacterFemenino4.id.ToString(),
						", repetida."
					}), interaccionDeCharacterFemenino4.instancia);
				}
				else
				{
					this.m_InteraccionEnID.Add(interaccionDeCharacterFemenino4.id, interaccionDeCharacterFemenino4);
					this.m_InteraccionDecharacterDeInteraccion.Add(interaccionDeCharacterFemenino4.instancia, interaccionDeCharacterFemenino4);
					interaccionDeCharacterFemenino4.instancia.comenzada += this.Interaccion_comenzada;
					interaccionDeCharacterFemenino4.instancia.terminada += this.Interaccion_terminada;
					this.m_interaccionesDiccDeLayer[3].Add(interaccionDeCharacterFemenino4.id, interaccionDeCharacterFemenino4);
				}
			}
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x00027868 File Offset: 0x00025A68
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			foreach (InteraccionDeCharacterFemenino interaccionDeCharacterFemenino in this.m_interaccionesDeFemale)
			{
				InteraccionDeCharacterFemenino par = interaccionDeCharacterFemenino;
				if (par != null && par.setInitial)
				{
					GlobalUpdater.instancia.Invokar(delegate
					{
						par.instancia.Ejecutar(1, -1f, ControllerPrioridadConfig.prioridad, 1f, 1f, false);
					}, 2f);
				}
			}
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x000278F8 File Offset: 0x00025AF8
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

		// Token: 0x060008A0 RID: 2208 RVA: 0x00027950 File Offset: 0x00025B50
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			foreach (InteraccionDeCharacterFemenino interaccionDeCharacterFemenino in this.m_interaccionesDeFemale)
			{
				Interaccion instancia = interaccionDeCharacterFemenino.instancia;
				if (!(instancia == null))
				{
					instancia.comenzada -= this.Interaccion_comenzada;
					instancia.terminada -= this.Interaccion_terminada;
				}
			}
			foreach (InteraccionesBasicasDeFemale.InteraccionesParPrimaria interaccionesParPrimaria in this.m_ListaDePrimarias)
			{
				InteraccionAddingEvents instancia2 = interaccionesParPrimaria.instancia;
				if (instancia2 != null)
				{
					instancia2.RemovingFrom(this);
					instancia2.RemovedFrom(this);
				}
			}
			foreach (InteraccionesBasicasDeFemale.InteraccionesParSegundaria interaccionesParSegundaria in this.m_ListaDeSegundarias)
			{
				InteraccionAddingEvents instancia3 = interaccionesParSegundaria.instancia;
				if (instancia3 != null)
				{
					instancia3.RemovingFrom(this);
					instancia3.RemovedFrom(this);
				}
			}
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x00027A7C File Offset: 0x00025C7C
		public bool TryAddInteraction(int id, Interaccion interaccion)
		{
			return this.TryAddInteraction(id, interaccion, TipoDePose.None);
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x00027A88 File Offset: 0x00025C88
		public bool TryAddInteraction(int id, Interaccion interaccion, TipoDePose invalidas)
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
					Dictionary<int, InteraccionDeCharacterFemenino> interaccionEnID = this.m_InteraccionEnID;
					if (interaccionEnID.ContainsKey(id))
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
						List<InteraccionDeCharacterFemenino> list;
						if (this.m_interaccionesDeLayer.ContainsKey(interactionLayer))
						{
							list = this.m_interaccionesDeLayer[interactionLayer];
						}
						else
						{
							list = new List<InteraccionDeCharacterFemenino>();
							this.m_interaccionesDeLayer.Add(interactionLayer, list);
						}
						InteraccionesBasicasDeFemale.InteraccionesParGenerica interaccionesParGenerica = new InteraccionesBasicasDeFemale.InteraccionesParGenerica();
						interaccionesParGenerica.id = id;
						interaccionesParGenerica.layer = interactionLayer;
						interaccionesParGenerica.instancia = interaccion;
						interaccionesParGenerica.posesNoValidas = invalidas;
						interaccionesParGenerica.setInitial = false;
						list.Add(interaccionesParGenerica);
						interaccionEnID.Add(id, interaccionesParGenerica);
						this.m_InteraccionDecharacterDeInteraccion.Add(interaccion, interaccionesParGenerica);
						if (this.m_interaccionesDiccDeLayer.ContainsKey(interactionLayer))
						{
							this.m_interaccionesDiccDeLayer[interactionLayer].Add(id, interaccionesParGenerica);
						}
						else
						{
							this.m_interaccionesDiccDeLayer.Add(interactionLayer, new Dictionary<int, InteraccionDeCharacterFemenino> { { id, interaccionesParGenerica } });
						}
						this.m_interaccionesDeFemale.Add(interaccionesParGenerica);
						interaccion.comenzada += this.Interaccion_comenzada;
						interaccion.terminada += this.Interaccion_terminada;
						((InteraccionAddingEvents)interaccion).AddedTo(this);
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

		// Token: 0x060008A3 RID: 2211 RVA: 0x00027C4C File Offset: 0x00025E4C
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

		// Token: 0x060008A4 RID: 2212 RVA: 0x00027CA4 File Offset: 0x00025EA4
		private void Interaccion_terminada(Interaccion obj)
		{
			InteraccionDeCharacter interaccionDeCharacter;
			if (this.m_InteraccionDecharacterDeInteraccion.TryGetValue(obj, out interaccionDeCharacter))
			{
				Action<InteraccionDeCharacter> action = this.terminada;
				if (action == null)
				{
					return;
				}
				action(interaccionDeCharacter);
			}
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x00027CD4 File Offset: 0x00025ED4
		public bool TryRemoveInteraction(int id)
		{
			bool flag2;
			try
			{
				Dictionary<int, InteraccionDeCharacterFemenino> interaccionEnID = this.m_InteraccionEnID;
				if ((Application.isEditor || Debug.isDebugBuild) && interaccionEnID.ContainsKey(id) && this.EstaEjecutandose(id))
				{
					Debug.LogWarning("Se esta intando remover una interaccion primaria de id: " + id.ToString() + ", al esta estarse ejecutando , talvez se generen problemas.");
				}
				InteraccionDeCharacterFemenino interaccionDeCharacterFemenino;
				bool flag;
				if (interaccionEnID.TryGetValue(id, out interaccionDeCharacterFemenino))
				{
					flag = true;
					interaccionEnID.Remove(id);
				}
				else
				{
					flag = false;
				}
				if (flag)
				{
					List<InteraccionDeCharacterFemenino> list = this.m_interaccionesDeLayer[interaccionDeCharacterFemenino.layer];
					for (int i = list.Count - 1; i >= 0; i--)
					{
						InteraccionDeCharacterFemenino interaccionDeCharacterFemenino2 = list[i];
						if (interaccionDeCharacterFemenino2.id == id)
						{
							Interaccion instancia = interaccionDeCharacterFemenino2.instancia;
							if (instancia != null)
							{
								((InteraccionAddingEvents)instancia).RemovingFrom(this);
							}
						}
					}
				}
				Dictionary<int, InteraccionDeCharacterFemenino> dictionary;
				if (this.m_interaccionesDiccDeLayer.TryGetValue(interaccionDeCharacterFemenino.layer, out dictionary))
				{
					flag = true;
					dictionary.Remove(id);
				}
				else
				{
					flag = flag;
				}
				if (((interaccionDeCharacterFemenino != null) ? interaccionDeCharacterFemenino.instancia : null) != null)
				{
					this.m_InteraccionDecharacterDeInteraccion.Remove(interaccionDeCharacterFemenino.instancia);
				}
				for (int j = this.m_interaccionesDeFemale.Count - 1; j >= 0; j--)
				{
					if (this.m_interaccionesDeFemale[j].id == id)
					{
						this.m_interaccionesDeFemale.RemoveAt(j);
					}
				}
				if (flag)
				{
					List<InteraccionDeCharacterFemenino> list2 = this.m_interaccionesDeLayer[interaccionDeCharacterFemenino.layer];
					this.m_interaccionesDiccDeLayer[interaccionDeCharacterFemenino.layer].Remove(id);
					for (int k = list2.Count - 1; k >= 0; k--)
					{
						InteraccionDeCharacterFemenino interaccionDeCharacterFemenino3 = list2[k];
						if (interaccionDeCharacterFemenino3.id == id)
						{
							list2.RemoveAt(k);
							Interaccion instancia2 = interaccionDeCharacterFemenino3.instancia;
							if (instancia2 != null)
							{
								((InteraccionAddingEvents)instancia2).RemovedFrom(this);
							}
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

		// Token: 0x060008A6 RID: 2214 RVA: 0x00027EB8 File Offset: 0x000260B8
		public bool Ejecutandose(InteraccionPrimariaName @enum, out Interaccion ejecutandose)
		{
			return this.EstaEjecutandose(@enum.GetInteractionID(), out ejecutandose);
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x00027EC7 File Offset: 0x000260C7
		public bool Ejecutandose(InteraccionSegundariaName @enum, out Interaccion ejecutandose)
		{
			return this.EstaEjecutandose(@enum.GetInteractionID(), out ejecutandose);
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x00027ED8 File Offset: 0x000260D8
		public bool EstaEjecutandose(InteraccionPrimariaName @enum)
		{
			Interaccion interaccion;
			return this.Ejecutandose(@enum, out interaccion);
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x00027EF0 File Offset: 0x000260F0
		public bool EstaEjecutandose(InteraccionSegundariaName @enum)
		{
			Interaccion interaccion;
			return this.Ejecutandose(@enum, out interaccion);
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x00027F08 File Offset: 0x00026108
		public bool EstaEjecutandose(int id)
		{
			Interaccion interaccion;
			return this.EstaEjecutandose(id, out interaccion);
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x00027F20 File Offset: 0x00026120
		public bool EstaEjecutandose(int id, out Interaccion ejecutandose)
		{
			bool flag;
			try
			{
				ejecutandose = null;
				InteraccionDeCharacterFemenino interaccionDeCharacterFemenino;
				if (!this.m_InteraccionEnID.TryGetValue(id, out interaccionDeCharacterFemenino))
				{
					flag = false;
				}
				else
				{
					ejecutandose = interaccionDeCharacterFemenino.instancia;
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

		// Token: 0x060008AC RID: 2220 RVA: 0x00027F70 File Offset: 0x00026170
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
					List<InteraccionDeCharacterFemenino> list = this.m_interaccionesDeLayer[0];
					for (int i = 0; i < list.Count; i++)
					{
						InteraccionDeCharacterFemenino interaccionDeCharacterFemenino = list[i];
						if (interaccionDeCharacterFemenino.instancia.ejecutandose)
						{
							return interaccionDeCharacterFemenino;
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

		// Token: 0x060008AD RID: 2221 RVA: 0x00027FE4 File Offset: 0x000261E4
		public void ObtenerEjecutandosePrimaria(IList<InteraccionDeCharacter> result)
		{
			try
			{
				if (this.m_interaccionesDeLayer.ContainsKey(0))
				{
					IReadOnlyList<Component> readOnlyList = this.m_updater.SortedIKsDeLayer(0);
					List<InteraccionDeCharacterFemenino> list = this.m_interaccionesDeLayer[0];
					for (int i = 0; i < readOnlyList.Count; i++)
					{
						int num = this.m_updater.IDDeIK(readOnlyList[i]);
						for (int j = 0; j < list.Count; j++)
						{
							InteraccionDeCharacterFemenino interaccionDeCharacterFemenino = list[j];
							if (interaccionDeCharacterFemenino.instancia.ejecutandose && interaccionDeCharacterFemenino.instancia.lastInteractionSystemID == num)
							{
								result.Add(interaccionDeCharacterFemenino);
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

		// Token: 0x060008AE RID: 2222 RVA: 0x000280A0 File Offset: 0x000262A0
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
					List<InteraccionDeCharacterFemenino> list = this.m_interaccionesDeLayer[0];
					for (int i = 0; i < readOnlyList.Count; i++)
					{
						int num = this.m_updater.IDDeIK(readOnlyList[i]);
						for (int j = 0; j < list.Count; j++)
						{
							InteraccionDeCharacterFemenino interaccionDeCharacterFemenino = list[j];
							if (interaccionDeCharacterFemenino.instancia.ejecutandose && interaccionDeCharacterFemenino.instancia.lastInteractionSystemID == num)
							{
								return interaccionDeCharacterFemenino;
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

		// Token: 0x060008AF RID: 2223 RVA: 0x00028160 File Offset: 0x00026360
		public bool EsValidaParaCurrentAnimControllerBase(InteraccionDeCharacter interaccionPar)
		{
			InteraccionDeCharacterFemenino interaccionDeCharacterFemenino = interaccionPar as InteraccionDeCharacterFemenino;
			return interaccionDeCharacterFemenino != null && this.EsValidaParaCurrentAnimController(interaccionDeCharacterFemenino);
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x00028180 File Offset: 0x00026380
		public bool EsValidaParaCurrentAnimController(InteraccionDeCharacterFemenino interaccionPar)
		{
			int currentPose = (int)this.m_poseController.currentPose;
			return !((int)interaccionPar.posesNoValidas).HasFlag(currentPose);
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x000281A8 File Offset: 0x000263A8
		public bool TryObtenerSiEsValida(InteraccionPrimariaName @enum, out Interaccion interaccion)
		{
			return this.TryObtenerSiEsValida(@enum.GetInteractionID(), out interaccion);
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x000281B7 File Offset: 0x000263B7
		public bool TryObtenerSiEsValida(InteraccionSegundariaName @enum, out Interaccion interaccion)
		{
			return this.TryObtenerSiEsValida(@enum.GetInteractionID(), out interaccion);
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x000281C8 File Offset: 0x000263C8
		public bool TryObtenerSiEsValida(int id, out Interaccion interaccion)
		{
			interaccion = null;
			InteraccionDeCharacterFemenino interaccionDeCharacterFemenino;
			bool flag = this.TryObtenerSiEsValida(id, out interaccionDeCharacterFemenino);
			if (interaccionDeCharacterFemenino != null)
			{
				interaccion = interaccionDeCharacterFemenino.instancia;
			}
			return flag;
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x000281EC File Offset: 0x000263EC
		public bool TryObtenerSiEsValida(int id, out InteraccionDeCharacterFemenino interaccionDeCharacter)
		{
			bool flag;
			try
			{
				interaccionDeCharacter = null;
				InteraccionDeCharacterFemenino interaccionDeCharacterFemenino;
				if (!this.m_InteraccionEnID.TryGetValue(id, out interaccionDeCharacterFemenino))
				{
					flag = false;
				}
				else if (this.m_poseController == null)
				{
					interaccionDeCharacter = interaccionDeCharacterFemenino;
					flag = true;
				}
				else
				{
					interaccionDeCharacter = interaccionDeCharacterFemenino;
					flag = this.EsValidaParaCurrentAnimController(interaccionDeCharacterFemenino);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				throw ex;
			}
			return flag;
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x0002824C File Offset: 0x0002644C
		public bool ContieneAndIsValido(int id)
		{
			InteraccionDeCharacterFemenino interaccionDeCharacterFemenino;
			return this.m_InteraccionEnID.TryGetValue(id, out interaccionDeCharacterFemenino) && (this.m_poseController == null || this.EsValidaParaCurrentAnimController(interaccionDeCharacterFemenino));
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x00028282 File Offset: 0x00026482
		public InteraccionDeCharacter ObtenerBase(int id)
		{
			return this.Obtener(id);
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x0002828C File Offset: 0x0002648C
		public InteraccionDeCharacterFemenino Obtener(int id)
		{
			InteraccionDeCharacterFemenino interaccionDeCharacterFemenino;
			if (!this.m_InteraccionEnID.TryGetValue(id, out interaccionDeCharacterFemenino))
			{
				return null;
			}
			return interaccionDeCharacterFemenino;
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x000282AC File Offset: 0x000264AC
		public bool Contiene(int id)
		{
			InteraccionDeCharacterFemenino interaccionDeCharacterFemenino;
			if (!this.m_InteraccionEnID.TryGetValue(id, out interaccionDeCharacterFemenino))
			{
				return false;
			}
			if (interaccionDeCharacterFemenino.instancia.owner != this)
			{
				Object @object = interaccionDeCharacterFemenino.instancia.owner as Object;
				Debug.LogError(string.Concat(new string[]
				{
					"Interaccion de id: ",
					id.ToString(),
					" estaba añadida pero el owner no era ",
					base.name,
					" si no ",
					new ValueTuple<string, InteraccionesBasicasDeFemale>(@object ? @object.name : "NULL", this).ToString()
				}));
				this.TryRemoveInteraction(id);
				return false;
			}
			return true;
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x00028360 File Offset: 0x00026560
		public void GetEjecutandose(int layer, IList<InteraccionDeCharacter> ejecutandose)
		{
			List<InteraccionDeCharacterFemenino> list;
			if (!this.m_interaccionesDeLayer.TryGetValue(layer, out list))
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				InteraccionDeCharacterFemenino interaccionDeCharacterFemenino = list[i];
				if (this.EstaEjecutandose(interaccionDeCharacterFemenino.id))
				{
					ejecutandose.Add(interaccionDeCharacterFemenino);
				}
			}
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x0002840C File Offset: 0x0002660C
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x00028414 File Offset: 0x00026614
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x04000589 RID: 1417
		[SerializeField]
		[CoolArrayItem]
		private List<Transform> m_rootsDeInteracionesPorLayer = new List<Transform>();

		// Token: 0x0400058A RID: 1418
		[Header("Interacciones Estaticas")]
		[CoolArrayItem]
		[SerializeField]
		private List<InteraccionesBasicasDeFemale.InteraccionesParPrimaria> m_ListaDePrimarias = new List<InteraccionesBasicasDeFemale.InteraccionesParPrimaria>();

		// Token: 0x0400058B RID: 1419
		[CoolArrayItem]
		[SerializeField]
		private List<InteraccionesBasicasDeFemale.InteraccionesParSegundaria> m_ListaDeSegundarias = new List<InteraccionesBasicasDeFemale.InteraccionesParSegundaria>();

		// Token: 0x0400058C RID: 1420
		[Header("Read Only")]
		[ReadOnlyUI]
		[CoolArrayItem(removable = false, reorderable = false)]
		[SerializeField]
		private List<InteraccionDeCharacterFemenino> m_AddedPrimarias = new List<InteraccionDeCharacterFemenino>();

		// Token: 0x0400058D RID: 1421
		[ReadOnlyUI]
		[CoolArrayItem(removable = false, reorderable = false)]
		[SerializeField]
		private List<InteraccionDeCharacterFemenino> m_AddedSegundarias = new List<InteraccionDeCharacterFemenino>();

		// Token: 0x0400058E RID: 1422
		[ReadOnlyUI]
		[CoolArrayItem(removable = false, reorderable = false)]
		[SerializeField]
		private List<InteraccionDeCharacterFemenino> m_AddedTerciarias = new List<InteraccionDeCharacterFemenino>();

		// Token: 0x0400058F RID: 1423
		[ReadOnlyUI]
		[CoolArrayItem(removable = false, reorderable = false)]
		[SerializeField]
		private List<InteraccionDeCharacterFemenino> m_AddedCuaternarias = new List<InteraccionDeCharacterFemenino>();

		// Token: 0x04000590 RID: 1424
		private List<InteraccionDeCharacterFemenino> m_interaccionesDeFemale;

		// Token: 0x04000591 RID: 1425
		private Dictionary<int, InteraccionDeCharacterFemenino> m_InteraccionEnID;

		// Token: 0x04000592 RID: 1426
		private Dictionary<Interaccion, InteraccionDeCharacter> m_InteraccionDecharacterDeInteraccion;

		// Token: 0x04000593 RID: 1427
		private Dictionary<int, List<InteraccionDeCharacterFemenino>> m_interaccionesDeLayer;

		// Token: 0x04000594 RID: 1428
		private Dictionary<int, Dictionary<int, InteraccionDeCharacterFemenino>> m_interaccionesDiccDeLayer;

		// Token: 0x04000595 RID: 1429
		private AnimController m_poseController;

		// Token: 0x04000596 RID: 1430
		private ICharacter m_character;

		// Token: 0x04000597 RID: 1431
		private IIKUpdater m_updater;

		// Token: 0x020001BA RID: 442
		[Serializable]
		public sealed class InteraccionesParGenerica : InteraccionDeCharacterFemenino
		{
			// Token: 0x17000273 RID: 627
			// (get) Token: 0x06000CE0 RID: 3296 RVA: 0x000395A5 File Offset: 0x000377A5
			// (set) Token: 0x06000CE1 RID: 3297 RVA: 0x000395AD File Offset: 0x000377AD
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

			// Token: 0x17000274 RID: 628
			// (get) Token: 0x06000CE2 RID: 3298 RVA: 0x000395B6 File Offset: 0x000377B6
			// (set) Token: 0x06000CE3 RID: 3299 RVA: 0x000395BE File Offset: 0x000377BE
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

			// Token: 0x040009B6 RID: 2486
			[SerializeField]
			private int m_id;

			// Token: 0x040009B7 RID: 2487
			[SerializeField]
			private int m_layer;
		}

		// Token: 0x020001BB RID: 443
		[Serializable]
		public sealed class InteraccionesParSegundaria : InteraccionDeCharacterFemenino
		{
			// Token: 0x17000275 RID: 629
			// (get) Token: 0x06000CE5 RID: 3301 RVA: 0x000395CF File Offset: 0x000377CF
			// (set) Token: 0x06000CE6 RID: 3302 RVA: 0x000395DC File Offset: 0x000377DC
			public override int id
			{
				get
				{
					return ((InteraccionSegundariaName)this.@enum).GetInteractionID();
				}
				set
				{
					throw new NotSupportedException();
				}
			}

			// Token: 0x17000276 RID: 630
			// (get) Token: 0x06000CE7 RID: 3303 RVA: 0x000395E3 File Offset: 0x000377E3
			// (set) Token: 0x06000CE8 RID: 3304 RVA: 0x000395E6 File Offset: 0x000377E6
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

			// Token: 0x040009B8 RID: 2488
			[Tooltip("ID")]
			[SerializeField]
			[EnumID(typeof(InteraccionSegundariaName))]
			private int @enum;
		}

		// Token: 0x020001BC RID: 444
		[Serializable]
		public sealed class InteraccionesParPrimaria : InteraccionDeCharacterFemenino
		{
			// Token: 0x17000277 RID: 631
			// (get) Token: 0x06000CEA RID: 3306 RVA: 0x000395F5 File Offset: 0x000377F5
			// (set) Token: 0x06000CEB RID: 3307 RVA: 0x00039602 File Offset: 0x00037802
			public override int id
			{
				get
				{
					return ((InteraccionPrimariaName)this.@enum).GetInteractionID();
				}
				set
				{
					throw new NotSupportedException();
				}
			}

			// Token: 0x17000278 RID: 632
			// (get) Token: 0x06000CEC RID: 3308 RVA: 0x00039609 File Offset: 0x00037809
			// (set) Token: 0x06000CED RID: 3309 RVA: 0x0003960C File Offset: 0x0003780C
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

			// Token: 0x040009B9 RID: 2489
			[Tooltip("ID")]
			[SerializeField]
			[EnumID(typeof(InteraccionPrimariaName))]
			private int @enum;
		}
	}
}
