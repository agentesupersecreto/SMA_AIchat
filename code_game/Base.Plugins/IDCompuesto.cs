using System;

// Token: 0x02000026 RID: 38
[Serializable]
public struct IDCompuesto : IEquatable<IDCompuesto>
{
	// Token: 0x06000165 RID: 357 RVA: 0x0000904D File Offset: 0x0000724D
	public IDCompuesto(int id1, int id2)
	{
		this.ID1 = id1;
		this.ID2 = id2;
	}

	// Token: 0x1700001D RID: 29
	// (get) Token: 0x06000166 RID: 358 RVA: 0x0000905D File Offset: 0x0000725D
	public long ID
	{
		get
		{
			return IDCompuesto.Componer(this.ID1, this.ID2);
		}
	}

	// Token: 0x06000167 RID: 359 RVA: 0x00009070 File Offset: 0x00007270
	public override int GetHashCode()
	{
		return this.ID.GetHashCode();
	}

	// Token: 0x06000168 RID: 360 RVA: 0x0000908B File Offset: 0x0000728B
	public override bool Equals(object obj)
	{
		return obj is IDCompuesto && this.Equals((IDCompuesto)obj);
	}

	// Token: 0x06000169 RID: 361 RVA: 0x000090A3 File Offset: 0x000072A3
	public static long Componer(int a, int b)
	{
		return ((long)a << 32) + (long)b;
	}

	// Token: 0x0600016A RID: 362 RVA: 0x000090AD File Offset: 0x000072AD
	public static void Descomponer(long compuesto, out int a, out int b)
	{
		b = (int)compuesto;
		a = (int)(compuesto - (long)b >> 32);
	}

	// Token: 0x0600016B RID: 363 RVA: 0x000090BE File Offset: 0x000072BE
	public static bool operator ==(IDCompuesto left, IDCompuesto right)
	{
		return object.Equals(left, right);
	}

	// Token: 0x0600016C RID: 364 RVA: 0x000090D1 File Offset: 0x000072D1
	public static bool operator !=(IDCompuesto left, IDCompuesto right)
	{
		return !object.Equals(left, right);
	}

	// Token: 0x0600016D RID: 365 RVA: 0x000090E7 File Offset: 0x000072E7
	public bool Equals(IDCompuesto other)
	{
		return other.ID == this.ID;
	}

	// Token: 0x04000058 RID: 88
	public int ID1;

	// Token: 0x04000059 RID: 89
	public int ID2;
}
