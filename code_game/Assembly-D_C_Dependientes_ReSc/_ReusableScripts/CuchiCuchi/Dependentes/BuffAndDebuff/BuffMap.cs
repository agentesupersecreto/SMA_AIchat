using System;
using System.Text;
using Assets.Base.Plugins.Runtime;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff
{
	// Token: 0x020002BE RID: 702
	[CreateAssetMenu(fileName = "BuffMap", menuName = "Objetos/Buff/BuffMap")]
	public class BuffMap : ScriptableObject
	{
		// Token: 0x06001210 RID: 4624 RVA: 0x00055030 File Offset: 0x00053230
		public BuffEvento GetEventoBuff(DateTime start, string idSegundaria, ArgumentoDeEfecto argumento, BuffMap.Duracion duracionOverride = null)
		{
			if (argumento == null)
			{
				throw new ArgumentNullException("argumento", "argumento null reference.");
			}
			BuffEvento buffEvento = new BuffEvento();
			this.SetConfigToNewEvent(buffEvento, start, idSegundaria, argumento, duracionOverride);
			return buffEvento;
		}

		// Token: 0x06001211 RID: 4625 RVA: 0x00055064 File Offset: 0x00053264
		public T GetEventoBuff<T>(DateTime start, string idSegundaria, ArgumentoDeEfecto argumento, BuffMap.Duracion duracionOverride = null) where T : BuffEvento, new()
		{
			if (argumento == null)
			{
				throw new ArgumentNullException("argumento", "argumento null reference.");
			}
			T t = new T();
			this.SetConfigToNewEvent(t, start, idSegundaria, argumento, duracionOverride);
			return t;
		}

		// Token: 0x06001212 RID: 4626 RVA: 0x0005509C File Offset: 0x0005329C
		public static string GenerateBuffID(BuffMap buffMap, string idSegundaria)
		{
			return BuffMap.GenerateBuffID(buffMap.id, idSegundaria);
		}

		// Token: 0x06001213 RID: 4627 RVA: 0x000550AA File Offset: 0x000532AA
		public static string GenerateBuffID(string buffMapID, string idSegundaria)
		{
			if (string.IsNullOrWhiteSpace(buffMapID))
			{
				throw new ArgumentNullException("buffMapID", "buffMapID null reference.");
			}
			if (string.IsNullOrWhiteSpace(idSegundaria))
			{
				return buffMapID;
			}
			return buffMapID + "." + idSegundaria;
		}

		// Token: 0x06001214 RID: 4628 RVA: 0x000550DA File Offset: 0x000532DA
		public static string GenerateIdSegundaria(string idA, string idB)
		{
			if (string.IsNullOrWhiteSpace(idA))
			{
				throw new ArgumentNullException("idA", "idA null reference.");
			}
			if (string.IsNullOrWhiteSpace(idB))
			{
				throw new ArgumentNullException("idB", "idB null reference.");
			}
			return idA + "." + idB;
		}

		// Token: 0x06001215 RID: 4629 RVA: 0x00055118 File Offset: 0x00053318
		public static string GenerateIdSegundaria(string idA, string idB, string idC)
		{
			if (string.IsNullOrWhiteSpace(idC))
			{
				throw new ArgumentNullException("idC", "idC null reference.");
			}
			return BuffMap.GenerateIdSegundaria(idA, idB) + "." + idC;
		}

		// Token: 0x06001216 RID: 4630 RVA: 0x00055144 File Offset: 0x00053344
		public static string GenerateIdSegundaria(string idA, string idB, string idC, string idD)
		{
			if (string.IsNullOrWhiteSpace(idD))
			{
				throw new ArgumentNullException("idD", "idD null reference.");
			}
			return BuffMap.GenerateIdSegundaria(idA, idB, idC) + "." + idD;
		}

		// Token: 0x06001217 RID: 4631 RVA: 0x00055174 File Offset: 0x00053374
		public static string GenerateIdSegundaria(params string[] ids)
		{
			switch (ids.Length)
			{
			case 0:
				return string.Empty;
			case 1:
				return ids[0];
			case 2:
				return BuffMap.GenerateIdSegundaria(ids[0], ids[1]);
			case 3:
				return BuffMap.GenerateIdSegundaria(ids[0], ids[1], ids[2]);
			case 4:
				return BuffMap.GenerateIdSegundaria(ids[0], ids[1], ids[2], ids[3]);
			default:
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < ids.Length; i++)
				{
					string text = ids[i];
					if (string.IsNullOrWhiteSpace(text))
					{
						throw new ArgumentNullException("id", "id null reference.");
					}
					stringBuilder.Append(text);
					if (!i.IsLastIndex(ids.Length))
					{
						stringBuilder.Append('.');
					}
				}
				return stringBuilder.ToString();
			}
			}
		}

		// Token: 0x06001218 RID: 4632 RVA: 0x0005522C File Offset: 0x0005342C
		protected virtual void SetConfigToNewEvent(BuffEvento r, DateTime start, string idSegundaria, ArgumentoDeEfecto argumento, BuffMap.Duracion duracionOverride = null)
		{
			if ((duracionOverride == null && !this.duracion.infinite && this.duracion.timeSpan == TimeSpan.Zero) || (duracionOverride != null && !duracionOverride.infinite && duracionOverride.timeSpan == TimeSpan.Zero))
			{
				Debug.LogError("buff " + r.id + " durara nada, muy posiblemente nunca inicie");
			}
			r.id = BuffMap.GenerateBuffID(this.id, idSegundaria);
			r.buffID = this.id;
			r.idSegundaria = idSegundaria;
			r.forceVolatil = this.esVolatil;
			r.SetInitialStacks();
			r.nombre = this.nombre;
			r.quality = this.quality;
			r.priority = this.priority;
			r.showMessageOnStart = false;
			r.startDateTime = start;
			BuffMap.Duracion duracion;
			if (duracionOverride != null)
			{
				duracion = duracionOverride;
			}
			else
			{
				duracion = this.duracion;
			}
			if (duracion.infinite)
			{
				r.endDateTime = DateTime.MaxValue;
			}
			else
			{
				r.endDateTime = start + duracion.timeSpan;
			}
			r.efectoArgumento = argumento;
		}

		// Token: 0x04000D27 RID: 3367
		public string id;

		// Token: 0x04000D28 RID: 3368
		[StringSelectorV2(typeof(ProveedorDeStacksTipoIdsAttribute))]
		public string tipoDeStackID;

		// Token: 0x04000D29 RID: 3369
		[StringSelectorV2(typeof(ProveedorEfectosIdsAttribute))]
		public string efectoId;

		// Token: 0x04000D2A RID: 3370
		public string nombre;

		// Token: 0x04000D2B RID: 3371
		[Space]
		public bool esVolatil;

		// Token: 0x04000D2C RID: 3372
		public bool hidden;

		// Token: 0x04000D2D RID: 3373
		public ItemQuality quality;

		// Token: 0x04000D2E RID: 3374
		public int priority;

		// Token: 0x04000D2F RID: 3375
		[Tooltip("el efecto solo puede aplicarse una vez")]
		public bool onlyOnce;

		// Token: 0x04000D30 RID: 3376
		[Tooltip("al finalizar el buff, no se ejecutara 'Remover' en el efecto")]
		public bool efectoPermanente;

		// Token: 0x04000D31 RID: 3377
		[Tooltip("Default duracion")]
		public BuffMap.Duracion duracion = new BuffMap.Duracion();

		// Token: 0x04000D32 RID: 3378
		public BuffMap.Ticks ticks = new BuffMap.Ticks();

		// Token: 0x020002BF RID: 703
		[Serializable]
		public class Duracion
		{
			// Token: 0x17000453 RID: 1107
			// (get) Token: 0x0600121A RID: 4634 RVA: 0x00055370 File Offset: 0x00053570
			public TimeSpan timeSpan
			{
				get
				{
					return new TimeSpan(this.days, this.hours, this.minutes, this.seconds, 0);
				}
			}

			// Token: 0x04000D33 RID: 3379
			public bool infinite;

			// Token: 0x04000D34 RID: 3380
			[Range(0f, 365f)]
			public int days;

			// Token: 0x04000D35 RID: 3381
			[Range(0f, 24f)]
			public int hours;

			// Token: 0x04000D36 RID: 3382
			[Range(0f, 60f)]
			public int minutes;

			// Token: 0x04000D37 RID: 3383
			[Range(0f, 60f)]
			public int seconds;
		}

		// Token: 0x020002C0 RID: 704
		[Serializable]
		public class Ticks
		{
			// Token: 0x04000D38 RID: 3384
			[Tooltip("cada cuanto se actualiza el efecto")]
			public float tickTimeMin = -1f;

			// Token: 0x04000D39 RID: 3385
			[Tooltip("cada cuanto se actualiza el efecto")]
			public float tickTimeMax = -1f;
		}
	}
}
