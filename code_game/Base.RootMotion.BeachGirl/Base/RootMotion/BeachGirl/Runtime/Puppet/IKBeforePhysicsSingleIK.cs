using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Puppet
{
	// Token: 0x0200000F RID: 15
	public class IKBeforePhysicsSingleIK : IKBeforePhysicsBase, IIKUpdater
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000070 RID: 112 RVA: 0x00004790 File Offset: 0x00002990
		// (remove) Token: 0x06000071 RID: 113 RVA: 0x000047C8 File Offset: 0x000029C8
		public event Action<CustomUpdatedMonobehaviourBase> updatingFBBIKUltimaVuelta;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000072 RID: 114 RVA: 0x00004800 File Offset: 0x00002A00
		// (remove) Token: 0x06000073 RID: 115 RVA: 0x00004838 File Offset: 0x00002A38
		[Obsolete("", true)]
		public event Action<IKBeforePhysicsV2> fullBodyBipedIKPrimerPasoUpdating;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000074 RID: 116 RVA: 0x00004870 File Offset: 0x00002A70
		// (remove) Token: 0x06000075 RID: 117 RVA: 0x000048A8 File Offset: 0x00002AA8
		[Obsolete("", true)]
		public event Action<IKBeforePhysicsV2> fullBodyBipedIKPrimerPasoUpdated;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000076 RID: 118 RVA: 0x000048E0 File Offset: 0x00002AE0
		// (remove) Token: 0x06000077 RID: 119 RVA: 0x00004918 File Offset: 0x00002B18
		[Obsolete("", true)]
		public event Action<IKBeforePhysicsV2> fullBodyBipedIKSegundoPasoUpdating;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000078 RID: 120 RVA: 0x00004950 File Offset: 0x00002B50
		// (remove) Token: 0x06000079 RID: 121 RVA: 0x00004988 File Offset: 0x00002B88
		[Obsolete("", true)]
		public event Action<IKBeforePhysicsV2> fullBodyBipedIKSegundoPasoUpdated;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600007A RID: 122 RVA: 0x000049C0 File Offset: 0x00002BC0
		// (remove) Token: 0x0600007B RID: 123 RVA: 0x000049F8 File Offset: 0x00002BF8
		public event Action<IKBeforePhysicsV2> updatingFBBIKAny;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600007C RID: 124 RVA: 0x00004A30 File Offset: 0x00002C30
		// (remove) Token: 0x0600007D RID: 125 RVA: 0x00004A68 File Offset: 0x00002C68
		public event Action<IKBeforePhysicsV2> updatedFBBIKAny;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x0600007E RID: 126 RVA: 0x00004AA0 File Offset: 0x00002CA0
		// (remove) Token: 0x0600007F RID: 127 RVA: 0x00004AD8 File Offset: 0x00002CD8
		public event Action<IKBeforePhysicsV2> updatingFBBIK1;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000080 RID: 128 RVA: 0x00004B10 File Offset: 0x00002D10
		// (remove) Token: 0x06000081 RID: 129 RVA: 0x00004B48 File Offset: 0x00002D48
		public event Action<IKBeforePhysicsV2> updatedFBBIK1;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000082 RID: 130 RVA: 0x00004B80 File Offset: 0x00002D80
		// (remove) Token: 0x06000083 RID: 131 RVA: 0x00004BB8 File Offset: 0x00002DB8
		public event Action<IKBeforePhysicsV2> updatingFBBIK2;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06000084 RID: 132 RVA: 0x00004BF0 File Offset: 0x00002DF0
		// (remove) Token: 0x06000085 RID: 133 RVA: 0x00004C28 File Offset: 0x00002E28
		public event Action<IKBeforePhysicsV2> updatedFBBIK2;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000086 RID: 134 RVA: 0x00004C60 File Offset: 0x00002E60
		// (remove) Token: 0x06000087 RID: 135 RVA: 0x00004C98 File Offset: 0x00002E98
		public event Action<IKBeforePhysicsV2> updatingFBBIK3;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000088 RID: 136 RVA: 0x00004CD0 File Offset: 0x00002ED0
		// (remove) Token: 0x06000089 RID: 137 RVA: 0x00004D08 File Offset: 0x00002F08
		public event Action<IKBeforePhysicsV2> updatedFBBIK3;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x0600008A RID: 138 RVA: 0x00004D40 File Offset: 0x00002F40
		// (remove) Token: 0x0600008B RID: 139 RVA: 0x00004D78 File Offset: 0x00002F78
		public event Action<CustomUpdatedMonobehaviourBase> puppetUpdating;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x0600008C RID: 140 RVA: 0x00004DB0 File Offset: 0x00002FB0
		// (remove) Token: 0x0600008D RID: 141 RVA: 0x00004DE8 File Offset: 0x00002FE8
		public event Action<CustomUpdatedMonobehaviourBase> puppetUpdated;

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00004E1D File Offset: 0x0000301D
		[Obsolete("ahora hay dos", true)]
		public FullBodyBipedIK fullBodyBipedIK
		{
			get
			{
				if (this.m_fullBodyBipedIK == null)
				{
					this.m_fullBodyBipedIK = base.GetComponentInChildren<FullBodyBipedIK>();
				}
				return this.m_fullBodyBipedIK;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00004E3F File Offset: 0x0000303F
		public sealed override FullBodyBipedIK userFullBodyBipedIK
		{
			get
			{
				return this.m_primario;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00004E47 File Offset: 0x00003047
		public override int cantidadDeIKs
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00004E4A File Offset: 0x0000304A
		public override int cantidadDeLayers
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00004E50 File Offset: 0x00003050
		protected sealed override void AwakeUnityEvent()
		{
			ICharacter componentInParent = base.GetComponentInParent<ICharacter>();
			if (componentInParent == null)
			{
				this.character = this;
			}
			else
			{
				this.character = (MonoBehaviour)componentInParent;
			}
			if (this.m_primario == null)
			{
				throw new ArgumentNullException("m_primario", "m_primario null reference.");
			}
			this.m_fullBodyBipedIKs.Add(this.m_primario);
			this.m_layerZero.Add(this.m_primario);
			base.AwakeUnityEvent();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00004EC2 File Offset: 0x000030C2
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00004ECA File Offset: 0x000030CA
		public override int IDDeIK(Component IK)
		{
			if (IK == this.m_primario)
			{
				return 0;
			}
			return -1;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00004EDD File Offset: 0x000030DD
		public override int LayerDeIK(Component IK)
		{
			return this.IDDeIK(IK);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00004EE6 File Offset: 0x000030E6
		public override int IndexEnLayerDeIK(Component IK, out bool ultimoDeLayer)
		{
			ultimoDeLayer = true;
			if (this.IDDeIK(IK) >= 0)
			{
				return 0;
			}
			return -1;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00004EF8 File Offset: 0x000030F8
		public sealed override FullBodyBipedIK ObtenerFullBodyBipedIKDeID(int index)
		{
			if (index == 0)
			{
				return this.m_primario;
			}
			return null;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00004F05 File Offset: 0x00003105
		[Obsolete("", true)]
		public sealed override FullBodyBipedIK ObtenerFullBodyBipedIKLayer(int layer)
		{
			return this.m_fullBodyBipedIK;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004F0D File Offset: 0x0000310D
		public override IReadOnlyList<Component> SortedIKsDeLayer(int layer)
		{
			if (layer == 0)
			{
				return this.m_layerZero;
			}
			return null;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00004F1A File Offset: 0x0000311A
		public override void SwitchLayerIks(int layer)
		{
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00004F1C File Offset: 0x0000311C
		protected override IReadOnlyList<FullBodyBipedIK> ObtenerAllFullBodyBipedIKSortedNonAlloc()
		{
			return this.m_fullBodyBipedIKs;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00004F24 File Offset: 0x00003124
		public override int CantidadDePasadasDeIK(int IKIndex)
		{
			if (IKIndex == 0)
			{
				return 1;
			}
			return -1;
		}

		// Token: 0x04000035 RID: 53
		private MonoBehaviour character;

		// Token: 0x04000036 RID: 54
		[Obsolete("ahora hay dos", true)]
		private FullBodyBipedIK m_fullBodyBipedIK;

		// Token: 0x04000037 RID: 55
		[SerializeField]
		private FullBodyBipedIK m_primario;

		// Token: 0x04000038 RID: 56
		private List<FullBodyBipedIK> m_layerZero = new List<FullBodyBipedIK>();

		// Token: 0x04000039 RID: 57
		private List<FullBodyBipedIK> m_fullBodyBipedIKs = new List<FullBodyBipedIK>();
	}
}
