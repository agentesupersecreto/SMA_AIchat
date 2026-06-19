using System;

namespace Assets
{
	// Token: 0x0200011D RID: 285
	[Serializable]
	public struct DiccLayer : IComparable, IComparable<int>, IConvertible, IEquatable<int>, IFormattable, IComparable<DiccLayer>, IEquatable<DiccLayer>
	{
		// Token: 0x0600080D RID: 2061 RVA: 0x0001B85D File Offset: 0x00019A5D
		public int CompareTo(object obj)
		{
			return this.layer.CompareTo(obj);
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x0001B86B File Offset: 0x00019A6B
		public int CompareTo(int other)
		{
			return this.layer.CompareTo(other);
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x0001B879 File Offset: 0x00019A79
		public int CompareTo(DiccLayer other)
		{
			return this.CompareTo(other.layer);
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x0001B887 File Offset: 0x00019A87
		public bool Equals(int other)
		{
			return this.layer.Equals(other);
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x0001B895 File Offset: 0x00019A95
		public bool Equals(DiccLayer other)
		{
			return this.Equals(other.layer);
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x0001B8A3 File Offset: 0x00019AA3
		public override bool Equals(object obj)
		{
			return this.layer.Equals(obj);
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x0001B8B1 File Offset: 0x00019AB1
		public override int GetHashCode()
		{
			return this.layer.GetHashCode();
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x0001B8C0 File Offset: 0x00019AC0
		public static implicit operator DiccLayer(int Layer)
		{
			return new DiccLayer
			{
				layer = Layer
			};
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0001B8DE File Offset: 0x00019ADE
		public TypeCode GetTypeCode()
		{
			return this.layer.GetTypeCode();
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0001B8EB File Offset: 0x00019AEB
		public bool ToBoolean(IFormatProvider provider)
		{
			return ((IConvertible)this.layer).ToBoolean(provider);
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x0001B8FE File Offset: 0x00019AFE
		public byte ToByte(IFormatProvider provider)
		{
			return ((IConvertible)this.layer).ToByte(provider);
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x0001B911 File Offset: 0x00019B11
		public char ToChar(IFormatProvider provider)
		{
			return ((IConvertible)this.layer).ToChar(provider);
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x0001B924 File Offset: 0x00019B24
		public DateTime ToDateTime(IFormatProvider provider)
		{
			return ((IConvertible)this.layer).ToDateTime(provider);
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x0001B937 File Offset: 0x00019B37
		public decimal ToDecimal(IFormatProvider provider)
		{
			return ((IConvertible)this.layer).ToDecimal(provider);
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x0001B94A File Offset: 0x00019B4A
		public double ToDouble(IFormatProvider provider)
		{
			return ((IConvertible)this.layer).ToDouble(provider);
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x0001B95D File Offset: 0x00019B5D
		public short ToInt16(IFormatProvider provider)
		{
			return ((IConvertible)this.layer).ToInt16(provider);
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x0001B970 File Offset: 0x00019B70
		public int ToInt32(IFormatProvider provider)
		{
			return ((IConvertible)this.layer).ToInt32(provider);
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x0001B983 File Offset: 0x00019B83
		public long ToInt64(IFormatProvider provider)
		{
			return ((IConvertible)this.layer).ToInt64(provider);
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x0001B996 File Offset: 0x00019B96
		public sbyte ToSByte(IFormatProvider provider)
		{
			return ((IConvertible)this.layer).ToSByte(provider);
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x0001B9A9 File Offset: 0x00019BA9
		public float ToSingle(IFormatProvider provider)
		{
			return ((IConvertible)this.layer).ToSingle(provider);
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x0001B9BC File Offset: 0x00019BBC
		public string ToString(IFormatProvider provider)
		{
			return this.layer.ToString(provider);
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x0001B9CA File Offset: 0x00019BCA
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return this.layer.ToString(format, formatProvider);
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x0001B9D9 File Offset: 0x00019BD9
		public object ToType(Type conversionType, IFormatProvider provider)
		{
			return ((IConvertible)this.layer).ToType(conversionType, provider);
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x0001B9ED File Offset: 0x00019BED
		public ushort ToUInt16(IFormatProvider provider)
		{
			return ((IConvertible)this.layer).ToUInt16(provider);
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0001BA00 File Offset: 0x00019C00
		public uint ToUInt32(IFormatProvider provider)
		{
			return ((IConvertible)this.layer).ToUInt32(provider);
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x0001BA13 File Offset: 0x00019C13
		public ulong ToUInt64(IFormatProvider provider)
		{
			return ((IConvertible)this.layer).ToUInt64(provider);
		}

		// Token: 0x0400022B RID: 555
		public int layer;
	}
}
