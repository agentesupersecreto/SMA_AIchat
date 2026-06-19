using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Productos.Juegos.Reception.Scripts;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Tiempo;
using Assets._ReusableScripts.Scenes;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Oficinas
{
	// Token: 0x02000092 RID: 146
	public class OficinaManager : Singleton<OficinaManager>
	{
		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00022033 File Offset: 0x00020233
		public IReadOnlyList<OficinaManager.OficinaScenes> oficinas
		{
			get
			{
				return this.m_oficinaScenes;
			}
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0002203C File Offset: 0x0002023C
		protected override void Awaking()
		{
			base.Awaking();
			List<OficinaManager.OficinaScenes> list = this.m_oficinaScenes.ToList<OficinaManager.OficinaScenes>();
			int num = this.m_oficinaScenes.Max((OficinaManager.OficinaScenes o) => o.oficinaLvl);
			List<int> list2 = new List<int>();
			this.m_oficinaScenes = new OficinaManager.OficinaScenes[num + 1];
			HashSet<ValueTuple<int, int, int>> hashSet = new HashSet<ValueTuple<int, int, int>>();
			for (int i = 0; i < list.Count; i++)
			{
				OficinaManager.OficinaScenes oficinaScenes = list[i];
				if (!oficinaScenes.isValid)
				{
					Debug.LogError("officina scene data at index " + i.ToString() + " es invalida", this);
				}
				else if (!hashSet.Add(oficinaScenes.key))
				{
					Debug.LogError("officina scene data repetida en index: " + i.ToString(), this);
				}
				else
				{
					this.m_oficinaScenes[oficinaScenes.oficinaLvl] = oficinaScenes;
					list2.AddRange(oficinaScenes.lightingAndGeometricsScenes.Select((OficinaManager.LightingAndGeometricsScenes p) => (int)p.lightingAndGeometrics));
					list2.Add((int)oficinaScenes.pre);
					list2.Add((int)oficinaScenes.post);
					list2.Add((int)oficinaScenes.pre2);
					list2.Add((int)oficinaScenes.post2);
					list2.Add((int)oficinaScenes.pre3);
					list2.Add((int)oficinaScenes.post3);
				}
			}
			this.m_scenas = (from bi in list2.Distinct<int>()
				where bi >= 0
				select bi).ToArray<int>();
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x000221DE File Offset: 0x000203DE
		public bool Contains(int officeLvl)
		{
			return this.m_oficinaScenes.ContieneIndex(officeLvl) && this.m_oficinaScenes[officeLvl].isValid;
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x000221FD File Offset: 0x000203FD
		public IEnumerator LoadOffice(int officeLvl)
		{
			while (Singleton<SceneLoader>.instance.isLoading)
			{
				yield return null;
			}
			IReadOnlyList<OficinaManager.LightingAndGeometricsScenes> lightingAndGeometrics;
			int num;
			int post;
			int pre2;
			int post2;
			int pre3;
			int post3;
			this.GetOficinaData(officeLvl, out lightingAndGeometrics, out num, out post, out pre2, out post2, out pre3, out post3);
			if (num >= 0)
			{
				yield return this.LoadOfficeScene(num);
			}
			if (pre2 >= 0)
			{
				yield return this.LoadOfficeScene(pre2);
			}
			if (pre3 >= 0)
			{
				yield return this.LoadOfficeScene(pre3);
			}
			if (lightingAndGeometrics.Count >= 0)
			{
				yield return this.LoadOfficeScene((int)lightingAndGeometrics[0].lightingAndGeometrics);
			}
			if (post >= 0)
			{
				yield return this.LoadOfficeScene(post);
			}
			if (post2 >= 0)
			{
				yield return this.LoadOfficeScene(post2);
			}
			if (post3 >= 0)
			{
				yield return this.LoadOfficeScene(post3);
			}
			yield break;
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x00022213 File Offset: 0x00020413
		public IEnumerator UnLoadCurrentOffice()
		{
			while (Singleton<SceneLoader>.instance.isLoading)
			{
				yield return null;
			}
			int num;
			for (int i = 0; i < this.m_scenas.Length; i = num + 1)
			{
				yield return this.UnLoadScene(this.m_scenas[i]);
				num = i;
			}
			yield break;
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x00022222 File Offset: 0x00020422
		private IEnumerator LoadOfficeScene(int buildIndex)
		{
			while (Singleton<SceneLoader>.instance.isLoading)
			{
				yield return null;
			}
			if (SceneLoader.EscenaYaEstaCerrada(buildIndex))
			{
				SceneLoader.Pedido pedido = SceneLoader.Pedido.@default;
				pedido.scene.index = buildIndex;
				pedido.doLoadOrDoUnload = true;
				Singleton<SceneLoader>.instance.AddPedido(pedido);
				while (!pedido.finalizado)
				{
					yield return null;
				}
				pedido = null;
			}
			yield break;
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x00022231 File Offset: 0x00020431
		private IEnumerator UnLoadScene(int buildIndex)
		{
			if (SceneLoader.EscenaYaEstaCargada(buildIndex))
			{
				SceneLoader.Pedido pedido = SceneLoader.Pedido.@default;
				pedido.scene.index = buildIndex;
				pedido.doLoadOrDoUnload = false;
				Singleton<SceneLoader>.instance.AddPedido(pedido);
				while (!pedido.finalizado)
				{
					yield return null;
				}
				pedido = null;
			}
			yield break;
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x00022240 File Offset: 0x00020440
		public OficinaManager.OficinaScenes GetOficinaData(int officeLvl)
		{
			if (!this.m_oficinaScenes.ContieneIndex(officeLvl))
			{
				return null;
			}
			return this.m_oficinaScenes[officeLvl];
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0002225C File Offset: 0x0002045C
		public void GetOficinaData(int officeLvl, out IReadOnlyList<OficinaManager.LightingAndGeometricsScenes> lightingAndGeometrics, out int pre, out int post, out int pre2, out int post2, out int pre3, out int post3)
		{
			OficinaManager.OficinaScenes oficinaData = this.GetOficinaData(officeLvl);
			lightingAndGeometrics = oficinaData.lightingAndGeometricsScenes;
			pre = (int)oficinaData.pre;
			post = (int)oficinaData.post;
			pre2 = (int)oficinaData.pre2;
			post2 = (int)oficinaData.post2;
			pre3 = (int)oficinaData.pre3;
			post3 = (int)oficinaData.post3;
		}

		// Token: 0x0400039E RID: 926
		[SerializeField]
		private OficinaManager.OficinaScenes[] m_oficinaScenes;

		// Token: 0x0400039F RID: 927
		private int[] m_scenas;

		// Token: 0x02000221 RID: 545
		[Serializable]
		public class OficinaScenes
		{
			// Token: 0x170002A3 RID: 675
			// (get) Token: 0x06001028 RID: 4136 RVA: 0x0004E174 File Offset: 0x0004C374
			public ValueTuple<int, int, int> key
			{
				get
				{
					return new ValueTuple<int, int, int>(this.GetlightingAndGeometricsKey(), HashCode.Combine<EscenaDeRecepcionJuego, EscenaDeRecepcionJuego, EscenaDeRecepcionJuego>(this.pre, this.pre2, this.pre3), HashCode.Combine<EscenaDeRecepcionJuego, EscenaDeRecepcionJuego, EscenaDeRecepcionJuego>(this.post, this.post2, this.post3));
				}
			}

			// Token: 0x170002A4 RID: 676
			// (get) Token: 0x06001029 RID: 4137 RVA: 0x0004E1AF File Offset: 0x0004C3AF
			public bool isValid
			{
				get
				{
					return this.oficinaLvl >= 0 && this.lightingAndGeometricsScenes.Count > 0 && this.GetlightingAndGeometricsValid();
				}
			}

			// Token: 0x0600102A RID: 4138 RVA: 0x0004E1D0 File Offset: 0x0004C3D0
			private int GetlightingAndGeometricsKey()
			{
				HashCode hashCode = default(HashCode);
				for (int i = 0; i < this.lightingAndGeometricsScenes.Count; i++)
				{
					hashCode.Add<int>(this.lightingAndGeometricsScenes[i].Key);
				}
				return hashCode.ToHashCode();
			}

			// Token: 0x0600102B RID: 4139 RVA: 0x0004E21C File Offset: 0x0004C41C
			private bool GetlightingAndGeometricsValid()
			{
				for (int i = 0; i < this.lightingAndGeometricsScenes.Count; i++)
				{
					if (!this.lightingAndGeometricsScenes[i].isValid)
					{
						return false;
					}
				}
				return true;
			}

			// Token: 0x04000A54 RID: 2644
			public int oficinaLvl;

			// Token: 0x04000A55 RID: 2645
			public float weeklyRent;

			// Token: 0x04000A56 RID: 2646
			public string inGameName;

			// Token: 0x04000A57 RID: 2647
			[TextArea]
			public string inGameDesc;

			// Token: 0x04000A58 RID: 2648
			public Texture2D thumbnail;

			// Token: 0x04000A59 RID: 2649
			public EscenaDeRecepcionJuego pre = EscenaDeRecepcionJuego.None;

			// Token: 0x04000A5A RID: 2650
			public EscenaDeRecepcionJuego pre2 = EscenaDeRecepcionJuego.None;

			// Token: 0x04000A5B RID: 2651
			public EscenaDeRecepcionJuego pre3 = EscenaDeRecepcionJuego.None;

			// Token: 0x04000A5C RID: 2652
			public List<OficinaManager.LightingAndGeometricsScenes> lightingAndGeometricsScenes = new List<OficinaManager.LightingAndGeometricsScenes>();

			// Token: 0x04000A5D RID: 2653
			public EscenaDeRecepcionJuego post = EscenaDeRecepcionJuego.None;

			// Token: 0x04000A5E RID: 2654
			public EscenaDeRecepcionJuego post2 = EscenaDeRecepcionJuego.None;

			// Token: 0x04000A5F RID: 2655
			public EscenaDeRecepcionJuego post3 = EscenaDeRecepcionJuego.None;
		}

		// Token: 0x02000222 RID: 546
		[Serializable]
		public class LightingAndGeometricsScenes
		{
			// Token: 0x170002A5 RID: 677
			// (get) Token: 0x0600102D RID: 4141 RVA: 0x0004E292 File Offset: 0x0004C492
			public bool isValid
			{
				get
				{
					return this.tiempoDelDia > ScenaTiempoDelDia.None && this.lightingAndGeometrics > EscenaDeRecepcionJuego.main;
				}
			}

			// Token: 0x170002A6 RID: 678
			// (get) Token: 0x0600102E RID: 4142 RVA: 0x0004E2A8 File Offset: 0x0004C4A8
			public int Key
			{
				get
				{
					return HashCode.Combine<ScenaTiempoDelDia, EscenaDeRecepcionJuego>(this.tiempoDelDia, this.lightingAndGeometrics);
				}
			}

			// Token: 0x04000A60 RID: 2656
			public ScenaTiempoDelDia tiempoDelDia;

			// Token: 0x04000A61 RID: 2657
			public EscenaDeRecepcionJuego lightingAndGeometrics = EscenaDeRecepcionJuego.None;
		}
	}
}
