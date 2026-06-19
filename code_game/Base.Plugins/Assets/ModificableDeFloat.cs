using System;

namespace Assets
{
	// Token: 0x020000FF RID: 255
	[Serializable]
	public class ModificableDeFloat : MultipleModificable<ModificadorDeFloat, ModificadorDeFloatBase.Data>
	{
		// Token: 0x06000731 RID: 1841 RVA: 0x00019977 File Offset: 0x00017B77
		public ModificableDeFloat(float DefaultValueDeModificadorAlInstanciar)
		{
			this.defaultValueDeModificadorAlInstanciar = DefaultValueDeModificadorAlInstanciar;
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x00019991 File Offset: 0x00017B91
		protected sealed override ModificadorDeFloat InstanciarModificador(int id)
		{
			return new ModificadorDeFloat(id, this.defaultValueDeModificadorAlInstanciar, this);
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x000199A0 File Offset: 0x00017BA0
		public void SetAllTo(float valor)
		{
			base.SetAllTo(new ModificadorDeFloatBase.Data
			{
				valor = valor
			});
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x000199C4 File Offset: 0x00017BC4
		public float ModificarValor(float valor)
		{
			ModificadorDeFloatBase.Data data = default(ModificadorDeFloatBase.Data);
			data.valor = valor;
			base.ModificarValor(ref data);
			return data.valor;
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x000199F0 File Offset: 0x00017BF0
		public float PromediarConValor(float valor)
		{
			ModificadorDeFloatBase.Data data = default(ModificadorDeFloatBase.Data);
			data.valor = valor;
			base.PromediarConValor(ref data);
			return data.valor;
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x00019A1C File Offset: 0x00017C1C
		public float PromediarNormalizadoConValor(float valor)
		{
			ModificadorDeFloatBase.Data data = default(ModificadorDeFloatBase.Data);
			data.valor = valor;
			base.AdicionarValorIncluyendo(ref data);
			if (data.valor == 0f)
			{
				return 0f;
			}
			ModificadorDeFloatBase.Data data2 = default(ModificadorDeFloatBase.Data);
			data2.valor = valor;
			base.PromediarNormalizadoConValor(ref data2);
			return data2.valor;
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x00019A74 File Offset: 0x00017C74
		public float PromediarSinValor()
		{
			ModificadorDeFloatBase.Data data;
			base.PromediarSinValor(out data);
			return data.valor;
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x00019A90 File Offset: 0x00017C90
		public float AdicinarValorIncluyendo(float valor)
		{
			ModificadorDeFloatBase.Data data = default(ModificadorDeFloatBase.Data);
			data.valor = valor;
			base.AdicionarValorIncluyendo(ref data);
			return data.valor;
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x00019ABC File Offset: 0x00017CBC
		public float MaximoValorIncluyendo(float valor)
		{
			ModificadorDeFloatBase.Data data = default(ModificadorDeFloatBase.Data);
			data.valor = valor;
			base.MaximoValorIncluyendo(ref data);
			return data.valor;
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x00019AE8 File Offset: 0x00017CE8
		public float MinimoValorIncluyendo(float valor)
		{
			ModificadorDeFloatBase.Data data = default(ModificadorDeFloatBase.Data);
			data.valor = valor;
			base.MinimoValorIncluyendo(ref data);
			return data.valor;
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00019B14 File Offset: 0x00017D14
		public float MaximoValorAbsolutoIncluyendo(float valor)
		{
			ModificadorDeFloatBase.Data data = default(ModificadorDeFloatBase.Data);
			data.valor = valor;
			base.MaximoValorAbsolutoIncluyendo(ref data);
			return data.valor;
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x00019B40 File Offset: 0x00017D40
		public float? TryObtenerMaximoValorfloat()
		{
			ModificadorDeFloatBase.Data? data = base.TryObtenerMaximoValor();
			if (data == null)
			{
				return null;
			}
			return new float?(data.Value.valor);
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00019B78 File Offset: 0x00017D78
		public float? TryObtenerModificadorfloat()
		{
			ModificadorDeFloatBase.Data? data = base.TryObtenerModificador();
			if (data == null)
			{
				return null;
			}
			return new float?(data.Value.valor);
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x00019BB0 File Offset: 0x00017DB0
		public float? TryObtenerPromediofloat()
		{
			ModificadorDeFloatBase.Data? data = base.TryObtenerPromedio();
			if (data == null)
			{
				return null;
			}
			return new float?(data.Value.valor);
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x00019BE8 File Offset: 0x00017DE8
		public float? TryObtenerPromedioNormalizadofloat()
		{
			ModificadorDeFloatBase.Data? data = base.TryAdicionarValorIncluyendo();
			if (data == null)
			{
				return null;
			}
			if (data.Value.valor == 0f)
			{
				return new float?(0f);
			}
			ModificadorDeFloatBase.Data? data2 = base.TryObtenerPromedioNormalizado();
			if (data2 == null)
			{
				return null;
			}
			return new float?(data2.Value.valor);
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00019C58 File Offset: 0x00017E58
		public float? TryObtenerMinimofloat()
		{
			ModificadorDeFloatBase.Data? data = base.TryObtenerMinimoValor();
			if (data == null)
			{
				return null;
			}
			return new float?(data.Value.valor);
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00019C90 File Offset: 0x00017E90
		public float? TryObtenerMaximoFloatAbsoluto()
		{
			ModificadorDeFloatBase.Data? data = base.TryObtenerMaximoValorAbsoluto();
			if (data == null)
			{
				return null;
			}
			return new float?(data.Value.valor);
		}

		// Token: 0x040001FD RID: 509
		public float defaultValueDeModificadorAlInstanciar = 1f;
	}
}
