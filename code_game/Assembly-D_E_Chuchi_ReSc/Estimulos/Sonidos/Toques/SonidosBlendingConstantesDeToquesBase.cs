using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Sonidos;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques
{
	// Token: 0x020002AB RID: 683
	public abstract class SonidosBlendingConstantesDeToquesBase<TSonidoConstanteConFlag> : SonidosConstantesDeToquesBase<TSonidoConstanteConFlag>, IReproductorDeBlendingSonidoDeToques, IReproductorDeSonidoDeToques, IReproductorDeSonidos, IReproductorDeBlendingSonidos where TSonidoConstanteConFlag : class, ISonidoConstanteBlendingConFlag
	{
		// Token: 0x1400003E RID: 62
		// (add) Token: 0x06000F41 RID: 3905 RVA: 0x00045FA4 File Offset: 0x000441A4
		// (remove) Token: 0x06000F42 RID: 3906 RVA: 0x00045FDC File Offset: 0x000441DC
		public event ModificarExtraDataDeBlendingSonidos registrandoToqueExtraData;

		// Token: 0x06000F43 RID: 3907 RVA: 0x00046014 File Offset: 0x00044214
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

		// Token: 0x06000F44 RID: 3908 RVA: 0x00046054 File Offset: 0x00044254
		protected override void LimpiandoPedidos()
		{
			base.LimpiandoPedidos();
			foreach (KeyValuePair<SonidoProductor, object> keyValuePair in this.m_extradataDeProductorEnFrameDicc)
			{
				this.m_extraDataPool.ReturnItem(keyValuePair.Value as SonidoBlendingExtraData);
			}
		}

		// Token: 0x06000F45 RID: 3909 RVA: 0x000460C0 File Offset: 0x000442C0
		protected override void LoadExtraDataASlot(ref ReproductorDeSonidos.PedidoDeReporduccion pedido, ISonido slot, ref object extraData)
		{
			base.LoadExtraDataASlot(ref pedido, slot, ref extraData);
			SonidoBlendingExtraData sonidoBlendingExtraData = extraData as SonidoBlendingExtraData;
			if (sonidoBlendingExtraData == null)
			{
				return;
			}
			TSonidoConstanteConFlag tsonidoConstanteConFlag = slot as TSonidoConstanteConFlag;
			if (tsonidoConstanteConFlag == null)
			{
				return;
			}
			if (!sonidoBlendingExtraData.wasSet)
			{
				return;
			}
			tsonidoConstanteConFlag.blendWeight = sonidoBlendingExtraData.blendWeight.Value;
		}

		// Token: 0x06000F46 RID: 3910 RVA: 0x0004611C File Offset: 0x0004431C
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

		// Token: 0x04000CBD RID: 3261
		private SimplePoolDeClearables<SonidoBlendingExtraData> m_extraDataPool = new SimplePoolDeClearables<SonidoBlendingExtraData>();
	}
}
