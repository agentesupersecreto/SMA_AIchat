using System;
using System.Collections;
using System.Linq;
using Assets.Base.Tiempo.Runtime.Eventos;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff
{
	// Token: 0x020002B7 RID: 695
	[Serializable]
	public class BuffEnEspera : EventosLocales<BuffEvento>
	{
		// Token: 0x060011E3 RID: 4579 RVA: 0x000545FF File Offset: 0x000527FF
		public IEnumerator AddOrStackUpAfterStart(BuffEvento evento, bool sortAfter, bool UpdateStartTimeAndEndTime)
		{
			while (!base.owner.isStared)
			{
				yield return null;
			}
			this.AddOrStackUp(evento, sortAfter, UpdateStartTimeAndEndTime);
			yield break;
		}

		// Token: 0x060011E4 RID: 4580 RVA: 0x00054624 File Offset: 0x00052824
		public void AddOrStackUp(BuffEvento evento, bool sortAfter, bool UpdateStartTimeAndEndTime)
		{
			if (evento == null || string.IsNullOrWhiteSpace(evento.id))
			{
				throw new ArgumentNullException("evento", "evento null reference.");
			}
			if (!base.Add(evento, sortAfter))
			{
				BuffEvento buffEvento = this.eventos.FirstOrDefault((BuffEvento ev) => ev.id == evento.id);
				if (buffEvento == null)
				{
					throw new ArgumentNullException("existente", "se suponia que existia un evento de id: " + evento.id);
				}
				if (this.aconteciendo.eventos.FirstOrDefault((BuffEvento ev) => ev.id == evento.id) != null)
				{
					buffEvento.ForceRemoverEfecto();
					if (UpdateStartTimeAndEndTime)
					{
						TimeSpan timeSpan = evento.EndDateTime - evento.StartDateTime;
						buffEvento.startDateTime = Singleton<TiempoDeJuego>.instance.tiempoActual;
						buffEvento.endDateTime = buffEvento.StartDateTime + timeSpan;
					}
					buffEvento.ResolveStackingUp(evento);
					buffEvento.ForceApplyEfecto();
					return;
				}
				buffEvento.ResolveStackingUp(evento);
				if (UpdateStartTimeAndEndTime)
				{
					buffEvento.startDateTime = evento.StartDateTime;
					buffEvento.endDateTime = evento.EndDateTime;
				}
			}
		}

		// Token: 0x060011E5 RID: 4581 RVA: 0x00054778 File Offset: 0x00052978
		public void RemoveOrStackDown(BuffEvento evento)
		{
			if (evento == null)
			{
				throw new ArgumentNullException("evento", "evento null reference.");
			}
			BuffEvento buffEvento = this.eventos.FirstOrDefault((BuffEvento ev) => ev.id == evento.id);
			if (buffEvento == null)
			{
				return;
			}
			if (this.aconteciendo.eventos.FirstOrDefault((BuffEvento ev) => ev.id == evento.id) != null)
			{
				buffEvento.ForceRemoverEfecto();
				buffEvento.ResolveStackingDown(evento);
				if (buffEvento.stacks <= 0)
				{
					base.Remover(buffEvento);
					return;
				}
				buffEvento.ForceApplyEfecto();
				return;
			}
			else
			{
				buffEvento.ResolveStackingDown(evento);
				if (buffEvento.stacks <= 0)
				{
					base.Remover(buffEvento);
					return;
				}
				return;
			}
		}
	}
}
