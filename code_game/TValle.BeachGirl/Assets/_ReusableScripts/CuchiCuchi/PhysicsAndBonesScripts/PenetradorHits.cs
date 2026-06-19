using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000F1 RID: 241
	[Serializable]
	public class PenetradorHits : ILimpiarPenisHit, IAñadirPenisHit
	{
		// Token: 0x06000A3D RID: 2621 RVA: 0x000215B4 File Offset: 0x0001F7B4
		internal PenetradorHits()
		{
			this.todos = new List<PenisPartHit>();
			this.m_todosLosCollidersDePenesSet = new HashSet<Collider>();
			this.partesDic = new Dictionary<PenisPart, PenisPartHit>();
		}

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x06000A3E RID: 2622 RVA: 0x000215E8 File Offset: 0x0001F7E8
		public PenisPartHit primero
		{
			get
			{
				if (this.todos.Count == 0)
				{
					return null;
				}
				return this.todos[0];
			}
		}

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06000A3F RID: 2623 RVA: 0x00021605 File Offset: 0x0001F805
		// (set) Token: 0x06000A40 RID: 2624 RVA: 0x0002160D File Offset: 0x0001F80D
		private List<PenisPartHit> todos { get; set; }

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06000A41 RID: 2625 RVA: 0x00021616 File Offset: 0x0001F816
		// (set) Token: 0x06000A42 RID: 2626 RVA: 0x0002161E File Offset: 0x0001F81E
		private Dictionary<PenisPart, PenisPartHit> partesDic { get; set; }

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06000A43 RID: 2627 RVA: 0x00021627 File Offset: 0x0001F827
		public IEnumerable<KeyValuePair<PenisPart, PenisPartHit>> diccEnumerable
		{
			get
			{
				return this.partesDic;
			}
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06000A44 RID: 2628 RVA: 0x0002162F File Offset: 0x0001F82F
		public int cantidadRealDeHitsContraPartes
		{
			get
			{
				return this.m_cantidadRealDeHitsContraPartes;
			}
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x00021637 File Offset: 0x0001F837
		public bool ContainsKey(PenisPart key)
		{
			return this.partesDic.ContainsKey(key);
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x00021645 File Offset: 0x0001F845
		public bool ContainsCollider(Collider peneCollider)
		{
			return this.m_todosLosCollidersDePenesSet.Contains(peneCollider);
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x00021653 File Offset: 0x0001F853
		public void Clear()
		{
			((ILimpiarPenisHit)this).Limpiar();
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06000A48 RID: 2632 RVA: 0x0002165B File Offset: 0x0001F85B
		public bool hayHits
		{
			get
			{
				return this.todos.Count > 0;
			}
		}

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06000A49 RID: 2633 RVA: 0x0002166B File Offset: 0x0001F86B
		public int count
		{
			get
			{
				if (this.todos.Count != this.partesDic.Count)
				{
					throw new InvalidOperationException();
				}
				return this.todos.Count;
			}
		}

		// Token: 0x17000401 RID: 1025
		public PenisPartHit this[PenisPart i]
		{
			get
			{
				PenisPartHit penisPartHit;
				if (this.partesDic.TryGetValue(i, out penisPartHit))
				{
					return penisPartHit;
				}
				return null;
			}
		}

		// Token: 0x17000402 RID: 1026
		public PenisPartHit this[int i]
		{
			get
			{
				if (this.todos.Count >= i + 1)
				{
					return this.todos[i];
				}
				return null;
			}
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x000216D8 File Offset: 0x0001F8D8
		public bool Contiene(Character chara)
		{
			if (chara == null)
			{
				return false;
			}
			for (int i = 0; i < this.todos.Count; i++)
			{
				PenisPartHit penisPartHit = this.todos[i];
				if (penisPartHit.penis.inmediateOwner == chara || penisPartHit.penis.GetRootOwner() == chara)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x00021734 File Offset: 0x0001F934
		public void Remove(PenisPart key)
		{
			PenisPartHit penisPartHit;
			if (this.partesDic.TryGetValue(key, out penisPartHit))
			{
				this.partesDic.Remove(key);
				this.todos.Remove(penisPartHit);
				for (int i = 0; i < key.mainCollider.collidersV2.Count; i++)
				{
					this.m_todosLosCollidersDePenesSet.Remove(key.mainCollider.collidersV2[i]);
				}
				for (int j = 0; j < key.complementoCollider.collidersV2.Count; j++)
				{
					this.m_todosLosCollidersDePenesSet.Remove(key.complementoCollider.collidersV2[j]);
				}
				((ILimpiarPenisHit)penisPartHit).Limpiar();
				this.pool.Enqueue(penisPartHit);
			}
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x000217F0 File Offset: 0x0001F9F0
		public void Remove(IPeneConPartes owner)
		{
			foreach (PenisPart penisPart in owner.enumerator)
			{
				this.Remove(penisPart);
			}
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x00021840 File Offset: 0x0001FA40
		public void ObtenerPenes(IList<IPeneConPartes> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result", "result null reference.");
			}
			if (result.Count > 0)
			{
				result.Clear();
			}
			for (int i = 0; i < this.todos.Count; i++)
			{
				Penetrador penis = this.todos[i].penis;
				if (penis != null && !result.Contains(penis))
				{
					result.Add(penis);
				}
			}
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x000218B0 File Offset: 0x0001FAB0
		public void ObtenerPenes(IList<Penetrador> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result", "result null reference.");
			}
			if (result.Count > 0)
			{
				result.Clear();
			}
			for (int i = 0; i < this.todos.Count; i++)
			{
				Penetrador penis = this.todos[i].penis;
				if (penis != null && !result.Contains(penis))
				{
					result.Add(penis);
				}
			}
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x00021920 File Offset: 0x0001FB20
		void ILimpiarPenisHit.Limpiar()
		{
			this.m_cantidadRealDeHitsContraPartes = 0;
			if (this.partesDic.Count > 0)
			{
				this.partesDic.Clear();
			}
			if (this.todos.Count > 0)
			{
				foreach (PenisPartHit penisPartHit in this.todos)
				{
					((ILimpiarPenisHit)penisPartHit).Limpiar();
					this.pool.Enqueue(penisPartHit);
				}
				this.todos.Clear();
			}
			this.m_todosLosCollidersDePenesSet.Clear();
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x000219C4 File Offset: 0x0001FBC4
		void IAñadirPenisHit.Añadir(Dictionary<PenisPart, RaycastHit> hits, float largoAgujero, int CantidadRealDeHitsContraPartes)
		{
			if (hits.Count == 0)
			{
				throw new InvalidOperationException();
			}
			this.m_cantidadRealDeHitsContraPartes = CantidadRealDeHitsContraPartes;
			foreach (KeyValuePair<PenisPart, RaycastHit> keyValuePair in hits)
			{
				PenisPartHit penisPartHit;
				if (this.Poblar(keyValuePair, largoAgujero, out penisPartHit))
				{
					this.todos.Add(penisPartHit);
					for (int i = 0; i < keyValuePair.Key.mainCollider.collidersV2.Count; i++)
					{
						this.m_todosLosCollidersDePenesSet.Add(keyValuePair.Key.mainCollider.collidersV2[i]);
					}
					for (int j = 0; j < keyValuePair.Key.complementoCollider.collidersV2.Count; j++)
					{
						this.m_todosLosCollidersDePenesSet.Add(keyValuePair.Key.complementoCollider.collidersV2[j]);
					}
				}
			}
			this.todos.Sort((PenisPartHit a, PenisPartHit b) => a.hit.Value.distance.CompareTo(b.hit.Value.distance));
			for (int k = 0; k < this.todos.Count; k++)
			{
				PenisPartHit penisPartHit2 = this.todos[k];
				try
				{
					this.partesDic.Add(penisPartHit2.penisPart, penisPartHit2);
				}
				catch (Exception ex)
				{
					Debug.LogError(ex);
					throw ex;
				}
			}
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x00021B4C File Offset: 0x0001FD4C
		private bool Poblar(KeyValuePair<PenisPart, RaycastHit> h, float largoAgujero, out PenisPartHit resultado)
		{
			resultado = this.Get();
			return ((IPoblarPenisHit)resultado).Poblar(h.Value, h.Key, largoAgujero);
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x00021B6C File Offset: 0x0001FD6C
		private PenisPartHit Get()
		{
			if (this.pool.Count == 0)
			{
				return new PenisPartHit();
			}
			return this.pool.Dequeue();
		}

		// Token: 0x04000579 RID: 1401
		private int m_cantidadRealDeHitsContraPartes;

		// Token: 0x0400057B RID: 1403
		private HashSet<Collider> m_todosLosCollidersDePenesSet;

		// Token: 0x0400057D RID: 1405
		private Queue<PenisPartHit> pool = new Queue<PenisPartHit>();
	}
}
