using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Sonidos;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques
{
	// Token: 0x020002AD RID: 685
	public abstract class SonidosBlendingUnaVezDeToquesBase<TSonidoUnaVez> : SonidosUnaVezDeToquesBase<TSonidoUnaVez>, IReproductorDeBlendingSonidoDeToques, IReproductorDeSonidoDeToques, IReproductorDeSonidos, IReproductorDeBlendingSonidos where TSonidoUnaVez : class, ISonidoUnaVezBlending
	{
		// Token: 0x14000040 RID: 64
		// (add) Token: 0x06000F5C RID: 3932 RVA: 0x000465F0 File Offset: 0x000447F0
		// (remove) Token: 0x06000F5D RID: 3933 RVA: 0x00046628 File Offset: 0x00044828
		public event ModificarExtraDataDeBlendingSonidos registrandoToqueExtraData;

		// Token: 0x06000F5E RID: 3934 RVA: 0x00046660 File Offset: 0x00044860
		protected override object ObtenerExtraData(ICharacterUnico by, EstimuloTactil estimulo, SonidoProductor productor)
		{
			if (base.ObtenerExtraData(by, estimulo, productor) != null)
			{
				throw new NotSupportedException();
			}
			SonidoBlendingExtraData item = this.m_extraDataPool.GetItem();
			ModificarExtraDataDeBlendingSonidos modificarExtraDataDeBlendingSonidos = this.registrandoToqueExtraData;
			if (modificarExtraDataDeBlendingSonidos != null)
			{
				modificarExtraDataDeBlendingSonidos(estimulo, productor, item, this);
			}
			return item;
		}

		// Token: 0x06000F5F RID: 3935 RVA: 0x000466A0 File Offset: 0x000448A0
		protected override void LimpiandoPedidos()
		{
			base.LimpiandoPedidos();
			foreach (KeyValuePair<SonidoProductor, object> keyValuePair in this.m_extradataDeProductorEnFrameDicc)
			{
				this.m_extraDataPool.ReturnItem(keyValuePair.Value as SonidoBlendingExtraData);
			}
		}

		// Token: 0x06000F60 RID: 3936 RVA: 0x0004670C File Offset: 0x0004490C
		protected override void LoadExtraDataASlot(ref ReproductorDeSonidos.PedidoDeReporduccion pedido, ISonido slot, ref object extraData)
		{
			base.LoadExtraDataASlot(ref pedido, slot, ref extraData);
			SonidoBlendingExtraData sonidoBlendingExtraData = extraData as SonidoBlendingExtraData;
			if (sonidoBlendingExtraData == null)
			{
				return;
			}
			TSonidoUnaVez tsonidoUnaVez = slot as TSonidoUnaVez;
			if (tsonidoUnaVez == null)
			{
				return;
			}
			if (!sonidoBlendingExtraData.wasSet)
			{
				return;
			}
			tsonidoUnaVez.blendWeight = sonidoBlendingExtraData.blendWeight.Value;
		}

		// Token: 0x06000F61 RID: 3937 RVA: 0x00046768 File Offset: 0x00044968
		protected override object ResolverConflictoDeExtraData(object old, object @new)
		{
			SonidoBlendingExtraData sonidoBlendingExtraData = old as SonidoBlendingExtraData;
			SonidoBlendingExtraData sonidoBlendingExtraData2 = @new as SonidoBlendingExtraData;
			if (sonidoBlendingExtraData != null && sonidoBlendingExtraData2 != null)
			{
				SonidoBlendingExtraData item = this.m_extraDataPool.GetItem();
				if (sonidoBlendingExtraData.wasSet && sonidoBlendingExtraData2.wasSet)
				{
					item.SetValue(sonidoBlendingExtraData.blendWeight.Value * sonidoBlendingExtraData2.blendWeight.Value);
				}
				else if (sonidoBlendingExtraData.wasSet)
				{
					item.SetValue(sonidoBlendingExtraData.blendWeight.Value);
				}
				else if (sonidoBlendingExtraData2.wasSet)
				{
					item.SetValue(sonidoBlendingExtraData2.blendWeight.Value);
				}
				this.m_extraDataPool.ReturnItem(sonidoBlendingExtraData);
				this.m_extraDataPool.ReturnItem(sonidoBlendingExtraData2);
				return item;
			}
			if (sonidoBlendingExtraData != null)
			{
				SonidoBlendingExtraData item2 = this.m_extraDataPool.GetItem();
				if (sonidoBlendingExtraData.wasSet)
				{
					item2.SetValue(sonidoBlendingExtraData.blendWeight.Value);
				}
				this.m_extraDataPool.ReturnItem(sonidoBlendingExtraData);
				return item2;
			}
			if (sonidoBlendingExtraData2 != null)
			{
				SonidoBlendingExtraData item3 = this.m_extraDataPool.GetItem();
				if (sonidoBlendingExtraData2.wasSet)
				{
					item3.SetValue(sonidoBlendingExtraData2.blendWeight.Value);
				}
				this.m_extraDataPool.ReturnItem(sonidoBlendingExtraData2);
				return item3;
			}
			return null;
		}

		// Token: 0x04000CC4 RID: 3268
		private SimplePoolDeClearables<SonidoBlendingExtraData> m_extraDataPool = new SimplePoolDeClearables<SonidoBlendingExtraData>();
	}
}
