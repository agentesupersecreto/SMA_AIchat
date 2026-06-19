using System;
using System.Collections.Generic;
using Assets.Base.RootMotion.BeachGirl.Runtime;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x02000100 RID: 256
	public sealed class FemaleIKUpdater : IKBeforePhysicsBase
	{
		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x0002B4BB File Offset: 0x000296BB
		private IFemaleFullBodyBipedIKs FemaleFullBodyBipedIKs
		{
			get
			{
				if (this.m_femaleFullBodyBipedIKs == null)
				{
					this.m_femaleFullBodyBipedIKs = base.GetComponentInChildren<IFemaleFullBodyBipedIKs>();
				}
				return this.m_femaleFullBodyBipedIKs;
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000983 RID: 2435 RVA: 0x0002B4D7 File Offset: 0x000296D7
		public sealed override FullBodyBipedIK userFullBodyBipedIK
		{
			get
			{
				IFemaleFullBodyBipedIKs femaleFullBodyBipedIKs = this.FemaleFullBodyBipedIKs;
				if (femaleFullBodyBipedIKs == null)
				{
					return null;
				}
				return femaleFullBodyBipedIKs.user;
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x0002B4EC File Offset: 0x000296EC
		public sealed override int cantidadDeIKs
		{
			get
			{
				IFemaleFullBodyBipedIKs femaleFullBodyBipedIKs = this.FemaleFullBodyBipedIKs;
				return ((femaleFullBodyBipedIKs != null) ? new int?(femaleFullBodyBipedIKs.cantidadDeIKs) : null).GetValueOrDefault();
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000985 RID: 2437 RVA: 0x0002B520 File Offset: 0x00029720
		public override int cantidadDeLayers
		{
			get
			{
				IFemaleFullBodyBipedIKs femaleFullBodyBipedIKs = this.FemaleFullBodyBipedIKs;
				return ((femaleFullBodyBipedIKs != null) ? new int?(femaleFullBodyBipedIKs.cantidadDeLayers) : null).GetValueOrDefault();
			}
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x0002B554 File Offset: 0x00029754
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x0002B55C File Offset: 0x0002975C
		public sealed override int IDDeIK(Component IK)
		{
			if (this.FemaleFullBodyBipedIKs == null)
			{
				return -1;
			}
			return this.FemaleFullBodyBipedIKs.GetId(IK as FullBodyBipedIK);
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x0002B579 File Offset: 0x00029779
		public override int LayerDeIK(Component IK)
		{
			if (this.FemaleFullBodyBipedIKs == null)
			{
				return -1;
			}
			return this.FemaleFullBodyBipedIKs.GetLayerDeIK(IK as FullBodyBipedIK);
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0002B596 File Offset: 0x00029796
		public override int IndexEnLayerDeIK(Component IK, out bool ultimoDeLayer)
		{
			ultimoDeLayer = true;
			if (this.FemaleFullBodyBipedIKs == null)
			{
				return -1;
			}
			return this.FemaleFullBodyBipedIKs.GetIndexInLayerDeIK(IK as FullBodyBipedIK, out ultimoDeLayer);
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x0002B5B7 File Offset: 0x000297B7
		public sealed override FullBodyBipedIK ObtenerFullBodyBipedIKDeID(int id)
		{
			if (this.FemaleFullBodyBipedIKs == null)
			{
				return null;
			}
			return this.FemaleFullBodyBipedIKs.ObtenerCurrentFullBodyBipedIKDeID(id);
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x0002B5CF File Offset: 0x000297CF
		public override void SwitchLayerIks(int layer)
		{
			if (this.FemaleFullBodyBipedIKs == null)
			{
				return;
			}
			if (layer == 0)
			{
				this.FemaleFullBodyBipedIKs.SwitchPrimarios();
				return;
			}
			if (layer != 1)
			{
				throw new ArgumentOutOfRangeException(layer.ToString());
			}
			this.FemaleFullBodyBipedIKs.SwitchSegundarios();
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x0002B607 File Offset: 0x00029807
		public override FullBodyBipedIK ObtenerFullBodyBipedIKLayer(int layer)
		{
			if (this.FemaleFullBodyBipedIKs == null)
			{
				return null;
			}
			return this.FemaleFullBodyBipedIKs.ObtenerCurrentFullBodyBipedIKDeLayer(layer);
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x0002B61F File Offset: 0x0002981F
		public override IReadOnlyList<Component> SortedIKsDeLayer(int layer)
		{
			if (this.FemaleFullBodyBipedIKs == null)
			{
				return null;
			}
			return this.FemaleFullBodyBipedIKs.ObtenerFullBodyBipedIKsDeLayer(layer);
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x0002B637 File Offset: 0x00029837
		protected override IReadOnlyList<FullBodyBipedIK> ObtenerAllFullBodyBipedIKSortedNonAlloc()
		{
			if (this.FemaleFullBodyBipedIKs == null)
			{
				return null;
			}
			return this.FemaleFullBodyBipedIKs.allFullBodyBipedIKs;
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0002B650 File Offset: 0x00029850
		public sealed override int CantidadDePasadasDeIK(int IKID)
		{
			Component component = base.IKDeID(IKID);
			return this.FemaleFullBodyBipedIKs.CantidadDePasadasDeIK(component as FullBodyBipedIK);
		}

		// Token: 0x040005E2 RID: 1506
		private IFemaleFullBodyBipedIKs m_femaleFullBodyBipedIKs;
	}
}
