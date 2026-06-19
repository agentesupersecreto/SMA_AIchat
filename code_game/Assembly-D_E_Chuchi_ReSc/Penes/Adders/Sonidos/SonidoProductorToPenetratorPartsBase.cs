using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Sonidos;
using Assets._ReusableScripts.Sonidos.Adders;

namespace Assets._ReusableScripts.CuchiCuchi.Penes.Adders.Sonidos
{
	// Token: 0x0200014D RID: 333
	public abstract class SonidoProductorToPenetratorPartsBase<TProductor, TPenetrator> : SonidoBehaviourAdder<TProductor> where TProductor : SonidoProductor where TPenetrator : Penetrador
	{
		// Token: 0x17000196 RID: 406
		// (get) Token: 0x0600078C RID: 1932 RVA: 0x0002396A File Offset: 0x00021B6A
		public sealed override object addedResult
		{
			get
			{
				return this.m_added;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x0600078D RID: 1933 RVA: 0x0000D704 File Offset: 0x0000B904
		protected override BehaviourAdder.AddType addType
		{
			get
			{
				return BehaviourAdder.AddType.custom;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x0600078E RID: 1934 RVA: 0x00004252 File Offset: 0x00002452
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00023972 File Offset: 0x00021B72
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.textura = TexturaDeObjetoSonoro.skin;
			this.forma = FormaDeObjetoSonoro.macisa;
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x00023988 File Offset: 0x00021B88
		public override void OnUpdateEvent1()
		{
			this.TryAdd();
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x00023990 File Offset: 0x00021B90
		private void TryAdd()
		{
			TPenetrator componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null || !componentEnRoot.isStared)
			{
				return;
			}
			this.m_added = new List<TProductor>();
			foreach (PenisPart penisPart in componentEnRoot.enumerator)
			{
				TProductor componentNotNull = penisPart.physicBone.GetComponentNotNull<TProductor>();
				this.m_added.Add(componentNotNull);
				base.SetConfig(componentNotNull);
				this.OnSonidoProductorAdded(componentNotNull);
			}
			base.OnAddBehaviour();
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void AddBehaviour()
		{
		}

		// Token: 0x06000793 RID: 1939
		protected abstract void OnSonidoProductorAdded(TProductor added);

		// Token: 0x04000606 RID: 1542
		private List<TProductor> m_added;
	}
}
