using System;
using System.Globalization;
using UnityEngine;

// Token: 0x02000046 RID: 70
[Serializable]
public class UDateTime : ISerializationCallbackReceiver
{
	// Token: 0x17000032 RID: 50
	// (get) Token: 0x06000249 RID: 585 RVA: 0x0000C282 File Offset: 0x0000A482
	public string serialTime
	{
		get
		{
			this.OnBeforeSerialize();
			return this._dateTime;
		}
	}

	// Token: 0x0600024A RID: 586 RVA: 0x0000C290 File Offset: 0x0000A490
	public static implicit operator DateTime(UDateTime udt)
	{
		udt.OnAfterDeserialize();
		return udt.dateTime;
	}

	// Token: 0x0600024B RID: 587 RVA: 0x0000C29E File Offset: 0x0000A49E
	public static implicit operator UDateTime(DateTime dt)
	{
		UDateTime udateTime = new UDateTime();
		udateTime.dateTime = dt;
		udateTime.OnBeforeSerialize();
		return udateTime;
	}

	// Token: 0x0600024C RID: 588 RVA: 0x0000C2B2 File Offset: 0x0000A4B2
	public static implicit operator UDateTime(string serialized)
	{
		UDateTime udateTime = new UDateTime();
		udateTime._dateTime = serialized;
		udateTime.OnAfterDeserialize();
		return udateTime;
	}

	// Token: 0x0600024D RID: 589 RVA: 0x0000C2C6 File Offset: 0x0000A4C6
	public void OnAfterDeserialize()
	{
		this.dateTime = UDateTime.Deserialize(this._dateTime);
	}

	// Token: 0x0600024E RID: 590 RVA: 0x0000C2D9 File Offset: 0x0000A4D9
	public void OnBeforeSerialize()
	{
		this._dateTime = UDateTime.Serialize(this.dateTime);
	}

	// Token: 0x0600024F RID: 591 RVA: 0x0000C2EC File Offset: 0x0000A4EC
	public string Serialized()
	{
		this.OnBeforeSerialize();
		return this._dateTime;
	}

	// Token: 0x06000250 RID: 592 RVA: 0x0000C2FA File Offset: 0x0000A4FA
	public static string Serialize(DateTime dateTime)
	{
		return dateTime.ToString("o", CultureInfo.InvariantCulture);
	}

	// Token: 0x06000251 RID: 593 RVA: 0x0000C310 File Offset: 0x0000A510
	public static DateTime Deserialize(string date)
	{
		if (string.IsNullOrWhiteSpace(date))
		{
			return DateTime.MinValue;
		}
		DateTime dateTime;
		if (DateTime.TryParseExact(date, "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dateTime))
		{
			return dateTime;
		}
		if (DateTime.TryParse(date, out dateTime))
		{
			return dateTime;
		}
		return DateTime.MinValue;
	}

	// Token: 0x06000252 RID: 594 RVA: 0x0000C358 File Offset: 0x0000A558
	public static bool IsCorrupted(UDateTime udt)
	{
		DateTime dateTime;
		return string.IsNullOrWhiteSpace(udt._dateTime) || (!DateTime.TryParseExact(udt._dateTime, "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dateTime) && !DateTime.TryParse(udt._dateTime, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime));
	}

	// Token: 0x0400007F RID: 127
	[HideInInspector]
	public DateTime dateTime;

	// Token: 0x04000080 RID: 128
	[ReadOnlyUI]
	[SerializeField]
	private string _dateTime;
}
