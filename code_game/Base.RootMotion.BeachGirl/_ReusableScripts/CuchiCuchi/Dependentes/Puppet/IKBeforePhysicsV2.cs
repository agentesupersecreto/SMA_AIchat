using System;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x02000103 RID: 259
	public sealed class IKBeforePhysicsV2 : IKBeforePhysicsBase, IIKUpdater
	{
		// Token: 0x14000090 RID: 144
		// (add) Token: 0x060009F6 RID: 2550 RVA: 0x0002CD3C File Offset: 0x0002AF3C
		// (remove) Token: 0x060009F7 RID: 2551 RVA: 0x0002CD74 File Offset: 0x0002AF74
		public event Action<CustomUpdatedMonobehaviourBase> updatingFBBIKUltimaVuelta;

		// Token: 0x14000091 RID: 145
		// (add) Token: 0x060009F8 RID: 2552 RVA: 0x0002CDAC File Offset: 0x0002AFAC
		// (remove) Token: 0x060009F9 RID: 2553 RVA: 0x0002CDE4 File Offset: 0x0002AFE4
		[Obsolete("", true)]
		public event Action<IKBeforePhysicsV2> fullBodyBipedIKPrimerPasoUpdating;

		// Token: 0x14000092 RID: 146
		// (add) Token: 0x060009FA RID: 2554 RVA: 0x0002CE1C File Offset: 0x0002B01C
		// (remove) Token: 0x060009FB RID: 2555 RVA: 0x0002CE54 File Offset: 0x0002B054
		[Obsolete("", true)]
		public event Action<IKBeforePhysicsV2> fullBodyBipedIKPrimerPasoUpdated;

		// Token: 0x14000093 RID: 147
		// (add) Token: 0x060009FC RID: 2556 RVA: 0x0002CE8C File Offset: 0x0002B08C
		// (remove) Token: 0x060009FD RID: 2557 RVA: 0x0002CEC4 File Offset: 0x0002B0C4
		[Obsolete("", true)]
		public event Action<IKBeforePhysicsV2> fullBodyBipedIKSegundoPasoUpdating;

		// Token: 0x14000094 RID: 148
		// (add) Token: 0x060009FE RID: 2558 RVA: 0x0002CEFC File Offset: 0x0002B0FC
		// (remove) Token: 0x060009FF RID: 2559 RVA: 0x0002CF34 File Offset: 0x0002B134
		[Obsolete("", true)]
		public event Action<IKBeforePhysicsV2> fullBodyBipedIKSegundoPasoUpdated;

		// Token: 0x14000095 RID: 149
		// (add) Token: 0x06000A00 RID: 2560 RVA: 0x0002CF6C File Offset: 0x0002B16C
		// (remove) Token: 0x06000A01 RID: 2561 RVA: 0x0002CFA4 File Offset: 0x0002B1A4
		public event Action<IKBeforePhysicsV2> updatingFBBIKAny;

		// Token: 0x14000096 RID: 150
		// (add) Token: 0x06000A02 RID: 2562 RVA: 0x0002CFDC File Offset: 0x0002B1DC
		// (remove) Token: 0x06000A03 RID: 2563 RVA: 0x0002D014 File Offset: 0x0002B214
		public event Action<IKBeforePhysicsV2> updatedFBBIKAny;

		// Token: 0x14000097 RID: 151
		// (add) Token: 0x06000A04 RID: 2564 RVA: 0x0002D04C File Offset: 0x0002B24C
		// (remove) Token: 0x06000A05 RID: 2565 RVA: 0x0002D084 File Offset: 0x0002B284
		public event Action<IKBeforePhysicsV2> updatingFBBIK1;

		// Token: 0x14000098 RID: 152
		// (add) Token: 0x06000A06 RID: 2566 RVA: 0x0002D0BC File Offset: 0x0002B2BC
		// (remove) Token: 0x06000A07 RID: 2567 RVA: 0x0002D0F4 File Offset: 0x0002B2F4
		public event Action<IKBeforePhysicsV2> updatedFBBIK1;

		// Token: 0x14000099 RID: 153
		// (add) Token: 0x06000A08 RID: 2568 RVA: 0x0002D12C File Offset: 0x0002B32C
		// (remove) Token: 0x06000A09 RID: 2569 RVA: 0x0002D164 File Offset: 0x0002B364
		public event Action<IKBeforePhysicsV2> updatingFBBIK2;

		// Token: 0x1400009A RID: 154
		// (add) Token: 0x06000A0A RID: 2570 RVA: 0x0002D19C File Offset: 0x0002B39C
		// (remove) Token: 0x06000A0B RID: 2571 RVA: 0x0002D1D4 File Offset: 0x0002B3D4
		public event Action<IKBeforePhysicsV2> updatedFBBIK2;

		// Token: 0x1400009B RID: 155
		// (add) Token: 0x06000A0C RID: 2572 RVA: 0x0002D20C File Offset: 0x0002B40C
		// (remove) Token: 0x06000A0D RID: 2573 RVA: 0x0002D244 File Offset: 0x0002B444
		public event Action<IKBeforePhysicsV2> updatingFBBIK3;

		// Token: 0x1400009C RID: 156
		// (add) Token: 0x06000A0E RID: 2574 RVA: 0x0002D27C File Offset: 0x0002B47C
		// (remove) Token: 0x06000A0F RID: 2575 RVA: 0x0002D2B4 File Offset: 0x0002B4B4
		public event Action<IKBeforePhysicsV2> updatedFBBIK3;

		// Token: 0x1400009D RID: 157
		// (add) Token: 0x06000A10 RID: 2576 RVA: 0x0002D2EC File Offset: 0x0002B4EC
		// (remove) Token: 0x06000A11 RID: 2577 RVA: 0x0002D324 File Offset: 0x0002B524
		public event Action<CustomUpdatedMonobehaviourBase> puppetUpdating;

		// Token: 0x1400009E RID: 158
		// (add) Token: 0x06000A12 RID: 2578 RVA: 0x0002D35C File Offset: 0x0002B55C
		// (remove) Token: 0x06000A13 RID: 2579 RVA: 0x0002D394 File Offset: 0x0002B594
		public event Action<CustomUpdatedMonobehaviourBase> puppetUpdated;

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000A14 RID: 2580 RVA: 0x0002D3C9 File Offset: 0x0002B5C9
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

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000A15 RID: 2581 RVA: 0x0002D3EB File Offset: 0x0002B5EB
		public sealed override FullBodyBipedIK userFullBodyBipedIK
		{
			get
			{
				return this.m_pelvis;
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000A16 RID: 2582 RVA: 0x0002D3F3 File Offset: 0x0002B5F3
		public override int cantidadDeIKs
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000A17 RID: 2583 RVA: 0x0002D3F6 File Offset: 0x0002B5F6
		public override int cantidadDeLayers
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x0002D3FC File Offset: 0x0002B5FC
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
			if (this.m_segundario == null)
			{
				throw new ArgumentNullException("m_segundario", "m_segundario null reference.");
			}
			if (this.m_pelvis == null)
			{
				throw new ArgumentNullException("m_pelvis", "m_pelvis null reference.");
			}
			this.m_fullBodyBipedIKs.Add(this.m_primario);
			if (this.m_pelvis != null)
			{
				this.m_fullBodyBipedIKs.Add(this.m_pelvis);
			}
			if (this.m_segundario != null)
			{
				this.m_fullBodyBipedIKs.Add(this.m_segundario);
			}
			this.m_layerZero.Add(this.m_primario);
			if (this.m_pelvis != null)
			{
				this.m_layerPelvis.Add(this.m_pelvis);
			}
			if (this.m_segundario != null)
			{
				this.m_layerTwo.Add(this.m_segundario);
			}
			base.AwakeUnityEvent();
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x0002D526 File Offset: 0x0002B726
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x0002D52E File Offset: 0x0002B72E
		public override int IDDeIK(Component IK)
		{
			if (IK == this.m_primario)
			{
				return 0;
			}
			if (IK == this.m_pelvis)
			{
				return 1;
			}
			if (IK == this.m_segundario)
			{
				return 2;
			}
			return -1;
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x0002D561 File Offset: 0x0002B761
		public override int LayerDeIK(Component IK)
		{
			return this.IDDeIK(IK);
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x0002D56A File Offset: 0x0002B76A
		public override int IndexEnLayerDeIK(Component IK, out bool ultimoDeLayer)
		{
			ultimoDeLayer = true;
			if (this.IDDeIK(IK) >= 0)
			{
				return 0;
			}
			return -1;
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x0002D57C File Offset: 0x0002B77C
		public sealed override FullBodyBipedIK ObtenerFullBodyBipedIKDeID(int index)
		{
			switch (index)
			{
			case 0:
				return this.m_primario;
			case 1:
				return this.m_pelvis;
			case 2:
				return this.m_segundario;
			default:
				return null;
			}
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x0002D5A8 File Offset: 0x0002B7A8
		[Obsolete("", true)]
		public sealed override FullBodyBipedIK ObtenerFullBodyBipedIKLayer(int layer)
		{
			return this.m_fullBodyBipedIK;
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x0002D5B0 File Offset: 0x0002B7B0
		public override IReadOnlyList<Component> SortedIKsDeLayer(int layer)
		{
			switch (layer)
			{
			case 0:
				return this.m_layerZero;
			case 1:
				return this.m_layerPelvis;
			case 2:
				return this.m_layerTwo;
			default:
				return null;
			}
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x0002D5DC File Offset: 0x0002B7DC
		public override void SwitchLayerIks(int layer)
		{
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x0002D5DE File Offset: 0x0002B7DE
		protected override IReadOnlyList<FullBodyBipedIK> ObtenerAllFullBodyBipedIKSortedNonAlloc()
		{
			return this.m_fullBodyBipedIKs;
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x0002D5E6 File Offset: 0x0002B7E6
		public override int CantidadDePasadasDeIK(int IKIndex)
		{
			switch (IKIndex)
			{
			case 0:
				return 1;
			case 1:
				return 2;
			case 2:
				return 2;
			default:
				return -1;
			}
		}

		// Token: 0x04000620 RID: 1568
		private MonoBehaviour character;

		// Token: 0x04000621 RID: 1569
		[Obsolete("ahora hay dos", true)]
		private FullBodyBipedIK m_fullBodyBipedIK;

		// Token: 0x04000622 RID: 1570
		[SerializeField]
		private FullBodyBipedIK m_primario;

		// Token: 0x04000623 RID: 1571
		[SerializeField]
		private FullBodyBipedIK m_pelvis;

		// Token: 0x04000624 RID: 1572
		[SerializeField]
		private FullBodyBipedIK m_segundario;

		// Token: 0x04000625 RID: 1573
		private List<FullBodyBipedIK> m_layerZero = new List<FullBodyBipedIK>();

		// Token: 0x04000626 RID: 1574
		private List<FullBodyBipedIK> m_layerPelvis = new List<FullBodyBipedIK>();

		// Token: 0x04000627 RID: 1575
		private List<FullBodyBipedIK> m_layerTwo = new List<FullBodyBipedIK>();

		// Token: 0x04000628 RID: 1576
		private List<FullBodyBipedIK> m_fullBodyBipedIKs = new List<FullBodyBipedIK>();
	}
}
