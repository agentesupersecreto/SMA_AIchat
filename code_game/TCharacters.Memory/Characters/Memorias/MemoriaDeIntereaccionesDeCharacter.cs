using System;
using System.Collections.Generic;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.Memorias.JsonMemorias.Clases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Memorias
{
	// Token: 0x02000006 RID: 6
	[MemoriaRelatedBehaviour]
	public class MemoriaDeIntereaccionesDeCharacter : MemoriaDeCharacterBase
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002474 File Offset: 0x00000674
		public override bool permanente
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002477 File Offset: 0x00000677
		public override string selfMemKeyName
		{
			get
			{
				return "Interactions";
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002480 File Offset: 0x00000680
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ownCharacter = this.GetComponentEnRoot(false);
			if (this.m_ownCharacter == null)
			{
				throw new ArgumentNullException("m_ownCharacter", "m_ownCharacter null reference.");
			}
			this.m_ReportadorInteraccionesEnScenaAMemoria = this.GetComponentEnRoot(false);
			if (this.m_ReportadorInteraccionesEnScenaAMemoria == null)
			{
				throw new ArgumentNullException("m_ReportadorInteraccionesEnScenaAMemoria", "m_ReportadorInteraccionesEnScenaAMemoria null reference.");
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000024EC File Offset: 0x000006EC
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (this.m_ReportadorInteraccionesEnScenaAMemoria != null)
			{
				this.m_ReportadorInteraccionesEnScenaAMemoria.onRegistroDadoChanged += this.M_ReportadorInteraccionesEnScenaAMemoria_onRegistroDadoChanged;
				this.m_ReportadorInteraccionesEnScenaAMemoria.onRegistroRecibidoChanged += this.M_ReportadorInteraccionesEnScenaAMemoria_onRegistroRecibidoChanged;
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000253C File Offset: 0x0000073C
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_ReportadorInteraccionesEnScenaAMemoria != null)
			{
				this.m_ReportadorInteraccionesEnScenaAMemoria.onRegistroDadoChanged -= this.M_ReportadorInteraccionesEnScenaAMemoria_onRegistroDadoChanged;
				this.m_ReportadorInteraccionesEnScenaAMemoria.onRegistroRecibidoChanged -= this.M_ReportadorInteraccionesEnScenaAMemoria_onRegistroRecibidoChanged;
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000258C File Offset: 0x0000078C
		private void M_ReportadorInteraccionesEnScenaAMemoria_onRegistroRecibidoChanged(ref Interaction registro)
		{
			if (this.m_ownCharacter.ID_UnicoString != registro.toID)
			{
				Debug.LogError("registro no pertenece a este character", this.m_ownCharacter);
				return;
			}
			Guid guid;
			if (Guid.TryParse(registro.fromID, out guid))
			{
				this.m_RecibidoDesdeCharacter.AddOrChange(ref registro, ref guid);
			}
			this.m_Recibidas.Add(ref registro, true, false);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000025F0 File Offset: 0x000007F0
		private void M_ReportadorInteraccionesEnScenaAMemoria_onRegistroDadoChanged(ref Interaction registro)
		{
			if (this.m_ownCharacter.ID_UnicoString != registro.fromID)
			{
				Debug.LogError("registro no pertenece a este character", this.m_ownCharacter);
				return;
			}
			Guid guid;
			if (Guid.TryParse(registro.toID, out guid))
			{
				this.m_DadoHaciaCharacter.AddOrChange(ref registro, ref guid);
			}
			this.m_Dadas.Add(ref registro, false, true);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002654 File Offset: 0x00000854
		protected override void OnLoadMemory(JsonMemoryNode fromMemory)
		{
			this.m_RecibidoDesdeCharacter = new MemoriaDeIntereaccionesDeCharacter.MemoriaDiccsOtherCharacter();
			this.m_DadoHaciaCharacter = new MemoriaDeIntereaccionesDeCharacter.MemoriaDiccsOtherCharacter();
			this.m_Recibidas = new MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs();
			this.m_Dadas = new MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs();
			JsonMemoryNode jsonMemoryNode = fromMemory.FindChildNotNull("Taken");
			JsonMemoryNode jsonMemoryNode2 = fromMemory.FindChildNotNull("Given");
			MemoriaDeIntereaccionesDeCharacter.LoadDicc(this.m_RecibidoDesdeCharacter.interacciones, jsonMemoryNode, this.m_ownCharacter.ID_UnicoString, false);
			MemoriaDeIntereaccionesDeCharacter.LoadDicc(this.m_Recibidas.past, this.m_Recibidas.allTime, jsonMemoryNode, string.Empty, this.m_ownCharacter.ID_UnicoString);
			MemoriaDeIntereaccionesDeCharacter.LoadDicc(this.m_DadoHaciaCharacter.interacciones, jsonMemoryNode2, this.m_ownCharacter.ID_UnicoString, true);
			MemoriaDeIntereaccionesDeCharacter.LoadDicc(this.m_Dadas.past, this.m_Dadas.allTime, jsonMemoryNode2, this.m_ownCharacter.ID_UnicoString, string.Empty);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002738 File Offset: 0x00000938
		protected override void OnSavingMemory(JsonMemoryNode toMemory)
		{
			JsonMemoryNode jsonMemoryNode = toMemory.FindChildNotNull("Taken");
			JsonMemoryNode jsonMemoryNode2 = toMemory.FindChildNotNull("Given");
			jsonMemoryNode.ResetMemoria();
			jsonMemoryNode2.ResetMemoria();
			MemoriaDeIntereaccionesDeCharacter.SaveDicc(this.m_RecibidoDesdeCharacter.interacciones, jsonMemoryNode);
			MemoriaDeIntereaccionesDeCharacter.SaveDicc(this.m_Recibidas.allTime, jsonMemoryNode);
			MemoriaDeIntereaccionesDeCharacter.SaveDicc(this.m_DadoHaciaCharacter.interacciones, jsonMemoryNode2);
			MemoriaDeIntereaccionesDeCharacter.SaveDicc(this.m_Dadas.allTime, jsonMemoryNode2);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000027B0 File Offset: 0x000009B0
		public void GetRegistro(Guid otherChar, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro type, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro direccion, TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool triggerMaxValue, out Interaction registro)
		{
			registro = default(Interaction);
			ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> valueTuple = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(fromPart, toPart, interationReceivedType, emotion, triggerMaxValue);
			MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs memoriaDiccs;
			if (direccion != MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido)
			{
				if (direccion != MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.dado)
				{
					throw new ArgumentOutOfRangeException(direccion.ToString());
				}
				this.m_DadoHaciaCharacter.interacciones.TryGetValue(otherChar, out memoriaDiccs);
			}
			else
			{
				this.m_RecibidoDesdeCharacter.interacciones.TryGetValue(otherChar, out memoriaDiccs);
			}
			if (memoriaDiccs == null)
			{
				return;
			}
			switch (type)
			{
			case MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.allTime:
			{
				MemoriaDeIntereaccionesDeCharacter.InteractionBox interactionBox;
				if (memoriaDiccs.allTime.TryGetValue(valueTuple, out interactionBox))
				{
					registro = interactionBox.interaction;
					return;
				}
				break;
			}
			case MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.past:
			{
				MemoriaDeIntereaccionesDeCharacter.InteractionBox interactionBox2;
				if (memoriaDiccs.past.TryGetValue(valueTuple, out interactionBox2))
				{
					registro = interactionBox2.interaction;
					return;
				}
				break;
			}
			case MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session:
			{
				MemoriaDeIntereaccionesDeCharacter.InteractionBox interactionBox3;
				if (memoriaDiccs.session.TryGetValue(valueTuple, out interactionBox3))
				{
					registro = interactionBox3.interaction;
					return;
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException(type.ToString());
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000028A4 File Offset: 0x00000AA4
		public void GetRegistro(MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro type, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro direccion, TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool triggerMaxValue, out Interaction registro)
		{
			registro = default(Interaction);
			ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> valueTuple = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(fromPart, toPart, interationReceivedType, emotion, triggerMaxValue);
			MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs memoriaDiccs;
			if (direccion != MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido)
			{
				if (direccion != MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.dado)
				{
					throw new ArgumentOutOfRangeException(direccion.ToString());
				}
				memoriaDiccs = this.m_Dadas;
			}
			else
			{
				memoriaDiccs = this.m_Recibidas;
			}
			if (memoriaDiccs == null)
			{
				return;
			}
			switch (type)
			{
			case MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.allTime:
			{
				MemoriaDeIntereaccionesDeCharacter.InteractionBox interactionBox;
				if (memoriaDiccs.allTime.TryGetValue(valueTuple, out interactionBox))
				{
					registro = interactionBox.interaction;
					return;
				}
				break;
			}
			case MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.past:
			{
				MemoriaDeIntereaccionesDeCharacter.InteractionBox interactionBox2;
				if (memoriaDiccs.past.TryGetValue(valueTuple, out interactionBox2))
				{
					registro = interactionBox2.interaction;
					return;
				}
				break;
			}
			case MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session:
			{
				MemoriaDeIntereaccionesDeCharacter.InteractionBox interactionBox3;
				if (memoriaDiccs.session.TryGetValue(valueTuple, out interactionBox3))
				{
					registro = interactionBox3.interaction;
					return;
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException(type.ToString());
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002980 File Offset: 0x00000B80
		public int CantidadDeOrgasmosJunto(Guid otherChar, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro type, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro direccion)
		{
			Interaction interaction;
			this.GetRegistro(otherChar, type, direccion, TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.All, Emotion.pleasure, true, out interaction);
			return interaction.times;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000029A4 File Offset: 0x00000BA4
		public int CantidadDePlacenterosJunto(Guid otherChar, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro type, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro direccion, InterationReceivedType interationReceivedType)
		{
			Interaction interaction;
			this.GetRegistro(otherChar, type, direccion, TriggeringBodyPart.All, SensitiveBodyPart.All, interationReceivedType, Emotion.pleasure, false, out interaction);
			return interaction.times;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000029C8 File Offset: 0x00000BC8
		public int CantidadDePlacenterosJunto(Guid otherChar, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro type, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro direccion, InterationReceivedType interationReceivedType, SensitiveBodyPart toPart)
		{
			Interaction interaction;
			this.GetRegistro(otherChar, type, direccion, TriggeringBodyPart.All, toPart, interationReceivedType, Emotion.pleasure, false, out interaction);
			return interaction.times;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000029F0 File Offset: 0x00000BF0
		private static void SaveDicc(Dictionary<Guid, MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs> interaccionesConOtherCharacter, JsonMemoryNode memoria)
		{
			foreach (KeyValuePair<Guid, MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs> keyValuePair in interaccionesConOtherCharacter)
			{
				Guid key = keyValuePair.Key;
				MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs value = keyValuePair.Value;
				JsonMemoryNode jsonMemoryNode = memoria.FindChildNotNull(key.ToString());
				MemoriaDeIntereaccionesDeCharacter.SaveDicc(value.allTime, jsonMemoryNode);
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002A68 File Offset: 0x00000C68
		private static void LoadDicc(Dictionary<Guid, MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs> interaccionesConOtherCharacter, JsonMemoryNode memoria, string selfID, bool selfIdIsFromOrTo)
		{
			foreach (JsonMemoryNode jsonMemoryNode in memoria.children)
			{
				Guid guid;
				if (!Guid.TryParse(jsonMemoryNode.id, out guid))
				{
					Debug.LogError("no se puedo convertirt string a id " + jsonMemoryNode.id);
				}
				else if (MemoriaDeCharacterBase.PersonajeExisteAndLog(memoria.memory, memoria.id, jsonMemoryNode.id))
				{
					MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs memoriaDiccs = new MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs();
					if (!interaccionesConOtherCharacter.TryAdd(guid, memoriaDiccs))
					{
						Debug.LogError("ya existia otras interacciones de personaje " + jsonMemoryNode.id + " en memoria");
					}
					else
					{
						MemoriaDeIntereaccionesDeCharacter.LoadDicc(memoriaDiccs.past, memoriaDiccs.allTime, jsonMemoryNode, selfIdIsFromOrTo ? selfID : jsonMemoryNode.id, (!selfIdIsFromOrTo) ? selfID : jsonMemoryNode.id);
					}
				}
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002B4C File Offset: 0x00000D4C
		private static void SaveDicc(Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, MemoriaDeIntereaccionesDeCharacter.InteractionBox> allTimeData, JsonMemoryNode memoria)
		{
			foreach (KeyValuePair<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, MemoriaDeIntereaccionesDeCharacter.InteractionBox> keyValuePair in allTimeData)
			{
				ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key = keyValuePair.Key;
				MemoriaDeIntereaccionesDeCharacter.Key key2 = MemoriaDeIntereaccionesDeCharacter.Key.SetKey(ref key);
				InteractionToDisk interactionToDisk = keyValuePair.Value.interaction.ToDiskInter();
				interactionToDisk.tID = string.Empty;
				interactionToDisk.fID = string.Empty;
				memoria.AddDataValue(ref key2, ref interactionToDisk, true);
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002BDC File Offset: 0x00000DDC
		private static void LoadDicc(Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, MemoriaDeIntereaccionesDeCharacter.InteractionBox> pastData, Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, MemoriaDeIntereaccionesDeCharacter.InteractionBox> allTimeData, JsonMemoryNode memoria, string formID, string toID)
		{
			foreach (KeyValuePair<string, string> keyValuePair in memoria.data)
			{
				string key = keyValuePair.Key;
				MemoriaDeIntereaccionesDeCharacter.Key key2;
				InteractionToDisk interactionToDisk;
				if (!memoria.TryFindDataValue(key, out key2, out interactionToDisk))
				{
					Debug.LogError("no se puedo des serializar interacion de character " + key + " con valor " + keyValuePair.Value);
				}
				else
				{
					Interaction interaction = interactionToDisk.ToInter();
					interaction.toID = toID;
					interaction.fromID = formID;
					MemoriaDeIntereaccionesDeCharacter.InteractionBox interactionBox = new MemoriaDeIntereaccionesDeCharacter.InteractionBox();
					interactionBox.interaction = interaction;
					if (!pastData.TryAdd(key2.GetKey(), interactionBox))
					{
						Debug.LogError("ya existia otra interaccion " + key2.GetKey().ToString() + " en memoria");
					}
					else
					{
						MemoriaDeIntereaccionesDeCharacter.InteractionBox interactionBox2 = new MemoriaDeIntereaccionesDeCharacter.InteractionBox();
						interactionBox2.interaction = interaction;
						if (!allTimeData.TryAdd(key2.GetKey(), interactionBox2))
						{
							Debug.LogError("ya existia otra interaccion " + key2.GetKey().ToString() + " en memoria");
						}
					}
				}
			}
		}

		// Token: 0x04000002 RID: 2
		private const string DataKey = "Interactions";

		// Token: 0x04000003 RID: 3
		private const string RecibidasDataKey = "Taken";

		// Token: 0x04000004 RID: 4
		private const string DadasDataKey = "Given";

		// Token: 0x04000005 RID: 5
		private ReportadorInteraccionesEnScenaAMemoria m_ReportadorInteraccionesEnScenaAMemoria;

		// Token: 0x04000006 RID: 6
		private MemoriaDeIntereaccionesDeCharacter.MemoriaDiccsOtherCharacter m_RecibidoDesdeCharacter = new MemoriaDeIntereaccionesDeCharacter.MemoriaDiccsOtherCharacter();

		// Token: 0x04000007 RID: 7
		private MemoriaDeIntereaccionesDeCharacter.MemoriaDiccsOtherCharacter m_DadoHaciaCharacter = new MemoriaDeIntereaccionesDeCharacter.MemoriaDiccsOtherCharacter();

		// Token: 0x04000008 RID: 8
		private MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs m_Recibidas = new MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs();

		// Token: 0x04000009 RID: 9
		private MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs m_Dadas = new MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs();

		// Token: 0x0400000A RID: 10
		private Character m_ownCharacter;

		// Token: 0x02000013 RID: 19
		public enum TipoDeRegistro
		{
			// Token: 0x04000051 RID: 81
			allTime,
			// Token: 0x04000052 RID: 82
			past,
			// Token: 0x04000053 RID: 83
			session
		}

		// Token: 0x02000014 RID: 20
		public enum DireccionDeRegistro
		{
			// Token: 0x04000055 RID: 85
			recibido,
			// Token: 0x04000056 RID: 86
			dado
		}

		// Token: 0x02000015 RID: 21
		[Serializable]
		public class MemoriaDiccsOtherCharacter
		{
			// Token: 0x060000FB RID: 251 RVA: 0x00006530 File Offset: 0x00004730
			public void AddOrChange(ref Interaction registro, ref Guid otherID)
			{
				MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs memoriaDiccs;
				if (!this.interacciones.TryGetValue(otherID, out memoriaDiccs))
				{
					memoriaDiccs = new MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs();
					this.interacciones.Add(otherID, memoriaDiccs);
				}
				memoriaDiccs.Add(ref registro, false, false);
			}

			// Token: 0x04000057 RID: 87
			public Dictionary<Guid, MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs> interacciones = new Dictionary<Guid, MemoriaDeIntereaccionesDeCharacter.MemoriaDiccs>();
		}

		// Token: 0x02000016 RID: 22
		[Serializable]
		public class MemoriaDiccs
		{
			// Token: 0x060000FD RID: 253 RVA: 0x00006588 File Offset: 0x00004788
			public void Add(ref Interaction registro, bool clearFrom, bool clearTo)
			{
				ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key = registro.GetKey();
				MemoriaDeIntereaccionesDeCharacter.InteractionBox interactionBox;
				if (!this.session.TryGetValue(key, out interactionBox))
				{
					interactionBox = new MemoriaDeIntereaccionesDeCharacter.InteractionBox();
					this.session.Add(key, interactionBox);
				}
				interactionBox.interaction = registro;
				if (clearFrom)
				{
					interactionBox.interaction.fromID = string.Empty;
				}
				if (clearTo)
				{
					interactionBox.interaction.toID = string.Empty;
				}
				MemoriaDeIntereaccionesDeCharacter.InteractionBox interactionBox2;
				this.past.TryGetValue(key, out interactionBox2);
				MemoriaDeIntereaccionesDeCharacter.InteractionBox interactionBox3;
				if (!this.allTime.TryGetValue(key, out interactionBox3))
				{
					interactionBox3 = new MemoriaDeIntereaccionesDeCharacter.InteractionBox();
					this.allTime.Add(key, interactionBox3);
				}
				if (interactionBox2 != null)
				{
					Interaction interaction = interactionBox2.interaction;
					Interaction.AddFromDifferentRecordings(ref interaction, ref registro);
					interactionBox3.interaction = interaction;
				}
				else
				{
					interactionBox3.interaction = registro;
				}
				if (clearFrom)
				{
					interactionBox3.interaction.fromID = string.Empty;
				}
				if (clearTo)
				{
					interactionBox3.interaction.toID = string.Empty;
				}
			}

			// Token: 0x04000058 RID: 88
			public Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, MemoriaDeIntereaccionesDeCharacter.InteractionBox> past = new Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, MemoriaDeIntereaccionesDeCharacter.InteractionBox>();

			// Token: 0x04000059 RID: 89
			public Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, MemoriaDeIntereaccionesDeCharacter.InteractionBox> allTime = new Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, MemoriaDeIntereaccionesDeCharacter.InteractionBox>();

			// Token: 0x0400005A RID: 90
			public Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, MemoriaDeIntereaccionesDeCharacter.InteractionBox> session = new Dictionary<ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>, MemoriaDeIntereaccionesDeCharacter.InteractionBox>();
		}

		// Token: 0x02000017 RID: 23
		[Serializable]
		public class InteractionBox
		{
			// Token: 0x0400005B RID: 91
			public Interaction interaction;
		}

		// Token: 0x02000018 RID: 24
		[Serializable]
		public struct Key
		{
			// Token: 0x06000100 RID: 256 RVA: 0x000066A4 File Offset: 0x000048A4
			public static MemoriaDeIntereaccionesDeCharacter.Key SetKey(TriggeringBodyPart fromPart, SensitiveBodyPart toPart, InterationReceivedType interationReceivedType, Emotion emotion, bool triggerMaxValue)
			{
				return new MemoriaDeIntereaccionesDeCharacter.Key
				{
					fr = fromPart,
					to = toPart,
					tp = interationReceivedType,
					emo = emotion,
					mV = triggerMaxValue
				};
			}

			// Token: 0x06000101 RID: 257 RVA: 0x000066E4 File Offset: 0x000048E4
			public static MemoriaDeIntereaccionesDeCharacter.Key SetKey(ref ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key)
			{
				return new MemoriaDeIntereaccionesDeCharacter.Key
				{
					fr = key.Item1,
					to = key.Item2,
					tp = key.Item3,
					emo = key.Item4,
					mV = key.Item5
				};
			}

			// Token: 0x06000102 RID: 258 RVA: 0x0000673B File Offset: 0x0000493B
			public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> GetKey()
			{
				return new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(this.fr, this.to, this.tp, this.emo, this.mV);
			}

			// Token: 0x0400005C RID: 92
			public TriggeringBodyPart fr;

			// Token: 0x0400005D RID: 93
			public SensitiveBodyPart to;

			// Token: 0x0400005E RID: 94
			public InterationReceivedType tp;

			// Token: 0x0400005F RID: 95
			public Emotion emo;

			// Token: 0x04000060 RID: 96
			public bool mV;
		}
	}
}
