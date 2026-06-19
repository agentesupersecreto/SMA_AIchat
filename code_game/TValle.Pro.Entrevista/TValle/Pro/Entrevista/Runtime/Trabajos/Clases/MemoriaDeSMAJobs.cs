using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.Tools.Runtime.Memory;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Clases
{
	// Token: 0x02000075 RID: 117
	[MemoriaFunctions]
	public static class MemoriaDeSMAJobs
	{
		// Token: 0x060004ED RID: 1261 RVA: 0x0001C984 File Offset: 0x0001AB84
		public static bool ConoceCharacterComoEmpleador(IContextMemory memoriaJobChar, string otherCharacterID, bool defaultValue = false)
		{
			List<string> list;
			memoriaJobChar.TryFindDataArrayNull<string>("Conocidos.Employer", out list);
			if (list == null)
			{
				return defaultValue;
			}
			return list.Contains(otherCharacterID);
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0001C9AC File Offset: 0x0001ABAC
		public static bool ConoceCharacterComoCliente(IContextMemory memoriaJobChar, string otherCharacterID, bool defaultValue = false)
		{
			List<string> list;
			memoriaJobChar.TryFindDataArrayNull<string>("Conocidos.Client", out list);
			if (list == null)
			{
				return defaultValue;
			}
			return list.Contains(otherCharacterID);
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0001C9D4 File Offset: 0x0001ABD4
		public static void RegistrarCharacterComoEmpleador(IContextMemory memoriaJobChar, string otherCharacterID)
		{
			string text = "Conocidos.Employer";
			List<string> list;
			memoriaJobChar.TryFindDataArrayNull<string>(text, out list);
			if (list == null)
			{
				list = new List<string>();
			}
			if (!list.Contains(otherCharacterID))
			{
				list.Add(otherCharacterID);
			}
			memoriaJobChar.AddData<string>(text, list, true);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x0001CA14 File Offset: 0x0001AC14
		public static void RegistrarCharacterComoCliente(IContextMemory memoriaJobChar, string otherCharacterID)
		{
			string text = "Conocidos.Client";
			List<string> list;
			memoriaJobChar.TryFindDataArrayNull<string>(text, out list);
			if (list == null)
			{
				list = new List<string>();
			}
			if (!list.Contains(otherCharacterID))
			{
				list.Add(otherCharacterID);
			}
			memoriaJobChar.AddData<string>(text, list, true);
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x0001CA54 File Offset: 0x0001AC54
		public static bool CharacterEsCurrentEmpleador(IContextMemory memoriaJobChar, string otherCharacterID, bool defaultValue = false)
		{
			string text = memoriaJobChar.FindData("Employer", null);
			if (string.IsNullOrWhiteSpace(text))
			{
				return defaultValue;
			}
			return otherCharacterID == text;
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0001CA7F File Offset: 0x0001AC7F
		public static void RegistrarCharacterComoCurrentEmpleador(IContextMemory memoriaJobChar, string otherCharacterID)
		{
			memoriaJobChar.AddData("Employer", otherCharacterID, true);
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0001CA90 File Offset: 0x0001AC90
		public static bool CharacterWasLastClient(IContextMemory memoriaJobChar, string otherCharacterID, bool defaultValue = false)
		{
			string text = memoriaJobChar.FindData("Client", null);
			if (string.IsNullOrWhiteSpace(text))
			{
				return defaultValue;
			}
			return otherCharacterID == text;
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0001CABB File Offset: 0x0001ACBB
		public static void RegistrarCharacterComoLastClient(IContextMemory memoriaJobChar, string otherCharacterID)
		{
			memoriaJobChar.AddData("Client", otherCharacterID, true);
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x0001CACA File Offset: 0x0001ACCA
		public static int SesionesLaboralesDeCharacter(IContextMemory memoriaJobChar, int defaultValue = 0)
		{
			return memoriaJobChar.FindDataInt("SesionesC", defaultValue);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x0001CAD8 File Offset: 0x0001ACD8
		public static void RegistrarNewSesionesLaboralDeCharacter(IContextMemory memoriaJobChar)
		{
			int num = MemoriaDeSMAJobs.SesionesLaboralesDeCharacter(memoriaJobChar, 0);
			memoriaJobChar.AddData("SesionesC", num + 1, true);
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0001CAFC File Offset: 0x0001ACFC
		public static void AddClienteID(IContextMemory memoriaJob, Guid clienteID)
		{
			string text = clienteID.ToString();
			List<string> list;
			memoriaJob.TryFindDataArrayNull<string>("Client", out list);
			if (list == null)
			{
				list = new List<string>();
			}
			if (!list.Contains(text))
			{
				list.Add(text);
			}
			memoriaJob.AddData<string>("Client", list, true);
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x0001CB4C File Offset: 0x0001AD4C
		public static List<string> GetClienteStringID(IContextMemory memoriaJob)
		{
			List<string> list;
			if (!memoriaJob.TryFindDataArrayNull<string>("Client", out list))
			{
				return null;
			}
			return list;
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x0001CB6C File Offset: 0x0001AD6C
		public static List<Guid> GetClientesID(IContextMemory memoriaJob)
		{
			List<string> clienteStringID = MemoriaDeSMAJobs.GetClienteStringID(memoriaJob);
			if (clienteStringID == null)
			{
				return null;
			}
			List<Guid> list = new List<Guid>();
			foreach (string text in clienteStringID)
			{
				Guid guid;
				if (!string.IsNullOrWhiteSpace(text) && Guid.TryParse(text, out guid))
				{
					list.Add(guid);
				}
			}
			return list;
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0001CBE0 File Offset: 0x0001ADE0
		private static int GetWeekNumberOfMonth(DateTime date)
		{
			date = date.Date;
			DateTime dateTime = new DateTime(date.Year, date.Month, 1);
			DateTime dateTime2 = dateTime.AddDays((double)(((DayOfWeek)8 - (int)dateTime.DayOfWeek) % (DayOfWeek)7));
			if (dateTime2 > date)
			{
				dateTime = dateTime.AddMonths(-1);
				dateTime2 = dateTime.AddDays((double)(((DayOfWeek)8 - (int)dateTime.DayOfWeek) % (DayOfWeek)7));
			}
			return (date - dateTime2).Days / 7 + 1;
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0001CC59 File Offset: 0x0001AE59
		private static int GetWeekNumberOfMonthClamped(DateTime date)
		{
			return Mathf.Clamp(MemoriaDeSMAJobs.GetWeekNumberOfMonth(date), 1, 4) - 1;
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x0001CC6C File Offset: 0x0001AE6C
		private static int GetDayIndexOfWeekToFriday(DateTime date)
		{
			int num;
			if (date.Hour >= 0 && date.Hour < 12)
			{
				num = (int)((date.DayOfWeek + 6) % (DayOfWeek)7);
			}
			else
			{
				num = (int)((DayOfWeek.Friday - (int)date.DayOfWeek + 7) % (DayOfWeek)7);
			}
			if (num > 4)
			{
				num = Random.Range(0, 5);
			}
			return num;
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x0001CCB8 File Offset: 0x0001AEB8
		public static void AddOrReplaceEmpleadorID(IContextMemory memoriaJob, Guid emplyerID, DateTime date)
		{
			string text = emplyerID.ToString();
			List<string> list;
			memoriaJob.TryFindDataArrayNull<string>("Employer", out list);
			if (list == null)
			{
				list = new List<string>(5);
			}
			if (list.Count > 5)
			{
				list = new List<string>(list.Take(5));
				Debug.LogError("more that 5 emplyer where found in job :" + memoriaJob.id);
			}
			while (list.Count < 5)
			{
				list.Add(string.Empty);
			}
			int dayIndexOfWeekToFriday = MemoriaDeSMAJobs.GetDayIndexOfWeekToFriday(date);
			list[dayIndexOfWeekToFriday] = text;
			memoriaJob.AddData<string>("Employer", list, true);
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x0001CD48 File Offset: 0x0001AF48
		public static Guid GetEmpleadorID(IContextMemory memoriaJob, DateTime date)
		{
			int dayIndexOfWeekToFriday = MemoriaDeSMAJobs.GetDayIndexOfWeekToFriday(date);
			List<Guid> empleadoresID = MemoriaDeSMAJobs.GetEmpleadoresID(memoriaJob);
			if (empleadoresID != null && empleadoresID.ContieneIndex(dayIndexOfWeekToFriday))
			{
				return empleadoresID[dayIndexOfWeekToFriday];
			}
			return Guid.Empty;
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x0001CD7C File Offset: 0x0001AF7C
		public static List<string> GetEmpleadoresStringID(IContextMemory memoriaJob)
		{
			List<string> list;
			if (!memoriaJob.TryFindDataArrayNull<string>("Employer", out list))
			{
				return null;
			}
			return list;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0001CD9C File Offset: 0x0001AF9C
		public static List<Guid> GetEmpleadoresID(IContextMemory memoriaJob)
		{
			List<string> empleadoresStringID = MemoriaDeSMAJobs.GetEmpleadoresStringID(memoriaJob);
			if (empleadoresStringID == null)
			{
				return null;
			}
			List<Guid> list = new List<Guid>();
			foreach (string text in empleadoresStringID)
			{
				Guid guid;
				if (!string.IsNullOrWhiteSpace(text) && Guid.TryParse(text, out guid))
				{
					list.Add(guid);
				}
				else
				{
					list.Add(Guid.Empty);
				}
			}
			return list;
		}
	}
}
