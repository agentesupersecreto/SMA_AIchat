using System;
using System.Collections.Generic;
using Assets.Base.RootMotion.BeachGirl.Runtime;
using RootMotion;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000072 RID: 114
	public class FemaleFullBodyBipedIKs : AplicableBehaviour, IFemaleFullBodyBipedIKs
	{
		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x00014951 File Offset: 0x00012B51
		public int cantidadDeIKs
		{
			get
			{
				return 6;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000452 RID: 1106 RVA: 0x00014954 File Offset: 0x00012B54
		public int cantidadDeLayers
		{
			get
			{
				return 4;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x00014957 File Offset: 0x00012B57
		[Obsolete("", true)]
		public List<FullBodyBipedIK> fullBodyBipedIKs
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000454 RID: 1108 RVA: 0x0001495E File Offset: 0x00012B5E
		[Obsolete("", true)]
		public FullBodyBipedIK currentPrimario
		{
			get
			{
				return this.m_primario;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x00014966 File Offset: 0x00012B66
		[Obsolete("", true)]
		public FullBodyBipedIK currentSegundario
		{
			get
			{
				return this.m_segundario;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x0001496E File Offset: 0x00012B6E
		[Obsolete("", true)]
		public FullBodyBipedIK terciario
		{
			get
			{
				return this.m_terciario;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x00014976 File Offset: 0x00012B76
		[Obsolete("", true)]
		public FullBodyBipedIK cuaternario
		{
			get
			{
				return this.m_cuaternario;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000458 RID: 1112 RVA: 0x0001497E File Offset: 0x00012B7E
		public FullBodyBipedIK user
		{
			get
			{
				return this.m_user;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x00014986 File Offset: 0x00012B86
		public IReadOnlyList<FullBodyBipedIK> allFullBodyBipedIKs
		{
			get
			{
				this.InitFullBodyBipedIKsList();
				return this.m_iks;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600045A RID: 1114 RVA: 0x00014994 File Offset: 0x00012B94
		public IReadOnlyList<FullBodyBipedIK> primarios
		{
			get
			{
				this.InitFullBodyBipedIKsList();
				return this.m_primarios;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x000149A2 File Offset: 0x00012BA2
		public IReadOnlyList<FullBodyBipedIK> segundarios
		{
			get
			{
				this.InitFullBodyBipedIKsList();
				return this.m_segundarios;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600045C RID: 1116 RVA: 0x000149B0 File Offset: 0x00012BB0
		public IReadOnlyList<FullBodyBipedIK> terciarios
		{
			get
			{
				this.InitFullBodyBipedIKsList();
				return this.m_terciarios;
			}
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x000149C0 File Offset: 0x00012BC0
		private void InitFullBodyBipedIKsList()
		{
			if (!base.isAwaken)
			{
				this.CheckFullBodyBipedIKs();
			}
			if (this.m_iks == null)
			{
				this.m_iks = new List<FullBodyBipedIK>();
			}
			if (this.m_iks.Count == 0)
			{
				this.m_iks.Add(this.m_0);
				this.m_iks.Add(this.m_1);
				this.m_iks.Add(this.m_2);
				this.m_iks.Add(this.m_3);
				this.m_iks.Add(this.m_4);
				this.m_iks.Add(this.m_user);
			}
			if (this.m_primarios == null)
			{
				this.m_primarios = new List<FullBodyBipedIK>();
			}
			if (this.m_primarios.Count == 0)
			{
				this.m_primarios.Add(this.m_0);
				this.m_primarios.Add(this.m_1);
			}
			if (this.m_segundarios == null)
			{
				this.m_segundarios = new List<FullBodyBipedIK>();
			}
			if (this.m_segundarios.Count == 0)
			{
				this.m_segundarios.Add(this.m_2);
				this.m_segundarios.Add(this.m_3);
			}
			if (this.m_terciarios == null)
			{
				this.m_terciarios = new List<FullBodyBipedIK>();
			}
			if (this.m_terciarios.Count == 0)
			{
				this.m_terciarios.Add(this.m_4);
			}
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00014B18 File Offset: 0x00012D18
		private void CheckFullBodyBipedIKs()
		{
			if (this.m_primarioA == null)
			{
				throw new ArgumentNullException("m_primarioA", "m_primarioA null reference.");
			}
			if (this.m_primarioB == null)
			{
				throw new ArgumentNullException("m_primarioB", "m_primarioB null reference.");
			}
			if (this.m_segundarioA == null)
			{
				throw new ArgumentNullException("m_segundarioA", "m_segundarioA null reference.");
			}
			if (this.m_segundarioB == null)
			{
				throw new ArgumentNullException("m_segundarioB", "m_segundarioB null reference.");
			}
			if (this.m_terciario == null)
			{
				throw new ArgumentNullException("m_terciario", "m_terciario null reference.");
			}
			if (this.m_user == null)
			{
				throw new ArgumentNullException("m_user", "m_user null reference.");
			}
			if (this.m_0 == null)
			{
				this.m_0 = this.m_primarioA;
			}
			if (this.m_1 == null)
			{
				this.m_1 = this.m_primarioB;
			}
			if (this.m_2 == null)
			{
				this.m_2 = this.m_segundarioA;
			}
			if (this.m_3 == null)
			{
				this.m_3 = this.m_segundarioB;
			}
			if (this.m_4 == null)
			{
				this.m_4 = this.m_terciario;
			}
			if (this.m_0 == this.m_1)
			{
				this.m_0 = this.m_primarioA;
				this.m_1 = this.m_primarioB;
			}
			if (this.m_2 == this.m_3)
			{
				this.m_2 = this.m_segundarioA;
				this.m_3 = this.m_segundarioB;
			}
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00014CB4 File Offset: 0x00012EB4
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			ICharacter componentInParent = base.GetComponentInParent<ICharacter>();
			this.CheckFullBodyBipedIKs();
			this.InitFullBodyBipedIKsList();
			this.m_updater = this.GetComponentEnRoot(false);
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
			}
			foreach (FullBodyBipedIK fullBodyBipedIK in this.m_iks)
			{
				fullBodyBipedIK.SetAnimator(componentInParent.bodyAnimator);
			}
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x00014D48 File Offset: 0x00012F48
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00014D50 File Offset: 0x00012F50
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00014D5C File Offset: 0x00012F5C
		public int CantidadDePasadasDeIK(FullBodyBipedIK IK)
		{
			int layerDeIK = this.GetLayerDeIK(IK);
			if (layerDeIK == 0)
			{
				return this.m_cantidadDePAsadasParaLayer0;
			}
			if (layerDeIK != 1)
			{
				return this.m_cantidadDePAsadasParaOtrosLayers;
			}
			return this.m_cantidadDePAsadasParaLayer1;
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00014D90 File Offset: 0x00012F90
		public void SwitchPrimarios()
		{
			this.CheckFullBodyBipedIKs();
			FullBodyBipedIK <<EMPTY_NAME>> = this.m_0;
			FullBodyBipedIK 2 = this.m_1;
			this.m_0 = 2;
			this.m_1 = <<EMPTY_NAME>>;
			this.m_iks.Clear();
			this.m_primarios.Clear();
			this.InitFullBodyBipedIKsList();
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00014DDC File Offset: 0x00012FDC
		public void SwitchSegundarios()
		{
			this.CheckFullBodyBipedIKs();
			FullBodyBipedIK <<EMPTY_NAME>> = this.m_2;
			FullBodyBipedIK 2 = this.m_3;
			this.m_2 = 2;
			this.m_3 = <<EMPTY_NAME>>;
			this.m_iks.Clear();
			this.m_segundarios.Clear();
			this.InitFullBodyBipedIKsList();
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00014E27 File Offset: 0x00013027
		public void SwitchTerciarios()
		{
			this.CheckFullBodyBipedIKs();
			this.m_iks.Clear();
			this.m_terciarios.Clear();
			this.InitFullBodyBipedIKsList();
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x00014E4C File Offset: 0x0001304C
		[Obsolete("", true)]
		public FullBodyBipedIK ObtenerFullBodyBipedIKDePasada(int index)
		{
			FullBodyBipedIK fullBodyBipedIK;
			try
			{
				fullBodyBipedIK = this.allFullBodyBipedIKs[index];
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException("index " + index.ToString() + ", no existe en iks de " + base.name, ex);
			}
			return fullBodyBipedIK;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00014EA0 File Offset: 0x000130A0
		protected sealed override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Update IKs Referencias",
				playTimeVisible = false
			};
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00014EB9 File Offset: 0x000130B9
		protected sealed override void OnAplicar2()
		{
			base.OnAplicar2();
			this.UpdateIKsReferencias();
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00014EC8 File Offset: 0x000130C8
		public void UpdateIKsReferencias()
		{
			if (Application.isPlaying)
			{
				throw new InvalidOperationException();
			}
			Animator componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("anim", "anim null reference.");
			}
			BipedReferences bipedReferences = null;
			BipedReferences.AutoDetectReferences(ref bipedReferences, componentEnRoot.transform, new BipedReferences.AutoDetectParams(true, false));
			foreach (FullBodyBipedIK fullBodyBipedIK in this.allFullBodyBipedIKs)
			{
				fullBodyBipedIK.solver.rootNode = IKSolverFullBodyBiped.DetectRootNodeBone(bipedReferences);
				fullBodyBipedIK.SetReferences(bipedReferences, fullBodyBipedIK.solver.rootNode);
			}
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00014F78 File Offset: 0x00013178
		public FullBodyBipedIK ObtenerCurrentFullBodyBipedIKDeLayer(int layer)
		{
			switch (layer)
			{
			case 0:
				return this.m_0;
			case 1:
				return this.m_2;
			case 2:
				return this.m_4;
			default:
				throw new ArgumentOutOfRangeException(layer.ToString());
			}
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00014FB0 File Offset: 0x000131B0
		public FullBodyBipedIK ObtenerCurrentFullBodyBipedIKDeID(int id)
		{
			switch (id)
			{
			case 0:
				return this.m_primarioA;
			case 1:
				return this.m_primarioB;
			case 2:
				return this.m_segundarioA;
			case 3:
				return this.m_segundarioB;
			case 4:
				return this.m_terciario;
			default:
				if (id != 99)
				{
					throw new ArgumentOutOfRangeException(id.ToString());
				}
				return this.m_user;
			}
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00015014 File Offset: 0x00013214
		public IReadOnlyList<FullBodyBipedIK> ObtenerFullBodyBipedIKsDeLayer(int layer)
		{
			switch (layer)
			{
			case 0:
				return this.primarios;
			case 1:
				return this.segundarios;
			case 2:
				return this.terciarios;
			default:
				throw new ArgumentOutOfRangeException(layer.ToString());
			}
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0001504C File Offset: 0x0001324C
		public int GetId(FullBodyBipedIK IK)
		{
			if (IK == this.m_primarioA)
			{
				return 0;
			}
			if (IK == this.m_primarioB)
			{
				return 1;
			}
			if (IK == this.m_segundarioA)
			{
				return 2;
			}
			if (IK == this.m_segundarioB)
			{
				return 3;
			}
			if (IK == this.m_terciario)
			{
				return 4;
			}
			if (IK == this.m_user)
			{
				return 99;
			}
			return -1;
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x000150BC File Offset: 0x000132BC
		public int GetLayerDeIK(FullBodyBipedIK IK)
		{
			if (IK == this.m_primarioA)
			{
				return 0;
			}
			if (IK == this.m_primarioB)
			{
				return 0;
			}
			if (IK == this.m_segundarioA)
			{
				return 1;
			}
			if (IK == this.m_segundarioB)
			{
				return 1;
			}
			if (IK == this.m_terciario)
			{
				return 2;
			}
			if (IK == this.m_user)
			{
				return 3;
			}
			return -1;
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0001512C File Offset: 0x0001332C
		public int GetIndexInLayerDeIK(FullBodyBipedIK IK, out bool ultimoDeLayer)
		{
			if (IK == this.m_0)
			{
				ultimoDeLayer = false;
				return 0;
			}
			if (IK == this.m_1)
			{
				ultimoDeLayer = true;
				return 1;
			}
			if (IK == this.m_2)
			{
				ultimoDeLayer = false;
				return 0;
			}
			if (IK == this.m_3)
			{
				ultimoDeLayer = true;
				return 1;
			}
			if (IK == this.m_4)
			{
				ultimoDeLayer = true;
				return 0;
			}
			if (IK == this.m_user)
			{
				ultimoDeLayer = true;
				return 0;
			}
			ultimoDeLayer = true;
			return -1;
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x000151AF File Offset: 0x000133AF
		protected sealed override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Switch Primarios",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x000151C8 File Offset: 0x000133C8
		protected sealed override void OnAplicar3()
		{
			base.OnAplicar3();
			this.SwitchPrimarios();
		}

		// Token: 0x040002DE RID: 734
		[SerializeField]
		private int m_cantidadDePAsadasParaLayer0 = 2;

		// Token: 0x040002DF RID: 735
		[SerializeField]
		private int m_cantidadDePAsadasParaLayer1 = 2;

		// Token: 0x040002E0 RID: 736
		[SerializeField]
		private int m_cantidadDePAsadasParaOtrosLayers = 2;

		// Token: 0x040002E1 RID: 737
		private IIKUpdater m_updater;

		// Token: 0x040002E2 RID: 738
		[SerializeField]
		private FullBodyBipedIK m_primarioA;

		// Token: 0x040002E3 RID: 739
		[SerializeField]
		private FullBodyBipedIK m_primarioB;

		// Token: 0x040002E4 RID: 740
		[SerializeField]
		private FullBodyBipedIK m_segundarioA;

		// Token: 0x040002E5 RID: 741
		[SerializeField]
		private FullBodyBipedIK m_segundarioB;

		// Token: 0x040002E6 RID: 742
		[SerializeField]
		private FullBodyBipedIK m_terciario;

		// Token: 0x040002E7 RID: 743
		[SerializeField]
		private FullBodyBipedIK m_user;

		// Token: 0x040002E8 RID: 744
		[ReadOnlyUI]
		[SerializeField]
		private FullBodyBipedIK m_0;

		// Token: 0x040002E9 RID: 745
		[ReadOnlyUI]
		[SerializeField]
		private FullBodyBipedIK m_1;

		// Token: 0x040002EA RID: 746
		[ReadOnlyUI]
		[SerializeField]
		private FullBodyBipedIK m_2;

		// Token: 0x040002EB RID: 747
		[ReadOnlyUI]
		[SerializeField]
		private FullBodyBipedIK m_3;

		// Token: 0x040002EC RID: 748
		[ReadOnlyUI]
		[SerializeField]
		private FullBodyBipedIK m_4;

		// Token: 0x040002ED RID: 749
		[Obsolete("", true)]
		private FullBodyBipedIK m_primario;

		// Token: 0x040002EE RID: 750
		[Obsolete("", true)]
		private FullBodyBipedIK m_segundario;

		// Token: 0x040002EF RID: 751
		[Obsolete("", true)]
		private FullBodyBipedIK m_cuaternario;

		// Token: 0x040002F0 RID: 752
		[SerializeField]
		[ReadOnlyUI]
		private List<FullBodyBipedIK> m_iks = new List<FullBodyBipedIK>();

		// Token: 0x040002F1 RID: 753
		[SerializeField]
		[ReadOnlyUI]
		private List<FullBodyBipedIK> m_primarios = new List<FullBodyBipedIK>();

		// Token: 0x040002F2 RID: 754
		[SerializeField]
		[ReadOnlyUI]
		private List<FullBodyBipedIK> m_segundarios = new List<FullBodyBipedIK>();

		// Token: 0x040002F3 RID: 755
		[SerializeField]
		[ReadOnlyUI]
		private List<FullBodyBipedIK> m_terciarios = new List<FullBodyBipedIK>();
	}
}
