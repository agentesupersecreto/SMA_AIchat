using System;
using System.Collections.Generic;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Scenas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores
{
	// Token: 0x02000528 RID: 1320
	[RequireComponent(typeof(Emocion))]
	public class ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion : CustomMonobehaviour
	{
		// Token: 0x06002038 RID: 8248 RVA: 0x0007A0BB File Offset: 0x000782BB
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Emocion = base.GetComponent<Emocion>();
		}

		// Token: 0x06002039 RID: 8249 RVA: 0x0007A0D0 File Offset: 0x000782D0
		public ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesMix GetModificador(InteracionEstimulanteBasica estimulo, ParteDelCuerpoHumano parteDelCuerpoHumano, ParteQuePuedeEstimular estimulante, bool esGolpe = false, SensitiveFemaleHoleType? siParteDelCuerpoHumanoEsHole = null)
		{
			InterationReceivedType interationReceivedType;
			SensitiveBodyPart sensitiveBodyPart;
			TriggeringBodyPart triggeringBodyPart;
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.GenericParser(out interationReceivedType, out sensitiveBodyPart, out triggeringBodyPart, estimulo, parteDelCuerpoHumano, estimulante, esGolpe, siParteDelCuerpoHumanoEsHole);
			return new ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesMix
			{
				advanced = this.GetModificadorAdvanced(interationReceivedType, triggeringBodyPart, sensitiveBodyPart),
				tradicional = this.GetModificadorTradicional(estimulo.tipoDeEstimulo, parteDelCuerpoHumano, new ParteQuePuedeEstimular?(estimulante), estimulo.tipo)
			};
		}

		// Token: 0x0600203A RID: 8250 RVA: 0x0007A128 File Offset: 0x00078328
		public static void GenericParser(out InterationReceivedType interationReceivedType, out SensitiveBodyPart sensitiveBodyPart, out TriggeringBodyPart triggeringBodyPart, InteracionEstimulanteBasica estimulo, ParteDelCuerpoHumano parteDelCuerpoHumano, ParteQuePuedeEstimular estimulante, bool esGolpe = false, SensitiveFemaleHoleType? siParteDelCuerpoHumanoEsHole = null)
		{
			InteraccionesEnScena.GenericParser(estimulo, parteDelCuerpoHumano, estimulante, esGolpe, siParteDelCuerpoHumanoEsHole, out interationReceivedType, out sensitiveBodyPart, out triggeringBodyPart);
		}

		// Token: 0x0600203B RID: 8251 RVA: 0x0007A13C File Offset: 0x0007833C
		public ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced GetModificadorAdvanced(InterationReceivedType interationReceivedType, TriggeringBodyPart fromPart, SensitiveBodyPart toPart)
		{
			ValueTuple<InterationReceivedType, SensitiveBodyPart, TriggeringBodyPart> valueTuple = new ValueTuple<InterationReceivedType, SensitiveBodyPart, TriggeringBodyPart>(interationReceivedType, toPart, fromPart);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificablesAdvanced;
			if (!this.m_modificablesV2.TryGetValue(valueTuple, out modificablesAdvanced))
			{
				return null;
			}
			return modificablesAdvanced;
		}

		// Token: 0x0600203C RID: 8252 RVA: 0x0007A168 File Offset: 0x00078368
		public ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced GetModificadorAdvanced(InteracionEstimulanteBasica estimulo, ParteDelCuerpoHumano parteDelCuerpoHumano, ParteQuePuedeEstimular estimulante, bool esGolpe = false, SensitiveFemaleHoleType? siParteDelCuerpoHumanoEsHole = null)
		{
			InterationReceivedType interationReceivedType;
			SensitiveBodyPart sensitiveBodyPart;
			TriggeringBodyPart triggeringBodyPart;
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.GenericParser(out interationReceivedType, out sensitiveBodyPart, out triggeringBodyPart, estimulo, parteDelCuerpoHumano, estimulante, esGolpe, siParteDelCuerpoHumanoEsHole);
			ValueTuple<InterationReceivedType, SensitiveBodyPart, TriggeringBodyPart> valueTuple = new ValueTuple<InterationReceivedType, SensitiveBodyPart, TriggeringBodyPart>(interationReceivedType, sensitiveBodyPart, triggeringBodyPart);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificablesAdvanced;
			if (!this.m_modificablesV2.TryGetValue(valueTuple, out modificablesAdvanced))
			{
				return null;
			}
			return modificablesAdvanced;
		}

		// Token: 0x0600203D RID: 8253 RVA: 0x0007A1A8 File Offset: 0x000783A8
		public ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced GetModificadorAdvancedNotNull(InterationReceivedType interationReceivedType, TriggeringBodyPart fromPart, SensitiveBodyPart toPart)
		{
			ValueTuple<InterationReceivedType, SensitiveBodyPart, TriggeringBodyPart> valueTuple = new ValueTuple<InterationReceivedType, SensitiveBodyPart, TriggeringBodyPart>(interationReceivedType, toPart, fromPart);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificablesAdvanced;
			if (!this.m_modificablesV2.TryGetValue(valueTuple, out modificablesAdvanced))
			{
				modificablesAdvanced = new ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced(interationReceivedType, fromPart, toPart);
				this.m_modificablesV2.Add(valueTuple, modificablesAdvanced);
			}
			return modificablesAdvanced;
		}

		// Token: 0x0600203E RID: 8254 RVA: 0x0007A1E8 File Offset: 0x000783E8
		public ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional GetModificadorTradicional(TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano parteDelCuerpoHumano, ParteQuePuedeEstimular? parteQuePuedeEstimular, DireccionDeEstimulo direccionDeEstimulo)
		{
			ValueTuple<TipoDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, DireccionDeEstimulo> valueTuple = new ValueTuple<TipoDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, DireccionDeEstimulo>(tipoDeEstimulo, parteDelCuerpoHumano, (parteQuePuedeEstimular == null) ? ParteQuePuedeEstimular.None : parteQuePuedeEstimular.Value, direccionDeEstimulo);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional modificablesTradicional;
			if (!this.m_modificables.TryGetValue(valueTuple, out modificablesTradicional))
			{
				return null;
			}
			return modificablesTradicional;
		}

		// Token: 0x0600203F RID: 8255 RVA: 0x0007A228 File Offset: 0x00078428
		public ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional GetModificadorTradicionalNotNull(TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano parteDelCuerpoHumano, ParteQuePuedeEstimular? parteQuePuedeEstimular, DireccionDeEstimulo direccionDeEstimulo)
		{
			ValueTuple<TipoDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, DireccionDeEstimulo> valueTuple = new ValueTuple<TipoDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, DireccionDeEstimulo>(tipoDeEstimulo, parteDelCuerpoHumano, (parteQuePuedeEstimular == null) ? ParteQuePuedeEstimular.None : parteQuePuedeEstimular.Value, direccionDeEstimulo);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional modificablesTradicional;
			if (!this.m_modificables.TryGetValue(valueTuple, out modificablesTradicional))
			{
				modificablesTradicional = new ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional(tipoDeEstimulo, parteDelCuerpoHumano, valueTuple.Item3, direccionDeEstimulo);
				this.m_modificables.Add(valueTuple, modificablesTradicional);
			}
			return modificablesTradicional;
		}

		// Token: 0x04001535 RID: 5429
		private Emocion m_Emocion;

		// Token: 0x04001536 RID: 5430
		private Dictionary<ValueTuple<TipoDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, DireccionDeEstimulo>, ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional> m_modificables = new Dictionary<ValueTuple<TipoDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, DireccionDeEstimulo>, ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional>();

		// Token: 0x04001537 RID: 5431
		[SerializeField]
		private List<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional> m_modificablesDEBUG = new List<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional>();

		// Token: 0x04001538 RID: 5432
		private Dictionary<ValueTuple<InterationReceivedType, SensitiveBodyPart, TriggeringBodyPart>, ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced> m_modificablesV2 = new Dictionary<ValueTuple<InterationReceivedType, SensitiveBodyPart, TriggeringBodyPart>, ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced>();

		// Token: 0x04001539 RID: 5433
		[SerializeField]
		private List<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced> m_modificablesV2DEBUG = new List<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced>();

		// Token: 0x02000529 RID: 1321
		[Serializable]
		public struct ModificablesMix
		{
			// Token: 0x0400153A RID: 5434
			public ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced advanced;

			// Token: 0x0400153B RID: 5435
			public ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional tradicional;
		}

		// Token: 0x0200052A RID: 1322
		[Serializable]
		public class ModificablesAdvanced
		{
			// Token: 0x06002041 RID: 8257 RVA: 0x0007A2B8 File Offset: 0x000784B8
			public ModificablesAdvanced(InterationReceivedType interationReceivedType, TriggeringBodyPart fromPart, SensitiveBodyPart toPart)
			{
				this.interationReceivedType = interationReceivedType;
				this.fromPart = fromPart;
				this.toPart = toPart;
			}

			// Token: 0x170008A6 RID: 2214
			// (get) Token: 0x06002042 RID: 8258 RVA: 0x0007A330 File Offset: 0x00078530
			public ModificableDeFloat interPositionMinMaxModificable
			{
				get
				{
					return this.m_interPositionMinMaxModificable;
				}
			}

			// Token: 0x170008A7 RID: 2215
			// (get) Token: 0x06002043 RID: 8259 RVA: 0x0007A338 File Offset: 0x00078538
			public ModificableDeFloat interPositionMinModificable
			{
				get
				{
					return this.m_interPositionMinModificable;
				}
			}

			// Token: 0x170008A8 RID: 2216
			// (get) Token: 0x06002044 RID: 8260 RVA: 0x0007A340 File Offset: 0x00078540
			public ModificableDeFloat interPositionMaxModificable
			{
				get
				{
					return this.m_interPositionMaxModificable;
				}
			}

			// Token: 0x170008A9 RID: 2217
			// (get) Token: 0x06002045 RID: 8261 RVA: 0x0007A348 File Offset: 0x00078548
			public ModificableDeFloat interExpandModificable
			{
				get
				{
					return this.m_interExpandModificable;
				}
			}

			// Token: 0x170008AA RID: 2218
			// (get) Token: 0x06002046 RID: 8262 RVA: 0x0007A350 File Offset: 0x00078550
			public ModificableDeFloat gainModificable
			{
				get
				{
					return this.m_gainModificable;
				}
			}

			// Token: 0x0400153C RID: 5436
			public InterationReceivedType interationReceivedType;

			// Token: 0x0400153D RID: 5437
			public TriggeringBodyPart fromPart;

			// Token: 0x0400153E RID: 5438
			public SensitiveBodyPart toPart;

			// Token: 0x0400153F RID: 5439
			private ModificableDeFloat m_interPositionMinMaxModificable = new ModificableDeFloat(1f);

			// Token: 0x04001540 RID: 5440
			private ModificableDeFloat m_interPositionMinModificable = new ModificableDeFloat(1f);

			// Token: 0x04001541 RID: 5441
			private ModificableDeFloat m_interPositionMaxModificable = new ModificableDeFloat(1f);

			// Token: 0x04001542 RID: 5442
			private ModificableDeFloat m_interExpandModificable = new ModificableDeFloat(1f);

			// Token: 0x04001543 RID: 5443
			private ModificableDeFloat m_gainModificable = new ModificableDeFloat(1f);
		}

		// Token: 0x0200052B RID: 1323
		[Serializable]
		public class ModificablesTradicional
		{
			// Token: 0x06002047 RID: 8263 RVA: 0x0007A358 File Offset: 0x00078558
			public ModificablesTradicional(TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano parteDelCuerpoHumano, ParteQuePuedeEstimular parteQuePuedeEstimular, DireccionDeEstimulo direccionDeEstimulo)
			{
				this.tipoDeEstimulo = tipoDeEstimulo;
				this.parteDelCuerpoHumano = parteDelCuerpoHumano;
				this.parteQuePuedeEstimular = parteQuePuedeEstimular;
				this.direccionDeEstimulo = direccionDeEstimulo;
			}

			// Token: 0x170008AB RID: 2219
			// (get) Token: 0x06002048 RID: 8264 RVA: 0x0007A3D8 File Offset: 0x000785D8
			public ModificableDeFloat interPositionMinMaxModificable
			{
				get
				{
					return this.m_interPositionMinMaxModificable;
				}
			}

			// Token: 0x170008AC RID: 2220
			// (get) Token: 0x06002049 RID: 8265 RVA: 0x0007A3E0 File Offset: 0x000785E0
			public ModificableDeFloat interPositionMinModificable
			{
				get
				{
					return this.m_interPositionMinModificable;
				}
			}

			// Token: 0x170008AD RID: 2221
			// (get) Token: 0x0600204A RID: 8266 RVA: 0x0007A3E8 File Offset: 0x000785E8
			public ModificableDeFloat interPositionMaxModificable
			{
				get
				{
					return this.m_interPositionMaxModificable;
				}
			}

			// Token: 0x170008AE RID: 2222
			// (get) Token: 0x0600204B RID: 8267 RVA: 0x0007A3F0 File Offset: 0x000785F0
			public ModificableDeFloat interExpandModificable
			{
				get
				{
					return this.m_interExpandModificable;
				}
			}

			// Token: 0x170008AF RID: 2223
			// (get) Token: 0x0600204C RID: 8268 RVA: 0x0007A3F8 File Offset: 0x000785F8
			public ModificableDeFloat gainModificable
			{
				get
				{
					return this.m_gainModificable;
				}
			}

			// Token: 0x04001544 RID: 5444
			public TipoDeEstimulo tipoDeEstimulo;

			// Token: 0x04001545 RID: 5445
			public ParteDelCuerpoHumano parteDelCuerpoHumano;

			// Token: 0x04001546 RID: 5446
			public ParteQuePuedeEstimular parteQuePuedeEstimular;

			// Token: 0x04001547 RID: 5447
			public DireccionDeEstimulo direccionDeEstimulo;

			// Token: 0x04001548 RID: 5448
			private ModificableDeFloat m_interPositionMinMaxModificable = new ModificableDeFloat(1f);

			// Token: 0x04001549 RID: 5449
			private ModificableDeFloat m_interPositionMinModificable = new ModificableDeFloat(1f);

			// Token: 0x0400154A RID: 5450
			private ModificableDeFloat m_interPositionMaxModificable = new ModificableDeFloat(1f);

			// Token: 0x0400154B RID: 5451
			private ModificableDeFloat m_interExpandModificable = new ModificableDeFloat(1f);

			// Token: 0x0400154C RID: 5452
			private ModificableDeFloat m_gainModificable = new ModificableDeFloat(1f);
		}
	}
}
