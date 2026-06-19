using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.Sonidos;
using Assets._ReusableScripts.Sonidos.Adders;
using RootMotion.Dynamics;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Adders.Sonidos
{
	// Token: 0x02000139 RID: 313
	public abstract class SonidoProductorToMusclesAdderBase<TProductor> : SonidoBehaviourAdder<TProductor> where TProductor : SonidoProductor
	{
		// Token: 0x17000135 RID: 309
		// (get) Token: 0x0600063C RID: 1596 RVA: 0x0002325D File Offset: 0x0002145D
		public sealed override object addedResult
		{
			get
			{
				return this.m_added;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x00014CB2 File Offset: 0x00012EB2
		protected override BehaviourAdder.AddType addType
		{
			get
			{
				return BehaviourAdder.AddType.custom;
			}
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x00023265 File Offset: 0x00021465
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.textura = TexturaDeObjetoSonoro.skin;
			this.forma = FormaDeObjetoSonoro.macisa;
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x0002327C File Offset: 0x0002147C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			PuppetMaster componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("puppet", "puppet null reference.");
			}
			if (componentEnRoot.initiated)
			{
				base.OnAddBehaviour();
				return;
			}
			PuppetMaster puppetMaster = componentEnRoot;
			puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Combine(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(base.OnAddBehaviour));
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x000232E4 File Offset: 0x000214E4
		protected override void AddBehaviour()
		{
			PuppetMaster componentEnRoot = this.GetComponentEnRoot(false);
			PuppetMaster puppetMaster = componentEnRoot;
			puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Remove(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(base.OnAddBehaviour));
			this.m_added = new List<TProductor>();
			for (int i = 0; i < componentEnRoot.muscles.Length; i++)
			{
				Muscle m = componentEnRoot.muscles[i];
				TProductor componentNotNull = m.rigidbody.GetComponentNotNull<TProductor>();
				base.SetConfig(componentNotNull);
				MuscleTexturaPar muscleTexturaPar = this.texturaOverrides.FirstOrDefault((MuscleTexturaPar par) => par.muscle == m.props.group);
				MuscleFormaPar muscleFormaPar = this.formaOverrides.FirstOrDefault((MuscleFormaPar par) => par.muscle == m.props.group);
				if (muscleTexturaPar != null)
				{
					componentNotNull.textura = muscleTexturaPar.textura;
				}
				if (muscleFormaPar != null)
				{
					componentNotNull.forma = muscleFormaPar.forma;
				}
				this.m_added.Add(componentNotNull);
				this.OnSonidoProductorAdded(componentNotNull);
			}
		}

		// Token: 0x06000641 RID: 1601
		protected abstract void OnSonidoProductorAdded(TProductor added);

		// Token: 0x04000512 RID: 1298
		private List<TProductor> m_added;

		// Token: 0x04000513 RID: 1299
		public List<MuscleTexturaPar> texturaOverrides = new List<MuscleTexturaPar>();

		// Token: 0x04000514 RID: 1300
		public List<MuscleFormaPar> formaOverrides = new List<MuscleFormaPar>();
	}
}
