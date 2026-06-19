using System;
using System.Collections.Generic;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Penes
{
	// Token: 0x0200007D RID: 125
	[RequireComponent(typeof(IPene))]
	[RequireComponent(typeof(PenisLinearChain))]
	public class PenisMassModSetter : CustomMonobehaviour
	{
		// Token: 0x06000348 RID: 840 RVA: 0x00009D90 File Offset: 0x00007F90
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_chain = base.GetComponent<PenisLinearChain>();
			this.m_penis = base.GetComponent<IPene>();
			if (this.m_penis == null)
			{
				throw new ArgumentNullException("m_penis", "m_penis null reference.");
			}
			if (this.m_chain == null)
			{
				throw new ArgumentNullException("m_chain", "m_chain null reference.");
			}
			if (!this.m_chain.isStared)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00009E04 File Offset: 0x00008004
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.pelvisMassGetter == null)
			{
				throw new ArgumentNullException("pelvisMassGetter", "pelvisMassGetter null reference.");
			}
			this.Initiate();
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00009E2C File Offset: 0x0000802C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_chain)
			{
				this.m_chain.updatedTotalMass -= this.M_chain_updatedTotalMass;
			}
			this.m_mods.ForEach(delegate(ModificadorDeFloat m)
			{
				if (m != null)
				{
					m.TryRemoverDeOwner(true);
				}
			});
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00009E90 File Offset: 0x00008090
		private void Initiate()
		{
			MassModifier componentNotNull = this.m_chain.rootPunto.principal.GetComponentNotNull<MassModifier>();
			this.m_mods.Add(componentNotNull.modificable.ObtenerModificadorNotNull(this));
			for (int i = 0; i < this.m_chain.puntosExcluyendoRootList.Count; i++)
			{
				MassModifier componentNotNull2 = this.m_chain.puntosExcluyendoRootList[i].principal.GetComponentNotNull<MassModifier>();
				this.m_mods.Add(componentNotNull2.modificable.ObtenerModificadorNotNull(this));
			}
			this.M_chain_updatedTotalMass(this.m_chain);
			this.m_chain.updatedTotalMass += this.M_chain_updatedTotalMass;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00009F3C File Offset: 0x0000813C
		private void M_chain_updatedTotalMass(PenisLinearChain obj)
		{
			int num = this.m_chain.cantidadDePuntos + 1;
			this.UpdateMassMod(0, num, obj, this.m_chain.rootPunto, this.m_mods[0]);
			for (int i = 0; i < this.m_chain.puntosExcluyendoRootList.Count; i++)
			{
				int num2 = i + 1;
				this.UpdateMassMod(num2, num, obj, this.m_chain.puntosExcluyendoRootList[i], this.m_mods[num2]);
			}
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00009FBC File Offset: 0x000081BC
		private void UpdateMassMod(int index, int cantidad, PenisLinearChain obj, PenisPoint item, ModificadorDeFloat mod)
		{
			float num = Mathf.Lerp(0.75f, 1f, Mathf.InverseLerp((float)cantidad, 1f, (float)(index + 1)));
			float num2 = this.pelvisMassGetter() * num * (this.m_penis.currentRealErectionValue / 100f) + obj.totalMass;
			mod.valor.valor = num2 / item.principal.mass;
		}

		// Token: 0x040001ED RID: 493
		public Func<float> pelvisMassGetter;

		// Token: 0x040001EE RID: 494
		private IPene m_penis;

		// Token: 0x040001EF RID: 495
		private PenisLinearChain m_chain;

		// Token: 0x040001F0 RID: 496
		[SerializeField]
		private List<ModificadorDeFloat> m_mods = new List<ModificadorDeFloat>();
	}
}
