using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.AutoRatingProfilesDeGrupos
{
	// Token: 0x0200014B RID: 331
	public class AutoRatingProfilesDeGruposPanel : UIElemento, IUIPanel, IUIElemento, IUIPanelConControles, IUIPanelConTitulo
	{
		// Token: 0x14000042 RID: 66
		// (add) Token: 0x0600098C RID: 2444 RVA: 0x0001F8BC File Offset: 0x0001DABC
		// (remove) Token: 0x0600098D RID: 2445 RVA: 0x0001F8F4 File Offset: 0x0001DAF4
		public event Action<object> onCreate;

		// Token: 0x14000043 RID: 67
		// (add) Token: 0x0600098E RID: 2446 RVA: 0x0001F92C File Offset: 0x0001DB2C
		// (remove) Token: 0x0600098F RID: 2447 RVA: 0x0001F964 File Offset: 0x0001DB64
		public event AutoRatingProfilesDeGruposPanel.GrupoChangedHandler onCambiar;

		// Token: 0x14000044 RID: 68
		// (add) Token: 0x06000990 RID: 2448 RVA: 0x0001F99C File Offset: 0x0001DB9C
		// (remove) Token: 0x06000991 RID: 2449 RVA: 0x0001F9D4 File Offset: 0x0001DBD4
		public event AutoRatingProfilesDeGruposPanel.GrupoChangedHandler onEditar;

		// Token: 0x14000045 RID: 69
		// (add) Token: 0x06000992 RID: 2450 RVA: 0x0001FA0C File Offset: 0x0001DC0C
		// (remove) Token: 0x06000993 RID: 2451 RVA: 0x0001FA44 File Offset: 0x0001DC44
		public event AutoRatingProfilesDeGruposPanel.GrupoChangedHandler onRemover;

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06000994 RID: 2452 RVA: 0x0001FA79 File Offset: 0x0001DC79
		public Scrollbar scrollbar
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0001FA7C File Offset: 0x0001DC7C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_panel == null)
			{
				this.m_panel = base.GetComponent<Image>();
			}
			if (this.m_panelParaTitulo == null)
			{
				throw new ArgumentNullException("m_panelParaTitulo", "m_panelParaTitulo null reference.");
			}
			if (this.m_panelParaControles == null)
			{
				throw new ArgumentNullException("m_panelParaControles", "m_panelParaControles null reference.");
			}
			if (this.m_panelParaFields == null)
			{
				throw new ArgumentNullException("m_panelParaFields", "m_panelParaFields null reference.");
			}
			if (this.grupoA == null)
			{
				throw new ArgumentNullException("grupoA", "grupoA null reference.");
			}
			if (this.grupoB == null)
			{
				throw new ArgumentNullException("grupoB", "grupoB null reference.");
			}
			if (this.grupoC == null)
			{
				throw new ArgumentNullException("grupoC", "grupoC null reference.");
			}
			if (this.grupoD == null)
			{
				throw new ArgumentNullException("grupoD", "grupoD null reference.");
			}
			if (this.grupoE == null)
			{
				throw new ArgumentNullException("grupoE", "grupoE null reference.");
			}
			if (this.grupoF == null)
			{
				throw new ArgumentNullException("grupoF", "grupoF null reference.");
			}
			if (this.grupoG == null)
			{
				throw new ArgumentNullException("grupoG", "grupoG null reference.");
			}
			if (this.grupoH == null)
			{
				throw new ArgumentNullException("grupoH", "grupoH null reference.");
			}
			if (this.grupoI == null)
			{
				throw new ArgumentNullException("grupoI", "grupoI null reference.");
			}
			if (this.grupoJ == null)
			{
				throw new ArgumentNullException("grupoJ", "grupoJ null reference.");
			}
			this.grupoA.Init(0);
			this.grupoB.Init(1);
			this.grupoC.Init(2);
			this.grupoD.Init(3);
			this.grupoE.Init(4);
			this.grupoF.Init(5);
			this.grupoG.Init(6);
			this.grupoH.Init(7);
			this.grupoI.Init(8);
			this.grupoJ.Init(9);
			this.m_gruposBases.Add("grupoA", this.grupoA);
			this.m_gruposBases.Add("grupoB", this.grupoB);
			this.m_gruposBases.Add("grupoC", this.grupoC);
			this.m_gruposBases.Add("grupoD", this.grupoD);
			this.m_gruposBases.Add("grupoE", this.grupoE);
			this.m_gruposBases.Add("grupoF", this.grupoF);
			this.m_gruposBases.Add("grupoG", this.grupoG);
			this.m_gruposBases.Add("grupoH", this.grupoH);
			this.m_gruposBases.Add("grupoI", this.grupoI);
			this.m_gruposBases.Add("grupoJ", this.grupoJ);
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0001FD84 File Offset: 0x0001DF84
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.SubscribeToGroups(this.grupoA);
			this.SubscribeToGroups(this.grupoB);
			this.SubscribeToGroups(this.grupoC);
			this.SubscribeToGroups(this.grupoD);
			this.SubscribeToGroups(this.grupoE);
			this.SubscribeToGroups(this.grupoF);
			this.SubscribeToGroups(this.grupoG);
			this.SubscribeToGroups(this.grupoH);
			this.SubscribeToGroups(this.grupoI);
			this.SubscribeToGroups(this.grupoJ);
			this.m_createBoton.onClick.AddListener(new UnityAction(this.OnCrearClicked));
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0001FE2C File Offset: 0x0001E02C
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.UnSubscribeToGroups(this.grupoA);
			this.UnSubscribeToGroups(this.grupoB);
			this.UnSubscribeToGroups(this.grupoC);
			this.UnSubscribeToGroups(this.grupoD);
			this.UnSubscribeToGroups(this.grupoE);
			this.UnSubscribeToGroups(this.grupoF);
			this.UnSubscribeToGroups(this.grupoG);
			this.UnSubscribeToGroups(this.grupoH);
			this.UnSubscribeToGroups(this.grupoI);
			this.UnSubscribeToGroups(this.grupoJ);
			Button createBoton = this.m_createBoton;
			if (createBoton == null)
			{
				return;
			}
			createBoton.onClick.RemoveListener(new UnityAction(this.OnCrearClicked));
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x0001FED9 File Offset: 0x0001E0D9
		private void SubscribeToGroups(GrupoProfile grupo)
		{
			grupo.onCambiar += this.Grupo_onCambiar;
			grupo.onEditar += this.Grupo_onEditar;
			grupo.onRemover += this.Grupo_onRemover;
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x0001FF14 File Offset: 0x0001E114
		private void UnSubscribeToGroups(GrupoProfile grupo)
		{
			if (grupo != null)
			{
				grupo.onCambiar -= this.Grupo_onCambiar;
				grupo.onEditar -= this.Grupo_onEditar;
				grupo.onRemover -= this.Grupo_onRemover;
			}
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0001FF60 File Offset: 0x0001E160
		private void OnCrearClicked()
		{
			Action<object> action = this.onCreate;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0001FF73 File Offset: 0x0001E173
		private void Grupo_onRemover(GrupoProfile obj)
		{
			AutoRatingProfilesDeGruposPanel.GrupoChangedHandler grupoChangedHandler = this.onRemover;
			if (grupoChangedHandler == null)
			{
				return;
			}
			grupoChangedHandler(obj.index, obj, this);
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x0001FF8D File Offset: 0x0001E18D
		private void Grupo_onEditar(GrupoProfile obj)
		{
			AutoRatingProfilesDeGruposPanel.GrupoChangedHandler grupoChangedHandler = this.onEditar;
			if (grupoChangedHandler == null)
			{
				return;
			}
			grupoChangedHandler(obj.index, obj, this);
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x0001FFA7 File Offset: 0x0001E1A7
		private void Grupo_onCambiar(GrupoProfile obj)
		{
			AutoRatingProfilesDeGruposPanel.GrupoChangedHandler grupoChangedHandler = this.onCambiar;
			if (grupoChangedHandler == null)
			{
				return;
			}
			grupoChangedHandler(obj.index, obj, this);
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x0001FFC4 File Offset: 0x0001E1C4
		public GrupoProfile GetGrupo(int index)
		{
			switch (index)
			{
			case 0:
				return this.grupoA;
			case 1:
				return this.grupoB;
			case 2:
				return this.grupoC;
			case 3:
				return this.grupoD;
			case 4:
				return this.grupoE;
			case 5:
				return this.grupoF;
			case 6:
				return this.grupoG;
			case 7:
				return this.grupoH;
			case 8:
				return this.grupoI;
			case 9:
				return this.grupoJ;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x0600099F RID: 2463 RVA: 0x00020053 File Offset: 0x0001E253
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				return this.m_gruposBases;
			}
		}

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x060009A0 RID: 2464 RVA: 0x0002005B File Offset: 0x0001E25B
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x060009A1 RID: 2465 RVA: 0x00020063 File Offset: 0x0001E263
		public Transform padreParaControles
		{
			get
			{
				return this.m_panelParaControles;
			}
		}

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x060009A2 RID: 2466 RVA: 0x0002006B File Offset: 0x0001E26B
		public Transform padreParaTitulos
		{
			get
			{
				return this.m_panelParaTitulo;
			}
		}

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x060009A3 RID: 2467 RVA: 0x00020073 File Offset: 0x0001E273
		public int getParentCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x00020076 File Offset: 0x0001E276
		public void AddElementos(IEnumerable<KeyValuePair<string, IUIElemento>> pares)
		{
			if (pares != null && pares.Count<KeyValuePair<string, IUIElemento>>() > 0)
			{
				throw new NotSupportedException("este panel No es compatible con adiciones de elementos dinamicas");
			}
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0002008F File Offset: 0x0001E28F
		public void ReplaceElemento(IUIElemento elemento)
		{
			throw new NotSupportedException("este panel No es compatible con adiciones de elementos dinamicas");
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x0002009B File Offset: 0x0001E29B
		public Transform GetParentPara(int index)
		{
			return this.m_panelParaFields;
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x000200A3 File Offset: 0x0001E2A3
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x000200BD File Offset: 0x0001E2BD
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x000200C5 File Offset: 0x0001E2C5
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x040003C2 RID: 962
		[SerializeField]
		private Transform m_panelParaTitulo;

		// Token: 0x040003C3 RID: 963
		[SerializeField]
		private Transform m_panelParaControles;

		// Token: 0x040003C4 RID: 964
		[SerializeField]
		private Transform m_panelParaFields;

		// Token: 0x040003C5 RID: 965
		[Tooltip("puede ser null")]
		[SerializeField]
		private Image m_panel;

		// Token: 0x040003C6 RID: 966
		[SerializeField]
		private Button m_createBoton;

		// Token: 0x040003C7 RID: 967
		public GrupoProfile grupoA;

		// Token: 0x040003C8 RID: 968
		public GrupoProfile grupoB;

		// Token: 0x040003C9 RID: 969
		public GrupoProfile grupoC;

		// Token: 0x040003CA RID: 970
		public GrupoProfile grupoD;

		// Token: 0x040003CB RID: 971
		public GrupoProfile grupoE;

		// Token: 0x040003CC RID: 972
		public GrupoProfile grupoF;

		// Token: 0x040003CD RID: 973
		public GrupoProfile grupoG;

		// Token: 0x040003CE RID: 974
		public GrupoProfile grupoH;

		// Token: 0x040003CF RID: 975
		public GrupoProfile grupoI;

		// Token: 0x040003D0 RID: 976
		public GrupoProfile grupoJ;

		// Token: 0x040003D5 RID: 981
		private Dictionary<string, IUIElemento> m_gruposBases = new Dictionary<string, IUIElemento>();

		// Token: 0x020001CF RID: 463
		// (Invoke) Token: 0x06000C56 RID: 3158
		public delegate void GrupoChangedHandler(int grupoIndex, object grupo, object sender);
	}
}
