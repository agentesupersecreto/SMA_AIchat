using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.UI.Interacciones.Donas.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.UI
{
	// Token: 0x02000056 RID: 86
	[Obsolete("usar la version para THS")]
	public abstract class OpcionesDeDonaDeCanIDisponibles : GenericOpcionesDeDonaDeKeys<int, OpcionesDeDonaDeCanIDisponibles.CurrentClicked>
	{
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000281 RID: 641
		public abstract int TipoID { get; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000282 RID: 642 RVA: 0x0000CED7 File Offset: 0x0000B0D7
		public Personalidad personalidad
		{
			get
			{
				return this.m_personalidad;
			}
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000CEDF File Offset: 0x0000B0DF
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000CF14 File Offset: 0x0000B114
		protected override void LoadKeys(HashSetList<int> resultado)
		{
			foreach (KeyValuePair<int, string> keyValuePair in OpcionesDeDonaDeCanIDisponibles.opciones)
			{
				resultado.Add(keyValuePair.Key);
			}
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000CF70 File Offset: 0x0000B170
		public override string TextDeKey(int key)
		{
			string text;
			try
			{
				text = OpcionesDeDonaDeCanIDisponibles.opciones[key];
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = key.ToString();
			}
			return text;
		}

		// Token: 0x04000107 RID: 263
		public static readonly Dictionary<int, string> opciones = new Dictionary<int, string>
		{
			{ 0, "Arms" },
			{ 1, "Legs" },
			{ 2, "Face" },
			{ 3, "Body" },
			{ 4, "Privates" }
		};

		// Token: 0x04000108 RID: 264
		private Personalidad m_personalidad;

		// Token: 0x0200008F RID: 143
		[Serializable]
		public class CurrentClicked : OpcionesDeDonaCurrentClickedKey<int>
		{
			// Token: 0x040001AF RID: 431
			public bool puede;
		}
	}
}
