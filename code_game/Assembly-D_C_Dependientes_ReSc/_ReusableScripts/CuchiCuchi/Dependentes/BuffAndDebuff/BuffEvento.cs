using System;
using Assets.Base.Plugins.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.Tiempo;
using TValleCustomClases;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff
{
	// Token: 0x020002BC RID: 700
	[Serializable]
	public class BuffEvento : EventoUnicoNoVolatil
	{
		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x060011F4 RID: 4596 RVA: 0x000548F2 File Offset: 0x00052AF2
		public int stacks
		{
			get
			{
				return this.m_stacks;
			}
		}

		// Token: 0x060011F5 RID: 4597 RVA: 0x000548FA File Offset: 0x00052AFA
		public void SetInitialStacks()
		{
			this.m_stacks = 1;
		}

		// Token: 0x060011F6 RID: 4598 RVA: 0x00054904 File Offset: 0x00052B04
		protected override void NoVolatilStared()
		{
			base.NoVolatilStared();
			this.m_buff = Singleton<BuffManager>.instance.GetMap(this.buffID);
			if (this.m_buff == null)
			{
				Debug.Log("No se encontro buff con id: " + this.buffID);
				return;
			}
			this.m_Efecto = Singleton<EfectosManager>.instance.GetEfecto(this.m_buff.efectoId);
			if (this.m_Efecto == null)
			{
				Debug.LogError("No se encontro efecto con id: " + this.m_buff.efectoId, base.owner);
				return;
			}
			if (!this.m_buff.onlyOnce || !this.m_wasStarted)
			{
				this.ApplyEfecto();
			}
		}

		// Token: 0x060011F7 RID: 4599 RVA: 0x000549B8 File Offset: 0x00052BB8
		protected override void NoVolatilStayed()
		{
			base.NoVolatilStayed();
			this.CheckInstances();
			if (this.m_buff.ticks.tickTimeMin < 0f)
			{
				return;
			}
			if (this.m_buff.onlyOnce)
			{
				return;
			}
			if (this.m_buff.ticks.tickTimeMin > 0f)
			{
				if (!this.m_CoolDown.isOn)
				{
					this.StayEfecto();
					this.m_CoolDown.ApplyNext(Random.Range(this.m_buff.ticks.tickTimeMin, this.m_buff.ticks.tickTimeMax));
					return;
				}
			}
			else
			{
				this.StayEfecto();
			}
		}

		// Token: 0x060011F8 RID: 4600 RVA: 0x00054A58 File Offset: 0x00052C58
		protected override void NoVolatilEnded()
		{
			base.NoVolatilEnded();
			this.CheckInstances();
			if (!this.m_buff.efectoPermanente)
			{
				this.RemoverEfecto();
			}
		}

		// Token: 0x060011F9 RID: 4601 RVA: 0x00054A7C File Offset: 0x00052C7C
		private void CheckInstances()
		{
			if (this.m_buff == null)
			{
				this.m_buff = Singleton<BuffManager>.instance.GetMap(this.buffID);
				if (this.m_buff == null)
				{
					Debug.Log("No se encontro buff con id: " + this.buffID);
					return;
				}
			}
			if (this.m_Efecto == null)
			{
				this.m_Efecto = Singleton<EfectosManager>.instance.GetEfecto(this.m_buff.efectoId);
				if (this.m_Efecto == null)
				{
					Debug.LogError("No se encontro efecto con id: " + this.m_buff.efectoId, base.owner);
					return;
				}
			}
		}

		// Token: 0x060011FA RID: 4602 RVA: 0x00054B1D File Offset: 0x00052D1D
		public void ForceApplyEfecto()
		{
			this.CheckInstances();
			this.ApplyEfecto();
		}

		// Token: 0x060011FB RID: 4603 RVA: 0x00054B2B File Offset: 0x00052D2B
		public void ForceRemoverEfecto()
		{
			this.CheckInstances();
			this.RemoverEfecto();
		}

		// Token: 0x060011FC RID: 4604 RVA: 0x00054B3C File Offset: 0x00052D3C
		private void ApplyEfecto()
		{
			if (this.m_buff.onlyOnce && this.m_stacks != 1)
			{
				Debug.LogError("Aun no es compatible con efecto solo una vez y numero de stacks diferente a 1", base.owner);
			}
			int maxCountDeTipo = MapaSingleton<MapaDeTiposDeBuffStackableMaxCount>.instance.GetMaxCountDeTipo(this.m_buff.tipoDeStackID);
			if (maxCountDeTipo > 0)
			{
				this.m_stacks = Mathf.Clamp(this.m_stacks, 1, maxCountDeTipo);
			}
			this.m_Efecto.Apply(base.owner, this.efectoArgumento, this.m_stacks, this, null);
		}

		// Token: 0x060011FD RID: 4605 RVA: 0x00054BBC File Offset: 0x00052DBC
		private void StayEfecto()
		{
			if (this.m_buff.onlyOnce && this.m_stacks != 1)
			{
				Debug.LogError("Aun no es compatible con efecto solo una vez y numero de stacks diferente a 1", base.owner);
			}
			int maxCountDeTipo = MapaSingleton<MapaDeTiposDeBuffStackableMaxCount>.instance.GetMaxCountDeTipo(this.m_buff.tipoDeStackID);
			if (maxCountDeTipo > 0)
			{
				this.m_stacks = Mathf.Clamp(this.m_stacks, 1, maxCountDeTipo);
			}
			this.m_Efecto.Stay(base.owner, this.efectoArgumento, this.m_stacks, this, null);
		}

		// Token: 0x060011FE RID: 4606 RVA: 0x00054C3C File Offset: 0x00052E3C
		private void RemoverEfecto()
		{
			if (this.m_buff.efectoPermanente && this.m_stacks != 1)
			{
				Debug.LogError("Aun no es compatible con efecto permanente y numero de stacks diferente a 1", base.owner);
			}
			this.m_Efecto.Remove(base.owner, this.efectoArgumento, this.m_stacks, this, null);
		}

		// Token: 0x060011FF RID: 4607 RVA: 0x00054C90 File Offset: 0x00052E90
		protected override void GuardarEventoAMemoria(IJsonMemoryNode eventoMem)
		{
			base.GuardarEventoAMemoria(eventoMem);
			eventoMem.AddData("buffID", this.buffID, true);
			eventoMem.AddData("idSegundaria", this.idSegundaria, true);
			eventoMem.AddData("stacks", this.m_stacks, true);
			eventoMem.AddData("displayFirst", this.displayFirst, true);
			eventoMem.AddData("priority", this.priority, true);
			eventoMem.AddData("quality", (int)this.quality, true);
			eventoMem.AddDataObject("efectoArgumento", this.efectoArgumento, true);
		}

		// Token: 0x06001200 RID: 4608 RVA: 0x00054D24 File Offset: 0x00052F24
		protected override void CargarEventoDesdeMemoria(IJsonMemoryNode eventoMem, string eventoID)
		{
			base.CargarEventoDesdeMemoria(eventoMem, eventoID);
			this.buffID = eventoMem.FindData("buffID");
			this.idSegundaria = eventoMem.FindData("idSegundaria");
			this.m_stacks = eventoMem.FindDataInt("stacks", 1);
			this.priority = eventoMem.FindDataInt("priority", 0);
			this.displayFirst = eventoMem.FindDataBool("displayFirst", false);
			this.quality = (ItemQuality)eventoMem.FindDataInt("quality", 0);
			BuffMap map = Singleton<BuffManager>.instance.GetMap(this.buffID);
			if (map == null)
			{
				Debug.Log("No se encontro buff con id: " + this.buffID);
			}
			Efecto efecto = Singleton<EfectosManager>.instance.GetEfecto(map.efectoId);
			if (efecto == null)
			{
				Debug.LogError("No se pudo cargar efecto de id " + map.efectoId, base.owner);
			}
			string argumentoID = efecto.argumentoID;
			Type argumentoType = Singleton<ArgumentosDeEfectosManager>.instance.GetArgumentoType(argumentoID);
			if (argumentoType == null)
			{
				Debug.LogError("No se pudo cargar argumento Type de id " + argumentoID, base.owner);
			}
			object obj;
			if (!eventoMem.TryFindDataObject("efectoArgumento", argumentoType, out obj, null) || obj == null)
			{
				Debug.LogError("no se pudo deserializar argumento de tipo: " + argumentoType.Name);
			}
			this.efectoArgumento = (ArgumentoDeEfecto)obj;
		}

		// Token: 0x06001201 RID: 4609 RVA: 0x00054E66 File Offset: 0x00053066
		public void ResolveStackingUp(BuffEvento other)
		{
			if (other == this)
			{
				throw new InvalidOperationException();
			}
			this.OnStackingUp(other);
		}

		// Token: 0x06001202 RID: 4610 RVA: 0x00054E79 File Offset: 0x00053079
		public void ResolveStackingDown(BuffEvento other)
		{
			if (other == this)
			{
				throw new InvalidOperationException();
			}
			this.OnStackingDown(other);
		}

		// Token: 0x06001203 RID: 4611 RVA: 0x00054E8C File Offset: 0x0005308C
		protected virtual void OnStackingUp(BuffEvento other)
		{
			this.DefaultStackingUp();
		}

		// Token: 0x06001204 RID: 4612 RVA: 0x00054E94 File Offset: 0x00053094
		protected void DefaultStackingUp()
		{
			this.m_stacks++;
		}

		// Token: 0x06001205 RID: 4613 RVA: 0x00054EA4 File Offset: 0x000530A4
		protected virtual void OnStackingDown(BuffEvento other)
		{
			this.DefaultStackingDown();
		}

		// Token: 0x06001206 RID: 4614 RVA: 0x00054EAC File Offset: 0x000530AC
		protected void DefaultStackingDown()
		{
			this.m_stacks--;
		}

		// Token: 0x06001207 RID: 4615 RVA: 0x00054EBC File Offset: 0x000530BC
		public void UpdateQuality(float min, float med, float max, float value, float outPower, bool notInverted, out float weight)
		{
			weight = MathfExtension.InverseLerpConMedio(min, med, max, value);
			this.quality = (ItemQuality)Mathf.RoundToInt(MathfExtension.LerpConMedio((float)((!notInverted) ? 13 : 1), 7f, (float)((!notInverted) ? 1 : 13), weight.InInOutOutPow(outPower, outPower, 0.5f)));
		}

		// Token: 0x04000D1A RID: 3354
		private const string stacksSerialName = "stacks";

		// Token: 0x04000D1B RID: 3355
		public string buffID;

		// Token: 0x04000D1C RID: 3356
		public string idSegundaria;

		// Token: 0x04000D1D RID: 3357
		[FormerlySerializedAs("stacks")]
		private int m_stacks;

		// Token: 0x04000D1E RID: 3358
		public bool displayFirst;

		// Token: 0x04000D1F RID: 3359
		public int priority;

		// Token: 0x04000D20 RID: 3360
		public ItemQuality quality;

		// Token: 0x04000D21 RID: 3361
		[SerializeReference]
		public ArgumentoDeEfecto efectoArgumento;

		// Token: 0x04000D22 RID: 3362
		[SerializeField]
		protected BuffMap m_buff;

		// Token: 0x04000D23 RID: 3363
		[SerializeReference]
		private Efecto m_Efecto;

		// Token: 0x04000D24 RID: 3364
		[NonSerialized]
		private CoolDown m_CoolDown = new CoolDown();
	}
}
